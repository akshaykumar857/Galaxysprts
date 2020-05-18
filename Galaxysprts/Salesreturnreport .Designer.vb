<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Salesreturnreport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Salesreturnreport))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.btnclose = New System.Windows.Forms.Button
        Me.btnshow = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.btncls = New System.Windows.Forms.Button
        Me.btnshw = New System.Windows.Forms.Button
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.btnclos = New System.Windows.Forms.Button
        Me.btnsh = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.ComboBox4 = New System.Windows.Forms.ComboBox
        Me.btncl = New System.Windows.Forms.Button
        Me.btns = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(222, 194)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(593, 295)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.PapayaWhip
        Me.TabPage1.Controls.Add(Me.DateTimePicker1)
        Me.TabPage1.Controls.Add(Me.btnclose)
        Me.TabPage1.Controls.Add(Me.btnshow)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 31)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(585, 260)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Day Wise"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(233, 73)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(309, 30)
        Me.DateTimePicker1.TabIndex = 5
        '
        'btnclose
        '
        Me.btnclose.BackColor = System.Drawing.Color.White
        Me.btnclose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnclose.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.Location = New System.Drawing.Point(300, 159)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(78, 33)
        Me.btnclose.TabIndex = 3
        Me.btnclose.Text = "Close"
        Me.btnclose.UseVisualStyleBackColor = False
        '
        'btnshow
        '
        Me.btnshow.BackColor = System.Drawing.Color.White
        Me.btnshow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnshow.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnshow.Location = New System.Drawing.Point(160, 159)
        Me.btnshow.Name = "btnshow"
        Me.btnshow.Size = New System.Drawing.Size(78, 33)
        Me.btnshow.TabIndex = 2
        Me.btnshow.Text = "Show"
        Me.btnshow.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(85, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 22)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Sales Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(105, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(311, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sales Return Report Date Wise"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.PapayaWhip
        Me.TabPage2.Controls.Add(Me.btncls)
        Me.TabPage2.Controls.Add(Me.btnshw)
        Me.TabPage2.Controls.Add(Me.ComboBox2)
        Me.TabPage2.Controls.Add(Me.ComboBox1)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 31)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(585, 260)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Month Wise"
        '
        'btncls
        '
        Me.btncls.BackColor = System.Drawing.Color.White
        Me.btncls.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncls.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncls.Location = New System.Drawing.Point(369, 163)
        Me.btncls.Name = "btncls"
        Me.btncls.Size = New System.Drawing.Size(75, 33)
        Me.btncls.TabIndex = 6
        Me.btncls.Text = "Close"
        Me.btncls.UseVisualStyleBackColor = False
        '
        'btnshw
        '
        Me.btnshw.BackColor = System.Drawing.Color.White
        Me.btnshw.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnshw.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnshw.Location = New System.Drawing.Point(199, 163)
        Me.btnshw.Name = "btnshw"
        Me.btnshw.Size = New System.Drawing.Size(75, 33)
        Me.btnshw.TabIndex = 5
        Me.btnshw.Text = "Show"
        Me.btnshw.UseVisualStyleBackColor = False
        '
        'ComboBox2
        '
        Me.ComboBox2.BackColor = System.Drawing.Color.White
        Me.ComboBox2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.ComboBox2.Location = New System.Drawing.Point(137, 80)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(150, 27)
        Me.ComboBox2.TabIndex = 4
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.White
        Me.ComboBox1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(421, 80)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(152, 27)
        Me.ComboBox1.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(313, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 22)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Select Year"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 22)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Select Month"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(146, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(330, 25)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Sales Return Report Month Wise"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.PapayaWhip
        Me.TabPage3.Controls.Add(Me.ComboBox3)
        Me.TabPage3.Controls.Add(Me.btnclos)
        Me.TabPage3.Controls.Add(Me.btnsh)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Location = New System.Drawing.Point(4, 31)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(585, 260)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Year Wise"
        '
        'ComboBox3
        '
        Me.ComboBox3.BackColor = System.Drawing.Color.White
        Me.ComboBox3.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(260, 96)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(157, 27)
        Me.ComboBox3.TabIndex = 4
        '
        'btnclos
        '
        Me.btnclos.BackColor = System.Drawing.Color.White
        Me.btnclos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnclos.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclos.Location = New System.Drawing.Point(287, 179)
        Me.btnclos.Name = "btnclos"
        Me.btnclos.Size = New System.Drawing.Size(82, 33)
        Me.btnclos.TabIndex = 3
        Me.btnclos.Text = "Close"
        Me.btnclos.UseVisualStyleBackColor = False
        '
        'btnsh
        '
        Me.btnsh.BackColor = System.Drawing.Color.White
        Me.btnsh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsh.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsh.Location = New System.Drawing.Point(140, 179)
        Me.btnsh.Name = "btnsh"
        Me.btnsh.Size = New System.Drawing.Size(82, 33)
        Me.btnsh.TabIndex = 2
        Me.btnsh.Text = "Show"
        Me.btnsh.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(80, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 22)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Select Year"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(108, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(309, 25)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Sales Return Report Year Wise"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.PapayaWhip
        Me.TabPage4.Controls.Add(Me.ComboBox4)
        Me.TabPage4.Controls.Add(Me.btncl)
        Me.TabPage4.Controls.Add(Me.btns)
        Me.TabPage4.Controls.Add(Me.Label9)
        Me.TabPage4.Controls.Add(Me.Label8)
        Me.TabPage4.Location = New System.Drawing.Point(4, 31)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(585, 260)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Return No. Wise"
        '
        'ComboBox4
        '
        Me.ComboBox4.BackColor = System.Drawing.Color.White
        Me.ComboBox4.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(277, 81)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(168, 27)
        Me.ComboBox4.TabIndex = 4
        '
        'btncl
        '
        Me.btncl.BackColor = System.Drawing.Color.White
        Me.btncl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncl.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncl.Location = New System.Drawing.Point(345, 168)
        Me.btncl.Name = "btncl"
        Me.btncl.Size = New System.Drawing.Size(85, 35)
        Me.btncl.TabIndex = 3
        Me.btncl.Text = "Close"
        Me.btncl.UseVisualStyleBackColor = False
        '
        'btns
        '
        Me.btns.BackColor = System.Drawing.Color.White
        Me.btns.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btns.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btns.Location = New System.Drawing.Point(181, 168)
        Me.btns.Name = "btns"
        Me.btns.Size = New System.Drawing.Size(85, 35)
        Me.btns.TabIndex = 2
        Me.btns.Text = "Show"
        Me.btns.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(68, 86)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(150, 22)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Select Return No"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Cambria", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(128, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(335, 25)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Sales Return Report Bill No. Wise"
        '
        'Salesreturnreport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(943, 568)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Salesreturnreport"
        Me.Text = "Salesreturnreport"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents btnshow As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents btncls As System.Windows.Forms.Button
    Friend WithEvents btnshw As System.Windows.Forms.Button
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents btnclos As System.Windows.Forms.Button
    Friend WithEvents btnsh As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents btncl As System.Windows.Forms.Button
    Friend WithEvents btns As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
End Class
