<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(login))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.admin = New System.Windows.Forms.PictureBox
        Me.employee = New System.Windows.Forms.PictureBox
        Me.Panel1.SuspendLayout()
        CType(Me.admin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.employee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.admin)
        Me.Panel1.Controls.Add(Me.employee)
        Me.Panel1.Location = New System.Drawing.Point(167, 60)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(720, 489)
        Me.Panel1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Cambria", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(89, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 37)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "ADMIN"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Cambria", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(445, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(171, 37)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "EMPLOYEE"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Font = New System.Drawing.Font("Cambria", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(252, 430)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(145, 55)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "EXIT"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'admin
        '
        Me.admin.BackColor = System.Drawing.Color.Transparent
        Me.admin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.admin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.admin.Image = CType(resources.GetObject("admin.Image"), System.Drawing.Image)
        Me.admin.Location = New System.Drawing.Point(18, 154)
        Me.admin.Name = "admin"
        Me.admin.Size = New System.Drawing.Size(245, 229)
        Me.admin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.admin.TabIndex = 0
        Me.admin.TabStop = False
        '
        'employee
        '
        Me.employee.BackColor = System.Drawing.Color.Transparent
        Me.employee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.employee.Cursor = System.Windows.Forms.Cursors.Hand
        Me.employee.Image = CType(resources.GetObject("employee.Image"), System.Drawing.Image)
        Me.employee.Location = New System.Drawing.Point(417, 154)
        Me.employee.Name = "employee"
        Me.employee.Size = New System.Drawing.Size(264, 229)
        Me.employee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.employee.TabIndex = 1
        Me.employee.TabStop = False
        '
        'login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(980, 525)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "login"
        Me.Text = "login"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.admin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.employee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents admin As System.Windows.Forms.PictureBox
    Friend WithEvents employee As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
