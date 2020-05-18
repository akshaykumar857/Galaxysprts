  Imports System.Data.SqlClient
  Public Class Salaryreport
    Dim adp As New SqlDataAdapter

	Private Sub btnshw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshw.Click
        Dim dt3 As New DataTable
        If Me.ComboBox3.Text = "" And Me.ComboBox4.Text = "" Then
            MsgBox("please Select Employee ID and year", MsgBoxStyle.Information, "Warning")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "select * from pay_slip where emp_id = '" & Me.ComboBox3.Text & "' and Year(pay_slip.salary_date)= '" & Me.ComboBox4.Text & "'"
            adp.SelectCommand = cmd
            dt3.Clear()
            adp.Fill(dt3)
            If dt3.Rows.Count = 0 Then
                MsgBox("No Records Found", MsgBoxStyle.Information, "Information")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        sel = "{pay_slip.emp_id}='" & Me.ComboBox1.Text & "' and Year({pay_slip.salary_date})=" & Me.ComboBox4.Text
        crystalsal.WindowState = FormWindowState.Maximized
        crystalsal.Show()
    End Sub

    
    Private Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click
        Dim m
        Dim dt As New DataTable
        Try
            all_connect()
            If Me.ComboBox2.Text = "" Or Me.ComboBox3.Text = "" Then
                MsgBox("please Select the month and year", MsgBoxStyle.Information, "Warning")
                Exit Sub
            End If
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
            cmd.CommandText = "select * from pay_slip where month(salary_date)='" & m & "'and Year(salary_date)='" & Me.ComboBox2.Text & "'"
            adp.SelectCommand = cmd
            dt.Clear()
            adp.Fill(dt)
            If dt.Rows.Count = 0 Then
                MsgBox("No Record Found", MsgBoxStyle.Information, "Information")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        sel = "month({pay_slip.salary_date})=" & m & " and Year({pay_slip.salary_date})=" & Me.ComboBox2.Text
        crystalsal.WindowState = FormWindowState.Maximized
        crystalsal.Show()
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub btncls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncls.Click
        Me.Close()
    End Sub

    Private Sub ComboBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.Click
        Me.ComboBox2.Items.Clear()
        For i As Integer = 2010 To Today.Year
            Me.ComboBox2.Items.Add(i)
        Next
    End Sub

   

    Private Sub ComboBox4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox4.Click
        Me.ComboBox4.Items.Clear()
        For i As Integer = 2010 To Today.Year
            Me.ComboBox4.Items.Add(i)
        Next
    End Sub

    Private Sub ComboBox3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.Click
        Dim db As New DataTable
        Try
            all_connect()
            cmd.CommandText = "select emp_id from Employee"
            adp.SelectCommand = cmd
            db.Clear()
            adp.Fill(db)
            Me.ComboBox3.Items.Clear()
            For i As Integer = 0 To db.Rows.Count - 1
                Me.ComboBox3.Items.Add(db.Rows(i).Item(0))
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
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

    Private Sub ComboBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox4.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.ComboBox4.Focus()
            e.Handled = True
        End If
    End Sub
End Class



