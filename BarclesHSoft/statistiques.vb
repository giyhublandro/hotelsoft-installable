Imports System.IO
Imports MySql.Data.MySqlClient

Public Class statistiques

    'STATISTIQUES

    'Public Function InsertStatistique(ByVal CODE_STATISTIQUE As String, ByVal DATE_DE_TRAVAIL As Date, ByVal NOMBRE_DEPART_INITIAL As Integer, ByVal NOMBRE_DEPART_EFFECTUE As Integer, ByVal NOMBRE_ARRIVEE_INITIAL As Integer, ByVal NOMBRE_ARRIVEE_EFFECTUE As Integer, ByVal NOMBRE_CHAMBRE_OCCUPEE As Integer, ByVal NOMBRE_CHAMBRE_LIBRE As Integer, ByVal NOMBRE_CHAMBRE_TOTAL As Integer, ByVal TAUX_OCCUPATION As Double, ByVal RECETTE_TOTAL_PAR_CHAMBRE As Double, ByVal REVENU_MOYEN_PAR_CHAMBRE_DISPONIBLE As Double, ByVal RECETTE_MOYENNE_PAR_CHAMBRE_LOUEE As Double, ByVal CODE_AGENCE As String, ByVal NOMBRE_EN_CHAMBRE_INITIAL As Integer, ByVal NOMBRE_EN_CHAMBRE_FINAL As Integer, ByVal NOMBRE_EN_CHAMBRE_EFFECTUE As Integer) As Boolean
    Public Function InsertStatistique(ByVal CODE_STATISTIQUE As String, ByVal DATE_DE_TRAVAIL As Date, ByVal NOMBRE_DEPART_INITIAL As Integer, ByVal NOMBRE_DEPART_EFFECTUE As Integer, ByVal NOMBRE_ARRIVEE_INITIAL As Integer, ByVal NOMBRE_ARRIVEE_EFFECTUE As Integer, ByVal NOMBRE_CHAMBRE_OCCUPEE As Integer, ByVal NOMBRE_CHAMBRE_LIBRE As Integer, ByVal NOMBRE_CHAMBRE_TOTAL As Integer, ByVal TAUX_OCCUPATION As Double, ByVal RECETTE_TOTAL_PAR_CHAMBRE As Double, ByVal REVENU_MOYEN_PAR_CHAMBRE_DISPONIBLE As Double, ByVal RECETTE_MOYENNE_PAR_CHAMBRE_LOUEE As Double, ByVal CODE_AGENCE As String, ByVal NOMBRE_EN_CHAMBRE_INITIAL As Integer, ByVal NOMBRE_EN_CHAMBRE_EFFECTUE As Integer) As Boolean

        Dim insertQuery As String = "INSERT INTO `statistiques`(`CODE_STATISTIQUE`, `DATE_DE_TRAVAIL`, `NOMBRE_DEPART_INITIAL`, `NOMBRE_DEPART_EFFECTUE`, `NOMBRE_ARRIVEE_INITIAL`, `NOMBRE_ARRIVEE_EFFECTUE`, `NOMBRE_CHAMBRE_OCCUPEE`, `NOMBRE_CHAMBRE_LIBRE`, `NOMBRE_CHAMBRE_TOTAL`, `TAUX_OCCUPATION`, `RECETTE_TOTAL_PAR_CHAMBRE`, `REVENU_MOYEN_PAR_CHAMBRE_DISPONIBLE`, `RECETTE_MOYENNE_PAR_CHAMBRE_LOUEE`, `CODE_AGENCE`, `NOMBRE_EN_CHAMBRE_INITIAL`, `NOMBRE_EN_CHAMBRE_EFFECTUE`) VALUES (@CODE_STATISTIQUE, @DATE_DE_TRAVAIL, @NOMBRE_DEPART_INITIAL, @NOMBRE_DEPART_EFFECTUE, @NOMBRE_ARRIVEE_INITIAL, @NOMBRE_ARRIVEE_EFFECTUE, @NOMBRE_CHAMBRE_OCCUPEE, @NOMBRE_CHAMBRE_LIBRE, @NOMBRE_CHAMBRE_TOTAL, @TAUX_OCCUPATION, @RECETTE_TOTAL_PAR_CHAMBRE, @REVENU_MOYEN_PAR_CHAMBRE_DISPONIBLE, @RECETTE_MOYENNE_PAR_CHAMBRE_LOUEE, @CODE_AGENCE, @NOMBRE_EN_CHAMBRE_INITIAL, @NOMBRE_EN_CHAMBRE_EFFECTUE)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_STATISTIQUE", MySqlDbType.VarChar).Value = CODE_STATISTIQUE
        command.Parameters.Add("@DATE_DE_TRAVAIL", MySqlDbType.Date).Value = DATE_DE_TRAVAIL
        command.Parameters.Add("@NOMBRE_DEPART_INITIAL", MySqlDbType.Int64).Value = NOMBRE_DEPART_INITIAL
        command.Parameters.Add("@NOMBRE_DEPART_EFFECTUE", MySqlDbType.Int64).Value = NOMBRE_DEPART_EFFECTUE
        command.Parameters.Add("@NOMBRE_ARRIVEE_INITIAL", MySqlDbType.Int64).Value = NOMBRE_ARRIVEE_INITIAL
        command.Parameters.Add("@NOMBRE_ARRIVEE_EFFECTUE", MySqlDbType.Int64).Value = NOMBRE_ARRIVEE_EFFECTUE
        command.Parameters.Add("@NOMBRE_CHAMBRE_OCCUPEE", MySqlDbType.Int64).Value = NOMBRE_CHAMBRE_OCCUPEE
        command.Parameters.Add("@NOMBRE_CHAMBRE_LIBRE", MySqlDbType.Int64).Value = NOMBRE_CHAMBRE_LIBRE
        command.Parameters.Add("@NOMBRE_CHAMBRE_TOTAL", MySqlDbType.Int64).Value = NOMBRE_CHAMBRE_TOTAL
        command.Parameters.Add("@TAUX_OCCUPATION", MySqlDbType.Double).Value = TAUX_OCCUPATION
        command.Parameters.Add("@RECETTE_TOTAL_PAR_CHAMBRE", MySqlDbType.Double).Value = RECETTE_TOTAL_PAR_CHAMBRE
        command.Parameters.Add("@REVENU_MOYEN_PAR_CHAMBRE_DISPONIBLE", MySqlDbType.Double).Value = REVENU_MOYEN_PAR_CHAMBRE_DISPONIBLE
        command.Parameters.Add("@RECETTE_MOYENNE_PAR_CHAMBRE_LOUEE", MySqlDbType.Double).Value = RECETTE_MOYENNE_PAR_CHAMBRE_LOUEE
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = CODE_AGENCE
        command.Parameters.Add("@NOMBRE_EN_CHAMBRE_INITIAL", MySqlDbType.Int64).Value = NOMBRE_EN_CHAMBRE_INITIAL
        command.Parameters.Add("@NOMBRE_EN_CHAMBRE_EFFECTUE", MySqlDbType.Int64).Value = NOMBRE_EN_CHAMBRE_EFFECTUE

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

    'Public Function UpdateStatistique(ByVal CODE_STATISTIQUE As String, ByVal DATE_DE_TRAVAIL As Date, ByVal NOMBRE_DEPART_FINAL As Integer, ByVal NOMBRE_DEPART_EFFECTUE As Integer, ByVal NOMBRE_ARRIVEE_FINAL As Integer, ByVal NOMBRE_ARRIVEE_EFFECTUE As Integer, ByVal NOMBRE_CHAMBRE_OCCUPEE As Integer, ByVal NOMBRE_CHAMBRE_LIBRE As Integer, ByVal NOMBRE_CHAMBRE_TOTAL As Integer, ByVal TAUX_OCCUPATION As Double, ByVal RECETTE_TOTAL_PAR_CHAMBRE As Double, ByVal REVENU_MOYEN_PAR_CHAMBRE_DISPONIBLE As Double, ByVal RECETTE_MOYENNE_PAR_CHAMBRE_LOUEE As Double, ByVal CODE_AGENCE As String, ByVal NOMBRE_EN_CHAMBRE_FINAL As Integer, ByVal NOMBRE_EN_CHAMBRE_EFFECTUE As Integer) As Boolean

    Public Sub updateValeurApresCloture(ByVal CODE_STATISTIQUE As String)

        Dim updqteQuery As String = "UPDATE `statistiques` SET  NOMBRE_DEPART_FINAL = NOMBRE_DEPART_INITIAL, NOMBRE_EN_CHAMBRE_FINAL= NOMBRE_EN_CHAMBRE_INITIAL, NOMBRE_ARRIVEE_FINAL=NOMBRE_ARRIVEE_INITIAL WHERE CODE_STATISTIQUE=@CODE_STATISTIQUE"

        'Dim updqteQuery As String = "UPDATE `statistiques` SET  NOMBRE_DEPART_FINAL = NOMBRE_ARRIVEE_INITIAL, NOMBRE_EN_CHAMBRE_EFFECTUE= NOMBRE_EN_CHAMBRE_INITIAL, NOMBRE_DEPART_EFFECTUE=NOMBRE_DEPART_INITIAL WHERE CODE_STATISTIQUE=@CODE_STATISTIQUE"

        Dim command As New MySqlCommand(updqteQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_STATISTIQUE", MySqlDbType.VarChar).Value = CODE_STATISTIQUE

        command.ExecuteNonQuery()

    End Sub

    Public Sub sauvegardeDAncienneValeur(ByVal CODE_STATISTIQUE As String)

        Dim updqteQuery As String = "UPDATE `statistiques` SET  NOMBRE_ARRIVEE_EFFECTUE = NOMBRE_ARRIVEE_INITIAL, NOMBRE_EN_CHAMBRE_EFFECTUE= NOMBRE_EN_CHAMBRE_INITIAL WHERE CODE_STATISTIQUE=@CODE_STATISTIQUE"

        Dim command As New MySqlCommand(updqteQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_STATISTIQUE", MySqlDbType.VarChar).Value = CODE_STATISTIQUE
        'command.Parameters.Add("@NOMBRE_DEPART_EFFECTUE", MySqlDbType.VarChar).Value = GlobalVariable.derniereValeurDepartFinal

        command.ExecuteNonQuery()

    End Sub

    Dim NOMBRE_DEPART_FINAL_OLD As Integer = 0

    Public Function UpdateStatistique(ByVal CODE_STATISTIQUE As String, ByVal DATE_DE_TRAVAIL As Date, ByVal NOMBRE_DEPART_EFFECTUE As Integer, ByVal NOMBRE_ARRIVEE_EFFECTUE As Integer, ByVal NOMBRE_CHAMBRE_OCCUPEE As Integer, ByVal NOMBRE_CHAMBRE_LIBRE As Integer, ByVal NOMBRE_CHAMBRE_TOTAL As Integer, ByVal TAUX_OCCUPATION As Double, ByVal RECETTE_TOTAL_PAR_CHAMBRE As Double, ByVal REVENU_MOYEN_PAR_CHAMBRE_DISPONIBLE As Double, ByVal RECETTE_MOYENNE_PAR_CHAMBRE_LOUEE As Double, ByVal CODE_AGENCE As String, ByVal NOMBRE_EN_CHAMBRE_EFFECTUE As Integer, ByVal NOMBRE_ARRIVEE_INITIAL As Integer, ByVal NOMBRE_EN_CHAMBRE_INITIAL As Integer, ByVal NOMBRE_DEPART_INITIAL As Integer) As Boolean

        Dim ARRIVEE As Integer = 0
        Dim DEPART As Integer = 0
        Dim EN_CHAMBRE As Integer = 0

        If NOMBRE_ARRIVEE_EFFECTUE > 0 Then
            ARRIVEE = 1
        ElseIf NOMBRE_ARRIVEE_EFFECTUE < 0 Then
            ARRIVEE = 0
        End If

        If GlobalVariable.entierAnnulation = -1 Then
            ARRIVEE = GlobalVariable.entierAnnulation * 2
        End If

        If NOMBRE_EN_CHAMBRE_EFFECTUE > 0 Then
            EN_CHAMBRE = 1
        ElseIf NOMBRE_EN_CHAMBRE_EFFECTUE < 0 Then
            EN_CHAMBRE = 0
        End If

        If NOMBRE_DEPART_EFFECTUE > 0 Then
            DEPART = 1 + GlobalVariable.derniereValeurDepartFinal
        ElseIf NOMBRE_DEPART_EFFECTUE <= 0 Then
            DEPART = 0 + GlobalVariable.derniereValeurDepartFinal
        End If

        sauvegardeDAncienneValeur(CODE_STATISTIQUE)

        'ActivationForm.GunaTextBox1.Text = "YES"
        'ActivationForm.GunaTextBox3.Text = GlobalVariable.derniereValeurDepartFinal

        'ActivationForm.Show()
        'ActivationForm.TopMost = True


        Dim updqteQuery As String = "UPDATE `statistiques` SET `DATE_DE_TRAVAIL`=@value3, `NOMBRE_CHAMBRE_OCCUPEE`=@NOMBRE_CHAMBRE_OCCUPEE, `NOMBRE_CHAMBRE_LIBRE`=@NOMBRE_CHAMBRE_LIBRE, `NOMBRE_CHAMBRE_TOTAL`=@NOMBRE_CHAMBRE_TOTAL, `TAUX_OCCUPATION`=@TAUX_OCCUPATION, `RECETTE_TOTAL_PAR_CHAMBRE`=@RECETTE_TOTAL_PAR_CHAMBRE, `REVENU_MOYEN_PAR_CHAMBRE_DISPONIBLE`=@REVENU_MOYEN_PAR_CHAMBRE_DISPONIBLE , `RECETTE_MOYENNE_PAR_CHAMBRE_LOUEE`=@RECETTE_MOYENNE_PAR_CHAMBRE_LOUEE,  `CODE_AGENCE`=@CODE_AGENCE, `NOMBRE_ARRIVEE_INITIAL`=@NOMBRE_ARRIVEE_INITIAL, `NOMBRE_EN_CHAMBRE_INITIAL`=@NOMBRE_EN_CHAMBRE_INITIAL, `NOMBRE_DEPART_INITIAL`=@NOMBRE_DEPART_INITIAL, NOMBRE_ARRIVEE_FINAL=`NOMBRE_ARRIVEE_FINAL` + @ARRIVEE , NOMBRE_DEPART_FINAL = @DEPART, NOMBRE_EN_CHAMBRE_FINAL=`NOMBRE_EN_CHAMBRE_FINAL` + @EN_CHAMBRE WHERE DATE_DE_TRAVAIL=@DATE_TRAVAIL"

        Dim command As New MySqlCommand(updqteQuery, GlobalVariable.connect)

        command.Parameters.Add("@DATE_TRAVAIL", MySqlDbType.Date).Value = DATE_DE_TRAVAIL
        command.Parameters.Add("@value3", MySqlDbType.Date).Value = DATE_DE_TRAVAIL
        'command.Parameters.Add("@NOMBRE_DEPART_FINAL", MySqlDbType.Int64).Value = NOMBRE_DEPART_FINAL
        command.Parameters.Add("@NOMBRE_DEPART_EFFECTUE", MySqlDbType.Int64).Value = NOMBRE_DEPART_EFFECTUE
        'command.Parameters.Add("@NOMBRE_ARRIVEE_FINAL", MySqlDbType.Int64).Value = NOMBRE_ARRIVEE_FINAL
        command.Parameters.Add("@NOMBRE_ARRIVEE_EFFECTUE", MySqlDbType.Int64).Value = NOMBRE_ARRIVEE_EFFECTUE
        command.Parameters.Add("@NOMBRE_CHAMBRE_OCCUPEE", MySqlDbType.Int64).Value = NOMBRE_CHAMBRE_OCCUPEE
        command.Parameters.Add("@NOMBRE_CHAMBRE_LIBRE", MySqlDbType.Int64).Value = NOMBRE_CHAMBRE_LIBRE
        command.Parameters.Add("@NOMBRE_CHAMBRE_TOTAL", MySqlDbType.Int64).Value = NOMBRE_CHAMBRE_TOTAL
        command.Parameters.Add("@TAUX_OCCUPATION", MySqlDbType.Double).Value = TAUX_OCCUPATION
        command.Parameters.Add("@RECETTE_TOTAL_PAR_CHAMBRE", MySqlDbType.Double).Value = RECETTE_TOTAL_PAR_CHAMBRE
        command.Parameters.Add("@REVENU_MOYEN_PAR_CHAMBRE_DISPONIBLE", MySqlDbType.Double).Value = REVENU_MOYEN_PAR_CHAMBRE_DISPONIBLE
        command.Parameters.Add("@RECETTE_MOYENNE_PAR_CHAMBRE_LOUEE", MySqlDbType.Double).Value = RECETTE_MOYENNE_PAR_CHAMBRE_LOUEE
        command.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = CODE_AGENCE

        command.Parameters.Add("@NOMBRE_EN_CHAMBRE_INITIAL", MySqlDbType.Int64).Value = NOMBRE_EN_CHAMBRE_INITIAL
        command.Parameters.Add("@NOMBRE_DEPART_INITIAL", MySqlDbType.Int64).Value = NOMBRE_DEPART_INITIAL
        command.Parameters.Add("@NOMBRE_EN_CHAMBRE_EFFECTUE", MySqlDbType.Int64).Value = NOMBRE_EN_CHAMBRE_EFFECTUE
        command.Parameters.Add("@NOMBRE_ARRIVEE_INITIAL", MySqlDbType.Int64).Value = NOMBRE_ARRIVEE_INITIAL

        command.Parameters.Add("@ARRIVEE", MySqlDbType.Int64).Value = ARRIVEE
        command.Parameters.Add("@EN_CHAMBRE", MySqlDbType.Int64).Value = EN_CHAMBRE
        command.Parameters.Add("@DEPART", MySqlDbType.Int64).Value = DEPART

        'Opening the connection
        'connect.openConnection()

        'Excuting the command and testing if everything went on well
        If (command.ExecuteNonQuery() = 1) Then
            'connect.closeConnection()
            GlobalVariable.entierAnnulation = 0
            Return True
        Else
            'connect.closeConnection()
            Return False
        End If

    End Function

    '------------- INFORMATIONS SUR LES RESERVATIONS POUR LES DONNEES STATISTIQUES ------------------------------------

    Public Function informationSurLesReservations(ByVal TYPE_RESERVATION As String) As Integer

        GlobalVariable.typeChambreOuSalle = "chambre"

        Dim NOMBRE_DE_RESERVATION As Integer = 0
        Dim query As String = ""
        Dim DateDebut As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")
        Dim DateFin As Date = GlobalVariable.DateDeTravail.ToString("yyyy-MM-dd")


        Dim table As New DataTable()

        If TYPE_RESERVATION = "en chambre" Then

            query = "SELECT CHAMBRE_ID AS 'CHAMBRE', NOM_CLIENT As 'NOM CLIENT', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' FROM reserve_conf WHERE DATE_ENTTRE <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 AND TYPE=@TYPE ORDER BY ID_RESERVATION DESC"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

            Dim adapter As New MySqlDataAdapter(command)

            adapter.Fill(table)

            If (table.Rows.Count > 0) Then
                NOMBRE_DE_RESERVATION = table.Rows.Count
            End If

        ElseIf TYPE_RESERVATION = "arrivee" Then

            query = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' FROM reservation WHERE DATE_ENTTRE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND TYPE=@TYPE AND ETAT_RESERVATION= 0 ORDER BY ID_RESERVATION DESC"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

            Dim adapter As New MySqlDataAdapter(command)

            adapter.Fill(table)

            If (table.Rows.Count > 0) Then
                NOMBRE_DE_RESERVATION = table.Rows.Count
            End If

        ElseIf TYPE_RESERVATION = "depart" Then

            query = "Select NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' FROM reserve_conf WHERE DATE_SORTIE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 AND TYPE=@TYPE ORDER BY ID_RESERVATION DESC"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

            Dim adapter As New MySqlDataAdapter(command)

            adapter.Fill(table)

            If (table.Rows.Count > 0) Then
                NOMBRE_DE_RESERVATION = table.Rows.Count
            End If

        End If

        Return NOMBRE_DE_RESERVATION

    End Function

    'Count the number of days in a month so as to know how many columns to create in our datagrid
    Private Function GetDaysInAMonth(ByVal year As Int16, ByVal month As Int16) As Int16

        Dim days As Int16 = 0

        Dim i As Integer = 0

        days += DateTime.DaysInMonth(year, month)

        Return days

    End Function

    Public Function ObtenirDerniereStatistique() As String

        'On pioche toutes les informations necessaire aux statistique a savoir

        'RMC = CHIFFRES D'AFFAIRES / NOMBRE DE NUITEES 

        'TREVPAR = CHIFFRES D'AFFAIRES / (NOMBRE DE NUITEES * NOMBRE DE CHAMBRE TOTAL)

        Dim roomList As New Room()
        Dim Room As DataTable = roomList.roomsOnly()
        Dim chifreAffaireDesChambres As Double = 0

        Dim nombreDeReservation As Integer = 0
        Dim nombreDeNuiteeTotal As Integer = 0

        Dim NOMBRE_DE_NUITEE As Integer = 0

        Dim arrivee As DataTable = Functions.getElementByCode(0, "reservation", "ETAT_RESERVATION")

        If arrivee.Rows.Count > 0 Then

            For i = 0 To arrivee.Rows.Count - 1

                Dim DATE_ENTREE = arrivee.Rows(i)("DATE_ENTTRE")
                Dim DATE_SORTIE = CDate(GlobalVariable.DateDeTravail).ToShortDateString

                nombreDeNuiteeTotal += nombreDeNuiteeDuneReservationPourLeMoisEnCours(DATE_ENTREE, DATE_SORTIE)

                chifreAffaireDesChambres += (arrivee.Rows(i)("MONTANT_ACCORDE") * (nombreDeNuiteeTotal + 1))

                NOMBRE_DE_NUITEE += nombreDeNuiteeTotal + 1

            Next

        End If

        Dim enChambre As DataTable = Functions.getElementByCode(1, "reserve_conf", "ETAT_RESERVATION")

        If enChambre.Rows.Count > 0 Then

            For j = 0 To enChambre.Rows.Count - 1

                Dim DATE_ENTREE = enChambre.Rows(j)("DATE_ENTTRE")
                Dim DATE_SORTIE = CDate(GlobalVariable.DateDeTravail).ToShortDateString

                nombreDeReservation += 1

                nombreDeNuiteeTotal += nombreDeNuiteeDuneReservationPourLeMoisEnCours(DATE_ENTREE, DATE_SORTIE)

                chifreAffaireDesChambres += (enChambre.Rows(j)("MONTANT_ACCORDE") * (nombreDeNuiteeTotal + 1))

                NOMBRE_DE_NUITEE += nombreDeNuiteeTotal + 1

            Next

        End If

        Dim enChambreAnnuler As DataTable = Functions.getElementByCode(0, "reserve_conf", "ETAT_RESERVATION")

        If enChambreAnnuler.Rows.Count > 0 Then

            For j = 0 To enChambreAnnuler.Rows.Count - 1
                Dim DATE_ENTREE = enChambreAnnuler.Rows(j)("DATE_ENTTRE")
                Dim DATE_SORTIE = CDate(GlobalVariable.DateDeTravail).ToShortDateString

                nombreDeReservation += 1

                nombreDeNuiteeTotal += nombreDeNuiteeDuneReservationPourLeMoisEnCours(DATE_ENTREE, DATE_SORTIE)

                chifreAffaireDesChambres += (enChambreAnnuler.Rows(j)("MONTANT_ACCORDE") * (nombreDeNuiteeTotal + 1))

                NOMBRE_DE_NUITEE += nombreDeNuiteeTotal + 1
            Next

        End If

        Dim TOTAL_DES_CHAMBRES As Integer = Functions.getElementByCode("chambre", "chambre", "TYPE").Rows.Count

        If TOTAL_DES_CHAMBRES = 0 Then
            TOTAL_DES_CHAMBRES = 1
        End If

        If NOMBRE_DE_NUITEE = 0 Then
            NOMBRE_DE_NUITEE = 1
        End If

        Dim statistiquesEnregistres As DataTable = Functions.allTableFields("statistiques")

        Dim NOMBRE_CHAMBRE_TOTAL As Integer = TOTAL_DES_CHAMBRES

        Dim CODE_STATISTIQUE As String = Functions.GeneratingRandomCode("statistiques", "STAT")

        Dim DATE_DE_TRAVAIL = Convert.ToDateTime(Functions.ObtenirDateDeTravail())

        Dim NOMBRE_EN_CHAMBRE_EFFECTUE As Integer = 0
        Dim NOMBRE_DEPART_EFFECTUE As Integer = 0 ' doit contenir le nombre de depart deja effectue
        Dim NOMBRE_ARRIVEE_EFFECTUE As Integer = 0 ' doit contenir le nombre d'arrivee deja effectue

        Dim NOMBRE_EN_CHAMBRE_INITIAL As Integer = informationSurLesReservations("en chambre")
        Dim NOMBRE_DEPART_INITIAL As Integer = informationSurLesReservations("depart")
        Dim NOMBRE_ARRIVEE_INITIAL As Integer = Conversion.Int(informationSurLesReservations("arrivee"))

        'ON DOIT DTERMINER SI IL Y'A EU DES VARIATIONS DANS NOS STATISTIQUES
        Dim derniereStatistiquesEnregistrePourControl As DataTable = Functions.allTableFields("statistiques")

        If derniereStatistiquesEnregistrePourControl.Rows.Count > 0 Then
            'ON RECUPERE LE CODE DE LA DERNIERE STAT SI ELLE EXISTE
            Dim CODE_STATISTIQUE_CONTROLE As String = derniereStatistiquesEnregistrePourControl.Rows(derniereStatistiquesEnregistrePourControl.Rows.Count - 1)("CODE_STATISTIQUE")

            'ON RECUPERE LES INFOS DE LA DERNIERE STATISTIQUE
            Dim StatDeControle As DataTable = Functions.getElementByCode(CODE_STATISTIQUE_CONTROLE, "statistiques", "CODE_STATISTIQUE")

            If StatDeControle.Rows.Count > 0 Then
                'ON VERIFIE SI IL Y'A DES MISE AJOURS DANS LES VALEURS

                If Not NOMBRE_ARRIVEE_INITIAL = StatDeControle.Rows(0)("NOMBRE_ARRIVEE_EFFECTUE") Then
                    NOMBRE_ARRIVEE_EFFECTUE = NOMBRE_ARRIVEE_INITIAL - StatDeControle.Rows(0)("NOMBRE_ARRIVEE_INITIAL")
                End If

                If Not NOMBRE_EN_CHAMBRE_INITIAL = StatDeControle.Rows(0)("NOMBRE_EN_CHAMBRE_EFFECTUE") Then
                    NOMBRE_EN_CHAMBRE_EFFECTUE = NOMBRE_EN_CHAMBRE_INITIAL - StatDeControle.Rows(0)("NOMBRE_EN_CHAMBRE_INITIAL")
                End If

                If Not NOMBRE_DEPART_INITIAL = StatDeControle.Rows(0)("NOMBRE_DEPART_EFFECTUE") Then
                    NOMBRE_DEPART_EFFECTUE = NOMBRE_DEPART_INITIAL - StatDeControle.Rows(0)("NOMBRE_DEPART_INITIAL")
                End If

            End If

        End If

        Dim moi As Integer = 0
        Dim annee As Integer = 0
        Integer.TryParse(Month(Now), moi)
        Integer.TryParse(Year(Now), annee)

        Dim NOMBRE_DE_JOUR_DU_MOIS As Integer = GetDaysInAMonth(annee, moi)

        'Dim NOMBRE_EN_CHAMBRE_FINAL As Integer = NOMBRE_EN_CHAMBRE_INITIAL + NOMBRE_EN_CHAMBRE_EFFECTUE
        'Dim NOMBRE_DEPART_FINAL As Integer = NOMBRE_DEPART_EFFECTUE + NOMBRE_DEPART_INITIAL
        'Dim NOMBRE_ARRIVEE_FINAL As Integer = NOMBRE_ARRIVEE_INITIAL + NOMBRE_ARRIVEE_EFFECTUE

        Dim NOMBRE_CHAMBRE_OCCUPEE As Integer = NOMBRE_EN_CHAMBRE_INITIAL

        Dim NOMBRE_CHAMBRE_LIBRE As Integer = NOMBRE_CHAMBRE_TOTAL - NOMBRE_CHAMBRE_OCCUPEE

        Dim TAUX_OCCUPATION As Double = ((NOMBRE_CHAMBRE_OCCUPEE + NOMBRE_ARRIVEE_INITIAL) * 100) / TOTAL_DES_CHAMBRES

        Dim RECETTE_TOTAL_PAR_CHAMBRE As Double = chifreAffaireDesChambres / (TOTAL_DES_CHAMBRES * NOMBRE_DE_JOUR_DU_MOIS) 'TREVPAR
        Dim RECETTE_MOYENNE_PAR_CHAMBRE_LOUEE As Double = 0  'RMC

        If NOMBRE_CHAMBRE_OCCUPEE > 0 Then
            RECETTE_MOYENNE_PAR_CHAMBRE_LOUEE = chifreAffaireDesChambres / NOMBRE_DE_NUITEE ' RMC
        End If

        Dim REVENU_MOYEN_PAR_CHAMBRE_DISPONIBLE As Double = chifreAffaireDesChambres / (TOTAL_DES_CHAMBRES * NOMBRE_DE_JOUR_DU_MOIS) 'REVPAR OR TREVPAR

        Dim CODE_AGENCE As String = GlobalVariable.codeAgence

        Dim derniereStatistiquesEnregistre As DataTable = Functions.allTableFields("statistiques")

        'Si la table est vide alors on insere la premiere statistique
        If Not statistiquesEnregistres.Rows.Count > 0 Then
            'Enregistrement de la premiere statistque
            'MessageBox.Show("Premiere stat")
            'InsertStatistique(CODE_STATISTIQUE, DATE_DE_TRAVAIL, NOMBRE_DEPART_INITIAL, NOMBRE_DEPART_EFFECTUE, NOMBRE_ARRIVEE_INITIAL, NOMBRE_ARRIVEE_EFFECTUE, NOMBRE_CHAMBRE_OCCUPEE, NOMBRE_CHAMBRE_LIBRE, NOMBRE_CHAMBRE_TOTAL, TAUX_OCCUPATION, RECETTE_TOTAL_PAR_CHAMBRE, REVENU_MOYEN_PAR_CHAMBRE_DISPONIBLE, RECETTE_MOYENNE_PAR_CHAMBRE_LOUEE, CODE_AGENCE, NOMBRE_EN_CHAMBRE_INITIAL, NOMBRE_EN_CHAMBRE_FINAL, NOMBRE_EN_CHAMBRE_EFFECTUE)
            InsertStatistique(CODE_STATISTIQUE, DATE_DE_TRAVAIL, NOMBRE_DEPART_INITIAL, NOMBRE_DEPART_EFFECTUE, NOMBRE_ARRIVEE_INITIAL, NOMBRE_ARRIVEE_EFFECTUE, NOMBRE_CHAMBRE_OCCUPEE, NOMBRE_CHAMBRE_LIBRE, NOMBRE_CHAMBRE_TOTAL, TAUX_OCCUPATION, RECETTE_TOTAL_PAR_CHAMBRE, REVENU_MOYEN_PAR_CHAMBRE_DISPONIBLE, RECETTE_MOYENNE_PAR_CHAMBRE_LOUEE, CODE_AGENCE, NOMBRE_EN_CHAMBRE_INITIAL, NOMBRE_EN_CHAMBRE_EFFECTUE)

            'MessageBox.Show(CODE_STATISTIQUE + " : Insert statistiques", "stat")
        Else

            derniereStatistiquesEnregistre = Functions.allTableFields("statistiques")

            CODE_STATISTIQUE = derniereStatistiquesEnregistre.Rows(derniereStatistiquesEnregistre.Rows.Count - 1)("CODE_STATISTIQUE")
            Dim dernierDateDeTravail As Date = derniereStatistiquesEnregistre.Rows(derniereStatistiquesEnregistre.Rows.Count - 1)("DATE_DE_TRAVAIL")

            If derniereStatistiquesEnregistre.Rows.Count > 0 Then

                If dernierDateDeTravail = GlobalVariable.DateDeTravail Then
                    'MessageBox.Show("Mise e jours en date de travail")
                    'Si la date de la derniere stat est egale a la date de travail actuelle alors on a pas encore cloturer
                    'On met a jour les informations statistiques

                    GlobalVariable.derniereValeurDepartFinal = derniereStatistiquesEnregistre.Rows(0)("NOMBRE_DEPART_FINAL")


                    UpdateStatistique(CODE_STATISTIQUE, DATE_DE_TRAVAIL, NOMBRE_DEPART_EFFECTUE, NOMBRE_ARRIVEE_EFFECTUE, NOMBRE_CHAMBRE_OCCUPEE, NOMBRE_CHAMBRE_LIBRE, NOMBRE_CHAMBRE_TOTAL, TAUX_OCCUPATION, RECETTE_TOTAL_PAR_CHAMBRE, REVENU_MOYEN_PAR_CHAMBRE_DISPONIBLE, RECETTE_MOYENNE_PAR_CHAMBRE_LOUEE, CODE_AGENCE, NOMBRE_EN_CHAMBRE_EFFECTUE, NOMBRE_ARRIVEE_INITIAL, NOMBRE_EN_CHAMBRE_INITIAL, NOMBRE_DEPART_INITIAL)

                Else
                    'Si la date de la derniere stat est different de la date de travail actuelle alors on a cloturer
                    ' donc on doit inserer une nouvelle stat
                    'MessageBox.Show("Cloture de la stat")
                    Dim NEW_CODE_STATISTIQUE As String = Functions.GeneratingRandomCode("statistiques", "STAT")
                    NOMBRE_DEPART_EFFECTUE = 0
                    NOMBRE_ARRIVEE_EFFECTUE = 0
                    NOMBRE_EN_CHAMBRE_EFFECTUE = 0

                    InsertStatistique(NEW_CODE_STATISTIQUE, DATE_DE_TRAVAIL, NOMBRE_DEPART_INITIAL, NOMBRE_DEPART_EFFECTUE, NOMBRE_ARRIVEE_INITIAL, NOMBRE_ARRIVEE_EFFECTUE, NOMBRE_CHAMBRE_OCCUPEE, NOMBRE_CHAMBRE_LIBRE, NOMBRE_CHAMBRE_TOTAL, TAUX_OCCUPATION, RECETTE_TOTAL_PAR_CHAMBRE, REVENU_MOYEN_PAR_CHAMBRE_DISPONIBLE, RECETTE_MOYENNE_PAR_CHAMBRE_LOUEE, CODE_AGENCE, NOMBRE_EN_CHAMBRE_INITIAL, NOMBRE_EN_CHAMBRE_EFFECTUE)

                    'MISE AJOURS DES NOUVELLES VALEURS FINALS APRE CLOTURE

                    If GlobalVariable.upddateStatData Then

                        updateValeurApresCloture(NEW_CODE_STATISTIQUE)

                        GlobalVariable.upddateStatData = False

                    End If


                End If

            End If

        End If

        'Une stat aumoins etant enregistre, on la recupere
        'On selectionne les derniers statistique enregistree en selectionnant d'abord l'ensemble des stats

        derniereStatistiquesEnregistre = Functions.allTableFields("statistiques")

        If derniereStatistiquesEnregistre.Rows.Count > 0 Then
            'MessageBox.Show("mise à jours apres modification")
            'On la met a jor pour etre sure quelle contient les dernieres informations en date.
            'CODE HERE
            CODE_STATISTIQUE = derniereStatistiquesEnregistre.Rows(derniereStatistiquesEnregistre.Rows.Count - 1)("CODE_STATISTIQUE")

            UpdateStatistique(CODE_STATISTIQUE, DATE_DE_TRAVAIL, NOMBRE_DEPART_EFFECTUE, NOMBRE_ARRIVEE_EFFECTUE, NOMBRE_CHAMBRE_OCCUPEE, NOMBRE_CHAMBRE_LIBRE, NOMBRE_CHAMBRE_TOTAL, TAUX_OCCUPATION, RECETTE_TOTAL_PAR_CHAMBRE, REVENU_MOYEN_PAR_CHAMBRE_DISPONIBLE, RECETTE_MOYENNE_PAR_CHAMBRE_LOUEE, CODE_AGENCE, NOMBRE_EN_CHAMBRE_EFFECTUE, NOMBRE_ARRIVEE_INITIAL, NOMBRE_EN_CHAMBRE_INITIAL, NOMBRE_DEPART_INITIAL)

        End If

        'Enfin on retourne la derniere statistique
        Return derniereStatistiquesEnregistre.Rows(derniereStatistiquesEnregistre.Rows.Count - 1)("CODE_STATISTIQUE")

    End Function

    Public Function tauxDoccupationGenerale(ByVal DateDebut As Date, ByVal DateFin As Date) As Integer

        Dim tauxOccupation As Integer = 0

        Dim query As String = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' FROM reservation WHERE DATE_ENTTRE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND TYPE=@TYPE AND ETAT_RESERVATION= 0 ORDER BY ID_RESERVATION DESC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
        'command.Parameters.Add("@ETAT_RESERVATION", MySqlDbType.Int32).Value = 0

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            tauxOccupation += table.Rows.Count
        End If


        Dim query1 As String = "SELECT CHAMBRE_ID AS 'CHAMBRE', NOM_CLIENT As 'NOM CLIENT', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' FROM reserve_conf WHERE DATE_ENTTRE <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 AND TYPE=@TYPE ORDER BY ID_RESERVATION DESC"

        Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
        command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

        Dim adapter1 As New MySqlDataAdapter(command1)
        Dim table1 As New DataTable()
        adapter1.Fill(table1)

        If (table1.Rows.Count > 0) Then
            tauxOccupation += table1.Rows.Count
        End If

        Dim query3 As String = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)' FROM reserve_conf WHERE DATE_SORTIE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE <='" & DateFin.ToString("yyyy-MM-dd") & "' AND ETAT_RESERVATION = 1 AND TYPE=@TYPE ORDER BY ID_RESERVATION DESC"

        Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)
        command3.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

        Dim adapter3 As New MySqlDataAdapter(command3)
        Dim table3 As New DataTable()
        adapter3.Fill(table3)

        If (table3.Rows.Count > 0) Then
            tauxOccupation -= table3.Rows.Count
        End If

        Return tauxOccupation

    End Function

    Public Function nombreDeNuiteeDuneReservationPourLeMoisEnCours(ByVal DATE_ENTREE As Date, ByVal DATE_SORTIE As Date) As Integer

        Dim nombreDeNuiteeDuMois As Integer = 0

        Dim numeroDateActuelle As Integer = Month(Now())
        Dim numeroDateEntree As Integer = Month(DATE_ENTREE)
        Dim numeroDateSortie As Integer = Month(DATE_SORTIE)

        Dim dernierDateDuMois As Date

        'SI LA DATE D'ENTREE EST DANS LE MOIS ACTUEL
        If numeroDateActuelle = numeroDateEntree Then

            'SI LA DATE DE SORTIE EST DANS LE MOIS ACTUEL
            If numeroDateSortie = numeroDateActuelle Then
                nombreDeNuiteeDuMois = DateDiff(DateInterval.Day, DATE_ENTREE, DATE_SORTIE)
            Else
                'SI LA DATE DE SORTIE N'EST PADANS LE MOIS ACTUEL

                'ON RECUPERE LA DERNIER DATE DU MOIS ACTUEL
                dernierDateDuMois = DateSerial(Now.Year, Now.Month + 1, 0)
                nombreDeNuiteeDuMois = DateDiff(DateInterval.Day, DATE_ENTREE, dernierDateDuMois)

            End If

        End If

        Return Math.Abs(nombreDeNuiteeDuMois)

    End Function

End Class
