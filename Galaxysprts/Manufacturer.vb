Imports System.Data.SqlClient
Imports System.Data
Public Class Manufacturer
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim bds As New BindingSource
    Public Bname As String
    Public Sub display()
        Try
            cnn.Close()
            all_connect()
            cmd.CommandText = "select * from manufacturer"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.ListBox1.Items.Add(dt.Rows(i).Item(0))
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If Me.txtbrand.Text = "" Then
            MsgBox("Please Enter New BrandName to Add..")
            Exit Sub
        End If
        If Me.ComboBox1.Text = "" Then
            MsgBox("Please assign supplier to Add..")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "select brand_name from manufacturer where brand_name='" & Me.txtbrand.Text & "'"
            Dim name = cmd.ExecuteScalar
            If name <> "" Then
                MsgBox("Brand  " & Me.txtbrand.Text & " Already Exist", MsgBoxStyle.Information, "Warning")
                Me.txtbrand.Text = ""
                Exit Sub
            End If
            cmd.CommandText = "insert into manufacturer values(@brand_name,@supplier_id)"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@brand_name", SqlDbType.NVarChar).Value = Me.txtbrand.Text
            cmd.Parameters.Add("@supplier_id", SqlDbType.NVarChar).Value = Me.ComboBox1.Text
            cmd.ExecuteNonQuery()
            MsgBox("Brand " & Me.txtbrand.Text & " Sucessfully Added ", MsgBoxStyle.Information, "Save Message")
            Me.txtbrand.Text = ""
            Me.ComboBox1.Text = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Public Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click
        Me.btnupdate.Visible = True
        Me.txtbrand.Enabled = True
        Me.ComboBox1.Enabled = True
        Me.txtbrand.Text = Me.ListBox1.Text
        Bname = Me.txtbrand.Text
    End Sub
    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        If Me.txtbrand.Text = "" Then
            MsgBox("Please Enter BrandName to Update ..", MsgBoxStyle.Information, "Save Message")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "update manufacturer set brand_name=@brand_name,supplier_id=@supplier_id where brand_name='" & Bname & "'"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@brand_name", SqlDbType.NVarChar).Value = Me.txtbrand.Text
            cmd.Parameters.Add("@supplier_id", SqlDbType.NVarChar).Value = Me.ComboBox1.Text
            cmd.ExecuteNonQuery()
            MsgBox("Brand Name UPDATED....", MsgBoxStyle.Information, "Message")
            Supplier.btndel.Enabled = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        Me.ListBox1.Items.Clear()
        display()
        Me.btnupdate.Visible = False
        Me.ComboBox1.Text = ""
        Me.txtbrand.Enabled = False
        Me.ComboBox1.Enabled = False
        Me.txtbrand.Text = ""
    End Sub
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Me.txtbrand.Text = Me.ListBox1.SelectedItem.ToString
        Try
            all_connect()
            cmd.CommandText = "select supplier_id from manufacturer where brand_name='" & Me.ListBox1.SelectedItem.ToString & "'"
            Me.ComboBox1.Text = cmd.ExecuteScalar
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub TxtBrand_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbrand.KeyPress
        If (sender.Text.EndsWith(" ") And (e.KeyChar.ToString = " ")) Then
            'MsgBox("Successive Space not allowed!", MsgBoxStyle.Information, "Warning")
            e.Handled = True
            Exit Sub
        End If
    End Sub
    Private Sub ComboBox1_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDown
        Me.ComboBox1.Items.Clear()
        Try
            all_connect()
            'If MDIParent1.brandAdd = 1 Then
            '    cmd.CommandText = "select supplier_id from supplier where supplier_id not in(select supplier_id from manufacturer)"
            'Else
            cmd.CommandText = "select supplier_id from suppliers"
            'End If
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
    Private Sub BtnAddSup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaddsup.Click
        Supplier.Close()
        Supplier.Show()
        'Supplier.MdiParent = Me
        Supplier.WindowState = FormWindowState.Maximized
        Supplier.DataGridView2.Hide()
        Supplier.GroupBox1.Hide()
        Supplier.Panel1.Enabled = False
        Supplier.DataGridView1.Visible = True
        Supplier.DataGridView1.Enabled = False
        Supplier.display()
        Supplier.All_Clear()
    End Sub
    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.ComboBox1.Focus()
            e.Handled = True
        End If
    End Sub
End Class

