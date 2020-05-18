Imports System.Data.SqlClient
Imports System.Data
Public Class stock
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim bds As New BindingSource
    Dim db As New DataTable
    Public Sub display()
        Try
            all_connect()
            cmd.CommandText = "SELECT item_id, item_name, brand_name, group_name, supplier_id, cost_price, selling_price, reorder_level, unit_name, qty, vat_rate,vat_per from  stock"
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
        Me.txtitemid.Text = ""
        Me.txtitemname.Text = ""
        Me.txtcprice.Text = ""
        Me.txtsprice.Text = ""
        Me.txtqun.Text = ""
        Me.txtsearch.Text = ""
        Me.ComboBox4.Text = ""
        Me.ComboBox2.Text = ""
        Me.ComboBox1.Text = ""
        Me.txtsupid.Text = ""
        Me.txtreorder.Text = ""
        Me.txtvat.Text = ""
        Me.txtvatrate.Text = ""
        Me.ComboBox3.Text = ""
    End Sub
    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
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
            If Me.ComboBox4.Text = "Item ID" Then
                Me.txtsearch.Text = "ITEM"
            Else
                Me.txtsearch.Text = ""
            End If
        End If
    End Sub

    Private Sub txtsearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsearch.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.ProcessTabKey(True)
            Me.btnsearch.Focus()
        End If
    End Sub

    Private Sub txtsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        Try
            all_connect()
            If Me.ComboBox4.Text = "Name" Then
                cmd.CommandText = "SELECT item_id, item_name, brand_name, group_name, supplier_id, cost_price, selling_price, reorder_level, unit_name, qty, vat_rate,vat_per FROM  stock where item_name like '" & Me.txtsearch.Text & "%'"
            End If
            If Me.txtsearch.Text = "" Or Me.txtsearch.Text = "ITEM" Then
                cmd.CommandText = "SELECT item_id, item_name, brand_name, group_name, supplier_id, cost_price, selling_price, reorder_level, unit_name, qty, vat_rate,vat_per FROM  stock"
            End If
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

    Private Sub ComboBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox4.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.ComboBox4.Focus()
            e.Handled = True
        End If
    End Sub


    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        'combo search
        If Me.ComboBox4.Text = "Item ID" Then
            Me.txtsearch.Text = "ITEM"
            Me.btnsearch.Visible = True
        Else
            Me.txtsearch.Text = ""
            Me.btnsearch.Visible = False
        End If
    End Sub

    Private Sub ComboBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.Click
        'combo brand
        Me.ComboBox2.Items.Clear()
        Try
            cnn.Close()
            all_connect()
            cmd.CommandText = "select * from manufacturer"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.ComboBox2.Items.Add(dt.Rows(i).Item(0))
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub



    Private Sub btnbrand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbrand.Click
        Manufacturer.Close()
        Manufacturer.Show()
        MDIParent1.brandAdd = 1
        Manufacturer.WindowState = FormWindowState.Maximized
        Manufacturer.txtbrand.Visible = True
        Manufacturer.btnaddsup.Visible = True
        Manufacturer.btnadd.Visible = False
        Manufacturer.btnadd.Visible = True
        Manufacturer.btnclose.Visible = True
        display()
    End Sub

    Private Sub btngroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngroup.Click
        Group.Close()
        Group.Show()
        Group.WindowState = FormWindowState.Maximized
        Group.txtgroup.Visible = True
        Group.btnadd.Visible = True
        Group.btnclose.Visible = True
    End Sub

    Private Sub ComboBox3_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.DropDown
        'combo Units
        Me.ComboBox3.Items.Clear()
        Try
            all_connect()
            cmd.CommandText = "select * from units"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.ComboBox3.Items.Add(dt.Rows(i).Item(0))
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub ComboBox1_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDown
        'ComboGroup
        Me.ComboBox1.Items.Clear()
        Try
            all_connect()
            cmd.CommandText = "select * from group_info"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.ComboBox1.Items.Add(dt.Rows(i).Item(0))
            Next
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


    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
            cnn.Close()
            all_connect()
            cmd.CommandText = "select supplier_id from manufacturer where brand_name='" & Me.ComboBox2.Text & "'"
            Me.txtsupid.Text = cmd.ExecuteScalar
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub txtcprice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcprice.KeyPress
        If (Me.txtcprice.Text.Contains(".") And (e.KeyChar.ToString = ".")) Then
            e.Handled = True
            Exit Sub
        End If
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = "." Or Char.IsControl(e.KeyChar)) Then
            MsgBox("Enter only numbers...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub txtsprice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsprice.KeyPress
        If (Me.txtsprice.Text.Contains(".") And (e.KeyChar.ToString = ".")) Then
            e.Handled = True
            Exit Sub
        End If
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = "." Or Char.IsControl(e.KeyChar)) Then
            MsgBox("Enter only numbers...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub txtreorder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtreorder.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = "." Or Char.IsControl(e.KeyChar)) Then
            MsgBox("Enter only numbers...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub txtqun_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqun.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = "." Or Char.IsControl(e.KeyChar)) Then
            MsgBox("Enter only numbers...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub txtvatrate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvatrate.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = "." Or Char.IsControl(e.KeyChar)) Then
            MsgBox("Enter only numbers...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub txtvat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtvat.KeyPress
        If (Me.txtvat.Text.Contains(".") And (e.KeyChar.ToString = ".")) Then
            e.Handled = True
            Exit Sub
        End If
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = "." Or Char.IsControl(e.KeyChar)) Then
            MsgBox("Enter only numbers...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub txtvat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtvat.TextChanged
        Me.txtvatrate.Text = Val(Me.txtsprice.Text) * Val(Me.txtvat.Text) / 100
    End Sub

    Private Sub txtsprice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsprice.TextChanged
        If Me.txtvat.Text <> "" Then
            Me.txtvatrate.Text = Val(Me.txtsprice.Text) * Val(Me.txtvat.Text) / 100
        End If
    End Sub

    Private Sub txtitemname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtitemname.KeyPress
        If (sender.Text = "" And (e.KeyChar.ToString = " ")) Then
            e.Handled = True
            Exit Sub
        End If
        If (sender.Text.EndsWith(" ") And (e.KeyChar.ToString = " ")) Then
            MsgBox("Successive Space not allowed!", MsgBoxStyle.Information, "Warning")
            e.Handled = True
            Exit Sub
        End If
        If Not (Char.IsLetter(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = " " Or Char.IsWhiteSpace(e.KeyChar)) Then
            e.Handled = True
            MsgBox("Enter only character", MsgBoxStyle.Information, "Warning")
            If e.KeyChar = Chr(Keys.Enter) Then
                Me.ProcessTabKey(True)
            End If
        End If
    End Sub


    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Dim n As String
        Dim m As Integer
        Dim x As Integer
        Try
            all_connect()
            All_Clear()
            Me.GroupBox1.Enabled = True
            cmd.CommandText = "select max(item_id) from stock"
            Dim id = cmd.ExecuteScalar
            If IsDBNull(id) Then
                id = "ITEM101"
            Else
                n = id
                x = n.Substring(4)
                m = Int(x)
                m = m + 1
                id = "ITEM" & m
            End If
            Me.txtitemid.Text = id
            Me.txtitemid.ReadOnly = True
            Me.NewToolStripMenuItem.Enabled = False
            Me.SaveToolStripMenuItem.Enabled = True
            Me.SearchToolStripMenuItem.Visible = False
            Me.DataGridView1.Enabled = False
            Me.GroupBox1.Visible = True
            Me.DataGridView1.Visible = False
            Me.GroupBox2.Visible = False
            Me.ExitToolStripMenuItem.Visible = False
            Me.ToolStripMenuItem1.Visible = True
            Me.ModifyToolStripMenuItem.Visible = False
            Me.SaveToolStripMenuItem.Visible = True
            Me.GroupBox1.Visible = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If Me.txtitemid.Text = "" Or Me.txtitemname.Text = "" Or Me.ComboBox2.Text = "" Or Me.ComboBox1.Text = "" Or Me.txtcprice.Text = "" Or Me.txtsprice.Text = "" Or Me.txtqun.Text = "" Or Me.txtreorder.Text = "" Or Me.txtsupid.Text = "" Or Me.txtvatrate.Text = "" Then
            MsgBox("Please Enter all Fields..", MsgBoxStyle.Information, "Warning")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "insert into Stock values(@Item_id,@Item_name,@Brand_name,@Supplier_id,@group_name,@Cost_price,@Selling_price,@Reorder_level,@Units,@Qty,@Vat_rate,@Vat_per)"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@item_id", SqlDbType.NVarChar).Value = Me.txtitemid.Text
            cmd.Parameters.Add("@item_name", SqlDbType.NVarChar).Value = Me.txtitemname.Text
            cmd.Parameters.Add("@brand_name", SqlDbType.NVarChar).Value = Me.ComboBox2.Text
            cmd.Parameters.Add("@supplier_id", SqlDbType.NVarChar).Value = Me.txtsupid.Text
            cmd.Parameters.Add("@group_name", SqlDbType.NVarChar).Value = Me.ComboBox1.Text

            cmd.Parameters.Add("@cost_price", SqlDbType.Float).Value = Val(Me.txtcprice.Text)
            cmd.Parameters.Add("@selling_price", SqlDbType.Float).Value = Val(Me.txtsprice.Text)
            cmd.Parameters.Add("@reorder_level", SqlDbType.Int).Value = Val(Me.txtreorder.Text)
            cmd.Parameters.Add("@units", SqlDbType.NVarChar).Value = Me.ComboBox3.Text
            cmd.Parameters.Add("@qty", SqlDbType.Int).Value = Val(Me.txtqun.Text)
            cmd.Parameters.Add("@vat_rate", SqlDbType.Float).Value = Val(Me.txtvatrate.Text)
            cmd.Parameters.Add("@vat_per", SqlDbType.Float).Value = Val(Me.txtvat.Text)
            cmd.ExecuteNonQuery()
            MsgBox("Item Details saved Succeessfully....", MsgBoxStyle.Information, "Save Message")
            All_Clear()
            Me.SaveToolStripMenuItem.Enabled = False
            Me.NewToolStripMenuItem.Enabled = True
            Me.EditToolStripMenuItem.Enabled = True
            Me.GroupBox1.Visible = False
            Me.SearchToolStripMenuItem.Visible = False
            All_Clear()
            Me.ModifyToolStripMenuItem.Visible = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        display()
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Me.DataGridView1.Visible = True
        Me.DataGridView1.Enabled = True
        Me.GroupBox1.Visible = True
        Me.UpdateToolStripMenuItem.Enabled = True
        Me.EditToolStripMenuItem.Enabled = False
        Me.DeleteToolStripMenuItem.Enabled = True
        Me.txtitemid.ReadOnly = True
        Me.DataGridView1.Visible = True
        Me.ToolStripMenuItem1.Visible = True
        Me.ExitToolStripMenuItem.Visible = False
        Me.FileToolStripMenuItem.Visible = False
        Me.SearchToolStripMenuItem.Visible = False
        Me.GroupBox2.Visible = False

        display()
    End Sub

    Private Sub UpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem.Click
        If Me.txtitemid.Text = "" Or Me.txtitemname.Text = "" Or Me.ComboBox2.Text = "" Or Me.ComboBox1.Text = "" Or Me.txtcprice.Text = "" Or Me.txtsprice.Text = "" Or Me.txtqun.Text = "" Or Me.txtreorder.Text = "" Or Me.txtsupid.Text = "" Or Me.txtvatrate.Text = "" Then
            MsgBox("Please Enter all Fields..")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "update stock set item_id=@item_id,item_name=@item_name,brand_name=@brand_name,supplier_id=@supplier_id,group_name=@group_name,cost_price=@cost_price,selling_price=@selling_price,reorder_level=@reorder_level,unit_name=@unit_name,qty=@qty,vat_rate=@vat_rate,vat_per=@vat_per where item_id=@item_id"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@item_id", SqlDbType.NVarChar).Value = Me.txtitemid.Text
            cmd.Parameters.Add("@item_name", SqlDbType.NVarChar).Value = Me.txtitemname.Text
            cmd.Parameters.Add("@brand_name", SqlDbType.NVarChar).Value = Me.ComboBox2.Text
            cmd.Parameters.Add("@supplier_id", SqlDbType.NVarChar).Value = Me.txtsupid.Text
            cmd.Parameters.Add("@group_name", SqlDbType.NVarChar).Value = Me.ComboBox1.Text
            cmd.Parameters.Add("@cost_price", SqlDbType.Float).Value = Val(Me.txtcprice.Text)
            cmd.Parameters.Add("@selling_price", SqlDbType.Float).Value = Val(Me.txtsprice.Text)
            cmd.Parameters.Add("@reorder_level", SqlDbType.Int).Value = Val(Me.txtreorder.Text)
            cmd.Parameters.Add("@unit_name", SqlDbType.NVarChar).Value = Me.ComboBox3.Text
            cmd.Parameters.Add("@qty", SqlDbType.Int).Value = Val(Me.txtqun.Text)
            cmd.Parameters.Add("@vat_rate", SqlDbType.Float).Value = Val(Me.txtvatrate.Text)
            cmd.Parameters.Add("@vat_per", SqlDbType.Float).Value = Val(Me.txtvat.Text)
            cmd.ExecuteNonQuery()
            MsgBox("Record UPDATED....", MsgBoxStyle.Information, "Message")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        display()
        All_Clear()
        Me.UpdateToolStripMenuItem.Visible = True
        Me.EditToolStripMenuItem.Enabled = False
        Me.DeleteToolStripMenuItem.Visible = True
        Me.FileToolStripMenuItem.Visible = False
        Me.ToolStripMenuItem1.Visible = True
        Me.ExitToolStripMenuItem.Visible = False
        Me.SearchToolStripMenuItem.Visible = False
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If Me.txtitemid.Text = "" Then
            MsgBox("Please the select the Item from Grid to Delete", MsgBoxStyle.Information, "Message")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "select qty from stock where item_id ='" & Me.txtitemid.Text & "'"
            If cmd.ExecuteScalar <> 0 Then
                MsgBox("       " & cmd.ExecuteScalar & " Quantity of this Item is in stock" & vbCrLf & " Item can only be Deleted when the Quantity in stock is  Zero", MsgBoxStyle.Information, "Warning")
                Exit Sub
            End If
            cmd.CommandText = "delete from stock where item_id='" & Me.txtitemid.Text & "'"
            cmd.ExecuteNonQuery()
            MsgBox("Record DELETED....", MsgBoxStyle.Information, "Message")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        All_Clear()
        display()
        Me.FileToolStripMenuItem.Visible = False
        Me.SearchToolStripMenuItem.Visible = False
        Me.ExitToolStripMenuItem.Visible = False
        Me.ToolStripMenuItem1.Visible = True
    End Sub

    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        Me.GroupBox2.Visible = True
        Me.DataGridView1.Visible = True
        Me.FileToolStripMenuItem.Visible = False
        Me.ModifyToolStripMenuItem.Visible = False
        Me.ExitToolStripMenuItem.Visible = False
        Me.ToolStripMenuItem1.Visible = True
        Me.SearchToolStripMenuItem.Visible = False
        Me.GroupBox1.Visible = False
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        All_Clear()
        Me.DataGridView1.Visible = False
        Me.FileToolStripMenuItem.Visible = True
        Me.NewToolStripMenuItem.Enabled = True
        Me.SaveToolStripMenuItem.Enabled = False
        Me.ModifyToolStripMenuItem.Visible = True
        Me.EditToolStripMenuItem.Enabled = True
        Me.UpdateToolStripMenuItem.Enabled = False
        Me.DeleteToolStripMenuItem.Enabled = False
        Me.SearchToolStripMenuItem.Enabled = True
        Me.ExitToolStripMenuItem.Visible = True
        Me.GroupBox1.Visible = False
        Me.GroupBox2.Visible = False
        Me.ToolStripMenuItem1.Visible = False
        Me.SearchToolStripMenuItem.Visible = True
    End Sub

    Private Sub stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ToolStripMenuItem1.Visible = False
        Me.UpdateToolStripMenuItem.Enabled = False
        Me.DeleteToolStripMenuItem.Enabled = False
        Me.SaveToolStripMenuItem.Enabled = False
    End Sub

    Private Sub txtqun_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtqun.Leave
        If Val(Me.txtqun.Text) < Val(Me.txtreorder.Text) Then
            Me.txtqun.Clear()
            Me.txtqun.Focus()
            MsgBox("Quantity must be more than reorder level")
        End If
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.ComboBox1.Focus()
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

   
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            Me.txtitemid.Text = Me.DataGridView1.Item(0, e.RowIndex).Value
            Me.txtitemname.Text = Me.DataGridView1.Item(1, e.RowIndex).Value
            Me.ComboBox2.Text = Me.DataGridView1.Item(2, e.RowIndex).Value
            Me.ComboBox1.Text = Me.DataGridView1.Item(3, e.RowIndex).Value
            Me.txtsupid.Text = Me.DataGridView1.Item(4, e.RowIndex).Value
            Me.txtcprice.Text = Me.DataGridView1.Item(5, e.RowIndex).Value
            Me.txtsprice.Text = Me.DataGridView1.Item(6, e.RowIndex).Value
            Me.txtreorder.Text = Me.DataGridView1.Item(7, e.RowIndex).Value
            Me.ComboBox3.Text = Me.DataGridView1.Item(8, e.RowIndex).Value
            Me.txtqun.Text = Me.DataGridView1.Item(9, e.RowIndex).Value
            Me.txtvat.Text = Me.DataGridView1.Item(11, e.RowIndex).Value
            Me.txtvatrate.Text = Me.DataGridView1.Item(10, e.RowIndex).Value
        Catch ex As ArgumentOutOfRangeException
        End Try
    End Sub
End Class