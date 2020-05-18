Imports System.Data.SqlClient
Imports System.Data
Public Class pur_order
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim bds As New BindingSource
    Dim db As New DataTable
    Dim dt1 As New DataTable
    Dim rowIndex As Integer
    Public bill_no As String
    Public Sub display()
        Me.btnadd.Enabled = True
        Try
            all_connect()
            cmd.CommandText = "select * from Purchase_order_details"
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
        Me.ComboBox1.Text = ""
        Me.ComboBox2.Text = ""
        Me.txtgname.Text = ""
        Me.Txtiname.Text = ""
        me.txtunit .Text =""
        Me.txtquantity.Text = ""
        Me.txtname.Text = ""
    End Sub
    Public Sub all_clean()
        Me.ComboBox2.Text = ""
        Me.ComboBox2.SelectedItem = ""
        Me.ComboBox2.SelectedText = ""
        Me.txtgname.Text = ""
        Me.Txtiname.Text = ""
        Me.txtunit.Text = ""
        Me.txtquantity.Text = ""
    End Sub

    Private Sub pur_order_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            all_connect()
            cmd.CommandText = "select supplier_id from suppliers where supplier_id in(select supplier_id from Stock)"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Dim i
            For i = 0 To dt.Rows.Count - 1
                Me.ComboBox1.Items.Add(dt.Rows(i).Item(0))
            Next
            Me.txtorder.Text = ""
            Me.DateTimePicker1.Value = Today.Date

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        Me.btnedit.Visible = False
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnew.Click
        Me.Panel2.Enabled = True
        Me.Panel3.Enabled = False
        Me.Panel1.Enabled = True
        Me.ComboBox1.Enabled = True
        Dim n As String
        Dim m As Integer
        Dim x As Integer
        Try
            all_connect()
            All_Clear()
            Me.Panel2.Enabled = True
            If Me.txtorder.Text = "" Then
                cmd.CommandText = "select max(Order_no) from Purchase_order"
                Dim id = cmd.ExecuteScalar
                If IsDBNull(id) Then
                    id = "PO101"
                Else
                    n = id
                    x = n.Substring(2)
                    m = Int(x)
                    m = m + 1
                    id = "PO" & m
                End If
                Me.txtorder.Text = id
                Me.txtorder.ReadOnly = True
                Me.DateTimePicker1.Enabled = False
                Me.DateTimePicker1.Value = Today
            End If
            Me.ComboBox1.Focus()
            Me.btnnew.Enabled = False
            Me.ComboBox2.Items.Clear()
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
        Me.ComboBox2.Items.Clear()
        Me.ComboBox2.Text = ""
        Me.txtgname.Text = ""
        Me.Txtiname.Text = ""
        Me.txtunit.Text = ""
        Me.txtquantity.Text = ""
        Try
            all_connect()
            cmd.CommandText = "select item_id from Stock where supplier_id='" & Me.ComboBox1.Text & "'"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Dim i
            For i = 0 To dt.Rows.Count - 1
                Me.ComboBox2.Items.Add(dt.Rows(i).Item(0))
            Next
            Me.Panel3.Enabled = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        Try
            cnn.Close()
            all_connect()
            cmd.CommandText = "select supplier_name from Suppliers where supplier_id='" & Me.ComboBox1.SelectedItem & "'"
            Me.txtname.Text = cmd.ExecuteScalar
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        Me.txtgname.Enabled = False
        Me.txtunit.Enabled = False
        Me.txtquantity.Enabled = True
        Me.ComboBox2.Enabled = True
        Me.Txtiname.Enabled = False
        Me.txtname.Enabled = False
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If Me.ComboBox2.Text = "" Or Me.ComboBox1.Text = "" Or Me.txtunit.Text = "" Or Me.txtorder.Text = "" Or Me.txtname.Text = "" Or Me.txtgname.Text = "" Or Me.txtquantity.Text = "" Then
            MsgBox("Please Enter all Fields..", MsgBoxStyle.Information, "Warning")
            Exit Sub
        End If
        Dim flag = 0, rowval = 0
        For k As Integer = 0 To db.Rows.Count - 1
            If db.Rows(k).Item(0) = Me.ComboBox2.Text Then
                rowval = k
                flag = 1
                Exit For
            End If
        Next
        Try
            If flag = 1 Then
                Me.db.Rows.RemoveAt(rowval)
            End If
        Catch ex As IndexOutOfRangeException
        End Try
        If db.Rows.Count = 0 Then
            db.Rows.Clear()
            db.Columns.Clear()
            db.Columns.Add("Item ID")
            db.Columns.Add("Item Name")
            db.Columns.Add("Group Name")
            db.Columns.Add("Units")
            db.Columns.Add("Quantity")
            db.Rows.Add(Me.ComboBox2.Text, Me.Txtiname.Text, Me.txtgname.Text, Me.txtunit.Text, Me.txtquantity.Text)
        Else
            db.Rows.Add(Me.ComboBox2.Text, Me.Txtiname.Text, Me.txtgname.Text, Me.txtunit.Text, Me.txtquantity.Text)
        End If
        Me.DataGridView1.DataSource = db
        Me.DataGridView1.DataSource = db
        Me.btnnew.Enabled = False
        Me.btnsave.Visible = True
        Me.btnsave.Enabled = True
        Me.ComboBox1.Enabled = True
        Me.txtquantity.Enabled = False
        Me.Panel1.Enabled = False
        all_clean()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Me.DataGridView1.Rows.Count - 1 = 0 Then
            MsgBox(Me.DataGridView1.Rows.Count - 1)
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "insert into Purchase_order values(@order_no,@order_date)"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@order_no", SqlDbType.NVarChar).Value = Me.txtorder.Text
            cmd.Parameters.Add("@order_date", SqlDbType.DateTime).Value = Me.DateTimePicker1.Value.Date
            cmd.ExecuteNonQuery()
            For i As Integer = 0 To Me.DataGridView1.RowCount - 2
                cmd.CommandText = "insert into Purchase_order_details values(@Order_no,@Group_name,@Supplier_id,@Item_id,@Item_name,@Qty,@Units)"
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@order_no", SqlDbType.NVarChar).Value = Me.txtorder.Text
                'cmd.Parameters.Add("@order_date", SqlDbType.DateTime).Value = Me.DateTimePicker1.Value.Date
                cmd.Parameters.Add("@Group_name", SqlDbType.NVarChar).Value = Me.DataGridView1.Item(2, i).Value
                cmd.Parameters.Add("@Supplier_id", SqlDbType.NVarChar).Value = Me.ComboBox1.SelectedItem
                cmd.Parameters.Add("@Item_id", SqlDbType.NVarChar).Value = Me.DataGridView1.Item(0, i).Value
                cmd.Parameters.Add("@Item_name", SqlDbType.NVarChar).Value = Me.DataGridView1.Item(1, i).Value
                cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = Me.DataGridView1.Item(4, i).Value
                cmd.Parameters.Add("@Units", SqlDbType.NVarChar).Value = Me.DataGridView1.Item(3, i).Value
                cmd.ExecuteNonQuery()
            Next
            Dim result = MsgBox("          Order Created...." & vbCrLf & " Do u want to Print the Order...??", MsgBoxStyle.YesNo, "Confirm Print")
            If result = Windows.Forms.DialogResult.Yes Then
                bill_no = "{Purchase_order_details.Order_no}='" & Me.txtorder.Text & "'"
                Purchasebillprint.Show()
            End If
            All_Clear()
            Me.txtgname.Enabled = False
            Me.txtunit.Enabled = False
            Me.txtquantity.Enabled = False
            Me.ComboBox2.Enabled = False
            Me.Txtiname.Enabled = False
            Me.txtname.Enabled = False
            Me.btnsave.Enabled = False
            Me.btnnew.Enabled = True
            Me.btnclose.Visible = True
            Me.btnedit.Visible = False
            Me.DataGridView1.Columns.Clear()
            db.Rows.Clear()
            db.Columns.Clear()
            Me.ComboBox1.Text = ""
            Me.txtname.Text = ""
            Me.txtorder.Text = ""
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
                    ContextMenuStrip1.Show(Windows.Forms.Cursor.Position)
                End If
            End If
        Catch ex As ArgumentOutOfRangeException
        End Try
    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        all_clean()
        Me.ComboBox2.Enabled = True
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
        reorder.TextBox1.Text = ""
        reorder.TextBox2.Text = ""
        reorder.TextBox3.Text = ""
        reorder.TextBox4.Text = ""
        reorder.TextBox5.Text = ""
    End Sub

    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox2.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.ComboBox2.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox2_Leave1(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.Leave
        If Me.ComboBox2.Text <> "" Then
            For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                If Me.DataGridView1.Rows(i).Cells(0).Value = Me.ComboBox2.Text Then
                    MsgBox("Item already Entered To Order List...!!" & vbCrLf & " " & vbCrLf & "Right Click the item in List to Edit", MsgBoxStyle.Information, "Warning")
                    Me.ComboBox2.Text = ""
                    all_clean()
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
            cnn.Close()
            all_connect()
            cmd.CommandText = "select Item_name,Group_name,Unit_name from Stock where Item_id='" & Me.ComboBox2.Text & "'and Supplier_id='" & Me.ComboBox1.Text & "'"
            adp.SelectCommand = cmd
            dt1.Clear()
            adp.Fill(dt1)
            For i As Integer = 0 To dt1.Rows.Count - 1
                Me.Txtiname.Text = dt1.Rows(i).Item(0)
                Me.txtgname.Text = dt1.Rows(i).Item(1)
                Me.txtunit.Text = dt1.Rows(i).Item(2)
            Next
            Me.txtquantity.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        Me.txtquantity.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click
        Me.btnadd.Visible = False
        Me.Button1.Visible = True
        Me.TextBox1.Visible = True
        Me.TextBox2.Visible = True
        Me.TextBox3.Visible = True
        Me.TextBox4.Visible = True
        Me.ComboBox2.Visible = False
        Me.btnclear.Visible = False
        Me.Txtiname.Visible = False
        Me.txtgname.Visible = False
        Me.txtunit.Visible = False
        Dim n As String
        Dim m As Integer
        Dim x As Integer
        Try
            all_connect()
            All_Clear()
            Me.Panel2.Enabled = True
            If Me.txtorder.Text = "" Then
                cmd.CommandText = "select max(Order_no) from Purchase_order"
                Dim id = cmd.ExecuteScalar
                If IsDBNull(id) Then
                    id = "PO101"
                Else
                    n = id
                    x = n.Substring(2)
                    m = Int(x)
                    m = m + 1
                    id = "PO" & m
                End If
                Me.txtorder.Text = id
                Me.txtorder.ReadOnly = True
                Me.DateTimePicker1.Enabled = False
                Me.DateTimePicker1.Value = Today
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        Try
            TextBox1.Text = reorder.TextBox1.Text
            TextBox2.Text = reorder.TextBox2.Text
            TextBox3.Text = reorder.TextBox3.Text
            ComboBox1.Text = reorder.TextBox5.Text
            TextBox4.Text = reorder.TextBox4.Text
            txtquantity.Text = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        Try
            cnn.Close()
            all_connect()
            cmd.CommandText = "select supplier_name from Suppliers where supplier_id='" & Me.ComboBox1.Text & "'"
            Me.txtname.Text = cmd.ExecuteScalar
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        Me.btnsave.Enabled = True
        Me.TextBox1.Enabled = False
        Me.TextBox2.Enabled = False
        Me.TextBox3.Enabled = False
        Me.TextBox4.Enabled = False
        Me.btnedit.Visible = False
    End Sub

    Private Sub txtquantity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtquantity.KeyPress
        If (sender.Text.Contains(".") And (e.KeyChar.ToString = ".")) Then
            e.Handled = True
            Exit Sub
        End If
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = "." Or Char.IsControl(e.KeyChar)) Then
            MsgBox("Enter only numbers...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub EditItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditItemToolStripMenuItem.Click
        Try
            If Me.rowIndex > Me.DataGridView1.Rows.Count - 1 Then
                Exit Sub
            End If
            Me.ComboBox2.Text = Me.DataGridView1.Item(0, Me.rowIndex).Value
            Me.Txtiname.Text = Me.DataGridView1.Item(1, Me.rowIndex).Value
            Me.txtgname.Text = Me.DataGridView1.Item(2, Me.rowIndex).Value
            Me.txtunit.Text = Me.DataGridView1.Item(3, Me.rowIndex).Value
            Me.txtquantity.Text = Me.DataGridView1.Item(5, Me.rowIndex).Value
            Me.ComboBox2.Enabled = False
        Catch ex As InvalidCastException
        Catch ex As ArgumentOutOfRangeException
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub RemoveItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveItemToolStripMenuItem.Click
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

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.TextBox1.Text = "" Or Me.ComboBox1.Text = "" Or Me.TextBox4.Text = "" Or Me.txtorder.Text = "" Or Me.txtname.Text = "" Or Me.TextBox2.Text = "" Or Me.TextBox3.Text = "" Or Me.txtquantity.Text = "" Then
            MsgBox("Please Enter all Fields..", MsgBoxStyle.Information, "Warning")
            Exit Sub
        End If
        Dim flag = 0, rowval = 0
        For k As Integer = 0 To db.Rows.Count - 1
            If db.Rows(k).Item(0) = Me.TextBox1.Text Then
                rowval = k
                flag = 1
                Exit For
            End If
        Next
        Try
            If flag = 1 Then
                Me.db.Rows.RemoveAt(rowval)
            End If
        Catch ex As IndexOutOfRangeException
        End Try
        If db.Rows.Count = 0 Then
            db.Rows.Clear()
            db.Columns.Clear()
            db.Columns.Add("Item ID")
            db.Columns.Add("Item Name")
            db.Columns.Add("Group Name")
            db.Columns.Add("Units")
            db.Columns.Add("Quantity")
            db.Rows.Add(Me.TextBox1.Text, Me.TextBox2.Text, Me.TextBox3.Text, Me.TextBox4.Text, Me.txtquantity.Text)
        Else
            db.Rows.Add(Me.TextBox1.Text, Me.TextBox2.Text, Me.TextBox3.Text, Me.TextBox4.Text, Me.txtquantity.Text)
        End If
        Me.DataGridView1.DataSource = db
        Me.DataGridView1.DataSource = db
        Me.btnnew.Enabled = False
        Me.btnsave.Visible = True
        Me.btnsave.Enabled = True
        Me.ComboBox1.Enabled = True
        Me.txtquantity.Enabled = False
        Me.Panel1.Enabled = False
        all_clean()
        Me.TextBox1.Text = ""
        Me.TextBox2.Text = ""

        Me.TextBox3.Text = ""

        Me.TextBox4.Text = ""

    End Sub
End Class