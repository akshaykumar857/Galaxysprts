Imports System.Data.SqlClient
Imports System.Data
Public Class cancel_order
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt, dt1 As New DataTable
    Dim bds As New BindingSource
    Private Sub Cancel_Order_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cnn.Close()
        Me.ListBox1.Items.Clear()
        Try
            all_connect()
            cmd.CommandText = "SELECT order_no from purchase_order where order_no not in(select order_no from purchase_bill)"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            cnn.Close()
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.ListBox1.Items.Add(dt.Rows(i).Item(0))
            Next
            If Me.ListBox1.Items.Count = 0 Then
                MsgBox("There are No Pending Orders To Cancel", MsgBoxStyle.Information, "Message")
                Me.Close()
                Exit Sub
            End If
            Me.ListBox1.SelectedIndex = 0
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Try
            all_connect()
            cmd.CommandText = "SELECT item_id, item_name,group_name,units, qty FROM purchase_order_details where order_no ='" & Me.ListBox1.Text & "'"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Me.DataGridView1.DataSource = dt
            cmd.CommandText = "SELECT purchase_order_details.order_no, purchase_order_details.supplier_id, purchase_order.order_date  FROM  purchase_order_details CROSS JOIN purchase_order WHERE purchase_order_details.order_no ='" & Me.ListBox1.Text & "'"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.lblorder.Text = dt.Rows(0).Item(0)
                Me.lblsupplier.Text = dt.Rows(0).Item(1)
                Me.lbldate.Text = dt.Rows(0).Item(2)
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Close()
    End Sub
    Private Sub btncorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncorder.Click
        Dim result = MsgBox(" Order " & Me.ListBox1.Text & " Will be Deleted Permentaly " & vbCrLf & "  " & vbCrLf & "           Do you want to delete it ..?? ", MsgBoxStyle.YesNo, "Confirm Delete")
        If result = Windows.Forms.DialogResult.Yes Then
            Try
                all_connect()
                cmd.CommandText = "Delete from purchase_order_details where order_no='" & Me.ListBox1.Text & "'"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "Delete from purchase_order where order_no='" & Me.ListBox1.Text & "'"
                cmd.ExecuteNonQuery()
                MsgBox("Order " & Me.ListBox1.Text & " Deleted...", MsgBoxStyle.Information, "Delete Message")
                Me.DataGridView1.Columns.Clear()
                Me.lblsupplier.Text = ""
                Me.lblorder.Text = ""
                Me.lbldate.Text = ""
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                cnn.Close()
            End Try
        End If
        Cancel_Order_Load(sender, e)
    End Sub
End Class