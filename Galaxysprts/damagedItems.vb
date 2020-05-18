Imports System.Data.SqlClient
Imports System.data
Public Class DamagedItems
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim bds As New BindingSource
    Dim rowIndex As Integer
    Public db As New DataTable
    Public qtyrecived As Integer
    Public Sub All_Clear()
        Me.txtorderno.Clear()
        Me.txtsupid.Clear()
        Me.txtsupname.Clear()
        Me.ComboBox1.Text = ""
        Me.lbltotal.Text = ""
    End Sub
    Public Sub abc()
        Dim itemname
        Try
            cnn.Close()
            all_connect()
            cmd.CommandText = "select item_name from stock where item_id ='" & Me.DataGridView1.Item(1, rowIndex).Value & "'"
            itemname = cmd.ExecuteScalar
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        If damagedqty.qtydamage > 0 Then
            If Me.db.Columns.Count = 0 Then
                db.Columns.Add("Reciept No")
                db.Columns.Add("Item ID")
                db.Columns.Add("Item Name")
                db.Columns.Add("Quantity Damaged")
                db.Columns.Add("Total Amount")
                Me.DataGridView2.DataSource = db
            End If
            Dim amount = Me.DataGridView1.Item(4, rowIndex).Value * damagedqty.qtydamage
            db.Rows.Add(Me.DataGridView1.Item(0, rowIndex).Value, Me.DataGridView1.Item(1, rowIndex).Value, itemname, damagedqty.qtydamage, amount)
            damagedqty.Close()
            Me.Panel1.Enabled = False
            Me.btnsave.Enabled = True
        End If
    End Sub

    Private Sub ComboBox1_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDown
        Me.ComboBox1.Items.Clear()
        Try
            all_connect()
            cmd.CommandText = " Select  receipt_no  FROM  purchase_bill WHERE (receipt_no NOT IN (SELECT numbers FROM damaged))"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Dim i
            For i = 0 To dt.Rows.Count - 1
                Me.ComboBox1.Items.Add(dt.Rows(i).Item(0))
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        Me.Label2.Visible = True
        Me.lbltotal.Visible = True
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.ComboBox1.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            all_connect()
            cmd.CommandText = "SELECT purchase_bill.order_no, purchase_bill.supplier_id, suppliers.supplier_name FROM purchase_bill INNER JOIN suppliers ON purchase_bill.supplier_id = suppliers.supplier_id WHERE purchase_bill.receipt_no ='" & Me.ComboBox1.Text & "'"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.txtorderno.Text = dt.Rows(i).Item(0)
                Me.txtsupid.Text = dt.Rows(i).Item(1)
                Me.txtsupname.Text = dt.Rows(i).Item(2)
            Next
            cmd.CommandText = "select * from purchase_bill_details where receipt_no='" & Me.ComboBox1.Text & "'"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Me.DataGridView1.DataSource = dt
            cmd.CommandText = "select tot_amt from purchase_bill where receipt_no='" & Me.ComboBox1.Text & "'"
            Me.lbltotal.Text = cmd.ExecuteScalar
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
                If rowIndex <= Me.DataGridView1.Rows.Count - 2 Then
                    Me.ContextMenuStrip1.Show(Me.DataGridView1, e.Location)
                    Me.ContextMenuStrip1.Show(Windows.Forms.Cursor.Position)
                End If
            End If
        Catch ex As ArgumentOutOfRangeException
        End Try
    End Sub


    Private Sub DataGridView2_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseUp
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                Me.DataGridView2.Rows(e.RowIndex).Selected = True
                Me.rowIndex = e.RowIndex
                Me.DataGridView2.CurrentCell = Me.DataGridView2.Rows(e.RowIndex).Cells(1)
                If rowIndex <= Me.DataGridView2.Rows.Count - 2 Then
                    Me.ContextMenuStrip2.Show(Me.DataGridView1, e.Location)
                    Me.ContextMenuStrip2.Show(Windows.Forms.Cursor.Position)
                End If
            End If
        Catch ex As ArgumentOutOfRangeException
        End Try
    End Sub

    Private Sub RemoveFromListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveFromListToolStripMenuItem.Click
        Try
            If Not Me.DataGridView2.Rows(Me.rowIndex).IsNewRow Then
                Me.DataGridView2.Rows.RemoveAt(Me.rowIndex)
                If Me.DataGridView2.Rows.Count = 1 Then
                    db.Rows.Clear()
                    db.Columns.Clear()
                    Me.btnsave.Enabled = False
                End If
            End If
        Catch ex As ArgumentOutOfRangeException
        End Try
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Me.ComboBox1.Text = "" Or Me.txtsupid.Text = "" Or Me.txtsupname.Text = "" Or Me.txtorderno.Text = "" Then
            MsgBox("please enter all feilds")
            Exit Sub
        End If
        If Me.DataGridView2.Rows.Count = 0 Then
            MsgBox("No Records to save", MsgBoxStyle.Information, "alert")
            Exit Sub
        End If
        Try
            cnn.Close()
            all_connect()
            For i As Integer = 0 To Me.DataGridView1.Rows.Count - 2
                cmd.CommandText = "insert into damaged values(@numbers,@item_id,@item_name,@supplier_id,@Qty_rejected,@amount,@flag)"
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@numbers", SqlDbType.VarChar).Value = Me.DataGridView2.Item(0, i).Value
                cmd.Parameters.Add("@item_id", SqlDbType.VarChar).Value = Me.DataGridView2.Item(1, i).Value
                cmd.Parameters.Add("@item_name", SqlDbType.VarChar).Value = Me.DataGridView2.Item(2, i).Value
                cmd.Parameters.Add("@supplier_id", SqlDbType.VarChar).Value = Me.txtsupid.Text
                cmd.Parameters.Add("@Qty_rejected", SqlDbType.Int).Value = Me.DataGridView2.Item(3, i).Value
                cmd.Parameters.Add("@amount", SqlDbType.Float).Value = Me.DataGridView2.Item(4, i).Value
                cmd.Parameters.Add("@flag", SqlDbType.Int).Value = 0
                cmd.ExecuteNonQuery()
                cmd.CommandText = "select qty from stock where item_id='" & Me.DataGridView2.Item(1, i).Value & "'"
                Dim a = cmd.ExecuteScalar
                a = a - Me.DataGridView1.Item(3, i).Value
                cmd.CommandText = "update stock set qty=" & a & " where item_id='" & Me.DataGridView2.Item(1, i).Value & "'"
                cmd.ExecuteNonQuery()
            Next
            MsgBox("Damaged List Saved", MsgBoxStyle.Information, "Save Message")
            Me.DataGridView2.Columns.Clear()
            Me.db.Columns.Clear()
            Me.db.Rows.Clear()
            Me.DataGridView1.Columns.Clear()
            Me.Panel1.Enabled = True
            Me.btnsave.Enabled = False
            All_Clear()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub DamagedItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ComboBox1.Select()
    End Sub

    Private Sub AddToDamageListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToDamageListToolStripMenuItem.Click
        If Me.DataGridView2.Rows.Count <> 0 Then
            Dim flag = 0
            For k As Integer = 0 To db.Rows.Count - 1
                If Me.DataGridView1.Item(1, rowIndex).Value = Me.DataGridView2.Item(1, k).Value Then
                    flag = 1
                    Exit For
                End If
            Next
            If flag = 1 Then
                MsgBox("Item already added to Damage List", MsgBoxStyle.Information, "Warning")
                Exit Sub
            End If
        End If
        qtyrecived = Me.DataGridView1.Item(3, rowIndex).Value
        damagedqty.Show()
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub
End Class
