Imports System.Data.SqlClient
Imports System.Data
Public Class reorder
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt, dt1 As New DataTable
    Dim bds As New BindingSource
    Dim i As Integer
    Private Sub Reorder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cnn.Close()
            all_connect()
            cmd.CommandText = "SELECT  item_id, item_name, brand_name, group_name,unit_name, supplier_id, reorder_level, qty from stock where qty < reorder_level"
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
    Private Sub BtnOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnorder.Click
        If Me.TextBox1.Text <> "" And Me.TextBox2.Text <> "" And Me.TextBox3.Text <> "" And Me.TextBox4.Text <> "" And Me.TextBox5.Text <> "" Then
            pur_order.Close()
            pur_order.Show()
            pur_order.WindowState = FormWindowState.Maximized
            pur_order.All_Clear()
            pur_order.btnnew.Visible = False
            pur_order.btnsave.Visible = False
            pur_order.btnedit.Visible = True
            pur_order.txtquantity.Enabled = True
            pur_order.Panel1.Enabled = False
            pur_order.Panel3.Enabled = False
            pur_order.Panel2.Enabled = False
            pur_order.btnclose.Visible = False
            Try
                all_connect()
                cmd.CommandText = "delete from stock where qty < reorder_level and item_id='" & Me.TextBox1.Text & "' and item_name='" & Me.TextBox2.Text & "' and group_name='" & Me.TextBox3.Text & "' and unit_name='" & Me.TextBox4.Text & "' and supplier_id='" & Me.TextBox5.Text & "'"
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                cnn.Close()
            End Try
        Else
            MsgBox("Select a record", MsgBoxStyle.Information, "ALert")
        End If
      
        Try
            all_connect()
            cmd.CommandText = "SELECT  item_id, item_name, brand_name, group_name,unit_name, supplier_id, reorder_level, qty from stock where qty < reorder_level"
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

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
        MDIParent1.Show()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            Me.TextBox1.Text = Me.DataGridView1.Item(0, e.RowIndex).Value
            Me.TextBox2.Text = Me.DataGridView1.Item(1, e.RowIndex).Value
            Me.TextBox3.Text = Me.DataGridView1.Item(3, e.RowIndex).Value
            Me.TextBox4.Text = Me.DataGridView1.Item(4, e.RowIndex).Value
            Me.TextBox5.Text = Me.DataGridView1.Item(5, e.RowIndex).Value
        Catch ex As Exception
        End Try
    End Sub
End Class