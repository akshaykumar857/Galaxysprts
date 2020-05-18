Imports System.Data.SqlClient
Imports System.Data
Public Class createaccount
    Dim adp As New SqlDataAdapter
    Dim dt As New DataTable
    Dim bds As New BindingSource
    Public Sub all_clear()
        Me.Txtusername.Text = ""
        Me.txtpass.Text = ""
        Me.txtconfirmpass.Text = ""
    End Sub
    Public Sub textboxcheck()
        If Me.Txtusername.Text = "" Then
            MsgBox("Enter User Name", MsgBoxStyle.Information, "warning")
            Me.Txtusername.Focus()
        ElseIf Me.txtpass.Text = "" Then
            MsgBox("Enter New Password", MsgBoxStyle.Information, "warning")
            Me.txtpass.Focus()
        ElseIf Me.txtconfirmpass.Text = "" Then
            MsgBox("Confirm Password", MsgBoxStyle.Information, "warning")
        End If
    End Sub

    Private Sub createaccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtusertype.Text = "Employee"
        Me.txtusertype.Enabled = False
        Me.Txtusername.Focus()
    End Sub
    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If Me.CheckBox4.Checked = True Then
            Me.txtpass.PasswordChar = ""
            Me.txtconfirmpass.PasswordChar = ""
        Else
            Me.txtpass.PasswordChar = "*"
            Me.txtconfirmpass.PasswordChar = "*"
        End If
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub btncreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncreate.Click
        textboxcheck()
        If Me.Txtusername.Text = "" Or Me.txtpass.Text = "" Or Me.txtconfirmpass.Text = "" Then
            Exit Sub
        End If
        If Me.txtpass.Text = Me.txtconfirmpass.Text Then
            Try
                cnn.Close()
                all_connect()
                cmd.CommandText = "insert into Login values(@user_type,@user_name,@password,@flag)"
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@user_type", SqlDbType.VarChar).Value = Me.txtusertype.Text
                cmd.Parameters.Add("@user_name", SqlDbType.VarChar).Value = Me.Txtusername.Text
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = Me.txtpass.Text
                cmd.Parameters.Add("@flag", SqlDbType.BigInt).Value = 0
                cmd.ExecuteNonQuery()
                MsgBox("New user created", MsgBoxStyle.Information, "warning")
                Me.Close()
                all_clear()
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                cnn.Close()
            End Try
        Else
            MsgBox("password does not match", MsgBoxStyle.Critical, "warning")
            Me.txtpass.Clear()
            Me.txtconfirmpass.Clear()
        End If
    End Sub


    Private Sub txtpass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpass.KeyPress
        If e.KeyChar = Chr(Keys.Space) Then
            MsgBox("Space cannot be added", MsgBoxStyle.Question, "Alert")
            e.Handled = True
        End If
        If Me.txtpass.Text.Length >= 7 Then
            Me.txtconfirmpass.Enabled = True
        End If
    End Sub

    Private Sub txtpass_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpass.Leave
        If Me.txtpass.Text <> "" Then
            If Me.txtpass.Text.Length < 8 Then
                MsgBox("New Password must have minimum of 8 characters", MsgBoxStyle.Information, "Warning")
                Me.txtpass.Clear()
                Me.txtpass.Focus()
            End If
        End If
    End Sub

    Private Sub txtconfirmpass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtconfirmpass.KeyPress
        If e.KeyChar = Chr(Keys.Space) Then
            MsgBox("Space cannot be added", MsgBoxStyle.Question, "Alert")
            e.Handled = True
        End If
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.ProcessTabKey(True)
            Me.btncreate.Focus()
        End If
    End Sub

    Private Sub txtconfirmpass_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtconfirmpass.Leave
        If Me.txtconfirmpass.Text <> "" Then
            If Me.txtconfirmpass.Text.Length < 8 Then
                MsgBox("Confirm Password should be same as password", MsgBoxStyle.Information, "Warning")
                Me.txtconfirmpass.Clear()
                Me.txtconfirmpass.Focus()
            End If
        End If
    End Sub

    Private Sub Txtusername_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtusername.KeyPress
        If Not (Char.IsLetter(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = " " Or Char.IsWhiteSpace(e.KeyChar)) Then
            e.Handled = True
            MsgBox("Enter only character", MsgBoxStyle.Information, "Warning")
            If e.KeyChar = Chr(Keys.Enter) Then
                Me.ProcessTabKey(True)
            End If
        End If
        If Me.Txtusername.Text.Length = 0 Then
            If e.KeyChar = Chr(Keys.Space) Then
                MsgBox("Space cannot be added", MsgBoxStyle.Question, "Alert")
                e.Handled = True
            End If
        End If
        If Me.Txtusername.Text <> "" Then
            Me.txtpass.Enabled = True

        End If

    End Sub

    Private Sub Txtusername_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtusername.Leave
        If Me.Txtusername.Text = "" Then
            Me.txtpass.Clear()
            Me.txtpass.Enabled = False
            Me.txtconfirmpass.Clear()
            Me.txtconfirmpass.Enabled = False
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "select * from Login where user_type= '" & Me.txtusertype.Text & "' and  user_name='" & Me.Txtusername.Text & "'"
            Dim user = cmd.ExecuteScalar
            If user <> "" Then
                MsgBox("Account with Username " & Me.Txtusername.Text & " Already exists " & vbCrLf & "Try some other name", MsgBoxStyle.Information, "Save message")
                Me.Txtusername.Clear()
                Me.Txtusername.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
End Class