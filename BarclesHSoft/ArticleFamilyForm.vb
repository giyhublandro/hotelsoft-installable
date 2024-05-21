Imports MySql.Data.MySqlClient

Public Class ArticleFamilyForm

    'Dim connect As New DataBaseManipulation()

    Private Sub ArticleFamilyForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If GlobalVariable.typeFamilleOuSousFamille = "famille" Then 'POINT DE VENTE

            Functions.AffectingTitleToAForm("GESTION DES POINTS DE VENTES", GunaLabelGestCompteGeneraux)

            GunaLabelCategorie.Visible = False
            GunaComboBoxCategArticle.Visible = False

            GunaLabelFamilleArticle.Visible = False
            GunaComboBoxFamilleArticle.Visible = False

            GunaComboBoxCategArticle.SelectedIndex = -1
            GunaComboBoxFamilleArticle.SelectedIndex = -1

        ElseIf GlobalVariable.typeFamilleOuSousFamille = "sous famille" Then ' FAMILLE
            Functions.AffectingTitleToAForm("GESTION DES FAMILLES D'ARTICLE", GunaLabelGestCompteGeneraux)
            GunaLabelFamilleArticle.Visible = False
            GunaComboBoxFamilleArticle.Visible = False

            loadCategorieArticle()

        ElseIf GlobalVariable.typeFamilleOuSousFamille = "categorie" Then 'CATEGORIE
            Functions.AffectingTitleToAForm("GESTION DES CATEGORIES D'ARTICLE", GunaLabelGestCompteGeneraux)

            GunaLabelCategorie.Visible = False
            GunaComboBoxCategArticle.Visible = False

            GunaLabelFamilleArticle.Visible = False
            GunaComboBoxFamilleArticle.Visible = False

            GunaComboBoxCategArticle.SelectedIndex = -1
            GunaComboBoxFamilleArticle.SelectedIndex = -1


        ElseIf GlobalVariable.typeFamilleOuSousFamille = "sous sous famille" Then ' SOUS FAMILLE
            Functions.AffectingTitleToAForm("GESTION DES SOUS FAMILLES D'ARTICLE", GunaLabelGestCompteGeneraux)

            GunaComboBoxCategArticle.SelectedIndex = -1

            'loadFamilleArticle()

            loadCategorieArticle()

        End If

        Dim language As New Languages()

        language.articleFamily(GlobalVariable.actualLanguageValue)

        'familleOuSousFamilleListe()

        TabControl1.SelectedIndex = 1


    End Sub

    Private Sub loadCategorieArticle()

        Dim categorieArticle As DataTable = Functions.allTableFieldsOrganised("categorie_article", "LIBELLE_FAMILLE")

        If (categorieArticle.Rows.Count > 0) Then

            GunaComboBoxCategArticle.DataSource = categorieArticle
            'GunaComboBoxCategArticle.ValueMember = "CODE_FAMILLE"
            GunaComboBoxCategArticle.ValueMember = "LIBELLE_FAMILLE"
            GunaComboBoxCategArticle.DisplayMember = "LIBELLE_FAMILLE"

        End If

    End Sub

    Private Sub loadFamilleArticle()

        Dim Famille As DataTable = Functions.allTableFieldsOrganised("sous_famille", "LIBELLE_SOUS_FAMILLE")

        If (Famille.Rows.Count > 0) Then

            GunaComboBoxFamilleArticle.DataSource = Famille
            GunaComboBoxFamilleArticle.ValueMember = "LIBELLE_SOUS_FAMILLE"
            'GunaComboBoxFamilleArticle.ValueMember = "CODE_SOUS_FAMILLE"
            GunaComboBoxFamilleArticle.DisplayMember = "LIBELLE_SOUS_FAMILLE"

        End If

    End Sub

    Private Sub GunaImageButton3_Click(sender As Object, e As EventArgs) Handles GunaImageButton3.Click
        GlobalVariable.typeFamilleOuSousFamille = ""
        Close()
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        GlobalVariable.typeFamilleOuSousFamille = ""
        Me.Close()
    End Sub

    Public Sub familleOuSousFamilleListe()

        Dim query As String

        If GlobalVariable.typeFamilleOuSousFamille = "famille" Then 'POINT DE VENTE

            If GlobalVariable.actualLanguageValue = 0 Then
                query = "SELECT CODE_FAMILLE AS 'CODE', LIBELLE_FAMILLE As 'SALE POINT', NIVEAU_HIERARCHIQUE As 'DESCRIPTION', DATE_CREATION AS 'CREATION DATE ' FROM famille ORDER BY LIBELLE_FAMILLE ASC"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                query = "SELECT CODE_FAMILLE AS 'CODE', LIBELLE_FAMILLE As 'POINT DE VENTE', NIVEAU_HIERARCHIQUE As 'DESCRIPTION', DATE_CREATION AS 'DATE CREATION' FROM famille ORDER BY LIBELLE_FAMILLE ASC"
            End If

        ElseIf GlobalVariable.typeFamilleOuSousFamille = "sous famille" Then 'FAMILLE

            If GlobalVariable.actualLanguageValue = 0 Then
                query = "SELECT CODE_SOUS_FAMILLE AS 'CODE', LIBELLE_SOUS_FAMILLE AS 'FAMILY', NIVEAU_HIERARCHIQUE As 'DESCRIPTION', DATE_CREATION AS 'CREATION DATE' FROM sous_famille ORDER BY LIBELLE_SOUS_FAMILLE ASC"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                query = "SELECT CODE_SOUS_FAMILLE AS 'CODE', LIBELLE_SOUS_FAMILLE AS 'FAMILLE', NIVEAU_HIERARCHIQUE As 'DESCRIPTION', DATE_CREATION AS 'DATE CREATION' FROM sous_famille ORDER BY LIBELLE_SOUS_FAMILLE ASC"
            End If

        ElseIf GlobalVariable.typeFamilleOuSousFamille = "sous sous famille" Then 'SOUS FAMILLE


            If GlobalVariable.actualLanguageValue = 0 Then

                query = "SELECT CODE_FAMILLE AS 'CODE', LIBELLE_FAMILLE As 'SUB FAMILY', NIVEAU_HIERARCHIQUE As 'DESCRIPTION', DATE_CREATION AS 'CREATION DATE' FROM sous_sous_famille ORDER BY LIBELLE_FAMILLE ASC"

            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                query = "SELECT CODE_FAMILLE AS 'CODE', LIBELLE_FAMILLE As 'SOUS FAMILLE', NIVEAU_HIERARCHIQUE As 'DESCRIPTION', DATE_CREATION AS 'DATE CREATION' FROM sous_sous_famille ORDER BY LIBELLE_FAMILLE ASC"
            End If

        ElseIf GlobalVariable.typeFamilleOuSousFamille = "categorie" Then 'CATEGORIE

            If GlobalVariable.actualLanguageValue = 0 Then

                query = "SELECT CODE_FAMILLE AS 'CODE', LIBELLE_FAMILLE As 'CATEGORY', NIVEAU_HIERARCHIQUE As 'DESCRIPTION', DATE_CREATION AS 'CREATION DATE ' FROM categorie_article ORDER BY LIBELLE_FAMILLE ASC"

            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                query = "SELECT CODE_FAMILLE AS 'CODE', LIBELLE_FAMILLE As 'CATEGORIE', NIVEAU_HIERARCHIQUE As 'DESCRIPTION', DATE_CREATION AS 'DATE CREATION' FROM categorie_article ORDER BY LIBELLE_FAMILLE ASC"

            End If

        End If

        Dim command As New MySqlCommand(query, GlobalVariable.connect)

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)

        'connect.openConnection()

        If (table.Rows.Count > 0) Then

            GunaDataGridViewFamilleArticle.DataSource = table

            GunaDataGridViewFamilleArticle.Columns("CODE").Visible = False

            GunaTextBoxLIbelle.Text = ""
            GunaComboBoxSuiviStock.SelectedIndex = -1
            GunaTextBoxTauxRemise.Text = 0.00
            GunaTextBoxTauxTVA.Text = 0.00
            GunaTextBoxDescription.Text = ""
            GunaTextBoxCodeArticle.Text = ""

        Else
            'MessageBox.Show("No record found!")
        End If

        'connect.closeConnection()

    End Sub

    Dim languageMessage As String = ""
    Dim languageTitle As String = ""

    'Saving An entry
    Private Sub GunaButtonEnregistrer_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Dim CODE_FAMILLE As String = Functions.GeneratingRandomCode("famille", "")
        Dim LIBELLE_FAMILLE As String = GunaTextBoxLIbelle.Text
        Dim NIVEAU_HIERARCHIQUE As String = GunaTextBoxDescription.Text 'DESCRIPTION
        Dim CODE_FAMILLE_PARENT As String = ""

        If GunaComboBoxCategArticle.SelectedIndex >= 0 Then
            CODE_FAMILLE_PARENT = GunaComboBoxCategArticle.SelectedValue.ToString()
        End If

        If GunaComboBoxFamilleArticle.SelectedIndex >= 0 Then
            CODE_FAMILLE_PARENT = GunaComboBoxFamilleArticle.SelectedValue.ToString()
        End If

        Dim NUM_COMPTE_MARCHANDISE As String = ""
        Dim NUM_COMPTE_VENTE As String = ""
        Dim METHODE_SUIVI_STOCK As String = GunaComboBoxSuiviStock.SelectedItem
        Dim pourcentage As Double = 0
        Double.TryParse(GunaTextBoxTauxRemise.Text, pourcentage)
        Dim POURCENTAGE_REMISE As Double = pourcentage
        Dim tva As Double = 0
        Double.TryParse(GunaTextBoxTauxTVA.Text, tva)
        Dim TAUX_TVA As Double = tva
        Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail
        Dim CODE_UTILISATEUR_CREA = GlobalVariable.codeUser
        Dim DATE_MODIFICATION As DateTime = CDate(GlobalVariable.DateDeTravail)
        Dim CODE_UTILISATEUR_MODIF As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim CODE_AGENCE As String = GlobalVariable.codeAgence
        Dim TABLE_NAME As String = ""

        Dim articleFamily As New ArticleFamily

        If GunaButtonEnregistrer.Text = "Sauvegarder" Or GunaButtonEnregistrer.Text = "Save" Then

            CODE_FAMILLE = Trim(GunaTextBoxCodeArticle.Text)

            If GlobalVariable.typeFamilleOuSousFamille = "sous famille" Then 'sous famille = famille

                TABLE_NAME = "sous_famille"

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "Family updated successfully"
                    languageTitle = "Update of Item family"
                    GunaButtonEnregistrer.Text = "Add"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Famille mise à jour avec succès"
                    languageTitle = "Mise à jour de famille d'article"
                    GunaButtonEnregistrer.Text = "Enregistrer"
                End If

                If articleFamily.updateArticleFamilySous(CODE_FAMILLE, LIBELLE_FAMILLE, NIVEAU_HIERARCHIQUE, CODE_FAMILLE_PARENT, NUM_COMPTE_MARCHANDISE, NUM_COMPTE_VENTE, METHODE_SUIVI_STOCK, POURCENTAGE_REMISE, TAUX_TVA, DATE_CREATION, CODE_UTILISATEUR_CREA, DATE_MODIFICATION, CODE_UTILISATEUR_MODIF, CODE_AGENCE) Then

                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else

                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageMessage = "Something went wrong during updating !"
                        languageTitle = "Updating"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        languageMessage = "Un problème lors de la mise à jour !"
                        languageTitle = "Mise de à jour"
                    End If
                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                TabControl1.SelectedIndex = 1

            ElseIf GlobalVariable.typeFamilleOuSousFamille = "famille" Then 'famille = point de vente

                TABLE_NAME = "famille"

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "Sale point updated successfully"
                    languageTitle = "Update of Item sale point"
                    GunaButtonEnregistrer.Text = "Add"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Point de vente mise à jour avec succès"
                    languageTitle = "Mise à jour du point de vente"
                    GunaButtonEnregistrer.Text = "Enregistrer"
                End If

                If articleFamily.updateArticleFamily(CODE_FAMILLE, LIBELLE_FAMILLE, NIVEAU_HIERARCHIQUE, CODE_FAMILLE_PARENT, NUM_COMPTE_MARCHANDISE, NUM_COMPTE_VENTE, METHODE_SUIVI_STOCK, POURCENTAGE_REMISE, TAUX_TVA, DATE_CREATION, CODE_UTILISATEUR_CREA, DATE_MODIFICATION, CODE_UTILISATEUR_MODIF, CODE_AGENCE, TABLE_NAME) Then
                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageMessage = "Something went wrong during updating !"
                        languageTitle = "Updating"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        languageMessage = "Un problème lors de la mise à jour !"
                        languageTitle = "Mise de à jour"
                    End If
                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                TabControl1.SelectedIndex = 1

            ElseIf GlobalVariable.typeFamilleOuSousFamille = "categorie" Then

                TABLE_NAME = "categorie_article"

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "Category updated successfully"
                    languageTitle = "Update of Item category"
                    GunaButtonEnregistrer.Text = "Add"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Catégorie mise à jour avec succès"
                    languageTitle = "Mise à jour de catégorie d'article"
                    GunaButtonEnregistrer.Text = "Enregistrer"
                End If

                If articleFamily.updateArticleFamily(CODE_FAMILLE, LIBELLE_FAMILLE, NIVEAU_HIERARCHIQUE, CODE_FAMILLE_PARENT, NUM_COMPTE_MARCHANDISE, NUM_COMPTE_VENTE, METHODE_SUIVI_STOCK, POURCENTAGE_REMISE, TAUX_TVA, DATE_CREATION, CODE_UTILISATEUR_CREA, DATE_MODIFICATION, CODE_UTILISATEUR_MODIF, CODE_AGENCE, TABLE_NAME) Then

                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageMessage = "Something went wrong during updating !"
                        languageTitle = "Updating"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        languageMessage = "Un problème lors de la mise à jour !"
                        languageTitle = "Mise de à jour"
                    End If
                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                TabControl1.SelectedIndex = 1

            ElseIf GlobalVariable.typeFamilleOuSousFamille = "sous sous famille" Then 'SOUS FAMILLE

                TABLE_NAME = "sous_sous_famille"

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "Sub family updated successfully"
                    languageTitle = "Update of Item sub family"
                    GunaButtonEnregistrer.Text = "Add"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Sous famille mise à jour avec succès"
                    languageTitle = "Mise à jour de Sous famille d'article"
                    GunaButtonEnregistrer.Text = "Enregistrer"
                End If

                If articleFamily.updateArticleFamily(CODE_FAMILLE, LIBELLE_FAMILLE, NIVEAU_HIERARCHIQUE, CODE_FAMILLE_PARENT, NUM_COMPTE_MARCHANDISE, NUM_COMPTE_VENTE, METHODE_SUIVI_STOCK, POURCENTAGE_REMISE, TAUX_TVA, DATE_CREATION, CODE_UTILISATEUR_CREA, DATE_MODIFICATION, CODE_UTILISATEUR_MODIF, CODE_AGENCE, TABLE_NAME) Then

                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageMessage = "Something went wrong during updating !"
                        languageTitle = "Updating"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        languageMessage = "Un problème lors de la mise à jour !"
                        languageTitle = "Mise de à jour"
                    End If
                    MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                TabControl1.SelectedIndex = 1

            End If

        Else

            'verifyfields function
            If (True) Then
                'check if entry already  exist

                If GlobalVariable.typeFamilleOuSousFamille = "sous famille" Then 'FAMILLE

                    If Not Functions.entryCodeExists(CODE_FAMILLE, "sous_famille", "CODE_SOUS_FAMILLE") Then

                        If GlobalVariable.actualLanguageValue = 0 Then
                            languageMessage = "New family created successfully"
                            languageTitle = "Family creation"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            languageMessage = "Nouvelle Famille enregistrée avec succès "
                            languageTitle = "Création de famille d'article"
                        End If

                        If articleFamily.insertArticleFamilySous(CODE_FAMILLE, LIBELLE_FAMILLE, NIVEAU_HIERARCHIQUE, CODE_FAMILLE_PARENT, NUM_COMPTE_MARCHANDISE, NUM_COMPTE_VENTE, METHODE_SUIVI_STOCK, POURCENTAGE_REMISE, TAUX_TVA, DATE_CREATION, CODE_UTILISATEUR_CREA, DATE_MODIFICATION, CODE_UTILISATEUR_MODIF, CODE_AGENCE) Then

                            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else

                            If GlobalVariable.actualLanguageValue = 0 Then
                                languageMessage = "Something went wrong during Creation !"
                                languageTitle = "Family creation"
                            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                                languageMessage = "Un problème lors de la création !!"
                                languageTitle = "Création d'une famille"
                            End If

                            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        If GlobalVariable.actualLanguageValue = 0 Then
                            languageMessage = "This family already exist, try again"
                            languageTitle = "Family creation"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            languageMessage = "Cette Famille existe déjà, Essayer à nouveau"
                            languageTitle = "Création d'une famille"
                        End If
                        MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                ElseIf GlobalVariable.typeFamilleOuSousFamille = "categorie" Then 'CATEGORIE

                    If Not Functions.entryCodeExists(CODE_FAMILLE, "famille", "CODE_FAMILLE") Then

                        TABLE_NAME = "categorie_article"

                        If GlobalVariable.actualLanguageValue = 0 Then
                            languageMessage = "New categorie created successfully"
                            languageTitle = "Categorie creation"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            languageMessage = "Nouvelle catégorie enregistrée avec succès "
                            languageTitle = "Création de Catégorie"
                        End If

                        If articleFamily.insertArticleFamily(CODE_FAMILLE, LIBELLE_FAMILLE, NIVEAU_HIERARCHIQUE, CODE_FAMILLE_PARENT, NUM_COMPTE_MARCHANDISE, NUM_COMPTE_VENTE, METHODE_SUIVI_STOCK, POURCENTAGE_REMISE, TAUX_TVA, DATE_CREATION, CODE_UTILISATEUR_CREA, DATE_MODIFICATION, CODE_UTILISATEUR_MODIF, CODE_AGENCE, TABLE_NAME) Then

                            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else

                            If GlobalVariable.actualLanguageValue = 0 Then
                                languageMessage = "Something went wrong during Creation !"
                                languageTitle = "Category creation"
                            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                                languageMessage = "Un problème lors de la création !!"
                                languageTitle = "Création d'une catégorie"
                            End If

                            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        End If
                    Else
                        If GlobalVariable.actualLanguageValue = 0 Then
                            languageMessage = "This category already, exist try again"
                            languageTitle = "Category creation"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            languageMessage = "Cette Catégorie existe déjà, Essayer à nouveau"
                            languageTitle = "Création d'une catégorie"
                        End If
                        MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                ElseIf GlobalVariable.typeFamilleOuSousFamille = "sous sous famille" Then 'SOUS FAMILLE

                    If Not Functions.entryCodeExists(CODE_FAMILLE, "famille", "CODE_FAMILLE") Then

                        TABLE_NAME = "sous_sous_famille"

                        If GlobalVariable.actualLanguageValue = 0 Then
                            languageMessage = "New Sub family created successfully"
                            languageTitle = "Sub family creation"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            languageMessage = "Nouvelle sous famille enregistrée avec succès "
                            languageTitle = "Création de Sous famille"
                        End If

                        If articleFamily.insertArticleFamily(CODE_FAMILLE, LIBELLE_FAMILLE, NIVEAU_HIERARCHIQUE, CODE_FAMILLE_PARENT, NUM_COMPTE_MARCHANDISE, NUM_COMPTE_VENTE, METHODE_SUIVI_STOCK, POURCENTAGE_REMISE, TAUX_TVA, DATE_CREATION, CODE_UTILISATEUR_CREA, DATE_MODIFICATION, CODE_UTILISATEUR_MODIF, CODE_AGENCE, TABLE_NAME) Then

                            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else

                            If GlobalVariable.actualLanguageValue = 0 Then
                                languageMessage = "Something went wrong during Creation !"
                                languageTitle = "Sub Family creation"
                            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                                languageMessage = "Un problème lors de la création !!"
                                languageTitle = "Création d'une sous famille"
                            End If

                            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        End If
                    Else
                        If GlobalVariable.actualLanguageValue = 0 Then
                            languageMessage = "This Sub family already exist try again"
                            languageTitle = "Sub Family creation"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            languageMessage = "Cette Sous Famille existe déjà, Essayer à nouveau"
                            languageTitle = "Création d'une sous famille"
                        End If
                        MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                ElseIf GlobalVariable.typeFamilleOuSousFamille = "famille" Then 'POINT DE VENTE

                    If Not Functions.entryCodeExists(CODE_FAMILLE, "famille", "CODE_FAMILLE") Then

                        TABLE_NAME = "famille"

                        If GlobalVariable.actualLanguageValue = 0 Then
                            languageMessage = "New Sale point created successfully"
                            languageTitle = "Sale point creation"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            languageMessage = "Nouveau point de vente enregistré avec succès "
                            languageTitle = "Création de Point de vente"
                        End If

                        If articleFamily.insertArticleFamily(CODE_FAMILLE, LIBELLE_FAMILLE, NIVEAU_HIERARCHIQUE, CODE_FAMILLE_PARENT, NUM_COMPTE_MARCHANDISE, NUM_COMPTE_VENTE, METHODE_SUIVI_STOCK, POURCENTAGE_REMISE, TAUX_TVA, DATE_CREATION, CODE_UTILISATEUR_CREA, DATE_MODIFICATION, CODE_UTILISATEUR_MODIF, CODE_AGENCE, TABLE_NAME) Then

                            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else

                            If GlobalVariable.actualLanguageValue = 0 Then
                                languageMessage = "Something went wrong during Creation !"
                                languageTitle = "Sale point creation"
                            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                                languageMessage = "Un problème lors de la création !!"
                                languageTitle = "Création d'un Point de vente"
                            End If

                            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        End If
                    Else
                        If GlobalVariable.actualLanguageValue = 0 Then
                            languageMessage = "This sale point already exist, try again"
                            languageTitle = "Sale Point creation"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            languageMessage = "Ce point de vente existe déjà, Essayer à nouveau"
                            languageTitle = "Création d'un point de vente"
                        End If
                        MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                End If

            Else
                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "please fill all the fields"
                    languageTitle = "Information"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Bien vouloir remplir tous les champs!!"
                    languageTitle = "Information"
                End If
                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

        Functions.SiplifiedClearTextBox(Me)

    End Sub

    Private Sub GunaDataGridViewFamilleArticle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewFamilleArticle.CellDoubleClick

        If e.RowIndex >= 0 Then

            If GlobalVariable.actualLanguageValue = 0 Then

                GunaButtonEnregistrer.Text = "Save"

            ElseIf GlobalVariable.actualLanguageValue = 1 Then

                GunaButtonEnregistrer.Text = "Sauvegarder"

            End If

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewFamilleArticle.Rows(e.RowIndex)

            TabControl1.SelectedIndex = 0

            Dim FamilleArticle As DataTable

            If GlobalVariable.typeFamilleOuSousFamille = "famille" Then ' point de vente
                FamilleArticle = Functions.getElementByCode(Trim(row.Cells("CODE").Value.ToString), "famille", "CODE_FAMILLE")
            ElseIf GlobalVariable.typeFamilleOuSousFamille = "sous famille" Then
                FamilleArticle = Functions.getElementByCode(Trim(row.Cells("CODE").Value.ToString), "sous_famille", "CODE_SOUS_FAMILLE")
            ElseIf GlobalVariable.typeFamilleOuSousFamille = "sous sous famille" Then
                FamilleArticle = Functions.getElementByCode(Trim(row.Cells("CODE").Value.ToString), "sous_sous_famille", "CODE_FAMILLE")
            ElseIf GlobalVariable.typeFamilleOuSousFamille = "categorie" Then ' famille
                FamilleArticle = Functions.getElementByCode(Trim(row.Cells("CODE").Value.ToString), "categorie_article", "CODE_FAMILLE")
            End If

            If FamilleArticle.Rows.Count > 0 Then

                If GlobalVariable.typeFamilleOuSousFamille = "famille" Then ' POINT DE VENTE
                    GunaTextBoxCodeArticle.Text = FamilleArticle.Rows(0)("CODE_FAMILLE")
                    GunaTextBoxLIbelle.Text = FamilleArticle.Rows(0)("LIBELLE_FAMILLE")
                ElseIf GlobalVariable.typeFamilleOuSousFamille = "sous famille" Then 'FAMILLE
                    GunaTextBoxCodeArticle.Text = FamilleArticle.Rows(0)("CODE_SOUS_FAMILLE")
                    GunaTextBoxLIbelle.Text = FamilleArticle.Rows(0)("LIBELLE_SOUS_FAMILLE")
                    GunaComboBoxCategArticle.SelectedValue = FamilleArticle.Rows(0)("CODE_FAMILLE_PARENT")
                ElseIf GlobalVariable.typeFamilleOuSousFamille = "sous sous famille" Then 'SOUS FAMILLE
                    GunaTextBoxCodeArticle.Text = FamilleArticle.Rows(0)("CODE_FAMILLE")
                    GunaTextBoxLIbelle.Text = FamilleArticle.Rows(0)("LIBELLE_FAMILLE")

                    loadFamilleArticle()

                    GunaComboBoxFamilleArticle.SelectedValue = FamilleArticle.Rows(0)("CODE_FAMILLE_PARENT")
                    'GunaComboBoxCategArticle.SelectedValue = FamilleArticle.Rows(0)("NIVEAU_HIERARCHIQUE")
                ElseIf GlobalVariable.typeFamilleOuSousFamille = "categorie" Then 'CATEGORIE
                    GunaTextBoxCodeArticle.Text = FamilleArticle.Rows(0)("CODE_FAMILLE")
                    GunaTextBoxLIbelle.Text = FamilleArticle.Rows(0)("LIBELLE_FAMILLE")
                End If

                GunaComboBoxSuiviStock.SelectedItem = FamilleArticle.Rows(0)("METHODE_SUIVI_STOCK")
                GunaTextBoxTauxRemise.Text = FamilleArticle.Rows(0)("POURCENTAGE_REMISE")
                GunaTextBoxTauxTVA.Text = FamilleArticle.Rows(0)("TAUX_TVA")
                'NIVEAU_HIERARCHIQUE Used as description
                GunaTextBoxDescription.Text = FamilleArticle.Rows(0)("NIVEAU_HIERARCHIQUE")

            End If

        End If

    End Sub

    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        If GunaDataGridViewFamilleArticle.Rows.Count > 0 Then

            Dim NOM_FAMILLE As String = ""

            If GlobalVariable.typeFamilleOuSousFamille = "famille" Then
                If GlobalVariable.actualLanguageValue = 0 Then
                    NOM_FAMILLE = GunaDataGridViewFamilleArticle.CurrentRow.Cells("SALE POINT").Value.ToString
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    NOM_FAMILLE = GunaDataGridViewFamilleArticle.CurrentRow.Cells("POINT DE VENTE").Value.ToString
                End If
            ElseIf GlobalVariable.typeFamilleOuSousFamille = "sous famille" Then
                If GlobalVariable.actualLanguageValue = 0 Then
                    NOM_FAMILLE = GunaDataGridViewFamilleArticle.CurrentRow.Cells("FAMILY").Value.ToString
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    NOM_FAMILLE = GunaDataGridViewFamilleArticle.CurrentRow.Cells("FAMILLE").Value.ToString
                End If
            ElseIf GlobalVariable.typeFamilleOuSousFamille = "sous sous famille" Then
                If GlobalVariable.actualLanguageValue = 0 Then
                    NOM_FAMILLE = GunaDataGridViewFamilleArticle.CurrentRow.Cells("SUB FAMILY").Value.ToString
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    NOM_FAMILLE = GunaDataGridViewFamilleArticle.CurrentRow.Cells("SOUS FAMILLE").Value.ToString
                End If
            ElseIf GlobalVariable.typeFamilleOuSousFamille = "categorie" Then
                If GlobalVariable.actualLanguageValue = 0 Then
                    NOM_FAMILLE = GunaDataGridViewFamilleArticle.CurrentRow.Cells("CATEGORY").Value.ToString
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    NOM_FAMILLE = GunaDataGridViewFamilleArticle.CurrentRow.Cells("CATEGORIE").Value.ToString
                End If
            End If

            Dim dialog As DialogResult

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Dou you really want to delete " & NOM_FAMILLE
                languageTitle = "Delete"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Voulez-vous vraiment Supprimer " & NOM_FAMILLE
                languageTitle = "Suppression"
            End If

            dialog = MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else

                If GlobalVariable.typeFamilleOuSousFamille = "famille" Then
                    Functions.DeleteRowFromDataGridGeneral(GunaDataGridViewFamilleArticle, GunaDataGridViewFamilleArticle.CurrentRow.Cells("CODE").Value.ToString, "famille", "CODE_FAMILLE")
                ElseIf GlobalVariable.typeFamilleOuSousFamille = "sous famille" Then
                    Functions.DeleteRowFromDataGridGeneral(GunaDataGridViewFamilleArticle, GunaDataGridViewFamilleArticle.CurrentRow.Cells("CODE").Value.ToString, "sous_famille", "CODE_SOUS_FAMILLE")
                ElseIf GlobalVariable.typeFamilleOuSousFamille = "sous sous famille" Then
                    Functions.DeleteRowFromDataGridGeneral(GunaDataGridViewFamilleArticle, GunaDataGridViewFamilleArticle.CurrentRow.Cells("CODE").Value.ToString, "sous_sous_famille", "CODE_FAMILLE")
                ElseIf GlobalVariable.typeFamilleOuSousFamille = "categorie" Then
                    Functions.DeleteRowFromDataGridGeneral(GunaDataGridViewFamilleArticle, GunaDataGridViewFamilleArticle.CurrentRow.Cells("CODE").Value.ToString, "categorie_article", "CODE_FAMILLE")
                End If

                GunaDataGridViewFamilleArticle.Columns.Clear()

                familleOuSousFamilleListe()

                If GlobalVariable.actualLanguageValue = 0 Then
                    languageMessage = "Deleted successfully"
                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                    languageMessage = "Vous avez supprimé avec succès"
                End If

                MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Else

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Nothing to be deleted !"
                languageTitle = "Delete"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                languageMessage = "Aucune ligne à suprimer !"
                languageTitle = "Supression"
            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click
        familleOuSousFamilleListe()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        If TabControl1.SelectedIndex = 1 Then
            GunaDataGridViewFamilleArticle.Columns.Clear()
            GunaButtonEnregistrer.Visible = False
        Else
            GunaButtonEnregistrer.Visible = True

            If GunaButtonEnregistrer.Text = "Enregistrer" Or GunaButtonEnregistrer.Text = "Add" Then
                GunaComboBoxCategArticle.SelectedIndex = -1
            End If

        End If



    End Sub

    Private Sub GunaComboBoxFamilleArticle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxFamilleArticle.SelectedIndexChanged

        If GunaButtonEnregistrer.Text = "Sauvegarder" Or GunaButtonEnregistrer.Text = "Save" Then

            Dim CATEGORIE_DE_LA_FAMILLE As String = ""

            Dim FAMILLE As String = GunaComboBoxFamilleArticle.SelectedValue.ToString

            'ON RECEUPERE LA SOUS FAMILLE ACTUELLEMENT SELECTIONNEE PUIS ON DETERMINE SA CATEGORIE

            Dim infoFamille As DataTable = Functions.getElementByCode(FAMILLE, "sous_famille", "LIBELLE_SOUS_FAMILLE")

            If infoFamille.Rows.Count > 0 Then
                GunaComboBoxCategArticle.SelectedValue = infoFamille.Rows(0)("CODE_FAMILLE_PARENT")
            End If

        End If

    End Sub

    Private Sub GunaComboBoxCategArticle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxCategArticle.SelectedIndexChanged

        If GunaButtonEnregistrer.Text = "Enregistrer" Or GunaButtonEnregistrer.Text = "Add" Then

            If GunaComboBoxFamilleArticle.Visible Then

                If GunaComboBoxCategArticle.SelectedIndex >= 0 Then

                    Dim CATEGORIE As String = GunaComboBoxCategArticle.SelectedValue.ToString

                    'ON RECEUPERE LES FAMILLES DONT LA CATEGORIE EST ACTUELLEMENT SELECTIONNEE

                    Dim infoFamille As DataTable = Functions.getElementByCode(CATEGORIE, "sous_famille", "CODE_FAMILLE_PARENT")

                    If infoFamille.Rows.Count > 0 Then

                        GunaComboBoxFamilleArticle.DataSource = infoFamille
                        GunaComboBoxFamilleArticle.ValueMember = "LIBELLE_SOUS_FAMILLE"
                        GunaComboBoxFamilleArticle.DisplayMember = "LIBELLE_SOUS_FAMILLE"

                    Else
                        GunaComboBoxFamilleArticle.DataSource = Nothing
                    End If

                End If

            Else
                GunaComboBoxFamilleArticle.SelectedIndex = -1
            End If


        End If


    End Sub

End Class