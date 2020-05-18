Imports System.Data.SqlClient
Imports System.Data

Public Class Purchasereturnreport

    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim bds As New BindingSource

    Private Sub Txtreturn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtreturn.KeyPress
        If (Char.IsWhiteSpace(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox3_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.DropDown
        Me.ComboBox3.Items.Clear()
        For i As Integer = 2010 To Today.Year
            Me.ComboBox3.Items.Add(i.ToString)
        Next
    End Sub
    Private Sub ComboBox2_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.DropDown
        Me.ComboBox2.Items.Clear()
        For i As Integer = 2010 To Today.Year
            Me.ComboBox2.Items.Add(i.ToString)
        Next
    End Sub





    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        If Me.txtreturn.Text = "PR" Or Me.txtreturn.Text = "" Then
            MsgBox("Please Enter Return Number to Display Report", MsgBoxStyle.Information, "Warning")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "SELECT * FROM purchase_return WHERE pr_no ='" & Me.txtreturn.Text & "'"
            If cmd.ExecuteScalar = "" Then
                MsgBox("Report Doesnot Exist.. Please check the Return No.", MsgBoxStyle.Information, "Warning")
                Exit Sub
            End If
            reportstr = "{purchase_return.Pr_no}='" & Me.txtreturn.Text & "'"
            crystalpurr.WindowState = FormWindowState.Maximized
            crystalpurr.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub btnrepo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrepo.Click
        If Me.ComboBox1.Text = "" Or Me.ComboBox2.Text = "" Then
            MsgBox("Please select the Month and Year tho Display Report", MsgBoxStyle.Information, "Warning")
            Exit Sub
        End If
        Dim m = 0
        If Me.ComboBox1.Text = "January" Then
            m = "1"
        ElseIf Me.ComboBox1.Text = "February" Then
            m = "2"
        ElseIf Me.ComboBox1.Text = "March" Then
            m = "3"
        ElseIf Me.ComboBox1.Text = "April" Then
            m = "4"
        ElseIf Me.ComboBox1.Text = "May" Then
            m = "5"
        ElseIf Me.ComboBox1.Text = "June" Then
            m = "6"
        ElseIf Me.ComboBox1.Text = "July" Then
            m = "7"
        ElseIf Me.ComboBox1.Text = "August" Then
            m = "8"
        ElseIf Me.ComboBox1.Text = "September" Then
            m = "9"
        ElseIf Me.ComboBox1.Text = "October" Then
            m = "10"
        ElseIf Me.ComboBox1.Text = "November" Then
            m = "11"
        ElseIf Me.ComboBox1.Text = "December" Then
            m = "12"
        End If
        Try
            all_Connect()
            cmd.CommandText = "SELECT * FROM purchase_return WHERE MONTH(return_date) =" & m & "AND  YEAR(return_date) =" & Val(Me.ComboBox2.Text)
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            If dt.Rows.Count = 0 Then
                MsgBox("No Records Found for selected month and year", MsgBoxStyle.Information, "Warning")
                Exit Sub
            End If
            reportstr = "month({purchase_return.return_date})=" & m & " and year({purchase_return.return_date})=" & Me.ComboBox2.Text
            crystalpurr.WindowState = FormWindowState.Maximized
            crystalpurr.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub btnyear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnyear.Click
        If Me.ComboBox3.Text = "" Then
            MsgBox("Please select Year to Display Report", MsgBoxStyle.Information, "Warning")
            Exit Sub
        End If
        Try
            all_Connect()
            cmd.CommandText = "SELECT * FROM purchase_return WHERE  YEAR(return_date) =" & Val(Me.ComboBox3.Text)
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            If dt.Rows.Count = 0 Then
                MsgBox("No Records Found for selected Year", MsgBoxStyle.Information, "Warning")
                Exit Sub
            End If
            reportstr = "year({purchase_return.return_date})=" & Me.ComboBox3.Text
            crystalpurr.WindowState = FormWindowState.Maximized
            crystalpurr.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

   
    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub btncls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncls.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.ComboBox1.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox2.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.ComboBox2.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox3.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.ComboBox3.Focus()
            e.Handled = True
        End If
    End Sub
End Class