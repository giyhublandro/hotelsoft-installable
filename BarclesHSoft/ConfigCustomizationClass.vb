
Public Class ConfigCustomizationClass

    Dim backColorString As String = ""
    Dim backSecondaryColorString As String = ""
    Dim textColorString As String = ""
    Dim textSecondaryColorString As String = ""

    Dim paramCouleur() As String
    Dim paramSecondaryCouleur() As String
    Dim paramSecondaryTextCouleur() As String
    Dim paramPrimaryTextCouleur() As String

    Public Sub customization(ByVal formName As String)

        If GlobalVariable.AgenceActuelle.Rows(0)("CONFIG") = 1 Then

            If GlobalVariable.config.Rows.Count > 0 Then

                backColorString = GlobalVariable.config.Rows(0)("SCHEME_COLOR")
                backSecondaryColorString = GlobalVariable.config.Rows(0)("SCHEME_SECONDARY_COLOR")
                textColorString = GlobalVariable.config.Rows(0)("TEXT_PRIMARY_COLOR")
                textSecondaryColorString = GlobalVariable.config.Rows(0)("TEXT_SECONDARY_COLOR")

                paramCouleur = Functions.returningColorFromString(backColorString)
                paramSecondaryCouleur = Functions.returningColorFromString(backSecondaryColorString)
                paramSecondaryTextCouleur = Functions.returningColorFromString(textSecondaryColorString)
                paramPrimaryTextCouleur = Functions.returningColorFromString(textColorString)

                If formName.Equals("authentification") Then
                    authentification()
                End If

            End If

        End If

    End Sub

    Public Sub authentification()

        If paramCouleur(1).Equals("") Then

            GenerationForm.GunaButtonAfficherValidee.BaseColor = Color.FromName(paramSecondaryCouleur(0))
            GenerationForm.GunaButton1.BaseColor = Color.FromName(paramSecondaryCouleur(0))
            GenerationForm.GunaLinePanelTop.BackColor = Color.FromName(paramSecondaryCouleur(0))
            GenerationForm.Panel1.BackColor = Color.FromName(paramSecondaryCouleur(0))

        Else

            GenerationForm.GunaButtonAfficherValidee.BaseColor = Color.FromArgb(Integer.Parse(paramSecondaryCouleur(0)), Integer.Parse(paramSecondaryCouleur(1)), Integer.Parse(paramSecondaryCouleur(2)), Integer.Parse(paramSecondaryCouleur(3)))
            GenerationForm.GunaButton1.BaseColor = Color.FromArgb(Integer.Parse(paramSecondaryCouleur(0)), Integer.Parse(paramSecondaryCouleur(1)), Integer.Parse(paramSecondaryCouleur(2)), Integer.Parse(paramSecondaryCouleur(3)))
            GenerationForm.GunaLinePanelTop.BackColor = Color.FromArgb(Integer.Parse(paramCouleur(0)), Integer.Parse(paramCouleur(1)), Integer.Parse(paramCouleur(2)), Integer.Parse(paramCouleur(3)))
            GenerationForm.Panel1.BackColor = Color.FromArgb(Integer.Parse(paramCouleur(0)), Integer.Parse(paramCouleur(1)), Integer.Parse(paramCouleur(2)), Integer.Parse(paramCouleur(3)))

        End If

    End Sub

End Class
