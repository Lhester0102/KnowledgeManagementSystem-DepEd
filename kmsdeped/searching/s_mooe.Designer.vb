<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class s_mooe
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.sy = New System.Windows.Forms.ComboBox()
        Me.sname = New System.Windows.Forms.ComboBox()
        Me.division = New System.Windows.Forms.ComboBox()
        Me.regional = New System.Windows.Forms.ComboBox()
        Me.soption = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea2.AxisX.Interval = 1.0R
        ChartArea2.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend2)
        Me.Chart1.Location = New System.Drawing.Point(5, 93)
        Me.Chart1.Name = "Chart1"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "ES Enrollees"
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(998, 406)
        Me.Chart1.TabIndex = 46
        Me.Chart1.Text = "Chart1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(2, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 16)
        Me.Label7.TabIndex = 45
        Me.Label7.Text = "Search By"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(902, 56)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 35)
        Me.Button1.TabIndex = 44
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(584, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 16)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "School Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(379, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Division"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(181, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 16)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Region"
        '
        'sy
        '
        Me.sy.FormattingEnabled = True
        Me.sy.Items.AddRange(New Object() {"region", "province", "division", "district", "municipality", "school_name"})
        Me.sy.Location = New System.Drawing.Point(22, 93)
        Me.sy.Name = "sy"
        Me.sy.Size = New System.Drawing.Size(164, 21)
        Me.sy.TabIndex = 37
        '
        'sname
        '
        Me.sname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sname.FormattingEnabled = True
        Me.sname.Location = New System.Drawing.Point(587, 62)
        Me.sname.Name = "sname"
        Me.sname.Size = New System.Drawing.Size(309, 24)
        Me.sname.TabIndex = 35
        '
        'division
        '
        Me.division.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.division.FormattingEnabled = True
        Me.division.Location = New System.Drawing.Point(382, 62)
        Me.division.Name = "division"
        Me.division.Size = New System.Drawing.Size(199, 24)
        Me.division.TabIndex = 32
        '
        'regional
        '
        Me.regional.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regional.FormattingEnabled = True
        Me.regional.Location = New System.Drawing.Point(175, 62)
        Me.regional.Name = "regional"
        Me.regional.Size = New System.Drawing.Size(199, 24)
        Me.regional.TabIndex = 31
        '
        'soption
        '
        Me.soption.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.soption.FormattingEnabled = True
        Me.soption.Items.AddRange(New Object() {"region", "division", "school_name", "specific_school"})
        Me.soption.Location = New System.Drawing.Point(5, 62)
        Me.soption.Name = "soption"
        Me.soption.Size = New System.Drawing.Size(164, 24)
        Me.soption.TabIndex = 30
        '
        'Label10
        '
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(0, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(1010, 37)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "MOOE OF ELEMENTARY"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        's_mooe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1010, 509)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.sy)
        Me.Controls.Add(Me.sname)
        Me.Controls.Add(Me.division)
        Me.Controls.Add(Me.regional)
        Me.Controls.Add(Me.soption)
        Me.Name = "s_mooe"
        Me.Text = "ELEMENTARY MOOE"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents sy As System.Windows.Forms.ComboBox
    Friend WithEvents sname As System.Windows.Forms.ComboBox
    Friend WithEvents division As System.Windows.Forms.ComboBox
    Friend WithEvents regional As System.Windows.Forms.ComboBox
    Friend WithEvents soption As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
