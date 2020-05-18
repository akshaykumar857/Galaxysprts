Imports System.Data.SqlClient
Imports System.Data
Public Class payslip
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim bds As New BindingSource
    Dim rowindex As Integer
    Public Sub display()
        Try
            all_connect()
            cmd.CommandText = "select * from Pay_slip where Emp_id in( select Emp_id from attendance)"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Me.DataGridView1.DataSource = dt
            Me.DataGridView1.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Public Sub All_Clear()
        Me.ComboBox1.Text = ""
        Me.txtname.Text = ""
        Me.txtdesi.Text = ""
        Me.txtsal.Text = ""
        Me.txtmonth.Text = ""
        Me.txtyear.Text = ""
        Me.txtday.Text = ""
        Me.txtleave.Text = ""
        Me.txtdeduct.Text = ""
        Me.txtbonus.Text = ""
        Me.txttot.Text = ""
    End Sub
    Private Sub btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnew.Click
        Dim n As String
        Dim m As Integer
        Dim x As Integer
        All_Clear()
        Me.txtdesi.Enabled = True
        Me.ComboBox1.Enabled = True
        Me.txtno.Enabled = True
        Me.txtname.Enabled = True
        Me.txtsal.Enabled = True
        Me.txtmonth.Enabled = True
        Me.txtyear.Enabled = True

        Me.txtday.Enabled = True
        Me.txtleave.Enabled = True
        Me.txtbonus.Enabled = True
        Me.txtdeduct.Enabled = True
        Me.txttot.Enabled = True
        Me.DateTimePicker1.Enabled = True
        Try
            all_connect()
            All_Clear()
            Me.GroupBox1.Enabled = True
            cmd.CommandText = "select max(Slip_no) from Pay_slip"
            Dim id = cmd.ExecuteScalar
            If IsDBNull(id) Then
                id = "PAY101"
            Else
                n = id
                x = n.Substring(3)
                m = Int(x)
                m = m + 1
                id = "PAY" & m
            End If
            Me.txtno.Text = id
            Me.GroupBox1.Enabled = True
            Me.GroupBox2.Enabled = True
            Me.btnsave.Enabled = True
            Me.btnnew.Enabled = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Dim ch As New DataTable
        If Me.ComboBox1.Text = "" And Me.txtno.Text <> "" Then
            MsgBox("Please Select Employee ID to Calculate Salary..")
            Exit Sub
        End If
        If Me.txtdesi.Text = "" Or Me.txtleave.Text = "" Or Me.txtmonth.Text = "" Or Me.txtname.Text = "" Or Me.txtdeduct.Text = "" Or Me.ComboBox1.Text = "" Or Me.txtno.Text = "" Or Me.txtday.Text = "" Or Me.txtbonus.Text = "" Or txtsal.Text = "" Or Me.txtyear.Text = "" Or Me.txttot.Text = "" Then
            MsgBox("Please Enter All the Fields...!!")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "select Emp_id from attendance where Emp_id ='" & Me.ComboBox1.Text & "'"
            adp.SelectCommand = cmd
            ch.Clear()
            adp.Fill(ch)
            If ch.Rows.Count = 0 Then
                MsgBox("employee does not exist...!!", MsgBoxStyle.Information, "Warning")
                Exit Sub
            Else
                cmd.CommandText = "insert into Pay_slip values(@slip_no,@emp_id,@salary_date,@designation,@basic,@bonus,@month,@year,@deduct,@tot_salary)"
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@Slip_no", SqlDbType.NVarChar).Value = Me.txtno.Text
                cmd.Parameters.Add("@Emp_id", SqlDbType.NVarChar).Value = Me.ComboBox1.Text
                cmd.Parameters.Add("@Salary_date", SqlDbType.DateTime).Value = Me.DateTimePicker1.Value.Date
                cmd.Parameters.Add("@Designation", SqlDbType.NVarChar).Value = Me.txtdesi.Text
                cmd.Parameters.Add("@Basic", SqlDbType.BigInt).Value = Val(Me.txtsal.Text)
                cmd.Parameters.Add("@Bonus", SqlDbType.Float).Value = Val(Me.txtbonus.Text)
                cmd.Parameters.Add("@Month", SqlDbType.VarChar).Value = Me.txtmonth.Text
                cmd.Parameters.Add("@Year", SqlDbType.BigInt).Value = Val(Me.txtyear.Text)
                cmd.Parameters.Add("@Deduct", SqlDbType.Float).Value = Val(Me.txtdeduct.Text)
                cmd.Parameters.Add("@Tot_salary", SqlDbType.Float).Value = Val(Me.txttot.Text)
                cmd.ExecuteNonQuery()
                MsgBox("Record Saved....", MsgBoxStyle.Information, "Save Message")
                Me.btnsave.Enabled = False
                Me.btnnew.Enabled = True
                Me.GroupBox1.Enabled = False
                Me.GroupBox2.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        All_Clear()
        display()
    End Sub
    Private Sub payslip_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            all_connect()
            cmd.CommandText = "select Emp_id from attendance"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Dim j
            For j = 0 To dt.Rows.Count - 1
                Me.ComboBox1.Items.Add(dt.Rows(j).Item(0))
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try

        display()
        Me.txtdesi.Enabled = False
        Me.ComboBox1.Enabled = False
        Me.txtno.Enabled = False
        Me.txtname.Enabled = False
        Me.txtsal.Enabled = False
        Me.txtmonth.Enabled = False
        Me.txtyear.Enabled = False
        Me.txtday.Enabled = False
        Me.txtleave.Enabled = False
        Me.txtbonus.Enabled = False
        Me.txtdeduct.Enabled = False
        Me.txttot.Enabled = False
        Me.DateTimePicker1.Enabled = False
      
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If ((Char.IsSymbol(e.KeyChar)) Or (Char.IsPunctuation(e.KeyChar)) Or (Char.IsDigit(e.KeyChar)) Or (Char.IsLetter(e.KeyChar))) Then
            MsgBox("Please dont enter here", MsgBoxStyle.Exclamation)
            Me.ComboBox1.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub Combobox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            all_connect()
            cmd.CommandText = "select * from employee where Emp_id ='" & Me.ComboBox1.Text & "'"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.txtname.Text = dt.Rows(i).Item(1)
                Me.txtdesi.Text = dt.Rows(i).Item(8)
                Me.txtsal.Text = dt.Rows(i).Item(9)
            Next
            Me.txtyear.Text = Today.Year
            Me.txtmonth.Text = Today.Month
            If Me.txtmonth.Text = "1" Then
                Me.txtmonth.Text = "January"
            ElseIf Me.txtmonth.Text = "2" Then
                Me.txtmonth.Text = "February"
            ElseIf Me.txtmonth.Text = "3" Then
                Me.txtmonth.Text = "March"
            ElseIf Me.txtmonth.Text = "4" Then
                Me.txtmonth.Text = "April"
            ElseIf Me.txtmonth.Text = "5" Then
                Me.txtmonth.Text = "May"
            ElseIf Me.txtmonth.Text = "6" Then
                Me.txtmonth.Text = "June"
            ElseIf Me.txtmonth.Text = "7" Then
                Me.txtmonth.Text = "July"
            ElseIf Me.txtmonth.Text = "8" Then
                Me.txtmonth.Text = "August"
            ElseIf Me.txtmonth.Text = "9" Then
                Me.txtmonth.Text = "September"
            ElseIf Me.txtmonth.Text = "10" Then
                Me.txtmonth.Text = "October"
            ElseIf Me.txtmonth.Text = "11" Then
                Me.txtmonth.Text = "November"
            Else
                Me.txtmonth.Text = "December"
            End If
            cmd.CommandText = "select Emp_id,Month,Year from Pay_slip where Emp_id= '" & Me.ComboBox1.Text & "'And  Month='" & Me.txtmonth.Text & "'And Year='" & Me.txtyear.Text & "'"
            Dim p = cmd.ExecuteScalar
            If p <> "" Then
                MsgBox("Salary Details of  " & Me.ComboBox1.Text & " for " & Me.txtmonth.Text & " " & Me.txtyear.Text & " Already Exist")
                Me.ComboBox1.SelectedText = ""
                All_Clear()
                Exit Sub
            End If
            cmd.CommandText = "select * from Attendance where emp_id= '" & Me.ComboBox1.Text & "'And  Month='" & Me.txtmonth.Text & "'And Year='" & Me.txtyear.Text & "'"
            Dim c = cmd.ExecuteScalar
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Me.txtday.Text = dt.Rows(i).Item(5)
                    Me.txtleave.Text = dt.Rows(i).Item(4)
                Next
            Else
                MsgBox("Attendance of this Employee Has not Entered for " & Me.txtmonth.Text & " " & Me.txtyear.Text, MsgBoxStyle.Information, "Message")
                All_Clear()
                Exit Sub
            End If
            Dim perday As Integer
            Dim days As Integer
            perday = 250
            If Me.txtleave.Text <= 3 Then
                Me.txtdeduct.Text = 0
            Else
                days = Val(txtleave.Text) - 3
                Me.txtdeduct.Text = perday * days
            End If
            Me.txttot.Text = Val(Me.txtsal.Text) - Val(Me.txtdeduct.Text) + Val(Me.txtbonus.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try

    End Sub

    Private Sub Txtbonus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbonus.KeyPress
        If (Me.txtbonus.Text.Contains(".") And (e.KeyChar.ToString = ".")) Then
            e.Handled = True
            Exit Sub
        End If
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = "." Or Char.IsControl(e.KeyChar)) Then
            'MsgBox("Enter only numbers...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub

    Private Sub Txtbonus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbonus.TextChanged
        Me.txttot.Text = Val(Me.txtsal.Text) - Val(Me.txtdeduct.Text) + Val(Me.txtbonus.Text)
    End Sub
    Private Sub txtdeduction_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdeduct.KeyPress
        If (Me.txtdeduct.Text.Contains(".") And (e.KeyChar.ToString = ".")) Then
            e.Handled = True
            Exit Sub
        End If
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = "." Or Char.IsControl(e.KeyChar)) Then
            'MsgBox("Enter only numbers...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
        End If
    End Sub
    Private Sub txtdeduction_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdeduct.TextChanged
        Me.txttot.Text = Val(Me.txtsal.Text) - Val(Me.txtdeduct.Text) + Val(Me.txtbonus.Text)
    End Sub
    Private Sub DateTimePicker1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker1.Leave
        If Me.DateTimePicker1.Value > Today Then
            MsgBox("Date cant be greated then today...", MsgBoxStyle.Information, "Message")
            Me.DateTimePicker1.Value = Today
            Me.DateTimePicker1.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub txttot_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttot.TextChanged
        Me.txttot.Text = Val(Me.txtsal.Text) - Val(Me.txtdeduct.Text) + Val(Me.txtbonus.Text)
    End Sub


    Private Sub btnclose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub
End Class
