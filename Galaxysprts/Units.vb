Imports System.Data.SqlClient
Imports System.Data
Public Class Units
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim bds As New BindingSource
    Dim Uname As String
    Public Sub display()
        Try
            all_connect()
            cmd.CommandText = "SELECT * FROM Units"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            Me.ListBox1.DataSource = dt
            Me.ListBox1.DisplayMember = "unit_name"
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub Btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If Me.txtunit.Text = "" Then
            MsgBox("Please Enter New Unit to Add..")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "select unit_name from Units where unit_name='" & Me.txtunit.Text & "'"
            Dim name = cmd.ExecuteScalar
            If name <> "" Then
                MsgBox("Unit " & Me.txtunit.Text & " Already Exist", MsgBoxStyle.Information, "Warning")
                Me.txtunit.Text = ""
                Exit Sub
            End If
            cmd.CommandText = "insert into units values(@unit_name)"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@unit_name", SqlDbType.NVarChar).Value = Me.txtunit.Text
            cmd.ExecuteNonQuery()
            MsgBox("Unit " & Me.txtunit.Text & " Sucessfully Added ", MsgBoxStyle.Information, "Save Message")
            Me.txtunit.Text = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click
        Me.txtunit.Enabled = True
        Me.btnupdate.Visible = True
        Me.txtunit.Text = Me.ListBox1.Text
        Uname = Me.txtunit.Text
    End Sub
    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        If Me.txtunit.Text = "" Then
            MsgBox("Please Enter Unit Name to Update ..")
            Exit Sub
        End If
        Try
            all_connect()
            cmd.CommandText = "update Units set unit_name=@unit_name where unit_name='" & Uname & "'"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@unit_name", SqlDbType.NVarChar).Value = Me.txtunit.Text
            cmd.ExecuteNonQuery()
            MsgBox("Unit Name UPDATED....", MsgBoxStyle.Information, "Message")
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
        display()
        Me.BtnUpdate.Visible = False
        Me.txtunit.Text = ""
    End Sub
    Private Sub TxtUnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtunit.KeyPress
        If (sender.Text.EndsWith(" ") And (e.KeyChar.ToString = " ")) Then
            'MsgBox("Successive Space not allowed!", MsgBoxStyle.Information, "Warning")
            e.Handled = True
            Exit Sub
        End If
    End Sub

    Private Sub btnclose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub
End Class