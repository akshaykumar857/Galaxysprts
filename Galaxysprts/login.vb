Public Class login
    Private Sub admin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles admin.Click
        logger.Show()
        logger.TextBox3.Text = "Administrator"
        logger.ForeColor = Color.ForestGreen
        logger.TextBox3.Enabled = False
        logger.txtname.Text = ""
        logger.txtpass.Text = ""

    End Sub

   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub employee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles employee.Click
        logger.Show()
        logger.TextBox3.Text = "Employee"
        logger.ForeColor = Color.ForestGreen
        logger.TextBox3.Enabled = False
        logger.txtname.Text = ""
        logger.txtpass.Text = ""

    End Sub

   
    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    
End Class