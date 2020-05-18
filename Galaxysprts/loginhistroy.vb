Imports System.Data.SqlClient
Public Class loginhistroy
    Dim adp As New SqlClient.SqlDataAdapter
    Dim dt As New DataTable
    Private Sub loginhistroy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Try
            all_connect()
            cmd.CommandText = "select * from histroy"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Me.DataGridView1.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.close()
        End Try
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        MDIparent1.show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            all_connect()
            cmd.CommandText = "delete from histroy"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Me.DataGridView1.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
End Class