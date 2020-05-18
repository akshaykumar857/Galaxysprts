<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class createaccount
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(createaccount))
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Txtusername = New System.Windows.Forms.TextBox
        Me.CheckBox4 = New System.Windows.Forms.CheckBox
        Me.txtconfirmpass = New System.Windows.Forms.TextBox
        Me.txtpass = New System.Windows.Forms.TextBox
        Me.txtusertype = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btncreate = New System.Windows.Forms.Button
        Me.btnclose = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Cambria", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(281, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(186, 32)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "New Employee"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Txtusername)
        Me.GroupBox1.Controls.Add(Me.CheckBox4)
        Me.GroupBox1.Controls.Add(Me.txtconfirmpass)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtpass)
        Me.GroupBox1.Controls.Add(Me.txtusertype)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btncreate)
        Me.GroupBox1.Controls.Add(Me.btnclose)
        Me.GroupBox1.Font = New System.Drawing.Font("Cambria", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(161, 144)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(728, 430)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'Txtusername
        '
        Me.Txtusername.BackColor = System.Drawing.Color.Black
        Me.Txtusername.Font = New System.Drawing.Font("Cambria", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtusername.ForeColor = System.Drawing.Color.White
        Me.Txtusername.Location = New System.Drawing.Point(363, 128)
        Me.Txtusername.Name = "Txtusername"
        Me.Txtusername.Size = New System.Drawing.Size(284, 39)
        Me.Txtusername.TabIndex = 11
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox4.Font = New System.Drawing.Font("Cambria", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox4.ForeColor = System.Drawing.Color.White
        Me.CheckBox4.Location = New System.Drawing.Point(376, 289)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(215, 36)
        Me.CheckBox4.TabIndex = 10
        Me.CheckBox4.Text = "Show Password"
        Me.CheckBox4.UseVisualStyleBackColor = False
        '
        'txtconfirmpass
        '
        Me.txtconfirmpass.BackColor = System.Drawing.Color.Black
        Me.txtconfirmpass.Enabled = False
        Me.txtconfirmpass.Font = New System.Drawing.Font("Cambria", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtconfirmpass.ForeColor = System.Drawing.Color.White
        Me.txtconfirmpass.Location = New System.Drawing.Point(363, 224)
        Me.txtconfirmpass.Name = "txtconfirmpass"
        Me.txtconfirmpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtconfirmpass.Size = New System.Drawing.Size(282, 39)
        Me.txtconfirmpass.TabIndex = 9
        '
        'txtpass
        '
        Me.txtpass.BackColor = System.Drawing.Color.Black
        Me.txtpass.Enabled = False
        Me.txtpass.Font = New System.Drawing.Font("Cambria", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpass.ForeColor = System.Drawing.Color.White
        Me.txtpass.Location = New System.Drawing.Point(363, 177)
        Me.txtpass.Name = "txtpass"
        Me.txtpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpass.Size = New System.Drawing.Size(284, 39)
        Me.txtpass.TabIndex = 8
        '
        'txtusertype
        '
        Me.txtusertype.BackColor = System.Drawing.Color.Black
        Me.txtusertype.Font = New System.Drawing.Font("Cambria", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtusertype.ForeColor = System.Drawing.Color.White
        Me.txtusertype.Location = New System.Drawing.Point(363, 78)
        Me.txtusertype.Name = "txtusertype"
        Me.txtusertype.Size = New System.Drawing.Size(284, 39)
        Me.txtusertype.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Cambria", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(41, 224)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(263, 32)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Confirm Password     :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(39, 177)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(272, 32)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Password                       :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(39, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(268, 32)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "UserName                     :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(39, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(271, 32)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "UserType                       :"
        '
        'btncreate
        '
        Me.btncreate.BackColor = System.Drawing.Color.Transparent
        Me.btncreate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncreate.Font = New System.Drawing.Font("Cambria", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncreate.ForeColor = System.Drawing.Color.Red
        Me.btncreate.Location = New System.Drawing.Point(68, 358)
        Me.btncreate.Name = "btncreate"
        Me.btncreate.Size = New System.Drawing.Size(250, 41)
        Me.btncreate.TabIndex = 0
        Me.btncreate.Text = "Create Account"
        Me.btncreate.UseVisualStyleBackColor = False
        '
        'btnclose
        '
        Me.btnclose.BackColor = System.Drawing.Color.Transparent
        Me.btnclose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnclose.Font = New System.Drawing.Font("Cambria", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.ForeColor = System.Drawing.Color.Red
        Me.btnclose.Location = New System.Drawing.Point(451, 358)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(177, 41)
        Me.btnclose.TabIndex = 1
        Me.btnclose.Text = "Close"
        Me.btnclose.UseVisualStyleBackColor = False
        '
        'createaccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1001, 535)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "createaccount"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtconfirmpass As System.Windows.Forms.TextBox
    Friend WithEvents txtpass As System.Windows.Forms.TextBox
    Friend WithEvents txtusertype As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btncreate As System.Windows.Forms.Button
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents Txtusername As System.Windows.Forms.TextBox
End Class
