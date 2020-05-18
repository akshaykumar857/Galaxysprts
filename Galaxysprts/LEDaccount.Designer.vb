<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LEDaccount
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LEDaccount))
        Me.Groupbox1 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnclear = New System.Windows.Forms.Button
        Me.btnupdate = New System.Windows.Forms.Button
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.txtnpass = New System.Windows.Forms.TextBox
        Me.txtcpass = New System.Windows.Forms.TextBox
        Me.txtusername = New System.Windows.Forms.TextBox
        Me.txtusertype = New System.Windows.Forms.TextBox
        Me.lblnpass = New System.Windows.Forms.Label
        Me.lblcpass = New System.Windows.Forms.Label
        Me.lblname = New System.Windows.Forms.Label
        Me.lbltype = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Btnexit = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Label7 = New System.Windows.Forms.Label
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditUserAccountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteUserAccountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Groupbox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Groupbox1
        '
        Me.Groupbox1.BackColor = System.Drawing.Color.Transparent
        Me.Groupbox1.Controls.Add(Me.Button1)
        Me.Groupbox1.Controls.Add(Me.Label6)
        Me.Groupbox1.Controls.Add(Me.btnclear)
        Me.Groupbox1.Controls.Add(Me.btnupdate)
        Me.Groupbox1.Controls.Add(Me.CheckBox1)
        Me.Groupbox1.Controls.Add(Me.txtnpass)
        Me.Groupbox1.Controls.Add(Me.txtcpass)
        Me.Groupbox1.Controls.Add(Me.txtusername)
        Me.Groupbox1.Controls.Add(Me.txtusertype)
        Me.Groupbox1.Controls.Add(Me.lblnpass)
        Me.Groupbox1.Controls.Add(Me.lblcpass)
        Me.Groupbox1.Controls.Add(Me.lblname)
        Me.Groupbox1.Controls.Add(Me.lbltype)
        Me.Groupbox1.Controls.Add(Me.Label1)
        Me.Groupbox1.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Groupbox1.Location = New System.Drawing.Point(135, 149)
        Me.Groupbox1.Name = "Groupbox1"
        Me.Groupbox1.Size = New System.Drawing.Size(559, 508)
        Me.Groupbox1.TabIndex = 0
        Me.Groupbox1.TabStop = False
        Me.Groupbox1.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Cambria", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(216, 421)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(139, 38)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Cambria", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(307, 326)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 28)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "..."
        Me.Label6.Visible = False
        '
        'btnclear
        '
        Me.btnclear.BackColor = System.Drawing.Color.Transparent
        Me.btnclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnclear.Font = New System.Drawing.Font("Cambria", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclear.ForeColor = System.Drawing.Color.White
        Me.btnclear.Location = New System.Drawing.Point(364, 369)
        Me.btnclear.Name = "btnclear"
        Me.btnclear.Size = New System.Drawing.Size(133, 35)
        Me.btnclear.TabIndex = 11
        Me.btnclear.Text = "Clear"
        Me.btnclear.UseVisualStyleBackColor = False
        '
        'btnupdate
        '
        Me.btnupdate.BackColor = System.Drawing.Color.Transparent
        Me.btnupdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnupdate.Font = New System.Drawing.Font("Cambria", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnupdate.ForeColor = System.Drawing.Color.White
        Me.btnupdate.Location = New System.Drawing.Point(73, 369)
        Me.btnupdate.Name = "btnupdate"
        Me.btnupdate.Size = New System.Drawing.Size(125, 35)
        Me.btnupdate.TabIndex = 10
        Me.btnupdate.Text = "Update"
        Me.btnupdate.UseVisualStyleBackColor = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Cambria", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.White
        Me.CheckBox1.Location = New System.Drawing.Point(312, 240)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(220, 32)
        Me.CheckBox1.TabIndex = 9
        Me.CheckBox1.Text = "Set New password"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'txtnpass
        '
        Me.txtnpass.Font = New System.Drawing.Font("Cambria", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnpass.Location = New System.Drawing.Point(312, 281)
        Me.txtnpass.Name = "txtnpass"
        Me.txtnpass.Size = New System.Drawing.Size(220, 36)
        Me.txtnpass.TabIndex = 8
        Me.txtnpass.Visible = False
        '
        'txtcpass
        '
        Me.txtcpass.Enabled = False
        Me.txtcpass.Font = New System.Drawing.Font("Cambria", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcpass.Location = New System.Drawing.Point(312, 194)
        Me.txtcpass.Name = "txtcpass"
        Me.txtcpass.Size = New System.Drawing.Size(220, 36)
        Me.txtcpass.TabIndex = 7
        '
        'txtusername
        '
        Me.txtusername.Enabled = False
        Me.txtusername.Font = New System.Drawing.Font("Cambria", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtusername.Location = New System.Drawing.Point(312, 136)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Size = New System.Drawing.Size(220, 36)
        Me.txtusername.TabIndex = 6
        '
        'txtusertype
        '
        Me.txtusertype.Enabled = False
        Me.txtusertype.Font = New System.Drawing.Font("Cambria", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtusertype.Location = New System.Drawing.Point(312, 72)
        Me.txtusertype.Name = "txtusertype"
        Me.txtusertype.Size = New System.Drawing.Size(220, 36)
        Me.txtusertype.TabIndex = 5
        '
        'lblnpass
        '
        Me.lblnpass.AutoSize = True
        Me.lblnpass.Font = New System.Drawing.Font("Cambria", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnpass.ForeColor = System.Drawing.Color.White
        Me.lblnpass.Location = New System.Drawing.Point(32, 281)
        Me.lblnpass.Name = "lblnpass"
        Me.lblnpass.Size = New System.Drawing.Size(231, 28)
        Me.lblnpass.TabIndex = 4
        Me.lblnpass.Text = "New Password            :"
        Me.lblnpass.Visible = False
        '
        'lblcpass
        '
        Me.lblcpass.AutoSize = True
        Me.lblcpass.Font = New System.Drawing.Font("Cambria", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcpass.ForeColor = System.Drawing.Color.White
        Me.lblcpass.Location = New System.Drawing.Point(32, 202)
        Me.lblcpass.Name = "lblcpass"
        Me.lblcpass.Size = New System.Drawing.Size(228, 28)
        Me.lblcpass.TabIndex = 3
        Me.lblcpass.Text = "Current password     :"
        '
        'lblname
        '
        Me.lblname.AutoSize = True
        Me.lblname.Font = New System.Drawing.Font("Cambria", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblname.ForeColor = System.Drawing.Color.White
        Me.lblname.Location = New System.Drawing.Point(32, 144)
        Me.lblname.Name = "lblname"
        Me.lblname.Size = New System.Drawing.Size(231, 28)
        Me.lblname.TabIndex = 2
        Me.lblname.Text = "User Name                    :"
        '
        'lbltype
        '
        Me.lbltype.AutoSize = True
        Me.lbltype.Font = New System.Drawing.Font("Cambria", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltype.ForeColor = System.Drawing.Color.White
        Me.lbltype.Location = New System.Drawing.Point(32, 80)
        Me.lbltype.Name = "lbltype"
        Me.lbltype.Size = New System.Drawing.Size(231, 28)
        Me.lbltype.TabIndex = 1
        Me.lbltype.Text = "User Type                      :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(191, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 28)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Edit Account"
        '
        'Btnexit
        '
        Me.Btnexit.BackColor = System.Drawing.Color.Transparent
        Me.Btnexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Btnexit.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnexit.ForeColor = System.Drawing.Color.White
        Me.Btnexit.Location = New System.Drawing.Point(840, 518)
        Me.Btnexit.Name = "Btnexit"
        Me.Btnexit.Size = New System.Drawing.Size(99, 47)
        Me.Btnexit.TabIndex = 12
        Me.Btnexit.Text = "Exit"
        Me.Btnexit.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DataGridView1.Location = New System.Drawing.Point(723, 194)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(291, 285)
        Me.DataGridView1.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(776, 149)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(201, 25)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "List of User Accounts"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditUserAccountToolStripMenuItem, Me.DeleteUserAccountToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(182, 48)
        '
        'EditUserAccountToolStripMenuItem
        '
        Me.EditUserAccountToolStripMenuItem.Name = "EditUserAccountToolStripMenuItem"
        Me.EditUserAccountToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.EditUserAccountToolStripMenuItem.Text = "Edit User Account"
        '
        'DeleteUserAccountToolStripMenuItem
        '
        Me.DeleteUserAccountToolStripMenuItem.Name = "DeleteUserAccountToolStripMenuItem"
        Me.DeleteUserAccountToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.DeleteUserAccountToolStripMenuItem.Text = "Delete User Account"
        '
        'LEDaccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1036, 780)
        Me.Controls.Add(Me.Groupbox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Btnexit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "LEDaccount"
        Me.Text = "LEDaccount"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Groupbox1.ResumeLayout(False)
        Me.Groupbox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Groupbox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtnpass As System.Windows.Forms.TextBox
    Friend WithEvents txtcpass As System.Windows.Forms.TextBox
    Friend WithEvents txtusername As System.Windows.Forms.TextBox
    Friend WithEvents txtusertype As System.Windows.Forms.TextBox
    Friend WithEvents lblnpass As System.Windows.Forms.Label
    Friend WithEvents lblcpass As System.Windows.Forms.Label
    Friend WithEvents lblname As System.Windows.Forms.Label
    Friend WithEvents lbltype As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnclear As System.Windows.Forms.Button
    Friend WithEvents btnupdate As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Btnexit As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditUserAccountToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteUserAccountToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
