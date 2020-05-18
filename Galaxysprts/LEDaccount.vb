Imports System.Data
Imports System.data.sqlclient

Public Class LEDaccount
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim bds As New BindingSource
    Dim rowindex As Integer
    Private Sub display()
        Try
            all_connect()
            cmd.CommandText = "select user_name as username,user_type as usertype from Login where user_type='Employee'"
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
    Public Sub all_clear()
        Me.txtusertype.Text = ""
        Me.txtusername.Text = ""
        Me.txtcpass.Text = ""
        Me.txtnpass.Text = ""
        Me.Label6.Text = ""
        Me.CheckBox1.Checked = True
    End Sub
    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        If Me.txtnpass.Text <> "" Then
            If Me.txtnpass.Text.Length < 8 Then
                MsgBox("New Password must have minimum of 8 characters", MsgBoxStyle.Information, "Warning")

                Me.txtnpass.Clear()
                Me.txtnpass.Focus()
            End If
        Else
            MsgBox("Enter new password to update", MsgBoxStyle.Information, "warning")
            Exit Sub
        End If
        If Me.CheckBox1.Checked = True Then
            If Me.txtnpass.Text = "" Then
                Me.lblnpass.Visible = True
                Me.Label6.Text = "please enter new password"
                Exit Sub
            End If
        End If
        If Me.txtcpass.Text = Me.txtnpass.Text Then
            MsgBox("new password cannot be same as old password", MsgBoxStyle.Information, "warning")
            Exit Sub
        End If
        Try
            cnn.Close()
            all_connect()
            If Me.CheckBox1.Checked = True Then
                cmd.CommandText = "update Login set password='" & Me.txtnpass.Text & "' where user_type='" & Me.txtusertype.Text & "' and user_name='" & Me.txtusername.Text & "'"

            End If
            cmd.ExecuteNonQuery()
            MsgBox("Account updated succesfully....", MsgBoxStyle.MsgBoxRight, "update message")
            all_clear()
            Me.Groupbox1.Visible = False

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close
        End Try
    End Sub



    Private Sub LEDaccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        display()
    End Sub
    Private Sub EditUserAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditUserAccountToolStripMenuItem.Click
        Me.Label6.Text = ""
        Me.CheckBox1.Checked = False
        Me.Label6.Visible = False
        Try
            If Me.rowindex > Me.DataGridView1.Rows.Count - 1 Then
                Exit Sub
            End If
            Me.txtusertype.Text = Me.DataGridView1.Item(1, Me.rowindex).Value
            Me.txtusername.Text = Me.DataGridView1.Item(0, Me.rowindex).Value
            all_connect()
            cmd.CommandText = "select password from Login where user_type='" & Me.DataGridView1.Item(1, Me.rowindex).Value & "' and user_name='" & Me.DataGridView1.Item(0, Me.rowindex).Value & "'"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.txtcpass.Text = dt.Rows(0).Item(0)
            Next
            Me.Groupbox1.Visible = True
            Me.Groupbox1.Visible = True
        Catch a As InvalidCastException
        Catch b As ArgumentOutOfRangeException
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged

        If Me.CheckBox1.Checked = True Then
            Me.lblnpass.Visible = True
            Me.txtnpass.Visible = True

            Me.Label6.Visible = False
        Else
            Me.txtnpass.Text = ""
            Me.lblnpass.Visible = False
            Me.txtnpass.Visible = False
            Me.Label6.Visible = False
        End If
    End Sub

    Private Sub Btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnexit.Click

        Me.Close()
    End Sub

    Private Sub DataGridView1_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseUp
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                Me.DataGridView1.Rows(e.RowIndex).Selected = True
                Me.rowindex = e.RowIndex
                Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(e.RowIndex).Cells(1)
                If Me.rowindex <= Me.DataGridView1.Rows.Count - 2 Then
                    Me.ContextMenuStrip1.Show(Me.DataGridView1, e.Location)
                    Me.ContextMenuStrip1.Show(Windows.Forms.Cursor.Position)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DeleteUserAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteUserAccountToolStripMenuItem.Click
        Dim uname As String = Me.DataGridView1.Item(0, Me.rowindex).Value
        Dim result = MsgBox("the user " & uname & " will be deleted permanently " & vbCrLf & "" & vbCrLf & " do you want to delete it??", MsgBoxStyle.YesNo, "confirm delete")
        If result = Windows.Forms.DialogResult.Yes Then
            Try
                all_connect()
                cmd.CommandText = "delete from Login where user_type='Employee' and user_name='" & uname & "'"
                cmd.ExecuteNonQuery()
                MsgBox("user " & uname & " deleted....", MsgBoxStyle.MsgBoxRight, "delete message")
                cnn.Close()
                display()
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                cnn.Close()
            End Try
        End If
    End Sub

    Private Sub txtnpass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnpass.KeyPress
        If e.KeyChar = Chr(Keys.Space) Then
            MsgBox("Space cannot be added", MsgBoxStyle.Question, "Alert")
            e.Handled = True
        End If
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.ProcessTabKey(True)
            Me.btnupdate.Focus()
        End If
    End Sub

    Private Sub txtnpass_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnpass.Leave
       
    End Sub


    Private Sub txtnpass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnpass.TextChanged
        If Me.txtnpass.Text <> "" Then
            Me.Label6.Visible = False
        Else
            Me.Label6.Visible = True
        End If
    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        all_clear()
        Me.CheckBox1.Checked = False
        Me.txtnpass.Visible = False
        Me.Label6.Visible = False
        Me.lblnpass.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.CheckBox1.Checked = False
        Me.Label6.Visible = False
        Me.Groupbox1.Visible = False
    End Sub
End Class