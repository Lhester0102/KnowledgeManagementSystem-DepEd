﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class s_ernrollment_es
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.sname = New System.Windows.Forms.ComboBox()
        Me.province = New System.Windows.Forms.ComboBox()
        Me.municipality = New System.Windows.Forms.ComboBox()
        Me.division = New System.Windows.Forms.ComboBox()
        Me.regional = New System.Windows.Forms.ComboBox()
        Me.soption = New System.Windows.Forms.ComboBox()
        Me.district = New System.Windows.Forms.ComboBox()
        Me.sy = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'sname
        '
        Me.sname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sname.FormattingEnabled = True
        Me.sname.Location = New System.Drawing.Point(684, 106)
        Me.sname.Name = "sname"
        Me.sname.Size = New System.Drawing.Size(241, 24)
        Me.sname.TabIndex = 17
        '
        'province
        '
        Me.province.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.province.FormattingEnabled = True
        Me.province.Location = New System.Drawing.Point(425, 66)
        Me.province.Name = "province"
        Me.province.Size = New System.Drawing.Size(253, 24)
        Me.province.TabIndex = 16
        '
        'municipality
        '
        Me.municipality.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.municipality.FormattingEnabled = True
        Me.municipality.Location = New System.Drawing.Point(425, 106)
        Me.municipality.Name = "municipality"
        Me.municipality.Size = New System.Drawing.Size(253, 24)
        Me.municipality.TabIndex = 15
        '
        'division
        '
        Me.division.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.division.FormattingEnabled = True
        Me.division.Location = New System.Drawing.Point(684, 66)
        Me.division.Name = "division"
        Me.division.Size = New System.Drawing.Size(241, 24)
        Me.division.TabIndex = 14
        '
        'regional
        '
        Me.regional.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.regional.FormattingEnabled = True
        Me.regional.Location = New System.Drawing.Point(173, 66)
        Me.regional.Name = "regional"
        Me.regional.Size = New System.Drawing.Size(243, 24)
        Me.regional.TabIndex = 13
        '
        'soption
        '
        Me.soption.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.soption.FormattingEnabled = True
        Me.soption.Items.AddRange(New Object() {"region", "province", "division", "district", "municipality", "school_name", "specific_school"})
        Me.soption.Location = New System.Drawing.Point(3, 66)
        Me.soption.Name = "soption"
        Me.soption.Size = New System.Drawing.Size(164, 24)
        Me.soption.TabIndex = 12
        '
        'district
        '
        Me.district.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.district.FormattingEnabled = True
        Me.district.Location = New System.Drawing.Point(173, 106)
        Me.district.Name = "district"
        Me.district.Size = New System.Drawing.Size(243, 24)
        Me.district.TabIndex = 18
        '
        'sy
        '
        Me.sy.FormattingEnabled = True
        Me.sy.Items.AddRange(New Object() {"region", "province", "division", "district", "municipality", "school_name"})
        Me.sy.Location = New System.Drawing.Point(3, 146)
        Me.sy.Name = "sy"
        Me.sy.Size = New System.Drawing.Size(164, 21)
        Me.sy.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(170, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 16)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Region"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(422, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 16)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Province"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(684, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Division"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(170, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "District"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(422, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 16)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Municipality"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(684, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 16)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "School Name"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(931, 66)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(125, 64)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(0, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 16)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Search By"
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea1.AxisX.Interval = 1.0R
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(3, 137)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "ES Enrollees"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(1053, 360)
        Me.Chart1.TabIndex = 29
        Me.Chart1.Text = "Chart1"
        '
        'Label10
        '
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(0, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(1059, 37)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "ENROLLEES IN ELEMENTARY"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        's_ernrollment_es
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1059, 501)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.sy)
        Me.Controls.Add(Me.district)
        Me.Controls.Add(Me.sname)
        Me.Controls.Add(Me.province)
        Me.Controls.Add(Me.municipality)
        Me.Controls.Add(Me.division)
        Me.Controls.Add(Me.regional)
        Me.Controls.Add(Me.soption)
        Me.Name = "s_ernrollment_es"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ELEMENTARY ENROLLMENT"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents sname As System.Windows.Forms.ComboBox
    Friend WithEvents province As System.Windows.Forms.ComboBox
    Friend WithEvents municipality As System.Windows.Forms.ComboBox
    Friend WithEvents division As System.Windows.Forms.ComboBox
    Friend WithEvents regional As System.Windows.Forms.ComboBox
    Friend WithEvents soption As System.Windows.Forms.ComboBox
    Friend WithEvents district As System.Windows.Forms.ComboBox
    Friend WithEvents sy As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
