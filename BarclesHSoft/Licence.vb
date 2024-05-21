Imports MySql.Data.MySqlClient
Imports System.Data.Odbc
Imports System.IO

Public Class Licence

    Public Sub gestionDesLicence()

        Dim licence As DataTable = Functions.allTableFields("licence")

        Dim languageMessage As String = ""

        If licence.Rows.Count > 0 Then

            If licence.Rows(0)("CODE_LICENCE") = "DEFAULT" Then
                'GESTION DE LA LICENCE PAR DEFAUT

                Dim NC As Integer = licence.Rows(0)("NC")

                Dim s As String = ""

                If NC > 1 Then
                    s = "s"
                End If

                'ON DETERMINE LE MOMENT QU'ON DOIT AVOIR LE COMPTE A REBOURS CONCERNANT LE NOMBRE DE CONNEXION RESTANTE

                If NC <= 10 Then

                    'ActivationForm.Close()
                    ActivationForm.Show()
                    ActivationForm.TopMost = True

                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageMessage = "Remanining " & NC & " running of HOTEL SOFT. " & Chr(13) & "Please contact us on 695-04-35-76 for activation"
                    Else
                        languageMessage = "Il vous manque " & NC & " exécution" & s & " de HOTEL SOFT. " & Chr(13) & "Bien vouloir nous contacter au 695-04-35-76 pour l'activation"
                    End If

                    ActivationForm.GunaTextBoxMessage.Text = languageMessage

                End If

            Else

                'GESTION DES AUTRES TYPE DE LICENCES

                Dim serialKey As String = licence.Rows(0)("CODE_LICENCE")
                Dim NC As Integer = licence.Rows(0)("NC")

                If Not licenceVerification(serialKey) Then 'LICENCE NON VALIDE

                    'MAUVAISE CLE D'ACTIVATION

                    ActivationForm.Show()
                    ActivationForm.TopMost = True

                    If GlobalVariable.actualLanguageValue = 0 Then
                        languageMessage = "Type a correct Serial key for HOTEL SOFT. " & Chr(13) & "Please contact us on 695-04-35-76 for Activation"
                    Else
                        languageMessage = "Saisir un clé d'activation correcte pour HOTEL SOFT. " & Chr(13) & "Bien vouloir nous contacter au 695-04-35-76 pour l'activation"
                    End If

                    ActivationForm.GunaTextBoxMessage.Text = languageMessage

                    If GlobalVariable.actualLanguageValue = 0 Then
                        AccueilForm.GunaButtonSeConnecter.Text = "ACTIVATE HOTEL SOFT"
                    ElseIf GlobalVariable.actualLanguageValue = 1 Then
                        AccueilForm.GunaButtonSeConnecter.Text = "ACTIVER HOTEL SOFT"
                    End If

                Else

                    'BONNE CLE D'ACTIVATION
                    'ON DOIT VERIFIER LA VALIDITE DE LA CLE

                    If Not licenceValidityVerification(serialKey, NC) Then 'LICENCE EXPIRE

                        'EN CAS DE NON VALIDITE DE LA LICENCE

                        ActivationForm.Show()
                        ActivationForm.TopMost = True

                        If GlobalVariable.actualLanguageValue = 0 Then
                            languageMessage = "Your activation key has already expired ! " & Chr(13) & "Please contact us on 695-04-35-76 for activation"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            languageMessage = "Votre clé d'activation a expirée ! " & Chr(13) & "Bien vouloir nous contacter au 695-04-35-76 pour l'activation"
                        End If

                        ActivationForm.GunaTextBoxMessage.Text = languageMessage

                        If GlobalVariable.actualLanguageValue = 0 Then
                            AccueilForm.GunaButtonSeConnecter.Text = "ACTIVATE HOTEL SOFT"
                        ElseIf GlobalVariable.actualLanguageValue = 1 Then
                            AccueilForm.GunaButtonSeConnecter.Text = "ACTIVER HOTEL SOFT"
                        End If

                    End If

                End If

            End If

        Else

            'AU CAS OU IL Y'A PAS DE LIGNE DE LICENCE ON BLOQUE LE LOGICIEL 

            If GlobalVariable.actualLanguageValue = 0 Then
                AccueilForm.GunaButtonSeConnecter.Text = "ACTIVATE HOTEL SOFT"
            ElseIf GlobalVariable.actualLanguageValue = 1 Then
                AccueilForm.GunaButtonSeConnecter.Text = "ACTIVER HOTEL SOFT"
            End If

        End If

    End Sub

    Public Sub reductionDeNombreDeDemarrageParDefaut(ByVal REDUCTION As Integer, ByVal CODE_LICENCE As String)

        Dim upDateQuery As String = "UPDATE `licence` SET `NC` = NC - @REDUCTION WHERE CODE_LICENCE=@CODE_LICENCE"

        Dim command As New MySqlCommand(upDateQuery, GlobalVariable.connect)

        command.Parameters.Add("@CODE_LICENCE", MySqlDbType.VarChar).Value = CODE_LICENCE
        command.Parameters.Add("@REDUCTION", MySqlDbType.Int64).Value = REDUCTION

        command.ExecuteNonQuery()

    End Sub

    Public Sub insertionDelaLicenceParDefaut()

        Dim insertQuery As String = "INSERT INTO `licence` (`NC`, `CODE_LICENCE`) VALUES (10, @value1)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)
        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = "DEFAULT"

        command.ExecuteNonQuery()

    End Sub

    Public Function creationDeLaTableDeLicence() As Boolean

        Dim createQuery As String = "CREATE TABLE IF NOT EXISTS `licence` (
            `ID_LICENCE` int(11) NOT NULL AUTO_INCREMENT,
             `NC` int(100) NOT NULL,
             `CODE_LICENCE` varchar(30) NOT NULL DEFAULT 'DEFAULT',
             PRIMARY KEY (`ID_LICENCE`)
        )"

        Dim commandCreate As New MySqlCommand(createQuery, GlobalVariable.connect)

        commandCreate.ExecuteNonQuery()

        Dim defaultLicence As DataTable = Functions.allTableFields("licence")

        Dim languageMessage As String = ""

        If defaultLicence.Rows.Count < 1 Then
            'ON INSERE LA LICENCE PAR DEFAUT DANS LA TABLE NOUVELLEMENT CREE
            insertionDelaLicenceParDefaut()
        Else

            '-----------------TRAITEMENT DE LA LICENCE PAR DEFAUT-------------------------

            'ON DECREMENTE LE NOMBRE DE CONNECTION EXISTANT

            Dim licenceDefault As DataTable = Functions.allTableFields("licence")

            If licenceDefault.Rows.Count > 0 Then

                If licenceDefault.Rows(0)("CODE_LICENCE") = "DEFAULT" Then

                    'ON NE DOIT PLUS DECREMENTE LORSQUE L'ON ATTEINT 0 
                    If licenceDefault.Rows(0)("NC") > 0 Then
                        reductionDeNombreDeDemarrageParDefaut(1, licenceDefault.Rows(0)("CODE_LICENCE"))
                    Else

                        If licenceDefault.Rows(0)("NC") = 0 Then

                            If GlobalVariable.actualLanguageValue = 0 Then
                                languageMessage = "ACTIVATE HOTEL SOFT"
                            Else
                                languageMessage = "ACTIVER HOTEL SOFT"
                            End If

                            AccueilForm.GunaButtonSeConnecter.Text = languageMessage

                        End If

                    End If

                End If

            Else

                'TRAITEMENT DES AUTRES TYPE DE LICENCE


            End If

            '----------------------------------------------------------------------------

        End If

    End Function

    '-------------------------------- GESTION DES ACTIVATIONS --------------------------------------------

    Public Function renversementDeLaChaine(ByVal chaineAChiffrer As String) As String

        Dim chaineRenverse As String = ""

        For i = chaineAChiffrer.Length - 1 To 0 Step -1
            chaineRenverse = chaineRenverse + chaineAChiffrer(i)
        Next

        Return chaineRenverse

    End Function

    Public Function transformStringIntoDate(ByVal dateChaine As String) As Date

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

    Public Function formatDeDateCorrect(ByVal dateChaine As String) As Boolean

        Dim dateFormat As String = ""
        Dim dateFormatCorrect As Boolean = True

        For i = 0 To dateChaine.Length - 1

            dateFormat = dateFormat + dateChaine(i)

            If i = 1 Then
                dateFormat = dateFormat & "/"
            ElseIf i = 3 Then
                dateFormat = dateFormat & "/"
            End If

        Next

        Dim dateFormatArray As String()

        dateFormatArray = dateFormat.Split("/")

        'SI NOTRE TABLEAU DE CHAINE CONTIENT DES ELEMENTS

        If dateFormatArray.Count > 0 Then

            'ON PARCOURS CHAQUE ELEMENTS PUIS ON TESTE LES VALEURS DE CHAQUE VALEUR

            For i = 0 To dateFormatArray.Count - 1

                If i = 0 Then
                    'ON RECUPRE LE JOUR PUIS ON VERIFIE SI IL EST DANS LE BON INTERVAL
                    Dim jour As Integer = Integer.Parse(dateFormatArray(i))

                    If Not (jour >= 1 And jour <= 31) Then
                        Return False
                    End If

                ElseIf i = 1 Then

                    'ON RECUPRE LE MOIS PUIS ON VERIFIE SI IL EST DANS LE BON INTERVAL
                    Dim mois As Integer = Integer.Parse(dateFormatArray(i))

                    If Not (mois >= 1 And mois <= 12) Then
                        Return False
                    End If

                ElseIf i = 2 Then

                    'ON RECUPRE L'ANNEE PUIS ON VERIFIE SI IL EST DANS LE BON INTERVAL
                    Dim annee As Integer = Integer.Parse(dateFormatArray(i))

                    If Not (annee >= 2022 And annee <= 3000) Then
                        Return False
                    End If

                End If

            Next

        Else
            Return False
        End If

        Return dateFormatCorrect

    End Function

    Public Function extractionDesDonnees(ByVal extractedChaine As String) As String()

        Dim strArr() As String

        strArr = extractedChaine.Split("-")

        Return strArr

    End Function

    Public Function insertionDeSeparateur(ByVal originalString As String)

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

    Public Sub insertionDeNouvelleCle(ByVal CODE_LICENCE As String, ByVal NC As Integer)

        Functions.deleteAll("licence")

        Dim insertQuery As String = "INSERT INTO `licence` (`NC`, `CODE_LICENCE`) VALUES (@NC, @value1)"

        Dim command As New MySqlCommand(insertQuery, GlobalVariable.connect)
        command.Parameters.Add("@value1", MySqlDbType.VarChar).Value = CODE_LICENCE
        command.Parameters.Add("@NC", MySqlDbType.VarChar).Value = NC

        command.ExecuteNonQuery()

    End Sub

    Public Function licenceVerification(ByVal serialKey As String) As Boolean

        Dim license As New Licence()

        Dim originalString As String = ""

        Dim serialLenght As Integer = 0
        Dim longueurMaximale As Integer = 25

        serialLenght = serialKey.Length

        If Not Trim(serialKey).Equals("") Then

            If serialLenght = longueurMaximale Then

                '-VERIFICATION DE LA CONCORDANCES DES DONNEES VIA UNE EXTRACTION ET VERIFICATION DU CONTENU

                '1- MANIPULATION D'EXTRACTION 

                originalString = license.retranchementDeCaractere(license.renversementDeLaChaine(serialKey))

                Dim extractedChaine As String = license.insertionDeSeparateur(originalString)

                Dim extractArr As String() = license.extractionDesDonnees(extractedChaine)

                Dim serialType As Integer = Integer.Parse(extractArr(0))

                Dim periodeDebutString = extractArr(1)
                Dim periodeFinString = extractArr(2)

                Dim numberConnectionDaysLeft As Integer = Integer.Parse(extractArr(3))

                '1.1- ON DOIT SE RASSURE QUE LES CHAINES DE DATE EXTRAITES ONT UN FORMAT DE DATE CORRECT

                '1.1.1- ON VERIFIE LA CHAINE DATE DEBUT

                Dim formatDeDateCorrect As Boolean = license.formatDeDateCorrect(periodeDebutString)

                If formatDeDateCorrect Then

                    '1.1.2- ON VERIFIE LA CHAINE DATE FIN

                    formatDeDateCorrect = license.formatDeDateCorrect(periodeFinString)

                    If formatDeDateCorrect Then

                        'LE FORMAT DES DEUX CHAINES DE DATE SONT CORRECTS

                        '1.2- ON PEUT PROCEDER A LA CONVERSION DES CHAINES DE DATE EN DATE A PROPREMENT PARLER

                        Dim periodeDebut As Date = license.transformStringIntoDate(periodeDebutString).ToShortDateString

                        Dim periodeFin As Date = license.transformStringIntoDate(periodeFinString).ToShortDateString

                        '1.3- ON DETERMINE LA NATURE DE LA CLE D'ACTIVATION A FIN D'EFFECTUER LES VERIFICATIONS APPROPRIE

                        If serialType = 0 Then
                            'SERIAL KEY : NOMBRE DE CONNECTION
                            Dim jours As Integer = (periodeFin - periodeDebut).TotalDays()

                            If Not jours = 0 Then
                                'LES DATES NE CORRESPONDENT PAS 
                                Return False
                            End If

                        ElseIf serialType = 1 Then
                            'SERIAL KEY : PERIODIQUE
                            Dim duree As Integer = (periodeFin - periodeDebut).TotalDays()

                            If duree = 0 Then
                                'LES DATES NE CORRESPONDENT PAS 
                                Return False
                            Else
                                'ON SE RASSURE QUE LE NOMBRE DE JOUR EST > 0
                                If numberConnectionDaysLeft > 0 Then
                                    'ON SE RASSURE QUE LEL NOMBRE DE JOUR RESTANT N'EST EGAL  A LA DUREE
                                    If Not numberConnectionDaysLeft = duree Then
                                        Return False
                                    End If

                                Else
                                    Return False
                                End If

                            End If

                        ElseIf serialType = 2 Then
                            'SERIAL KEY : TRIAL
                        ElseIf serialType = 3 Then
                            'SERIAL KEY : PREMIUM
                        End If

                    Else
                        'LE FORMAT DE DATE DE FIN EST INCORRECTE 
                        Return False
                    End If

                Else
                    'LE FORMAT DE DATE DE DEBUT EST INCORRECTE 
                    Return False
                End If

            Else
                Return False
            End If

        Else
            Return False
        End If

        Return True

    End Function

    Public Function licenceValidityVerification(ByVal serialKey As String, Optional ByVal NC As Integer = 0) As Boolean

        Dim originalString As String = ""

        originalString = retranchementDeCaractere(renversementDeLaChaine(serialKey))

        Dim extractedChaine As String = insertionDeSeparateur(originalString)

        Dim extractArr As String() = extractionDesDonnees(extractedChaine)

        Dim periodeDebut As Date = transformStringIntoDate(extractArr(1)).ToShortDateString

        Dim periodeFin As Date = transformStringIntoDate(extractArr(2)).ToShortDateString

        Dim serialType As Integer = Integer.Parse(extractArr(0))

        Dim numberConnectionDaysLeft As Integer = Integer.Parse(extractArr(3))

        If serialType = 0 Then
            'SERIAL KEY : NOMBRE DE CONNECTION

            If NC <= 0 Then
                Return False
            End If

        ElseIf serialType = 1 Then
            'SERIAL KEY : PERIODIQUE
            Dim duree As Integer = (periodeFin - periodeDebut).TotalDays()
            Dim dateDeTravail As Date = Convert.ToDateTime(Functions.ObtenirDateDeTravail()).ToShortDateString

            'ON VERIFIE SI LA DATE DE TRAVAIL EST > A LA DATE DE FIN DE LA CLE D'ACTIVATION
            Dim d1 As Integer = (dateDeTravail - periodeFin).TotalDays()

            'ON VERIFIE SI LA DATE DE TRAVAIL EST > A LA DATE DE DEBUT DE LA CLE D'ACTIVATION
            Dim d2 As Integer = (periodeDebut - dateDeTravail).TotalDays()

            'AccueilForm.GunaLabelTitle.Text = periodeFin & " - " & periodeDebut & " - " & dateDeTravail & " d1 : " & d1 & " d2 : " & d2

            If d1 > 0 Then
                Return False
            End If

            If d2 > 0 Then
                Return False
            End If

        ElseIf serialType = 2 Then
            'SERIAL KEY : TRIAL
        ElseIf serialType = 3 Then
            'SERIAL KEY : PREMIUM
        End If

        Return True

    End Function

    Dim languageMessage As String = ""
    Dim languageTitle As String = ""

    Private Sub errorMessage()

        If GlobalVariable.actualLanguageValue = 0 Then
            languageMessage = "The Serial Key is incorrect !!"
            languageTitle = "Hotel Soft Activation"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            languageMessage = "Mauvaise Clé d'Activation"
            languageTitle = "Activation Hotel Soft"
        End If

        MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)

    End Sub

    Private Sub successMessage(ByVal serialKey As String)

        Dim license As New Licence()

        If GlobalVariable.actualLanguageValue = 0 Then
            languageMessage = "Hotel Soft activated successfully"
            languageTitle = "Hotel Soft Activation"
        ElseIf GlobalVariable.actualLanguageValue = 1 Then
            languageMessage = "Hotel Soft activé avec succès"
            languageTitle = "Activation Hotel Soft"
        End If

        MessageBox.Show(languageMessage, languageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

End Class
