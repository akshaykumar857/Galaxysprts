Public Class damagedqty

    Public qtydamage As Integer = 0


    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = "." Or Char.IsControl(e.KeyChar)) Then
            MsgBox("Enter only numbers...", MsgBoxStyle.Information, "Warning")
            e.Handled = True
            If e.KeyChar = Chr(Keys.Enter) Then
                Me.ProcessTabKey(True)
                Me.btnok.Focus()
            End If
        End If
    End Sub
  
    
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If Me.TextBox1.Text <> "" Then
            Me.Label2.Visible = False
        End If
        If Val(Me.TextBox1.Text) > DamagedItems.qtyrecived Then
            Me.Label2.Visible = True
            Me.Label2.Text = "Damaged Quantity CANNOT be greater" & vbCrLf & " than Received Quantity"
            MsgBox("Damaged Quantity CANNOT be greater than Received Quantity", MsgBoxStyle.Information, "Warning")
            Me.TextBox1.Clear()
        End If
    End Sub
    Private Sub damagedqty_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TextBox1.Focus()
    End Sub

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        If Me.TextBox1.Text = "" Then
            Me.Label2.Visible = True
            Me.Label2.Text = "Please Enter Quantity Damaged"
            Exit Sub
        End If
        Me.qtydamage = Val(Me.TextBox1.Text)
        Me.Hide()
        DamagedItems.abc()
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Close()
    End Sub
End Class
