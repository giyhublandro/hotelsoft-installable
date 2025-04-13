Public Class ControllerNettoyageForm

    Dim CODE_CHAMBRE As String = ""

    Private Sub ControllerNettoyageForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim CODE_CHAMBRE As String = Trim(EtatDeChambreForm.GunaLabelChmabreEncoursDeNettoyage.Text)
        Dim langue As New Languages
        langue.controllerNettoyage(GlobalVariable.actualLanguageValue)

        GunaButtonEnregistrer.Enabled = False
        compteur = 0

        EtatDeChambreForm.Close()

    End Sub

    Private Sub GunaImageButton6_Click(sender As Object, e As EventArgs) Handles GunaImageButton6.Click
        Me.Close()
    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButtonEnregistrer.Click

        Dim serviceEtag As New ServicesEtage

        Dim CODE_CHAMBRE As String = GlobalVariable.btnNettoyage.Name
        Dim CHAMP As String = "HEURE_CONTROL"
        Dim STATUTS As Integer = 3
        Dim ETAT_CHAMBRE_NOTE As String = "Libre propre"
        If GlobalVariable.actualLanguageValue = 0 Then
            ETAT_CHAMBRE_NOTE = "Free clean"
        End If

        serviceEtag.updateNettoyageTime(CODE_CHAMBRE, CHAMP, STATUTS)

        serviceEtag.updateRoomApresNettoyage(CODE_CHAMBRE, ETAT_CHAMBRE_NOTE)

        serviceEtag.miseAjourDelaChambreApreNettoyage(CODE_CHAMBRE, ETAT_CHAMBRE_NOTE)

        Me.Close()

        MainWindowServiceEtageForm.TabPageNettoyage.Controls.Clear()
        MainWindowServiceEtageForm.StatistiquesDeNettoyage()
        MainWindowServiceEtageForm.StatusDesChambres()

    End Sub

    Dim compteur As Integer = 0

    Private Sub Guna1_Click(sender As Object, e As EventArgs) Handles Guna1.Click

        If Guna1.Checked Then

            compteur += 1

        Else
            compteur -= 1
        End If

        AfficherBoutonCOntroller()

    End Sub

    Private Sub GunaA_Click(sender As Object, e As EventArgs) Handles GunaA.Click

        If GunaA.Checked Then

            compteur += 1

        Else

            compteur -= 1
        End If


        AfficherBoutonCOntroller()


    End Sub

    Private Sub GunaB_Click(sender As Object, e As EventArgs) Handles GunaB.Click

        If GunaB.Checked Then

            compteur += 1

        Else

            compteur -= 1
        End If


        AfficherBoutonCOntroller()

    End Sub

    Private Sub GunaC_Click(sender As Object, e As EventArgs) Handles GunaC.Click

        If GunaC.Checked Then

            compteur += 1

        Else
            compteur -= 1
        End If


        AfficherBoutonCOntroller()

    End Sub

    Private Sub Guna3_Click(sender As Object, e As EventArgs) Handles Guna3.Click

        If Guna3.Checked Then

            compteur += 1

        Else
            compteur -= 1
        End If


        AfficherBoutonCOntroller()

    End Sub

    Private Sub Guna4_Click(sender As Object, e As EventArgs) Handles Guna4.Click

        If Guna4.Checked Then

            compteur += 1

        Else
            compteur -= 1
        End If


        AfficherBoutonCOntroller()

    End Sub

    Private Sub Guna5_Click(sender As Object, e As EventArgs) Handles Guna5.Click

        If Guna5.Checked Then

            compteur += 1

        Else
            compteur -= 1
        End If


        AfficherBoutonCOntroller()

    End Sub

    Private Sub Guna6_Click(sender As Object, e As EventArgs) Handles Guna6.Click

        If Guna6.Checked Then

            compteur += 1

        Else
            compteur -= 1
        End If


        AfficherBoutonCOntroller()

    End Sub

    Private Sub Guna7_Click(sender As Object, e As EventArgs) Handles Guna7.Click

        If Guna7.Checked Then

            compteur += 1

        Else
            compteur -= 1
        End If


        AfficherBoutonCOntroller()

    End Sub

    Private Sub Guna8_Click(sender As Object, e As EventArgs) Handles Guna8.Click

        If Guna8.Checked Then

            compteur += 1

        Else
            compteur -= 1
        End If


        AfficherBoutonCOntroller()

    End Sub

    Private Sub Guna9_Click(sender As Object, e As EventArgs) Handles Guna9.Click

        If Guna9.Checked Then

            compteur += 1

        Else
            compteur -= 1
        End If


        AfficherBoutonCOntroller()

    End Sub

    Private Sub Guna10_Click(sender As Object, e As EventArgs) Handles Guna10.Click

        If Guna10.Checked Then

            compteur += 1

        Else
            compteur -= 1
        End If


        AfficherBoutonCOntroller()

    End Sub

    Private Sub Guna11_Click(sender As Object, e As EventArgs) Handles Guna11.Click

        If Guna11.Checked Then

            compteur += 1

        Else
            compteur -= 1
        End If


        AfficherBoutonCOntroller()

    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Me.Close()
    End Sub

    Private Sub AfficherBoutonCOntroller()

        If compteur = 13 Then
            GunaButtonEnregistrer.Enabled = True
            GunaButtonEnregistrer.Visible = True
        Else
            GunaButtonEnregistrer.Enabled = False
            GunaButtonEnregistrer.Visible = True
        End If

    End Sub

    Private Sub GunaCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles GunaCheckBoxTousCocher.CheckedChanged

        compteur = 13

        If GunaCheckBoxTousCocher.Checked Then

            Guna1.Checked = True
            GunaA.Checked = True
            GunaB.Checked = True
            GunaC.Checked = True
            Guna3.Checked = True
            Guna4.Checked = True
            Guna5.Checked = True
            Guna6.Checked = True
            Guna7.Checked = True
            Guna8.Checked = True
            Guna9.Checked = True
            Guna10.Checked = True
            Guna11.Checked = True

            AfficherBoutonCOntroller()

        Else

            Guna1.Checked = False
            GunaA.Checked = False
            GunaB.Checked = False
            GunaC.Checked = False
            Guna3.Checked = False
            Guna4.Checked = False
            Guna5.Checked = False
            Guna6.Checked = False
            Guna7.Checked = False
            Guna8.Checked = False
            Guna9.Checked = False
            Guna10.Checked = False
            Guna11.Checked = False

            GunaButtonEnregistrer.Enabled = False

            GunaButtonEnregistrer.Visible = True

        End If



    End Sub

End Class