Imports System.Data.SqlClient
Imports System.Data
Public Class salesreturns
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt, db, dt1, amt As New DataTable
    Dim bds As New BindingSource
    Public billNO, custId, qty
    Public dt2 As New DataTable
    Dim rowIndex As Integer
    Dim amount
    Public Sub display()
        Me.btnadd.Enabled = True
        Try
            all_connect()
            cmd.CommandText = "select * from sales_return_details"
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
    Public Sub All_Clear()
        Me.ComboBox2.Text = ""
        Me.txtiname.Text = ""
        Me.txtprice.Text = ""
        Me.txtqunreq.Text = ""
        Me.txtamt.Text = ""
        Me.ComboBox3.Text = ""
        Me.txtsqunty.Text = ""
    End Sub
    Private Sub Txtno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtno.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
            MsgBox("Enter only numbers...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub
    Private Sub salesreturns_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.btnsave.Enabled = False
        Try
            Me.btnsave.Enabled = False
            Me.ComboBox1.Enabled = False
            Me.Panel3.Enabled = False
            Me.txtbdate.ReadOnly = True
            Me.txtid.ReadOnly = True
            Me.txtno.ReadOnly = True
            Me.txtname.ReadOnly = True
            Me.txtamt.ReadOnly = True
            Me.DateTimePicker1.Value = Today.Date
            Me.DateTimePicker1.Enabled = False
            Me.txtamt.Enabled = False
            Me.txtprice.ReadOnly = True
            Me.txtiname.ReadOnly = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub ComboBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.Click
        Try
            Me.ComboBox1.Items.Clear()
            all_connect()
            cmd.CommandText = "Select bill_no FROM sales_bill WHERE(bill_date BETWEEN DATEADD(DD, - 15, GETDATE()) AND GETDATE()) AND (bill_no NOT IN(SELECT bill_no FROM  sales_return))"
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
            All_Clear()
            all_connect()
            cmd.CommandText = "select bill_date,cust_id from sales_bill where bill_no='" & Me.ComboBox1.Text & "'"
            adp.SelectCommand = cmd
            dt.Clear()
            adp.Fill(dt)
            Me.txtbdate.Text = dt.Rows(0).Item(1)
            Me.txtid.Text = dt.Rows(0).Item(2)
            cmd.CommandText = "select item_id from sales_bill_details where bill_no='" & Me.ComboBox1.Text & "'"
            adp.SelectCommand = cmd
            dt1.Clear()
            adp.Fill(dt1)
            Me.ComboBox2.Items.Clear()
            For i As Integer = 0 To dt1.Rows.Count - 1
                Me.ComboBox2.Items.Add(dt1.Rows(i).Item(0))
            Next
            Me.Panel3.Enabled = True
            Me.btnadd.Enabled = True
            Me.ComboBox2.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub Txtid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtid.TextChanged
        Try
            cnn.Close()
            all_connect()
            If Me.txtid.Text <> "" Then
                cmd.CommandText = "select cust_name,pno from customer where cust_id='" & Me.txtid.Text & "'"
                adp.SelectCommand = cmd
                dt.Clear()
                adp.Fill(dt)
                Me.txtno.Text = dt.Rows(0).Item(4)
                Me.txtname.Text = dt.Rows(0).Item(3)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub Btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnew.Click
        Dim n As String
        Dim m As Integer
        Dim x As Integer
        Try
            Me.txtrno.Text = ""
            Me.ComboBox1.Text = ""
            Me.txtid.Text = ""
            Me.txtbdate.Text = ""
            Me.ComboBox2.Text = ""
            Me.txtno.Text = ""
            Me.txtname.Text = ""
            All_Clear()
            Me.DataGridView1.Columns.Clear()
            db.Rows.Clear()
            db.Columns.Clear()
            If Me.txtrno.Text = "" Then
                all_connect()
                cmd.CommandText = "select max(sr_no) from sales_return"
                Dim id = cmd.ExecuteScalar
                If IsDBNull(id) Then
                    id = "SR101"
                Else
                    n = id
                    x = n.Substring(2)
                    m = Int(x)
                    m = m + 1
                    id = "SR" & m
                End If
                Me.txtrno.Text = id
                Me.txtrno.ReadOnly = True
            End If
            Me.btnnew.Enabled = False
            Me.Panel2.Enabled = True
            Me.ComboBox1.Enabled = True
            Me.ComboBox1.Focus()
            'Me.PanelCust.Visible = True
            'Me.PanelItems.Visible = True
            'Me.BtnClose.Visible = True
            'Me.BtnNew.Visible = True
            'Me.BtAdd.Visible = True
            'Me.PanelReturnNo.Visible = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
            cnn.Close()
            all_connect()
            cmd.CommandText = "select item_name from stock where item_id='" & Me.ComboBox2.Text & "'"
            adp.SelectCommand = cmd
            dt1.Clear()
            adp.Fill(dt1)
            For i As Integer = 0 To dt1.Rows.Count - 1
                Me.txtiname.Text = dt1.Rows(0).Item(1)
            Next
            cmd.CommandText = "select price from sales_bill_details where item_id='" & Me.ComboBox2.Text & "'and bill_no='" & Me.ComboBox1.Text & "'"
            Me.txtprice.Text = cmd.ExecuteScalar
            Me.txtqunreq.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub Txtqunreq_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtqunreq.Leave
        Try
            If Me.txtqunreq.Text <> "" Then
                cnn.Close()
                all_connect()
                cmd.CommandText = "select qty from sales_bill_details where item_id='" & Me.ComboBox2.Text & "' and bill_no='" & Me.ComboBox1.Text & "'"
                Dim qty As Integer = 0
                qty = cmd.ExecuteScalar
                If qty < Me.txtqunreq.Text Then
                    MsgBox("Quantity Returned value is greater then quantity purchased")
                    Me.txtqunreq.Text = ""
                    Me.txtqunreq.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub Txtqunreq_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqunreq.TextChanged
        amount = 0
        Me.txtamt.Text = Val(Me.txtqunreq.Text) * Val(Me.txtprice.Text)
        Me.txtqunreq.Focus()
    End Sub
    Private Sub Txtamt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtamt.Click
        Me.txtqunreq.Focus()
    End Sub
    Private Sub Txtamt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtamt.TextChanged
        Me.txtamt.Focus()
    End Sub
    Private Sub BtAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If Me.ComboBox1.Text = "" Or Me.txtid.Text = "" Or Me.txtiname.Text = "" Or Me.txtqunreq.Text = "" Or Me.ComboBox3.Text = "" Then
            MsgBox("Please Enter all Fields..")
            Exit Sub
        End If
        Try
            all_connect()
            
            Me.btnsave.Enabled = True
            For i As Integer = 0 To db.Rows.Count - 1
                If db.Rows(i).Item(1) = Me.ComboBox2.Text Then
                    MsgBox("Item already Entered to the database...!!")
                    All_Clear()
                    Me.ComboBox2.Text = ""
                    Me.ComboBox3.Text = ""
                    Exit Sub
                End If
            Next
            If db.Rows.Count = 0 Then
                db.Columns.Add("Returns No")
                db.Columns.Add("Item Id")
                db.Columns.Add("Item Name")
                db.Columns.Add("Quantity Rejected")
                db.Columns.Add("Amount")
                db.Columns.Add("Status")
                Me.DataGridView1.DataSource = db
                db.Rows.Add(Me.txtrno.Text, Me.ComboBox2.Text, Me.txtiname.Text, Me.txtqunreq.Text, Me.txtamt.Text, Me.ComboBox3.Text)
            Else
                db.Rows.Add(Me.txtrno.Text, Me.ComboBox2.Text, Me.txtiname.Text, Me.txtqunreq.Text, Me.txtamt.Text, Me.ComboBox3.Text)
            End If
            amt.Columns.Clear()
            amt.Rows.Clear()
            amt.Columns.Add("srnumber")
            amt.Columns.Add("amount")
            amt.Rows.Add(Me.txtrno.Text, amount)
            Dim a As Decimal
            For i As Integer = 0 To db.Rows.Count - 1
                a = a + db.Rows(i).Item(4)
            Next
            Me.lbltotal.Text = a
            Me.btnsave.Visible = True
            Me.btnnew.Enabled = False
            Me.Panel1.Enabled = False
            Me.ComboBox1.Enabled = False
            Me.DataGridView1.Visible = True
            Me.Label17.Visible = True
            Me.lbltotal.Visible = True
            Me.txtbdate.Enabled = False
            All_Clear()
            Me.ComboBox3.Text = ""
            Me.btnsave.Enabled = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Dim count = 0
        Try
            all_connect()
            cmd.CommandText = "insert into sales_return values(@sr_no,@return_date,@bill_no,@bill_date,@cust_id,@total)"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@sr_no", SqlDbType.NVarChar).Value = Me.txtrno.Text
            cmd.Parameters.Add("@return_date", SqlDbType.DateTime).Value = Me.DateTimePicker1.Value.Date
            cmd.Parameters.Add("@bill_no", SqlDbType.NVarChar).Value = Me.ComboBox1.Text
            cmd.Parameters.Add("@bill_date", SqlDbType.DateTime).Value = Me.txtbdate.Text
            cmd.Parameters.Add("@cust_id", SqlDbType.NVarChar).Value = Me.txtid.Text
            cmd.Parameters.Add("@total", SqlDbType.Float).Value = Me.lbltotal.Text
            cmd.ExecuteNonQuery()
            For i As Integer = 0 To Me.DataGridView1.RowCount - 2
                cmd.CommandText = "insert into sales_return_details values(@sr_no,@item_id,@item_name,@qty_rejected,@status,@total_amt)"
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@sr_no", SqlDbType.NVarChar).Value = Me.DataGridView1.Item(0, i).Value
                cmd.Parameters.Add("@item_id", SqlDbType.NVarChar).Value = Me.DataGridView1.Item(1, i).Value
                cmd.Parameters.Add("@item_name", SqlDbType.NVarChar).Value = Me.DataGridView1.Item(2, i).Value
                cmd.Parameters.Add("@qty_rejected", SqlDbType.Int).Value = Me.DataGridView1.Item(3, i).Value
                cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = Me.DataGridView1.Item(5, i).Value
                cmd.Parameters.Add("@total_amt", SqlDbType.Float).Value = Me.DataGridView1.Item(4, i).Value
                cmd.ExecuteNonQuery()

                If Me.DataGridView1.Item(5, i).Value = "Damaged" Then
                    cmd.CommandText = "select supplier_id from stock where item_id='" & Me.DataGridView1.Item(1, i).Value & "'"
                    Dim s = cmd.ExecuteScalar
                    Dim amnt
                    For j As Integer = 0 To amt.Rows.Count - 1
                        If amt.Rows(j).Item(0) = Me.DataGridView1.Item(0, j).Value Then
                            amnt = amt.Rows(j).Item(1)
                        End If
                    Next
                    cmd.CommandText = "insert into damaged values(@numbers,@item_id,@item_name,@supplier_id,@qty_rejected,@amount,@flag)"
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add("@numbers", SqlDbType.NVarChar).Value = Me.DataGridView1.Item(0, i).Value
                    cmd.Parameters.Add("@item_id", SqlDbType.NVarChar).Value = Me.DataGridView1.Item(1, i).Value
                    cmd.Parameters.Add("@item_name", SqlDbType.NVarChar).Value = Me.DataGridView1.Item(2, i).Value
                    cmd.Parameters.Add("supplier_id", SqlDbType.NVarChar).Value = s
                    cmd.Parameters.Add("@qty_rejected", SqlDbType.Int).Value = Me.DataGridView1.Item(3, i).Value
                    cmd.Parameters.Add("@amount", SqlDbType.Float).Value = amnt 'Me.DataGridView1.Item(4, i).Value
                    cmd.Parameters.Add("@flag", SqlDbType.Int).Value = 0
                    cmd.ExecuteNonQuery()
                End If
            Next
            billNO = ""
            custId = ""
            custId = Me.txtid.Text
            billNO = Me.ComboBox1.Text
            MsgBox("Return Details Stored Successfully", MsgBoxStyle.Information, "Save Message")
            cmd.CommandText = "select item_id from Sales_return_details where sr_no='" & Me.txtrno.Text & "'and status='Exchange'"
            adp.SelectCommand = cmd
            dt2.Clear()
            adp.Fill(dt2)
            All_Clear()
            Me.btnsave.Enabled = False
            Me.btnnew.Enabled = True
            Me.Panel1.Enabled = False
            Me.txtsqunty.Enabled = True
            Me.txtrno.Text = ""
            Me.ComboBox1.Text = ""
            Me.txtid.Text = ""
            Me.txtbdate.Text = ""
            Me.ComboBox2.Text = ""
            Me.txtno.Text = ""
            Me.txtname.Text = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        All_Clear()
        Me.Label17.Visible = False
        Me.lbltotal.Text = ""
        Me.DataGridView1.Columns.Clear()
        db.Rows.Clear()
        db.Columns.Clear()
        Me.Panel3.Enabled = False
    End Sub
    Private Sub DataGridView1_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseUp
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                Me.DataGridView1.Rows(e.RowIndex).Selected = True
                Me.rowIndex = e.RowIndex
                Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(e.RowIndex).Cells(1)
                Me.ContextMenuStrip1.Show(Me.DataGridView1, e.Location)
                ContextMenuStrip1.Show(Windows.Forms.Cursor.Position)
            End If
        Catch ex As ArgumentOutOfRangeException
        End Try
    End Sub
    Private Sub ComboBox2TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.TextChanged
        Try
            cnn.Close()
            all_connect()
            cmd.CommandText = "select qty from sales_bill_details where item_id='" & Me.ComboBox2.Text & "' and bill_no='" & Me.ComboBox1.Text & "'"
            Me.txtsqunty.Text = cmd.ExecuteScalar
            Me.txtsqunty.Enabled = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox3.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.ComboBox3.Focus()
            e.Handled = True
        End If
    End Sub
    Private Sub CombBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        If Me.ComboBox3.Text = "Damaged" Then
            amount = Val(Me.txtamt.Text)

        End If
    End Sub
    Private Sub Txtprice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtprice.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = "." Or Char.IsControl(e.KeyChar)) Then
            MsgBox("Enter only numbers...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub
    Private Sub Txtqunreq_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqunreq.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
            MsgBox("Enter only numbers...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub



    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            If Not Me.DataGridView1.Rows(Me.rowIndex).IsNewRow Then
                Me.DataGridView1.Rows.RemoveAt(Me.rowIndex)
                If Me.DataGridView1.Rows.Count = 1 Then
                    db.Rows.Clear()
                    db.Columns.Clear()
                    Me.btnsave.Enabled = False
                End If
            End If
        Catch ex As ArgumentOutOfRangeException
        End Try
    End Sub
    

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Try
            If Me.rowIndex > Me.DataGridView1.Rows.Count - 1 Then
                Exit Sub
            End If
            Me.txtrno.Text = Me.DataGridView1.Item(0, Me.rowIndex).Value
            Me.ComboBox2.Text = Me.DataGridView1.Item(1, Me.rowIndex).Value
            Me.txtiname.Text = Me.DataGridView1.Item(2, Me.rowIndex).Value
            Me.txtqunreq.Text = Me.DataGridView1.Item(3, Me.rowIndex).Value
            Me.txtamt.Text = Me.DataGridView1.Item(4, Me.rowIndex).Value
            Me.ComboBox3.Text = Me.DataGridView1.Item(5, Me.rowIndex).Value
            all_connect()
            cmd.CommandText = "select price from sales_bill_details where item_id='" & Me.ComboBox2.Text & "'and bill_no='" & Me.ComboBox1.Text & "'"
            Me.txtprice.Text = cmd.ExecuteScalar
            DeleteToolStripMenuItem_Click(sender, e)
        Catch ex As InvalidCastException
        Catch ex As ArgumentOutOfRangeException
        Catch ex As Exception
            MsgBox(e.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
End Class