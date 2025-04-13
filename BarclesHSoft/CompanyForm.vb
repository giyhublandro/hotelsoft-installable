Imports System.IO
Imports MySql.Data.MySqlClient

Public Class CompanyForm

    'Creating an instance of database
    'Dim connect As New DataBaseManipulation()

    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Close()
    End Sub

    Private Sub CompanyForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TabControl1.TabPages.Remove(TabPageTransferts)
        'In case we want to show it back
        'TabControl1.TabPages.Add(TabPageTransferts)

        TabControl1.TabPages.Remove(TabPageDivers)
        'TabControl1.TabPages.Add(TabPageDivers)

        'We load the information concerning the company
        GunaTextBoxNumero.Text = GlobalVariable.societe.Rows(0)("CODE_SOCIETE")
        GunaTextBoxBp.Text = GlobalVariable.societe.Rows(0)("BOITE_POSTALE")
        GunaTextBoxRaison.Text = GlobalVariable.societe.Rows(0)("RAISON_SOCIALE")
        GunaTextBoxVille.Text = GlobalVariable.societe.Rows(0)("VILLE")
        GunaTextBoxPays.Text = GlobalVariable.societe.Rows(0)("PAYS")
        GunaTextBoxFax.Text = GlobalVariable.societe.Rows(0)("FAX")
        GunaTextBoxMail.Text = GlobalVariable.societe.Rows(0)("EMAIL")
        GunaTextBoxRue.Text = GlobalVariable.societe.Rows(0)("RUE")
        GunaTextBoxNumContribuable.Text = GlobalVariable.societe.Rows(0)("NUM_CONTRIBUABLE")
        GunaTextBoxNumRegistre.Text = GlobalVariable.societe.Rows(0)("NUM_REGISTRE")
        GunaTextBoxTelephone.Text = GlobalVariable.societe.Rows(0)("TELEPHONE")

        If Not IsDBNull(GlobalVariable.societe.Rows(0)("LOGO")) Then
            Dim img() As Byte
            img = GlobalVariable.societe.Rows(0)("LOGO")
            Dim mStream As New MemoryStream(img)
            GunaPictureBoxLogo.Image = Image.FromStream(mStream)
        End If

    End Sub

    'Function to check empty fields
    Public Function verifyFields() As Boolean

        Dim check As Boolean = False

        If (GunaTextBoxRaison.Text.Trim().Equals("") _
                    Or GunaTextBoxNumero.Text.Trim().Equals("") _
                    Or GunaTextBoxBp.Text.Trim().Equals("") _
                    Or GunaTextBoxVille.Text.Trim().Equals("") _
                    Or GunaTextBoxPays.Text.Trim().Equals("") _
                    Or GunaTextBoxFax.Text.Trim().Equals("") _
                    Or GunaTextBoxMail.Text.Trim().Equals("") _
                    Or GunaTextBoxRue.Text.Trim().Equals("") _
                    Or GunaTextBoxNumContribuable.Text.Trim().Equals("") _
                    Or GunaTextBoxNumRegistre.Text.Trim().Equals("") _
                    Or GunaTextBoxTelephone.Text.Trim().Equals("")) Then
            check = False

        Else

            check = True

        End If

        Return check

    End Function

    'Saving company into database
    Private Sub GunaButtonEnregistrer_Click(sender As Object, e As EventArgs)

        Dim CODE_SOCIETE = GunaTextBoxNumero.Text
        Dim BOITE_POSTALE = GunaTextBoxBp.Text
        Dim RAISON_SOCIALE = GunaTextBoxRaison.Text
        Dim VILLE = GunaTextBoxVille.Text
        Dim PAYS = GunaTextBoxPays.Text
        Dim FAX = GunaTextBoxFax.Text
        Dim EMAIL = GunaTextBoxMail.Text
        Dim RUE = GunaTextBoxRue.Text
        Dim NUM_CONTRIBUABLE = GunaTextBoxNumContribuable.Text
        Dim NUM_REGISTRE = GunaTextBoxNumRegistre.Text
        Dim TELEPHONE = GunaTextBoxTelephone.Text

        Dim company As New Company

        'company verifyfields function
        If (verifyFields()) Then
            'check if the company alreday exist
            If Not company.companyExists(CODE_SOCIETE, RAISON_SOCIALE) Then
                If company.InsertCompany(CODE_SOCIETE, RAISON_SOCIALE, VILLE, BOITE_POSTALE, PAYS, TELEPHONE, FAX, EMAIL, RUE, NUM_CONTRIBUABLE, NUM_REGISTRE) Then
                    MessageBox.Show("Nouvelle Société enregistré avec succès", "Création de Société", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    'We empty the fields
                    GunaTextBoxNumero.Text = ""
                    GunaTextBoxBp.Text = ""
                    GunaTextBoxRaison.Text = ""
                    GunaTextBoxVille.Text = ""
                    GunaTextBoxPays.Text = ""
                    GunaTextBoxFax.Text = ""
                    GunaTextBoxMail.Text = ""
                    GunaTextBoxRue.Text = ""
                    GunaTextBoxNumContribuable.Text = ""
                    GunaTextBoxNumRegistre.Text = ""
                    GunaTextBoxTelephone.Text = ""
                Else
                    MessageBox.Show("Un problème lors de la création !!", "Création de Société", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Cette société existe déjà, Essayer à nouveau", "Société Invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Bien vouloir remplir tous les champs!!", "Création de Société", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub GunaButtonFermer_Click_1(sender As Object, e As EventArgs) Handles GunaButtonFermer.Click
        Me.Close()
    End Sub

    'Saving the informations of the company
    Private Sub GunaButtonEnregistrer_Click_1(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        GlobalVariable.societe = Functions.allTableFields("societe")

        Dim company As New Company()

        Functions.DeleteElementByCode(GlobalVariable.societe.Rows(0)("CODE_SOCIETE"), "societe", "CODE_SOCIETE")

        If company.InsertCompany(GunaTextBoxNumero.Text, GunaTextBoxRaison.Text, GunaTextBoxVille.Text, GunaTextBoxBp.Text, GunaTextBoxPays.Text, GunaTextBoxTelephone.Text, GunaTextBoxFax.Text, GunaTextBoxMail.Text, GunaTextBoxRue.Text, GunaTextBoxNumContribuable.Text, GunaTextBoxNumRegistre.Text) Then

            'we update the other values obtained from configurations
            If company.UpdateCompany(GlobalVariable.societe.Rows(0)("CODE_SOCIETE"), GlobalVariable.societe.Rows(0)("TAUX_CHAMBRE"), GlobalVariable.societe.Rows(0)("TAUX_TVA"), GlobalVariable.societe.Rows(0)("TAUX_REPAS"), GlobalVariable.societe.Rows(0)("TAUX_PRODUIT"), GlobalVariable.societe.Rows(0)("DATE_CREATION")) Then

                Dim ms As New MemoryStream()
                GunaPictureBoxLogo.Image.Save(ms, GunaPictureBoxLogo.Image.RawFormat)
                Dim img As Byte() = ms.GetBuffer()
                If ms.Length > 0 Then
                    Dim updateQuery As String = "UPDATE `societe` SET `LOGO`=@LOGO WHERE CODE_SOCIETE = @CODE_SOCIETE"

                    Dim command As New MySqlCommand(updateQuery, GlobalVariable.connect)

                    command.Parameters.Add("@CODE_SOCIETE", MySqlDbType.VarChar).Value = GlobalVariable.societe.Rows(0)("CODE_SOCIETE")
                    command.Parameters.Add("@LOGO", MySqlDbType.Blob).Value = ms.ToArray()

                    If (command.ExecuteNonQuery() = 1) Then

                    End If
                Else

                    MessageBox.Show("Erreur lors du chargement du logo !", "Mise à jours de Société", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

                MessageBox.Show("Société Mise à jours avec succès", "Mise à jours de Société", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        End If

        'We update the content of the variable societe
        GlobalVariable.societe = Functions.allTableFields("societe")

    End Sub

    'GESTION DU LOGO
    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButtonUpload.Click

        Dim opf As New OpenFileDialog
        opf.Filter = "Choose Image(*.JPG;*.PNG;*.GIF) | *.jpg;*.png;*.gif"

        If opf.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim ImagePath As String = opf.FileName
            GunaPictureBoxLogo.Image = Image.FromFile(opf.FileName)
            'GunaPictureBoxLogo.ImageLocation = ImagePath

        End If

    End Sub

    Private Sub GunaCheckBoxConfig_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxConfig.CheckedChanged
        If GunaCheckBoxConfig.Checked Then
            ConfigForm.Show()
            ConfigForm.TopMost = True
        Else
            ConfigForm.Close()
        End If
    End Sub
End Class