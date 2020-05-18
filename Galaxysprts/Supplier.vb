Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms
Public Class Supplier
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt, dt3, dt2 As New DataTable
    Dim bds As New BindingSource
    Public Sub display()
        Me.BtnSave.Enabled = False
        Me.BtnNew.Enabled = True
        Try
            cnn.Close()
            all_connect()
            cmd.CommandText = "select supplier_id,supplier_name,address,pno,email,website from suppliers"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Me.DataGridView1.DataSource = dt
            Me.DataGridView2.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Public Sub All_Clear()
        Me.txtsupid.Text = ""
        Me.txtsupname.Text = ""
        Me.txtsupnum.Text = ""
        Me.txtemail.Text = ""
        Me.txtadd.Text = ""
        Me.txtweb.Text = ""
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click
        Me.DataGridView1.Visible = True
        Me.DataGridView1.Enabled = True
        Me.Panel1.Enabled = True
        Me.BtnUpdate.Enabled = True
        Me.BtnEdit.Enabled = False
        Me.TxtSupId.ReadOnly = True
        Me.btndel.Enabled = False
    End Sub
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        If Me.txtsupid.Text = "" Or Me.txtsupname.Text = "" Or Me.txtsupnum.Text = "" Or Me.txtemail.Text = "" Or Me.txtadd.Text = "" Then
            MsgBox("Please Enter all Fields..")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "update suppliers set supplier_id=@supplier_id,supplier_name=@supplier_name,pno=@pno,website=@website,address=@address,email=@email where supplier_id=@supplier_id"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@supplier_id", SqlDbType.NVarChar).Value = Me.txtsupid.Text
            cmd.Parameters.Add("@supplier_name", SqlDbType.NVarChar).Value = Me.txtsupname.Text
            cmd.Parameters.Add("@pno", SqlDbType.Decimal).Value = Val(Me.txtsupnum.Text)
            cmd.Parameters.Add("@website", SqlDbType.NVarChar).Value = Me.txtweb.Text
            cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = Me.txtadd.Text
            cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = Me.txtemail.Text

            cmd.ExecuteNonQuery()
            MsgBox("Record UPDATED....", MsgBoxStyle.Information, "Message")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        display()
        All_Clear()
        Me.btnupdate.Enabled = False
        Me.btnedit.Enabled = True
        Me.btndel.Enabled = True
        Me.Panel1.Enabled = False
    End Sub


    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        Dim flag As Integer = 0
        Me.DataGridView2.ClearSelection()
        For i As Integer = 0 To Me.DataGridView2.RowCount - 1
            If Me.DataGridView2.Rows(i).Cells(0).Value = Me.txtsearch.Text Then
                Me.DataGridView1.MultiSelect = False
                Me.DataGridView2.Rows(i).Selected = True
                If i > 3 Then
                    Me.DataGridView2.FirstDisplayedScrollingRowIndex = i - 3
                End If
                flag = 1
            End If
        Next
        If flag = 0 Then
            MsgBox("Record Does not Exist....", MsgBoxStyle.Information, "Message")
            If Me.ComboBox2.Text = "Supplier ID" Then
                Me.txtsearch.Text = "SUP"
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
            If Me.ComboBox2.Text = "Name" Then
                cmd.CommandText = "Select supplier_id,supplier_name,address,pno,email,website from  suppliers where supplier_name like '" & Me.txtsearch.Text & "%'"
            End If
            If Me.txtsearch.Text = "" Or Me.txtsearch.Text = "SUP" Then
                cmd.CommandText = "Select supplier_id,supplier_name,address,pno,email,website from  suppliers"
            End If
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Me.DataGridView2.DataSource = dt
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
        If Me.ComboBox2.Text = "Supplier ID" Then
            Me.txtsearch.Text = "SUP"
            Me.btnsearch.Visible = True
            Me.DataGridView2.ClearSelection()
        Else
            Me.DataGridView2.ClearSelection()
            Me.txtsearch.Text = ""
            Me.btnsearch.Visible = False
        End If
    End Sub

    Private Sub txtsupnum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsupnum.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
            MsgBox("Enter only numbers...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub txtsupname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsupname.KeyPress
        If (sender.Text = "" And (e.KeyChar.ToString = " ")) Then
            e.Handled = True
            Exit Sub
        End If

        If (sender.Text.EndsWith(" ") And (e.KeyChar.ToString = " ")) Then
            e.Handled = True
            Exit Sub
        End If
        If Char.IsNumber(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then
            MsgBox("Enter only Alphabets...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub txtweb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtweb.KeyPress
        If (sender.Text = "" And (e.KeyChar.ToString = " ")) Then
            e.Handled = True
            Exit Sub
        End If

        If (Me.txtweb.Text.EndsWith(".") And (e.KeyChar.ToString = ".")) Then
            MsgBox("Successive dots not allowed!")
            e.Handled = True
            Exit Sub
        End If
        If (sender.Text.EndsWith(" ") And (e.KeyChar.ToString = " ")) Then
            e.Handled = True
            Exit Sub
        End If
    End Sub

    Private Sub txtweb_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtweb.Leave
        If Me.txtweb.Text <> "" Then
            Dim pattern As String
            pattern = "^www[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(/\S*)?$"
            If Not Regex.IsMatch(Me.txtweb.Text, pattern) Then
                MessageBox.Show("invalid websiteAddress")
                Me.txtweb.Clear()
                Me.txtweb.Focus()
            End If
        End If
    End Sub
    Private Sub btndel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndel.Click
        Dim ds, db, db1, db2 As New DataTable
        If Me.txtsupid.Text = "" Or Me.txtsupname.Text = "" Or Me.txtsupnum.Text = "" Or Me.txtemail.Text = "" Or Me.txtadd.Text = "" Then
            MsgBox("Please Enter all Fields..")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "select order_no from purchase_order where order_no not in(select order_no from purchase_bill)"
            adp.SelectCommand = cmd
            db = New DataTable
            db.Clear()
            adp.Fill(db)
            db1.Clear()
            For i As Integer = 0 To db.Rows.Count - 1
                cmd.CommandText = "select order_no,supplier_id from purchase_order_details where order_no='" & db.Rows(i).Item(0) & "' and supplier_id='" & Me.txtsupid.Text & "'"
                adp.SelectCommand = cmd
                adp.Fill(db1)
            Next
            If db1.Rows.Count > 0 Then
                Dim val = MsgBox("Purchase order to this supplier is pending..Do you want to cancel the order..?", MsgBoxStyle.YesNo, "Warning")
                If val = MsgBoxResult.Yes Then
                    MDIParent1.CancelOrderToolStripMenuItem_Click(sender, e)
                    cancel_order.ListBox1.SelectedItem = db1.Rows(0).Item(0)
                    Exit Sub
                Else
                    Exit Sub
                End If
            End If
            cmd.CommandText = "select supplier_id from damaged where supplier_id='" & Me.txtsupid.Text & "' and flag=0"
            adp.SelectCommand = cmd
            db2 = New DataTable
            db2.Clear()
            adp.Fill(db2)
            If db2.Rows.Count > 0 Then
                MsgBox(" Goods need to be Returned to this Supplier.." & vbCrLf & "Supplier can only be Deleted when the Goods are Returned", MsgBoxStyle.Information, "Warning")
                Exit Sub
            End If
            Dim result = MsgBox(" Are You Sure ..?? ", MsgBoxStyle.YesNo, "Confirm Delete")
            Dim supp
            supp = Me.txtsupid.Text
            If result = MsgBoxResult.Yes Then
                cmd.CommandText = "delete from suppliers where supplier_id='" & Me.txtsupid.Text & "'"
                cmd.ExecuteNonQuery()
                MsgBox("Record deleted...", MsgBoxStyle.Information, "Information")
                Me.btnupdate.Enabled = False
                Me.btndel.Enabled = False
                Me.btnedit.Enabled = True
                display()
                all_connect()
                Dim bd As New DataTable
                cmd.CommandText = "select brand_name from manufacturer where supplier_id='" & supp & "'"
                adp.SelectCommand = cmd
                bd.Clear()
                adp.Fill(bd)
                If bd.Rows.Count > 0 Then
                    Dim s = cmd.ExecuteScalar
                    All_Clear()
                    Dim res = MsgBox("supplier for the brand " & s & "is not assigned..select new supplier ", MsgBoxStyle.YesNo, "Warning")
                    If res = MsgBoxResult.Yes Then
                        MDIParent1.ModifyToolStripMenuItem1_Click(sender, e)
                        MDIParent1.brandAdd = 1
                        Manufacturer.BtnEdit_Click(sender, e)
                        Manufacturer.txtbrand.Text = s
                        Manufacturer.Bname = Manufacturer.txtbrand.Text
                        Exit Sub
                    Else
                        Exit Sub
                    End If
                End If
                All_Clear()
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        display()
        Me.btndel.Enabled = True
    End Sub


    Private Sub txtsupnum_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsupnum.Leave
        If Me.txtsupnum.Text <> "" Then
            If Me.txtsupnum.Text = "1234567890" Or Me.txtsupnum.Text = "1111111111" Or Me.txtsupnum.Text = "2222222222" Or Me.txtsupnum.Text = "3333333333" Or Me.txtsupnum.Text = "4444444444" Or Me.txtsupnum.Text = "5555555555" Or Me.txtsupnum.Text = "6666666666" Or Me.txtsupnum.Text = "77777777777" Or Me.txtsupnum.Text = "8888888888" Or Me.txtsupnum.Text = "9999999999" Or Me.txtsupnum.Text = "0000000000" Then
                MsgBox("Invalid phone number", MsgBoxStyle.Exclamation, "Check")
                Me.txtsupnum.Text = ""
                Me.txtsupnum.Focus()
                Exit Sub
            End If
            If Me.txtsupnum.Text.Length = 7 Or Me.txtsupnum.Text.Length = 10 Then
                Try
                    all_connect()
                    cmd.CommandText = "select pno from suppliers where pno='" & Me.txtsupnum.Text & "'"
                    adp.SelectCommand = cmd
                    dt2 = New DataTable
                    dt2.Clear()
                    adp.Fill(dt2)
                    If dt2.Rows.Count > 0 Then
                        MsgBox("Number  " & Me.txtsupnum.Text & " Already Exist with other Supplier", MsgBoxStyle.Information, "Warning")
                        Me.txtsupnum.Text = ""
                        Me.txtsupnum.Focus()
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                Finally
                    cnn.Close()
                End Try
            Else
                MsgBox("Invalid Phone Number..", MsgBoxStyle.Information, "Warning")
                Me.txtsupnum.Clear()
                Me.txtsupnum.Focus()
            End If
        End If
       
    End Sub

    Private Sub txtadd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtadd.KeyPress
        If (sender.Text = "" And (e.KeyChar.ToString = " ")) Then
            e.Handled = True
            Exit Sub
        End If
    End Sub


    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Me.txtsupid.Text = "" Or Me.txtsupname.Text = "" Or Me.txtsupnum.Text = "" Or Me.txtemail.Text = "" Or Me.txtadd.Text = "" Then
            MsgBox("Please Enter all Fields..")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "insert into suppliers values(@supplier_id,@supplier_name,@pno,@website,@address,@email)"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@supplier_id", SqlDbType.NVarChar).Value = Me.txtsupid.Text
            cmd.Parameters.Add("@supplier_name", SqlDbType.NVarChar).Value = Me.txtsupname.Text
            cmd.Parameters.Add("@pno", SqlDbType.Decimal).Value = Val(Me.txtsupnum.Text)
            cmd.Parameters.Add("@website", SqlDbType.NVarChar).Value = Me.txtweb.Text
            cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = Me.txtadd.Text
            cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = Me.txtemail.Text

            cmd.ExecuteNonQuery()
            MsgBox("Record Saved....", MsgBoxStyle.Information, "Save Message")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        Me.btnsave.Enabled = False
        Me.btnnew.Enabled = True
        display()
        Me.DataGridView1.MultiSelect = False
        'Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 2).Selected = True
        Me.Panel1.Enabled = False
        All_Clear()
    End Sub

    Private Sub btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnew.Click
        Dim n As String
        Dim m As Integer
        Dim x As Integer
        Try
            all_connect()
            All_Clear()
            Me.Panel1.Enabled = True
            cmd.CommandText = "select max(supplier_id) from suppliers"
            Dim id = cmd.ExecuteScalar
            If IsDBNull(id) Then
                id = "SUP101"
            Else
                n = id
                x = n.Substring(3)
                m = Int(x)
                m = m + 1
                id = "SUP" & m
            End If
            Me.txtsupid.Text = id
            Me.txtsupid.ReadOnly = True
            Me.btnnew.Enabled = False
            Me.txtsupname.Focus()
            Me.btnsave.Enabled = True
            Me.DataGridView1.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub txtsupname_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsupname.Leave
        Try
            cnn.Close()
            all_connect()
            cmd.CommandText = "select * from suppliers where supplier_name='" & Me.txtsupname.Text & "'"
            adp.SelectCommand = cmd
            Dim dt2 As New DataTable
            dt2.Clear()
            adp.Fill(dt2)
            If dt2.Rows.Count > 0 Then
                MsgBox("Supplier '" & Me.txtsupname.Text & "' already exist ")
                Me.txtsupname.Text = ""
                Me.txtsupname.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub TxtEmail_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtemail.Leave
        Dim expression As New System.Text.RegularExpressions.Regex("^[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$")
        If Not expression.IsMatch(Me.txtemail.Text) Then
            If Me.txtemail.Text = "" Then
                MsgBox("Enter E-mail id", MsgBoxStyle.Exclamation, "verify")
                Exit Sub
            Else
                MsgBox("Invalid E-mail id", MsgBoxStyle.Exclamation, "verify")
                txtemail.Clear()
                txtemail.Focus()
                Exit Sub
            End If
        End If
        If Me.txtemail.Text <> "" Then
            Try
                Dim A As New System.Net.Mail.MailAddress(Me.txtemail.Text)
                If Not (Me.txtemail.Text.Contains(".com")) Then
                    MsgBox("FormateMissmatch..." & vbCrLf & "Formate should be like  abc@mail.com", MsgBoxStyle.Information, "Warning")
                    Me.txtemail.Clear()
                    Me.txtemail.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub TxtEmail_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtemail.TextChanged
        Dim count1 = 0, I As Integer
        Dim str As String = Me.TxtEmail.Text
        For I = 0 To str.Length - 1
            If str(I) = " " Then
                count1 += 1
            End If
        Next
        If count1 > 0 Then
            MsgBox("You Cannot Use Spaces", MsgBoxStyle.Information, "Warning")
            Me.TxtEmail.Clear()
            Me.TxtEmail.Focus()
            Exit Sub
        End If
        Dim count3, j As Integer
        Dim str2 As String = Me.TxtEmail.Text
        For j = 0 To str2.Length - 1
            If str(j) = "@" Then
                count3 += 1
            End If
        Next
        If count3 > 1 Then
            MsgBox("You Cannot Use More Than 1 @", MsgBoxStyle.Information, "WARNING")
            Me.TxtEmail.Clear()
            Me.TxtEmail.Focus()
            Exit Sub
        End If
        Dim count4, k As Integer
        Dim str3 As String = Me.txtemail.Text
        For k = 0 To str3.Length - 1
            If str(k) = "." Then
                count4 += 1
            End If
        Next
        If count4 > 1 Then
            MsgBox("You Cannot Use More Than 1 .", MsgBoxStyle.Information, "WARNING")
            Me.txtemail.Clear()
            Me.txtemail.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub TxtEmail_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtemail.Validating
        cmd.CommandText = "select Email from Suppliers where Email='" & Me.txtemail.Text & "'"
        adp.SelectCommand = cmd
        Dim dt3 As New DataTable
        dt3.Clear()
        adp.Fill(dt3)
        If dt3.Rows.Count > 0 Then
            MsgBox("Email ID already Exist", MsgBoxStyle.Information, "WARNING")
            Me.TxtEmail.Clear()
            Me.TxtEmail.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            Me.txtsupid.Text = Me.DataGridView1.Item(0, e.RowIndex).Value
            Me.txtsupname.Text = Me.DataGridView1.Item(1, e.RowIndex).Value
            Me.txtadd.Text = Me.DataGridView1.Item(2, e.RowIndex).Value
            Me.txtsupnum.Text = Me.DataGridView1.Item(3, e.RowIndex).Value
            Me.txtemail.Text = Me.DataGridView1.Item(4, e.RowIndex).Value
            Me.txtweb.Text = Me.DataGridView1.Item(5, e.RowIndex).Value
        Catch ex As Exception
        End Try
    End Sub
End Class


