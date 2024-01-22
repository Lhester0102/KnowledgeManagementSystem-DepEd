Imports MySql.Data.MySqlClient

Public Class enrolment_pie
    Dim k, g1, g2, g3, g4, g5, g6, sped As Double
    Dim y1, y2, y3, y4, h_sped, g11, g12 As Double
    Dim all_e_total As Double
    Dim all_h_total As Double
    Dim e_query As String = ""
    Dim h_query As String = ""
    Dim all_e_query As String = ""
    Dim all_h_query As String = ""
    Sub load_all_e()
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try

            conn.Open()
            com = New MySqlCommand(all_e_query, conn)
            READER = com.ExecuteReader
            While READER.Read
                all_e_total = READER.GetDouble("total")
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub load_all_h()
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try

            conn.Open()
            com = New MySqlCommand(all_h_query, conn)
            READER = com.ExecuteReader
            While READER.Read
                all_h_total = READER.GetDouble("total")
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub loadregions()
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("All Regions")
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT distinct region from enrollment order by region"
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                ComboBox1.Items.Add(READER.GetString("region").ToString())
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub loadsy()
        ComboBox2.Items.Clear()
        ComboBox3.Items.Clear()
        '        ComboBox2.Items.Add("All Regions")
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT distinct school_year from enrollment order by school_year"
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                ComboBox2.Items.Add(READER.GetString("school_year").ToString())
                ComboBox3.Items.Add(READER.GetString("school_year").ToString())
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub load_e()
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            conn.Open()
            com = New MySqlCommand(e_query, conn)
            READER = com.ExecuteReader
            While READER.Read
                k = READER.GetInt32(2)
                g1 = READER.GetInt32(3)
                g2 = READER.GetInt32(4)
                g3 = READER.GetInt32(5)
                g4 = READER.GetInt32(6)
                g5 = READER.GetInt32(7)
                g6 = READER.GetInt32(8)
                sped = READER.GetInt32(9)
            End While
            
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        TextBox1.Text = (k / all_e_total) * 100
        TextBox2.Text = (g1 / all_e_total) * 100
        TextBox3.Text = (g2 / all_e_total) * 100
        TextBox4.Text = (g3 / all_e_total) * 100
        TextBox5.Text = (g4 / all_e_total) * 100
        TextBox6.Text = (g5 / all_e_total) * 100
        TextBox7.Text = (g6 / all_e_total) * 100
        TextBox8.Text = (sped / all_e_total) * 100
        If Val(TextBox1.Text) <= 0 Then
            TextBox1.Text = "0.00"
        End If
        If Val(TextBox2.Text) <= 0 Then
            TextBox2.Text = "0.00"
        End If
        If Val(TextBox3.Text) <= 0 Then
            TextBox3.Text = "0.00"
        End If
        If Val(TextBox4.Text) <= 0 Then
            TextBox4.Text = "0.00"
        End If
        If Val(TextBox5.Text) <= 0 Then
            TextBox5.Text = "0.00"
        End If
        If Val(TextBox6.Text) <= 0 Then
            TextBox6.Text = "0.00"
        End If
        If Val(TextBox7.Text) <= 0 Then
            TextBox7.Text = "0.00"
        End If
        If Val(TextBox8.Text) <= 0 Then
            TextBox8.Text = "0.00"
        End If

        Dim strr, strr2, strr3, strr4, strr5, strr6, strr7, strr8 As String
        strr = ""
        strr2 = ""
        strr3 = ""
        strr4 = ""
        strr5 = ""
        strr6 = ""
        strr7 = ""
        strr8 = ""
        For x = 0 To 3

            strr = strr + TextBox1.Text.ElementAt(x)
            k = Val(strr)

            strr2 = strr2 + TextBox2.Text.ElementAt(x)
            g1 = Val(strr2)

            strr3 = strr3 + TextBox3.Text.ElementAt(x)
            g2 = Val(strr3)

            strr4 = strr4 + TextBox4.Text.ElementAt(x)
            g3 = Val(strr4)

            strr5 = strr5 + TextBox5.Text.ElementAt(x)
            g4 = Val(strr5)

            strr6 = strr6 + TextBox6.Text.ElementAt(x)
            g5 = Val(strr6)

            strr7 = strr7 + TextBox7.Text.ElementAt(x)
            g6 = Val(strr7)

            strr8 = strr8 + TextBox8.Text.ElementAt(x)
            sped = Val(strr8)
        Next
    End Sub
    Sub load_h()
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
             conn.Open()
            com = New MySqlCommand(h_query, conn)
            READER = com.ExecuteReader
            While READER.Read
                y1 = READER.GetInt32(2)
                y2 = READER.GetInt32(3)
                y3 = READER.GetInt32(4)
                y4 = READER.GetInt32(5)
                h_sped = READER.GetInt32(6)
                g11 = READER.GetInt32(7)
                g12 = READER.GetInt32(8)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        TextBox9.Text = (y1 / all_h_total) * 100
        TextBox10.Text = (y2 / all_h_total) * 100
        TextBox11.Text = (y3 / all_h_total) * 100
        TextBox12.Text = (y4 / all_h_total) * 100
        TextBox13.Text = (h_sped / all_h_total) * 100
        TextBox14.Text = (g11 / all_h_total) * 100
        TextBox15.Text = (g12 / all_h_total) * 100

        If Val(TextBox15.Text) <= 0 Then
            TextBox15.Text = "0.00"
        End If
        If Val(TextBox14.Text) <= 0 Then
            TextBox14.Text = "0.00"
        End If
        If Val(TextBox13.Text) <= 0 Then
            TextBox13.Text = "0.00"
        End If
        If Val(TextBox12.Text) <= 0 Then
            TextBox12.Text = "0.00"
        End If
        If Val(TextBox11.Text) <= 0 Then
            TextBox11.Text = "0.00"
        End If
        If Val(TextBox10.Text) <= 0 Then
            TextBox10.Text = "0.00"
        End If
        If Val(TextBox9.Text) <= 0 Then
            TextBox9.Text = "0.00"
        End If
        Dim strr8, strr2, strr3, strr4, strr5, str11, str12 As String
        strr2 = ""
        strr3 = ""
        strr4 = ""
        strr5 = ""
        strr8 = ""
        str11 = ""
        str12 = ""
        For x = 0 To 3
            strr2 = strr2 + TextBox9.Text.ElementAt(x)
            y1 = Val(strr2)

            strr3 = strr3 + TextBox10.Text.ElementAt(x)
            y2 = Val(strr3)

            strr4 = strr4 + TextBox11.Text.ElementAt(x)
            y3 = Val(strr4)

            strr5 = strr5 + TextBox12.Text.ElementAt(x)
            y4 = Val(strr5)

            str11 = str11 + TextBox14.Text.ElementAt(x)
            g11 = Val(str11)

            str12 = str12 + TextBox15.Text.ElementAt(x)
            g12 = Val(str12)
            strr8 = strr8 + TextBox13.Text.ElementAt(x)
            h_sped = Val(strr8)
        Next
    End Sub

    Private Sub enrolment_pie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        all_e_query = "SELECT sum(grand_total) as 'total' from enrollment"
        load_all_e()
        all_h_query = "SELECT sum(grandtotal) as 'total' from highschool"
        load_all_h()
        loadregions()
        loadsy()
        Chart1.Series.Clear()
        Chart1.ResetAutoValues()
        Chart1.Series.Add("Kinder")
        Chart1.Series.Add("Grade1")
        Chart1.Series.Add("Grade2")
        Chart1.Series.Add("Grade3")
        Chart1.Series.Add("Grade4")
        Chart1.Series.Add("Grade5")
        Chart1.Series.Add("Grade6")
        Chart1.Series.Add("Sped")
        Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Chart1.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Chart1.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Chart1.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Chart1.Series(4).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Chart1.Series(5).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Chart1.Series(6).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Chart1.Series(7).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        e_query = "SELECT region,school_year,sum(kinder_total) as 'kt',sum(grade1_total) as 'g1',sum(grade2_total) as 'g2',sum(grade3_total) as 'g3',sum(grade4_total) as 'g4',sum(grade5_total) as 'g5',sum(grade6_total) as 'g6', sum(sped_total) as 'sped' from enrollment"
        load_e()
        Chart1.Series(0).Points.AddXY("Kinder" & " " & k & " %", k)
        Chart1.Series(0).Points.AddXY("Grade1" & " " & g1 & " %", g1)
        Chart1.Series(0).Points.AddXY("Grade2" & " " & g2 & " %", g2)
        Chart1.Series(0).Points.AddXY("Grade3" & " " & g3 & " %", g3)
        Chart1.Series(0).Points.AddXY("Grade4" & " " & g4 & " %", g4)
        Chart1.Series(0).Points.AddXY("Grade5" & " " & g5 & " %", g5)
        Chart1.Series(0).Points.AddXY("Grade6" & " " & g6 & " %", g6)
        Chart1.Series(0).Points.AddXY("Sped" & " " & sped & " %", sped)



        Chart2.Series.Clear()
        Chart2.ResetAutoValues()
        Chart2.Series.Add("Grade 7")
        Chart2.Series.Add("Grade 8")
        Chart2.Series.Add("Grade 9")
        Chart2.Series.Add("Grade 10")
        Chart2.Series.Add("Grade 11")
        Chart2.Series.Add("Grade 12")
        Chart2.Series.Add("Sped")
        Chart2.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Chart2.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Chart2.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Chart2.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Chart2.Series(4).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Chart2.Series(5).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Chart2.Series(6).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        h_query = "SELECT region,school_year, sum(year1_total) as 'y1', sum(year2_total) as 'y2', sum(year3_total) as 'y3', sum(year4_total) as 'y4' , sum(sped_total) as 'sped',sum(g11_total) ,sum(g12_total) from highschool"
        load_h()
        Chart2.Series(0).Points.AddXY("Grade 7" & " " & y1 & " %", y1)
        Chart2.Series(0).Points.AddXY("Grade 8" & " " & y2 & " %", y2)
        Chart2.Series(0).Points.AddXY("Grade 9" & " " & y3 & " %", y3)
        Chart2.Series(0).Points.AddXY("Grade 10" & " " & y4 & " %", y4)
        Chart2.Series(0).Points.AddXY("Grade 11" & " " & g11 & " %", g11)
        Chart2.Series(0).Points.AddXY("Grade 12" & " " & g12 & " %", g12)
        Chart2.Series(0).Points.AddXY("Sped" & " " & h_sped & " %", h_sped)

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        all_e_query = "SELECT sum(grand_total) as 'total' from enrollment where school_year='" & ComboBox3.Text & "' and region='" & ComboBox1.Text & "'"
            load_all_e()
            all_h_query = "SELECT sum(grandtotal) as 'total' from highschool where school_year='" & ComboBox3.Text & "' and region='" & ComboBox1.Text & "'"
            load_all_h()
            ' loadregions()
            '  loadsy()
            Chart1.Series.Clear()
            Chart1.ResetAutoValues()
            Chart1.Series.Add("Kinder")
            Chart1.Series.Add("Grade1")
            Chart1.Series.Add("Grade2")
            Chart1.Series.Add("Grade3")
            Chart1.Series.Add("Grade4")
            Chart1.Series.Add("Grade5")
            Chart1.Series.Add("Grade6")
            Chart1.Series.Add("Sped")
            Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart1.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart1.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart1.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart1.Series(4).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart1.Series(5).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart1.Series(6).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart1.Series(7).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            e_query = "SELECT region,school_year,sum(kinder_total) as 'kt',sum(grade1_total) as 'g1',sum(grade2_total) as 'g2',sum(grade3_total) as 'g3',sum(grade4_total) as 'g4',sum(grade5_total) as 'g5',sum(grade6_total) as 'g6', sum(sped_total) as 'sped' from enrollment where school_year='" & ComboBox3.Text & "' and region='" & ComboBox1.Text & "'"
            load_e()
            Chart1.Series(0).Points.AddXY("Kinder" & " " & k & " %", k)
            Chart1.Series(0).Points.AddXY("Grade1" & " " & g1 & " %", g1)
            Chart1.Series(0).Points.AddXY("Grade2" & " " & g2 & " %", g2)
            Chart1.Series(0).Points.AddXY("Grade3" & " " & g3 & " %", g3)
            Chart1.Series(0).Points.AddXY("Grade4" & " " & g4 & " %", g4)
            Chart1.Series(0).Points.AddXY("Grade5" & " " & g5 & " %", g5)
            Chart1.Series(0).Points.AddXY("Grade6" & " " & g6 & " %", g6)
            Chart1.Series(0).Points.AddXY("Sped" & " " & sped & " %", sped)



            Chart2.Series.Clear()
            Chart2.ResetAutoValues()
            Chart2.Series.Add("Grade 7")
            Chart2.Series.Add("Grade 8")
            Chart2.Series.Add("Grade 9")
        Chart2.Series.Add("Grade 10")
        Chart2.Series.Add("Grade 11")
        Chart2.Series.Add("Grade 12")
            Chart2.Series.Add("Sped")
            Chart2.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart2.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart2.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart2.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Chart2.Series(4).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Chart2.Series(5).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Chart2.Series(6).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        h_query = "SELECT region,school_year, sum(year1_total) as 'y1', sum(year2_total) as 'y2', sum(year3_total) as 'y3', sum(year4_total) as 'y4' , sum(sped_total) as 'sped',sum(g11_total) ,sum(g12_total) from highschool where school_year='" & ComboBox3.Text & "' and region='" & ComboBox1.Text & "'"
            load_h()
            Chart2.Series(0).Points.AddXY("Grade 7" & " " & y1 & " %", y1)
            Chart2.Series(0).Points.AddXY("Grade 8" & " " & y2 & " %", y2)
            Chart2.Series(0).Points.AddXY("Grade 9" & " " & y3 & " %", y3)
        Chart2.Series(0).Points.AddXY("Grade 10" & " " & y4 & " %", y4)
        Chart2.Series(0).Points.AddXY("Grade 11" & " " & g11 & " %", g11)
        Chart2.Series(0).Points.AddXY("Grade 12" & " " & g12 & " %", g12)
            Chart2.Series(0).Points.AddXY("Sped" & " " & h_sped & " %", h_sped)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "All Regions" Then
            all_e_query = "SELECT sum(grand_total) as 'total' from enrollment"
            load_all_e()
            all_h_query = "SELECT sum(grandtotal) as 'total' from highschool"
            load_all_h()
            loadregions()
            loadsy()
            Chart1.Series.Clear()
            Chart1.ResetAutoValues()
            Chart1.Series.Add("Kinder")
            Chart1.Series.Add("Grade1")
            Chart1.Series.Add("Grade2")
            Chart1.Series.Add("Grade3")
            Chart1.Series.Add("Grade4")
            Chart1.Series.Add("Grade5")
            Chart1.Series.Add("Grade6")
            Chart1.Series.Add("Sped")
            Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart1.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart1.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart1.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart1.Series(4).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart1.Series(5).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart1.Series(6).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart1.Series(7).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            e_query = "SELECT region,school_year,sum(kinder_total) as 'kt',sum(grade1_total) as 'g1',sum(grade2_total) as 'g2',sum(grade3_total) as 'g3',sum(grade4_total) as 'g4',sum(grade5_total) as 'g5',sum(grade6_total) as 'g6', sum(sped_total) as 'sped' from enrollment"
            load_e()
            Chart1.Series(0).Points.AddXY("Kinder" & " " & k & " %", k)
            Chart1.Series(0).Points.AddXY("Grade1" & " " & g1 & " %", g1)
            Chart1.Series(0).Points.AddXY("Grade2" & " " & g2 & " %", g2)
            Chart1.Series(0).Points.AddXY("Grade3" & " " & g3 & " %", g3)
            Chart1.Series(0).Points.AddXY("Grade4" & " " & g4 & " %", g4)
            Chart1.Series(0).Points.AddXY("Grade5" & " " & g5 & " %", g5)
            Chart1.Series(0).Points.AddXY("Grade6" & " " & g6 & " %", g6)
            Chart1.Series(0).Points.AddXY("Sped" & " " & sped & " %", sped)



            Chart2.Series.Clear()
            Chart2.ResetAutoValues()
            Chart2.Series.Add("Grade 7")
            Chart2.Series.Add("Grade 8")
            Chart2.Series.Add("Grade 9")
            Chart2.Series.Add("Grade 10")
            Chart2.Series.Add("Grade 11")
            Chart2.Series.Add("Grade 12")
            Chart2.Series.Add("Sped")
            Chart2.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart2.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart2.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart2.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart2.Series(4).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart2.Series(5).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart2.Series(6).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            h_query = "SELECT region,school_year, sum(year1_total) as 'y1', sum(year2_total) as 'y2', sum(year3_total) as 'y3', sum(year4_total) as 'y4' , sum(sped_total) as 'sped',sum(g11_total) ,sum(g12_total) from highschool"
            load_h()
            Chart2.Series(0).Points.AddXY("Grade 7" & " " & y1 & " %", y1)
            Chart2.Series(0).Points.AddXY("Grade 8" & " " & y2 & " %", y2)
            Chart2.Series(0).Points.AddXY("Grade 9" & " " & y3 & " %", y3)
            Chart2.Series(0).Points.AddXY("Grade 10" & " " & y4 & " %", y4)
            Chart2.Series(0).Points.AddXY("Grade 11" & " " & g11 & " %", g11)
            Chart2.Series(0).Points.AddXY("Grade 12" & " " & g12 & " %", g12)
            Chart2.Series(0).Points.AddXY("Sped" & " " & h_sped & " %", h_sped)

        End If
    End Sub
End Class