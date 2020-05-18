Imports System.Data
Imports System.Data.SqlClient
Public Class changepassword
    Public Sub all_clear()
        Me.txtcurrentpass.Clear()
        Me.txtnewpass.Clear()
        Me.txtconformpass.Clear()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.txtcurrentpass.Text = "" Then
            MsgBox("Please enter current password", MsgBoxStyle.Information, "warning")
            Me.txtcurrentpass.Focus()
        End If
        If Me.txtnewpass.Text = "" And Me.txtcurrentpass.Text <> "" Then
            MsgBox("Please enter new password", MsgBoxStyle.Information, "warning")
            Me.txtnewpass.Focus()
        End If
        If Me.txtconformpass.Text = "" And Me.txtcurrentpass.Text <> "" And Me.txtnewpass.Text <> "" Then
            MsgBox("Please confirm password", MsgBoxStyle.Information, "warning")
            Me.txtconformpass.Focus()
        End If

        If Me.txtcurrentpass.Text = "" Or Me.txtnewpass.Text = "" Or Me.txtconformpass.Text = "" Then
            Exit Sub

        End If
        Try
            all_connect()
            cmd.CommandText = "select password from Login where user_type='" & logger.utype & "' and user_name='" & logger.uname & "'"
            Dim pass = cmd.ExecuteScalar
            If Me.txtcurrentpass.Text <> pass Then
                MsgBox("current password is incorrect", MsgBoxStyle.Exclamation, "message")
                all_clear()
                Me.txtnewpass.Enabled = False
                Me.txtconformpass.Enabled = False
                Me.txtcurrentpass.Focus()
                Exit Sub
            End If
            If Me.txtnewpass.Text = pass Then
                MsgBox("new password cannot be as current password", MsgBoxStyle.Exclamation, "message")
                Me.txtnewpass.Text = ""
                Me.txtconformpass.Text = ""
                Me.txtconformpass.Enabled = False
                Me.txtnewpass.Focus()
                Exit Sub
            End If
            If Me.txtname.Text = Me.txtnewpass.Text Then
                MsgBox("new password cannot be as Username", MsgBoxStyle.Exclamation, "message")
                Me.txtnewpass.Text = ""
                Me.txtconformpass.Text = ""
                Me.txtconformpass.Enabled = False
                Me.txtnewpass.Focus()
                Exit Sub
            End If
            If Me.txtconformpass.Text = Me.txtnewpass.Text Then
                Try
                    cnn.Close()
                    all_connect()
                    cmd.CommandText = "update Login set password='" & Me.txtnewpass.Text & "' where user_type='" & logger.utype & "' and user_name= '" & logger.uname & "'"
                    cmd.ExecuteNonQuery()
                    MsgBox("password changed succesfully", MsgBoxStyle.MsgBoxRight, "save message")
                    all_clear()
                    Me.CheckBox1.Checked = False
                    Me.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                Finally
                    cnn.Close()
                End Try
            Else
                MsgBox("Password does'nt match", MsgBoxStyle.Information, "warning")
                Me.txtconformpass.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

  
    Private Sub changepassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtname.Text = logger.uname
        Me.txtcurrentpass.Select()
        Me.txtname.Enabled = False
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.Checked = True Then
            Me.txtcurrentpass.PasswordChar = ""
            Me.txtnewpass.PasswordChar = ""
            Me.txtconformpass.PasswordChar = ""
        Else
            Me.txtcurrentpass.PasswordChar = "*"
            Me.txtnewpass.PasswordChar = "*"
            Me.txtconformpass.PasswordChar = "*"
        End If
    End Sub

    Private Sub txtcurrentpass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcurrentpass.KeyPress
        If e.KeyChar = Chr(Keys.Space) Then
            MsgBox("Space cannot be added", MsgBoxStyle.Question, "Alert")
            e.Handled = True
        End If
        If Me.txtcurrentpass.Text.Length >= 7 Then
            Me.txtnewpass.Enabled = True
        End If
    End Sub

    Private Sub txtcurrentpass_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcurrentpass.Leave
        If Me.txtcurrentpass.Text <> "" Then
            If Me.txtcurrentpass.Text.Length < 8 Then
                MsgBox("Current Password must have minimum of 8 characters", MsgBoxStyle.Information, "Warning")
                Me.txtcurrentpass.Clear()
                Me.txtcurrentpass.Focus()
            End If
        Else
            Me.txtnewpass.Clear()
            Me.txtnewpass.Enabled = False
            Me.txtconformpass.Clear()
            Me.txtconformpass.Enabled = False
        End If

    End Sub

    Private Sub txtnewpass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnewpass.KeyPress
        If e.KeyChar = Chr(Keys.Space) Then
            MsgBox("Space cannot be added", MsgBoxStyle.Question, "Alert")
            e.Handled = True
        End If
        If Me.txtnewpass.Text.Length >= 7 Then
            Me.txtconformpass.Enabled = True
        End If
    End Sub

    Private Sub txtnewpass_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnewpass.Leave
        If Me.txtnewpass.Text <> "" Then
            If Me.txtnewpass.Text.Length < 8 Then
                MsgBox("New Password must have minimum of 8 characters", MsgBoxStyle.Information, "Warning")
                Me.txtnewpass.Clear()
                Me.txtnewpass.Focus()
            End If
        End If
    End Sub

    Private Sub txtconformpass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtconformpass.KeyPress

        If e.KeyChar = Chr(Keys.Space) Then
            MsgBox("Space cannot be added", MsgBoxStyle.Question, "Alert")
            e.Handled = True
        End If
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.ProcessTabKey(True)
            Me.Button1.Focus()
        End If
    End Sub

    Private Sub txtconformpass_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtconformpass.Leave
        If Me.txtconformpass.Text <> "" Then
            If Me.txtconformpass.Text.Length < 8 Then
                MsgBox("Confirm Password must have minimum of 8 characters", MsgBoxStyle.Information, "Warning")
                Me.txtconformpass.Clear()
                Me.txtconformpass.Focus()
            End If
        End If
    End Sub
End Class