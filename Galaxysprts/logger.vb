Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class logger
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Public uname, utype As String

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.Checked = True Then
            Me.txtpass.UseSystemPasswordChar = False
        Else
            Me.txtpass.UseSystemPasswordChar = True

        End If
    End Sub

    Private Sub btnlogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlogin.Click
        If Me.txtpass.Text = "" And Me.txtname.Text = "" Then
            MsgBox("Please enter all the fields", MsgBoxStyle.Information, "warning")
            Me.txtname.Focus()
            Exit Sub
        ElseIf Me.txtname.Text = "" Then
            MsgBox("Please enter username", MsgBoxStyle.Information, "warning")
            Me.txtname.Focus()
            Exit Sub
        ElseIf Me.txtpass.Text = "" Then
            MsgBox("Please enter the password", MsgBoxStyle.Information, "warning")
            Me.txtpass.Focus()
            Exit Sub
        Else
            Me.ProgressBar1.Visible = True
            Me.Label4.Visible = True
            Me.Timer1.Enabled = True
            Me.Timer1.Start()
        End If
       
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.ProgressBar1.Value += 10
        If Me.ProgressBar1.Value <= 25 Then
            Me.Label4.Text = "Verify"
        ElseIf Me.ProgressBar1.Value > 26 And Me.ProgressBar1.Value <= 50 Then
            Me.Label4.Text = "comparing"
        Else
            Me.Label4.Text = "loading"
        End If
        If Me.ProgressBar1.Value >= 100 Then
            Me.ProgressBar1.Visible = False
            Me.Label4.Visible = False
            Me.Timer1.Enabled = False
            Me.Timer1.Stop()
            Me.ProgressBar1.Value = 0
            Try
                all_connect()
                cmd.CommandText = "select* from Login where user_type= '" & Me.TextBox3.Text & "' and user_name='" & Me.txtname.Text & "'"
                Dim c = cmd.ExecuteScalar
                If c = "" Then
                    MsgBox("Wrong user name", MsgBoxStyle.Information, "warning")
                    Me.ProgressBar1.Value = 0
                    Me.txtname.Clear()
                    Me.txtpass.Clear()
                    'Me.txtname.Focus()
                    Exit Sub
                End If
                cmd.CommandText = "select* from Login where user_type= '" & Me.TextBox3.Text & "' and user_name='" & Me.txtname.Text & "' and password='" & Me.txtpass.Text & "'"
                adp.SelectCommand = cmd
                dt = New DataTable
                dt.Clear()
                adp.Fill(dt)
                If (dt.Rows.Count > 0) Then
                    Dim counter As Integer = dt.Rows(0).Item(3)
                    If (counter >= 3) Then
                        MsgBox("your account has been blocked")
                        Me.txtname.Clear()
                        Me.txtpass.Clear()
                        Me.ProgressBar1.Value = 0
                        Me.ProgressBar1.Visible = False
                        Me.Label4.Visible = False
                        Exit Sub
                    End If
                    MsgBox("login successful", MsgBoxStyle.Information, "warning")
                    dat = Now
                    uname = Me.txtname.Text
                    utype = Me.TextBox3.Text
                    unamee = Me.txtname.Text
                    If (counter < 3) Then
                        cmd.CommandText = "update Login set flag=" & 0 & " where user_type='" & Me.TextBox3.Text & "' and user_name='" & Me.txtname.Text & "'"
                        cmd.ExecuteNonQuery()
                    End If
                    Me.ProgressBar1.Value = 0
                    If Me.TextBox3.Text = "Employee" Then
                        MDIParent1.Show()
                        MDIParent1.SetSecurityQuestionToolStripMenuItem.Visible = False
                        MDIParent1.CreateUsersToolStripMenuItem.Visible = False
                        MDIParent1.HistoryToolStripMenuItem.Visible = False
                        MDIParent1.ToolStripMenuItem11.Visible = False
                        MDIParent1.ToolStripMenuItem49.Visible = False
                    Else
                        MDIParent1.Show()
                        MDIParent1.SetSecurityQuestionToolStripMenuItem.Visible = True
                        MDIParent1.CreateUsersToolStripMenuItem.Visible = True
                        MDIParent1.HistoryToolStripMenuItem.Visible = True
                        MDIParent1.ToolStripMenuItem11.Visible = True
                        MDIParent1.ToolStripMenuItem49.Visible = True
                        MDIParent1.WindowState = FormWindowState.Maximized
                    End If
                    Me.Hide()
                    Exit Sub
                Else
                    cmd.CommandText = "select flag from Login where user_type='" & Me.TextBox3.Text & "' and user_name='" & Me.txtname.Text & "'"
                    Dim flg As Integer = cmd.ExecuteScalar
                    flg = flg + 1
                    If flg > 3 Then
                        If Me.TextBox3.Text = "Employee" Then
                            MsgBox("Your account has been blocked : Please contact administrator")

                        End If
                        If Me.TextBox3.Text = "Administrator" Then
                            MsgBox("Your account has been blocked : Please click on forget password link to unlock")

                        End If
                        Me.txtpass.Clear()
                        Me.ProgressBar1.Value = 0
                        Me.ProgressBar1.Visible = False
                        Me.Label4.Visible = False
                        Exit Sub
                    Else
                        MsgBox("Incorrect Password", MsgBoxStyle.Information, "warning")
                        cmd.CommandText = "update Login set flag=" & CInt(flg) & "where user_type='" & Me.TextBox3.Text & "'and user_name='" & Me.txtname.Text & "'"
                        cmd.ExecuteNonQuery()
                        Me.txtpass.Clear()
                        Me.ProgressBar1.Value = 0
                        Me.ProgressBar1.Visible = False
                        Me.Label4.Visible = False
                        Me.txtpass.Focus()
                    End If

                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                cnn.Close()
            End Try
        End If
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Dim result As Integer
        result = MsgBox("Are You Sure???", MsgBoxStyle.OkCancel + MsgBoxStyle.Information, "close")
        If (result = MsgBoxResult.Ok) Then
            Me.Close()
            login.Show()
        End If
        
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            all_connect()
            cmd.CommandText = "select* from Login where user_type=' " & Me.TextBox3.Text & " ' and user_name=' " & Me.txtname.Text & " ' "
            Dim c = cmd.ExecuteScalar
            'If c = " " Then
            '    MsgBox("Wrong Username>>>>>", MsgBoxStyle.Information, "message")
            '    Me.ProgressBar1.Value = 0
            '    Exit Sub
            'End If
            Me.txtpass.Text = " "
            securityquestion.Show()
            securityquestion.WindowState = FormWindowState.Maximized
            securityquestion.txtusername.Text = Me.txtname.Text
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub logger_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.ProgressBar1.Visible = False
        Me.Label4.Visible = False
    End Sub

    Private Sub txtname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtname.KeyPress
        If Me.TextBox3.Text = " " Then
            MsgBox("Please enter Usertype", MsgBoxStyle.Information, "warning")
        End If
        If e.KeyChar = Chr(Keys.Space) Then
            MsgBox("Space cannot be added", MsgBoxStyle.Question, "Alert")
            e.Handled = True
        End If
    End Sub

    Private Sub txtname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtname.Leave
        Try
            all_connect()
            cmd.CommandText = "select* from Login where user_type= '" & Me.TextBox3.Text & "' and user_name='" & Me.txtname.Text & "'"
            Dim c = cmd.ExecuteScalar
            If c = "" And Me.txtname.Text <> "" Then
                MsgBox("Wrong user name", MsgBoxStyle.Information, "warning")
                Me.ProgressBar1.Value = 0
                Me.txtname.Clear()
                Me.txtpass.Clear()
                Me.txtname.Focus()
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try

    End Sub
 

    Private Sub txtname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtname.TextChanged
        Try
            cnn.Close()
            all_connect()
            cmd.CommandText = "select user_name from login where user_type= 'Administrator' "
            Dim ch = cmd.ExecuteScalar
            If Me.TextBox3.Text = "Administrator" And Me.txtname.Text = ch Then
                Me.LinkLabel1.Visible = True
             
            Else
                Me.LinkLabel1.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub txtpass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpass.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.ProcessTabKey(True)
            Me.btnlogin.Focus()
        End If
    End Sub
    Private Sub txtpass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpass.TextChanged
        If Me.txtname.Text = "" And Me.txtpass.Focus And Me.txtpass.Text <> "" Then
            Me.txtpass.Clear()
            Me.txtname.Focus()
            MsgBox("Enter Username first", MsgBoxStyle.Information, "Warning")
        End If
    End Sub
End Class