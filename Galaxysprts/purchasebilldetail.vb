Imports System.Data.SqlClient
Imports System.Data
Public Class purchasebilldetail
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim bds As New BindingSource
    Dim db As New DataTable
    Dim dt1 As New DataTable
    Dim rowIndex As Integer
    Public Sub All_Clear()
        Me.ComboBox2.Text = ""
        Me.txtqorder.Text = ""
        Me.txtqreceive.Text = ""
        Me.txtcprice.Text = ""
        Me.txtamt.Text = ""
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If Me.ComboBox2.Text = "" Or Me.txtqorder.Text = "" Or Me.txtqreceive.Text = "" Or Me.txtcprice.Text = "" Or Me.txtamt.Text = "" Or Me.txtrno.Text = "" Or Me.ComboBox1.Text = "" Then
            MsgBox("Please Enter all Fields..", MsgBoxStyle.Information, "Warning")
            Exit Sub
        End If
        Dim flag = 0, rowval = 0
        For k As Integer = 0 To db.Rows.Count - 1
            If db.Rows(k).Item(1) = Me.ComboBox2.Text Then
                rowval = k
                flag = 1
                Exit For
            End If
        Next
        If flag = 1 Then
            Me.db.Rows.RemoveAt(rowval)
        End If
        Dim grand As Decimal
        Me.Panel2.Enabled = False
        If Me.db.Columns.Count = 0 Then
            db.Columns.Add("Reciept No")
            db.Columns.Add("Item ID")
            db.Columns.Add("Quantity Ordered")
            db.Columns.Add("Quantity Recieved")
            db.Columns.Add("Price")
            db.Columns.Add("Total Amount")
            Me.DataGridView1.DataSource = db
            db.Rows.Add(Me.txtrno.Text, Me.ComboBox2.Text, Me.txtqorder.Text, Me.txtqreceive.Text, Me.txtcprice.Text, Me.txtamt.Text)
        Else
            db.Rows.Add(Me.txtrno.Text, Me.ComboBox2.Text, Me.txtqorder.Text, Me.txtqreceive.Text, Me.txtcprice.Text, Me.txtamt.Text)
        End If
        For i As Integer = 0 To db.Rows.Count - 1
            grand = grand + db.Rows(i).Item(5)
        Next
        Me.lbltotal.Text = grand
        Me.btnnew.Enabled = False
        Me.txtcprice.Enabled = False
        Me.txtqreceive.Enabled = False
        Me.ComboBox2.Enabled = True
        Me.lbltotal.Visible = True
        All_Clear()
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.ComboBox1.Focus()
            e.Handled = True
        End If
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Me.Panel3.Enabled = True
        cnn.Close()
        Try
            all_connect()
            Me.ComboBox2.Items.Clear()
            cmd.CommandText = "select item_id from purchase_order_details where order_no='" & Me.ComboBox1.Text & "'"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            All_Clear()
            Dim j
            For j = 0 To dt.Rows.Count - 1
                Me.ComboBox2.Items.Add(dt.Rows(j).Item(0))
            Next
            cmd.CommandText = "select supplier_id from purchase_order_details where order_no='" & Me.ComboBox1.Text & "'"
            Me.txtsupid.Text = cmd.ExecuteScalar
            cmd.CommandText = "select supplier_name from suppliers where supplier_id='" & Me.txtsupid.Text & "'"
            Me.txtname.Text = cmd.ExecuteScalar
            Me.ComboBox2.Enabled = True
            Me.ComboBox2.Focus()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try

    End Sub

    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox2.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.ComboBox2.Focus()
            e.Handled = True
        End If
    End Sub
    Private Sub ComboBox2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.Leave
        For i As Integer = 0 To db.Rows.Count - 1
            If db.Rows(i).Item(1) = Me.ComboBox2.Text Then
                MsgBox("Item already Entered to the Bill...!!", MsgBoxStyle.Information, "Warning")
                All_Clear()
                Me.ComboBox2.SelectedText = ""
                Me.ComboBox2.Focus()
            End If
        Next
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
            cnn.Close()
            all_connect()
            cmd.CommandText = "select qty from purchase_order_details where order_no='" & Me.ComboBox1.Text & "' and item_id='" & Me.ComboBox2.Text & "'"
            Me.txtqorder.Text = cmd.ExecuteScalar
            Me.txtqreceive.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        Me.txtcprice.Enabled = True
        Me.txtqreceive.Enabled = True
        Me.txtamt.Enabled = False
        Me.txtcprice.Focus()
        Me.txtcprice.Enabled = True
        Me.txtqreceive.Enabled = True

    End Sub
    Private Sub Txtcprice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcprice.KeyPress
        If (sender.Text.Contains(".") And (e.KeyChar.ToString = ".")) Then
            e.Handled = True
            Exit Sub
        End If
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = "." Or Char.IsControl(e.KeyChar)) Then
            MsgBox("Enter only numbers...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub
    Private Sub Txtcprice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcprice.TextChanged
        Me.txtamt.Text = Val(Me.txtqreceive.Text) * Val(Me.txtcprice.Text)
    End Sub
    Private Sub Txtqreceive_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqreceive.KeyPress
        If (sender.Text.Contains(".") And (e.KeyChar.ToString = ".")) Then
            e.Handled = True
            Exit Sub
        End If
        If Not (Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
            MsgBox("Enter only numbers...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub
    Private Sub Txtqreceive_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqreceive.TextChanged
        Try
            cnn.Close()
            all_connect()
            Me.txtamt.Text = Val(Me.txtqreceive.Text) * Val(Me.txtcprice.Text)
            If Val(Me.txtqreceive.Text) > Val(Me.txtqorder.Text) Then
                MsgBox("Quantity Recieved CANNOT be GREATER then Quantity ordered...!!", MsgBoxStyle.Information, "Warning")
                Me.txtqreceive.Text = ""
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            If Me.DataGridView1.Rows.Count = 0 Then
                MsgBox("There are no items in the bill to save")
                Exit Sub
            End If
            Dim a As Integer
            all_connect()
            cmd.CommandText = "insert into purchase_bill values(@reciept_no,@order_no,@bill_date,@supplier_id,@tot_amt)"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@reciept_no", SqlDbType.NVarChar).Value = Me.txtrno.Text
            cmd.Parameters.Add("@order_no", SqlDbType.NVarChar).Value = Me.ComboBox1.Text
            cmd.Parameters.Add("@bill_date", SqlDbType.DateTime).Value = Me.DateTimePicker1.Value.Date
            cmd.Parameters.Add("@supplier_id", SqlDbType.NVarChar).Value = Me.txtsupid.Text
            cmd.Parameters.Add("@tot_amt", SqlDbType.Float).Value = Val(Me.lbltotal.Text)
            cmd.ExecuteNonQuery()
            For i As Integer = 0 To Me.DataGridView1.RowCount - 2
                cmd.CommandText = "insert into purchase_bill_details values(@reciept_no,@item_id,@qty_ordered,@qty_received,@cost_price,@tot_amt)"
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@reciept_no", SqlDbType.NVarChar).Value = Me.txtrno.Text
                cmd.Parameters.Add("@item_id", SqlDbType.NVarChar).Value = Me.DataGridView1.Item(1, i).Value
                cmd.Parameters.Add("@qty_ordered", SqlDbType.Int).Value = Me.DataGridView1.Item(2, i).Value
                cmd.Parameters.Add("@qty_received", SqlDbType.Int).Value = Me.DataGridView1.Item(3, i).Value
                cmd.Parameters.Add("@cost_price", SqlDbType.Float).Value = Me.DataGridView1.Item(4, i).Value
                cmd.Parameters.Add("@tot_amt", SqlDbType.Float).Value = Me.DataGridView1.Item(5, i).Value
                cmd.ExecuteNonQuery()
            Next
            MsgBox("Purchase Bill Saved and Stock Updated..", MsgBoxStyle.Information, "Save Message")
            For i As Integer = 0 To Me.DataGridView1.RowCount - 2
                cmd.CommandText = "select qty from stock where item_id='" & Me.DataGridView1.Item(1, i).Value & "'"
                a = cmd.ExecuteScalar
                a = a + Me.DataGridView1.Item(3, i).Value
                cmd.CommandText = "update stock set qty=" & a & " where item_id='" & Me.DataGridView1.Item(1, i).Value & "'"
                cmd.ExecuteNonQuery()
            Next
            Me.btnsave.Enabled = False
            Me.btnnew.Enabled = True
            Me.Panel1.Enabled = False
            Me.Panel3.Enabled = False
            Me.Panel2.Enabled = False
            '  Me.btnEdit.Enabled = True
            Me.DataGridView1.Columns.Clear()
            db.Rows.Clear()
            db.Columns.Clear()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        All_Clear()
        Me.txtrno.Text = ""
        Me.ComboBox1.Text = ""
        Me.txtsupid.Text = ""
        Me.txtname.Text = ""
        Me.lbltotal.Text = ""
    End Sub
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub
    Private Sub DataGridView1_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseUp
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                Me.DataGridView1.Rows(e.RowIndex).Selected = True
                Me.rowIndex = e.RowIndex
                Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(e.RowIndex).Cells(1)
                If rowIndex <= Me.DataGridView1.Rows.Count - 2 Then
                    Me.ContextMenuStrip1.Show(Me.DataGridView1, e.Location)
                    ContextMenuStrip1.Show(Windows.Forms.Cursor.Position)
                End If
            End If
        Catch ex As ArgumentOutOfRangeException
        End Try
    End Sub
    Private Sub ContextItemRemoveItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            If Not Me.DataGridView1.Rows(Me.rowIndex).IsNewRow Then
                Me.DataGridView1.Rows.RemoveAt(Me.rowIndex)
                If Me.DataGridView1.Rows.Count = 1 Then
                    db.Rows.Clear()
                    db.Columns.Clear()
                End If
                Me.lbltotal.Text = ""
                Dim grand = 0
                For i As Integer = 0 To db.Rows.Count - 1
                    grand = grand + db.Rows(i).Item(5)
                Next
                Me.lbltotal.Text = grand
                ContextMenuStrip1.Close()
            End If
        Catch ex As ArgumentOutOfRangeException
        End Try
    End Sub
    Private Sub ContextItemEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Try
            If Me.rowIndex > Me.DataGridView1.Rows.Count - 1 Then
                Exit Sub
            End If
            Me.txtrno.Text = Me.DataGridView1.Item(0, Me.rowIndex).Value
            Me.ComboBox2.Text = Me.DataGridView1.Item(1, Me.rowIndex).Value
            Me.txtqorder.Text = Me.DataGridView1.Item(2, Me.rowIndex).Value
            Me.txtqreceive.Text = Me.DataGridView1.Item(3, Me.rowIndex).Value
            Me.txtcprice.Text = Me.DataGridView1.Item(4, Me.rowIndex).Value
            Me.txtamt.Text = Me.DataGridView1.Item(5, Me.rowIndex).Value
            Me.ComboBox2.Enabled = False
        Catch ex As InvalidCastException
        Catch ex As ArgumentOutOfRangeException
        End Try
        Me.ComboBox2.Enabled = True
        Me.txtqreceive.Enabled = True
    End Sub
    Private Sub BtnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        All_Clear()
        Me.ComboBox2.Enabled = True
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If Me.DateTimePicker1.Value > Today Then
            MsgBox("Bill Date CANNOT be GREATER then TODAY...", MsgBoxStyle.Information, "Warning")
            Me.DateTimePicker1.Value = Today
            Exit Sub
        End If
    End Sub
    Private Sub purchsebilldetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtsupid.ReadOnly = True
        Me.txtname.ReadOnly = True
        Me.ComboBox2.Enabled = False
        Me.txtqorder.Enabled = False
        Me.txtcprice.Enabled = False
        Me.txtqreceive.Enabled = False
        Me.txtamt.Enabled = False
        Me.DateTimePicker1.Enabled = False
        Me.ComboBox1.Enabled = False
        Me.btnclear.Visible = True
        Me.txtrno.Enabled = False
    End Sub
    Private Sub btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnew.Click
        Me.Panel1.Enabled = True
        Me.Panel2.Enabled = True
        ' Me.btnEdit.Enabled = False
        Dim n As String
        Dim m As Integer
        Dim x As Integer
        Try
            all_connect()
            All_Clear()
            Me.Panel1.Enabled = True
            If Me.txtrno.Text = "" Then
                cmd.CommandText = "select max(receipt_no) from purchase_bill"
                Dim id = cmd.ExecuteScalar
                If IsDBNull(id) Then
                    id = "REC101"
                Else
                    n = id
                    x = n.Substring(3)
                    m = Int(x)
                    m = m + 1
                    id = "REC" & m
                End If
                Me.txtrno.Text = id
                Me.txtrno.ReadOnly = True
                Me.DateTimePicker1.Enabled = False
            End If
            Me.ComboBox1.Items.Clear()
            cmd.CommandText = "Select  order_no  FROM  purchase_order WHERE (order_no NOT IN (SELECT order_no FROM purchase_bill))"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Dim i
            For i = 0 To dt.Rows.Count - 1
                Me.ComboBox1.Items.Add(dt.Rows(i).Item(0))
            Next
            If dt.Rows.Count = 0 Then
                MsgBox("Bills for all Purchase Orders have ben saved", MsgBoxStyle.Information, "Warning")
                'Me.btnEdit.Enabled = True
                Me.Close()
                Exit Sub
            End If
            Me.btnsave.Enabled = True
            Me.DateTimePicker1.Value = Today.Date
            Me.ComboBox1.Enabled = True
            Me.ComboBox1.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
End Class
