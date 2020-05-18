Imports System.Data.SqlClient
Imports System.Data
Public Class DamagedList
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt, dt1 As New DataTable
    Dim bds As New BindingSource
    Private Sub DamagedList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            all_connect()
            cmd.CommandText = "SELECT  item_id as ITEM_ID, item_name as ITEM_NAME, supplier_id as SUPPLIER_ID,Qty_rejected as QUANTITY_DAMAGED  FROM damaged where flag=0 ORDER BY ITEM_ID"
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
    End Sub
End Class


