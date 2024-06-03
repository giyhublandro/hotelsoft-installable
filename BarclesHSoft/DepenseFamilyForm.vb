Imports MySql.Data.MySqlClient

Public Class DepenseFamilyForm

    'Dim connect As New DataBaseManipulation()

    Private Sub ArticleFamilyForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()
        language.depenseFamily(GlobalVariable.actualLanguageValue)

        GunaDateTimePicker2.Value = Functions.firstDayOfMonth(GlobalVariable.DateDeTravail)
        GunaDateTimePicker3.Value = GlobalVariable.DateDeTravail

        If GlobalVariable.typeDeCompte = "exploitation" Then
            Functions.AffectingTitleToAForm("COMPTES D'EXPLOITATIONS", GunaLabelGestCompteGeneraux)
            GunaComboBoxNiveauCompte.Visible = True
            GunaLabel5.Visible = True
        ElseIf GlobalVariable.typeDeCompte = "comptable" Then
            Functions.AffectingTitleToAForm("PLAN COMPTABLE", GunaLabelGestCompteGeneraux)
            GunaComboBoxNiveauCompte.Visible = False
            GunaLabel5.Visible = False
            TabControl1.TabPages.Remove(TabPage2)
            TabControl1.TabPages.Remove(TabPage1)
        End If

        GunaComboBoxNiveauCompte.SelectedIndex = 0
        GunaComboBoxNatureCompte.SelectedIndex = 0
        TabControl1.SelectedIndex = 1

        GunaComboBoxModeReglement.SelectedIndex = 0

        SituationDeCaisse()

    End Sub

    Private Sub plan_comptable()

        Dim FillingListquery As String = ""

        If GlobalVariable.typeDeCompte = "exploitation" Then
            FillingListquery = "SELECT COMPTE, INTITULE FROM compte_exploitation ORDER BY COMPTE ASC"
        ElseIf GlobalVariable.typeDeCompte = "comptable" Then
            FillingListquery = "SELECT COMPTE, INTITULE FROM plan_comptable ORDER BY COMPTE ASC"
        End If

        Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)

        Dim adapterList As New MySqlDataAdapter(commandList)
        Dim tableList As New DataTable()

        adapterList.Fill(tableList)

        GunaDataGridViewPlanComptable.Columns.Clear()

        If tableList.Rows.Count > 0 Then
            GunaDataGridViewPlanComptable.DataSource = tableList
        End If

    End Sub

    Private Sub SupprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupprimerToolStripMenuItem.Click

        If GunaDataGridViewPlanComptable.Rows.Count > 0 Then

            Dim COMPTE As String = GunaDataGridViewPlanComptable.CurrentRow.Cells("COMPTE").Value.ToString

            Dim dialog As DialogResult
            dialog = MessageBox.Show("Voulez-vous vraiment Supprimer le compte " & COMPTE & " ?", "Demande de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.No Then
                'e.Cancel = True
            Else

                Functions.DeleteRowFromDataGridGeneral(GunaDataGridViewPlanComptable, GunaDataGridViewPlanComptable.CurrentRow.Cells("COMPTE").Value.ToString, "plan_comptable", "COMPTE")

                GunaDataGridViewPlanComptable.Columns.Clear()

                plan_comptable()

                MessageBox.Show("Vous avez supprimé avec succès", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Else
            MessageBox.Show("Aucune ligne à suprimer!", "Supression", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub GunaImageButton4_Click(sender As Object, e As EventArgs) Handles GunaImageButton4.Click
        Me.Close()
    End Sub

    Private Sub GunaButtonEnregistrer_Click_1(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Dim continuer As Boolean = True

        If Trim(GunaTextBoxIntitule.Text).Equals("") Or Trim(GunaTextBoxCompte.Text).Equals("") Then
            continuer = False
        End If

        If continuer Then

            Dim COMPTE As Integer = GunaTextBoxCompte.Text

            Dim COMPTE_PARENT As Integer = 0
            Dim NIVEAU_COMPTE As Integer = 0
            Dim NATURE_COMPTE As Integer = 0

            Dim RECURRENTE As Integer = 0

            If GunaCheckBoxPonctuelle.Checked Then
                RECURRENTE = 1
            End If

            Dim clear As Boolean = False

            If GunaComboBoxNiveauCompte.SelectedIndex >= 0 Then
                NIVEAU_COMPTE = GunaComboBoxNiveauCompte.SelectedIndex '[0=PARENTS; 1=SOUS PARENTS; 2=SOUS SOUS PARENTS]
            End If

            If GunaComboBoxNatureCompte.SelectedIndex >= 0 Then
                NATURE_COMPTE = GunaComboBoxNiveauCompte.SelectedIndex  '[0=CHIFFRES D'AFFAIRES; 1=DEPENSES; 2=ENCAISSEMENT]
            End If

            If Not Trim(GunaTextBoxCompteParent.Text).Equals("") Then
                If GunaComboBoxNiveauCompte.SelectedIndex = 1 Then
                    COMPTE_PARENT = GunaTextBoxCompteParent.Text
                End If
            End If

            Dim MONTANT_DEPENSE As Double = 0

            If Not Trim(GunaTextBoxMontant.Text).Equals("") Then
                MONTANT_DEPENSE = GunaTextBoxMontant.Text
            End If

            Dim OLD_COMPTE As Integer = 0

            If Not Trim(GunaTextBoxOldCompte.Text) = "" Then
                OLD_COMPTE = GunaTextBoxOldCompte.Text
            End If

            Dim INTITULE As String = GunaTextBoxIntitule.Text
            Dim tableName As String = "plan_comptable"

            If GlobalVariable.typeDeCompte = "exploitation" Then
                tableName = "compte_exploitation"
            End If

            If GunaButtonEnregistrer.Text = "Sauvegarder" Then

                Functions.DeleteElementByCode(OLD_COMPTE, tableName, "COMPTE")
                GunaButtonEnregistrer.Text = "Enregistrer"

                clear = True
            Else
                MessageBox.Show("Compte crée avec succès !!", "Gestion de Compte", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Dim account As New Compte()

            account.insertPlanComptable(INTITULE, COMPTE, NIVEAU_COMPTE, NATURE_COMPTE, RECURRENTE, COMPTE_PARENT, MONTANT_DEPENSE)

            If clear Then

                MessageBox.Show("Compte mise à jours avec succès !!", "Gestion de Compte", MessageBoxButtons.OK, MessageBoxIcon.Information)

                plan_comptable()

                TabControl1.SelectedIndex = 1
                GunaTextBoxCompteParent.Clear()
                GunaTextBoxIntituleCompteParent.Clear()

            End If

            GunaDataGridView4.Rows.Clear()
            GunaTextBoxCompte.Clear()
            GunaTextBoxIntitule.Clear()
            GunaTextBoxMontant.Text = 0

        End If

    End Sub

    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click
        GunaDataGridViewPlanComptable.Visible = True
        plan_comptable()
    End Sub

    Private Sub GunaDataGridViewPlanComptable_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewPlanComptable.CellDoubleClick

        If e.RowIndex >= 0 Then

            GunaButtonEnregistrer.Text = "Sauvegarder"

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewPlanComptable.Rows(e.RowIndex)

            GunaTextBoxOldCompte.Text = row.Cells("COMPTE").Value.ToString
            GunaTextBoxCompte.Text = row.Cells("COMPTE").Value.ToString
            GunaTextBoxIntitule.Text = row.Cells("INTITULE").Value.ToString

            If GlobalVariable.typeDeCompte = "exploitation" Then

                Dim infoCompte As DataTable = Functions.getElementByCode(GunaTextBoxOldCompte.Text, "compte_exploitation", "COMPTE")

                If infoCompte.Rows.Count > 0 Then

                    If Integer.Parse(infoCompte.Rows(0)("RECURRENTE")) = 1 Then
                        GunaCheckBoxPonctuelle.Checked = True
                    Else
                        GunaCheckBoxPonctuelle.Checked = False
                    End If

                    GunaTextBoxMontant.Text = Format(infoCompte.Rows(0)("MONTANT_DEPENSE"), "#,##0")

                    If Integer.Parse(infoCompte.Rows(0)("COMPTE_PARENT")) > 0 Then

                        Dim COMPTE_PARENT As Integer = Integer.Parse(infoCompte.Rows(0)("COMPTE_PARENT"))

                        infoCompte = Functions.getElementByCode(COMPTE_PARENT, "compte_exploitation", "COMPTE")

                        If infoCompte.Rows.Count > 0 Then
                            GunaTextBoxCompteParent.Text = COMPTE_PARENT
                            GunaTextBoxIntituleCompteParent.Text = infoCompte.Rows(0)("INTITULE")
                            GunaComboBoxNiveauCompte.Visible = True
                            GunaComboBoxNiveauCompte.SelectedIndex = 1
                            GunaLabel5.Visible = True
                            GunaPanel3.Visible = True
                        End If

                    Else
                        GunaComboBoxNiveauCompte.SelectedIndex = 0
                    End If

                    If infoCompte.Rows(0)("RECURRENTE") = 1 Then
                        GunaCheckBoxPonctuelle.Visible = True
                    Else
                        GunaCheckBoxPonctuelle.Visible = False
                    End If

                End If

                GunaDataGridView2.Visible = False
                GunaDataGridView3.Visible = False
                GunaDataGridViewIntitule.Visible = False

                GunaComboBoxNiveauCompte.Visible = True

            End If

            TabControl1.SelectedIndex = 0

        End If

    End Sub

    Private Sub GunaTextBoxRefArticleMatiere_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxRefCompte.TextChanged

        If GunaCheckBoxSearch.Checked Then

            If Trim(GunaTextBoxRefCompte.Text) = "" Then
                GunaDataGridViewPlanComptable.Columns.Clear()
                GunaDataGridViewPlanComptable.Visible = False
            Else

                GunaDataGridViewPlanComptable.Visible = True

                Dim tableName As String = ""
                If GlobalVariable.typeDeCompte = "comptable" Then
                    tableName = "plan_comptable"
                ElseIf GlobalVariable.typeDeCompte = "exploitation" Then
                    tableName = "compte_exploitation"
                End If

                'REFRESHING information from database for instant visualisation 
                Dim query As String = "SELECT COMPTE, INTITULE FROM " & tableName & " WHERE COMPTE LIKE '%" & Trim(GunaTextBoxRefCompte.Text) & "%' OR INTITULE LIKE '%" & Trim(GunaTextBoxRefCompte.Text) & "%' ORDER BY COMPTE ASC"
                Dim command As New MySqlCommand(query, GlobalVariable.connect)

                Dim adapter As New MySqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)

                If (table.Rows.Count > 0) Then
                    GunaDataGridViewPlanComptable.DataSource = table
                Else
                    GunaDataGridViewPlanComptable.Columns.Clear()
                End If

            End If

        Else
            GunaDataGridViewPlanComptable.Visible = True
        End If

    End Sub


    Private Sub GunaTextBoxIntitule_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxIntitule.TextChanged

        If GunaButtonEnregistrer.Text = "Enregistrer" And Trim(GunaTextBoxIntitule.Text).Equals("") Then
            GunaDataGridViewIntitule.Visible = False
        End If

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getArticleQuery As String = ""

        'Si l'article n'existe pas alors on efface toute les informations le concernant

        Dim tableName As String = ""

        If GlobalVariable.typeDeCompte = "exploitation" Then
            tableName = "compte_exploitation"
        Else
            tableName = "plan_comptable"
        End If

        getArticleQuery = "SELECT COMPTE, INTITULE FROM " & tableName & " WHERE INTITULE LIKE '%" & Trim(GunaTextBoxIntitule.Text) & "%' OR
        COMPTE LIKE '%" & Trim(GunaTextBoxIntitule.Text) & "%' ORDER BY INTITULE ASC"

        Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
        adapter.SelectCommand = Command
        adapter.Fill(table)

        If table.Rows.Count > 0 Then
            GunaDataGridViewIntitule.Visible = True
            GunaDataGridViewIntitule.DataSource = table
        Else
            GunaDataGridViewIntitule.Columns.Clear()
            GunaDataGridViewIntitule.Visible = False
        End If

        If Trim(GunaTextBoxIntitule.Text) = "" Then
            GunaDataGridViewIntitule.Visible = False
        End If

    End Sub

    Private Sub GunaComboBoxNiveauCompte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxNiveauCompte.SelectedIndexChanged

        If GunaComboBoxNiveauCompte.SelectedIndex = 0 Then
            GunaPanel3.Visible = False
        ElseIf GunaComboBoxNiveauCompte.SelectedIndex = 1 Then
            GunaPanel3.Visible = True
        ElseIf GunaComboBoxNiveauCompte.SelectedIndex = 1 Then
            GunaPanel3.Visible = True
        End If

    End Sub

    Private Sub GunaTextBoxIntituleCompteParent_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxIntituleCompteParent.TextChanged

        If Trim(GunaTextBoxIntituleCompteParent.Text).Equals("") Then
            GunaDataGridViewIntitule.Visible = False
            GunaTextBoxCompteParent.Clear()
        End If
        Dim NIVEAU_COMPTE As Integer = 0
        If GunaComboBoxNiveauCompte.SelectedIndex > 0 Then
            NIVEAU_COMPTE = GunaComboBoxNiveauCompte.SelectedIndex
            NIVEAU_COMPTE -= 1
        End If

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim compte As String = ""

        compte = "SELECT COMPTE, INTITULE FROM compte_exploitation WHERE INTITULE LIKE '%" & Trim(GunaTextBoxIntituleCompteParent.Text) & "%'
        OR COMPTE LIKE '%" & Trim(GunaTextBoxIntituleCompteParent.Text) & "%' AND COMPTE_PARENT = 0 AND NIVEAU_COMPTE = " & NIVEAU_COMPTE & " 
        ORDER BY INTITULE ASC"

        Dim Command As New MySqlCommand(compte, GlobalVariable.connect)
        adapter.SelectCommand = Command
        adapter.Fill(table)

        If table.Rows.Count > 0 Then
            GunaDataGridView2.Visible = True
            GunaDataGridView2.DataSource = table
        Else
            GunaDataGridView2.Columns.Clear()
            GunaDataGridView2.Visible = False
        End If

        If Trim(GunaTextBoxIntituleCompteParent.Text) = "" Then
            GunaDataGridView2.Visible = False
        End If

    End Sub

    Private Sub GunaDataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridView2.CellClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridView2.Rows(e.RowIndex)

            GunaTextBoxCompteParent.Text = row.Cells("COMPTE").Value.ToString
            GunaTextBoxIntituleCompteParent.Text = row.Cells("INTITULE").Value.ToString
            GunaDataGridView2.Visible = False

        End If

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        If TabControl1.SelectedIndex = 0 Then

            If GlobalVariable.typeDeCompte = "exploitation" Then

                If GunaButtonEnregistrer.Text = "Enregistrer" Then
                    GunaLabel5.Visible = True
                    GunaComboBoxNiveauCompte.Visible = True
                    GunaComboBoxNiveauCompte.SelectedIndex = 0
                End If

            Else

                GunaLabel5.Visible = False
                GunaComboBoxNiveauCompte.Visible = False
                GunaComboBoxNiveauCompte.SelectedIndex = 0

            End If

        End If

    End Sub

    Private Sub compteExploitation(ByVal dateDebut As Date, ByVal dateFin As Date)

        Dim FillingListquery As String = ""
        Dim FillingListquery_ As String = ""

        If GlobalVariable.typeDeCompte = "exploitation" Then

            FillingListquery_ = "SELECT DISTINCT `CODE_CATEGORY_DEPENSE`
            FROM regroupement_depenses WHERE DATE_DEPENSE >= '" & dateDebut.ToString("yyyy-MM-dd") & "' AND DATE_DEPENSE <= '" & dateFin.ToString("yyyy-MM-dd") & "'"

            Dim commandList_ As New MySqlCommand(FillingListquery_, GlobalVariable.connect)

            Dim adapterList_ As New MySqlDataAdapter(commandList_)
            Dim tableList_ As New DataTable()

            adapterList_.Fill(tableList_)

            Dim CODE As String = ""
            Dim INTITULE As String = ""
            Dim MONTANT As Double = 0

            If tableList_.Rows.Count > 0 Then

                GunaDataGridView1.Rows.Clear()

                For i = 0 To tableList_.Rows.Count - 1

                    MONTANT = 0

                    Dim COMPTE As String = tableList_.Rows(i)("CODE_CATEGORY_DEPENSE")

                    'FillingListquery = "SELECT `CODE`, `CODE_CATEGORY_DEPENSE` AS 'COMPTE', `FAMILLE` AS 'INTITULE', 
                    'SUM(regroupement_depenses.MONTANT) AS 'MONTANT'
                    'From regroupement_depenses, reglement WHERE regroupement_depenses.SOUS_FAMILLE = reglement.NUM_REGLEMENT AND CODE_CATEGORY_DEPENSE =@COMPTE
                    'And DATE_DEPENSE >= '" & dateDebut.ToString("yyyy-MM-dd") & "' AND DATE_DEPENSE <= '" & dateFin.ToString("yyyy-MM-dd") & "'
                    'ORDER BY regroupement_depenses.DATE_DEPENSE DESC"


                    FillingListquery = "SELECT `CODE`, `CODE_CATEGORY_DEPENSE` AS 'COMPTE', `FAMILLE` AS 'INTITULE', MONTANT
                    FROM regroupement_depenses WHERE DATE_DEPENSE >= '" & dateDebut.ToString("yyyy-MM-dd") & "' 
                    AND DATE_DEPENSE <= '" & dateFin.ToString("yyyy-MM-dd") & "' AND CODE_CATEGORY_DEPENSE = @COMPTE
                    ORDER BY regroupement_depenses.FAMILLE ASC"

                    Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)
                    commandList.Parameters.Add("@COMPTE", MySqlDbType.VarChar).Value = COMPTE
                    Dim adapterList As New MySqlDataAdapter(commandList)
                    Dim tableList As New DataTable()

                    adapterList.Fill(tableList)

                    If tableList.Rows.Count > 0 Then

                        CODE = tableList.Rows(0)("CODE")
                        INTITULE = tableList.Rows(0)("INTITULE")

                        For j = 0 To tableList.Rows.Count - 1
                            MONTANT += tableList.Rows(j)("MONTANT")
                        Next

                        GunaDataGridView1.Rows.Add(CODE, COMPTE, INTITULE, Format(MONTANT, "#,##0"))
                        GunaDataGridView1.Columns(0).Visible = False

                    End If

                Next

            Else
                GunaDataGridView1.Rows.Clear()
            End If

        Else

            FillingListquery = "Select COMPTE, INTITULE FROM plan_comptable ORDER BY COMPTE ASC"

            Dim commandList As New MySqlCommand(FillingListquery, GlobalVariable.connect)

            Dim adapterList As New MySqlDataAdapter(commandList)
            Dim tableList As New DataTable()

            adapterList.Fill(tableList)

            GunaDataGridView1.Columns.Clear()

            If tableList.Rows.Count > 0 Then
                GunaDataGridView1.DataSource = tableList
                GunaDataGridView1.Columns(0).Visible = False
            Else
                GunaDataGridView1.DataSource = Nothing
            End If

        End If

    End Sub


    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click
        Dim dateDebut As Date = GunaDateTimePicker2.Value.ToShortDateString
        Dim dateFin As Date = GunaDateTimePicker3.Value.ToShortDateString
        compteExploitation(dateDebut, dateFin)
    End Sub

    Private Sub GunaComboBoxNatureCompte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxNatureCompte.SelectedIndexChanged

        GunaComboBoxCritereEvalue.Items.Clear()

        If GunaComboBoxNatureCompte.SelectedIndex = 1 Then
            'ENTREES
            GunaPanel4.Visible = True
            GunaCheckBoxPonctuelle.Checked = False
            GunaCheckBoxPonctuelle.Visible = False

            If GlobalVariable.actualLanguageValue = 1 Then ' FRENCH

                GunaComboBoxCritereEvalue.Items.Add("AUTRES")
                GunaComboBoxCritereEvalue.Items.Add("BAR")
                GunaComboBoxCritereEvalue.Items.Add("DINNER")
                GunaComboBoxCritereEvalue.Items.Add("DEJEUNER")
                GunaComboBoxCritereEvalue.Items.Add("HEBERGEMENT")
                GunaComboBoxCritereEvalue.Items.Add("LOCATION")
                GunaComboBoxCritereEvalue.Items.Add("PETIT DEJEUNER")
                GunaComboBoxCritereEvalue.Items.Add("RESTAURANT")
                GunaComboBoxCritereEvalue.Items.Add("TAXE DE SEJOURS")

            ElseIf GlobalVariable.actualLanguageValue = 0 Then 'ENGLISH

                GunaComboBoxCritereEvalue.Items.Add("ACCOMMODATION")
                GunaComboBoxCritereEvalue.Items.Add("BAR")
                GunaComboBoxCritereEvalue.Items.Add("BREAK FAST")
                GunaComboBoxCritereEvalue.Items.Add("DINNER")
                GunaComboBoxCritereEvalue.Items.Add("LUNCH")
                GunaComboBoxCritereEvalue.Items.Add("LOCATION")
                GunaComboBoxCritereEvalue.Items.Add("MISCELLANEAOUS")
                GunaComboBoxCritereEvalue.Items.Add("RESTAURANT")
                GunaComboBoxCritereEvalue.Items.Add("TOURIST TAX")

            End If

            GunaComboBoxCritereEvalue.SelectedIndex = 0

        ElseIf GunaComboBoxNatureCompte.SelectedIndex = 0 Then
            'SORTIES
            GunaPanel4.Visible = False
            GunaCheckBoxPonctuelle.Visible = True

        End If

    End Sub


    Private Sub GunaTextBoxCompte_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxCompte.TextChanged

        If GunaButtonEnregistrer.Text = "Enregistrer" And Trim(GunaTextBoxCompte.Text).Equals("") Then
            GunaDataGridView3.Visible = False
        End If

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getArticleQuery As String = ""

        'Si l'article n'existe pas alors on efface toute les informations le concernant

        Dim tableName As String = ""

        If GlobalVariable.typeDeCompte = "exploitation" Then
            tableName = "compte_exploitation"
        Else
            tableName = "plan_comptable"
        End If

        getArticleQuery = "Select COMPTE FROM " & tableName & " WHERE INTITULE Like '%" & Trim(GunaTextBoxCompte.Text) & "%' OR
        COMPTE LIKE '%" & Trim(GunaTextBoxCompte.Text) & "%' ORDER BY INTITULE ASC"

        Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
        adapter.SelectCommand = Command
        adapter.Fill(table)

        If table.Rows.Count > 0 Then
            GunaDataGridView3.Visible = True
            GunaDataGridView3.DataSource = table
        Else
            GunaDataGridView3.Columns.Clear()
            GunaDataGridView3.Visible = False
        End If

        If Trim(GunaTextBoxCompte.Text) = "" Then
            GunaDataGridView3.Visible = False
        End If

    End Sub

    Private Sub listeDesDepensesRecurrentes()

        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim getArticleQuery As String = ""

        'Si l'article n'existe pas alors on efface toute les informations le concernant

        Dim tableName As String = ""

        If GlobalVariable.typeDeCompte = "exploitation" Then
            tableName = "compte_exploitation"
        Else
            tableName = "plan_comptable"
        End If

        getArticleQuery = "SELECT COMPTE, INTITULE, MONTANT_DEPENSE FROM " & tableName & " WHERE RECURRENTE = 1 ORDER BY INTITULE ASC"

        Dim Command As New MySqlCommand(getArticleQuery, GlobalVariable.connect)
        adapter.SelectCommand = Command
        adapter.Fill(table)

        GunaDataGridView4.Rows.Clear()

        Dim MONTANT_DEPENSE As Double = 0
        Dim INTITULE As String = ""
        Dim COMPTE As String = ""

        If table.Rows.Count > 0 Then

            For i = 0 To table.Rows.Count - 1
                MONTANT_DEPENSE = table.Rows(i)(2)
                INTITULE = table.Rows(i)(1)
                COMPTE = table.Rows(i)(0)
                GunaDataGridView4.Rows.Add(COMPTE, INTITULE, MONTANT_DEPENSE)
            Next

            GunaDataGridView4.Columns(2).DefaultCellStyle.Format = "#,##0"

        Else
            GunaDataGridView4.Rows.Clear()
        End If

    End Sub

    Private Sub GunaButton6_Click(sender As Object, e As EventArgs) Handles GunaButton6.Click
        listeDesDepensesRecurrentes()
    End Sub

    Private Sub GunaCheckBoxPonctuelle_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxPonctuelle.CheckedChanged

        If GunaCheckBoxPonctuelle.Checked Then
            GunaTextBoxMontant.Visible = True
            GunaLabel12.Visible = True
        Else
            GunaTextBoxMontant.Visible = False
            GunaLabel12.Visible = False
        End If

    End Sub

    Private Sub GunaButton5_Click(sender As Object, e As EventArgs) Handles GunaButton5.Click

        If GunaDataGridView4.Rows.Count > 0 Then

            Dim CODE_CATEGORY_DEPENSE As String = ""
            Dim FAMILLE As String = ""
            Dim SOUS_FAMILLE As String = ""
            Dim CODE As String = ""
            Dim LIBELLE As String = ""
            Dim CODE_AGENCE As String = GlobalVariable.AgenceActuelle.Rows(0)("CODE_AGENCE")
            Dim MONTANT As Double = 0

            Dim NUM_REGLEMENT As String = ""

            Dim NUM_FACTURE = "" 'CODE DE LA FACTURE EN COURS DE REGLEMENT

            Dim CODE_CAISSIER = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

            Dim DATE_REGLEMENT = GlobalVariable.DateDeTravail
            Dim MODE_REGLEMENT = GunaComboBoxModeReglement.SelectedItem
            Dim MODE_REGLEMENT_INDEX As Integer = GunaComboBoxModeReglement.SelectedIndex
            Dim REF_REGLEMENT = ""
            Dim CODE_MODE = ""
            Dim IMPRIMER = 3
            Dim ETAT = 3

            Dim CODE_RESERVATION As String = ""
            Dim CODE_CLIENT As String = ""
            Dim NUMERO_BLOC_NOTE As String = "SORTIE DE FONDS"

            If GlobalVariable.actualLanguageValue = 0 Then
                NUMERO_BLOC_NOTE = "CASH OUTFLOW"
            End If

            Dim MODE_REG_INFO_SUP_1 As String = ""
            Dim MODE_REG_INFO_SUP_2 As String = ""
            Dim MODE_REG_INFO_SUP_3 As Date = GlobalVariable.DateDeTravail
            Dim DATE_DEPENSE As Date = GlobalVariable.DateDeTravail

            Dim SOLDE_EN_CAISSE As Double = 0
            Dim COCHER
            Dim depense As New Depense()
            Dim reglement As New Reglement()

            Dim message As Boolean = False

            For i = 0 To GunaDataGridView4.Rows.Count - 1

                SOLDE_EN_CAISSE = LabelSituationCaisse.Text
                CODE_CATEGORY_DEPENSE = GunaDataGridView4.Rows(i).Cells(0).Value.ToString 'COMPTE
                MONTANT = GunaDataGridView4.Rows(i).Cells(2).Value
                COCHER = GunaDataGridView4.Rows(i).Cells(3).Value
                NUM_REGLEMENT = Functions.GeneratingRandomCode("reglement", "")

                If COCHER Then

                    If SOLDE_EN_CAISSE >= MONTANT Then

                        FAMILLE = GunaDataGridView4.Rows(i).Cells(1).Value.ToString 'INTITULE COMPTE EXPLOITATION

                        If GlobalVariable.actualLanguageValue = 0 Then
                            REF_REGLEMENT = "CASH OUTLOW " & FAMILLE & " [ " & GunaComboBoxModeReglement.SelectedItem & " ]" & " " & GlobalVariable.DateDeTravail
                        Else
                            REF_REGLEMENT = "SORTIE DE FONDS " & FAMILLE & " [ " & GunaComboBoxModeReglement.SelectedItem & " ]" & " " & GlobalVariable.DateDeTravail
                        End If

                        reglement.insertReglement(NUM_REGLEMENT, NUM_FACTURE, CODE_CAISSIER, MONTANT * -1, DATE_REGLEMENT, MODE_REGLEMENT, REF_REGLEMENT, CODE_MODE, IMPRIMER, CODE_AGENCE, CODE_RESERVATION, CODE_CLIENT, NUMERO_BLOC_NOTE, MODE_REG_INFO_SUP_1, MODE_REG_INFO_SUP_2, MODE_REG_INFO_SUP_3)

                        SOUS_FAMILLE = NUM_REGLEMENT 'CODE DEPENSE
                        CODE = Functions.GeneratingRandomCodePanne("regroupement_depenses", "")
                        LIBELLE = REF_REGLEMENT

                        depense.insertCategorieDepense(CODE_CATEGORY_DEPENSE, FAMILLE, SOUS_FAMILLE, CODE, LIBELLE, MONTANT, CODE_AGENCE, DATE_DEPENSE)

                        Functions.updateOfFields("reglement", "ETAT", ETAT, "NUM_REGLEMENT", NUM_REGLEMENT, 1)

                        message = True

                        SituationDeCaisse()

                    Else
                        Exit For
                    End If

                End If

            Next

            If message Then
                If GlobalVariable.actualLanguageValue = 0 Then
                    MessageBox.Show("Cas out flow successfully saved ", "Exploitation Account", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Dépense enregistrées avec succès ", "Compte d'exploitation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If

        End If

    End Sub

    Public Sub SituationDeCaisse()

        Dim CODE_CAISSIER_PRINCIPALE As String = ""
        Dim CODE_CAISSIER_CONNECTED As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim TYPE_CAISSE As String = "Caisse principale"

        Dim infoCaisse As DataTable = Functions.getElementByCode(TYPE_CAISSE, "caisse", "TYPE_CAISSE")

        If infoCaisse.Rows.Count = 1 Then
            CODE_CAISSIER_PRINCIPALE = infoCaisse.Rows(0)("CODE_UTILISATEUR")
        End If

        Dim getUserQuery As String = ""

        If GlobalVariable.DroitAccesDeUtilisateurConnect.Rows(0)("CAISSE_PRINCIPALE_ECRITURE") = 0 Then
            'LECTURE SEULE
            'getUserQuery = "SELECT * FROM reglement WHERE IMPRIMER=@IMPRIMER AND CODE_CAISSIER=@CODE_CAISSIER AND MODE_REGLEMENT= @MODE_REGLEMENT  ORDER BY ID_REGLEMENT DESC"
            getUserQuery = "SELECT * FROM reglement WHERE IMPRIMER=@IMPRIMER AND MODE_REGLEMENT= @MODE_REGLEMENT  ORDER BY ID_REGLEMENT DESC"

        Else
            'LECTURE ET ECRITURE
            getUserQuery = "SELECT * FROM reglement WHERE IMPRIMER=@IMPRIMER AND CODE_CAISSIER = @CODE_CAISSIER_CONNECTED AND MODE_REGLEMENT= @MODE_REGLEMENT ORDER BY ID_REGLEMENT DESC"
        End If

        Dim command As New MySqlCommand(getUserQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_CAISSIER", MySqlDbType.VarChar).Value = CODE_CAISSIER_PRINCIPALE
        command.Parameters.Add("@CODE_CAISSIER_CONNECTED", MySqlDbType.VarChar).Value = CODE_CAISSIER_CONNECTED
        command.Parameters.Add("@MODE_REGLEMENT", MySqlDbType.VarChar).Value = "Cash"
        command.Parameters.Add("@IMPRIMER", MySqlDbType.Int64).Value = 3

        Dim adapter As New MySqlDataAdapter

        Dim dt As New DataTable()
        'Dim command As New MySqlCommand(query, GlobalVariable.connect)

        adapter.SelectCommand = command
        adapter.Fill(dt)

        'Dim SituationDeCaisse As DataTable = Functions.SituationDeCaisse(GlobalVariable.DateDeTravail)
        Dim SituationDeCaisse As DataTable = dt

        Dim TotalFacture As Double = 0
        Dim SortieDeFonds As Double = 0

        If SituationDeCaisse.Rows.Count > 0 Then
            'On selection l'ensemble des reglements d'un jour donné
            For i = 0 To SituationDeCaisse.Rows.Count - 1

                'ON CALCUL LES SORTIES DE FONDS
                If SituationDeCaisse.Rows(i)("MONTANT_VERSE") < 0 Then
                    SortieDeFonds += SituationDeCaisse.Rows(i)("MONTANT_VERSE")
                ElseIf SituationDeCaisse.Rows(i)("MONTANT_VERSE") >= 0 Then
                    TotalFacture += SituationDeCaisse.Rows(i)("MONTANT_VERSE")
                End If

            Next

            Dim situationDeCaisseReelle As Double = 0

            If TotalFacture + SortieDeFonds > 0 Then
                situationDeCaisseReelle = TotalFacture + SortieDeFonds
            End If

            LabelSituationCaisse.Text = Format(situationDeCaisseReelle, "#,##0")
            'LabelSortiesDeFonds.Text = Format(SortieDeFonds * -1, "#,##0")

        Else
            LabelSituationCaisse.Text = 0
            'LabelSortiesDeFonds.Text = 0
        End If

    End Sub

End Class