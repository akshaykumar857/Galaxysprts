<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Stockreport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Stockreport))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.btnall = New System.Windows.Forms.Button
        Me.btnclose = New System.Windows.Forms.Button
        Me.btnshow = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnrecords = New System.Windows.Forms.Button
        Me.btnclos = New System.Windows.Forms.Button
        Me.btnshw = New System.Windows.Forms.Button
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(218, 207)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(601, 314)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.PapayaWhip
        Me.TabPage1.Controls.Add(Me.btnall)
        Me.TabPage1.Controls.Add(Me.btnclose)
        Me.TabPage1.Controls.Add(Me.btnshow)
        Me.TabPage1.Controls.Add(Me.ComboBox1)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 31)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(593, 279)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Brand Wise"
        '
        'btnall
        '
        Me.btnall.BackColor = System.Drawing.Color.White
        Me.btnall.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnall.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnall.Location = New System.Drawing.Point(378, 185)
        Me.btnall.Name = "btnall"
        Me.btnall.Size = New System.Drawing.Size(152, 41)
        Me.btnall.TabIndex = 5
        Me.btnall.Text = "All Records"
        Me.btnall.UseVisualStyleBackColor = False
        '
        'btnclose
        '
        Me.btnclose.BackColor = System.Drawing.Color.White
        Me.btnclose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnclose.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.Location = New System.Drawing.Point(255, 185)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(97, 41)
        Me.btnclose.TabIndex = 4
        Me.btnclose.Text = "Close"
        Me.btnclose.UseVisualStyleBackColor = False
        '
        'btnshow
        '
        Me.btnshow.BackColor = System.Drawing.Color.White
        Me.btnshow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnshow.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnshow.Location = New System.Drawing.Point(113, 185)
        Me.btnshow.Name = "btnshow"
        Me.btnshow.Size = New System.Drawing.Size(97, 41)
        Me.btnshow.TabIndex = 3
        Me.btnshow.Text = "Show"
        Me.btnshow.UseVisualStyleBackColor = False
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.White
        Me.ComboBox1.Font = New System.Drawing.Font("Cambria", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(266, 88)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(180, 30)
        Me.ComboBox1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(108, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Select Brand"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(175, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(322, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Stock Report Brand Wise"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.PapayaWhip
        Me.TabPage2.Controls.Add(Me.ComboBox2)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.btnrecords)
        Me.TabPage2.Controls.Add(Me.btnclos)
        Me.TabPage2.Controls.Add(Me.btnshw)
        Me.TabPage2.Location = New System.Drawing.Point(4, 31)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(593, 279)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Group Wise"
        '
        'ComboBox2
        '
        Me.ComboBox2.BackColor = System.Drawing.Color.White
        Me.ComboBox2.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(305, 88)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(191, 33)
        Me.ComboBox2.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Cambria", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(101, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 25)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Select Group"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(192, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(322, 32)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Stock Report Group Wise"
        '
        'btnrecords
        '
        Me.btnrecords.BackColor = System.Drawing.Color.White
        Me.btnrecords.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnrecords.Font = New System.Drawing.Font("Cambria", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrecords.Location = New System.Drawing.Point(359, 191)
        Me.btnrecords.Name = "btnrecords"
        Me.btnrecords.Size = New System.Drawing.Size(154, 31)
        Me.btnrecords.TabIndex = 2
        Me.btnrecords.Text = "All records"
        Me.btnrecords.UseVisualStyleBackColor = False
        '
        'btnclos
        '
        Me.btnclos.BackColor = System.Drawing.Color.White
        Me.btnclos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnclos.Font = New System.Drawing.Font("Cambria", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclos.Location = New System.Drawing.Point(252, 191)
        Me.btnclos.Name = "btnclos"
        Me.btnclos.Size = New System.Drawing.Size(83, 31)
        Me.btnclos.TabIndex = 1
        Me.btnclos.Text = "Close"
        Me.btnclos.UseVisualStyleBackColor = False
        '
        'btnshw
        '
        Me.btnshw.BackColor = System.Drawing.Color.White
        Me.btnshw.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnshw.Font = New System.Drawing.Font("Cambria", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnshw.Location = New System.Drawing.Point(122, 191)
        Me.btnshw.Name = "btnshw"
        Me.btnshw.Size = New System.Drawing.Size(100, 31)
        Me.btnshw.TabIndex = 0
        Me.btnshw.Text = "Show"
        Me.btnshw.UseVisualStyleBackColor = False
        '
        'Stockreport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(806, 578)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Stockreport"
        Me.Text = "Stockreport"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents btnall As System.Windows.Forms.Button
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents btnshow As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnrecords As System.Windows.Forms.Button
    Friend WithEvents btnclos As System.Windows.Forms.Button
    Friend WithEvents btnshw As System.Windows.Forms.Button
End Class
