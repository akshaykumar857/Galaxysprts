Imports System.Data.SqlClient
Public Class Salesreport
    Dim adp As New SqlDataAdapter
    Private Sub ComboBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.Click
        Me.ComboBox2.Items.Clear()
        For i As Integer = 2010 To Today.Year
            Me.ComboBox2.Items.Add(i)
        Next
    End Sub

    Private Sub btnclos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclos.Click
        Me.Close()
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub btnclo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclo.Click
        Me.Close()
    End Sub

    Private Sub btnshw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshw.Click
        Dim m
        Dim dt1 As New DataTable
        Try
            all_connect()
            If Me.ComboBox1.Text = "" Or Me.ComboBox2.Text = "" Then
                MsgBox("Please Select the month and year", MsgBoxStyle.Information, "Warning")
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
            cmd.CommandText = "select * from sales_bill where Month(bill_date)='" & m & "' and Year(bill_date)='" & Me.ComboBox2.Text & "'"
            adp.SelectCommand = cmd
            dt1.Clear()
            adp.Fill(dt1)
            If dt1.Rows.Count = 0 Then
                MsgBox("Selected Month does not have any Transactions ", MsgBoxStyle.Information, "Information")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        sel = "Month({sales_bill.bill_date})=" & m & " and Year({sales_bill.bill_date})=" & Me.ComboBox2.Text
        crystalsale.WindowState = FormWindowState.Maximized
        crystalsale.Show()
    End Sub

    Private Sub btnsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsh.Click
        Dim dt3 As New DataTable
        If Me.ComboBox4.Text = "" Then
            MsgBox("Please Select Bill Number..", MsgBoxStyle.Information, "Warning")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "select * from sales_bill where Bill_no='" & Me.ComboBox4.Text & "'"
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
        sel = "{sales_bill.bill_no}='" & Me.ComboBox4.Text & "'"
        crystalsale.WindowState = FormWindowState.Maximized
        crystalsale.Show()
    End Sub

    Private Sub ComboBox3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.Click
        Me.ComboBox3.Items.Clear()
        For i As Integer = 2010 To Today.Year
            Me.ComboBox3.Items.Add(i)
        Next
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If Me.DateTimePicker1.Value > Today Then
            MsgBox("Future Date cannot be selected", MsgBoxStyle.Information, "Information")
            Me.DateTimePicker1.Value = Today
            Exit Sub
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Me.ComboBox1.Text = ""
        Me.ComboBox2.Text = ""
        Me.ComboBox3.Text = ""
        Me.ComboBox4.Text = ""
    End Sub

    Private Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click

        Dim dt As New DataTable
        Try
            all_connect()
            cmd.CommandText = "select * from sales_bill where bill_date=@bill_date"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("bill_date", Me.DateTimePicker1.Value.Date)
            adp.SelectCommand = cmd
            dt.Clear()
            adp.Fill(dt)
            If dt.Rows.Count = 0 Then
                MsgBox("No Sales are made on this date.", MsgBoxStyle.Information, "Information")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        sel = "Day({sales_bill.bill_date})=" & Me.DateTimePicker1.Value.Day & " and Month({sales_bill.bill_date})=" & Me.DateTimePicker1.Value.Month & " and Year({sales_bill.bill_date})=" & Me.DateTimePicker1.Value.Year
        crystalsale.WindowState = FormWindowState.Maximized
        crystalsale.Show()

    End Sub

    Private Sub btnsho_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsho.Click
        Dim dt2 As New DataTable
        If Me.ComboBox3.Text = "" Then
            MsgBox("Please Select the year", MsgBoxStyle.Information, "Warning")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "select * from sales_bill where Year(bill_date)='" & Me.ComboBox3.Text & "'"
            adp.SelectCommand = cmd
            dt2.Clear()
            adp.Fill(dt2)
            If dt2.Rows.Count = 0 Then
                MsgBox("Selected Year does not have any Transactions", MsgBoxStyle.Information, "Information")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        sel = "Year({sales_bill.bill_date})=" & Me.ComboBox3.Text
        crystalsale.WindowState = FormWindowState.Maximized
        crystalsale.Show()
    End Sub

    Private Sub ComboBox4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox4.Click
        Dim dt As New DataTable
        Try
            all_connect()
            cmd.CommandText = "select bill_no from sales_bill"
            adp.SelectCommand = cmd
            dt.Clear()
            adp.Fill(dt)
            Me.ComboBox4.Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.ComboBox4.Items.Add(dt.Rows(i).Item(0))
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub Salesreport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DateTimePicker1.Value = Today.Date
    End Sub

    
   
   
    Private Sub btncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncl.Click
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

    Private Sub ComboBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox4.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.ComboBox4.Focus()
            e.Handled = True
        End If
    End Sub
End Class