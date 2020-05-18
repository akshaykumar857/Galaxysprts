Imports System.Data.SqlClient
Public Class Stockreport
    Dim adp As New SqlDataAdapter

    Private Sub btnshw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshw.Click
        Dim ds As New DataTable
        Try
            all_Connect()
            If Me.ComboBox2.Text = "" Then
                MsgBox("Please select the Group...!!", MsgBoxStyle.Information, "Warning")
                Exit Sub
            End If
            cmd.CommandText = "select * from stock where group_name='" & Me.ComboBox2.Text & "'"
            adp.SelectCommand = cmd
            ds.Clear()
            adp.Fill(ds)
            If ds.Rows.Count = 0 Then
                MsgBox("No Record Found...!!", MsgBoxStyle.Information, "Information")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        sel = "{stock.group_name}='" & Me.ComboBox2.Text & "'"
        CrystalStock.WindowState = FormWindowState.Maximized
        CrystalStock.Show()
    End Sub

    Private Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click
        Dim ds As New DataTable
        Try
            all_Connect()
            If Me.ComboBox1.Text = "" Then
                MsgBox("select the Brand...!!", MsgBoxStyle.Information, "Information")
                Exit Sub
            End If

            cmd.CommandText = "select * from stock where brand_name='" & Me.ComboBox1.Text & "'"
            adp.SelectCommand = cmd
            ds.Clear()
            adp.Fill(ds)
            If ds.Rows.Count = 0 Then
                MsgBox("No Record Found...!!", MsgBoxStyle.Information, "Information")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        sel = "{stock.brand_name}='" & Me.ComboBox1.Text & "'"
        CrystalStock.WindowState = FormWindowState.Maximized
        CrystalStock.Show()
    End Sub

    Private Sub btnall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnall.Click
        Dim ds As New DataTable
        Try
            all_Connect()
            cmd.CommandText = "select * from stock "
            adp.SelectCommand = cmd
            ds.Clear()
            adp.Fill(ds)
            If ds.Rows.Count = 0 Then
                MsgBox("No Record Found...!!", MsgBoxStyle.Information, "Information")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        CrystalStock.WindowState = FormWindowState.Maximized
        sel = ""
        CrystalStock.Show()
    End Sub

    Private Sub btnrecords_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrecords.Click
        Dim ds As New DataTable
        Try
            all_Connect()
            cmd.CommandText = "select * from stock "
            adp.SelectCommand = cmd
            ds.Clear()
            adp.Fill(ds)
            If ds.Rows.Count = 0 Then
                MsgBox("No Record Found...!!", MsgBoxStyle.Information, "Information")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        CrystalStock.WindowState = FormWindowState.Maximized
        sel = ""
        CrystalStock.Show()
    End Sub

    Private Sub ComboBox2_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.DropDown
        Dim dt As New DataTable


        Try
            all_connect()
            cmd.CommandText = "select group_name from group_info"
            adp.SelectCommand = cmd
            dt.Clear()
            adp.Fill(dt)
            Me.ComboBox2.Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.ComboBox2.Items.Add(dt.Rows(i).Item(0))
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub ComboBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.Click
        Dim dt As New DataTable
        Try
            all_connect()
            cmd.CommandText = "select brand_name from manufacturer"
            adp.SelectCommand = cmd
            dt.Clear()
            adp.Fill(dt)
            Me.ComboBox1.Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.ComboBox1.Items.Add(dt.Rows(i).Item(0))
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub


    

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub btnclos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclos.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.ComboBox1.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox2.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.ComboBox2.Focus()
            e.Handled = True
        End If
    End Sub

End Class