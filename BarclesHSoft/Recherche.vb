Imports MySql.Data.MySqlClient

Public Class Recherche

    Public Shared Sub RechercheGenerale(ByVal Grid As DataGridView, ByVal tableToSearch As String, ByVal champVoulu As String, ByVal valeurARechercher As String, ByVal champDeRecherche As String)
        Dim query As String = ""

        query = "SELECT " & champVoulu & " FROM " & tableToSearch & " WHERE " & champDeRecherche & " LIKE '%" & valeurARechercher & "%' ORDER BY client." & champDeRecherche & " ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            Grid.Visible = True

            Grid.DataSource = table

        Else

            Grid.Columns.Clear()

        End If

        'GlobalVariable.connect.closeConnection()

    End Sub

    Public Shared Sub RechercherClient(ByVal Grid As DataGridView, ByVal valeurARechercher As String, ByVal champDeRecherche As String)
        Dim query As String = ""

        query = "SELECT NOM_PRENOM FROM client WHERE " & champDeRecherche & " LIKE '%" & valeurARechercher & "%' ORDER BY client." & champDeRecherche & " ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            Grid.Visible = True

            Grid.DataSource = table

        Else

            Grid.Columns.Clear()

        End If

        'GlobalVariable.connect.closeConnection()

    End Sub

    Public Shared Sub RechercherClient(ByVal Grid As DataGridView, ByVal valeurARechercher As String, ByVal champDeRecherche As String, ByRef typeDeClient As String)

        Dim query As String = ""

        query = "SELECT NOM_PRENOM FROM client WHERE " & champDeRecherche & " LIKE '%" & valeurARechercher & "%' AND TYPE_CLIENT =@TYPE_CLIENT ORDER BY client." & champDeRecherche & " ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
        command.Parameters.Add("@TYPE_CLIENT", MySqlDbType.VarChar).Value = typeDeClient

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then

            Grid.Visible = True

            Grid.DataSource = table

        Else

            Grid.Columns.Clear()

        End If

        'GlobalVariable.connect.closeConnection()

    End Sub

    Public Shared Sub RechercherParText(ByVal Grid As DataGridView, ByVal valeurARechercher As String, ByVal champDeRecherche As String)

        'On Affiche toute reservation dont la date d'entree figure entre les deux dates saisies
        Dim query As String = ""
        Dim query1 As String = ""

        If champDeRecherche = "ENTREPRISE" Then
            'Séelction d'une entreprise associé a un client
            champDeRecherche = "NOM_CLIENT"

            query = "SELECT DISTINCT client.NOM_CLIENT FROM reservation INNER JOIN client WHERE reservation.CLIENT_ID = client.CODE_CLIENT AND TYPE=@TYPE AND client." & champDeRecherche & " LIKE '%" & valeurARechercher & "%' AND TYPE_CLIENT =@TYPE_CLIENT ORDER BY client." & champDeRecherche & " ASC"

            'On Affiche toute reservation dont la date d'entree figure entre les deux dates saisies
            query1 = "SELECT DISTINCT client.NOM_CLIENT FROM reservation INNER JOIN client WHERE reservation.CLIENT_ID = client.CODE_CLIENT AND TYPE=@TYPE AND client." & champDeRecherche & " LIKE '%" & valeurARechercher & "%' AND TYPE_CLIENT =@TYPE_CLIENT ORDER BY client." & champDeRecherche & " ASC"

        Else

            query = "SELECT DISTINCT " & champDeRecherche & " FROM reservation WHERE " & champDeRecherche & " LIKE '%" & valeurARechercher & "%' ORDER BY " & champDeRecherche & " ASC"

            query1 = "SELECT DISTINCT " & champDeRecherche & " FROM reserve_conf WHERE " & champDeRecherche & " LIKE '%" & valeurARechercher & "%' ORDER BY " & champDeRecherche & " ASC"

        End If

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
        command.Parameters.Add("@TYPE_CLIENT", MySqlDbType.VarChar).Value = "ENTREPRISE"

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
        command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
        command1.Parameters.Add("@TYPE_CLIENT", MySqlDbType.VarChar).Value = "ENTREPRISE"

        Dim adapter1 As New MySqlDataAdapter(command1)
        Dim table1 As New DataTable()
        adapter1.Fill(table1)

        table.Merge(table1)

        If (table.Rows.Count > 0) Then

            Grid.Visible = True

            Grid.DataSource = table
        Else

            Grid.Columns.Clear()

        End If

        'GlobalVariable.connect.closeConnection()

    End Sub

    Public Shared Sub RechercherParDateArrivee(ByVal Grid As DataGridView, ByVal DateArrivee As Date, ByVal champDeRecherche As String)

        Dim DateDebut As Date = DateArrivee.ToString("yyyy-MM-dd")

        Dim query As String = "SELECT CHAMBRE_ID AS 'CHAMBRE', NOM_CLIENT As 'NOM CLIENT', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'ETAT',NB_PERSONNES As 'PERSONNE(S)', GROUPE FROM reserve_conf WHERE DATE_ENTTRE <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND TYPE=@TYPE ORDER BY ID_RESERVATION DESC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        Dim query1 As String = "SELECT CHAMBRE_ID AS 'CHAMBRE', NOM_CLIENT As 'NOM CLIENT', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'ETAT',NB_PERSONNES As 'PERSONNE(S)', GROUPE FROM reservation WHERE DATE_ENTTRE <= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND TYPE=@TYPE ORDER BY ID_RESERVATION DESC"

        Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
        command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

        Dim adapter1 As New MySqlDataAdapter(command1)
        Dim table1 As New DataTable()
        adapter1.Fill(table1)

        table.Merge(table1)

        If (table.Rows.Count > 0) Then

            Grid.DataSource = table

            Grid.DefaultCellStyle.SelectionBackColor = Color.BlueViolet
            Grid.DefaultCellStyle.SelectionForeColor = Color.White
            Grid.Columns("PRIX/NUITEE").DefaultCellStyle.Format = "#,##0"
            Grid.Columns("PRIX/NUITEE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Grid.Columns("SOLDE").DefaultCellStyle.Format = "#,##0"
            Grid.Columns("SOLDE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Grid.Columns("NOM CLIENT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            For i = 0 To Grid.Rows.Count - 1

                If Grid.Rows(i).Cells("SOLDE").Value < 0 Then
                    'Grid.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    'Grid.Rows(i).DefaultCellStyle.ForeColor = Color.White
                End If

            Next

        Else

            Grid.Columns.Clear()

        End If

        'GlobalVariable.connect.closeConnection()


    End Sub

    Public Shared Sub RechercherParDateDepart(ByVal Grid As DataGridView, ByVal DateDepart As Date, ByVal champDeRecherche As String)

        Dim DateDepartFormated As Date = DateDepart.ToString("yyyy-MM-dd")
        'Dim DateFin As Date = GunaDateTimePickerFin.Value.ToString("yyyy-MM-dd")

        'If (DateArrivee.Value <= GunaDateTimePickerFin.Value) Then

        'On Affiche toute reservation dont la date d'entree figure entre les deux dates saisies
        Dim query As String = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',NB_PERSONNES As 'NOMBRE PERSONNE', GROUPE FROM reservation WHERE DATE_SORTIE >= '" & DateDepartFormated.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE <='" & DateDepartFormated.ToString("yyyy-MM-dd") & "' AND TYPE=@TYPE ORDER BY ID_RESERVATION DESC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
        'command.Parameters.Add("@ETAT_RESERVATION", MySqlDbType.Int32).Value = 0

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        Dim query1 As String = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',NB_PERSONNES As 'NOMBRE PERSONNE', GROUPE FROM reserve_conf WHERE DATE_SORTIE >= '" & DateDepartFormated.ToString("yyyy-MM-dd") & "' AND DATE_SORTIE <='" & DateDepartFormated.ToString("yyyy-MM-dd") & "' AND TYPE=@TYPE ORDER BY ID_RESERVATION DESC"

        Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
        command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
        command.Parameters.Add("@ETAT_RESERVATION", MySqlDbType.Int32).Value = 0

        Dim adapter1 As New MySqlDataAdapter(command1)
        Dim table1 As New DataTable()
        adapter1.Fill(table1)

        table.Merge(table1)

        If (table.Rows.Count > 0) Then

            Grid.DataSource = table

            Grid.DefaultCellStyle.SelectionBackColor = Color.BlueViolet
            Grid.DefaultCellStyle.SelectionForeColor = Color.White
            Grid.Columns("PRIX/NUITEE").DefaultCellStyle.Format = "#,##0"
            Grid.Columns("PRIX/NUITEE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Grid.Columns("SOLDE").DefaultCellStyle.Format = "#,##0"
            Grid.Columns("SOLDE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Grid.Columns("NOM CLIENT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            For i = 0 To Grid.Rows.Count - 1

                If Grid.Rows(i).Cells("SOLDE").Value < 0 Then
                    Grid.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    Grid.Rows(i).DefaultCellStyle.ForeColor = Color.White
                End If

            Next

        Else
            Grid.Columns.Clear()
        End If

    End Sub

    Public Shared Sub RechercherParDate(ByVal Grid As DataGridView, ByVal DateArrivee As Date, ByVal DateArrivee2 As Date)

        Dim DateDebut As Date = DateArrivee.ToString("yyyy-MM-dd")
        Dim DateDebut2 As Date = DateArrivee2.ToString("yyyy-MM-dd")

        Dim table As New DataTable()
        Dim table01 As New DataTable()
        Dim table1 As New DataTable()

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("FISCALITE") Then

            Dim query01 As String = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)', GROUPE FROM reserve_conf, source_reservation WHERE DATE_ENTTRE <= '" & DateDebut2.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND TYPE=@TYPE AND source_reservation.SOURCE_RESERVATION IN ('COMPTOIR', 'COMPTOIRE') AND reserve_conf.SOURCE_RESERVATION = source_reservation.CODE_SOURCE_RESERVATION ORDER BY CHAMBRE_ID ASC "

            Dim command01 As New MySqlCommand(query01, GlobalVariable.connect)
            command01.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

            Dim adapter01 As New MySqlDataAdapter(command01)

            adapter01.Fill(table01)

            Dim nombreDeReservationTotal As Integer = table01.Rows.Count
            Dim tauxDeVisibilite As Double = Double.Parse(GlobalVariable.AgenceActuelle.Rows(0)("FISCALITE")) / 100

            Dim LIMITER As Integer = Math.Round(nombreDeReservationTotal * tauxDeVisibilite)

            '----------------------------------------------------------------------------------------------------------------------------

            Dim query As String = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)', GROUPE FROM reserve_conf, source_reservation WHERE TYPE=@TYPE AND DATE_ENTTRE <= '" & DateDebut2.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND source_reservation.SOURCE_RESERVATION IN ('COMPTOIR', 'COMPTOIRE') AND reserve_conf.SOURCE_RESERVATION = source_reservation.CODE_SOURCE_RESERVATION ORDER BY CHAMBRE_ID ASC LIMIT " & LIMITER

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
            'command.Parameters.Add("@ETAT_RESERVATION", MySqlDbType.Int32).Value = 0

            Dim adapter As New MySqlDataAdapter(command)

            adapter.Fill(table)

            Dim query1 As String = "SELECT NOM_CLIENT As 'NOM CLIENT', CHAMBRE_ID AS 'CHAMBRE',DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'STATUT',NB_PERSONNES As 'PERSONNE(S)', GROUPE FROM reserve_conf, source_reservation WHERE TYPE=@TYPE AND source_reservation.SOURCE_RESERVATION NOT IN ('COMPTOIR', 'COMPTOIRE') AND reserve_conf.SOURCE_RESERVATION = source_reservation.CODE_SOURCE_RESERVATION ORDER BY CHAMBRE_ID ASC"

            Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
            command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle
            'command.Parameters.Add("@ETAT_RESERVATION", MySqlDbType.Int32).Value = 0

            Dim adapter1 As New MySqlDataAdapter(command1)

            adapter1.Fill(table1)

            table.Merge(table1)
        Else

            Dim query As String = "SELECT CHAMBRE_ID AS 'CHAMBRE', NOM_CLIENT As 'NOM CLIENT', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'ETAT',NB_PERSONNES As 'PERSONNE(S)', GROUPE FROM reserve_conf WHERE DATE_ENTTRE <= '" & DateDebut2.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND TYPE=@TYPE ORDER BY DATE_ENTTRE DESC"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            command.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

            Dim adapter As New MySqlDataAdapter(command)

            adapter.Fill(table)

            Dim query1 As String = "SELECT CHAMBRE_ID AS 'CHAMBRE', NOM_CLIENT As 'NOM CLIENT', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', SOLDE_RESERVATION AS 'SOLDE', MONTANT_ACCORDE AS 'PRIX/NUITEE', CODE_RESERVATION AS 'RESERVATION',ETAT_NOTE_RESERVATION AS 'ETAT',NB_PERSONNES As 'PERSONNE(S)', GROUPE FROM reservation WHERE DATE_ENTTRE <= '" & DateDebut2.ToString("yyyy-MM-dd") & "' AND DATE_ENTTRE >='" & DateDebut.ToString("yyyy-MM-dd") & "' AND TYPE=@TYPE ORDER BY DATE_ENTTRE DESC"

            Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)
            command1.Parameters.Add("@TYPE", MySqlDbType.VarChar).Value = GlobalVariable.typeChambreOuSalle

            Dim adapter1 As New MySqlDataAdapter(command1)

            adapter1.Fill(table1)

            table.Merge(table1)

        End If

        If (table.Rows.Count > 0) Then

            Grid.DataSource = table

            Grid.DefaultCellStyle.SelectionBackColor = Color.BlueViolet
            Grid.DefaultCellStyle.SelectionForeColor = Color.White
            Grid.Columns("PRIX/NUITEE").DefaultCellStyle.Format = "#,##0"
            Grid.Columns("PRIX/NUITEE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Grid.Columns("SOLDE").DefaultCellStyle.Format = "#,##0"
            Grid.Columns("SOLDE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Grid.Columns("NOM CLIENT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            For i = 0 To Grid.Rows.Count - 1

                If i Mod 2 = 0 Then
                    Grid.Rows(i).DefaultCellStyle.BackColor = Color.LightBlue
                Else
                    Grid.Rows(i).DefaultCellStyle.BackColor = Color.White
                End If

            Next

        Else

            Grid.Columns.Clear()

        End If

    End Sub

End Class
