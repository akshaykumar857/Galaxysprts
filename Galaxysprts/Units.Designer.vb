<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Units
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Units))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtunit = New System.Windows.Forms.TextBox
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.btnupdate = New System.Windows.Forms.Button
        Me.btnedit = New System.Windows.Forms.Button
        Me.btnexit = New System.Windows.Forms.Button
        Me.btnadd = New System.Windows.Forms.Button
        Me.btnclose = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Cambria", 26.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(451, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 41)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Units"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Cambria", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(323, 187)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 32)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Unit"
        '
        'txtunit
        '
        Me.txtunit.BackColor = System.Drawing.Color.White
        Me.txtunit.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtunit.Location = New System.Drawing.Point(456, 184)
        Me.txtunit.Name = "txtunit"
        Me.txtunit.Size = New System.Drawing.Size(134, 32)
        Me.txtunit.TabIndex = 2
        Me.txtunit.Visible = False
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.Color.White
        Me.ListBox1.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 22
        Me.ListBox1.Location = New System.Drawing.Point(349, 259)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(305, 268)
        Me.ListBox1.TabIndex = 3
        Me.ListBox1.Visible = False
        '
        'btnupdate
        '
        Me.btnupdate.BackColor = System.Drawing.Color.Transparent
        Me.btnupdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnupdate.Font = New System.Drawing.Font("Cambria", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnupdate.ForeColor = System.Drawing.Color.White
        Me.btnupdate.Location = New System.Drawing.Point(686, 366)
        Me.btnupdate.Name = "btnupdate"
        Me.btnupdate.Size = New System.Drawing.Size(119, 40)
        Me.btnupdate.TabIndex = 4
        Me.btnupdate.Text = "Update"
        Me.btnupdate.UseVisualStyleBackColor = False
        Me.btnupdate.Visible = False
        '
        'btnedit
        '
        Me.btnedit.BackColor = System.Drawing.Color.Transparent
        Me.btnedit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnedit.Font = New System.Drawing.Font("Cambria", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnedit.ForeColor = System.Drawing.Color.White
        Me.btnedit.Location = New System.Drawing.Point(389, 549)
        Me.btnedit.Name = "btnedit"
        Me.btnedit.Size = New System.Drawing.Size(80, 45)
        Me.btnedit.TabIndex = 5
        Me.btnedit.Text = "Edit"
        Me.btnedit.UseVisualStyleBackColor = False
        Me.btnedit.Visible = False
        '
        'btnexit
        '
        Me.btnexit.BackColor = System.Drawing.Color.Transparent
        Me.btnexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnexit.Font = New System.Drawing.Font("Cambria", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.ForeColor = System.Drawing.Color.White
        Me.btnexit.Location = New System.Drawing.Point(522, 549)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(80, 45)
        Me.btnexit.TabIndex = 6
        Me.btnexit.Text = "Exit"
        Me.btnexit.UseVisualStyleBackColor = False
        Me.btnexit.Visible = False
        '
        'btnadd
        '
        Me.btnadd.BackColor = System.Drawing.Color.Transparent
        Me.btnadd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnadd.Font = New System.Drawing.Font("Cambria", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnadd.ForeColor = System.Drawing.Color.White
        Me.btnadd.Location = New System.Drawing.Point(324, 279)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(81, 39)
        Me.btnadd.TabIndex = 7
        Me.btnadd.Text = "Add"
        Me.btnadd.UseVisualStyleBackColor = False
        Me.btnadd.Visible = False
        '
        'btnclose
        '
        Me.btnclose.BackColor = System.Drawing.Color.Transparent
        Me.btnclose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnclose.Font = New System.Drawing.Font("Cambria", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.ForeColor = System.Drawing.Color.White
        Me.btnclose.Location = New System.Drawing.Point(458, 279)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(97, 39)
        Me.btnclose.TabIndex = 8
        Me.btnclose.Text = "Close"
        Me.btnclose.UseVisualStyleBackColor = False
        Me.btnclose.Visible = False
        '
        'Units
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlText
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(987, 596)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.btnadd)
        Me.Controls.Add(Me.btnexit)
        Me.Controls.Add(Me.btnedit)
        Me.Controls.Add(Me.btnupdate)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.txtunit)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.ForeColor = System.Drawing.Color.Red
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Units"
        Me.Text = "Units"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtunit As System.Windows.Forms.TextBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents btnupdate As System.Windows.Forms.Button
    Friend WithEvents btnedit As System.Windows.Forms.Button
    Friend WithEvents btnexit As System.Windows.Forms.Button
    Friend WithEvents btnadd As System.Windows.Forms.Button
    Friend WithEvents btnclose As System.Windows.Forms.Button
End Class
