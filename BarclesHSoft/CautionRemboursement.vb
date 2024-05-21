Public Class CautionRemboursement
    Private Sub CautionRemboursement_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()
        language.cautionRembours(GlobalVariable.actualLanguageValue)

    End Sub

    Dim languageMessage As String = ""
    Dim languageTitle As String = ""

    Private Sub GunaButtonRembourser_Click(sender As Object, e As EventArgs) Handles GunaButtonRembourser.Click

        'MISE AJOURS DU MONTANT EN DEBIT

        GunaTextBoxMotifDifference.Visible = False

        Dim resa As New Reservation()

        Dim CODE_CAUTION As String = GunaTextBoxCodeCaution.Text

        Dim caution As DataTable = Functions.getElementByCode(CODE_CAUTION, "caution", "CODE_CAUTION")

        Dim CREDIT As Double = 0
        Dim DEBIT As Double = 0

        'Dim CODE_CAUTION As String = ""
        Dim CODE_UTILISATEUR_CREA As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")
        Dim TYPE_CAUTION_DEPOT As Integer = 0

        DEBIT = GunaTextBoxMontantARembourser.Text

        If caution.Rows.Count > 0 Then

            CREDIT = caution.Rows(0)("CREDIT")
            CODE_CAUTION = caution.Rows(0)("CODE_CAUTION")
            TYPE_CAUTION_DEPOT = caution.Rows(0)("TYPE")

        End If

        'REBOURSEMENT PARTIEL DONC ON DOIT AVOIR LE MOTIF DE LA PARTIALITE
        Dim ETAT_DEPOT As String = "Remboursé"

        If Double.Parse(GunaTextBoxMontantARembourser.Text) <= 0 Then

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Please enter an amount !!"
                languageTitle = "Arrhes"
            Else
                languageMessage = "Bien vouloir Entrer un montant !!"
                languageTitle = "Caution"
            End If

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

        ElseIf Double.Parse(GunaTextBoxCaution.Text) <= Double.Parse(GunaTextBoxMontantARembourser.Text) Then

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Arhes of " & Format(CREDIT, "#,##0") & " paid back (completely) !!"
                languageTitle = "Caution"
            Else
                languageMessage = "Caution de " & Format(CREDIT, "#,##0") & " remboursée (en totalité) !!"
                languageTitle = "Caution"
            End If

            resa.updateCaution(CODE_CAUTION, CODE_CAUTION, DEBIT, CREDIT, CODE_UTILISATEUR_CREA, TYPE_CAUTION_DEPOT, ETAT_DEPOT)

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Close()

        ElseIf Double.Parse(GunaTextBoxCaution.Text) > Double.Parse(GunaTextBoxMontantARembourser.Text) And Not Trim(GunaTextBoxMotifDifference.Text) = "" Then

            If GlobalVariable.actualLanguageValue = 0 Then
                languageMessage = "Arhes of " & Format(CREDIT, "#,##0") & " paid back (partially) !!"
                languageTitle = "Caution"
            Else
                languageMessage = "Caution de " & Format(CREDIT, "#,##0") & " remboursée (partiellement) !!"
                languageTitle = "Caution"
            End If

            resa.updateCaution(CODE_CAUTION, CODE_CAUTION, DEBIT, CREDIT, CODE_UTILISATEUR_CREA, TYPE_CAUTION_DEPOT, ETAT_DEPOT)

            Dim RAISON As String = GunaTextBoxMotifDifference.Text

            resa.updateMotifRemboursementPartielDelaCaution(CODE_CAUTION, RAISON)

            MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Close()

        Else

            GunaTextBoxMotifDifference.Visible = True
            GunaLabelmOTIF.Visible = True

        End If

        If TYPE_CAUTION_DEPOT = 1 Then
            Dim n As Integer = DepotGarantieForm.GunaComboBoxTypeDepot.SelectedIndex
            DepotGarantieForm.listeDesCautionsArrange(0, n)
        End If

    End Sub

    Private Sub GunaTextBoxMontantARembourser_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxMontantARembourser.TextChanged

        If Trim(GunaTextBoxMontantARembourser.Text) = "" Then
            GunaTextBoxMontantARembourser.Text = 0
            GunaTextBoxMotifDifference.Visible = True
            GunaLabelmOTIF.Visible = True
        End If

        If Trim(GunaTextBoxCaution.Text) = "" Then
            GunaTextBoxCaution.Text = 0
        End If

        'REMBOURSEMENT EN TOTALITE
        If Double.Parse(GunaTextBoxMontantARembourser.Text) >= Double.Parse(GunaTextBoxCaution.Text) Then
            GunaTextBoxMotifDifference.Visible = False
            GunaLabelmOTIF.Visible = False
        Else
            'REMBOURSEMENT PARTIELLE
            GunaTextBoxMotifDifference.Visible = True
            GunaLabelmOTIF.Visible = True
        End If

    End Sub

    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Me.Close()
    End Sub

End Class