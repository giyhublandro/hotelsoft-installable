Imports MySql.Data.MySqlClient

Public Class TablesForm

    Structure Tables

        Dim NUMERO_TABLE As Integer
        Dim MONTANT As Double

    End Structure



    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs) Handles GunaImageButton1.Click
        Me.Close()
    End Sub

    Private Sub GunaImageButton2_Click(sender As Object, e As EventArgs) Handles GunaImageButton2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub TablesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tablesManager()

    End Sub

    Public Sub tablesManager()

        If True Then

            Dim xValue As Integer = 0

            Dim yValue As Integer = -27

            Dim query4 = "SELECT * FROM `tables` ORDER BY TABLE_NAME ASC"

            Dim command4 As New MySqlCommand(query4, GlobalVariable.connect)

            Dim adapter4 As New MySqlDataAdapter(command4)
            Dim dt As New DataTable()
            adapter4.Fill(dt)

            If dt.Rows.Count > 0 Then

                For i As Integer = 0 To dt.Rows.Count - 1 Step 1

                    Dim nomCLient As String = ""
                    Dim emailCLient As String = ""

                    Dim toolTip As New ToolTip()

                    Dim buttonColor As Color = Color.ForestGreen
                    Dim textColor As Color = Color.White
                    Dim ClientInRoom As DataTable

                    'ddHandlercustomPanel.Click, AddressOf Update
                    '1- GRAND CADRE
                    Dim customPanel As New Panel
                    customPanel.Text = "Test" & i
                    customPanel.Name = "a" & i
                    customPanel.Location = New Point(5 + xValue, 35 + yValue)
                    customPanel.BackColor = buttonColor
                    customPanel.ForeColor = textColor
                    'customPanel.Size = New Size(75, 103)
                    customPanel.Size = New Size(200, 80)
                    customPanel.Anchor = AnchorStyles.None

                    Dim customLabel1 As New Label

                    '3- MONTANT TABLE
                    customLabel1.AutoSize = True
                    customLabel1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    customLabel1.Location = New System.Drawing.Point(65, 45)
                    customLabel1.Name = "customLabel"
                    customLabel1.BorderStyle = BorderStyle.None
                    customLabel1.Size = New System.Drawing.Size(45, 65)
                    customLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    customLabel1.TabIndex = 4

                    Dim customComboBox As New ComboBox

                    '2- COMBOBOX
                    customComboBox.AutoSize = True
                    customComboBox.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    customComboBox.Location = New System.Drawing.Point(5, 0)
                    customComboBox.Name = dt.Rows(i)("TABLE_NAME")
                    customComboBox.Size = New System.Drawing.Size(190, 65)

                    Dim blocnotes As DataTable

                    '------------------------------------------
                    Dim caisse As New Caisse()
                    Dim tables As New Tables

                    'On charge La liste des commandes ou NUMERO_DE_BLOC_NOTE contenant Toutes les commandes a cloturer et a regler par apport a un caissier et un a la date de travail

                    Dim ETAT_BLOC_NOTE As Integer = 0 'NON CLOTURER

                    Dim DateDeSituation As Date = CDate(GlobalVariable.DateDeTravail).ToShortDateString
                    Dim CODE_CAISSIER As String = GlobalVariable.ConnectedUser.Rows(0)("CODE_UTILISATEUR")

                    'C- VISUALISATION DE LA LISTE DES BLOC NOTES

                    Dim blocNoteAvisualiser As DataTable = caisse.AutoLoadBlocNoteVisualisationClass(DateDeSituation, CODE_CAISSIER, ETAT_BLOC_NOTE)

                    ETAT_BLOC_NOTE = 1 'CLOTURE DONC A REGLER
                    Dim blocNoteAvisualiser2 As DataTable = caisse.AutoLoadBlocNoteVisualisationClass(DateDeSituation, CODE_CAISSIER, ETAT_BLOC_NOTE)

                    blocNoteAvisualiser.Merge(blocNoteAvisualiser2)

                    Dim NOMBRE_DE_TABLE As Integer = GlobalVariable.AgenceActuelle.Rows(0)("NOMBRE_DE_TABLE")
                    Dim MONTANT As Double = 0

                    Dim listeDesTables(NOMBRE_DE_TABLE) As Tables

                    Dim colorisation_1 As Color = Color.White

                    If blocNoteAvisualiser.Rows.Count > 0 Then

                        customComboBox.Items.Clear()

                        MONTANT = 0

                        For s = 0 To blocNoteAvisualiser.Rows.Count - 1

                            Dim parts As String()

                            Dim NUMERO_BLOC_NOTE As String = ""

                            If GlobalVariable.actualLanguageValue = 0 Then
                                parts = blocNoteAvisualiser.Rows(s)("RECEIPT NUMBER").Split("-")
                                NUMERO_BLOC_NOTE = blocNoteAvisualiser.Rows(s)("RECEIPT NUMBER")
                            Else
                                parts = blocNoteAvisualiser.Rows(s)("NUMERO BLOC NOTE").Split("-")
                                NUMERO_BLOC_NOTE = blocNoteAvisualiser.Rows(s)("NUMERO BLOC NOTE")
                            End If
                            ' If Integer.Parse(parts(1)) = t Then

                            If Trim(dt.Rows(i)("TABLE_NAME")).Equals(Trim(parts(1))) Then

                                If GlobalVariable.actualLanguageValue = 0 Then
                                    MONTANT += blocNoteAvisualiser.Rows(s)("AMOUNT")
                                ElseIf GlobalVariable.actualLanguageValue = 1 Then
                                    MONTANT += blocNoteAvisualiser.Rows(s)("MONTANT")
                                End If

                                customComboBox.Items.Add(NUMERO_BLOC_NOTE)
                                If customComboBox.Items.Count > 0 Then
                                    customComboBox.SelectedIndex = 0
                                End If
                            End If

                        Next

                        customLabel1.Text = Format(MONTANT, "#,##0") & " " & GlobalVariable.societe.Rows(0)("CODE_MONNAIE")

                    End If

                    customPanel.Controls.Add(customLabel1)

                    AddHandler customComboBox.SelectedIndexChanged, AddressOf onSelectedIndexChange
                    'AddHandler customPanel.Click, AddressOf OnClick

                    '------------------------------------------

                    customPanel.Controls.Add(customComboBox)

                    'customComboBox.SelectedIndex = 0

                    Dim customLabel As New Label

                    '2- NUMERO TABLE
                    customLabel.AutoSize = True
                    customLabel.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    customLabel.Location = New System.Drawing.Point(0, 45)
                    customLabel.Name = "customLabel"
                    customLabel.Size = New System.Drawing.Size(45, 65)
                    customLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    customLabel.TabIndex = 4
                    customLabel.Text = dt.Rows(i)("TABLE_NAME")

                    customPanel.Controls.Add(customLabel)

                    Dim customLabel2 As New Label
                    '2- HEURE TABLE
                    customLabel2.AutoSize = True
                    customLabel2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    customLabel2.Location = New System.Drawing.Point(55, 30)
                    customLabel2.Name = dt.Rows(i)("TABLE_NAME") & "time"
                    customLabel2.BorderStyle = BorderStyle.None
                    customLabel2.Size = New System.Drawing.Size(45, 60)
                    customLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    customLabel2.TabIndex = 4
                    customLabel2.Text = "12:30:45"

                    customPanel.Controls.Add(customLabel2)
                    TabPageManager.Controls.Add(customPanel)

                    toolTip.ShowAlways = True

                    toolTip.UseFading = True
                    toolTip.UseAnimation = True
                    toolTip.IsBalloon = True
                    toolTip.AutoPopDelay = 5000

                    xValue = xValue + 225

                    'alignement 
                    If (i + 1) Mod 5 = 0 Then
                        xValue = 0
                        yValue = yValue + 85
                    End If

                    If i = 34 Then
                        Exit For
                    End If

                Next

            End If

        End If

    End Sub


    Public Function heureBlocNotte(ByVal NUMERO_BLOC_NOTE As String)

        Dim blocNote As DataTable = Functions.getElementByCode(NUMERO_BLOC_NOTE, "ligne_facture_bloc_note", "NUMERO_BLOC_NOTE")
        Dim HEURE As String = ""
        If blocNote.Rows.Count > 0 Then
            HEURE = CDate(blocNote.Rows(0)("DATE_DE_CONTROLE")).ToLongTimeString
        End If

        Return HEURE

    End Function

    Private Sub onSelectedIndexChange(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim comboBox As ComboBox = CType(sender, ComboBox)
        Dim newLabel As New Label

        If comboBox.Items.Count > 0 Then

            Dim NUMERO_BLOC_NOTE As String = ""
            Dim TABLE_NAME As String = ""
            Dim parts As String()

            If comboBox.SelectedIndex >= 0 Then
                NUMERO_BLOC_NOTE = comboBox.SelectedItem
                parts = NUMERO_BLOC_NOTE.Split("-")
                TABLE_NAME = parts(1)
                newLabel.Text = heureBlocNotte(NUMERO_BLOC_NOTE)
            Else
                newLabel.Name = TABLE_NAME & "time"
                newLabel.Text = ""
            End If

        End If

    End Sub

End Class