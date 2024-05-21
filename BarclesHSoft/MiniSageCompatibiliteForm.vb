Public Class MiniSageCompatibiliteForm
    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Functions.exitApplicationThread()
    End Sub

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub NouveauToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NouveauToolStripMenuItem.Click

        'CREER UN FICHIER COMPTABLE

        MiniSageNouveauDocumentComptableForm.Show()
        MiniSageNouveauDocumentComptableForm.TopMost = True
        MiniSageNouveauDocumentComptableForm.Text = "Assistant de création de fichier comptable"
        MiniSageNouveauDocumentComptableForm.GunaPanelAssitantDeConfigFichierCompta.BringToFront()

    End Sub

    Private Sub PlanComptabeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlanComptabeToolStripMenuItem.Click

        MiniSageNouveauDocumentComptableForm.Show()
        MiniSageNouveauDocumentComptableForm.TopMost = True
        MiniSageNouveauDocumentComptableForm.Text = "Plan comptable"
        MiniSageNouveauDocumentComptableForm.GunaPanelPlan.BringToFront()
        MiniSageNouveauDocumentComptableForm.TabControlPlan.SelectedIndex = 0
        MiniSageNouveauDocumentComptableForm.GunaPanelAddComptePlanComptable.Visible = False
        MiniSageNouveauDocumentComptableForm.GunaPanelRecherchePlanComptablePanel.Visible = True

    End Sub

    Private Sub AjouterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjouterToolStripMenuItem.Click
        MiniSageNouveauDocumentComptableForm.Show()
        MiniSageNouveauDocumentComptableForm.TopMost = True
        MiniSageNouveauDocumentComptableForm.Text = "Ajouter un compte"
        MiniSageNouveauDocumentComptableForm.GunaPanelPlan.BringToFront()
        MiniSageNouveauDocumentComptableForm.GunaPanelAddComptePlanComptable.Visible = True
        MiniSageNouveauDocumentComptableForm.GunaPanelRecherchePlanComptablePanel.Visible = False
    End Sub

    Private Sub PlanAnalytiqueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlanAnalytiqueToolStripMenuItem.Click

        MiniSageNouveauDocumentComptableForm.Show()
        MiniSageNouveauDocumentComptableForm.TopMost = True
        MiniSageNouveauDocumentComptableForm.Text = "Plan analytique"
        MiniSageNouveauDocumentComptableForm.GunaPanelPlan.BringToFront()
        MiniSageNouveauDocumentComptableForm.TabControlPlan.SelectedIndex = 2
        MiniSageNouveauDocumentComptableForm.GunaPanelAddComptePlanComptable.Visible = False
        MiniSageNouveauDocumentComptableForm.GunaPanelRecherchePlanComptablePanel.Visible = True

    End Sub

    Private Sub PlanTiersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlanTiersToolStripMenuItem.Click

        MiniSageNouveauDocumentComptableForm.Show()
        MiniSageNouveauDocumentComptableForm.TopMost = True
        MiniSageNouveauDocumentComptableForm.Text = "Plan tiers"
        MiniSageNouveauDocumentComptableForm.GunaPanelPlan.BringToFront()
        MiniSageNouveauDocumentComptableForm.TabControlPlan.SelectedIndex = 1
        MiniSageNouveauDocumentComptableForm.GunaPanelAddComptePlanComptable.Visible = False
        MiniSageNouveauDocumentComptableForm.GunaPanelRecherchePlanComptablePanel.Visible = True

    End Sub

    Private Sub CodeJournauxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CodeJournauxToolStripMenuItem.Click

        MiniSageNouveauDocumentComptableForm.Show()
        MiniSageNouveauDocumentComptableForm.TopMost = True
        MiniSageNouveauDocumentComptableForm.Text = "Code journaux"
        MiniSageNouveauDocumentComptableForm.GunaPanelCodeJournaux.BringToFront()
        MiniSageNouveauDocumentComptableForm.GunaPanelCodeJournaux.Visible = True
        MiniSageNouveauDocumentComptableForm.GunaPanelAddComptePlanComptable.Visible = False
        MiniSageNouveauDocumentComptableForm.GunaPanelRecherchePlanComptablePanel.Visible = False

    End Sub

    Private Sub TauxDeTaxesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TauxDeTaxesToolStripMenuItem.Click

        MiniSageNouveauDocumentComptableForm.Show()
        MiniSageNouveauDocumentComptableForm.TopMost = True
        MiniSageNouveauDocumentComptableForm.Text = "Taux de taxes"
        MiniSageNouveauDocumentComptableForm.GunaPanelTauxDeTaxe.BringToFront()
        MiniSageNouveauDocumentComptableForm.GunaPanelTauxDeTaxe.Visible = True
        MiniSageNouveauDocumentComptableForm.TabControlTauxDeTaxes.SelectedIndex = 0
        MiniSageNouveauDocumentComptableForm.GunaPanelAssitantDeConfigFichierCompta.Visible = False

    End Sub

    Private Sub ModeRèglementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModeRèglementToolStripMenuItem.Click

        MiniSageNouveauDocumentComptableForm.Show()
        MiniSageNouveauDocumentComptableForm.TopMost = True
        MiniSageNouveauDocumentComptableForm.Text = "Modèles de règlement"
        MiniSageNouveauDocumentComptableForm.GunaPanelModeReglement.BringToFront()
        MiniSageNouveauDocumentComptableForm.GunaPanelModeReglement.Visible = True
        MiniSageNouveauDocumentComptableForm.GunaPanelTauxDeTaxe.Visible = False
        MiniSageNouveauDocumentComptableForm.TabControlTauxDeTaxes.SelectedIndex = 0
        MiniSageNouveauDocumentComptableForm.GunaPanelAssitantDeConfigFichierCompta.Visible = False

    End Sub

    Private Sub BanquesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BanquesToolStripMenuItem.Click

        BankForm.Show()
        BankForm.TopMost = True

    End Sub

    Private Sub LibellésToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LibellésToolStripMenuItem.Click

        MiniSageNouveauDocumentComptableForm.Show()
        MiniSageNouveauDocumentComptableForm.TopMost = True
        MiniSageNouveauDocumentComptableForm.Text = "Libellés"
        MiniSageNouveauDocumentComptableForm.GunaPanelLibelle.BringToFront()
        MiniSageNouveauDocumentComptableForm.GunaPanelLibelle.Visible = True
        MiniSageNouveauDocumentComptableForm.GunaPanelTauxDeTaxe.Visible = False
        MiniSageNouveauDocumentComptableForm.TabControlLibelle.SelectedIndex = 0
        MiniSageNouveauDocumentComptableForm.GunaPanelAssitantDeConfigFichierCompta.Visible = False

    End Sub

    Private Sub JounauxDeSaisieToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JounauxDeSaisieToolStripMenuItem.Click

        MiniSageNouveauDocumentComptableForm.Show()
        MiniSageNouveauDocumentComptableForm.TopMost = True
        MiniSageNouveauDocumentComptableForm.Text = "Journaux de saisie"
        MiniSageNouveauDocumentComptableForm.GunaPanelSaisieDesJournaux.BringToFront()
        MiniSageNouveauDocumentComptableForm.GunaPanelSaisieDesJournaux.Visible = True
        MiniSageNouveauDocumentComptableForm.GunaPanelLibelle.Visible = False
        MiniSageNouveauDocumentComptableForm.GunaPanelTauxDeTaxe.Visible = False
        MiniSageNouveauDocumentComptableForm.TabControlJournauxDeSaisie.SelectedIndex = 0
        MiniSageNouveauDocumentComptableForm.GunaPanelAssitantDeConfigFichierCompta.Visible = False

    End Sub

    Private Sub RechercheDécrituresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RechercheDécrituresToolStripMenuItem.Click

        MiniSageNouveauDocumentComptableForm.Show()
        MiniSageNouveauDocumentComptableForm.TopMost = True
        MiniSageNouveauDocumentComptableForm.Text = "Journaux de saisie"
        MiniSageNouveauDocumentComptableForm.GunaPanelSaisieDesJournaux.BringToFront()
        MiniSageNouveauDocumentComptableForm.GunaPanelSaisieDesJournaux.Visible = True
        MiniSageNouveauDocumentComptableForm.GunaPanelLibelle.Visible = False
        MiniSageNouveauDocumentComptableForm.GunaPanelTauxDeTaxe.Visible = False
        MiniSageNouveauDocumentComptableForm.TabControlJournauxDeSaisie.SelectedIndex = 2
        MiniSageNouveauDocumentComptableForm.GunaPanelAssitantDeConfigFichierCompta.Visible = False

    End Sub
End Class