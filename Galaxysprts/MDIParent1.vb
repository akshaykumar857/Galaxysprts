Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class MDIParent1
    Public brandAdd As Integer = 0
    Private m_ChildFormNumber As Integer = 0
    Dim adp As New SqlDataAdapter
    Dim dt As New DataTable
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim result As Integer
        result = MsgBox("Are you sure??", MsgBoxStyle.OkCancel + MsgBoxStyle.Information, "Close")
        If (result = MsgBoxResult.Ok) Then
            Try
                cnn.Close()
                all_connect()
                cmd.CommandText = "insert into Histroy values(@user_name,@login,@logout)"
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@user_name", SqlDbType.VarChar).Value = unamee
                cmd.Parameters.Add("@login", SqlDbType.DateTime).Value = dat
                cmd.Parameters.Add("@logout", SqlDbType.DateTime).Value = Now
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                cnn.Close()
            End Try
            End
        End If
        

    End Sub
    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        changepassword.Show()
        WindowState = FormWindowState.Maximized
    End Sub
    Private Sub SetSecurityQuestionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetSecurityQuestionToolStripMenuItem.Click
        setsecurityquestion.Show()
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem41.Click
        If logger.TextBox3.Text = "Employee" Or logger.TextBox3.Text = "Administrator" Then
            logger.txtname.Text = ""
            logger.txtpass.Text = ""
        End If
        Dim result = MsgBox(" Are You Sure ..?? ", MsgBoxStyle.YesNo, "Confirm Close")
        If result = Windows.Forms.DialogResult.Yes Then
            Try
                cnn.Close()
                all_connect()
                cmd.CommandText = "insert into Histroy values(@user_name,@login,@logout)"
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@user_name", SqlDbType.VarChar).Value = unamee
                cmd.Parameters.Add("@login", SqlDbType.DateTime).Value = dat
                cmd.Parameters.Add("@logout", SqlDbType.DateTime).Value = Now
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                cnn.Close()
            End Try

            login.Show()
            Me.Hide()
        End If
      
    End Sub

    Private Sub CreateUserAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateUserAccountToolStripMenuItem.Click
        createaccount.Show()
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub UnblockAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnblockAccountsToolStripMenuItem.Click
        Unblock.Show()
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ListEditDeleteAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListEditDeleteAccountToolStripMenuItem.Click
        LEDaccount.Show()
        WindowState = FormWindowState.Maximized
    End Sub
    Private Sub EmployeeDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem12.Click
        Employee.Close()
        Employee.Show()
        Employee.WindowState = FormWindowState.Maximized
        Employee.GroupBox1.Visible = False
    End Sub

    Private Sub EmployeeAttendanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem13.Click
        attendance.Close()
        attendance.Show()
        attendance.GroupBox1.Visible = False
        attendance.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub EmployeeSalaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem14.Click
        payslip.Close()
        payslip.Show()
        payslip.WindowState = FormWindowState.Maximized
        payslip.display()
    End Sub

    Private Sub CustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem42.Click
        customer.Close()
        customer.Show()
        customer.WindowState = FormWindowState.Maximized
        customer.display()
    End Sub


    Private Sub AddToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem17.Click
        Supplier.Close()
        Supplier.Show()
        Supplier.WindowState = FormWindowState.Maximized
        Supplier.DataGridView2.Hide()
        Supplier.GroupBox1.Hide()
        Supplier.Panel1.Enabled = False
        Supplier.DataGridView1.Visible = True
        Supplier.DataGridView1.ClearSelection()
        Supplier.DataGridView1.Enabled = False
        Supplier.btnedit.Enabled = False
        Supplier.btnupdate.Enabled = False

        Supplier.btndel.Enabled = False
        Supplier.display()
        Supplier.All_Clear()
    End Sub

    Private Sub ModifyToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem18.Click
        Supplier.Close()
        Supplier.Show()
        Supplier.WindowState = FormWindowState.Maximized
        Supplier.btnnew.Visible = False
        Supplier.btnsave.Visible = False
        Supplier.btnedit.Visible = True
        Supplier.btnupdate.Visible = True
        Supplier.btnupdate.Enabled = False
        Supplier.btndel.Visible = True
        Supplier.DataGridView1.Visible = True
        Supplier.DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Supplier.Panel1.Enabled = False
        Supplier.DataGridView2.Hide()
        Supplier.GroupBox1.Hide()
        Supplier.display()
    End Sub

    Private Sub ListToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem19.Click
        Supplier.Close()
        Supplier.Show()
        Supplier.btnclose.Visible = True
        Supplier.WindowState = FormWindowState.Maximized
        Supplier.Panel1.Hide()
        Supplier.Panel2.Hide()
        Supplier.DataGridView1.Visible = False
        Supplier.GroupBox1.Show()
        Supplier.DataGridView2.Show()
        Supplier.display()
        Supplier.btnclose.Visible = True
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Group.Show()
        Group.WindowState = FormWindowState.Maximized
        Group.txtgroup.Visible = True
        Group.btnadd.Visible = True
        Group.btnclose.Visible = True
    End Sub

    Private Sub ModifyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModifyToolStripMenuItem.Click
        Group.Show()
        Group.WindowState = FormWindowState.Maximized
        Group.txtgroup.Visible = True
        Group.txtgroup.Enabled = False
        Group.ListBox1.Visible = True
        Group.btnedit.Visible = True
        Group.btnexit.Visible = True
        Group.display()
    End Sub

    Private Sub ListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListToolStripMenuItem.Click
        Group.Show()
        Group.WindowState = FormWindowState.Maximized
        Group.txtgroup.Visible = True
        Group.ListBox1.Visible = True
        Group.txtgroup.Visible = False
        Group.Label1.Visible = False
        Group.btnexit.Visible = True
        Group.display()
    End Sub

    Private Sub AddToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem2.Click

        Units.Show()
        Units.WindowState = FormWindowState.Maximized
        Units.txtunit.Visible = True
        Units.btnadd.Visible = True
        Units.btnclose.Visible = True
    End Sub

    Private Sub ModifyToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModifyToolStripMenuItem2.Click
        Units.Show()
        Units.WindowState = FormWindowState.Maximized
        Units.txtunit.Visible = True
        Units.txtunit.Enabled = False
        Units.ListBox1.Visible = True
        Units.btnedit.Visible = True
        Units.btnexit.Visible = True
        Units.display()
    End Sub

    Private Sub ListToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListToolStripMenuItem2.Click
        Units.Show()
        Units.WindowState = FormWindowState.Maximized
        Units.Label1.Visible = True
        Units.Label2.Visible = False
        Units.ListBox1.Visible = True
        Units.display()
        Units.btnexit.Visible = True
    End Sub

    Public Sub AddToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem1.Click
        brandAdd = 1
        Manufacturer.Show()
        Manufacturer.WindowState = FormWindowState.Maximized
        Manufacturer.txtbrand.Visible = True
        Manufacturer.btnadd.Visible = True
        Manufacturer.btnclose.Visible = True
    End Sub
    Public Sub ModifyToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModifyToolStripMenuItem1.Click
        brandAdd = 0
        Manufacturer.Show()
        Manufacturer.WindowState = FormWindowState.Maximized
        Manufacturer.txtbrand.Enabled = False
        Manufacturer.ComboBox1.Enabled = False
        Manufacturer.txtbrand.Visible = True
        Manufacturer.ListBox1.Visible = True
        Manufacturer.btnedit.Visible = True
        Manufacturer.btnexit.Visible = True
        Manufacturer.display()
    End Sub

    Private Sub ListToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListToolStripMenuItem1.Click
        Manufacturer.Show()
        Manufacturer.WindowState = FormWindowState.Maximized
        Manufacturer.Label2.Visible = False
        Manufacturer.ComboBox1.Enabled = False
        Manufacturer.BtnAddSup.Visible = False
        Manufacturer.ListBox1.Visible = True
        Manufacturer.display()
        Manufacturer.btnexit.Visible = True
    End Sub

    Private Sub AddToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem36.Click
        salesbill.Close()
        salesbill.Show()
        salesbill.WindowState = FormWindowState.Maximized
        'salesbill.panelcustomer.Visible = False
        'salesbill.Panel2.Visible = False
        'salesbill.DataGridView1.Visible = False
        'salesbill.GroupBox1.Visible = False
        'salesbill.btnsave.Visible = False
        'salesbill.btnclose.Visible = False

    End Sub


    Private Sub AddToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem39.Click
        salesreturns.Close()
        salesreturns.Show()
        salesreturns.WindowState = FormWindowState.Maximized
        salesreturns.Panel1.Enabled = False
        salesreturns.lbltotal.Visible = False
        salesreturns.Label17.Visible = False
        salesreturns.Panel3.Enabled = False
        salesreturns.Panel2.Enabled = False
        salesreturns.btnadd.Enabled = False
        salesreturns.DataGridView1.Enabled = False
        salesreturns.btnsave.Enabled = False

    End Sub

    Private Sub ListToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem40.Click
        salesreturndisplay.Close()
        salesreturndisplay.Show()
        salesreturndisplay.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub DisplayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem37.Click
        salesdisplay.Close()
        salesdisplay.Show()
        salesdisplay.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub CreateOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem22.Click
        pur_order.Close()
        pur_order.Show()
        pur_order.WindowState = FormWindowState.Maximized
        pur_order.All_Clear()
        pur_order.Panel1.Enabled = False
        pur_order.Panel2.Enabled = False
        pur_order.Panel3.Enabled = False

    End Sub

    Public Sub CancelOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem23.Click
        cancel_order.Close()
        cancel_order.Show()
        cancel_order.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemToolStripMenuItem.Click
        stock.Close()
        stock.Show()
        stock.WindowState = FormWindowState.Maximized
        stock.GroupBox1.Visible = False
        stock.DataGridView1.Visible = False
        stock.GroupBox2.Visible = False
        stock.display()

    End Sub

    Private Sub AddToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem29.Click
        purchasereturn.Close()
        purchasereturn.Show()
        purchasereturn.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub ListToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem30.Click
        purchasereturndisplay.Close()
        purchasereturndisplay.Show()
        purchasereturndisplay.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub AddToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem26.Click
        purchasebilldetail.Close()
        purchasebilldetail.Close()
        purchasebilldetail.Show()
        purchasebilldetail.WindowState = FormWindowState.Maximized

    End Sub
    Private Sub DToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem24.Click

        purchaseordrdisply.Close()
        purchaseordrdisply.Show()
        purchaseordrdisply.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub StockReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem44.Click
        Stockreport.Show()
        Stockreport.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub SalesReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem45.Click
        salesreport.Close()
        salesreport.Show()
        salesreport.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub SalesReturnReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem46.Click
        Salesreturnreport.Close()
        Salesreturnreport.Show()
        Salesreturnreport.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub PurchaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem47.Click
        purchasereport.Close()
        purchasereport.Show()
        purchasereport.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub PurchaseReturnReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem48.Click
        Purchasereturnreport.Close()
        Purchasereturnreport.Show()
        Purchasereturnreport.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub SalaryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem49.Click
        Salaryreport.Close()
        Salaryreport.Show()
        Salaryreport.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub GoodsToReorderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem21.Click
        reorder.Close()
        reorder.Show()
        reorder.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub DisplayToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem27.Click
        Purchasebilldisplay.Close()
        Purchasebilldisplay.Show()
        Purchasebilldisplay.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub AddToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem32.Click
        DamagedItems.Close()
        DamagedItems.Show()
        DamagedItems.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ListToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem33.Click
        DamagedList.Close()
        DamagedList.Show()
        DamagedList.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub HistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistoryToolStripMenuItem.Click
        loginhistroy.Show()
    End Sub
    Private Sub InventoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventoryToolStripMenuItem.Click
        Try
            cnn.Close()
            all_connect()
            cmd.CommandText = "SELECT  * from stock where qty < reorder_level"
            adp.SelectCommand = cmd
            dt = New DataTable
            dt.Clear()
            adp.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim s As String
                s = MsgBox("Few Items has reached-level do you want to add new purchase?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Reorder")
                If s = Windows.Forms.DialogResult.Yes Then
                    reorder.Show()
                    reorder.WindowState = FormWindowState.Maximized
                    Me.Hide()
                Else
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            cnn.Close()
        End Try
    End Sub
End Class