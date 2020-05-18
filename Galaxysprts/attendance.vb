Imports System.Data.SqlClient
Imports System.Data
Public Class attendance
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim bds As New BindingSource
    Dim s
    Dim maxdays = 31
    Public Sub Bindclear()
        Me.ComboBox1.DataBindings.Clear()
        Me.txtname.DataBindings.Clear()
        Me.txtmonth.DataBindings.Clear()
        Me.txtyear.DataBindings.Clear()
        Me.txtleave.DataBindings.Clear()
        Me.txtworking.DataBindings.Clear()
    End Sub
    Public Sub display()
        Me.SaveToolStripMenuItem.Enabled = False
        Me.NewToolStripMenuItem.Enabled = True
        Try
            all_connect()
            cmd.CommandText = "select * from Attendance where emp_id in(select emp_id from Employee where status='active')"
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
    Public Sub All_clear()
        Me.ComboBox1.Text = ""
        Me.txtname.Text = ""
        Me.txtmonth.Text = ""
        Me.txtyear.Text = ""
        Me.txtleave.Text = ""
        Me.txtworking.Text = ""
        Me.txtdays.Text = ""
    End Sub
    Private Sub attendance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DataGridView1.Visible = False
        Me.GroupBox1.Enabled = False
        All_clear()
        Bindclear()
        Try
            all_connect()
            cmd.CommandText = "select *from Employee where status='active'"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Me.ComboBox1.DataSource = dt
            Me.ComboBox1.DisplayMember = "Emp_id"
            Me.ComboBox1.DataBindings.Clear()
            Me.ToolStripMenuItem1.Visible = False
            Me.UpdateToolStripMenuItem.Visible = False
            Me.DeleteToolStripMenuItem.Visible = False
            Me.SaveToolStripMenuItem.Visible = False
            Me.txtname.Enabled = False
            Me.GroupBox1.Visible = False
            display()
            All_clear()
            Bindclear()
            Me.ComboBox1.Text = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        All_clear()
    End Sub
    Private Sub combobox1_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDownClosed
        Dim year
        year = Today.Year
        Me.txtyear.Text = Today.Year
        Me.txtmonth.Text = Today.Month.ToString
        If Me.txtmonth.Text = "1" Then
            Me.txtmonth.Text = "January"
            maxdays = 31
            Me.txtdays.Text = maxdays
        ElseIf Me.txtmonth.Text = "2" Then
            Me.txtmonth.Text = "February"
            maxdays = 28
            Me.txtdays.Text = maxdays
        ElseIf Me.txtmonth.Text = "3" Then
            Me.txtmonth.Text = "March"
            maxdays = 31
            Me.txtdays.Text = maxdays
        ElseIf Me.txtmonth.Text = "4" Then
            Me.txtmonth.Text = "April"
            maxdays = 30
            Me.txtdays.Text = maxdays

        ElseIf Me.txtmonth.Text = "5" Then
            Me.txtmonth.Text = "May"
            maxdays = 31
            Me.txtdays.Text = maxdays
        ElseIf Me.txtmonth.Text = "6" Then
            Me.txtmonth.Text = "June"
            maxdays = 30
            Me.txtdays.Text = maxdays
        ElseIf Me.txtmonth.Text = "7" Then
            Me.txtmonth.Text = "July"
            maxdays = 31
            Me.txtdays.Text = maxdays
        ElseIf Me.txtmonth.Text = "8" Then
            Me.txtmonth.Text = "August"
            maxdays = 31
        ElseIf Me.txtmonth.Text = "9" Then
            Me.txtmonth.Text = "September"
            maxdays = 30
            Me.txtdays.Text = maxdays
        ElseIf Me.txtmonth.Text = "10" Then
            Me.txtmonth.Text = "October"
            maxdays = 31
            Me.txtdays.Text = maxdays
        ElseIf Me.txtmonth.Text = "11" Then
            Me.txtmonth.Text = "November"
            maxdays = 30
            Me.txtdays.Text = maxdays
        Else
            Me.txtmonth.Text = "December"
            maxdays = 31
            Me.txtdays.Text = maxdays
        End If
        Me.txtdays.Enabled = False
    End Sub
    Private Sub combobox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.Leave
        Try
            all_connect()
            If Me.ComboBox1.Text <> "" Then
                cmd.CommandText = "select Emp_id,Month,Year from Attendance where Emp_id='" & Me.ComboBox1.Text & "'and Month='" & Me.txtmonth.Text & "'and Year='" & Me.txtyear.Text & "'"
                Dim c = cmd.ExecuteScalar
                If c <> "" Then
                    MsgBox("attendance for month has already entered ")
                    All_clear()
                    ' Me.Checkenable.Text = "Enable"
                    Me.ComboBox1.Focus()
                    Exit Sub
                End If
            End If
            cmd.CommandText = "select Emp_name from Employee where Emp_id='" & Me.ComboBox1.Text & "'"
            Me.txtname.Text = cmd.ExecuteScalar
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub combobox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.TextChanged
        cnn.Close()
        Try
            all_connect()
            cmd.CommandText = "select Emp_name from Employee where Emp_id='" & Me.ComboBox1.Text & "'"
            Me.txtname.Text = cmd.ExecuteScalar
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub txtleave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtleave.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
            MsgBox("enter only number ..", MsgBoxStyle.Information, "warning")
            e.Handled = True
        End If
    End Sub

    Private Sub txtleave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtleave.TextChanged
        If Val(Me.txtleave.Text) > Val(Me.txtdays.Text) Then
            MsgBox("invalid input" & vbCrLf & "this month can not have more than total days", MsgBoxStyle.Information, "warning")
            Me.txtleave.Text = ""
        End If
    End Sub
    Private Sub txtworking_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtworking.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
            MsgBox("enter only number ..", MsgBoxStyle.Information, "warning")
            e.Handled = True
        End If

    End Sub
    Private Sub txtworking_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtworking.TextChanged
        If Val(Me.txtworking.Text) > Val(Me.txtdays.Text) Then
            MsgBox("invalid input" & vbCrLf & "this month can not have more than total days", MsgBoxStyle.Information, "warning")
            Me.txtworking.Clear()
            Me.txtworking.Focus()
            Me.txtleave.Clear()
            Exit Sub
        End If
        If Val(Me.txtworking.Text) <= Val(Me.txtdays.Text) Then
            Me.txtleave.Text = Val(Me.txtdays.Text) - Val(Me.txtworking.Text)
            Exit Sub
        End If

    End Sub
    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Me.GroupBox1.Enabled = True
        All_clear()
        Me.NewToolStripMenuItem.Visible = False
        Me.SaveToolStripMenuItem.Visible = True
        Me.SaveToolStripMenuItem.Enabled = True
        Me.ModifyToolStripMenuItem.Visible = False
        Me.DataGridView1.Visible = False
        Me.ToolStripMenuItem1.Visible = True
        Me.ExitToolStripMenuItem.Visible = False
        Me.ComboBox1.Focus()
        Me.ComboBox1.Enabled = True
        Me.txtyear.Enabled = False
        Me.txtmonth.Enabled = False
        Me.txtleave.Enabled = False
        Me.txtdays.Enabled = False
        Me.GroupBox1.Visible = True

    End Sub
    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If Me.ComboBox1.Text = "" Or Me.txtmonth.Text = "" Or Me.txtyear.Text = "" Or Me.txtleave.Text = "" Or Me.txtworking.Text = "" Then
            MsgBox("please enter all feilds")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "insert into Attendance values(@Emp_id,@Month,@Year,@tot_days,@No_leave,@No_working)"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Emp_id", SqlDbType.NVarChar).Value = Me.ComboBox1.Text
            cmd.Parameters.Add("@Month", SqlDbType.NVarChar).Value = Me.txtmonth.Text
            cmd.Parameters.Add("@Year", SqlDbType.BigInt).Value = Me.txtyear.Text
            cmd.Parameters.Add("@Tot_days", SqlDbType.BigInt).Value = Me.txtdays.Text
            cmd.Parameters.Add("@No_leave", SqlDbType.BigInt).Value = Me.txtleave.Text
            cmd.Parameters.Add("@No_working", SqlDbType.BigInt).Value = Me.txtworking.Text
            cmd.ExecuteNonQuery()
            MsgBox("attendance detail saved succesfull", MsgBoxStyle.Information, "save message")
            All_clear()
            Me.NewToolStripMenuItem.Visible = True
            Me.txtmonth.ReadOnly = True
            Me.GroupBox1.Visible = False
            Me.ModifyToolStripMenuItem.Visible = False
            Me.SaveToolStripMenuItem.Visible = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        display()
        All_clear()
    End Sub
    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        All_clear()
        Me.DataGridView1.Visible = True
        Me.DataGridView1.Enabled = True
        Me.GroupBox1.Visible = True
        Me.GroupBox1.Enabled = True
        Me.ComboBox1.Enabled = False
        Me.txtleave.Enabled = False
        Me.UpdateToolStripMenuItem.Visible = True
        Me.DeleteToolStripMenuItem.Visible = True
        Me.EditToolStripMenuItem.Visible = False
        Me.txtname.ReadOnly = True
        Me.FileToolStripMenuItem.Visible = False
        Me.txtmonth.ReadOnly = True
        Me.txtyear.ReadOnly = True
        Me.txtdays.Enabled = False
        Me.ExitToolStripMenuItem.Visible = False
        Me.ToolStripMenuItem1.Visible = True
    End Sub
    Private Sub UpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem.Click
        If Me.ComboBox1.Text = "" Or Me.txtmonth.Text = "" Or Me.txtyear.Text = "" Or Me.txtleave.Text = "" Or Me.txtworking.Text = "" Then
            MsgBox("please enter all fields")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "update Attendance set Emp_id=@Emp_id,Month=@Month,Year=@Year,tot_days=@tot_days,No_leave=@No_leave,No_working=@No_working where Emp_id='" & Me.ComboBox1.Text & "'and Month='" & Me.txtmonth.Text & "'"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@Emp_id", SqlDbType.NVarChar).Value = Me.ComboBox1.Text
            cmd.Parameters.Add("@Month", SqlDbType.NVarChar).Value = Me.txtmonth.Text
            cmd.Parameters.Add("@Year", SqlDbType.BigInt).Value = Me.txtyear.Text
            cmd.Parameters.Add("@Tot_days", SqlDbType.Int).Value = Me.txtdays.Text
            Me.txtleave.Text = Val(Me.txtdays.Text) - Val(Me.txtworking.Text)
            cmd.Parameters.Add("@No_leave", SqlDbType.Int).Value = Me.txtleave.Text
            cmd.Parameters.Add("@No_working", SqlDbType.Int).Value = Me.txtworking.Text
            cmd.ExecuteNonQuery()
            MsgBox("record update", MsgBoxStyle.Information, "message")
            All_clear()
            Me.ComboBox1.Enabled = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        display()
        All_clear()
    
        Me.GroupBox1.Enabled = True
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            all_connect()
            If Me.txtname.Text = "" Then
                MsgBox("record doesn't exists", MsgBoxStyle.Information, "warning")
            Else
                cmd.CommandText = "delete from Attendance where Emp_id='" & Me.ComboBox1.Text & "'and Month='" & Me.txtmonth.Text & "'and Year='" & Me.txtyear.Text & "'"
                cmd.ExecuteNonQuery()
                MsgBox("record deleted..", MsgBoxStyle.Information, "message")
                All_clear()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        display()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        All_clear()
        Me.FileToolStripMenuItem.Visible = True
        Me.ExitToolStripMenuItem.Visible = True
        Me.ModifyToolStripMenuItem.Visible = True
        Me.ToolStripMenuItem1.Visible = False
        Me.GroupBox1.Visible = False
        Me.SaveToolStripMenuItem.Visible = False
        Me.NewToolStripMenuItem.Visible = True
        Me.EditToolStripMenuItem.Visible = True
        Me.UpdateToolStripMenuItem.Visible = False
        Me.DeleteToolStripMenuItem.Visible = False
        Me.DataGridView1.Visible = False
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            Me.ComboBox1.Text = Me.DataGridView1.Item(0, e.RowIndex).Value
            Me.txtmonth.Text = Me.DataGridView1.Item(1, e.RowIndex).Value
            Me.txtyear.Text = Me.DataGridView1.Item(2, e.RowIndex).Value
            Me.txtdays.Text = Me.DataGridView1.Item(3, e.RowIndex).Value
            Me.txtleave.Text = Me.DataGridView1.Item(4, e.RowIndex).Value
            Me.txtworking.Text = Me.DataGridView1.Item(5, e.RowIndex).Value
        Catch ex As ArgumentOutOfRangeException
        End Try
    End Sub
End Class
