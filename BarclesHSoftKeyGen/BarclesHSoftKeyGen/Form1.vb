
Imports System.Security.Cryptography
Imports System.Text

Public Class Form1

    Public Function convertionDesDatesEnValeurNumerique(ByVal DateQuelconque As Date) As String

        Dim mois As Integer = 0
        Dim annee As Integer = 0
        Dim days As Integer = DateQuelconque.Day 'RETOURNE LE JOUR ACTUEL DU MOIS

        Integer.TryParse(Month(DateQuelconque), mois)
        Integer.TryParse(Year(DateQuelconque), annee)

        Dim addDays As String = ""
        Dim addMonths As String = ""

        If days < 10 Then
            addDays = "0"
        End If

        If mois < 10 Then
            addMonths = "0"
        End If

        Return addDays & days & "" & addMonths & mois & "" & annee

    End Function

    Public Function creationDelaCodeAChiffrer(ByVal index As Integer, ByVal dateDebut As Date, ByVal dateFin As Date, ByVal nombreDeConnexion As Integer, ByVal nombreDeJour As Integer) As String

        Dim nombreDeJOurChaine As String = ""
        Dim nombreDeConnexionChaine As String = ""

        If nombreDeJour < 10 Then
            nombreDeJOurChaine = "00"
        ElseIf nombreDeJour < 99 Then
            nombreDeJOurChaine = "0"
        End If

        If nombreDeConnexion < 10 Then
            nombreDeConnexionChaine = "00"
        ElseIf nombreDeConnexion < 99 Then
            nombreDeConnexionChaine = "0"
        End If

        Dim chaineDateDebut As String = convertionDesDatesEnValeurNumerique(dateDebut)
        Dim chaineDateFin As String = convertionDesDatesEnValeurNumerique(dateFin)
        Dim chaineAChiffrer As String = ""

        If index = 0 Then
            chaineAChiffrer = index & "" & chaineDateDebut & "" & chaineDateFin & nombreDeConnexionChaine & nombreDeConnexion
        ElseIf index = 1 Then
            chaineAChiffrer = index & "" & chaineDateDebut & "" & chaineDateFin & nombreDeJOurChaine & nombreDeJour
        End If

        Dim chaineARetourner As String = insertionDeCaractere(chaineAChiffrer)

        Return chaineARetourner

    End Function

    'ON RECUPERE LA CHAINE A CHIFFRER PUIS ON INSERT UN NOUVEAU CARACTERE TOUT LES 4 CARACTERES

    Private Function insertionDeCaractere(ByVal chaineAChiffrer As String) As String

        Dim chaineARetourner As String = ""

        Dim j As Integer = -1
        Dim k As Integer = 1

        For i = 0 To chaineAChiffrer.Length - 1

            chaineARetourner = chaineARetourner + chaineAChiffrer(i)

            If k Mod 4 = 0 Then

                Dim randomNumber As Integer = random.Next(3, 9)

                chaineARetourner = chaineARetourner & "" & randomNumber
                'chaineARetourner = chaineARetourner & ""

            End If

            k += 1

        Next

        Return renversementDeLaChaine(chaineARetourner)

    End Function

    Public Function retranchementDeCaractere(ByVal chaineADeChiffrer As String) As String

        Dim chaineDeChiffre As String = ""
        Dim k As Integer = 1

        Dim jump As Boolean = False

        For i = 0 To chaineADeChiffrer.Length - 1

            If jump Then

                jump = False

                Continue For

            End If

            chaineDeChiffre = chaineDeChiffre + chaineADeChiffrer(i)

            If k Mod 4 = 0 Then

                'LORSQU'ON A PRELEVER 4 CARACTERES ON SAUTE LA PROCHAINE ITERATION PUIS ON REPREND DE ZERO

                'chaineDeChiffre += chaineDeChiffre

                jump = True

                k = 0

            End If

            k += 1

        Next

        Return chaineDeChiffre

    End Function

    Private Function renversementDeLaChaine(ByVal chaineAChiffrer As String) As String

        Dim chaineRenverse As String = ""

        For i = chaineAChiffrer.Length - 1 To 0 Step -1
            chaineRenverse = chaineRenverse + chaineAChiffrer(i)
        Next

        Return chaineRenverse

    End Function

    Private Sub GunaComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GunaComboBoxSerialType.SelectedIndexChanged

        'TESTS
        GunaTextBox6.Clear()
        GunaTextBox7.Clear()
        GunaTextBox8.Clear()
        GunaTextBox9.Clear()

        GunaTextBoxSerialType.Clear()
        GunaTextBoxNumber.Clear()
        GunaTextBoxDateDebut.Clear()
        GunaTextBoxDateFin.Clear()
        '-------------------------------

        GunaButtonGetSerial.Visible = True

        GunaTextBoxNumberOfConnect.Clear()
        GunaTextBoxNumberDays.Clear()
        GunaTextBoxSerialGenerated.Clear()

        GunaTextBox1.Clear()
        GunaTextBox2.Clear()
        GunaTextBox3.Clear()
        GunaTextBox4.Clear()
        GunaTextBox5.Clear()

        '0 = NUMBER OF CONNECTIONS
        '1 = PERIODE
        '2 = TRIAL
        '3 = PREMIUM

        If GunaComboBoxSerialType.SelectedIndex >= 0 Then
            GunaButtonGetSerial.Visible = True

            GunaTextBoxNumberDays.Text = GunaComboBoxSerialType.SelectedIndex
        Else
            GunaButtonGetSerial.Visible = False

        End If

        If GunaComboBoxSerialType.SelectedIndex = 0 Then

            GunaLabelConnection.Visible = True
            GunaTextBoxNumberOfConnect.Visible = True

            GunaDateTimePicker1.Visible = False
            GunaDateTimePicker2.Visible = False

            GunaLabel4.Visible = False
            GunaLabel3.Visible = False

            GunaDateTimePicker1.Value = Now()

            GunaDateTimePicker2.Value = GunaDateTimePicker1.Value

        ElseIf GunaComboBoxSerialType.SelectedIndex = 1 Then

            GunaDateTimePicker1.Visible = True
            GunaDateTimePicker1.Value = Now()
            GunaDateTimePicker1.Enabled = False

            GunaDateTimePicker2.Visible = True
            GunaDateTimePicker2.Value = GunaDateTimePicker1.Value.AddDays(1)

            GunaTextBoxNumberDays.Text = (GunaDateTimePicker2.Value - GunaDateTimePicker1.Value).TotalDays()

            GunaLabel4.Visible = True
            GunaLabel3.Visible = True

            GunaLabelConnection.Visible = False
            GunaTextBoxNumberOfConnect.Visible = False

        ElseIf GunaComboBoxSerialType.SelectedIndex = 2 Then

        ElseIf GunaComboBoxSerialType.SelectedIndex = 3 Then

        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GunaDateTimePicker1.Value = Now()
        GunaDateTimePicker2.Value = Now()

        GunaDateTimePicker1.Enabled = False

        GunaComboBoxSerialType.SelectedIndex = 0

    End Sub

    Private Sub GunaDateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles GunaDateTimePicker2.ValueChanged

        GunaTextBoxSerialGenerated.Clear()

        If GunaComboBoxSerialType.SelectedIndex = 1 Then

            Dim nombreDeJour As Integer = 0

            nombreDeJour = (GunaDateTimePicker2.Value - GunaDateTimePicker1.Value).TotalDays()

            GunaTextBoxNumberDays.Text = nombreDeJour

            Dim index As Integer = GunaComboBoxSerialType.SelectedIndex
            Dim dateDebut As Date = GunaDateTimePicker1.Value
            Dim dateFin As Date = GunaDateTimePicker2.Value
            Dim nombreDeConnexion As Integer = GunaTextBoxNumberOfConnect.Text

            GunaTextBoxSerialGenerated.Text = creationDelaCodeAChiffrer(index, dateDebut, dateFin, nombreDeConnexion, nombreDeJour)

        Else
            GunaTextBoxNumberDays.Text = 0
        End If

    End Sub

    Shared random As New Random()

    Private Sub GunaTextBoxNumberOfConnect_TextChanged(sender As Object, e As EventArgs) Handles GunaTextBoxNumberOfConnect.TextChanged

        GunaTextBoxSerialGenerated.Clear()

        Dim index As Integer = GunaComboBoxSerialType.SelectedIndex
        Dim dateDebut As Date = GunaDateTimePicker1.Value
        Dim dateFin As Date = GunaDateTimePicker2.Value

        If Trim(GunaTextBoxNumberOfConnect.Text).Equals("") Then
            GunaTextBoxNumberOfConnect.Text = 0
        End If

        Dim nombreDeConnexion As Integer = GunaTextBoxNumberOfConnect.Text

        Dim nombreDeJour As Integer = 0

        nombreDeJour = (GunaDateTimePicker2.Value - GunaDateTimePicker1.Value).TotalDays()

        GunaTextBoxSerialGenerated.Text = creationDelaCodeAChiffrer(index, dateDebut, dateFin, nombreDeConnexion, nombreDeJour)

    End Sub

    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Me.Close()
    End Sub

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub GunaButton1_Click_1(sender As Object, e As EventArgs) Handles GunaButton1.Click

        GunaTextBox6.Text = renversementDeLaChaine(GunaTextBoxSerialGenerated.Text)

    End Sub

    Private Sub generateSerial(ByVal chaineAChiffrer As String)

        Dim chaineARetourner As String = ""

        Dim j As Integer = 1
        Dim k As Integer = 1

        For i = 0 To chaineAChiffrer.Length - 1

            chaineARetourner = chaineARetourner + chaineAChiffrer(i)

            If k Mod 5 = 0 Then

                If j = 1 Then

                    GunaTextBox5.Text = chaineARetourner
                    chaineARetourner = ""
                    j += 1

                ElseIf j = 2 Then

                    GunaTextBox4.Text = chaineARetourner
                    chaineARetourner = ""
                    j += 1

                ElseIf j = 3 Then

                    GunaTextBox3.Text = chaineARetourner
                    chaineARetourner = ""
                    j += 1

                ElseIf j = 4 Then

                    GunaTextBox2.Text = chaineARetourner
                    chaineARetourner = ""
                    j += 1

                ElseIf j = 5 Then

                    GunaTextBox1.Text = chaineARetourner
                    chaineARetourner = ""
                    j += 1

                End If

            End If

            k += 1

        Next

    End Sub

    Private Sub GunaButtonGetSerial_Click(sender As Object, e As EventArgs) Handles GunaButtonGetSerial.Click

        GunaTextBoxSerialType.Clear()
        GunaTextBoxNumber.Clear()
        GunaTextBoxDateDebut.Clear()
        GunaTextBoxDateFin.Clear()

        GunaTextBox6.Clear()
        GunaTextBox7.Clear()
        GunaTextBox8.Clear()
        GunaTextBox9.Clear()

        Dim chaineAChiffrer As String = GunaTextBoxSerialGenerated.Text

        generateSerial(chaineAChiffrer)

    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click

        Dim serialKey As String = ""

        serialKey = GunaTextBox5.Text & "" & GunaTextBox4.Text & "" & GunaTextBox3.Text & "" & GunaTextBox2.Text & "" & GunaTextBox1.Text & ""

        GunaTextBox7.Text = renversementDeLaChaine(serialKey)

    End Sub

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click

        Dim serialKey As String = ""

        serialKey = GunaTextBox5.Text & "" & GunaTextBox4.Text & "" & GunaTextBox3.Text & "" & GunaTextBox2.Text & "" & GunaTextBox1.Text & ""

        GunaTextBox8.Text = retranchementDeCaractere(renversementDeLaChaine(serialKey))

    End Sub

    Private Sub GunaButton4_Click(sender As Object, e As EventArgs) Handles GunaButton4.Click

        Dim serialKey As String = ""
        Dim originalString As String = ""

        serialKey = GunaTextBox5.Text & "" & GunaTextBox4.Text & "" & GunaTextBox3.Text & "" & GunaTextBox2.Text & "" & GunaTextBox1.Text & ""

        originalString = retranchementDeCaractere(renversementDeLaChaine(serialKey))

        GunaTextBox9.Text = insertionDeSeparateur(originalString)

        Dim extractedChaine As String = insertionDeSeparateur(originalString)

        Dim exploitArr As String() = extractionDesDonnees(extractedChaine)

        If Not Trim(GunaTextBox1.Text).Equals("") Then

            GunaTextBoxSerialType.Text = Integer.Parse(exploitArr(0))

            GunaTextBoxDateDebut.Text = transformStringIntoDate(exploitArr(1))

            GunaTextBoxDateFin.Text = transformStringIntoDate(exploitArr(2))

            GunaTextBoxNumber.Text = Integer.Parse(exploitArr(3))

        End If

    End Sub

    Private Function insertionDeSeparateur(ByVal originalString As String)

        Dim extractedChaine As String = ""

        For i = 0 To originalString.Length - 1

            extractedChaine = extractedChaine + originalString(i)

            If i = 0 Then
                extractedChaine = extractedChaine & "-"
            ElseIf i = 8 Then
                extractedChaine = extractedChaine & "-"
            ElseIf i = 16 Then
                extractedChaine = extractedChaine & "-"
            End If

        Next

        Return extractedChaine

    End Function

    Private Function extractionDesDonnees(ByVal extractedChaine As String) As String()

        Dim strArr() As String

        strArr = extractedChaine.Split("-")

        Return strArr

    End Function

    Private Function transformStringIntoDate(ByVal dateChaine As String) As Date

        Dim dateFormat As String = ""

        For i = 0 To dateChaine.Length - 1

            dateFormat = dateFormat + dateChaine(i)

            If i = 1 Then
                dateFormat = dateFormat & "/"
            ElseIf i = 3 Then
                dateFormat = dateFormat & "/"
            End If

        Next

        Return CDate(dateFormat).ToShortDateString

    End Function

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked Then
            GunaDateTimePicker1.Enabled = True
        Else
            GunaDateTimePicker1.Enabled = False
        End If

    End Sub

End Class
