Imports System.Data.SqlClient
Imports System.Data
Public Class purchasereport
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim bds As New BindingSource
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Me.ComboBox1.Text = ""
        Me.ComboBox2.Text = ""
        Me.ComboBox3.Text = ""
    End Sub

    Private Sub TxtOrderNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtodrerno.KeyPress
        If (Char.IsWhiteSpace(e.KeyChar)) Then
            e.Handled = True
        End If
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.ProcessTabKey(True)
            Me.btnorder.Focus()
        End If
    End Sub

    Private Sub btnorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnorder.Click
        If Me.txtodrerno.Text = "PO" Or Me.txtodrerno.Text = "" Then
            MsgBox("Please Enter Order Number to Display Report", MsgBoxStyle.Information, "Warning")
            Exit Sub
        End If
        Try
            all_Connect()
            cmd.CommandText = "SELECT * FROM purchase_bill WHERE order_no ='" & Me.txtodrerno.Text & "'"
            If cmd.ExecuteScalar = "" Then
                MsgBox("Report Doesnot Exist.. Please check the Order no", MsgBoxStyle.Information, "Warning")
                Exit Sub
            End If
            reportstr = "{purchase_bill.order_no}='" & Me.txtodrerno.Text & "'"
            crystalpur.WindowState = FormWindowState.Maximized
            crystalpur.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub


    Private Sub ComboBox3_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.DropDown
        Me.ComboBox3.Items.Clear()
        For i As Integer = 2010 To Today.Year
            Me.ComboBox3.Items.Add(i.ToString)
        Next
    End Sub

    Private Sub btnyearly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnyearly.Click
        If Me.ComboBox3.Text = "" Then
            MsgBox("Please select Year to Display Report", MsgBoxStyle.Information, "Warning")
            Exit Sub
        End If
        Try
            all_Connect()
            cmd.CommandText = "SELECT * FROM purchase_bill WHERE  YEAR(bill_date) =" & Val(Me.ComboBox3.Text)
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            If dt.Rows.Count = 0 Then
                MsgBox("No Records Found for selected Year", MsgBoxStyle.Information, "Warning")
                Exit Sub
            End If
            ReportStr = "year({purchase_bill.bill_date})=" & Me.ComboBox3.Text
            crystalpur.WindowState = FormWindowState.Maximized
            crystalpur.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub ComboBox2_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.DropDown
        Me.ComboBox2.Items.Clear()
        For i As Integer = 2010 To Today.Year
            Me.ComboBox2.Items.Add(i.ToString)
        Next
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub btnclos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclos.Click
        Me.Close()
    End Sub

    Private Sub btnclo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclo.Click
        Me.Close()
    End Sub

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
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
            cmd.CommandText = "SELECT * FROM purchase_bill WHERE MONTH(bill_date) =" & m & "AND  YEAR(bill_date) =" & Val(Me.ComboBox2.Text)
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            If dt.Rows.Count = 0 Then
                MsgBox("No Records Found for selected month and year", MsgBoxStyle.Information, "Warning")
                Exit Sub
            End If
            ReportStr = "month({purchase_bill.bill_date})=" & m & " and year({purchase_bill.bill_date})=" & Me.ComboBox2.Text
            crystalpur.WindowState = FormWindowState.Maximized
            crystalpur.Show()
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

    Private Sub txtodrerno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtodrerno.TextChanged

    End Sub
End Class