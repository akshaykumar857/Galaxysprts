Imports System.Data.SqlClient
Imports System.Data
Public Class salesdisplay

    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim bds As New BindingSource
    Dim db, db1 As New DataTable
    Dim dr As SqlDataReader
    Public Sub display()
        Try
            all_connect()
            cmd.CommandText = "select * from sales_bill_details"
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
    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        Try
            all_connect()
            If Me.ComboBox1.Text = "Bill No" Then
                cmd.CommandText = "Select * from  sales_bill_details where bill_no='" & Me.txtsearch.Text & "'"
                adp.SelectCommand = cmd
                dt = New DataTable
                dt.Clear()
                adp.Fill(dt)
                Me.DataGridView1.DataSource = dt
                Me.DataGridView1.Visible = True
                DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            ElseIf Me.ComboBox1.Text = "Bill Date" Then
                Me.DataGridView1.Visible = False
                cmd.CommandText = "SELECT  * from sales_bill_details where bill_no in(select bill_no from sales_bill where Day(bill_date) = '" & Me.DateTimePicker1.Value.Day & "' and Month(bill_date)='" & Me.DateTimePicker1.Value.Month & "' and Year(bill_date)='" & Me.DateTimePicker1.Value.Year & "')"
                adp.SelectCommand = cmd
                dt = New DataTable
                dt.Clear()
                adp.Fill(dt)
                If dt.Rows.Count = 0 Then
                    MsgBox("No Records  Found", MsgBoxStyle.Information, "Information")
                    Me.DataGridView1.Visible = False
                End If
                Me.DataGridView1.Visible = True
                Me.DataGridView1.DataSource = dt
                DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        Dim flag As Integer = 0
        For i As Integer = 0 To Me.DataGridView1.RowCount - 1
            If Me.DataGridView1.Rows(i).Cells(0).Value = Me.txtsearch.Text Then
                Me.DataGridView1.MultiSelect = False
                Me.DataGridView1.Rows(i).Selected = True
                Me.DataGridView1.FirstDisplayedScrollingRowIndex = i
                flag = 1
            End If
        Next
        If flag = 0 Then
            MsgBox("Record Does not Exist....", MsgBoxStyle.Information, "Message")
            Me.txtsearch.Text = "SB"
            Me.DataGridView1.Visible = False
        End If
    End Sub

    Private Sub txtsearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsearch.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.ProcessTabKey(True)
            Me.btnsearch.Focus()
        End If
    End Sub
    Private Sub TxtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        Try
            all_connect()
            If Me.ComboBox1.Text = "Bill No" Then
                Me.DataGridView1.Visible = True
                cmd.CommandText = "Select * from  sales_bill_details where bill_no like '" & Me.txtsearch.Text & "%'"
                Me.btnsearch.Visible = False
            Else
                Me.DataGridView1.Visible = False
            End If
            'If Me.txtsearch.Text = "" Or Me.txtsearch.Text = "SB" Then
            '    cmd.CommandText = "Select * from  sales_bill_details"
            'End If
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
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

    Private Sub Combobox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If Me.ComboBox1.Text = "Bill No" Then
            Me.txtsearch.Show()
            Me.txtsearch.Text = "SB"
            Me.DateTimePicker1.Hide()
        Else
            Me.txtsearch.Hide()
            Me.DateTimePicker1.Show()
            Me.txtsearch.Text = ""
            Me.btnsearch.Visible = True
        End If
    End Sub
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If Me.DateTimePicker1.Value > Date.Today Then
            'MsgBox("date is greater")
            Me.DateTimePicker1.Value = Today
        End If
    End Sub
    Private Sub salesdisplay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.btnsearch.Visible = True
    End Sub

    Private Sub Btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub
End Class