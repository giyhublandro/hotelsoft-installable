Public Class ProgressForm
    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        GunaCircleProgressBar1.Value = 0
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        GunaCircleProgressBar1.Increment(1)
    End Sub

    Private Sub GunaWinSwitch1_CheckedChanged(sender As Object, e As EventArgs) Handles GunaWinSwitch1.CheckedChanged
        GunaCircleProgressBar1.Animated = GunaWinSwitch1.Checked
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    End Sub

    Private Sub ProgressForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class