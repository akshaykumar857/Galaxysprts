Imports System.Data.SqlClient
Imports System.Data
Public Class salesreturndisplay
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim bds As New BindingSource
    Dim db, db1 As New DataTable
    Dim dr As SqlDataReader
    Public Sub display()
        Try
            all_connect()
            cmd.CommandText = "select * from sales_return_details"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Me.DataGridView1.DataSource = dt
            DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    'Private Sub sales_display_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    display()
    'End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        Try
            all_connect()
            If Me.ComboBox1.Text = "Sales Return No" Then
                Me.DataGridView1.Visible = True
                cmd.CommandText = "Select * from  sales_return_details where sr_no='" & Me.txtsearch.Text & "'"
            ElseIf Me.ComboBox1.Text = "Sales Return Date" Then
                cmd.CommandText = "select  * from sales_return_details where sr_no in(select sr_no from sales_return where Day(return_date)= '" & Me.DateTimePicker1.Value.Day & "' and Month(return_date)='" & Me.DateTimePicker1.Value.Month & "' and Year(return_date)='" & Me.DateTimePicker1.Value.Year & "')"
                Me.DataGridView1.Visible = True
            ElseIf Me.ComboBox1.Text = "Status" Then
                cmd.CommandText = "select  * from sales_return_details where status='" & Me.ComboBox2.SelectedItem & "'"
                Me.DataGridView1.Visible = True
            End If
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            If dt.Rows.Count = 0 Then
                MsgBox("No records Found", MsgBoxStyle.Information, "Information")
            End If
            Me.DataGridView1.DataSource = dt
            DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        Dim flag As Integer = 0
        For i As Integer = 0 To Me.DataGridView1.RowCount - 1
            If Me.DataGridView1.Rows(i).Cells(0).Value = Me.TxtSearch.Text Then
                Me.DataGridView1.MultiSelect = False
                Me.DataGridView1.Rows(i).Selected = True
                Me.DataGridView1.FirstDisplayedScrollingRowIndex = i
                flag = 1
            End If
        Next
        'If flag = 0 Then
        '    MsgBox("Record Does not Exist....", MsgBoxStyle.Information, "Message")
        '    Me.TxtSearch.Text = "SR"
        'End If
    End Sub

    Private Sub txtsearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsearch.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.ProcessTabKey(True)
            Me.btnsearch.Focus()
        End If
    End Sub
    Private Sub TxtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearch.TextChanged
        Try
            all_connect()
            If Me.ComboBox1.Text = "Sales Return No" Then

                cmd.CommandText = "Select * from  sales_return_details where sr_no like '" & Me.txtsearch.Text & "%'"
            End If
            'If Me.txtsearch.Text = "" Or Me.txtsearch.Text = "SR" Then
            '    cmd.CommandText = "Select * from  sales_return_details"
            'End If
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            If dt.Rows.Count = 0 Then
                MsgBox("No Records Found")
            End If
            Me.DataGridView1.DataSource = dt
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

   
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If Me.ComboBox1.Text = "Sales Return No" Then
            Me.ComboBox2.Visible = False
            Me.txtsearch.Show()
            Me.txtsearch.Text = "SR"
            Me.btnsearch.Visible = False
            Me.DateTimePicker1.Hide()
        ElseIf Me.ComboBox1.Text = "Status" Then
            Me.txtsearch.Visible = False
            Me.DataGridView1.Visible = False
            Me.ComboBox2.Text = ""
            Me.ComboBox2.Visible = True
            Me.DateTimePicker1.Hide()
            Me.btnsearch.Visible = True
        Else
            Me.DataGridView1.Visible = False
            Me.txtsearch.Hide()
            Me.ComboBox2.Visible = False
            Me.DateTimePicker1.Show()
            Me.txtsearch.Text = ""
            Me.btnsearch.Visible = True
        End If
    End Sub
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If Me.DateTimePicker1.Value > Date.Today Then
            ' MsgBox("date is greater")
            Me.DateTimePicker1.Value = Today
        End If
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub
End Class
