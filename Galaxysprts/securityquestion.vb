Imports System.Data
Imports System.Data.SqlClient
Public Class securityquestion
    Dim adp As New SqlDataAdapter
    Dim dt As New DataTable
    Private Sub securityquestion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cnn.Close()
            all_connect()

            cmd.CommandText = "select question1,question2,question3 from Questions"
            Me.lblq1.Text = cmd.ExecuteScalar
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.lblq1.Text = dt.Rows(i).Item(0)
                Me.lblq2.Text = dt.Rows(i).Item(1)
                Me.lblq3.Text = dt.Rows(i).Item(2)
            Next
            logger.txtpass.Text = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub txtusername_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtusername.DragDrop
        If Me.txtusername.Text = "" Then
            MsgBox("Please enter the UserName first", MsgBoxStyle.Information, "Message")
            Exit Sub
        End If

    End Sub

    Private Sub btnsubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsubmit.Click
        Try
            all_connect()
            If Me.txtans1.Text = "" Or Me.txtans2.Text = "" Or Me.txtans3.Text = "" Then
                MsgBox("Please Enter the Answer for all the Questions", MsgBoxStyle.Information, "Message")
                Exit Sub
            End If
            cmd.CommandText = "select Flag from Login where User_type='Administrator' and User_name='" & Me.txtusername.Text & "'"
            Dim flg = cmd.ExecuteScalar
            cmd.CommandText = "select Ans1,Ans2,Ans3 from Questions"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Dim Ans1, Ans2, Ans3 As String
            For i As Integer = 0 To dt.Rows.Count - 1
                Ans1 = dt.Rows(i).Item(0)
                Ans2 = dt.Rows(i).Item(1)
                Ans3 = dt.Rows(i).Item(2)
            Next

            If flg >= 3 And Me.txtans1.Text.ToLower() = Ans1.ToLower() And Me.txtans2.Text.ToLower() = Ans2.ToLower() And Me.txtans3.Text.ToLower() = Ans3.ToLower() Then
                Dim pass = "admin420"
                cmd.CommandText = "update Login set Password ='" & pass & "',Flag = 0 where User_type='Administrator' and User_name='" & Me.txtusername.Text & "'"
                cmd.ExecuteNonQuery()
                MsgBox("The Account has been Unblocked " & vbCrLf & " Your  new Password is   :  " & pass, MsgBoxStyle.Information, "Unblocked")
                logger.txtpass.Clear()
                Me.txtans1.Text = ""
                Me.txtans2.Text = ""
                Me.txtans3.Text = ""
            ElseIf flg < 3 And Me.txtans1.Text.ToLower() = Ans1.ToLower() And Me.txtans2.Text.ToLower() = Ans2.ToLower() And Me.txtans3.Text.ToLower() = Ans3.ToLower() Then
                cmd.CommandText = "select Password from Login where User_type='Administrator' and User_name='" & Me.txtusername.Text & "'"
                MsgBox("Your Current Password is  :  " & cmd.ExecuteScalar, MsgBoxStyle.Information, "Password")
                logger.txtpass.Clear()
                Me.txtans1.Text = ""
                Me.txtans2.Text = ""
                Me.txtans3.Text = ""
                Me.Close()
            Else
                MsgBox("One or more Answers are Wrong.!" & vbCrLf & "You need to Answer all 3 Questions Correctly", MsgBoxStyle.Information, "Message")

                Me.txtans1.Clear()
                Me.txtans2.Clear()
                Me.txtans3.Clear()

                End If
         
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub txtans3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtans3.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.ProcessTabKey(True)
            Me.btnsubmit.Focus()
        End If
    End Sub
End Class