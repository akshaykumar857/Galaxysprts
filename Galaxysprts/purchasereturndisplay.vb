Imports System.Data.SqlClient
Imports System.Data
Public Class purchasereturndisplay
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

        If Me.ComboBox1.Text = "Purchase Return No" Then
            Me.DateTimePicker1.Visible = False
            Me.TextBox1.Visible = True

            Me.TextBox1.Text = "PR"
        Else
            Me.TextBox1.Visible = False
            Me.DateTimePicker1.Visible = True
            Me.Panel1.Visible = False
            Me.lbltotal.Visible = False
            Me.Label8.Visible = False
        End If
        Me.DataGridView1.Columns.Clear()
    End Sub
    Private Sub Btndisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndisplay.Click
        Me.DataGridView1.Columns.Clear()
        Try
            all_connect()
            If Me.ComboBox1.Text = "Purchase Return No" Then
                cmd.CommandText = "SELECT * FROM purchase_return_details where pr_no ='" & Me.TextBox1.Text & "'"
                Dim c = cmd.ExecuteScalar
                If c = "" Then
                    Me.Panel1.Visible = True
                    Me.Label8.Visible = True
                    Me.lbltotal.Visible = True
                    MsgBox("Return Number does not exist", MsgBoxStyle.Information, "Message")
                    Exit Sub
                End If
            End If
            If Me.ComboBox1.Text = "Purchase Return Date" Then
                cmd.CommandText = "SELECT * from purchase_return_details where pr_no in(select pr_no from purchase_return where return_date = @bdate )"
                'cmd.CommandText = "SELECT  * from purchase_order_details where order_no in(select order_no from purchase_order where order_date = @bdate )"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("bdate", Me.DateTimePicker1.Value.Date)
                Dim c = cmd.ExecuteScalar
                If c = "" Then
                    MsgBox("No Returns are made on " & Me.DateTimePicker1.Value.Date, MsgBoxStyle.Information, "Message")
                    Exit Sub
                End If
            End If
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Me.DataGridView1.DataSource = dt
            If Me.ComboBox1.Text = "Purchase Return No" Then
                cmd.CommandText = "SELECT return_date,supplier_id,total FROM purchase_return where pr_no ='" & Me.TextBox1.Text & "'"
                adp.SelectCommand = cmd
                dt1 = New DataTable
                dt1.Clear()
                adp.Fill(dt1)
                For i As Integer = 0 To dt1.Rows.Count - 1
                    Me.lblsupid.Text = dt1.Rows(i).Item(1)
                    Me.lblrdate.Text = dt1.Rows(i).Item(0)
                    Me.lbltotal.Text = dt1.Rows(i).Item(2)
                    Me.Label8.Visible = True
                    Me.lbltotal.Visible = True
                Next
                Me.Panel1.Visible = True
            Else
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.ProcessTabKey(True)
            Me.btndisplay.Focus()
        End If
    End Sub
End Class