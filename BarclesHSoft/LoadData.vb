Imports System.IO
Imports MySql.Data.MySqlClient
Imports ExcelDataReader


Public Class LoadData


    Dim tables As DataTableCollection



    '1-------------------------- PREMIERE LIGNE DE TELEVERSEMENT --------------------------

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButtonParcourirL1.Click

        Using ofd As OpenFileDialog = New OpenFileDialog() With {.Filter = "Excel Files(*.xlsx)|*.xlsx| CSV(*.csv) |*.csv| All files(*.*)|*.*"}

            If ofd.ShowDialog() = DialogResult.OK Then
                GunaTextBoxL1.Text = ofd.FileName
                Using stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read)

                    Using reader As IExcelDataReader = ExcelReaderFactory.CreateReader(stream)

                        Dim result As DataSet = reader.AsDataSet(New ExcelDataSetConfiguration() With {
                                                                 .ConfigureDataTable = Function(__) New ExcelDataTableConfiguration() With {
                                                                 .UseHeaderRow = True}})
                        tables = result.Tables
                        GunaComboBoxSheetL1.Items.Clear()

                        For Each table As DataTable In tables
                            GunaComboBoxSheetL1.Items.Add(table.TableName)
                        Next

                    End Using

                End Using
            Else
                'GunaTextBoxTypeDeChambre.Clear()
            End If

        End Using



    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButtonL1.Click

        'UPLOADER 
        If GunaDataGridView1.Rows.Count > 0 Then

            GunaProgressBarL1.Maximum = GunaDataGridView1.Rows.Count

            '1- TYPE DE CHAMBRE
            If Trim(GunaComboBoxSheetL1.SelectedItem).Equals("Type de chambre") Or Trim(GunaComboBoxSheetL1.SelectedItem).Equals("Type de salle") Then

                Dim LIBELLE_TYPE_CHAMBRE As String = ""
                Dim DESCRIPTION As String = ""
                Dim PRIX As Double = 0
                Dim CODE_TYPE_CHAMBRE As String = ""
                Dim DATE_CREATION
                Dim CODE_UTILISATEUR_MODIF As String = ""
                Dim DATE_MODIFICATION
                Dim CODE_AGENCE As String = ""
                Dim CODE_TYPE As String = ""
                Dim SUPERFICIE As Double
                Dim CAPACITE As Double

                Dim RoomType As New RoomType()

                For i = 0 To GunaDataGridView1.Rows.Count - 1

                    LIBELLE_TYPE_CHAMBRE = GunaDataGridView1.Rows(i).Cells("LIBELLE_TYPE_CHAMBRE").Value.ToString()
                    DESCRIPTION = GunaDataGridView1.Rows(i).Cells("DESCRIPTION").Value.ToString()
                    PRIX = GunaDataGridView1.Rows(i).Cells("PRIX").Value
                    CODE_TYPE_CHAMBRE = GunaDataGridView1.Rows(i).Cells("CODE_TYPE_CHAMBRE").Value.ToString()
                    DATE_CREATION = GunaDataGridView1.Rows(i).Cells("DATE_CREATION").Value.ToString()
                    CODE_UTILISATEUR_MODIF = GunaDataGridView1.Rows(i).Cells("CODE_UTILISATEUR_MODIF").Value.ToString()
                    DATE_MODIFICATION = GunaDataGridView1.Rows(i).Cells("DATE_MODIFICATION").Value.ToString()
                    CODE_AGENCE = GunaDataGridView1.Rows(i).Cells("CODE_AGENCE").Value.ToString()
                    CODE_TYPE = GunaDataGridView1.Rows(i).Cells("TYPE").Value.ToString()
                    SUPERFICIE = GunaDataGridView1.Rows(i).Cells("SUPERFICIE").Value
                    CAPACITE = GunaDataGridView1.Rows(i).Cells("CAPACITE").Value
                    Dim TAUX_CHARGE_FIXE As Double = 50
                    'We update the value of the row in case of any change
                    If RoomType.Insert(LIBELLE_TYPE_CHAMBRE, DESCRIPTION, PRIX, CODE_TYPE_CHAMBRE, DATE_CREATION, CODE_UTILISATEUR_MODIF, DATE_MODIFICATION, TAUX_CHARGE_FIXE, CODE_AGENCE, SUPERFICIE, CAPACITE, CODE_TYPE) Then
                        'Timer1.Start()
                    End If

                    GunaProgressBarL1.Value += 1

                Next

            ElseIf Trim(GunaComboBoxSheetL1.SelectedItem).Equals("Societe") Then

                '2- SOCIETE

                Dim CODE_SOCIETE As String = ""
                Dim RAISON_SOCIALE As String = ""
                Dim VILLE As String = ""
                Dim BOITE_POSTALE As String = ""
                Dim PAYS As String = ""
                Dim TELEPHONE As String = ""
                Dim FAX As String = ""
                Dim EMAIL As String = ""
                Dim RUE As String = ""
                Dim NUM_CONTRIBUABLE As String = ""
                Dim NUM_REGISTRE As String = ""
                Dim CODE_AGENCE_ACTUEL As String = ""
                Dim CODE_MONNAIE As String = ""

                Dim company As New Company()

                For i = 0 To GunaDataGridView1.Rows.Count - 1

                    CODE_SOCIETE = GunaDataGridView1.Rows(i).Cells("CODE_SOCIETE").Value.ToString()
                    RAISON_SOCIALE = GunaDataGridView1.Rows(i).Cells("RAISON_SOCIALE").Value.ToString()
                    VILLE = GunaDataGridView1.Rows(i).Cells("VILLE").Value.ToString()
                    BOITE_POSTALE = GunaDataGridView1.Rows(i).Cells("BOITE_POSTALE").Value.ToString()
                    PAYS = GunaDataGridView1.Rows(i).Cells("PAYS").Value.ToString()
                    TELEPHONE = GunaDataGridView1.Rows(i).Cells("TELEPHONE").Value.ToString()
                    FAX = GunaDataGridView1.Rows(i).Cells("FAX").Value.ToString()
                    EMAIL = GunaDataGridView1.Rows(i).Cells("EMAIL").Value.ToString()
                    RUE = GunaDataGridView1.Rows(i).Cells("RUE").Value.ToString()
                    NUM_REGISTRE = GunaDataGridView1.Rows(i).Cells("NUM_REGISTRE").Value
                    CODE_AGENCE_ACTUEL = GunaDataGridView1.Rows(i).Cells("CODE_AGENCE_ACTUEL").Value
                    CODE_MONNAIE = GunaDataGridView1.Rows(i).Cells("CODE_MONNAIE").Value

                    'We update the value of the row in case of any change
                    If company.Insert(CODE_SOCIETE, RAISON_SOCIALE, VILLE, BOITE_POSTALE, PAYS, TELEPHONE, FAX, EMAIL, RUE, NUM_CONTRIBUABLE, NUM_REGISTRE, CODE_MONNAIE, CODE_AGENCE_ACTUEL) Then

                    End If

                    GunaProgressBarL1.Value += 1

                Next

            ElseIf Trim(GunaComboBoxSheetL1.SelectedItem).Equals("Agence") Then

                '3- AGENCE

                Dim NOM_AGENCE As String = ""
                Dim CODE_AGENCE As String = ""
                Dim FAX As String = ""
                Dim EMAIL As String = ""
                Dim TELEPHONE As String = ""
                Dim VILLE As String = ""
                Dim BOITE_POSTALE As String = ""
                Dim PAYS As String = ""
                Dim RUE As String = ""
                Dim CATEGORIE_HOTEL As String = ""

                Dim WHATSAPP_1 As String = ""
                Dim WHATSAPP_2 As String = ""
                Dim WHATSAPP_3 As String = ""
                Dim WHATSAPP_4 As String = ""
                Dim WHATSAPP_5 As String = ""
                Dim WHATSAPP_6 As String = ""
                Dim WHATSAPP_7 As String = ""

                Dim EMAIL_1 As String = ""
                Dim EMAIL_2 As String = ""
                Dim EMAIL_3 As String = ""
                Dim EMAIL_4 As String = ""
                Dim EMAIL_5 As String = ""
                Dim EMAIL_6 As String = ""
                Dim EMAIL_7 As String = ""

                Dim agency As New Agency()

                For i = 0 To GunaDataGridView1.Rows.Count - 1

                    NOM_AGENCE = GunaDataGridView1.Rows(i).Cells("NOM_AGENCE").Value.ToString()
                    CODE_AGENCE = GunaDataGridView1.Rows(i).Cells("CODE_AGENCE").Value.ToString()
                    FAX = GunaDataGridView1.Rows(i).Cells("FAX").Value.ToString()
                    EMAIL = GunaDataGridView1.Rows(i).Cells("EMAIL").Value.ToString()
                    TELEPHONE = GunaDataGridView1.Rows(i).Cells("TELEPHONE").Value.ToString()
                    VILLE = GunaDataGridView1.Rows(i).Cells("VILLE").Value.ToString()
                    BOITE_POSTALE = GunaDataGridView1.Rows(i).Cells("BOITE_POSTALE").Value.ToString()
                    PAYS = GunaDataGridView1.Rows(i).Cells("PAYS").Value.ToString()
                    RUE = GunaDataGridView1.Rows(i).Cells("RUE").Value.ToString()
                    CATEGORIE_HOTEL = GunaDataGridView1.Rows(i).Cells("CATEGORIE_HOTEL").Value

                    CATEGORIE_HOTEL = GunaDataGridView1.Rows(i).Cells("CATEGORIE_HOTEL").Value

                    WHATSAPP_1 = GunaDataGridView1.Rows(i).Cells("WHATSAPP_1").Value.ToString()
                    WHATSAPP_2 = GunaDataGridView1.Rows(i).Cells("WHATSAPP_2").Value.ToString()
                    WHATSAPP_3 = GunaDataGridView1.Rows(i).Cells("WHATSAPP_3").Value.ToString()
                    WHATSAPP_4 = GunaDataGridView1.Rows(i).Cells("WHATSAPP_4").Value.ToString()
                    WHATSAPP_5 = GunaDataGridView1.Rows(i).Cells("WHATSAPP_5").Value.ToString()
                    WHATSAPP_6 = GunaDataGridView1.Rows(i).Cells("WHATSAPP_6").Value.ToString()
                    WHATSAPP_7 = GunaDataGridView1.Rows(i).Cells("WHATSAPP_7").Value.ToString()

                    EMAIL_1 = GunaDataGridView1.Rows(i).Cells("EMAIL_1").Value.ToString()
                    EMAIL_2 = GunaDataGridView1.Rows(i).Cells("EMAIL_2").Value.ToString()
                    EMAIL_3 = GunaDataGridView1.Rows(i).Cells("EMAIL_3").Value.ToString()
                    EMAIL_4 = GunaDataGridView1.Rows(i).Cells("EMAIL_4").Value.ToString()
                    EMAIL_5 = GunaDataGridView1.Rows(i).Cells("EMAIL_5").Value.ToString()
                    EMAIL_6 = GunaDataGridView1.Rows(i).Cells("EMAIL_6").Value.ToString()
                    EMAIL_7 = GunaDataGridView1.Rows(i).Cells("EMAIL_7").Value.ToString()

                    'We update the value of the row in case of any change
                    If agency.InsertAgency(NOM_AGENCE, CODE_AGENCE, FAX, EMAIL, TELEPHONE, VILLE, BOITE_POSTALE, PAYS, RUE, CATEGORIE_HOTEL, WHATSAPP_1, WHATSAPP_2, WHATSAPP_3, WHATSAPP_4, WHATSAPP_5, WHATSAPP_6, WHATSAPP_7, EMAIL_1, EMAIL_2, EMAIL_3, EMAIL_4, EMAIL_5, EMAIL_6, EMAIL_7) Then

                    End If

                    GunaProgressBarL1.Value += 1

                Next

            ElseIf Trim(GunaComboBoxSheetL1.SelectedItem).Equals("Chambre") Then

                '4- CHAMBRE

                Dim CODE_CHAMBRE As String = ""
                Dim CODE_TYPE_CHAMBRE As String = ""
                Dim CODE_CATEGORY_CHAMBRE As String = ""
                Dim LIBELLE_CHAMBRE As String = ""
                Dim ETAT_CHAMBRE As Integer = 0
                Dim ETAT_CHAMBRE_NOTE As String = ""
                Dim LOCALISATION As String = ""
                Dim NUM_COMPTE As String = ""
                Dim PRIX As Double = 0
                Dim FICITIF As Integer = 0
                Dim LOCK_NO As String = ""
                Dim GUEST_DAI As String = ""
                Dim DATE_CREATION As Date
                Dim CODE_AGENCE As String = ""

                Dim room As New Room()

                For i = 0 To GunaDataGridView1.Rows.Count - 1

                    CODE_CHAMBRE = GunaDataGridView1.Rows(i).Cells("CODE_CHAMBRE").Value.ToString()
                    CODE_TYPE_CHAMBRE = GunaDataGridView1.Rows(i).Cells("CODE_TYPE_CHAMBRE").Value.ToString()
                    CODE_CATEGORY_CHAMBRE = GunaDataGridView1.Rows(i).Cells("CODE_CATEGORY_CHAMBRE").Value.ToString()
                    LIBELLE_CHAMBRE = GunaDataGridView1.Rows(i).Cells("LIBELLE_CHAMBRE").Value.ToString()
                    ETAT_CHAMBRE = GunaDataGridView1.Rows(i).Cells("ETAT_CHAMBRE").Value
                    ETAT_CHAMBRE_NOTE = GunaDataGridView1.Rows(i).Cells("ETAT_CHAMBRE_NOTE").Value.ToString()
                    LOCALISATION = GunaDataGridView1.Rows(i).Cells("LOCALISATION").Value.ToString()
                    NUM_COMPTE = GunaDataGridView1.Rows(i).Cells("NUM_COMPTE").Value.ToString()
                    PRIX = GunaDataGridView1.Rows(i).Cells("PRIX").Value
                    FICITIF = GunaDataGridView1.Rows(i).Cells("FICITIF").Value

                    If Not GunaDataGridView1.Rows(i).Cells("LOCK_NO").Value.ToString Is Nothing Then
                        LOCK_NO = GunaDataGridView1.Rows(i).Cells("LOCK_NO").Value.ToString
                    End If

                    GUEST_DAI = GunaDataGridView1.Rows(i).Cells("GUEST_DAI").Value.ToString()
                    DATE_CREATION = GunaDataGridView1.Rows(i).Cells("DATE_CREATION").Value.ToString()
                    CODE_AGENCE = GunaDataGridView1.Rows(i).Cells("CODE_AGENCE").Value.ToString()

                    'We update the value of the row in case of any change
                    If room.Insert(CODE_CHAMBRE, CODE_TYPE_CHAMBRE, CODE_CATEGORY_CHAMBRE, LIBELLE_CHAMBRE, ETAT_CHAMBRE, ETAT_CHAMBRE_NOTE, LOCALISATION, NUM_COMPTE, PRIX, FICITIF, LOCK_NO, GUEST_DAI, DATE_CREATION, CODE_AGENCE) Then

                    End If

                    GunaProgressBarL1.Value += 1

                Next

            ElseIf Trim(GunaComboBoxSheetL1.SelectedItem).Equals("Salle") Then

                '5- SALLE

                Dim CODE_CHAMBRE As String = ""
                Dim CODE_TYPE_CHAMBRE As String = ""
                Dim CODE_CATEGORY_CHAMBRE As String = ""
                Dim LIBELLE_CHAMBRE As String = ""
                Dim ETAT_CHAMBRE As Integer = 0
                Dim ETAT_CHAMBRE_NOTE As String = ""
                Dim LOCALISATION As String = ""
                Dim NUM_COMPTE As String = ""
                Dim PRIX As Double = 0
                Dim FICITIF As Integer = 0
                Dim LOCK_NO As String = ""
                Dim GUEST_DAI As String = ""
                Dim DATE_CREATION As Date
                Dim CODE_AGENCE As String = ""

                Dim room As New Room()

                For i = 0 To GunaDataGridView1.Rows.Count - 1

                    CODE_CHAMBRE = GunaDataGridView1.Rows(i).Cells("CODE_CHAMBRE").Value.ToString()
                    CODE_TYPE_CHAMBRE = GunaDataGridView1.Rows(i).Cells("CODE_TYPE_CHAMBRE").Value.ToString()
                    CODE_CATEGORY_CHAMBRE = GunaDataGridView1.Rows(i).Cells("CODE_CATEGORY_CHAMBRE").Value.ToString()
                    LIBELLE_CHAMBRE = GunaDataGridView1.Rows(i).Cells("LIBELLE_CHAMBRE").Value.ToString()
                    ETAT_CHAMBRE = GunaDataGridView1.Rows(i).Cells("ETAT_CHAMBRE").Value
                    ETAT_CHAMBRE_NOTE = GunaDataGridView1.Rows(i).Cells("ETAT_CHAMBRE_NOTE").Value.ToString()
                    LOCALISATION = GunaDataGridView1.Rows(i).Cells("LOCALISATION").Value.ToString()
                    NUM_COMPTE = GunaDataGridView1.Rows(i).Cells("NUM_COMPTE").Value.ToString()
                    PRIX = GunaDataGridView1.Rows(i).Cells("PRIX").Value
                    FICITIF = GunaDataGridView1.Rows(i).Cells("FICITIF").Value
                    LOCK_NO = GunaDataGridView1.Rows(i).Cells("LOCK_NO").Value
                    GUEST_DAI = GunaDataGridView1.Rows(i).Cells("GUEST_DAI").Value.ToString()
                    DATE_CREATION = GunaDataGridView1.Rows(i).Cells("DATE_CREATION").Value.ToString()
                    CODE_AGENCE = GunaDataGridView1.Rows(i).Cells("CODE_AGENCE").Value.ToString()

                    'We update the value of the row in case of any change
                    If room.Insert(CODE_CHAMBRE, CODE_TYPE_CHAMBRE, CODE_CATEGORY_CHAMBRE, LIBELLE_CHAMBRE, ETAT_CHAMBRE, ETAT_CHAMBRE_NOTE, LOCALISATION, NUM_COMPTE, PRIX, FICITIF, LOCK_NO, GUEST_DAI, DATE_CREATION, CODE_AGENCE) Then

                    End If

                    GunaProgressBarL1.Value += 1

                Next

            ElseIf Trim(GunaComboBoxSheetL1.SelectedItem).Equals("Fournisseur") Then

                '6- FOURNISSEUR
                Dim fournisseur As New Economat()

                Dim NOM_FOURNISSEUR As String
                Dim CODE_FOURNISSEUR As String
                Dim POURCENTAGE_REMISE As String
                Dim ADRESSE As String
                Dim TELEPHONE As String
                Dim FAX As String
                Dim NUMERO_COMPTE As String
                Dim CODE_AGENCE As String

                For i = 0 To GunaDataGridView1.Rows.Count - 1

                    NOM_FOURNISSEUR = GunaDataGridView1.Rows(i).Cells("NOM_FOURNISSEUR").Value.ToString()
                    CODE_FOURNISSEUR = GunaDataGridView1.Rows(i).Cells("CODE_FOURNISSEUR").Value.ToString()
                    POURCENTAGE_REMISE = GunaDataGridView1.Rows(i).Cells("POURCENTAGE_REMISE").Value.ToString()
                    ADRESSE = GunaDataGridView1.Rows(i).Cells("ADRESSE").Value.ToString()
                    TELEPHONE = GunaDataGridView1.Rows(i).Cells("TELEPHONE").Value
                    FAX = GunaDataGridView1.Rows(i).Cells("FAX").Value.ToString()
                    NUMERO_COMPTE = GunaDataGridView1.Rows(i).Cells("NUMERO_COMPTE").Value.ToString()
                    CODE_AGENCE = GunaDataGridView1.Rows(i).Cells("CODE_AGENCE").Value.ToString()

                    'We update the value of the row in case of any change
                    If fournisseur.insertFournisseur(NOM_FOURNISSEUR, CODE_FOURNISSEUR, POURCENTAGE_REMISE, ADRESSE, TELEPHONE, FAX, NUMERO_COMPTE, CODE_AGENCE) Then

                    End If

                    GunaProgressBarL1.Value += 1

                Next

            ElseIf Trim(GunaComboBoxSheetL1.SelectedItem).Equals("Personnel") Then

                '6- PERSONNEL

                Dim CODE_PERSONNEL As String
                Dim MATRICULE As String
                Dim NOM_PERSONNEL As String
                Dim NOM_JEUNE_FILLE As String
                Dim PRENOM_PERSONNEL As String
                Dim DATE_NAISSANCE As Date
                Dim LIEU_NAISSANCE As String
                Dim NOM_PERE As String
                Dim NOM_MERE As String
                Dim PROFESSION As String
                Dim CODE_AGENCE As String
                Dim SEXE As String
                Dim NUMERO_CNI As String
                Dim CODE_TYPE_PERSONNEL As String
                Dim ADRESSE As String
                Dim TELEPHONE As String
                Dim FAX As String
                Dim EMAIL As String
                Dim CODE_UTILISATEUR_CREA As String
                Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail
                Dim CHEMIN_PHOTO As String
                Dim SALAIRE As Double

                Dim personnel As New TypePersonnel()

                For i = 0 To GunaDataGridView1.Rows.Count - 1

                    CODE_PERSONNEL = GunaDataGridView1.Rows(i).Cells("CODE_PERSONNEL").Value.ToString()
                    MATRICULE = GunaDataGridView1.Rows(i).Cells("MATRICULE").Value.ToString()
                    NOM_PERSONNEL = GunaDataGridView1.Rows(i).Cells("NOM_PERSONNEL").Value.ToString()
                    NOM_JEUNE_FILLE = GunaDataGridView1.Rows(i).Cells("NOM_JEUNE_FILLE").Value.ToString()
                    PRENOM_PERSONNEL = GunaDataGridView1.Rows(i).Cells("PRENOM_PERSONNEL").Value.ToString()
                    DATE_NAISSANCE = GunaDataGridView1.Rows(i).Cells("DATE_NAISSANCE").Value.ToString()
                    LIEU_NAISSANCE = GunaDataGridView1.Rows(i).Cells("LIEU_NAISSANCE").Value.ToString()
                    NOM_PERE = GunaDataGridView1.Rows(i).Cells("NOM_PERE").Value.ToString()
                    NOM_MERE = GunaDataGridView1.Rows(i).Cells("NOM_MERE").Value.ToString()
                    PROFESSION = GunaDataGridView1.Rows(i).Cells("PROFESSION").Value.ToString()
                    SEXE = GunaDataGridView1.Rows(i).Cells("SEXE").Value.ToString()
                    NUMERO_CNI = GunaDataGridView1.Rows(i).Cells("NUMERO_CNI").Value.ToString()

                    CODE_TYPE_PERSONNEL = GunaDataGridView1.Rows(i).Cells("CODE_TYPE_PERSONNEL").Value.ToString()
                    ADRESSE = GunaDataGridView1.Rows(i).Cells("ADRESSE").Value.ToString()
                    TELEPHONE = GunaDataGridView1.Rows(i).Cells("TELEPHONE").Value.ToString()
                    FAX = GunaDataGridView1.Rows(i).Cells("FAX").Value.ToString()
                    EMAIL = GunaDataGridView1.Rows(i).Cells("EMAIL").Value.ToString()
                    CODE_UTILISATEUR_CREA = GunaDataGridView1.Rows(i).Cells("CODE_UTILISATEUR_CREA").Value.ToString()
                    'DATE_CREATION = GunaDataGridView1.Rows(i).Cells("DATE_CREATION").Value.ToString()
                    CODE_AGENCE = GunaDataGridView1.Rows(i).Cells("CODE_AGENCE").Value.ToString()

                    CHEMIN_PHOTO = GunaDataGridView1.Rows(i).Cells("CHEMIN_PHOTO").Value.ToString()
                    SALAIRE = GunaDataGridView1.Rows(i).Cells("SALAIRE").Value

                    'We update the value of the row in case of any change
                    If personnel.insertPersonnel(CODE_PERSONNEL, MATRICULE, NOM_PERSONNEL, NOM_JEUNE_FILLE, PRENOM_PERSONNEL, DATE_NAISSANCE, LIEU_NAISSANCE, NOM_PERE, NOM_MERE, PROFESSION, CODE_AGENCE, SEXE, NUMERO_CNI, CODE_TYPE_PERSONNEL, ADRESSE, TELEPHONE, FAX, EMAIL, CODE_UTILISATEUR_CREA, DATE_CREATION, CHEMIN_PHOTO, SALAIRE) Then

                    End If

                    GunaProgressBarL1.Value += 1

                Next

            End If

            MessageBox.Show("Importation (" & GunaComboBoxSheetL1.SelectedItem & ") Terminée avec succès !! ", "Importation de fichier Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
            GunaButtonL1.Enabled = False

        End If

    End Sub

    Private Sub GunaComboBoxSheet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxSheetL1.SelectedIndexChanged

        GunaButtonL1.Enabled = True
        GunaProgressBarL1.Value = 0

        GunaDataGridView1.Columns.Clear()

        If GunaComboBoxSheetL1.SelectedIndex >= 0 Then

            Dim dt As DataTable = tables(GunaComboBoxSheetL1.SelectedItem.ToString())
            GunaDataGridView1.DataSource = dt

        End If

    End Sub

    '1-------------------------- END PREMIERE LIGNE DE TELEVERSEMENT --------------------------

    Private Sub GunaImageButton5_Click(sender As Object, e As EventArgs) Handles GunaImageButton5.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        '1-------------------------- PREMIERE LIGNE DE TELEVERSEMENT --------------------------
        '1- TYPE DE CHAMBRE OU SALLE

        If GunaProgressBarL1.Value = 100 Then
            Timer1.Stop()
            MessageBox.Show("Importation (" & GunaComboBoxSheetL1.SelectedItem & ") Terminée avec succès !! ", "Importation de fichier Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
            GunaButtonL1.Enabled = False
        Else
            GunaProgressBarL1.Value += 5
        End If
        '-------------------------- END PREMIERE LIGNE DE TELEVERSEMENT --------------------------

    End Sub

    Private Sub GunaButton1_Click_1(sender As Object, e As EventArgs) Handles GunaButton1.Click

        Me.Close()

        AccueilForm.Show()

        MainWindow.Close()

    End Sub

End Class