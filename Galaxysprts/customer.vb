Imports System.Data.SqlClient
Imports System.Data
Public Class customer
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt, dt2 As New DataTable
    Dim bds As New BindingSource
    Public Sub display()
        Try
            all_connect()
            cmd.CommandText = "select * from customer"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Me.DataGridView1.DataSource = dt
            ' Me.DataGridView2.DataSource = dt
            Me.UpdateToolStripMenuItem.Visible = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Public Sub All_Clear()
        Me.txtid.Text = ""
        Me.ComboBox1.Text = ""
        Me.txtname.Text = ""
        Me.txtphone.Text = ""
        Me.txtmail.Text = ""
        Me.txtadd.Text = ""
        Me.txtsearch.Text = ""
    End Sub
    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub Txtmail_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmail.Leave
        Dim expression As New System.Text.RegularExpressions.Regex("^[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$")
        If Not expression.IsMatch(Me.txtmail.Text) Then
            If Me.txtmail.Text = "" Then
                MsgBox("Enter E-mail id", MsgBoxStyle.Exclamation, "verify")
                Exit Sub
            Else
                MsgBox("Invalid E-mail id", MsgBoxStyle.Exclamation, "verify")
                txtmail.Clear()
                txtmail.Focus()
                Exit Sub
            End If
        End If
        If Me.txtmail.Text <> "" Then
            Try
                Dim A As New System.Net.Mail.MailAddress(Me.txtmail.Text)
                If Not (Me.txtmail.Text.Contains(".com")) Then
                    MsgBox("Format Mismatch..." & vbCrLf & "Format should be like abc@mail.com", MsgBoxStyle.Information, "Warning")
                    Me.txtmail.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub Txtmail_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmail.TextChanged

        Dim count1 = 0, I As Integer
        Dim str As String = Me.txtmail.Text
        For I = 0 To str.Length - 1
            If str(I) = " " Then
                count1 += 1
            End If
        Next
        If count1 > 0 Then
            MsgBox("You Cannot Use Spaces", MsgBoxStyle.Information, "Warning")
            Me.txtmail.Clear()
            Me.txtmail.Focus()
            Exit Sub
        End If
        Dim count3, j As Integer
        Dim str2 As String = Me.txtmail.Text
        For j = 0 To str2.Length - 1
            If str(j) = "@" Then
                count3 += 1
            End If
        Next
        If count3 > 1 Then
            MsgBox("You Cannot Use More Than 1 @", MsgBoxStyle.Information, "WARNING")
            Me.txtmail.Clear()
            Me.txtmail.Focus()
            Exit Sub
        End If
        Me.txtadd.Enabled = True

    End Sub

    Private Sub Txtmail_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtmail.Validating
        cmd.CommandText = "select Email from customer where Email='" & Me.txtmail.Text & "'"
        adp.SelectCommand = cmd
        Dim dt3 As New DataTable
        dt3.Clear()
        adp.Fill(dt3)
        If dt3.Rows.Count > 0 Then
            MsgBox("Email ID already Exist", MsgBoxStyle.Information, "WARNING")
            Me.txtmail.Clear()
            Me.txtmail.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub txtphone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtphone.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
            MsgBox("enter only numbers...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub
    Private Sub txtphone_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtphone.Leave
        If Me.txtphone.Text <> "" Then
            If Me.txtphone.Text = "1234567890" Or Me.txtphone.Text = "1111111111" Or Me.txtphone.Text = "2222222222" Or Me.txtphone.Text = "3333333333" Or Me.txtphone.Text = "4444444444" Or Me.txtphone.Text = "5555555555" Or Me.txtphone.Text = "6666666666" Or Me.txtphone.Text = "77777777777" Or Me.txtphone.Text = "8888888888" Or Me.txtphone.Text = "9999999999" Or Me.txtphone.Text = "0000000000" Then
                MsgBox("Invalid phone number", MsgBoxStyle.Exclamation, "Check")
                Me.txtphone.Text = ""
                Me.txtphone.Focus()
                Exit Sub
            End If
            If Me.txtphone.Text.Length = 7 Or Me.txtphone.Text.Length = 10 Then
                Try
                    all_connect()
                    cmd.CommandText = "select pno from Customer where pno='" & Me.txtphone.Text & "'"
                    adp.SelectCommand = cmd
                    dt2 = New DataTable
                    dt2.Clear()
                    adp.Fill(dt2)
                    If dt2.Rows.Count > 0 Then
                        MsgBox("Number  " & Me.txtphone.Text & " Already Exist with other Customer", MsgBoxStyle.Information, "Warning")
                        Me.txtphone.Text = ""
                        Me.txtphone.Focus()
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                Finally
                    cnn.Close()
                End Try
            Else
                MsgBox("Invalid Phone Number..", MsgBoxStyle.Information, "Warning")
                Me.txtphone.Clear()
                Me.txtphone.Focus()
            End If
        End If
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.ComboBox1.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub Combobox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If Me.ComboBox1.Text = "Cust_ID" Then
            Me.txtsearch.Text = "CUST"
            Me.btnsearch.Visible = True
        Else
            Me.txtsearch.Text = ""
            Me.btnsearch.Visible = False
        End If
        Me.btnsearch.Visible = True
        Me.txtsearch.Text = "CUST"
        If Me.ComboBox1.Text = "Name" Then
            Me.txtsearch.Text = ""
            Me.btnsearch.Visible = False
        End If
        ''If Me.ComboBox1.SelectedItem.ToString = "Cust_ID" Then
        ''    Me.txtsearch.Text = "CUST"
        ''    Me.txtsearch.Enabled = True
        ''    Me.DataGridView1.Visible = True
        ''    Me.DataGridView1.ClearSelection()
        ''ElseIf ComboBox1.SelectedItem.ToString = "Name" Then
        ''    Me.txtsearch.Text = ""
        ''    Me.txtsearch.Enabled = True
        ''    Me.DataGridView1.Visible = True
        ''    Me.DataGridView1.ClearSelection()
        ''End If
    End Sub
    Private Sub txtsearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsearch.KeyPress
        If Me.ComboBox1.Text = "Name" Then
            If Char.IsNumber(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then
                MsgBox("Enter only Alphabets...", MsgBoxStyle.Information, "Warning")
                e.Handled = True
            End If
        End If
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.ProcessTabKey(True)
            Me.btnsearch.Focus()
        End If
    End Sub
    Private Sub txtsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        Try
            all_connect()
            If Me.ComboBox1.Text = "Name" Then
                cmd.CommandText = "Select * from  customer where cust_name like '" & Me.txtsearch.Text & "%'"
            End If
            If Me.txtsearch.Text = "" Or Me.txtsearch.Text = "CUST" Then
                cmd.CommandText = "Select * from  customer"
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
    Private Sub txtname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtname.KeyPress
        If (sender.Text.EndsWith(" ") And (e.KeyChar.ToString = " ")) Then
            e.Handled = True
            Exit Sub
        End If
        If Char.IsNumber(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then
            MsgBox("Enter only Alphabets...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub
    Private Sub customer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.Combosearch.Items.Add("Cust_id")
        '  Me.Combosearch.Items.Add("Cust_name")
        Me.DataGridView1.Visible = False
        Me.GroupBox2.Visible = False
        Me.ToolStripMenuItem1.Visible = False
        Me.GroupBox1.Visible = False
        Me.SaveToolStripMenuItem.Visible = False
    End Sub
    Private Sub NewToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Dim n As String
        Dim m As Integer
        Dim x As Integer

        Me.GroupBox1.Visible = True
        Me.GroupBox2.Visible = False
        Me.DataGridView1.Visible = False

        Try
            all_connect()
            All_Clear()
            'Me.Panel1.Enabled = True
            cmd.CommandText = "select max(cust_id) from customer"
            Dim id = cmd.ExecuteScalar
            If IsDBNull(id) Then
                id = "CUST101"
            Else
                n = id
                x = n.Substring(4)
                m = Int(x)
                m = m + 1
                id = "CUST" & m
            End If
            Me.txtid.Text = id
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        Me.ModifyToolStripMenuItem.Visible = False
        Me.DisplayToolStripMenuItem.Visible = False
        Me.SearchToolStripMenuItem.Visible = False
        Me.SaveToolStripMenuItem.Enabled = True
        Me.txtid.ReadOnly = True
        Me.NewToolStripMenuItem.Enabled = False
        Me.SaveToolStripMenuItem.Visible = True
        Me.GroupBox1.Enabled = True
        Me.ToolStripMenuItem1.Visible = True
        Me.ExitToolStripMenuItem.Visible = False
        Me.txtname.Focus()
    End Sub

    Private Sub SaveToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If Me.txtid.Text = "" Or Me.txtname.Text = "" Or Me.txtphone.Text = "" Or Me.txtmail.Text = "" Or Me.txtadd.Text = "" Then
            MsgBox("Please Enter all Fields..")
            Exit Sub
        End If

        Try
            all_connect()
            cmd.CommandText = "insert into customer values(@cust_id,@cust_name,@address,@pno,@email)"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@cust_id", SqlDbType.NVarChar).Value = Me.txtid.Text
            cmd.Parameters.Add("@cust_name", SqlDbType.NVarChar).Value = Me.txtname.Text
            cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = Me.txtadd.Text
            cmd.Parameters.Add("@pno", SqlDbType.BigInt).Value = Val(Me.txtphone.Text)
            cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = Me.txtmail.Text
            cmd.ExecuteNonQuery()
            MsgBox("Record Saved....", MsgBoxStyle.Information, "Save Message")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        Me.GroupBox1.Visible = True
        Me.GroupBox2.Visible = False
        Me.DataGridView1.Visible = False
        Me.SaveToolStripMenuItem.Enabled = False
        Me.NewToolStripMenuItem.Enabled = True
        Me.EditToolStripMenuItem.Enabled = False
        Me.UpdateToolStripMenuItem.Enabled = False
        Me.ModifyToolStripMenuItem.Visible = False
        Me.DisplayToolStripMenuItem.Visible = False
        Me.ToolStripMenuItem1.Visible = True
        Me.SearchToolStripMenuItem.Visible = False
        display()
        Me.DataGridView1.MultiSelect = False
        ' Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 2).Selected = True
        Me.GroupBox1.Enabled = False
        All_Clear()
    End Sub
    Private Sub EditRecordsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
     
        Try
            all_connect()
            cmd.CommandText = "select * from customer"
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
        Me.GroupBox2.Visible = False
        Me.DataGridView1.Visible = True
        Me.UpdateToolStripMenuItem.Visible = True
        Me.EditToolStripMenuItem.Enabled = False
        Me.GroupBox1.Visible = True
        Me.UpdateToolStripMenuItem.Enabled = True
        Me.txtid.Text = ""
        Me.txtid.ReadOnly = True
        Me.GroupBox1.Enabled = True
        Me.ToolStripMenuItem1.Visible = True
        Me.ExitToolStripMenuItem.Visible = False
        Me.FileToolStripMenuItem.Visible = False
        Me.DisplayToolStripMenuItem.Visible = False
        Me.SearchToolStripMenuItem.Visible = False
        Me.ExitToolStripMenuItem.Visible = False
    End Sub
    Private Sub UpdateRecordsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem.Click
        If Me.txtid.Text = "" Or Me.txtname.Text = "" Or Me.txtadd.Text = "" Or Me.txtphone.Text = "" Or Me.txtmail.Text = "" Then
            MsgBox("Please Enter all Fields..")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "update customer set cust_name=@cust_name,address=@address,pno=@pno,email=@email where cust_id=@cust_id"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@cust_id", SqlDbType.NVarChar).Value = Me.txtid.Text
            cmd.Parameters.Add("@cust_name", SqlDbType.NVarChar).Value = Me.txtname.Text
            cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = Me.txtadd.Text
            cmd.Parameters.Add("@pno", SqlDbType.BigInt).Value = Val(Me.txtphone.Text)
            cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = Me.txtmail.Text
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
        Me.UpdateToolStripMenuItem.Enabled = True
        Me.EditToolStripMenuItem.Visible = True
        Me.EditToolStripMenuItem.Enabled = False
    End Sub
    Private Sub DisplayToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisplayToolStripMenuItem.Click

        Try
            all_connect()
            cmd.CommandText = "select * from customer"
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
        Me.GroupBox1.Visible = False
        Me.GroupBox2.Visible = False
        Me.DataGridView1.Visible = True
        Me.DisplayToolStripMenuItem.Visible = False
        Me.ModifyToolStripMenuItem.Visible = False
        Me.ToolStripMenuItem1.Visible = True
        Me.ExitToolStripMenuItem.Visible = False
        Me.FileToolStripMenuItem.Visible = False
        Me.SearchToolStripMenuItem.Visible = False
    End Sub
    Private Sub SearchToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        Me.FileToolStripMenuItem.Visible = False
        Me.ModifyToolStripMenuItem.Visible = False
        Me.DisplayToolStripMenuItem.Visible = False
        Me.ExitToolStripMenuItem.Visible = False
        Me.SearchToolStripMenuItem.Visible = False
        Me.GroupBox1.Visible = False
        Me.GroupBox2.Visible = True
        Me.ToolStripMenuItem1.Visible = True
        Me.DataGridView1.Visible = True
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        Me.DataGridView1.Visible = True
        Me.GroupBox2.Visible = True
        Me.GroupBox1.Visible = False
        Dim flag As Integer = 0
        For i As Integer = 0 To Me.DataGridView1.RowCount - 1
            If Me.DataGridView1.Rows(i).Cells(0).Value = Me.txtsearch.Text Then
                Me.DataGridView1.MultiSelect = False
                Me.DataGridView1.Rows(i).Selected = True
                If i > 3 Then
                    Me.DataGridView1.FirstDisplayedScrollingRowIndex = i - 3
                End If
                flag = 1
            End If
        Next
        If flag = 0 Then
            MsgBox("Record Does not Exist....", MsgBoxStyle.Information, "Message")
            If Me.ComboBox1.Text = "CUST_ID" Then
                Me.txtsearch.Text = "CUST"
            Else
                Me.txtsearch.Text = ""
            End If

        End If
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        All_Clear()
        Me.FileToolStripMenuItem.Visible = True
        Me.ModifyToolStripMenuItem.Visible = True
        Me.DisplayToolStripMenuItem.Visible = True
        Me.SearchToolStripMenuItem.Visible = True
        Me.ExitToolStripMenuItem.Visible = True
        Me.ToolStripMenuItem1.Visible = False
        Me.GroupBox1.Visible = False
        Me.DataGridView1.Visible = False
        Me.NewToolStripMenuItem.Visible = True
        Me.NewToolStripMenuItem.Enabled = True
        Me.SaveToolStripMenuItem.Visible = False
        Me.EditToolStripMenuItem.Visible = True
        Me.EditToolStripMenuItem.Enabled = True
        Me.UpdateToolStripMenuItem.Visible = False
        Me.GroupBox2.Visible = False

        Me.DataGridView1.Visible = False
    End Sub

    Private Sub txtid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtid.TextChanged
        Me.txtname.Enabled = True

    End Sub

    Private Sub txtname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtname.TextChanged
        Me.txtphone.Enabled = True

    End Sub

    Private Sub txtphone_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtphone.TextChanged
        Me.txtmail.Enabled = True

    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Me.txtid.Text = Me.DataGridView1.Item(0, e.RowIndex).Value
        Me.txtname.Text = Me.DataGridView1.Item(1, e.RowIndex).Value
        Me.txtadd.Text = Me.DataGridView1.Item(2, e.RowIndex).Value
        Me.txtphone.Text = Me.DataGridView1.Item(3, e.RowIndex).Value
        Me.txtmail.Text = Me.DataGridView1.Item(4, e.RowIndex).Value
        Me.ModifyToolStripMenuItem.Enabled = True
    End Sub
End Class
