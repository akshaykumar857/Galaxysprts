Imports System.Data.SqlClient
Imports System.Data
Public Class Unblock
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim bds As New BindingSource
    Dim db As New DataTable
    Dim dt1 As New DataTable
    Dim rowindex As Integer
    Public Sub display()
        Try
            cnn.Close()
            all_connect()
            cmd.CommandText = "select user_type,user_name,password from Login where flag>=3"
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
    Private Sub Unblock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        display()
        If Me.DataGridView1.Rows.Count = 1 Then
            MsgBox("There are no Blocked Accounts....!!", MsgBoxStyle.Information, "load message")
            Me.Close()
        End If
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub UnblockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnblockToolStripMenuItem.Click
        Dim uname As String = Me.DataGridView1.Item(1, Me.rowindex).Value
        Try
            all_connect()
            cmd.CommandText = "update Login set flag=0 where user_type='Employee' and user_name='" & uname & "'"
            cmd.ExecuteNonQuery()
            MsgBox("the account has unblocked", MsgBoxStyle.Information, "block message")
            display()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub DataGridView1_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseUp
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                Me.DataGridView1.Rows(e.RowIndex).Selected = True
                Me.rowindex = e.RowIndex
                Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(e.RowIndex).Cells(1)
                If Me.rowindex <= Me.DataGridView1.Rows.Count - 2 Then
                    Me.ContextMenuStrip1.Show(Me.DataGridView1.Location)
                    Me.ContextMenuStrip1.Show(Windows.Forms.Cursor.Position)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            all_connect()
            For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                Dim uname As String = Me.DataGridView1.Item(1, i).Value
                cmd.CommandText = "update Login set flag=0 where user_type='Employee' and user_name='" & uname & "'"
                cmd.ExecuteNonQuery()
            Next

            If Me.DataGridView1.Rows.Count = 1 Then
                MsgBox("No Accounts", MsgBoxStyle.Information, "alert")
            Else
                MsgBox("All accounts are unblock", MsgBoxStyle.MsgBoxRight, "Load Message")
                display()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
End Class



