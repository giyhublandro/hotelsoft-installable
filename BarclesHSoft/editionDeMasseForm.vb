Public Class editionDeMasseForm
    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click

        GunaTextBoxCodeTarifDynamiquePeriodique.Clear()
        Me.Close()

    End Sub

    Private Sub GunaImageButton3_Click(sender As Object, e As EventArgs) Handles GunaImageButton3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub AutoLoadOfTarifPrix(ByVal CODE_TYPE_CHAMBRE As String)

        Dim tarif As New Tarifs

        Dim ListOftarif As DataTable = tarif.SelectDistinctTarifPrix(CODE_TYPE_CHAMBRE)

        If ListOftarif.Rows.Count > 0 Then

            GunaComboBoxTypeDeTarif.DataSource = ListOftarif
            GunaComboBoxTypeDeTarif.ValueMember = "CODE_TARIF"
            GunaComboBoxTypeDeTarif.DisplayMember = "LIBELLE_TARIF"

        Else

            GunaComboBoxTypeDeTarif.SelectedIndex = -1
            GunaComboBoxTypeDeTarif.DataSource = Nothing
            GunaTextBoxMontant.Text = 0

        End If

    End Sub

    Private Sub AutoLoadOfTypeDeChambre()

        Dim ListOfRoomType As DataTable = Functions.getElementByCode("chambre", "type_chambre", "TYPE")

        If ListOfRoomType.Rows.Count > 0 Then

            GunaComboBoxTypeDeChambre.DataSource = ListOfRoomType
            GunaComboBoxTypeDeChambre.ValueMember = "CODE_TYPE_CHAMBRE"
            GunaComboBoxTypeDeChambre.DisplayMember = "LIBELLE_TYPE_CHAMBRE"

        End If

    End Sub

    Private Sub GunaComboBoxTypeDeChambre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTypeDeChambre.SelectedIndexChanged

        'au changement de type de chambre on recupere l'ensemble des tarifs associe a ce type de chambre

        GunaTextBoxMontant.Text = 0

        If GunaComboBoxTypeDeChambre.SelectedIndex >= 0 Then

            Dim CODE_TYPE_CHAMBRE As String = GunaComboBoxTypeDeChambre.SelectedValue.ToString

            AutoLoadOfTarifPrix(CODE_TYPE_CHAMBRE)

        End If

    End Sub

    Private Sub editionDeMasseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'loading of types of rooms

        GunaDateTimePickerDispoDebut.Value = GlobalVariable.DateDeTravail.ToShortDateString
        GunaDateTimePickerDispoFin.Value = GlobalVariable.DateDeTravail.AddDays(1).ToShortDateString

        AutoLoadOfTypeDeChambre()

        GunaComboBoxEtatEditionDeMasse.Items.Add("Désactiver") 'INDEX = ETAT = 0
        GunaComboBoxEtatEditionDeMasse.Items.Add("Activer") 'INDEX = ETAT = 1

        GunaComboBoxEtatEditionDeMasse.SelectedIndex = 0

        'SI L'ON VIENT DE LA FENETRE DE TARIFICATION POUR MODIFICATION

        If Not Trim(GunaTextBoxCodeTarifDynamiquePeriodique.Text).Equals("") Then

            Dim CODE_DISPO_TARIF_SPECIFIC As String = GunaTextBoxCodeTarifDynamiquePeriodique.Text

            Dim infoEditionDeMasse As DataTable = Functions.getElementByCode(CODE_DISPO_TARIF_SPECIFIC, "disponibilite_tarif_specifique_periodique", "CODE_DISPO_TARIF_SPECIFIC")

            If infoEditionDeMasse.Rows.Count > 0 Then

                'ON CHARGE LES TYPES DE TARIFS ASSOCIES A UN TYPE DE CHAMBRE

                'AutoLoadOfTarifPrix(infoEditionDeMasse.Rows(0)("CODE_TYPE_CHAMBRE"))

                GunaComboBoxTypeDeChambre.SelectedValue = infoEditionDeMasse.Rows(0)("CODE_TYPE_CHAMBRE")
                GunaComboBoxTypeDeTarif.SelectedValue = infoEditionDeMasse.Rows(0)("CODE_TARIF")
                GunaDateTimePickerDispoDebut.Value = infoEditionDeMasse.Rows(0)("DEBUT_PERIODE")
                GunaDateTimePickerDispoFin.Value = infoEditionDeMasse.Rows(0)("FIN_PERIODE")
                GunaTextBoxMontant.Text = Format(infoEditionDeMasse.Rows(0)("MONTANT"), "#,##0")

                GunaComboBoxEtatEditionDeMasse.SelectedIndex = Integer.Parse(infoEditionDeMasse.Rows(0)("ETAT"))

            End If


        End If

    End Sub

    Private Sub GunaButtonAppliquerTarifSpecifique_Click(sender As Object, e As EventArgs) Handles GunaButtonAppliquerTarifSpecifique.Click

        'NOUS APPLIQUONS LES TARIFS PARTICULIERS

        Dim CODE_TYPE_CHAMBRE As String = ""

        If GunaComboBoxTypeDeChambre.SelectedIndex >= 0 Then
            CODE_TYPE_CHAMBRE = GunaComboBoxTypeDeChambre.SelectedValue.ToString
        End If

        Dim CODE_TARIF As String = ""

        If GunaComboBoxTypeDeTarif.SelectedIndex >= 0 Then
            CODE_TARIF = GunaComboBoxTypeDeTarif.SelectedValue.ToString
        End If

        Dim DEBUT_PERIODE As Date = GunaDateTimePickerDispoDebut.Value.ToShortDateString
        Dim FIN_PERIODE As Date = GunaDateTimePickerDispoFin.Value.ToShortDateString
        Dim MONTANT As Double = GunaTextBoxMontant.Text
        Dim CODE_DISPO_TARIF_SPECIFIC As String = Functions.GeneratingRandomCode("disponibilite_tarif_specifique_periodique", "DTSP")
        Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

        Dim ETAT As Integer = 0 'DESACTIVER
        'ETAT = 1 'ACTIVER

        If GunaComboBoxEtatEditionDeMasse.SelectedIndex >= 0 Then
            ETAT = GunaComboBoxEtatEditionDeMasse.SelectedIndex
        End If

        Dim tarif As New Tarifs

        Dim message As String = ""

        'If GunaComboBoxTypeDeTarif.SelectedIndex >= 0 Then
        If True Then

            If GunaButtonAppliquerTarifSpecifique.Text = "Enregistrer" Then

                message = "Enregistrement effectué avec succès !! "

            ElseIf GunaButtonAppliquerTarifSpecifique.Text = "Sauvegarder" Then

                CODE_DISPO_TARIF_SPECIFIC = GunaTextBoxCodeTarifDynamiquePeriodique.Text

                Functions.DeleteElementByCode(CODE_DISPO_TARIF_SPECIFIC, "disponibilite_tarif_specifique_periodique", "CODE_DISPO_TARIF_SPECIFIC")

                message = "Sauvegarde effectuée avec succès !! "

                GunaButtonAppliquerTarifSpecifique.Text = "Enregistrer"

            End If

            tarif.insertTarifSpecificDisponibiliteEtTarif(CODE_TYPE_CHAMBRE, CODE_TARIF, DEBUT_PERIODE, FIN_PERIODE, MONTANT, CODE_DISPO_TARIF_SPECIFIC, CODE_UTILISATEUR_CREA, ETAT)

            MessageBox.Show(message, "TARIFICATION PERIODIQUE", MessageBoxButtons.OK, MessageBoxIcon.Information)

            GunaComboBoxTypeDeChambre.SelectedIndex = -1
            GunaComboBoxTypeDeTarif.SelectedIndex = -1

            GunaTextBoxCodeTarifDynamiquePeriodique.Clear()

            GunaTextBoxMontant.Text = 0

            Me.Cursor = Cursors.WaitCursor

            MainWindow.GunaPanelDisponibilite.Visible = True
            MainWindow.GunaPanelDisponibilite.BringToFront()

            MainWindow.DisponibiliteEtTarifs(MainWindow.GunaDateTimePickerDispoDebut.Value.ToShortDateString, MainWindow.GunaDateTimePickerDispoFin.Value.ToShortDateString)

            Me.Cursor = Cursors.Default

        Else
            MessageBox.Show("Impossible d'appliquer car aucun plan tarifaire n'est sélectionné", "TARIFICATION PERIODIQUE", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub GunaComboBoxTypeDeTarif_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTypeDeTarif.SelectedIndexChanged

        'AU CHANGEMENT DU TYPE DE TARIF AU CHANGE LE MONTANT AFFICHE

        If GunaComboBoxTypeDeTarif.SelectedIndex >= 0 Then

            Dim CODE_TARIF As String = GunaComboBoxTypeDeTarif.SelectedValue.ToString

            Dim tarifDataTable = Functions.getElementByCode(CODE_TARIF, "tarif_prix", "CODE_TARIF")

            If tarifDataTable.Rows.Count > 0 Then
                GunaTextBoxMontant.Text = 0
            End If

        End If

    End Sub

    Private Sub GunaButtonEditionDeMasse_Click(sender As Object, e As EventArgs) Handles GunaButtonEditionDeMasse.Click

        TarifForm.Show()
        TarifForm.TopMost = True
        TarifForm.TabControl1.SelectedIndex = 3

        Me.Close()

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click

    End Sub
End Class