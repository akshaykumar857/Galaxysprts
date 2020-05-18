Imports System.Data.SqlClient
Imports System.data
Public Class Employee
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt, dt2 As New DataTable
    Dim bds As New BindingSource
    Dim sex As String
    Dim ctr As Integer = 0
    Public Sub display()
        Me.SaveToolStripMenuItem.Enabled = False
        Me.NewToolStripMenuItem.Enabled = True
        Try
            all_connect()
            cmd.CommandText = "select emp_id,emp_name,gender,address,pno,dob,age,doj,designation,basic,status from Employee"
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
        Me.txteid.Text = ""
        Me.ComboBox2.Text = ""
        Me.TextBox1.Text = ""
        Me.txtpno.Text = ""
        Me.txtsearch.Text = ""
        Me.ComboBox1.Text = ""
        Me.ComboBox3.Text = ""
        Me.txtadd.Text = ""
        Me.txtsalary.Text = ""
        Me.TxtAge.Text = ""
        Me.RadioButton2.Checked = False
        Me.RadioButton1.Checked = False
    End Sub
    Private Sub Employee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim emp = "Employee"

            all_connect()
            cmd.CommandText = "select user_name from login where user_type='" & emp & "'"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Dim i
            For i = 0 To dt.Rows.Count - 1
                'Me.ComboBox2.DataSource = dt
                'Me.ComboBox2.DisplayMember = "user_name"
                'Me.ComboBox2.Text = ""
                Me.ComboBox2.Items.Add(dt.Rows(i).Item(0))
            Next

            Me.DateTimePicker1.MaxDate = Today.AddYears(-18)
            Me.DateTimePicker2.MinDate = Today.AddYears(-65)
            Me.txtage.Text = ""
            Me.Panel1.Visible = False
            Me.GroupBox1.Visible = False
            Me.DataGridView1.Visible = False
            Me.SaveToolStripMenuItem.Visible = False
            Me.RecordUpdateToolStripMenuItem.Visible = False
            Me.DeleteToolStripMenuItem.Visible = False
            Me.ActiveToolStripMenuItem.Visible = False
            Me.InactiveToolStripMenuItem.Visible = False
            Me.ToolStripMenuItem1.Visible = False
            Me.ComboBox1.Text = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try

    End Sub
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If sender.checked = True Then
            sex = sender.text
        End If
    End Sub
    Private Sub txtsearch_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsearch.EnabledChanged
        Try
            all_connect()
            If Me.ComboBox1.Text = "Name" Then
                cmd.CommandText = "select * from  Employee where emp_name like '" & Me.txtsearch.Text & "%'"
                adp.SelectCommand = cmd
                dt = New DataTable
                dt.Clear()
                adp.Fill(dt)
                Me.DataGridView1.DataSource = dt
            ElseIf Me.txtsearch.Text = "EMP" Then
                cmd.CommandText = "select * from Employee"
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

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.ComboBox1.Focus()
            e.Handled = True
        End If
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If Me.ComboBox1.SelectedItem.ToString = "Emp_ID" Then
            Me.txtsearch.Text = "EMP"
            Me.txtsearch.Enabled = True
            Me.btnsearch.Visible = True
            Me.DataGridView1.Visible = True
            Me.DataGridView1.ClearSelection()
        ElseIf ComboBox1.SelectedItem.ToString = "Name" Then
            Me.txtsearch.Text = ""
            Me.btnsearch.Visible = False
            Me.txtsearch.Enabled = True
            Me.DataGridView1.Visible = True
            Me.DataGridView1.ClearSelection()
        End If
    End Sub
    Private Sub txtsearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsearch.KeyPress
        If Me.ComboBox1.Text = "Name" Then

            If (Char.IsNumber(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar)) Then
                MsgBox("Enter only charecter...", MsgBoxStyle.Information, "Warning")
                e.Handled = True
            End If
        End If
        If e.KeyChar = Chr(Keys.Enter) Then
            Me.ProcessTabKey(True)
            Me.btnsearch.Focus()
        End If
    End Sub

    Private Sub DateTimePicker1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DateTimePicker1.Validating
        If Me.DateTimePicker1.Value.Date = Today Then
            Me.DateTimePicker1.Text = Today
            Me.DateTimePicker1.Focus()
            Exit Sub
        End If
        Dim y = Today.Year
        Dim y1 = Me.DateTimePicker1.Value.Year
        If y - y1 < 18 Then
            MsgBox("Minimum age must be 18", MsgBoxStyle.Exclamation, "Warning")
            Me.DateTimePicker1.Text = Today.AddYears(-18)
            Me.DateTimePicker1.Focus()
        End If
        If y - y1 > 60 Then
            MsgBox("Minimum age must be 60", MsgBoxStyle.Exclamation, "Warning")
            Me.DateTimePicker2.Text = Today
            Me.DateTimePicker1.Text = Today.AddYears(-18)

            Me.DateTimePicker1.Focus()
        End If
    End Sub
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If Me.DateTimePicker1.Value > Today Then
            MsgBox("Date OF Birth CANNOT be GREATER THEN TODAY...", MsgBoxStyle.Information, "Warning")
            Me.txtage.Text = ""
            Me.DateTimePicker1.Value = Today.AddYears(-18)
            Exit Sub
        End If
        Dim d As Date = Me.DateTimePicker1.Value
        Dim age As Integer
        age = Val(DateDiff(DateInterval.Year, d, Today))
        Me.txtage.Text = age
    End Sub

    Private Sub txtpno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpno.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
            MsgBox("Enter only numbers...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub txtsalary_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsalary.KeyPress
        If (Me.txtsalary.Text.Contains(".") And (e.KeyChar.ToString = ".")) Then
            e.Handled = True
            Exit Sub
        End If
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = "." Or Char.IsControl(e.KeyChar)) Then
            MsgBox("Enter only numbers...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If

    End Sub

    Private Sub DateTimePicker2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker2.Leave
        If Me.DateTimePicker2.Value > Today Then
            MsgBox("Date of join must be  less then TODAY...", MsgBoxStyle.Information, "Warning")
            'Me.DOBPicker.Value = Today
            Exit Sub
        End If

    End Sub

    Private Sub txtpno_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpno.Leave
        If Me.txtpno.Text <> "" Then
            If Me.txtpno.Text = "1234567890" Or Me.txtpno.Text = "1111111111" Or Me.txtpno.Text = "2222222222" Or Me.txtpno.Text = "3333333333" Or Me.txtpno.Text = "4444444444" Or Me.txtpno.Text = "5555555555" Or Me.txtpno.Text = "6666666666" Or Me.txtpno.Text = "77777777777" Or Me.txtpno.Text = "8888888888" Or Me.txtpno.Text = "9999999999" Or Me.txtpno.Text = "0000000000" Then
                MsgBox("Invalid phone number", MsgBoxStyle.Exclamation, "Check")
                Me.txtpno.Text = ""
                Me.txtpno.Focus()
                Exit Sub
            End If
            If Me.txtpno.Text.Length = 7 Or Me.txtpno.Text.Length = 10 Then
                Try
                    all_connect()
                    cmd.CommandText = "select pno from Employee where pno='" & Me.txtpno.Text & "'"
                    adp.SelectCommand = cmd
                    dt2 = New DataTable
                    dt2.Clear()
                    adp.Fill(dt2)
                    If dt2.Rows.Count > 0 Then
                        MsgBox("Number  " & Me.txtpno.Text & " Already Exist with other Employee", MsgBoxStyle.Information, "Warning")
                        Me.txtpno.Text = ""
                        Me.txtpno.Focus()
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                Finally
                    cnn.Close()
                End Try
            Else
                MsgBox("Invalid Phone Number..", MsgBoxStyle.Information, "Warning")
                Me.txtpno.Clear()
                Me.txtpno.Focus()
            End If
        End If

    End Sub

    Private Sub txtadd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtadd.KeyPress
        If (sender.Text = "" And (e.KeyChar.ToString = " ")) Then
            e.Handled = True
            Exit Sub
        End If
    End Sub

  

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If sender.checked = True Then
            sex = sender.text
        End If
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click

        Dim n As String
        Dim m As Integer
        Dim x As Integer
        Me.GroupBox1.Visible = True
        Me.DateTimePicker1.Enabled = True
        Me.DateTimePicker2.Enabled = True
        Me.txtage.Enabled = False
        Me.TextBox1.Visible = False
        Me.ComboBox2.Visible = True
        Try
            All_Clear()
            all_connect()
            Me.GroupBox1.Enabled = True
            cmd.CommandText = "select max(emp_id) from Employee"
            Dim id = cmd.ExecuteScalar
            If IsDBNull(id) Then
                id = "EMP101"
            Else
                n = id
                x = n.Substring(3)
                m = Int(x)
                m = m + 1
                id = "EMP" & m
            End If

            Me.txteid.Text = id
            Me.txteid.ReadOnly = True
            Me.Panel1.Visible = True
            Me.GroupBox1.Visible = False
            Me.DataGridView1.Visible = False
            Me.SaveToolStripMenuItem.Visible = True
            Me.SaveToolStripMenuItem.Enabled = True
            Me.ToolStripMenuItem1.Visible = True
            Me.DisplayToolStripMenuItem.Visible = False
            Me.ModifyToolStripMenuItem.Visible = False
            Me.SearchToolStripMenuItem.Visible = False
            Me.ExitToolStripMenuItem.Visible = False
            Me.NewToolStripMenuItem.Visible = False
            Me.DateTimePicker2.Value = Today
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If Me.txteid.Text = "" Or Me.ComboBox2.Text = "" Or Me.txtpno.Text = "" Or Me.ComboBox3.Text = "" Or Me.txtadd.Text = "" Then
            MsgBox("Please Enter all Fields..", MsgBoxStyle.Information, "Warning")
            Exit Sub
        End If
        If Me.RadioButton1.Checked = False And Me.RadioButton2.Checked = False Then
            MsgBox("Please Select the Gender", MsgBoxStyle.Information, "Warning")
            Exit Sub
        End If

        If Me.txtage.Text = "" Then
            MsgBox("Please Select Date of Birth to Calculate Age", MsgBoxStyle.Information, "Warning")
            Exit Sub
        End If
        If Me.DateTimePicker2.Value > Today.Date Then
            MsgBox("Date of join must be less then  TODAY...", MsgBoxStyle.Information, "Warning")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "insert into Employee values(@emp_id,@emp_name,@gender,@address,@pno,@dob,@age,@doj,@designation,@basic,@deleted)"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@emp_id", SqlDbType.NVarChar).Value = Me.txteid.Text
            cmd.Parameters.Add("@emp_name", SqlDbType.NVarChar).Value = Me.ComboBox2.Text
            cmd.Parameters.Add("@gender", SqlDbType.NVarChar).Value = sex
            cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = Me.txtadd.Text
            cmd.Parameters.Add("@pno", SqlDbType.BigInt).Value = Val(Me.txtpno.Text)
            cmd.Parameters.Add("@dob", SqlDbType.DateTime).Value = Me.DateTimePicker1.Value.Date
            cmd.Parameters.Add("@age", SqlDbType.Int).Value = Val(Me.txtage.Text)
            cmd.Parameters.Add("@doj", SqlDbType.DateTime).Value = Me.DateTimePicker2.Value.Date
            cmd.Parameters.Add("@designation", SqlDbType.NVarChar).Value = Me.ComboBox3.Text
            cmd.Parameters.Add("@basic", SqlDbType.Float).Value = Val(Me.txtsalary.Text)
            cmd.Parameters.Add("@deleted", SqlDbType.NVarChar).Value = "active"
            cmd.ExecuteNonQuery()
            MsgBox("Record Saved....", MsgBoxStyle.Information, "Save Message")
            All_Clear()
            Me.GroupBox1.Enabled = True
            Me.Panel1.Visible = False
            Me.SaveToolStripMenuItem.Visible = False
            Me.NewToolStripMenuItem.Visible = True
            Me.DateTimePicker1.Value = New Date(1990, 8, 3)
            Me.DateTimePicker2.Value = Today
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try

    End Sub

    Private Sub EditRecordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditRecordToolStripMenuItem.Click
        Me.DataGridView1.Visible = True
        Me.DataGridView1.Enabled = True
        Me.GroupBox1.Enabled = True
        Me.ComboBox2.Visible = False
        Me.txteid.ReadOnly = True
        Me.Panel1.Visible = True
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker2.Enabled = False
        Me.txtage.Enabled = False
        Me.GroupBox1.Visible = False
        Me.TextBox1.Visible = True
        Try
            all_connect()
            All_Clear()
            cmd.CommandText = "select * from Employee"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Me.DataGridView1.DataSource = dt
            Me.FileToolStripMenuItem.Visible = False
            Me.DisplayToolStripMenuItem.Visible = False
            Me.SearchToolStripMenuItem.Visible = False
            Me.ExitToolStripMenuItem.Visible = False
            Me.TextBox1.Enabled = False
            Me.EditRecordToolStripMenuItem.Visible = False
            Me.ActiveToolStripMenuItem.Visible = False
            Me.InactiveToolStripMenuItem.Visible = False
            Me.DeleteToolStripMenuItem.Visible = False
            Me.RecordUpdateToolStripMenuItem.Visible = True
            Me.ToolStripMenuItem1.Visible = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try

    End Sub

    Private Sub RecordUpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecordUpdateToolStripMenuItem.Click
        If Me.txteid.Text = "" Or Me.TextBox1.Text = "" Or Me.txtpno.Text = "" Or Me.ComboBox3.Text = "" Or Me.txtadd.Text = "" Then
            MsgBox("Please Enter all Fields..", MsgBoxStyle.Information, "Warning")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "update employee set emp_id=@emp_id,emp_name=@emp_name,gender=@gender,address=@address,pno=@pno,dob=@dob,age=@age,doj=@doj,designation=@designation,basic=@basic where emp_id=@emp_id"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@emp_id", SqlDbType.NVarChar).Value = Me.txteid.Text
            cmd.Parameters.Add("@emp_name", SqlDbType.NVarChar).Value = Me.TextBox1.Text
            cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = Me.txtadd.Text
            cmd.Parameters.Add("@pno", SqlDbType.BigInt).Value = Val(Me.txtpno.Text)
            cmd.Parameters.Add("@gender", SqlDbType.NVarChar).Value = sex
            cmd.Parameters.Add("@dob", SqlDbType.DateTime).Value = Me.DateTimePicker1.Value
            cmd.Parameters.Add("@age", SqlDbType.Int).Value = Val(Me.txtage.Text)
            cmd.Parameters.Add("@doj", SqlDbType.DateTime).Value = Me.DateTimePicker2.Value
            cmd.Parameters.Add("@designation", SqlDbType.NVarChar).Value = Me.ComboBox3 .Text
            cmd.Parameters.Add("@basic", SqlDbType.Float).Value = Val(Me.txtsalary.Text)
            cmd.ExecuteNonQuery()
            MsgBox("Record UPDATED....", MsgBoxStyle.Information, "Message")
            'Me.DataGridView1.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        'ActiveToolStripMenuItem_Click_1(sender, e)
        display()
        For i As Integer = 0 To Me.DataGridView1.RowCount - 1
            If Me.DataGridView1.Rows(i).Cells(0).Value = Me.txteid.Text Then
                Me.DataGridView1.MultiSelect = False
                Me.DataGridView1.Rows(i).Selected = True
            End If
        Next
        All_Clear()
        
        'Me.GroupBox1.Enabled = False
        Me.Panel1.Visible = True
       
        Me.DataGridView1.Visible = True
      
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim dt2 As New DataTable
        Try
            all_connect()
            cmd.CommandText = "select * from Employee where emp_id='" & Me.txteid.Text & "'"
            adp.SelectCommand = cmd
            dt2.Clear()
            adp.Fill(dt2)
            If dt2.Rows.Count > 0 Then
                cmd.CommandText = "delete from Employee where emp_id='" & Me.txteid.Text & "'"
                cmd.ExecuteNonQuery()
                MsgBox("Records Deleted")
                Me.DataGridView1.Visible = False
                Me.EditRecordToolStripMenuItem.Visible = True
                Me.FileToolStripMenuItem.Visible = True
                Me.SaveToolStripMenuItem.Visible = True
                Me.DisplayToolStripMenuItem.Visible = True
                Me.SearchToolStripMenuItem.Visible = True
                Me.ActiveToolStripMenuItem.Visible = False
                Me.DeleteToolStripMenuItem.Visible = False
                Me.ExitToolStripMenuItem.Visible = True
                Me.ToolStripMenuItem1.Visible = False
                Me.InactiveToolStripMenuItem.Visible = False
            Else
                MsgBox("No Records Found")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        Me.ComboBox1.Text = ""
        Me.txtsearch.Text = ""
        Me.DataGridView1.Visible = False
        Me.Panel1.Visible = False
        Me.GroupBox1.Visible = True
        Me.FileToolStripMenuItem.Visible = False
        Me.ModifyToolStripMenuItem.Visible = False
        Me.DisplayToolStripMenuItem.Visible = False
        Me.SearchToolStripMenuItem.Visible = False
        Me.ToolStripMenuItem1.Visible = True
        Me.ExitToolStripMenuItem.Visible = False
    End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
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
            Me.DataGridView1.ClearSelection()
        End If
        Me.SearchToolStripMenuItem.Visible = False
        Me.GroupBox1.Visible = True
    End Sub

   
    Private Sub txtsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        Try
            all_connect()
            If Me.ComboBox1.Text = "Name" Then
                cmd.CommandText = "select * from  Employee where emp_name like '" & Me.txtsearch.Text & "%'"
                adp.SelectCommand = cmd
                dt = New DataTable
                dt.Clear()
                adp.Fill(dt)
                Me.DataGridView1.Visible = True
                Me.DataGridView1.DataSource = dt
            ElseIf Me.txtsearch.Text = "EMP" Then
                cmd.CommandText = "select * from Employee"
                adp.SelectCommand = cmd
                dt = New DataTable
                dt.Clear()
                adp.Fill(dt)
                Me.DataGridView1.Visible = True
                Me.DataGridView1.DataSource = dt
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        All_Clear()
        Me.FileToolStripMenuItem.Visible = True
        Me.DisplayToolStripMenuItem.Visible = True
        Me.SearchToolStripMenuItem.Visible = True
        Me.ModifyToolStripMenuItem.Visible = True
        Me.ExitToolStripMenuItem.Visible = True
        Me.ToolStripMenuItem1.Visible = False
        Me.GroupBox1.Visible = False
        Me.Panel1.Visible = False
        Me.DataGridView1.Visible = False
        Me.NewToolStripMenuItem.Visible = True
        Me.SaveToolStripMenuItem.Visible = False
        Me.EditRecordToolStripMenuItem.Visible = True
        Me.RecordUpdateToolStripMenuItem.Visible = False
        Me.DeleteToolStripMenuItem.Visible = False
        Me.InactiveToolStripMenuItem.Visible = False
        Me.ActiveToolStripMenuItem.Visible = False
        Me.DataGridView1.Visible = False

    End Sub

    Private Sub ActiveEmployeesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActiveEmployeesToolStripMenuItem.Click
        Me.DataGridView1.Visible = True
        Me.SaveToolStripMenuItem.Enabled = False
        Me.NewToolStripMenuItem.Enabled = True
        Try
            all_connect()
            cmd.CommandText = "select * from Employee where status='active'"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Me.DataGridView1.DataSource = dt
            Me.ToolStripMenuItem1.Visible = True
            Me.FileToolStripMenuItem.Visible = False
            Me.DisplayToolStripMenuItem.Visible = False
            Me.SearchToolStripMenuItem.Visible = False
            Me.ExitToolStripMenuItem.Visible = False
            Me.EditRecordToolStripMenuItem.Visible = False
            Me.ActiveToolStripMenuItem.Visible = False
            Me.InactiveToolStripMenuItem.Visible = True
            Me.DeleteToolStripMenuItem.Visible = True

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub InactiveEmployesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InactiveEmployesToolStripMenuItem.Click
        Me.DataGridView1.Visible = True
        Me.SaveToolStripMenuItem.Enabled = False
        Me.NewToolStripMenuItem.Enabled = True
        Try
            all_connect()
            cmd.CommandText = "select * from Employee where status='inactive'"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Me.DataGridView1.DataSource = dt
            Me.ToolStripMenuItem1.Visible = True
            Me.FileToolStripMenuItem.Visible = False
            Me.DisplayToolStripMenuItem.Visible = False
            Me.SearchToolStripMenuItem.Visible = False
            Me.ExitToolStripMenuItem.Visible = False
            Me.EditRecordToolStripMenuItem.Visible = False
            Me.InactiveToolStripMenuItem.Visible = False
            Me.ActiveToolStripMenuItem.Visible = True
            Me.DeleteToolStripMenuItem.Visible = True
            
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub ActiveToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActiveToolStripMenuItem.Click
        Dim dt2 As New DataTable
        Try
            all_connect()
            cmd.CommandText = "select * from Employee where emp_id='" & Me.txteid.Text & "' and status='inactive'"
            adp.SelectCommand = cmd
            dt2.Clear()
            adp.Fill(dt2)
            If dt2.Rows.Count > 0 Then
                cmd.CommandText = "update Employee set status='active' where emp_id='" & Me.txteid.Text & "'"
                cmd.ExecuteNonQuery()
                MsgBox("Employee is Active....", MsgBoxStyle.Information, "Information")
                cnn.Close()
                all_connect()
                cmd.CommandText = "select * from Employee where status='inactive'"
                adp.SelectCommand = cmd
                dt = New DataTable
                dt.Clear()
                adp.Fill(dt)
                Me.DataGridView1.DataSource = dt
                Me.DataGridView1.Visible = True
                Me.ToolStripMenuItem1.Visible = True
                Me.ModifyToolStripMenuItem.Visible = False
            Else
                MsgBox("No Records Found")
                Me.DataGridView1.Visible = True
                Exit Sub
            End If
            Me.Panel1.Visible = False
            Me.ToolStripMenuItem1.Visible = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub InactiveToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InactiveToolStripMenuItem.Click
        Dim dt2 As New DataTable
        Try
            all_connect()
            cmd.CommandText = "select * from Employee where emp_id='" & Me.txteid.Text & "' and status='active'"
            adp.SelectCommand = cmd
            dt2.Clear()
            adp.Fill(dt2)
            If dt2.Rows.Count > 0 Then
                cmd.CommandText = "update Employee set status='inactive' where emp_id='" & Me.txteid.Text & "'"
                cmd.ExecuteNonQuery()
                MsgBox("Employee is Inactive....", MsgBoxStyle.Information, "Information")
                cnn.Close()
                all_connect()
                cmd.CommandText = "select * from Employee where status='active'"
                adp.SelectCommand = cmd
                dt = New DataTable
                dt.Clear()
                adp.Fill(dt)
                Me.DataGridView1.DataSource = dt
                Me.DataGridView1.Visible = True
                Me.ToolStripMenuItem1.Visible = True
                Me.ModifyToolStripMenuItem.Visible = False
            Else
                MsgBox("No Records Found")
                Me.DataGridView1.Visible = True
                Exit Sub
            End If
            Me.Panel1.Visible = False

            Me.ToolStripMenuItem1.Visible = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox3.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.ComboBox3.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        If Me.ComboBox3.Text = "Manager" Then
            Me.txtsalary.Text = 35000
        ElseIf Me.ComboBox3.Text = "Sales Representative" Then
            Me.txtsalary.Text = 20000
        ElseIf Me.ComboBox3.Text = "Inventory Manager" Then
            Me.txtsalary.Text = 18000
        ElseIf Me.ComboBox3.Text = "Cashier" Then
            Me.txtsalary.Text = 15000
        ElseIf Me.ComboBox3.Text = "Cleaner" Then
            Me.txtsalary.Text = 10000
        End If
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
            cmd.CommandText = "select * from Employee where emp_name='" & Me.ComboBox2.SelectedItem & "'"
            adp.SelectCommand = cmd
            Dim dt2 As New DataTable
            dt2.Clear()
            adp.Fill(dt2)
            If dt2.Rows.Count > 0 Then
                MsgBox("Name '" & Me.ComboBox2.Text & "' already exist ")
                Me.ComboBox2.SelectedText = ""
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            Me.txteid.Text = Me.DataGridView1.Item(0, e.RowIndex).Value
            Me.TextBox1.Text = Me.DataGridView1.Item(1, e.RowIndex).Value
            If Me.DataGridView1.Item(2, e.RowIndex).Value = "Male" Then
                Me.RadioButton1.Checked = True
            Else
                Me.RadioButton2.Checked = True
            End If
            Me.txtadd.Text = Me.DataGridView1.Item(3, e.RowIndex).Value
            Me.txtpno.Text = Me.DataGridView1.Item(4, e.RowIndex).Value
            Me.DateTimePicker1.Value = Me.DataGridView1.Item(5, e.RowIndex).Value
            Me.txtage.Text = Me.DataGridView1.Item(6, e.RowIndex).Value
            Me.DateTimePicker2.Value = Me.DataGridView1.Item(7, e.RowIndex).Value
            Me.ComboBox3.Text = Me.DataGridView1.Item(8, e.RowIndex).Value
            Me.txtsalary.Text = Me.DataGridView1.Item(9, e.RowIndex).Value
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If (sender.Text = "" And (e.KeyChar.ToString = " ")) Then
            e.Handled = True
            Exit Sub
        End If
        If (sender.Text.EndsWith(" ") And (e.KeyChar.ToString = " ")) Then
            MsgBox("Successive Space not allowed!", MsgBoxStyle.Information, "Warning")
            e.Handled = True
            Exit Sub
        End If
        If (Char.IsNumber(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar)) Then
            MsgBox("Enter only character...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub txtpno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpno.TextChanged

    End Sub
End Class