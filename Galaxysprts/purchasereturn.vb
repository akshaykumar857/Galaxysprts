Imports System.Data.SqlClient
Imports System.data
Public Class purchasereturn
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim bds As New BindingSource
    Private Sub all_clear()
        Me.lblno.Text = ""
        Me.lblbrand.Text = ""
        Me.lblsname.Text = ""
        Me.lbltotal.Text = ""
        Me.ComboBox1.Text = ""
    End Sub
    Private Sub Btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnew.Click
        Dim n As String
        Dim m As Integer
        Dim x As Integer
        Try
            all_clear()
            all_connect()
            cmd.CommandText = "select max(pr_no) from purchase_return"
            Dim id = cmd.ExecuteScalar
            If IsDBNull(id) Then
                id = "PR101"
            Else
                n = id
                x = n.Substring(2)
                m = Int(x)
                m = m + 1
                id = "PR" & m
            End If
            Me.lblno.Text = id
            Me.btnreturn.Enabled = True
            Me.btnnew.Enabled = False
            Me.GroupBox1.Enabled = True
            Me.ComboBox1.Enabled = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub ComboBox1_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDown
        Me.ComboBox1.Items.Clear()
        Try
            all_connect()
            cmd.CommandText = " Select distinct supplier_id   FROM  damaged WHERE flag =0"
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
            all_connect()
            cmd.CommandText = " Select supplier_name   FROM  suppliers WHERE supplier_id='" & Me.ComboBox1.Text & "'"
            Me.lblsname.Text = cmd.ExecuteScalar
            cmd.CommandText = " Select brand_name FROM  manufacturer WHERE supplier_id='" & Me.ComboBox1.Text & "'"
            Me.lblbrand.Text = cmd.ExecuteScalar
            cmd.CommandText = " Select item_id,item_name,qty_rejected,amount from damaged where supplier_id ='" & Me.ComboBox1.Text & "'and flag=0"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Me.DataGridView1.DataSource = dt
            cmd.CommandText = "SELECT SUM(amount)FROM damaged WHERE supplier_id ='" & Me.ComboBox1.Text & "'AND flag = 0"
            Me.lbltotal.Text = cmd.ExecuteScalar
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub BtnReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreturn.Click
        If Me.DataGridView1.Rows.Count = 0 Then
            MsgBox("There are no items in the list to Return", MsgBoxStyle.Information, "Warning")
            Exit Sub
        End If
        If Me.DateTimePicker1.Value <> Today.Date Then
            MsgBox("Return date must be Todays date", MsgBoxStyle.Information, "Message")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "insert into purchase_return values(@pr_no,@return_date,@supplier_id,@total)"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@pr_no", SqlDbType.NVarChar).Value = Me.lblno.Text
            cmd.Parameters.Add("@return_date", SqlDbType.DateTime).Value = Me.DateTimePicker1.Value.Date
            cmd.Parameters.Add("@supplier_id", SqlDbType.NVarChar).Value = Me.ComboBox1.Text
            cmd.Parameters.Add("@total", SqlDbType.Float).Value = Me.lbltotal.Text
            cmd.ExecuteNonQuery()
            For i As Integer = 0 To Me.DataGridView1.Rows.Count - 2
                Dim price = Me.DataGridView1.Item(3, i).Value / Me.DataGridView1.Item(2, i).Value
                cmd.CommandText = "insert into purchase_return_details values(@pr_no,@item_id,@item_name,@price,@qty,@amount)"
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@pr_no", SqlDbType.NVarChar).Value = Me.lblno.Text
                cmd.Parameters.Add("@item_id", SqlDbType.NVarChar).Value = Me.DataGridView1.Item(0, i).Value
                cmd.Parameters.Add("@item_name", SqlDbType.NVarChar).Value = Me.DataGridView1(1, i).Value
                cmd.Parameters.Add("@price", SqlDbType.Float).Value = Me.DataGridView1.Item(2, i).Value
                cmd.Parameters.Add("@qty", SqlDbType.Int).Value = price
                cmd.Parameters.Add("@amount", SqlDbType.Float).Value = Me.DataGridView1.Item(3, i).Value
                cmd.ExecuteNonQuery()
            Next
            cmd.CommandText = "update damaged set flag=1 where supplier_id ='" & Me.ComboBox1.Text & "'and flag=0"
            cmd.ExecuteNonQuery()
            MsgBox("Goods worth Rs." & Me.lbltotal.Text & " has been Returned", MsgBoxStyle.Information, "Message")
            all_clear()
            Me.DataGridView1.Columns.Clear()
            Me.btnreturn.Enabled = False
            Me.btnnew.Enabled = True
            Me.GroupBox1.Enabled = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub PurchaseReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            all_connect()
            cmd.CommandText = " Select *  FROM  damaged where flag=0"
            Dim c = cmd.ExecuteScalar
            If c = "" Then
                MsgBox("Currently there are No Damaged Goods to Return", MsgBoxStyle.Information, "Message")
                Me.Close()
                Exit Sub
            End If
            Me.DateTimePicker1.Value = Today.Date
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub DateTimePicker1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker1.Leave
        If Me.DateTimePicker1.Value <> Today.Date Then
            MsgBox("Return date must be Todays date", MsgBoxStyle.Information, "Message")
        End If
    End Sub
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

End Class