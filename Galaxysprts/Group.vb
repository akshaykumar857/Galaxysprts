Imports System.Data.SqlClient
Imports System.Data
Public Class Group
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim bds As New BindingSource
    Dim Gname As String
    Public Sub display()
        Try
            all_connect()
            cmd.CommandText = "select* from group_info ORDER BY group_name asc"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Me.ListBox1.DataSource = dt
            Me.ListBox1.DisplayMember = "group_name"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If Me.txtgroup.Text = "" Then
            MsgBox("Please Enter New GroupName to Add..")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "select * from group_info where group_name='" & Me.txtgroup.Text & "'"
            Dim name = cmd.ExecuteScalar
            If name <> "" Then
                MsgBox("Group " & Me.txtgroup.Text & " Already Exist", MsgBoxStyle.Information, "Warning")
                Me.txtgroup.Text = ""
                Exit Sub
            End If
            cmd.CommandText = "insert into group_info values(@group_name)"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@group_name", SqlDbType.VarChar).Value = Me.txtgroup.Text
            cmd.ExecuteNonQuery()
            MsgBox("Group " & Me.txtgroup.Text & " Sucessfully Added ", MsgBoxStyle.Information, "Save Message")
            Me.txtgroup.Text = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click
        Me.txtgroup.Enabled = True
        Me.btnupdate.Visible = True
        Me.txtgroup.Text = Me.ListBox1.Text
        Gname = Me.txtgroup.Text
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub
    Private Sub txtgroup_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgroup.KeyPress
        If (sender.Text.EndsWith(" ") And (e.KeyChar.ToString = " ")) Then
            MsgBox("Successive Space not allowed!", MsgBoxStyle.Information, "Warning")
            e.Handled = True
            Exit Sub
        End If
        If (sender.Text = "" And (e.KeyChar.ToString = " ")) Then
            e.Handled = True
            Exit Sub
        End If
        If (Char.IsNumber(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar)) Then
            MsgBox("Enter only character...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub
    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        If Me.txtgroup.Text = "" Then
            MsgBox("Please Enter GroupName to Update ..")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "update Group_info set Group_name=@group_name where group_name='" & Gname & "'"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@group_name", SqlDbType.NVarChar).Value = Me.txtgroup.Text
            cmd.ExecuteNonQuery()
            MsgBox("Group Name UPDATED....", MsgBoxStyle.Information, "Message")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        display()
        Me.btnupdate.Visible = False
        Me.txtgroup.Text = ""
    End Sub
End Class