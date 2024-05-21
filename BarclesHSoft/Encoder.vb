Public Class Encoder

    'Declare Unicode Function StartSession Lib "LockDll_64.dll" (ByVal LockCard As Integer, ByVal DBServer As String, ByVal LogUser As String, ByVal DBFlag As Integer) As Integer

    'Declare Unicode Function EndSession Lib "LockDll_64.dll" () As Integer

    'Declare Unicode Function ChangeLogUser Lib "LockDll_64.dll" (ByVal LogUser As String) As Integer

    'Declare Unicode Function NewKey Lib "LockDll_64.dll" (ByVal Port As Integer, ByVal RoomNo As String, ByVal CommonDoor As String, ByVal LiftFloor As String, ByVal TimeStr As String, ByVal Holder As String, ByVal IDNo As String, ByVal breakfast As Integer, ByVal overflag As Integer, ByRef CardNo As Integer) As Integer

    'Declare Unicode Function AddKey Lib "LockDll_64.dll" (ByVal Port As Integer, ByVal RoomNo As String, ByVal CommonDoor As String, ByVal LiftFloor As String, ByVal TimeStr As String, ByVal Holder As String, ByVal IDNo As String, ByVal breakfast As Integer, ByVal overflag As Integer, ByRef CardNo As Integer) As Integer

    'Declare Unicode Function DupKey Lib "LockDll_64.dll" (ByVal Port As Integer, ByVal RoomNo As String, ByVal CommonDoor As String, ByVal LiftFloor As String, ByVal TimeStr As String, ByVal Holder As String, ByVal IDNo As String, ByVal breakfast As Integer, ByVal overflag As Integer, ByRef CardNo As Integer) As Integer

    'Declare Unicode Function ReadKeyCard Lib "LockDll_64.dll" (ByVal Port As Integer, ByVal RoomNo As String, ByVal CommonDoor As String, ByVal LiftFloor As String, ByVal TimeStr As String, ByVal Holder As String, ByVal IDNo As String, ByRef CardNo As Integer, ByRef CardStatus As Integer, ByRef breakfast As Integer) As Integer

    'Declare Unicode Function EraseKeyCard Lib "LockDll_64.dll" (ByVal Port As Integer, ByVal CardNo As Integer) As Integer

    'Declare Unicode Function CheckOut Lib "LockDll_64.dll" (ByVal RoomNo As String, ByVal CardNo As Integer) As Integer

    'Declare Unicode Function ReadCardID Lib "LockDll_64.dll" (ByVal Port As Integer, ByVal dwCardId As Integer) As Integer

    Private Declare Function StartSession Lib "LockDll.Dll" (ByVal Software As Integer, ByVal DBServer As String, ByVal LogUser As String, ByVal DBFlag As Integer) As Integer
    Private Declare Function EndSession Lib "LockDll.Dll" () As Integer
    Private Declare Function ChangeLogUser Lib "LockDll.Dll" (ByVal LogUser As String) As Integer

    Private Declare Function NewKey Lib "LockDll.Dll" (ByVal Port As Integer, ByVal RoomNo As String, ByVal Door As String, ByVal Floor As String, ByVal TimeStr As String, ByVal Holder As String, ByVal IDNo As String, ByVal breakfast As Integer, ByVal overflag As Integer, ByVal CardNo As Integer) As Integer
    Private Declare Function AddKey Lib "LockDll.Dll" (ByVal Port As Integer, ByVal RoomNo As String, ByVal Door As String, ByVal Floor As String, ByVal TimeStr As String, ByVal Holder As String, ByVal IDNo As String, ByVal breakfast As Integer, ByVal overflag As Integer, ByVal CardNo As Integer) As Integer
    Private Declare Function DupKey Lib "LockDll.Dll" (ByVal Port As Integer, ByVal RoomNo As String, ByVal Door As String, ByVal Floor As String, ByVal TimeStr As String, ByVal Holder As String, ByVal IDNo As String, ByVal breakfast As Integer, ByVal overflag As Integer, ByVal CardNo As Integer) As Integer

    'Private Declare Function ReadKeyCard Lib "LockDll.Dll" (ByVal Port As Integer, ByVal RoomNo As String, ByVal Gate As String, ByVal TimeStr As String, ByVal Holder As String, ByVal IDNo As String, ByVal CardNo As Integer, ByVal ByValCardStatus As Integer, ByVal breakfast As Integer) As Integer

    Private Declare Function ReadKeyCard Lib "LockDll.Dll" (ByVal Port As Integer, ByVal RoomNo As String, ByVal Door As String, ByVal Floor As String, ByVal TimeStr As String, ByVal Holder As String, ByVal IDNo As String, ByVal CardNo As Integer, ByVal ByValCardStatus As Integer, ByVal breakfast As Integer) As Integer

    Private Declare Function EraseKeyCard Lib "LockDll.Dll" (ByVal Port As Integer, ByVal cardno As Integer) As Integer
    Private Declare Function CheckOut Lib "LockDll.Dll" (ByVal RoomNo As String, ByVal CardNo As Integer) As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CB_Software.SelectedIndex = 0
        CB_Port.SelectedIndex = 0
        CB_Breakfast.SelectedIndex = 1
        CB_DB.SelectedIndex = 0

        TB_Time.Text = DateTime.Now.ToString("yyyyMMdd1200") + DateTime.Now.AddDays(1).ToString("yyyyMMdd1200")

    End Sub

    Private Sub B_Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Start.Click
        Dim server As String
        Dim user As String
        Dim LockSoftware As Integer
        Dim lStatus As Integer
        Dim db_flag As Long

        server = tb_server.Text
        user = "DllUser"
        LockSoftware = CB_Software.SelectedIndex + 1

        TB_Result.Text = "Executing..."
        db_flag = CB_DB.SelectedIndex
        TB_Result.Refresh()

        lStatus = StartSession(LockSoftware, server, user, CB_DB.SelectedIndex)
        'lStatus = StartSession(LockSoftware, server, user, db_flag)

        TB_Result.Text = lStatus.ToString("X")
    End Sub

    Private Sub B_End_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_End.Click
        Dim lStatus As Integer

        TB_Result.Text = "Executing..."

        TB_Result.Refresh()

        lStatus = EndSession()

        TB_Result.Text = lStatus.ToString("X")

    End Sub

    Private Sub B_NewKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_NewKey.Click
        Dim lStatus As Integer
        Dim Port As Integer
        Dim CardNo As Integer
        Dim OverFlag As Integer
        Dim Breakfast As Integer
        Dim RoomNo As String
        Dim Holder As String
        Dim IDNo As String
        Dim TimeStr As String

        Port = CB_Port.SelectedIndex

        If (CK_Over.Checked) Then
            OverFlag = 1
        Else
            OverFlag = 0
        End If

        Breakfast = CB_Breakfast.SelectedIndex

        RoomNo = TB_RoomNo.Text
        Holder = TB_Holder.Text
        IDNo = TB_IDNo.Text
        TimeStr = TB_Time.Text
        CardNo = 0

        TB_Result.Text = "Executing..."
        TB_Result.Refresh()

        lStatus = NewKey(Port, RoomNo, "", "", TimeStr, Holder, IDNo, Breakfast, OverFlag, CardNo)

        TB_Result.Text = lStatus.ToString("X")

        If (lStatus = 0) Then
            TB_CardNo.Text = CardNo.ToString()
        End If
    End Sub

    Private Sub B_DupKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_DupKey.Click
        Dim lStatus As Integer
        Dim Port As Integer
        Dim CardNo As Integer
        Dim OverFlag As Integer
        Dim Breakfast As Integer
        Dim RoomNo As String
        Dim Holder As String
        Dim IDNo As String
        Dim TimeStr As String

        Port = CB_Port.SelectedIndex

        If (CK_Over.Checked) Then
            OverFlag = 1
        Else
            OverFlag = 0
        End If

        Breakfast = CB_Breakfast.SelectedIndex

        RoomNo = TB_RoomNo.Text
        Holder = TB_Holder.Text
        IDNo = TB_IDNo.Text
        TimeStr = TB_Time.Text
        CardNo = 0

        TB_Result.Text = "Executing..."
        TB_Result.Refresh()

        lStatus = DupKey(Port, RoomNo, "", "", TimeStr, Holder, IDNo, Breakfast, OverFlag, CardNo)

        TB_Result.Text = lStatus.ToString("X")

        If (lStatus = 0) Then
            TB_CardNo.Text = CardNo.ToString()
        End If

    End Sub

    Private Sub B_ReadKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_ReadKey.Click
        Dim lStatus As Integer
        Dim Port As Integer
        Dim CardNo As Integer
        Dim CardStatus As Integer
        Dim Breakfast As Integer

        Dim RoomNo As String
        Dim Holder As String
        Dim IDNo As String
        Dim TimeStr As String
        Dim Door As String
        Dim lift As String

        RoomNo = New String("", 64)
        Holder = New String("", 64)
        IDNo = New String("", 64)
        TimeStr = New String("", 64)
        Door = New String("", 128)
        lift = New String("", 128)

        Port = CB_Port.SelectedIndex

        CardNo = 0
        CardStatus = 0
        Breakfast = 0

        TB_Result.Text = "Executing..."
        TB_Result.Refresh()

        lStatus = ReadKeyCard(Port, RoomNo, Door, lift, TimeStr, Holder, IDNo, CardNo, CardStatus, Breakfast)

        'TB_Result.Text = Hex(lStatus)
        TB_Result.Text = lStatus.ToString("X")

        'lStatus = ReadKeyCard(Port, RoomNo, Door, lift, TimeStr, Holder, IDNo, CardNo, CardStatus, Breakfast)

        'TB_Result.Text = lStatus.ToString("X")

        If (lStatus = 0) Then
            TB_CardNo.Text = CardNo.ToString()
            TB_Status.Text = CardStatus.ToString()
            CB_Breakfast.SelectedIndex = Breakfast

            TB_RoomNo.Text = RoomNo.ToString()
            TB_Holder.Text = Holder.ToString()
            TB_IDNo.Text = IDNo.ToString()
            TB_Time.Text = TimeStr.ToString()
        End If

    End Sub

    Private Sub B_EraseKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_EraseKey.Click
        Dim lStatus As Integer
        Dim Port As Integer
        Dim CardNo As Integer

        Port = CB_Port.SelectedIndex

        If IsNumeric(TB_CardNo.Text) Then
            CardNo = Val(TB_CardNo.Text)
        Else
            CardNo = 0
        End If

        TB_Result.Text = "Executing..."
        TB_Result.Refresh()

        lStatus = EraseKeyCard(Port, CardNo)

        TB_Result.Text = lStatus.ToString("X")

    End Sub

    Private Sub B_CheckOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_CheckOut.Click
        Dim lStatus As Integer
        Dim CardNo As Integer
        Dim RoomNo As String

        If IsNumeric(TB_CardNo.Text) Then
            CardNo = Val(TB_CardNo.Text)
        Else
            CardNo = 0
        End If

        RoomNo = TB_RoomNo.Text

        TB_Result.Text = "Executing..."
        TB_Result.Refresh()

        lStatus = CheckOut(RoomNo, CardNo)

        TB_Result.Text = lStatus.ToString("X")

    End Sub

    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        EndSession()
    End Sub

    Private Sub CB_DB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_DB.SelectedIndexChanged
        If (CB_DB.SelectedIndex = 0) Then
            If (CB_Software.SelectedIndex = 0) Then
                tb_server.Text = "C:\Users\hotelsoft\AppData\Local\VirtualStore\Program Files (x86)\Hotel\MHA\"
            Else
                tb_server.Text = "C:\Users\hotelsoft\AppData\Local\VirtualStore\Program Files (x86)\Hotel\MHA\"
            End If
        Else
            tb_server.Text = "(local)"
        End If

    End Sub

    Private Sub CB_Software_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB_Software.SelectedIndexChanged
        If (CB_DB.SelectedIndex = 0) Then
            If (CB_Software.SelectedIndex = 0) Then
                tb_server.Text = "C:\Users\hotelsoft\AppData\Local\VirtualStore\Program Files (x86)\Hotel\MHA\"
            Else
                tb_server.Text = "C:\Users\hotelsoft\AppData\Local\VirtualStore\Program Files (x86)\Hotel\MHA\"
            End If
        End If
    End Sub


End Class
