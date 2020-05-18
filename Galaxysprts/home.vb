Public Class home

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim frm As New Long
        Me.ProgressBar1.BackColor = Color.Black
        Me.ProgressBar1.Value = Me.ProgressBar1.Value + 25
        If Me.ProgressBar1.Value >= 100 Then
            login.Show()
            Timer1.Enabled = False
            Me.Hide()
        End If
    End Sub

    Private Sub home_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class