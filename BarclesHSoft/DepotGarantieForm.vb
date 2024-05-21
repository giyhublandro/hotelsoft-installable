Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Net
Imports System.IO

Imports System.ComponentModel

'-------------------------------
Imports System
Imports System.Text
Imports System.Web

Public Class DepotGarantieForm

    Private Sub GunaImageButton5_Click(sender As Object, e As EventArgs) Handles GunaImageButton5.Click
        Me.Close()
    End Sub

    Public Sub listeDesCautionsArrange(ByVal i As Integer, ByVal n As Integer)

        GunaDataGridView1.Columns.Clear()

        If i = 0 Then
            GunaDataGridView1.DataSource = listeDesDepots(n)
        Else
            GunaDataGridView1.DataSource = listeDesDepotsSearch(n, GunaTextBoxReference.Text)
        End If

        If GunaDataGridView1.Rows.Count > 0 Then

            GunaDataGridView1.DefaultCellStyle.SelectionBackColor = Color.BlueViolet
            GunaDataGridView1.DefaultCellStyle.SelectionForeColor = Color.White

            GunaDataGridView1.Columns("DEBIT").DefaultCellStyle.Format = "#,##0"
            GunaDataGridView1.Columns("CREDIT").DefaultCellStyle.Format = "#,##0"

            GunaDataGridView1.Columns("DEBIT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridView1.Columns("CREDIT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridView1.Columns("SOLDE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            GunaDataGridView1.Columns("SOLDE").DefaultCellStyle.Format = "#,##0"

            If n = 0 Then
                GunaDataGridView1.Columns("MONTANT ACCORDE").DefaultCellStyle.Format = "#,##0"
                GunaDataGridView1.Columns("MONTANT ACCORDE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

            Dim CreditTotal As Double = 0
            Dim DebitTotal As Double = 0
            Dim SoldeTotal As Double = 0

            For i = 0 To GunaDataGridView1.Rows.Count - 1
                CreditTotal += GunaDataGridView1.Rows(i).Cells("CREDIT").Value
                DebitTotal += GunaDataGridView1.Rows(i).Cells("DEBIT").Value
                SoldeTotal += GunaDataGridView1.Rows(i).Cells("SOLDE").Value
            Next

            GunaTextBoxDebit.Text = Format(DebitTotal, "#,##0")
            GunaTextBoxCredit.Text = Format(CreditTotal, "#,##0")
            GunaTextBoxSolde.Text = Format(SoldeTotal, "#,##0")

        Else
            GunaTextBoxDebit.Text = Format(0, "#,##0")
            GunaTextBoxCredit.Text = Format(0, "#,##0")
            GunaTextBoxSolde.Text = Format(0, "#,##0")
        End If

    End Sub


    Private Function listeDesDepots(ByVal n As Integer) As DataTable

        Dim table As New DataTable()
        Dim table1 As New DataTable()

        Dim query As String = ""
        Dim query1 As String = ""

        If n = 0 Then

            query = "SELECT CODE_CAUTION AS REFERENCE, ETAT_DEPOT AS ETAT, PAR, reservation.NOM_CLIENT As 'CLIENT', DEBIT, CREDIT, SOLDE, CHAMBRE_ID AS 'CODE', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE',
            MONTANT_ACCORDE AS 'MONTANT ACCORDE', reservation.CODE_RESERVATION AS 'RESERVATION'
            FROM reservation, caution WHERE reservation.CODE_RESERVATION=caution.CODE_RESERVATION AND caution.TYPE=1 ORDER BY ID_RESERVATION DESC"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            'command.Parameters.Add("@ETAT_RESERVATION", MySqlDbType.Int32).Value = 0

            Dim adapter As New MySqlDataAdapter(command)

            adapter.Fill(table)

            query1 = "SELECT CODE_CAUTION AS REFERENCE , ETAT_DEPOT AS ETAT, PAR, reserve_conf.NOM_CLIENT As 'CLIENT', DEBIT, CREDIT, SOLDE, CHAMBRE_ID AS 'CODE', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', 
            MONTANT_ACCORDE AS 'MONTANT ACCORDE', reserve_conf.CODE_RESERVATION AS 'RESERVATION'
            FROM reserve_conf, caution WHERE reserve_conf.CODE_RESERVATION=caution.CODE_RESERVATION AND caution.TYPE=1 ORDER BY ID_RESERVATION DESC"

            Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)

            Dim adapter1 As New MySqlDataAdapter(command1)

            adapter1.Fill(table1)

            table.Merge(table1)

            Return table

        Else

            query = "SELECT CODE_CAUTION AS REFERENCE, ETAT_DEPOT AS ETAT, PAR, NOM_CLIENT As 'CLIENT' ,DEBIT, CREDIT, SOLDE,CODE_RESERVATION AS 'CODE CLIENT', caution.DATE_CREATION As 'DATE ENCAISSEMENT'
            FROM caution WHERE caution.TYPE=1 AND CODE_RESERVATION IN ('') ORDER BY caution.DATE_CREATION DESC"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            'command.Parameters.Add("@ETAT_RESERVATION", MySqlDbType.Int32).Value = 0

            Dim adapter As New MySqlDataAdapter(command)

            adapter.Fill(table)

            Return table

        End If

    End Function


    Private Sub DepotGarantieForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GunaComboBoxTypeDepot.SelectedIndex = 0

        Dim n As Integer = GunaComboBoxTypeDepot.SelectedIndex
        listeDesCautionsArrange(0, n)

        If GlobalVariable.actualLanguageValue = 0 Then
            GunaButtonEnregistrer.Text = "Save"
        End If

        totalDesDepotDeGarantie()

    End Sub

    Private Function listeDesDepotsSearch(ByVal n As Integer, ByVal reference As String) As DataTable

        Dim table As New DataTable()
        Dim table1 As New DataTable()

        Dim query As String = ""
        Dim query1 As String = ""

        If n = 0 Then

            query = "SELECT CODE_CAUTION AS REFERENCE, ETAT_DEPOT AS ETAT, PAR, caution.NOM_CLIENT As 'NOM CLIENT', DEBIT, CREDIT, SOLDE, CHAMBRE_ID AS 'CODE', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE',
            MONTANT_ACCORDE AS 'MONTANT ACCORDE', reservation.CODE_RESERVATION AS 'RESERVATION' FROM reservation, caution WHERE reservation.CODE_RESERVATION=caution.CODE_RESERVATION AND caution.TYPE=1  
            AND CODE_CAUTION LIKE '%" & reference & "%' ORDER BY CODE_CAUTION DESC"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            'command.Parameters.Add("@ETAT_RESERVATION", MySqlDbType.Int32).Value = 0

            Dim adapter As New MySqlDataAdapter(command)

            adapter.Fill(table)

            query1 = "SELECT CODE_CAUTION AS REFERENCE, ETAT_DEPOT AS ETAT, PAR, caution.NOM_CLIENT As 'NOM CLIENT', DEBIT, CREDIT, SOLDE, CHAMBRE_ID AS 'CODE', DATE_ENTTRE As 'DATE ENTREE', DATE_SORTIE As 'DATE SORTIE', 
            MONTANT_ACCORDE AS 'MONTANT ACCORDE', reserve_conf.CODE_RESERVATION AS 'RESERVATION' FROM reserve_conf, caution WHERE reserve_conf.CODE_RESERVATION=caution.CODE_RESERVATION AND caution.TYPE=1 
            AND CODE_CAUTION LIKE '%" & reference & "%' ORDER BY CODE_CAUTION DESC"

            Dim command1 As New MySqlCommand(query1, GlobalVariable.connect)

            Dim adapter1 As New MySqlDataAdapter(command1)

            adapter1.Fill(table1)

            table.Merge(table1)

            Return table

        Else

            query = "SELECT CODE_CAUTION AS REFERENCE, ETAT_DEPOT AS ETAT, PAR , NOM_CLIENT As 'CLIENT' , DEBIT, CREDIT, SOLDE, CODE_RESERVATION AS 'CODE CLIENT', caution.DATE_CREATION As 'DATE ENCAISSEMENT'
            FROM caution WHERE caution.TYPE=1 AND CODE_CAUTION LIKE '%" & reference & "%' AND  CODE_RESERVATION IN ('')
            ORDER BY caution.DATE_CREATION DESC"

            Dim command As New MySqlCommand(query, GlobalVariable.connect)
            'command.Parameters.Add("@ETAT_RESERVATION", MySqlDbType.Int32).Value = 0

            Dim adapter As New MySqlDataAdapter(command)

            adapter.Fill(table)

            Return table

        End If

    End Function

    Private Sub GunaTextBoxReference_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxReference.TextChanged

        Dim n As Integer = GunaComboBoxTypeDepot.SelectedIndex

        If Trim(GunaTextBoxReference.Text).Equals("") Then
            listeDesCautionsArrange(0, n)
        Else
            listeDesCautionsArrange(1, n)
        End If

    End Sub

    Private Sub DétailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DétailsToolStripMenuItem.Click

        If GunaDataGridView1.Rows.Count > 0 Then

            Dim continuer As Boolean = False

            For Each row As DataGridViewRow In GunaDataGridView1.SelectedRows

                Dim DEPOT As Double = row.Cells("SOLDE").Value

                If DEPOT > 0 Then

                    Dim REFERENCE As String = row.Cells("REFERENCE").Value.ToString

                    Dim CODE_RESERVATION As String = ""

                    If GunaComboBoxTypeDepot.SelectedIndex = 0 Then

                        CODE_RESERVATION = row.Cells("RESERVATION").Value.ToString
                        Dim infoSupResa As DataTable = Functions.getElementByCode(CODE_RESERVATION, "reservation", "CODE_RESERVATION")

                        If Not infoSupResa.Rows.Count > 0 Then

                            infoSupResa = Functions.getElementByCode(CODE_RESERVATION, "reserve_conf", "CODE_RESERVATION")

                            If infoSupResa.Rows.Count > 0 Then

                                If GlobalVariable.codeReservationToUpdate = CODE_RESERVATION Then
                                    continuer = True
                                End If

                            End If

                        Else
                            If GlobalVariable.codeReservationToUpdate = CODE_RESERVATION Then
                                continuer = True
                            End If
                        End If

                    Else

                        Dim CODE_CLIENT As String = row.Cells("CODE CLIENT").Value.ToString

                        continuer = True

                    End If

                    If continuer Then
                        ReglementForm.GunaTextBoxMontantVerse.Text = Format(DEPOT, "#,##0")
                        ReglementForm.GunaTextBoxCodeDepot.Text = REFERENCE
                        ReglementForm.GunaTextBoxMontantDepot.Text = DEPOT
                    End If

                Else
                    MessageBox.Show("Ce Dépot de Garantie a déjà été utilisé ", "Garantie", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Next

            If continuer Then
                Me.Close()
            End If

        End If

    End Sub

    Private Sub RembourserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RembourserToolStripMenuItem.Click


        If GunaDataGridView1.Rows.Count > 0 Then

            For Each row As DataGridViewRow In GunaDataGridView1.SelectedRows

                Dim CODE_CAUTION As String = row.Cells("REFERENCE").Value.ToString

                If True Then

                    CautionRemboursement.GunaTextBoxCaution.Text = Format(row.Cells("SOLDE").Value, "#,##0")
                    'CautionRemboursement.GunaTextBoxMotifDifference.Text = row.Cells("RAISON").Value.ToString
                    CautionRemboursement.GunaTextBoxMontantARembourser.Text = Format(row.Cells("DEBIT").Value, "#,##0")
                    CautionRemboursement.GunaTextBoxCodeCaution.Text = CODE_CAUTION

                    CautionRemboursement.Show()
                    'MainWindow.cautionEnregistrement(CODE_RESERVATION, 0, GunaTextBoxMontantCaution.Text)

                Else

                    CautionRemboursement.GunaTextBoxCaution.Text = Format(row.Cells("SOLDE").Value, "#,##0")
                    'CautionRemboursement.GunaTextBoxMotifDifference.Text = row.Cells("RAISON").Value.ToString
                    CautionRemboursement.GunaTextBoxMontantARembourser.Text = Format(row.Cells("DEBIT").Value, "#,##0")
                    CautionRemboursement.GunaTextBoxCodeCaution.Text = CODE_CAUTION

                    CautionRemboursement.Show()
                    'MainWindow.cautionEnregistrement(CODE_RESERVATION, 0, GunaTextBoxMontantCaution.Text)

                End If

            Next

        End If


    End Sub

    Private Sub GunaButtonEnregistrerFiscValue_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        GunaComboBoxTypeDepot.SelectedIndex = 1

        If Trim(GunaTextBoxMontantDepot.Text) = "" Then
            GunaTextBoxMontantDepot.Text = 0
        End If

        'LE CODE N'EXISTE PAS ALORS ON INSERE
        Dim ETAT_DEPOT As String = "Disponible"
        Dim resa As New Reservation()

        Dim CODE_CAUTION As String = Functions.GeneratingRandomCodePanne("caution", "DG")
        Dim CODE_RESERVATION_CLIENT As String = GunaTextBoxCodeClientCarte.Text
        Dim DATE_CREATION As Date = GlobalVariable.DateDeTravail
        Dim DEBIT As Double = 0
        Dim CREDIT As Double = GunaTextBoxMontantDepot.Text
        Dim TYPE As Integer = 1
        Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim NOM_CLIENT As String = GunaTextBoxNomClientCarte.Text

        resa.insertionCaution(CODE_CAUTION, CODE_RESERVATION_CLIENT, DEBIT, CREDIT, DATE_CREATION, CODE_UTILISATEUR_CREA, TYPE, ETAT_DEPOT, NOM_CLIENT)

        If GlobalVariable.actualLanguageValue = 1 Then
            MessageBox.Show("Dépot de Garantie enregistré avec succès ", "Garantie", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else

        End If

        Dim n As Integer = GunaComboBoxTypeDepot.SelectedIndex

        listeDesCautionsArrange(0, n)

        Dim codeReservation As String = ""
        Dim dt As DataGridView

        Dim dialog As DialogResult

        If GlobalVariable.actualLanguageValue = 1 Then
            dialog = MessageBox.Show("Voulez-vous Imprimer Le reçu ", "Impression de reçu", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Else
            dialog = MessageBox.Show("Do you want to print the receipt ", "Receipt printing", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        End If

        If dialog = DialogResult.Yes Then
            Functions.DocumentToPrintComptoire("", "reglement", "NUM_REGLEMENT", GunaTextBoxNomClientCarte.Text, dt, CODE_RESERVATION_CLIENT, CODE_CAUTION, CREDIT)
        End If

        GunaTextBoxNomClientCarte.Text = ""
        GunaTextBoxMontantDepot.Text = ""
        totalDesDepotDeGarantie()

    End Sub

    Private Sub GunaComboBoxTypeDepot_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxTypeDepot.SelectedIndexChanged

        Dim n As Integer = GunaComboBoxTypeDepot.SelectedIndex
        listeDesCautionsArrange(0, n)

    End Sub

    Private Sub GunaTextBoxMontantDepot_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxMontantDepot.TextChanged

        If Not Trim(GunaTextBoxMontantDepot.Text).Equals("") Then

            Dim montantDepot As Double = GunaTextBoxMontantDepot.Text
            If montantDepot > 0 Then
                GunaButtonEnregistrer.Visible = True
            Else
                GunaButtonEnregistrer.Visible = False
            End If

        Else
            GunaButtonEnregistrer.Visible = False
        End If

    End Sub

    Private Sub ImprimerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimerToolStripMenuItem.Click
        'IMPRESSION DES DEPOT DE GARANTIES

        For Each row As DataGridViewRow In GunaDataGridView1.SelectedRows
            Dim CODE_CAUTION As String = row.Cells("REFERENCE").Value.ToString
            Dim CREDIT As String = row.Cells("CREDIT").Value
            Dim CODE_RESERVATION_CLIENT As String = row.Cells("CLIENT").Value
            Dim dt As DataGridView
            Functions.DocumentToPrintComptoire("", "reglement", "NUM_REGLEMENT", CODE_RESERVATION_CLIENT, dt, CODE_RESERVATION_CLIENT, CODE_CAUTION, CREDIT)
        Next

    End Sub


    Private Sub totalDesDepotDeGarantie()

        Dim TYPE = 1
        Dim infoDepot As DataTable = Functions.GetAllElementsOnCondition(TYPE, "caution", "TYPE")
        Dim solde As Double = 0
        If infoDepot.Rows.Count > 0 Then
            For i = 0 To infoDepot.Rows.Count - 1
                solde += infoDepot.Rows(i)("SOLDE")
            Next

        End If

        GunaTextBoxTotalDesSolde.Text = Format(solde, "#,##0")

    End Sub
End Class