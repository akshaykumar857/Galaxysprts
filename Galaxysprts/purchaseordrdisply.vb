Imports System.Data.SqlClient
Imports System.Data
Public Class purchaseordrdisply
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt, dt1 As New DataTable
    Dim bds As New BindingSource

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.ComboBox1.Focus()
            e.Handled = True
        End If
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If Me.ComboBox1.Text = "Order No." Then
            Me.TextBox1.Show()
            Me.DateTimePicker1.Visible = False
            Me.TextBox1.Visible = True
            Me.TextBox1.Text = "PO"
        Else
            Me.TextBox1.Visible = False
            Me.DateTimePicker1.Value = Today.Date
            Me.DateTimePicker1.Visible = True
            Me.DateTimePicker1.MaxDate = Today
            Me.Panel2.Visible = False
        End If
        Me.DataGridView1.Columns.Clear()
    End Sub
    Private Sub Btndisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndisplay.Click
        Me.DataGridView1.Columns.Clear()
        Try
            all_connect()
            If Me.ComboBox1.Text = "Order No." Then
                cmd.CommandText = "SELECT item_id, item_name,group_name,supplier_id,units, qty FROM purchase_order_details where order_no ='" & Me.TextBox1.Text & "'"
                Dim c = cmd.ExecuteScalar
                If c = "" Then
                    Me.lblorder.Text = ""
                    Me.lblsupplier.Text = ""
                    Me.lbldate.Text = ""
                    MsgBox("Order Number doesnot exist", MsgBoxStyle.Information, "Message")
                    Exit Sub
                End If
                adp.SelectCommand = cmd
                dt = New DataTable
                dt.Clear()
                adp.Fill(dt)
                Me.DataGridView1.DataSource = dt
                cmd.CommandText = "SELECT purchase_order_details.order_no, purchase_order_details.supplier_id, purchase_order.order_date  FROM  purchase_order_details CROSS JOIN purchase_order WHERE purchase_order_details.order_no ='" & Me.TextBox1.Text & "'"
                adp.SelectCommand = cmd
                dt = New DataTable
                dt.Clear()
                adp.Fill(dt)
                For i As Integer = 0 To dt.Rows.Count - 1
                    Me.lblorder.Text = dt.Rows(0).Item(0)
                    Me.lblsupplier.Text = dt.Rows(0).Item(1)
                    Me.lbldate.Text = dt.Rows(0).Item(2)
                Next
                
            End If
            If Me.ComboBox1.Text = "Order Date" Then
                cmd.CommandText = "SELECT  * from purchase_order_details where order_no in(select order_no from purchase_order where order_date = @bdate )"

                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("bdate", Me.DateTimePicker1.Value.Date)

                Dim c = cmd.ExecuteScalar
                If c = "" Then
                    MsgBox("No Orders are made on " & Me.DateTimePicker1.Value.Date, MsgBoxStyle.Information, "Message")
                    Exit Sub
                End If
                adp.SelectCommand = cmd
                dt = New DataTable
                dt.Clear()
                adp.Fill(dt)
                Me.DataGridView1.DataSource = dt
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub Btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.ProcessTabKey(True)
            Me.btndisplay.Focus()
        End If
    End Sub
End Class