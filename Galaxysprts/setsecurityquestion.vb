Imports System.Data
Imports System.Data.SqlClient
Public Class setsecurityquestion
    Dim adp As SqlDataAdapter
    Dim dt As New DataTable
    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub btnsub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsub.Click
        If Me.comboqstn1.Text = "" Or Me.Comboqstn2.Text = "" Or Me.comboqstn3.Text = "" Then
            MsgBox("Please select all the question", MsgBoxStyle.Information, "message")
            Exit Sub
        End If
        If Me.txtans1.Text = "" Or Me.txtans2.Text = "" Or Me.txtans3.Text = "" Then
            MsgBox("Please answer all the question", MsgBoxStyle.Information, "message")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "delete from Questions"
            If cmd.ExecuteScalar = "" Then
                cmd.CommandText = "insert into Questions values('" & Me.comboqstn1.Text & "','" & Me.txtans1.Text & "','" & Me.Comboqstn2.Text & "','" & Me.txtans2.Text & "','" & Me.comboqstn3.Text & "','" & Me.txtans3.Text & "')"
                cmd.ExecuteNonQuery()
                MsgBox("Security Questions Set Successfully")
            End If
            Me.comboqstn1.Text = ""
            Me.txtans1.Text = ""
            Me.Comboqstn2.Text = ""
            Me.txtans2.Text = ""
            Me.comboqstn3.Text = ""
            Me.txtans3.Text = ""
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub txtans1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtans1.KeyPress
        If (sender.text.endswith(" ") And (e.KeyChar.ToString = " ")) Then
            MsgBox("Successive space not allowed")
            e.Handled = True
            Exit Sub
        End If
    End Sub
    Private Sub txtans2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtans2.KeyPress
        If (sender.text.endswith(" ") And (e.KeyChar.ToString = " ")) Then
            MsgBox("Successive space not allowed")
            e.Handled = True
            Exit Sub
        End If
    End Sub
    Private Sub txtans3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtans3.KeyPress
        If (sender.text.endswith(" ") And (e.KeyChar.ToString = " ")) Then
            MsgBox("Successive space not allowed")
            e.Handled = True
            Exit Sub
        End If
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.ProcessTabKey(True)
            Me.btnsub.Focus()
        End If
    End Sub

    Private Sub comboqstn1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles comboqstn1.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.comboqstn1.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub Comboqstn2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Comboqstn2.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.Comboqstn2.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub comboqstn3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles comboqstn3.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.comboqstn3.Focus()
            e.Handled = True
        End If
    End Sub
End Class
