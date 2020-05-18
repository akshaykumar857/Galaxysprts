Imports System.Data.SqlClient
Imports System.Data
Public Class Purchasebilldisplay
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim bds As New BindingSource
    Dim db As New DataTable
    Dim dt1 As New DataTable
    Dim rowIndex As Integer
    Public Sub display()
        Try
            all_connect()
            cmd.CommandText = "select * from purchase_bill_details where qty_ordered<>qty_recieved"
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
    Private Sub EditBillToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditBillToolStripMenuItem.Click
        Try
            If Me.rowIndex > Me.DataGridView1.Rows.Count - 1 Then
                Exit Sub
            End If
            Me.txtrno.Text = Me.DataGridView1.Item(0, Me.rowIndex).Value
            Me.txtid.Text = Me.DataGridView1.Item(1, Me.rowIndex).Value
            Me.txtqtyor.Text = Me.DataGridView1.Item(2, Me.rowIndex).Value
            Me.txtcprice.Text = Me.DataGridView1.Item(4, Me.rowIndex).Value
            Me.txtqrecv.Text = Me.DataGridView1.Item(3, Me.rowIndex).Value
            Me.txttot.Text = Me.DataGridView1.Item(5, Me.rowIndex).Value
        Catch ex As InvalidCastException
        Catch ex As ArgumentOutOfRangeException
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub DataGridView1_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseUp
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                Me.DataGridView1.Rows(e.RowIndex).Selected = True
                Me.rowIndex = e.RowIndex
                Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(e.RowIndex).Cells(1)
                If Me.rowIndex <= Me.DataGridView1.Rows.Count - 2 Then
                    Me.ContextMenuStrip1.Show(Me.DataGridView1, e.Location)
                    Me.ContextMenuStrip1.Show(Windows.Forms.Cursor.Position)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Purchasebilldisplay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        display()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.txtqrecv.Text = "" Then
            MsgBox("Please Enter Qty Received")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "update purchase_bill_details set receipt_no=@receipt_no,item_id=@item_id,qty_ordered=@qty_ordered,qty_recieved=@qty_recieved,cost_price=@cost_price,tot_amt=@tot_amt where receipt_no=@receipt_no and item_id=@item_id"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@receipt_no", SqlDbType.NVarChar).Value = Me.txtrno.Text
            cmd.Parameters.Add("@item_id", SqlDbType.NVarChar).Value = Me.txtid.Text
            cmd.Parameters.Add("@qty_ordered", SqlDbType.Int).Value = Val(Me.txtqtyor.Text)
            cmd.Parameters.Add("@qty_recieved", SqlDbType.Int).Value = Val(Me.txtqrecv.Text)
            cmd.Parameters.Add("@cost_price", SqlDbType.Float).Value = Val(Me.txtcprice.Text)
            cmd.Parameters.Add("@tot_amt", SqlDbType.Float).Value = Val(Me.txttot.Text)

            cmd.ExecuteNonQuery()
            MsgBox("Record UPDATED....", MsgBoxStyle.Information, "Message")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        display()
        Me.txttot.Text = ""
        Me.txtrno.Clear()
        Me.txtqtyor.Clear()
        Me.txtqrecv.Clear()
        Me.txtcprice.Clear()
        Me.txtid.Clear()
    End Sub

    Private Sub txtqrecv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqrecv.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
            MsgBox("enter only numbers...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub txtqrecv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqrecv.TextChanged
        Try
            cnn.Close()
            all_connect()
            Me.txttot.Text = Val(Me.txtqrecv.Text) * Val(Me.txtcprice.Text)
            If Val(Me.txtqrecv.Text) > Val(Me.txtqtyor.Text) Then
                MsgBox("Quantity Recieved CANNOT be GREATER then Quantity ordered...!!", MsgBoxStyle.Information, "Warning")
                Me.txtqrecv.Text = ""
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try

    End Sub

    Private Sub txttot_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttot.TextChanged
        Me.Label9.Text = Val(Me.txttot.Text) - Me.DataGridView1.Item(5, Me.rowIndex).Value
        If Val(Me.Label9.Text) < 0 Then
            Me.Label9.Visible = False
        Else
            Me.Label9.Visible = True
        End If
    End Sub
End Class