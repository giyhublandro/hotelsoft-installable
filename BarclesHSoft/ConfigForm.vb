Imports MySql.Data.MySqlClient

Public Class ConfigForm

    Private Sub ConfigForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim language As New Languages()
        language.config(GlobalVariable.actualLanguageValue)

        affichageConfig()

    End Sub

    Public Sub affichageConfig()

        Dim config As DataTable = Functions.allTableFields("config")

        If config.Rows.Count > 0 Then

            GunaTextBoxIdConfig.Text = config.Rows(0)("ID_CONFIG")
            GunaTextBox2.Text = config.Rows(0)("DESCRIPTION_1_F")
            GunaTextBox1.Text = config.Rows(0)("DESCRIPTION_2_F")
            GunaTextBox3.Text = config.Rows(0)("DESCRIPTION_3_F")
            GunaTextBox4.Text = config.Rows(0)("DESCRIPTION_4_F")
            GunaTextBox5.Text = config.Rows(0)("SPEC_1F")
            GunaTextBox6.Text = config.Rows(0)("SPEC_2F")
            GunaTextBox7.Text = config.Rows(0)("SPEC_3F")
            GunaTextBox8.Text = config.Rows(0)("SPEC_4F")

            GunaTextBox13.Text = config.Rows(0)("DESCRIPTION_1_E")
            GunaTextBox14.Text = config.Rows(0)("DESCRIPTION_2_E")
            GunaTextBox15.Text = config.Rows(0)("DESCRIPTION_3_E")
            GunaTextBox16.Text = config.Rows(0)("DESCRIPTION_4_E")
            GunaTextBox17.Text = config.Rows(0)("SPEC_1E")
            GunaTextBox18.Text = config.Rows(0)("SPEC_2E")
            GunaTextBox19.Text = config.Rows(0)("SPEC_3E")
            GunaTextBox20.Text = config.Rows(0)("SPEC_4E")

            GunaTextBox9.Text = config.Rows(0)("LOG")
            GunaTextBox10.Text = config.Rows(0)("ACTIV_MES")
            GunaTextBox11.Text = config.Rows(0)("FOOTER_DOCUMENT_SOFTWARE")
            GunaTextBox20.Text = config.Rows(0)("SPEC_4E")
            GunaTextBox20.Text = config.Rows(0)("SPEC_4E")
            GunaTextBox20.Text = config.Rows(0)("SPEC_4E")
            GunaTextBox23.Text = config.Rows(0)("C_NAME")

            Dim primaryColorString As String = config.Rows(0)("SCHEME_COLOR")
            Dim secondaryColorForeString As String = config.Rows(0)("SCHEME_SECONDARY_COLOR")
            Dim primaryTextColorString As String = config.Rows(0)("TEXT_PRIMARY_COLOR")
            Dim secondaryTextColorForeString As String = config.Rows(0)("TEXT_SECONDARY_COLOR")

            Dim paramCouleur() As String

            If Trim(primaryColorString.ToString).Equals("") Then
                GunaTextBoxBgColoration.BaseColor = Color.FromArgb(255, 64, 0, 128)
            Else
                paramCouleur = Functions.returningColorFromString(primaryColorString)

                If paramCouleur(1).Equals("") Then
                    GunaTextBoxBgColoration.BaseColor = Color.FromName(paramCouleur(0))
                Else
                    GunaTextBoxBgColoration.BaseColor = Color.FromArgb(Integer.Parse(paramCouleur(0)), Integer.Parse(paramCouleur(1)), Integer.Parse(paramCouleur(2)), Integer.Parse(paramCouleur(3)))
                End If
            End If

            If Trim(secondaryColorForeString.ToString).Equals("") Then
                GunaTextBox12.BaseColor = Color.FromArgb(255, 64, 0, 128)
            Else
                paramCouleur = Functions.returningColorFromString(secondaryColorForeString)

                If paramCouleur(1).Equals("") Then
                    GunaTextBox12.BaseColor = Color.FromName(paramCouleur(0))
                Else
                    GunaTextBox12.BaseColor = Color.FromArgb(Integer.Parse(paramCouleur(0)), Integer.Parse(paramCouleur(1)), Integer.Parse(paramCouleur(2)), Integer.Parse(paramCouleur(3)))
                End If

            End If

            If Trim(primaryTextColorString.ToString).Equals("") Then
                GunaTextBox21.BaseColor = Color.FromArgb(255, 64, 0, 128)
            Else
                paramCouleur = Functions.returningColorFromString(primaryTextColorString)

                If paramCouleur(1).Equals("") Then
                    GunaTextBox21.BaseColor = Color.FromName(paramCouleur(0))
                Else
                    GunaTextBox21.BaseColor = Color.FromArgb(Integer.Parse(paramCouleur(0)), Integer.Parse(paramCouleur(1)), Integer.Parse(paramCouleur(2)), Integer.Parse(paramCouleur(3)))
                End If

            End If

            If Trim(secondaryTextColorForeString.ToString).Equals("") Then
                GunaTextBox22.BaseColor = Color.FromArgb(255, 64, 0, 128)
            Else
                paramCouleur = Functions.returningColorFromString(secondaryTextColorForeString)

                If paramCouleur(1).Equals("") Then
                    GunaTextBox22.BaseColor = Color.FromName(paramCouleur(0))
                Else
                    GunaTextBox22.BaseColor = Color.FromArgb(Integer.Parse(paramCouleur(0)), Integer.Parse(paramCouleur(1)), Integer.Parse(paramCouleur(2)), Integer.Parse(paramCouleur(3)))
                End If

            End If

            If GlobalVariable.actualLanguageValue = 1 Then
                GunaButton2.Text = "Update"
            Else
                GunaButton2.Text = "Sauvegarder"
            End If

        Else
            If GlobalVariable.actualLanguageValue = 1 Then
                GunaButton2.Text = "Save"
            Else
                GunaButton2.Text = "Create"
            End If
        End If


    End Sub

    Private Sub GunaButtonColoration_Click(sender As Object, e As EventArgs) Handles GunaButtonColoration.Click
        If ColorDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            GunaTextBoxBgColoration.BaseColor = ColorDialog.Color
        End If
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        If ColorDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            GunaTextBox12.BaseColor = ColorDialog.Color
        End If
    End Sub
    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click

        Dim config As New ConfigClass

        Dim DESCRIPTION_1_F As String = GunaTextBox2.Text
        Dim DESCRIPTION_2_F As String = GunaTextBox1.Text
        Dim DESCRIPTION_3_F As String = GunaTextBox3.Text
        Dim DESCRIPTION_4_F As String = GunaTextBox4.Text
        Dim DESCRIPTION_1_E As String = GunaTextBox13.Text
        Dim DESCRIPTION_2_E As String = GunaTextBox14.Text
        Dim DESCRIPTION_3_E As String = GunaTextBox15.Text
        Dim DESCRIPTION_4_E As String = GunaTextBox16.Text
        Dim ACTIV_MES As String = GunaTextBox10.Text
        Dim SPEC_1E As String = GunaTextBox17.Text
        Dim SPEC_2E As String = GunaTextBox18.Text
        Dim SPEC_3E As String = GunaTextBox19.Text
        Dim SPEC_4E As String = GunaTextBox20.Text
        Dim SPEC_1F As String = GunaTextBox5.Text
        Dim SPEC_2F As String = GunaTextBox6.Text
        Dim SPEC_3F As String = GunaTextBox7.Text
        Dim SPEC_4F As String = GunaTextBox8.Text
        Dim SCHEME_COLOR As String = GunaTextBoxBgColoration.BaseColor.ToString
        Dim SCHEME_SECONDARY_COLOR As String = GunaTextBox12.BaseColor.ToString
        Dim TEXT_PRIMARY_COLOR As String = GunaTextBox21.BaseColor.ToString
        Dim TEXT_SECONDARY_COLOR As String = GunaTextBox22.BaseColor.ToString
        Dim FOOTER_DOCUMENT_SOFTWARE As String = GunaTextBox11.Text
        Dim SF_NAME As String = GunaTextBox9.Text
        Dim C_NAME As String = GunaTextBox23.Text

        If GunaButton2.Text.Equals("Sauvegarder") Or GunaButton2.Text.Equals("Update") Then
            Dim ID_CONFIG As Integer = GunaTextBoxIdConfig.Text
            If GlobalVariable.actualLanguageValue = 1 Then
                config.updateConfigFr(DESCRIPTION_1_F, DESCRIPTION_2_F, DESCRIPTION_3_F, DESCRIPTION_4_F, ACTIV_MES, SPEC_1F, SPEC_2F, SPEC_3F, SPEC_4F, SCHEME_COLOR, SCHEME_SECONDARY_COLOR, FOOTER_DOCUMENT_SOFTWARE, C_NAME, SF_NAME, TEXT_PRIMARY_COLOR, TEXT_SECONDARY_COLOR, ID_CONFIG)
            ElseIf GlobalVariable.actualLanguageValue = 0 Then
                config.updateConfigEn(DESCRIPTION_1_E, DESCRIPTION_2_E, DESCRIPTION_3_E, DESCRIPTION_4_E, ACTIV_MES, SPEC_1E, SPEC_2E, SPEC_3E, SPEC_4E, SCHEME_COLOR, SCHEME_SECONDARY_COLOR, FOOTER_DOCUMENT_SOFTWARE, C_NAME, SF_NAME, TEXT_PRIMARY_COLOR, TEXT_SECONDARY_COLOR, ID_CONFIG)
            End If

        Else
            config.createConfig(DESCRIPTION_1_F, DESCRIPTION_2_F, DESCRIPTION_3_F, DESCRIPTION_4_F, DESCRIPTION_1_E, DESCRIPTION_2_E, DESCRIPTION_3_E, DESCRIPTION_4_E, ACTIV_MES, SPEC_1E, SPEC_2E, SPEC_3E, SPEC_4E, SPEC_1F, SPEC_2F, SPEC_3F, SPEC_4F, SCHEME_COLOR, SCHEME_SECONDARY_COLOR, FOOTER_DOCUMENT_SOFTWARE, C_NAME, SF_NAME, TEXT_PRIMARY_COLOR, TEXT_SECONDARY_COLOR)
        End If

        affichageConfig()

    End Sub

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click
        If ColorDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            GunaTextBox21.BaseColor = ColorDialog.Color
        End If
    End Sub

    Private Sub GunaButton4_Click(sender As Object, e As EventArgs) Handles GunaButton4.Click
        If ColorDialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            GunaTextBox22.BaseColor = ColorDialog.Color
        End If
    End Sub

End Class