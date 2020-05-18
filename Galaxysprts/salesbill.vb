Imports System.Data.SqlClient
Imports System.Data
Public Class salesbill
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim bds As New BindingSource
    Dim db As New DataTable
    Dim dt1 As New DataTable
    Dim rowIndex As Integer
    Public Sub All_Clear()
        Me.comboiid.Text = ""
        Me.txtitemname.Text = ""
        Me.combounits.Text = ""
        Me.txtprice.Text = ""
        Me.txtqun.Text = ""
        Me.txtvat.Text = ""
        Me.txtamt.Text = ""

    End Sub
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub comboiid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles comboiid.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.comboiid.Focus()
            e.Handled = True
        End If
    End Sub
    'Private Sub Comboiid_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboiid.LostFocus
    '    Me.ListBox1.Hide()
    'End Sub
    Private Sub Txtqun_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqun.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
            MsgBox("Enter only numbers...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub
    Private Sub Txtqun_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtqun.LostFocus
        Dim qty As Integer
        Try
            cnn.Close()
            all_connect()
            If Me.txtqun.Text = "" Then
                Exit Sub
            End If
            cmd.CommandText = "select qty from stock where item_id='" & Me.comboiid.Text & "'"
            qty = cmd.ExecuteScalar
            If qty < Me.txtqun.Text Then
                MsgBox("   Stock not available...!!" & vbCrLf & " Quantity in Stock is " & qty, MsgBoxStyle.Information, "Save Message")
                Me.txtamt.Clear()
                Me.txtqun.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        Me.txtamt.Text = (Val(Me.txtprice.Text) + Val(Me.txtvat.Text)) * Val(Me.txtqun.Text)
    End Sub
    Private Sub Txtqun_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqun.TextChanged, txtvat.TextChanged, txtprice.TextChanged
        Me.txtamt.Text = (Val(Me.txtprice.Text) + Val(Me.txtvat.Text)) * Val(Me.txtqun.Text)
    End Sub
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click

        If Me.txtdiscount.Text = "" Then
            MsgBox("Enter discount amount as 0" & vbCrLf & "If there is no discount and Please Click Calculate...!!", MsgBoxStyle.Information, "Information")
            Exit Sub
        End If
        If Me.txtgtotal.Text = "" Then
            MsgBox("Please Click Calculate...!!", MsgBoxStyle.Information, "Information")
            Exit Sub
        End If
        Dim a As Integer
        Try
            all_connect()
            cmd.CommandText = "insert into sales_bill values(@bill_no,@bill_date,@cust_id,@pno,@discount,@grand_tot)"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@bill_no", SqlDbType.NVarChar).Value = Me.txtbillno.Text
            cmd.Parameters.Add("@bill_date", SqlDbType.DateTime).Value = Me.DateTimePicker1.Value.Date
            cmd.Parameters.Add("@cust_id", SqlDbType.NVarChar).Value = Me.combocid.Text
            cmd.Parameters.Add("@pno", SqlDbType.BigInt).Value = Val(Me.txtphno.Text)
            cmd.Parameters.Add("@discount", SqlDbType.Float).Value = Val(Me.txtdiscount.Text)
            cmd.Parameters.Add("@grand_tot", SqlDbType.Float).Value = Val(Me.txtgtotal.Text)
            cmd.ExecuteNonQuery()
            For i As Integer = 0 To Me.DataGridView1.Rows.Count - 2
                cmd.CommandText = "insert into sales_bill_details values(@bill_no,@item_id,@unit_name,@qty,@price,@amount,@vat,@total)"
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@bill_no", SqlDbType.NVarChar).Value = Me.DataGridView1.Item(0, i).Value
                cmd.Parameters.Add("@item_id", SqlDbType.NVarChar).Value = Me.DataGridView1.Item(1, i).Value
                cmd.Parameters.Add("@unit_name", SqlDbType.NVarChar).Value = Me.DataGridView1.Item(2, i).Value
                cmd.Parameters.Add("@qty", SqlDbType.Int).Value = Me.DataGridView1.Item(3, i).Value
                cmd.Parameters.Add("@price", SqlDbType.Float).Value = Me.DataGridView1.Item(4, i).Value
                cmd.Parameters.Add("@amount", SqlDbType.Float).Value = Me.DataGridView1.Item(6, i).Value
                cmd.Parameters.Add("@vat", SqlDbType.Float).Value = Me.DataGridView1.Item(5, i).Value
                cmd.Parameters.Add("@total", SqlDbType.Float).Value = Me.DataGridView1.Item(7, i).Value
                cmd.ExecuteNonQuery()
                cmd.CommandText = "select qty from stock where item_id='" & Me.DataGridView1.Item(1, i).Value & "'"
                a = cmd.ExecuteScalar
                a = a - Me.DataGridView1.Item(3, i).Value
                cmd.CommandText = "update stock set qty=" & a & " where item_id='" & Me.DataGridView1.Item(1, i).Value & "'"
                cmd.ExecuteNonQuery()
            Next
            Dim result = MsgBox("          Record Added...." & vbCrLf & " Do u want to Print the Bill...??", MsgBoxStyle.YesNo, "Confirm Print")
            If result = Windows.Forms.DialogResult.Yes Then
                sel = "{sales_bill_details.bill_no}='" & Me.txtbillno.Text & "'"
                SalesbillPrint.Show()
            End If
            All_Clear()
            Me.btnsave.Enabled = False
            Me.btnnew.Enabled = True
            Me.GroupBox1.Enabled = False
            Me.Panel2.Enabled = False
        Catch ex As Exception
            MsgBox("Record already exist.." & ex.ToString)
        Finally
            cnn.Close()
        End Try
        Me.ContextMenuStrip1.Enabled = False
        All_Clear()
        Me.DataGridView1.Columns.Clear()
        db.Rows.Clear()
        db.Columns.Clear()
        Me.combocid.Text = ""
        Me.txtname.Text = ""
        Me.txtphno.Text = ""
        Me.txtbillno.Text = ""
        Me.lbltotal.Text = ""
        Me.txtdiscount.Text = ""
        Me.txtgtotal.Text = ""
        Me.btncal.Enabled = False
        Me.txtgtotal.Enabled = False
        Me.txtdiscount.Enabled = False

    End Sub
    Private Sub BtnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        salesbill_Load(sender, e)
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
    Private Sub ComboUnits_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles combounits.Click
        Try
            cnn.Close()
            all_connect()
            cmd.CommandText = "select * from units"
            adp.SelectCommand = cmd
            dt.Clear()
            adp.Fill(dt)
            Me.combounits.DataSource = dt
            Me.combounits.DisplayMember = "unit_name"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub combounits_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles combounits.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.combounits.Focus()
            e.Handled = True
        End If
    End Sub
    Private Sub ComboUnits_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles combounits.Leave
        Try
            cnn.Close()
            all_connect()
            cmd.CommandText = "select unit_name from stock where item_id='" & Me.comboiid.Text & "'"
            Dim unt As String
            unt = cmd.ExecuteScalar
            If Me.combounits.Text <> unt Then
                MsgBox("Units doesn't match with the item...!! Unit should be " & unt, MsgBoxStyle.Information, "Information")
                Me.combounits.Text = ""
                Me.combounits.Focus()
                Exit Sub

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub TxtDiscount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdiscount.TextChanged
        If Val(Me.txtdiscount.Text) > 100 Then
            MsgBox("Enter valid Discount")
            Me.txtdiscount.Clear()
        End If
    End Sub
    Private Sub Btncal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncal.Click
        Me.Label17.Visible = True
        Dim a As Decimal
        For i As Integer = 0 To db.Rows.Count - 1
            a = a + db.Rows(i).Item(7)
        Next
        Me.txtgtotal.Text = a
        Me.Label17.Text = Val(Me.txtdiscount.Text) * Val(Me.txtgtotal.Text) / 100
        Me.txtgtotal.Text = Val(Me.txtgtotal.Text) - Val(Me.Label17.Text)
        Me.btnsave.Enabled = True
        Label17_TextChanged(sender, e)
        Me.btnsave.Visible = True
    End Sub
    Private Sub BtnNewc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnewc.Click
        customer.Close()
        customer.Show()
        customer.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        If Me.txtphno.Text = "" Then
            MsgBox("Please Enter the Phone Num  To Search Customer", MsgBoxStyle.Information, "Warning")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "Select cust_id,cust_name from  customer where pno='" & Me.txtphno.Text & "'"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            cnn.Close()
            If dt.Rows.Count = 0 Then
                MsgBox("No Record Found...!!", MsgBoxStyle.Information, "Information")
                Exit Sub
            End If
            Me.combocid.Text = dt.Rows(0).Item(0)
            Me.txtname.Text = dt.Rows(0).Item(1)
            Me.comboiid.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub TxtPhno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtphno.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
            MsgBox("enter only numbers...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub
    Private Sub TxtVat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvat.KeyPress, txtprice.KeyPress, txtgtotal.KeyPress, txtdiscount.KeyPress
        If (sender.Text.Contains(".") And (e.KeyChar.ToString = ".")) Then
            e.Handled = True
            Exit Sub
        End If
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = "." Or Char.IsControl(e.KeyChar)) Then
            MsgBox("Enter only numbers...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub
    Private Sub TxtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtname.KeyPress
        If (Char.IsNumber(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar)) Then
            MsgBox("Enter only charecter...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub
    Private Sub TxtPhno_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtphno.Leave
        If Me.txtphno.Text <> "" Then
            If Me.txtphno.Text.Length = 7 Or Me.txtphno.Text.Length = 10 Then
            Else
                MsgBox("Invalid Phone Number..", MsgBoxStyle.Information, "Warning")
                Me.txtphno.Focus()
            End If
        End If
    End Sub
    Private Sub salesbill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            all_connect()
            panelcustomer.Visible = True
            Panel2.Visible = True
            DataGridView1.Visible = True
            GroupBox1.Visible = True
            btnsave.Visible = True
            btnclose.Visible = True
            Me.btncal.Enabled = False
            panelcustomer.Enabled = False
            Panel2.Enabled = False
            DataGridView1.Enabled = False
            GroupBox1.Enabled = False
            btnsave.Enabled = False
            btnclose.Enabled = True
            Me.txtdiscount.Enabled = False
            Me.txtgtotal.Enabled = False
            Me.txtname.Enabled = False
            Me.txtvat.Enabled = False
            Me.txtprice.Enabled = False
            Me.btnsave.Enabled = False
            Me.combocid.Items.Clear()
            Me.comboiid.Items.Clear()
            cmd.CommandText = "select item_id from stock"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Dim j
            For j = 0 To dt.Rows.Count - 1
                Me.comboiid.Items.Add(dt.Rows(j).Item(0))
            Next
           
            Me.txtbillno.Text = ""
            All_Clear()
            Me.combocid.Text = ""
            Me.txtphno.Text = ""
            Me.txtname.Text = ""
            Me.panelcustomer.Enabled = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
       
    End Sub

    Private Sub txtitemname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtitemname.TextChanged

        Try
            cnn.Close()
            all_connect()
            'cmd.CommandText = "Select item_name from  stock where item_name like '" & Me.txtitemname.Text & "%'"
            'adp.SelectCommand = cmd
            'dt = New DataTable
            'dt.Clear()
            'adp.Fill(dt)
            'Me.ListBox1.DataSource = dt
            cmd.CommandText = "Select selling_price from  stock where item_name='" & Me.txtitemname.Text & "'"
            Me.txtprice.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select vat_rate from  stock where item_name='" & Me.txtitemname.Text & "'"
            Me.txtvat.Text = cmd.ExecuteScalar
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

   

    Private Sub combocid_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles combocid.DropDown
        Me.combocid.Items.Clear()
        Try
            all_connect()
            cmd.CommandText = "select cust_id from customer"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Dim i
            For i = 0 To dt.Rows.Count - 1
                Me.combocid.Items.Add(dt.Rows(i).Item(0))
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub combocid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles combocid.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.combocid.Focus()
            e.Handled = True
        End If
    End Sub


    Private Sub combocid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combocid.SelectedIndexChanged
        Try
            all_connect()
            cmd.CommandText = "select cust_name,pno from customer where cust_id='" & Me.combocid.Text & "'"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Me.txtphno.Text = dt.Rows(0).Item(1)
            Me.txtname.Text = dt.Rows(0).Item(0)
            Me.panelcustomer.Enabled = True
            Me.comboiid.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        Me.txtitemname.Enabled = False
        Me.combounits.Enabled = False
    End Sub

    Private Sub btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnew.Click
        panelcustomer.Enabled = True
        Panel2.Enabled = True
        DataGridView1.Enabled = True
        btnsave.Enabled = True
        btnclose.Enabled = True
        Me.btncal.Enabled = True
        Me.txtdiscount.Enabled = True
        Me.txtgtotal.Enabled = True
        Me.combocid.Focus()
        Dim n As String
        Dim m As Integer
        Dim x As Integer
        Try
            Me.ContextMenuStrip1.Enabled = True
            all_connect()
            All_Clear()
            Me.combocid.Text = ""
            Me.txtname.Text = ""
            Me.txtphno.Text = ""
            Me.DataGridView1.Columns.Clear()
            db.Rows.Clear()
            db.Columns.Clear()
            If Me.txtbillno.Text = "" Then
                cmd.CommandText = "select max(bill_no) from sales_bill"
                Dim id = cmd.ExecuteScalar
                If IsDBNull(id) Then
                    id = "SB101"
                Else
                    n = id
                    x = n.Substring(2)
                    m = Int(x)
                    m = m + 1
                    id = "SB" & m
                End If
                Me.txtbillno.Text = id
                Me.txtbillno.ReadOnly = True
                Me.txtbillno.Enabled = False
                Me.DateTimePicker1.Enabled = False
                Me.DateTimePicker1.Value = Today.Date
            End If
            Me.btnnew.Enabled = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If Me.txtbillno.Text = "" Or Me.txtprice.Text = "" Or Me.txtamt.Text <= 0 Or Me.txtqun.Text = 0 Or Me.combounits.Text = "" Or Me.comboiid.Text = "" Or Me.combocid.Text = "" Or Me.txtitemname.Text = "" Or Me.txtqun.Text = "" Or Me.txtvat.Text = "" Then
            MsgBox("Please Enter all Fields..")
            Exit Sub
        End If
        For i As Integer = 0 To db.Rows.Count - 1
            If db.Rows(i).Item(1) = Me.comboiid.Text Then
                MsgBox("Item already Entered to the List...!!", MsgBoxStyle.Information, "Message")
                All_Clear()
                Exit Sub
            End If
        Next
        If db.Rows.Count = 0 Then
            db.Columns.Add("Bill No")
            db.Columns.Add("Item ID")
            db.Columns.Add("units")
            db.Columns.Add("Quantity")
            db.Columns.Add("Price")
            db.Columns.Add("Amount")
            db.Columns.Add("VAT")
            db.Columns.Add("Total")
            Me.DataGridView1.DataSource = db
            db.Rows.Add(Me.txtbillno.Text, Me.comboiid.Text, Me.combounits.Text, Me.txtqun.Text, Me.txtprice.Text, (Val(Me.txtprice.Text) * Val(Me.txtqun.Text)), Val(Me.txtvat.Text) * Val(Me.txtqun.Text), Val(Me.txtamt.Text))
        Else
            db.Rows.Add(Me.txtbillno.Text, Me.comboiid.Text, Me.combounits.Text, Me.txtqun.Text, Me.txtprice.Text, (Val(Me.txtprice.Text) * Val(Me.txtqun.Text)), Val(Me.txtvat.Text) * Val(Me.txtqun.Text), Val(Me.txtamt.Text))
        End If
        Dim a As Decimal
        For i As Integer = 0 To db.Rows.Count - 1
            a = a + db.Rows(i).Item(7)
        Next
        Me.lbltotal.Text = a
        Me.btnnew.Enabled = False
        Me.panelcustomer.Enabled = False
        Me.GroupBox1.Enabled = True
        Me.txtdiscount.Text = ""
        Me.btncal.Enabled = True
        Me.txtgtotal.Text = ""
        Me.DataGridView1.Visible = True
        Me.GroupBox1.Enabled = True
        Me.GroupBox1.Visible = True
        Me.txtgtotal.Enabled = False
        All_Clear()
    End Sub

    Private Sub comboiid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboiid.SelectedIndexChanged
        Try
            cnn.Close()
            all_connect()
            cmd.CommandText = "select item_name,unit_name from stock where item_id='" & Me.comboiid.Text & "'"
            adp.SelectCommand = cmd
            dt1.Clear()
            adp.Fill(dt1)
            Me.txtitemname.Text = dt1.Rows(0).Item(0)
            Me.combounits.Text = dt1.Rows(0).Item(1)
            Me.txtqun.Clear()
            Me.txtamt.Clear()
            Me.txtqun.Select()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        Me.txtitemname.Enabled = False
        Me.combounits.Enabled = False
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            If Not Me.DataGridView1.Rows(Me.rowIndex).IsNewRow Then
                Me.DataGridView1.Rows.RemoveAt(Me.rowIndex)
                Dim a As Decimal
                For i As Integer = 0 To db.Rows.Count - 1
                    a = a + db.Rows(i).Item(7)
                Next
                Me.lbltotal.Text = a
                If Me.DataGridView1.Rows.Count = 1 Then
                    db.Rows.Clear()
                    db.Columns.Clear()
                    Me.Label1.Text = ""
                    Me.btnsave.Enabled = False
                End If
            End If
        Catch ex As ArgumentOutOfRangeException
        End Try
    End Sub
 

    Private Sub Label17_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label17.TextChanged
        Dim a As Decimal
        For i As Integer = 0 To db.Rows.Count - 1
            a = a + db.Rows(i).Item(7)
        Next
        Me.txtgtotal.Text = a - Val(Me.Label17.Text)
    End Sub
End Class
