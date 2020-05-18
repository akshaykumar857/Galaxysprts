<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class purchasereport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(purchasereport))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.btnclose = New System.Windows.Forms.Button
        Me.btnorder = New System.Windows.Forms.Button
        Me.txtodrerno = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnclos = New System.Windows.Forms.Button
        Me.btnview = New System.Windows.Forms.Button
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.btnclo = New System.Windows.Forms.Button
        Me.btnyearly = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(195, 245)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(636, 259)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.PapayaWhip
        Me.TabPage1.Controls.Add(Me.btnclose)
        Me.TabPage1.Controls.Add(Me.btnorder)
        Me.TabPage1.Controls.Add(Me.txtodrerno)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 31)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(628, 224)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "OrderWise Report"
        '
        'btnclose
        '
        Me.btnclose.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.Location = New System.Drawing.Point(298, 131)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(89, 32)
        Me.btnclose.TabIndex = 3
        Me.btnclose.Text = "Close"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'btnorder
        '
        Me.btnorder.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnorder.Location = New System.Drawing.Point(410, 61)
        Me.btnorder.Name = "btnorder"
        Me.btnorder.Size = New System.Drawing.Size(212, 32)
        Me.btnorder.TabIndex = 2
        Me.btnorder.Text = "View Order Reports"
        Me.btnorder.UseVisualStyleBackColor = True
        '
        'txtodrerno
        '
        Me.txtodrerno.Location = New System.Drawing.Point(215, 63)
        Me.txtodrerno.Name = "txtodrerno"
        Me.txtodrerno.Size = New System.Drawing.Size(114, 30)
        Me.txtodrerno.TabIndex = 1
        Me.txtodrerno.Text = "PO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(86, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Order No."
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.PapayaWhip
        Me.TabPage2.Controls.Add(Me.ComboBox2)
        Me.TabPage2.Controls.Add(Me.ComboBox1)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.btnclos)
        Me.TabPage2.Controls.Add(Me.btnview)
        Me.TabPage2.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 31)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(628, 224)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Monthly Purchase Report"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(394, 50)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(137, 30)
        Me.ComboBox2.TabIndex = 5
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.ComboBox1.Location = New System.Drawing.Point(122, 50)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(137, 30)
        Me.ComboBox1.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(305, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 22)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Year"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 22)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Month"
        '
        'btnclos
        '
        Me.btnclos.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclos.Location = New System.Drawing.Point(366, 146)
        Me.btnclos.Name = "btnclos"
        Me.btnclos.Size = New System.Drawing.Size(91, 30)
        Me.btnclos.TabIndex = 1
        Me.btnclos.Text = "Close"
        Me.btnclos.UseVisualStyleBackColor = True
        '
        'btnview
        '
        Me.btnview.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnview.Location = New System.Drawing.Point(134, 146)
        Me.btnview.Name = "btnview"
        Me.btnview.Size = New System.Drawing.Size(158, 30)
        Me.btnview.TabIndex = 0
        Me.btnview.Text = "View Monthly"
        Me.btnview.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.PapayaWhip
        Me.TabPage3.Controls.Add(Me.ComboBox3)
        Me.TabPage3.Controls.Add(Me.btnclo)
        Me.TabPage3.Controls.Add(Me.btnyearly)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 31)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(628, 224)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Yearly Purchase Report"
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(167, 74)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(140, 30)
        Me.ComboBox3.TabIndex = 3
        '
        'btnclo
        '
        Me.btnclo.Location = New System.Drawing.Point(293, 158)
        Me.btnclo.Name = "btnclo"
        Me.btnclo.Size = New System.Drawing.Size(94, 34)
        Me.btnclo.TabIndex = 2
        Me.btnclo.Text = "Close"
        Me.btnclo.UseVisualStyleBackColor = True
        '
        'btnyearly
        '
        Me.btnyearly.Location = New System.Drawing.Point(358, 68)
        Me.btnyearly.Name = "btnyearly"
        Me.btnyearly.Size = New System.Drawing.Size(195, 34)
        Me.btnyearly.TabIndex = 1
        Me.btnyearly.Text = "View Yearly Report"
        Me.btnyearly.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(70, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 22)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Year"
        '
        'purchasereport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1036, 780)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "purchasereport"
        Me.Text = "purchasereport"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents btnorder As System.Windows.Forms.Button
    Friend WithEvents txtodrerno As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnclos As System.Windows.Forms.Button
    Friend WithEvents btnview As System.Windows.Forms.Button
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents btnclo As System.Windows.Forms.Button
    Friend WithEvents btnyearly As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
