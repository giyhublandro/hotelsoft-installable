Imports MySql.Data.MySqlClient

Public Class GestionDesDepensesForm

    Private Sub GunaImageButtonFermer_Click(sender As Object, e As EventArgs) Handles GunaImageButtonFermer.Click
        Me.Close()
        GrandeCaisseForm.TopMost = True
    End Sub

    Private Sub GestionDesDepensesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'CHARGEMENT DES DIFFERENTS ELEMENTS POUR ENREGISTREMENT DES DEPENSES CATEGORISEES

        If GlobalVariable.decaissemtnAssocie = "Bon commande" Then

            GunaTextBoxRefCompte.Visible = False
            GunaTextBoxiNTITUTLE.Visible = False
            GunaButtonAjouter.Visible = False

            GunaLabel4.Visible = False
            COMPTE.Visible = False

            Dim CODE_FACTURE As String = GrandeCaisseForm.GunaTextBoxCodeFacture.Text
            Dim CODE_AGENCE As String = GlobalVariable.codeAgence
            Dim infoRecette As DataTable = Functions.GetAllElementsOnTwoConditions(CODE_FACTURE, "transfert_recette", "CODE_FACTURE", CODE_AGENCE, "CODE_AGENCE")

            If infoRecette.Rows.Count > 0 Then

                If Not Trim(infoRecette.Rows(0)("NUMERO_TABLE")) = "" Then

                    Dim CODE_BORDEREAU As String = infoRecette.Rows(0)("NUMERO_TABLE")
                    Dim econom As New Economat()
                    'LA LIGNE DE TRANSFERT EST UN DECAISSEMENT ASSOCIE A UN BON DE COMMANDE

                    GunaDataGridViewCategorie.ColumnCount = 3

                    GunaDataGridViewCategorie.Columns(0).Name = "CODE"
                    GunaDataGridViewCategorie.Columns(1).Name = "LIBELLE"
                    GunaDataGridViewCategorie.Columns(2).Name = "MONTANT"
                    'GunaDataGridView1.Columns(3).Name = "INTITULE"

                    GunaDataGridViewCategorie.Rows.Clear()

                    Dim elementDuBordereau As DataTable = econom.ArticleDunBordereauQuelconque(CODE_BORDEREAU, "ligne_bordereaux")

                    'GunaDataGridView1.columns(0)()

                    For i = 0 To elementDuBordereau.Rows.Count - 1

                        'Dim CODE_BORDEREAUX As String = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("UNITE")
                        Dim DESIGNATION As String = elementDuBordereau.Rows(i)("DESIGNATION")
                        'Dim CODE_ARTICLE As String = econom.ArticleDunBordereauQuelconque(bordereau.Rows(0)("CODE_BORDEREAUX"), "ligne_bordereaux").Rows(i)("CODE ARTICLE")
                        Dim CODE As String = elementDuBordereau.Rows(i)("CODE ARTICLE")
                        'Dim QUANTITE As Double = elementDuBordereau.Rows(i)("QUANTITE")
                        Dim PRIX_ACHAT As Double = elementDuBordereau.Rows(i)("PRIX UNITAIRE")
                        Dim COUT_DU_STOCK As Double = elementDuBordereau.Rows(i)("PRIX TOTAL")
                        Dim UNITE As String = elementDuBordereau.Rows(i)("UNITE")

                        GunaDataGridViewCategorie.Rows.Add(CODE, DESIGNATION, Format(COUT_DU_STOCK, "#,##0"))

                    Next

                    GunaDataGridViewCategorie.Columns("CODE").Visible = False

                    Dim combo As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()

                    combo.HeaderText = "INTITULE"
                    combo.Name = "INTITULE"

                    Dim query11 As String = "SELECT INTITULE FROM `plan_comptable` WHERE COMPTE BETWEEN '100' AND '99999999' ORDER BY INTITULE ASC"
                    Dim command11 As New MySqlCommand(query11, GlobalVariable.connect)

                    Dim adapter11 As New MySqlDataAdapter(command11)

                    Dim Famille1 As New DataTable()
                    adapter11.Fill(Famille1)

                    For j = 0 To Famille1.Rows.Count - 1
                        combo.Items.Add(Famille1.Rows(j)("INTITULE"))
                    Next

                    GunaDataGridViewCategorie.Columns.Add(combo)

                End If

            End If

        Else

            GunaTextBoxRefCompte.Visible = True
            GunaTextBoxiNTITUTLE.Visible = True
            GunaButtonAjouter.Visible = True
            GunaLabel4.Visible = True
            COMPTE.Visible = True

        End If


    End Sub

    Private Sub GunaButtonEnregistrer_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click


        If GlobalVariable.categorisationDeDepense = "prevision" Then

        Else

            Dim depense As New Depense()

            Dim CODE_CATEGORY_DEPENSE As String = Functions.GeneratingRandomCodePanne("regroupement_depenses", "")
            Dim FAMILLE As String = ""
            Dim SOUS_FAMILLE As String = ""
            Dim CODE As String = ""
            Dim LIBELLE As String = ""
            Dim MONTANT As Double = 0
            Dim CODE_AGENCE As String = GlobalVariable.codeAgence

            If GlobalVariable.decaissemtnAssocie = "Bon commande" Then

                If GunaDataGridViewCategorie.Rows.Count > 0 Then

                    For i = 0 To GunaDataGridViewCategorie.Rows.Count - 1

                        CODE = GunaDataGridViewCategorie.Rows(i).Cells(0).Value.ToString

                        If Not Trim(CODE) = "" Then

                            FAMILLE = GunaDataGridViewCategorie.Rows(i).Cells("INTITULE").Value.ToString

                            Dim comptePlan As DataTable = Functions.getElementByCode(FAMILLE, "plan_comptable", "INTITULE")

                            If comptePlan.Rows.Count > 0 Then
                                SOUS_FAMILLE = comptePlan.Rows(0)("COMPTE")
                            End If

                            LIBELLE = GunaDataGridViewCategorie.Rows(i).Cells("LIBELLE").Value.ToString
                            MONTANT = GunaDataGridViewCategorie.Rows(i).Cells("MONTANT").Value

                            depense.insertCategorieDepense(CODE_CATEGORY_DEPENSE, FAMILLE, SOUS_FAMILLE, CODE, LIBELLE, MONTANT, CODE_AGENCE)

                        End If

                    Next

                End If

                GunaDataGridViewCategorie.Rows.Clear()

                GlobalVariable.decaissemtnAssocie = ""

            Else

                For i = 0 To GunaDataGridViewCategorie.Rows.Count - 1

                    CODE = GunaDataGridViewCategorie.Rows(i).Cells(0).Value.ToString

                    If Not Trim(CODE) = "" Then

                        FAMILLE = GunaDataGridViewCategorie.Rows(i).Cells("INTITULE").Value.ToString

                        Dim comptePlan As DataTable = Functions.getElementByCode(FAMILLE, "plan_comptable", "INTITULE")

                        If comptePlan.Rows.Count > 0 Then
                            SOUS_FAMILLE = comptePlan.Rows(0)("COMPTE")
                        End If

                        LIBELLE = GunaDataGridViewCategorie.Rows(i).Cells("LIBELLE").Value.ToString
                        MONTANT = GunaDataGridViewCategorie.Rows(i).Cells("MONTANT").Value

                        depense.insertCategorieDepense(CODE_CATEGORY_DEPENSE, FAMILLE, SOUS_FAMILLE, CODE, LIBELLE, MONTANT, CODE_AGENCE)

                    End If

                Next

            End If

            MessageBox.Show("Catégorisation enregistrée avec succès", "Gestion des dépenses", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

        Me.Close()

    End Sub

    Private Sub GunaButtonAjouter_Click(sender As Object, e As EventArgs) Handles GunaButtonAjouter.Click

        If Not Trim(GunaTextBoxRefCompte.Text).Equals("") Then

            If Not GunaDataGridViewCategorie.Rows.Count > 0 Then

                GunaDataGridViewCategorie.ColumnCount = 4
                GunaDataGridViewCategorie.Columns(0).Name = "CODE"
                'GunaDataGridViewCategorie.Columns(1).Name = "LIBELLE"
                GunaDataGridViewCategorie.Columns(1).Name = "COMPTE"
                GunaDataGridViewCategorie.Columns(2).Name = "INTITULE"
                GunaDataGridViewCategorie.Columns(3).Name = "MONTANT"

            End If

            Dim CODE As String = Functions.GeneratingRandomCodePanne("regroupement_depenses", "")
            Dim FAMILLE As String = GunaTextBoxRefCompte.Text
            Dim SOUS_FAMILLE As String = GunaTextBoxiNTITUTLE.Text

            If GlobalVariable.categorisationDeDepense = "prevision" Then

                GunaDataGridViewCategorie.Rows.Add(CODE, FAMILLE, SOUS_FAMILLE, 0)

            Else

                GunaDataGridViewCategorie.Columns.Clear()

                GunaDataGridViewCategorie.ColumnCount = 5
                GunaDataGridViewCategorie.Columns(0).Name = "CODE"
                GunaDataGridViewCategorie.Columns(1).Name = "LIBELLE"
                GunaDataGridViewCategorie.Columns(2).Name = "MONTANT"
                GunaDataGridViewCategorie.Columns(3).Name = "COMPTE"
                GunaDataGridViewCategorie.Columns(4).Name = "INTITULE"

                If SOUS_FAMILLE = "SALAIRES BRUTS" Then

                    Dim DESIGNATION As String = "Paiement des salaires bruts des employés [ " & GlobalVariable.DateDeTravail & " ] "
                    Dim SALAIRE As Double = 0

                    Dim employe As DataTable = Functions.allTableFields("personnel")

                    If employe.Rows.Count > 0 Then
                        For i = 0 To employe.Rows.Count - 1
                            SALAIRE += employe.Rows(i)("SALAIRE")
                        Next
                    End If

                    GunaDataGridViewCategorie.Rows.Add(CODE, DESIGNATION, Format(SALAIRE, "#,##0"), FAMILLE, SOUS_FAMILLE)

                    GrandeCaisseForm.GunaTextBoxReference.Text = DESIGNATION
                    GrandeCaisseForm.GunaTextBoxAPayer.Text = Format(SALAIRE, "#,##0")

                Else
                    GunaDataGridViewCategorie.Rows.Add(CODE, "", "", FAMILLE, SOUS_FAMILLE)
                End If

            End If

            GunaTextBoxRefCompte.Clear()
            GunaTextBoxiNTITUTLE.Clear()

        Else
            MessageBox.Show("Bien vouloir choisir un numéro de compte ", "Gestion des comptes", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub GunaTextBoxCompte_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxRefCompte.TextChanged

        If Trim(GunaTextBoxRefCompte.Text) = "" Then

            GunaTextBoxiNTITUTLE.Clear()
            GunaDataGridViewPlanComptable.Columns.Clear()
            GunaDataGridViewPlanComptable.Visible = False

        Else

            'REFRESHING information from database for instant visualisation 
            Dim query As String = "SELECT COMPTE, INTITULE FROM plan_comptable WHERE COMPTE LIKE '%" & Trim(GunaTextBoxRefCompte.Text) & "%' AND COMPTE BETWEEN '100' AND '9999999999' ORDER BY COMPTE ASC"
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            If (table.Rows.Count > 0) Then
                GunaDataGridViewPlanComptable.Visible = True
                GunaDataGridViewPlanComptable.DataSource = table
            Else
                'GunaDataGridViewPlanComptable.Columns.Clear()
                GunaDataGridViewPlanComptable.Visible = False
            End If

        End If

    End Sub

    Private Sub GunaDataGridViewPlanComptable_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GunaDataGridViewPlanComptable.CellClick

        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.GunaDataGridViewPlanComptable.Rows(e.RowIndex)

            GunaTextBoxRefCompte.Text = row.Cells("COMPTE").Value.ToString

            Dim comptePlan As DataTable = Functions.getElementByCode(GunaTextBoxRefCompte.Text, "plan_comptable", "COMPTE")

            If comptePlan.Rows.Count > 0 Then
                GunaTextBoxiNTITUTLE.Text = comptePlan.Rows(0)("INTITULE")
            End If

            GunaDataGridViewPlanComptable.Visible = False

        End If

    End Sub

    Private Sub GunaTextBoxiNTITUTLE_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxiNTITUTLE.TextChanged

        If Trim(GunaTextBoxiNTITUTLE.Text) = "" Then

            GunaDataGridViewPlanComptable.Columns.Clear()
            GunaDataGridViewPlanComptable.Visible = False

        Else

            'REFRESHING information from database for instant visualisation 
            'Dim query As String = "SELECT COMPTE, INTITULE FROM plan_comptable WHERE COMPTE LIKE '%" & Trim(GunaTextBoxRefCompte.Text) & "%' OR INTITULE LIKE '%" & Trim(GunaTextBoxRefCompte.Text) & "%' ORDER BY COMPTE ASC"
            Dim query As String = "SELECT COMPTE, INTITULE FROM plan_comptable WHERE INTITULE LIKE '%" & Trim(GunaTextBoxiNTITUTLE.Text) & "%' AND COMPTE BETWEEN '100' AND '9999999999' ORDER BY COMPTE ASC"
            Dim command As New MySqlCommand(query, GlobalVariable.connect)

            Dim adapter As New MySqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            If (table.Rows.Count > 0) Then
                GunaDataGridViewPlanComptable.Visible = True
                GunaDataGridViewPlanComptable.DataSource = table
            Else
                'GunaDataGridViewPlanComptable.Columns.Clear()
                GunaDataGridViewPlanComptable.Visible = False
            End If

        End If

    End Sub
End Class