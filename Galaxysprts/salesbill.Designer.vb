<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class salesbill
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(salesbill))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.panelcustomer = New System.Windows.Forms.Panel
        Me.btnnewc = New System.Windows.Forms.Button
        Me.btnsearch = New System.Windows.Forms.Button
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.txtbillno = New System.Windows.Forms.TextBox
        Me.txtphno = New System.Windows.Forms.TextBox
        Me.txtname = New System.Windows.Forms.TextBox
        Me.combocid = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.btnnew = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.combounits = New System.Windows.Forms.ComboBox
        Me.btnadd = New System.Windows.Forms.Button
        Me.txtamt = New System.Windows.Forms.TextBox
        Me.txtqun = New System.Windows.Forms.TextBox
        Me.txtvat = New System.Windows.Forms.TextBox
        Me.txtprice = New System.Windows.Forms.TextBox
        Me.txtitemname = New System.Windows.Forms.TextBox
        Me.comboiid = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.btncal = New System.Windows.Forms.Button
        Me.lbltotal = New System.Windows.Forms.Label
        Me.txtdiscount = New System.Windows.Forms.TextBox
        Me.txtgtotal = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.btnclose = New System.Windows.Forms.Button
        Me.btnsave = New System.Windows.Forms.Button
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.panelcustomer.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelcustomer
        '
        Me.panelcustomer.BackColor = System.Drawing.Color.Transparent
        Me.panelcustomer.Controls.Add(Me.btnnewc)
        Me.panelcustomer.Controls.Add(Me.btnsearch)
        Me.panelcustomer.Controls.Add(Me.DateTimePicker1)
        Me.panelcustomer.Controls.Add(Me.txtbillno)
        Me.panelcustomer.Controls.Add(Me.txtphno)
        Me.panelcustomer.Controls.Add(Me.txtname)
        Me.panelcustomer.Controls.Add(Me.combocid)
        Me.panelcustomer.Controls.Add(Me.Label5)
        Me.panelcustomer.Controls.Add(Me.Label4)
        Me.panelcustomer.Controls.Add(Me.Label3)
        Me.panelcustomer.Controls.Add(Me.Label2)
        Me.panelcustomer.Controls.Add(Me.Label1)
        Me.panelcustomer.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panelcustomer.Location = New System.Drawing.Point(140, 61)
        Me.panelcustomer.Name = "panelcustomer"
        Me.panelcustomer.Size = New System.Drawing.Size(849, 145)
        Me.panelcustomer.TabIndex = 0
        '
        'btnnewc
        '
        Me.btnnewc.BackColor = System.Drawing.Color.Transparent
        Me.btnnewc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnnewc.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnewc.ForeColor = System.Drawing.Color.Black
        Me.btnnewc.Location = New System.Drawing.Point(365, 91)
        Me.btnnewc.Name = "btnnewc"
        Me.btnnewc.Size = New System.Drawing.Size(171, 32)
        Me.btnnewc.TabIndex = 12
        Me.btnnewc.Text = "New Customer"
        Me.btnnewc.UseVisualStyleBackColor = False
        '
        'btnsearch
        '
        Me.btnsearch.BackColor = System.Drawing.Color.White
        Me.btnsearch.BackgroundImage = CType(resources.GetObject("btnsearch.BackgroundImage"), System.Drawing.Image)
        Me.btnsearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnsearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsearch.Location = New System.Drawing.Point(239, 88)
        Me.btnsearch.Name = "btnsearch"
        Me.btnsearch.Size = New System.Drawing.Size(54, 43)
        Me.btnsearch.TabIndex = 11
        Me.btnsearch.UseVisualStyleBackColor = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(599, 41)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(236, 27)
        Me.DateTimePicker1.TabIndex = 10
        '
        'txtbillno
        '
        Me.txtbillno.BackColor = System.Drawing.Color.White
        Me.txtbillno.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbillno.Location = New System.Drawing.Point(375, 49)
        Me.txtbillno.Name = "txtbillno"
        Me.txtbillno.Size = New System.Drawing.Size(125, 27)
        Me.txtbillno.TabIndex = 9
        '
        'txtphno
        '
        Me.txtphno.BackColor = System.Drawing.Color.White
        Me.txtphno.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtphno.Location = New System.Drawing.Point(376, 15)
        Me.txtphno.Name = "txtphno"
        Me.txtphno.Size = New System.Drawing.Size(125, 27)
        Me.txtphno.TabIndex = 8
        '
        'txtname
        '
        Me.txtname.BackColor = System.Drawing.Color.White
        Me.txtname.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(136, 47)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(139, 27)
        Me.txtname.TabIndex = 7
        '
        'combocid
        '
        Me.combocid.BackColor = System.Drawing.Color.White
        Me.combocid.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combocid.FormattingEnabled = True
        Me.combocid.Location = New System.Drawing.Point(136, 16)
        Me.combocid.Name = "combocid"
        Me.combocid.Size = New System.Drawing.Size(139, 27)
        Me.combocid.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(507, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 22)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Bill Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(283, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 22)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Bill No"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(281, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 22)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Phone No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 22)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Customer ID"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Cambria", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(372, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(109, 28)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Sales Bill"
        '
        'btnnew
        '
        Me.btnnew.BackColor = System.Drawing.Color.Transparent
        Me.btnnew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnnew.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnew.ForeColor = System.Drawing.Color.Black
        Me.btnnew.Location = New System.Drawing.Point(42, 95)
        Me.btnnew.Name = "btnnew"
        Me.btnnew.Size = New System.Drawing.Size(75, 28)
        Me.btnnew.TabIndex = 13
        Me.btnnew.Text = "New"
        Me.btnnew.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.combounits)
        Me.Panel2.Controls.Add(Me.btnadd)
        Me.Panel2.Controls.Add(Me.txtamt)
        Me.Panel2.Controls.Add(Me.txtqun)
        Me.Panel2.Controls.Add(Me.txtvat)
        Me.Panel2.Controls.Add(Me.txtprice)
        Me.Panel2.Controls.Add(Me.txtitemname)
        Me.Panel2.Controls.Add(Me.comboiid)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(63, 236)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(303, 284)
        Me.Panel2.TabIndex = 1
        '
        'combounits
        '
        Me.combounits.BackColor = System.Drawing.Color.White
        Me.combounits.FormattingEnabled = True
        Me.combounits.Location = New System.Drawing.Point(119, 128)
        Me.combounits.Name = "combounits"
        Me.combounits.Size = New System.Drawing.Size(146, 23)
        Me.combounits.TabIndex = 15
        '
        'btnadd
        '
        Me.btnadd.BackColor = System.Drawing.Color.Transparent
        Me.btnadd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnadd.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnadd.ForeColor = System.Drawing.Color.Black
        Me.btnadd.Location = New System.Drawing.Point(93, 238)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(84, 33)
        Me.btnadd.TabIndex = 14
        Me.btnadd.Text = "Add"
        Me.btnadd.UseVisualStyleBackColor = False
        '
        'txtamt
        '
        Me.txtamt.BackColor = System.Drawing.Color.White
        Me.txtamt.Location = New System.Drawing.Point(119, 187)
        Me.txtamt.Name = "txtamt"
        Me.txtamt.Size = New System.Drawing.Size(125, 23)
        Me.txtamt.TabIndex = 13
        '
        'txtqun
        '
        Me.txtqun.BackColor = System.Drawing.Color.White
        Me.txtqun.Location = New System.Drawing.Point(119, 157)
        Me.txtqun.Name = "txtqun"
        Me.txtqun.Size = New System.Drawing.Size(125, 23)
        Me.txtqun.TabIndex = 12
        '
        'txtvat
        '
        Me.txtvat.BackColor = System.Drawing.Color.White
        Me.txtvat.Location = New System.Drawing.Point(119, 100)
        Me.txtvat.Name = "txtvat"
        Me.txtvat.Size = New System.Drawing.Size(125, 23)
        Me.txtvat.TabIndex = 10
        '
        'txtprice
        '
        Me.txtprice.BackColor = System.Drawing.Color.White
        Me.txtprice.Location = New System.Drawing.Point(119, 71)
        Me.txtprice.Name = "txtprice"
        Me.txtprice.Size = New System.Drawing.Size(125, 23)
        Me.txtprice.TabIndex = 9
        '
        'txtitemname
        '
        Me.txtitemname.BackColor = System.Drawing.Color.White
        Me.txtitemname.Location = New System.Drawing.Point(119, 45)
        Me.txtitemname.Name = "txtitemname"
        Me.txtitemname.Size = New System.Drawing.Size(125, 23)
        Me.txtitemname.TabIndex = 8
        '
        'comboiid
        '
        Me.comboiid.BackColor = System.Drawing.Color.White
        Me.comboiid.FormattingEnabled = True
        Me.comboiid.Location = New System.Drawing.Point(118, 16)
        Me.comboiid.Name = "comboiid"
        Me.comboiid.Size = New System.Drawing.Size(146, 23)
        Me.comboiid.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(18, 194)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 22)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Amount"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(18, 164)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 22)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Quantity"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 136)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 22)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Units"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(18, 107)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 22)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Vat"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(18, 78)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 22)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Price"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(18, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 22)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Item Name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(18, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 22)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Item ID"
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.InactiveCaption
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Location = New System.Drawing.Point(399, 252)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(590, 245)
        Me.DataGridView1.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.btncal)
        Me.GroupBox1.Controls.Add(Me.lbltotal)
        Me.GroupBox1.Controls.Add(Me.txtdiscount)
        Me.GroupBox1.Controls.Add(Me.txtgtotal)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(63, 559)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 130)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Total"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Enabled = False
        Me.Label17.Location = New System.Drawing.Point(493, 19)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(22, 22)
        Me.Label17.TabIndex = 7
        Me.Label17.Text = "..."
        Me.Label17.Visible = False
        '
        'btncal
        '
        Me.btncal.BackColor = System.Drawing.Color.Transparent
        Me.btncal.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncal.ForeColor = System.Drawing.Color.Black
        Me.btncal.Location = New System.Drawing.Point(221, 95)
        Me.btncal.Name = "btncal"
        Me.btncal.Size = New System.Drawing.Size(121, 29)
        Me.btncal.TabIndex = 6
        Me.btncal.Text = "Calculate"
        Me.btncal.UseVisualStyleBackColor = False
        '
        'lbltotal
        '
        Me.lbltotal.AutoSize = True
        Me.lbltotal.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotal.Location = New System.Drawing.Point(120, 26)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(18, 22)
        Me.lbltotal.TabIndex = 5
        Me.lbltotal.Text = ".."
        '
        'txtdiscount
        '
        Me.txtdiscount.BackColor = System.Drawing.Color.White
        Me.txtdiscount.Location = New System.Drawing.Point(314, 19)
        Me.txtdiscount.Name = "txtdiscount"
        Me.txtdiscount.Size = New System.Drawing.Size(133, 30)
        Me.txtdiscount.TabIndex = 4
        '
        'txtgtotal
        '
        Me.txtgtotal.BackColor = System.Drawing.Color.White
        Me.txtgtotal.Location = New System.Drawing.Point(289, 59)
        Me.txtgtotal.Name = "txtgtotal"
        Me.txtgtotal.Size = New System.Drawing.Size(136, 30)
        Me.txtgtotal.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(158, 64)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(112, 22)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Grand Total"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(193, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(98, 22)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Discount : "
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(43, 26)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 22)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Total"
        '
        'btnclose
        '
        Me.btnclose.BackColor = System.Drawing.Color.Transparent
        Me.btnclose.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.ForeColor = System.Drawing.Color.Black
        Me.btnclose.Location = New System.Drawing.Point(828, 618)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(75, 34)
        Me.btnclose.TabIndex = 5
        Me.btnclose.Text = "Close"
        Me.btnclose.UseVisualStyleBackColor = False
        '
        'btnsave
        '
        Me.btnsave.BackColor = System.Drawing.Color.Transparent
        Me.btnsave.Font = New System.Drawing.Font("Cambria", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.ForeColor = System.Drawing.Color.Black
        Me.btnsave.Location = New System.Drawing.Point(711, 618)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 34)
        Me.btnsave.TabIndex = 6
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 26)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'salesbill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1028, 712)
        Me.Controls.Add(Me.btnnew)
        Me.Controls.Add(Me.panelcustomer)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.Label13)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "salesbill"
        Me.Text = "salesbill"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.panelcustomer.ResumeLayout(False)
        Me.panelcustomer.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents panelcustomer As System.Windows.Forms.Panel
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtbillno As System.Windows.Forms.TextBox
    Friend WithEvents txtphno As System.Windows.Forms.TextBox
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents combocid As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnnew As System.Windows.Forms.Button
    Friend WithEvents btnnewc As System.Windows.Forms.Button
    Friend WithEvents btnsearch As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnadd As System.Windows.Forms.Button
    Friend WithEvents txtamt As System.Windows.Forms.TextBox
    Friend WithEvents txtqun As System.Windows.Forms.TextBox
    Friend WithEvents txtvat As System.Windows.Forms.TextBox
    Friend WithEvents txtprice As System.Windows.Forms.TextBox
    Friend WithEvents txtitemname As System.Windows.Forms.TextBox
    Friend WithEvents comboiid As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btncal As System.Windows.Forms.Button
    Friend WithEvents lbltotal As System.Windows.Forms.Label
    Friend WithEvents txtdiscount As System.Windows.Forms.TextBox
    Friend WithEvents txtgtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents combounits As System.Windows.Forms.ComboBox
End Class
