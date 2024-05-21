Imports MySql.Data.MySqlClient

Public Class SynthesePetiteCaisseForm
    Private Sub GunaImageButtonReduce_Click(sender As Object, e As EventArgs) Handles GunaImageButtonReduce.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub GunaImageButtonFermer_Click(sender As Object, e As EventArgs) Handles GunaImageButtonFermer.Click
        Me.Close()
    End Sub

    Public Sub detailsHistoriques(ByVal CODE_SYNTHESE As String)

        Dim query3 As String = "SELECT `DATE_REGLEMENT` AS DATE, `NUM_REGLEMENT` AS REFERENCE, `REF_REGLEMENT` AS DESCRITION, `MONTANT_SORTIE` AS 'MONTANT RETIRE',`NOM_DU_RECEVEUR` AS 'RECU PAR', `APPROUVE_PAR` AS 'APPROUVE PAR', `NOM_UTILISATEUR` AS 'EFFECTUE PAR' FROM petite_caisse_ligne, utilisateurs WHERE CODE_AGENCE = @CODE_AGENCE AND MONTANT_VERSE >= 0 AND petite_caisse_ligne.CODE_CAISSIER= utilisateurs.CODE_UTILISATEUR AND CODE_SYNTHESE=@CODE_SYNTHESE AND NATURE_OPERATION=@NATURE_OPERATION ORDER BY DATE_REGLEMENT DESC "

        Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)
        command3.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence
        command3.Parameters.Add("@CODE_SYNTHESE", MySqlDbType.VarChar).Value = CODE_SYNTHESE
        command3.Parameters.Add("@NATURE_OPERATION", MySqlDbType.Int64).Value = 1

        Dim adapter3 As New MySqlDataAdapter(command3)
        Dim tableReglement As New DataTable()

        adapter3.Fill(tableReglement)

        If tableReglement.Rows.Count > 0 Then

            GunaDataGridViewDetaislHistoriques.Columns.Clear()

            GunaDataGridViewDetaislHistoriques.DataSource = tableReglement
            GunaDataGridViewDetaislHistoriques.Columns(3).DefaultCellStyle.Format = "#,##0"
            GunaDataGridViewDetaislHistoriques.Columns(4).DefaultCellStyle.Format = "#,##0"

            'GunaButtonImprimer.Visible = True

        Else
            GunaDataGridViewDetaislHistoriques.Columns.Clear()
            'GunaButtonImprimer.Visible = False
        End If
    End Sub

    Private Sub GunaButtonAfficher_Click(sender As Object, e As EventArgs) Handles GunaButtonAfficher.Click

        Dim DateDebut As Date = GunaDateTimePickerDebut.Value.ToShortDateString
        Dim DateFin As Date = GunaDateTimePickerFin.Value.ToShortDateString

        Dim query3 As String = "SELECT `DATE_SYNTHESE` As DATE, `CODE_SYNTHESE`, `LIBELLE`, `MONTANT_DEBIT` AS 'MONTANT RETIRE', `NOM_UTILISATEUR` AS 'EFFECTUE PAR' FROM `petite_caisse_ligne_synthese`, `utilisateurs` WHERE CODE_AGENCE = @CODE_AGENCE AND petite_caisse_ligne_synthese.CODE_UTILISATEUR= utilisateurs.CODE_UTILISATEUR AND DATE_SYNTHESE >= '" & DateDebut.ToString("yyyy-MM-dd") & "' AND DATE_SYNTHESE <='" & DateFin.ToString("yyyy-MM-dd") & "' ORDER BY DATE_SYNTHESE DESC "

        Dim command3 As New MySqlCommand(query3, GlobalVariable.connect)
        command3.Parameters.Add("@CODE_AGENCE", MySqlDbType.VarChar).Value = GlobalVariable.codeAgence

        Dim adapter3 As New MySqlDataAdapter(command3)
        Dim tableReglement As New DataTable()

        adapter3.Fill(tableReglement)

        If tableReglement.Rows.Count > 0 Then

            DataGridViewHostiques.Columns.Clear()

            DataGridViewHostiques.DataSource = tableReglement
            DataGridViewHostiques.Columns(3).DefaultCellStyle.Format = "#,##0"
            DataGridViewHostiques.Columns(1).Visible = False

            'GunaButtonImprimer.Visible = True

        Else
            DataGridViewHostiques.Columns.Clear()
            'GunaButtonImprimer.Visible = False
        End If

    End Sub

    Private Sub DataGridViewHostiques_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewHostiques.CellDoubleClick


        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow

            row = Me.DataGridViewHostiques.Rows(e.RowIndex)

            Dim CODE_SYNTHESE As String = row.Cells("CODE_SYNTHESE").Value.ToString

            detailsHistoriques(CODE_SYNTHESE)

        End If

    End Sub

    Private Sub SynthesePetiteCaisseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GunaDateTimePickerDebut.Value = GlobalVariable.DateDeTravail.ToShortDateString
        GunaDateTimePickerFin.Value = GlobalVariable.DateDeTravail.ToShortDateString

    End Sub

End Class