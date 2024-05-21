Imports MySql.Data.MySqlClient

Public Class FournisseurForm

    'Dim connect As New DataBaseManipulation()

    Private Sub FournisseurForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim langue As New Languages()
        langue.fournisseur(GlobalVariable.actualLanguageValue)

    End Sub

    Private Sub GunaImageButton4_Click_1(sender As Object, e As EventArgs) Handles GunaImageButton4.Click
        Close()
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    Private Sub listeDesFournisseurs()

        'REFRESHING information from database for instant visualisation 
        Dim query As String = "SELECT `CODE_FOURNISSEUR` AS 'CODE FOURNISSEUR', `NOM_FOURNISSEUR` AS 'NOM FOURNISSEUR', `POURCENTAGE_REMISE` AS 'POURCENTAGE REMISE', `ADRESSE`, `TELEPHONE`, `FAX`, `NUMERO_COMPTE` AS 'NUMERO COMPTE', `DATE_CREATION` As 'DATE_CREATION' FROM `fournisseur` ORDER BY NOM_FOURNISSEUR ASC"

        Dim command As New MySqlCommand(query, GlobalVariable.connect)
        'Parameters.Add("@TYPE_INTERVENTION", MySqlDbType.VarChar).Value = GlobalVariable.TypeIntervention

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        If (table.Rows.Count > 0) Then
            GunaDataGridViewFournisseurs.DataSource = table
        Else
            GunaDataGridViewFournisseurs.Columns.Clear()
        End If

    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Dim fournisseur As New Economat()

        Dim NOM_FOURNISSEUR = GunaTextBoxRaisonSociale.Text
        Dim CODE_FOURNISSEUR = Functions.GeneratingRandomCode("fournisseur", "")
        Dim remise As Double
        Double.TryParse(GunaTextBoxPourcentageRemise.Text, remise)
        Dim POURCENTAGE_REMISE = remise
        Dim ADRESSE = GunaTextBoxAdresse.Text
        Dim TELEPHONE = GunaTextBoxPhone.Text
        Dim FAX = GunaTextBoxfax.Text
        Dim NUMERO_COMPTE = GunaTextBoxMail.Text
        Dim CODE_AGENCE = GlobalVariable.codeAgence

        If GunaButtonEnregistrer.Text = "Sauvegarder" Then

            CODE_FOURNISSEUR = GunaTextBoxCodeFournisseur.Text

            If fournisseur.updateFournisseur(NOM_FOURNISSEUR, CODE_FOURNISSEUR, POURCENTAGE_REMISE, ADRESSE, TELEPHONE, FAX, NUMERO_COMPTE, CODE_AGENCE) Then

                MessageBox.Show("Fournisseur mise à jour avec succès", "Fournisseur", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else

                MessageBox.Show("Un problème lors de la mise à jour du fournisseur", "Fournisseur", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If

            GunaButtonEnregistrer.Text = "Enregistrer"

        ElseIf GunaButtonEnregistrer.Text = "Enregistrer" And Not trim(GunaTextBoxRaisonSociale.TExt).Equals("") Then

            If fournisseur.insertFournisseur(NOM_FOURNISSEUR, CODE_FOURNISSEUR, POURCENTAGE_REMISE, ADRESSE, TELEPHONE, FAX, NUMERO_COMPTE, CODE_AGENCE) Then

                MessageBox.Show("Nouveau fournisseur crée avec succès", "Fournisseur", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else

                MessageBox.Show("Un problème lors de l'insertion du fournisseur", "Fournisseur", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If

        Else

            MessageBox.Show("Entrer la raison sociale ou le nom du fournisseur !!!", "Fournisseur", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

        Functions.SiplifiedClearTextBox(Me)

    End Sub

    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click
        listeDesFournisseurs()
    End Sub

End Class