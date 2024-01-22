Imports MySql.Data.MySqlClient
Public Class graph_rooms
    Sub load_sy()
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
            query = "SELECT distinct region from rooms_i order by region"
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                ComboBox1.Items.Add(READER.GetString("region").ToString)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub load_in()
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String = ""
            Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
            query = "SELECT region,sum(total_instructional_room) as 'total',school_year,school_type FROM depedkms.rooms_i where  school_type='ELEMENTARY' group by region,school_year order by region,school_year "
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read

                Chart1.Series("ES").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("total"))

                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
    End Sub

    Sub load_in2()
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String = ""
            Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
                query = "SELECT region,sum(total_instructional_room) as 'total',school_year,school_type FROM depedkms.rooms_i where  school_type='HIGHSCHOOL' group by region,school_year order by region,school_year "
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                    Chart1.Series("SS").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("total"))
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
    End Sub
    Sub load_non()
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String = ""
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try

            query = "SELECT region,sum(total_non_instructional_room) as 'total',school_year,school_type FROM depedkms.rooms_ni where school_type='HIGHSCHOOL' group by region,school_year order by region,school_year "
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart2.Series("SS NON").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("total"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub load_non2()
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String = ""
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try

            query = "SELECT region,sum(total_non_instructional_room) as 'total',school_year,school_type FROM depedkms.rooms_ni where  school_type='ELEMENTARY' group by region,school_year order by region,school_year "
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read

                Chart2.Series("ES NON").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("total"))

            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub graph_mooe_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chart1.Series.Clear()
        Chart2.Series.Clear()
        chart1.Series.Clear()
        chart2.Series.Clear()
        Chart1.Series.Add("ES")
        Chart2.Series.Add("ES NON")
        chart1.Series.Add("SS")
        chart2.Series.Add("SS NON")
        Chart1.Series("ES").ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Chart2.Series("ES NON").ChartType = DataVisualization.Charting.SeriesChartType.Bar
        chart1.Series("SS").ChartType = DataVisualization.Charting.SeriesChartType.Bar
        chart2.Series("SS NON").ChartType = DataVisualization.Charting.SeriesChartType.Bar
        load_sy()
        load_in()
        load_in2()
        load_non()
        load_non2()
    End Sub
    Sub load_in3()
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String = ""
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT region,sum(total_instructional_room) as 'total',school_year,school_type FROM depedkms.rooms_i where region='" & ComboBox1.Text & "' and  school_type='ELEMENTARY' group by region,school_year order by region,school_year "
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read

                Chart1.Series("ES").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("total"))

            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub load_in23()
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String = ""
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT region,sum(total_instructional_room) as 'total',school_year,school_type FROM depedkms.rooms_i where region='" & ComboBox1.Text & "' and  school_type='HIGHSCHOOL' group by region,school_year order by region,school_year "
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart1.Series("SS").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("total"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub load_non3()
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String = ""
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try

            query = "SELECT region,sum(total_non_instructional_room) as 'total',school_year,school_type FROM depedkms.rooms_ni where region='" & ComboBox1.Text & "' and school_type='HIGHSCHOOL' group by region,school_year order by region,school_year "
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart2.Series("SS NON").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("total"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub load_non23()
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String = ""
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try

            query = "SELECT region,sum(total_non_instructional_room) as 'total',school_year,school_type FROM depedkms.rooms_ni where region='" & ComboBox1.Text & "' and  school_type='ELEMENTARY' group by region,school_year order by region,school_year "
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read

                Chart2.Series("ES NON").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("total"))

            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "All Regions" Then
            Chart1.Series.Clear()
            Chart2.Series.Clear()
            Chart1.Series.Clear()
            Chart2.Series.Clear()
            Chart1.Series.Add("ES")
            Chart2.Series.Add("ES NON")
            Chart1.Series.Add("SS")
            Chart2.Series.Add("SS NON")
            Chart1.Series("ES").ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series("ES NON").ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series("SS").ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series("SS NON").ChartType = DataVisualization.Charting.SeriesChartType.Bar

            Chart1.Series("ES").IsValueShownAsLabel = True
            Chart2.Series("ES NON").IsValueShownAsLabel = True
            Chart1.Series("SS").IsValueShownAsLabel = True
            Chart2.Series("SS NON").IsValueShownAsLabel = True
            load_in()
            load_in2()
            load_non()
            load_non2()
        Else
            Chart1.ResetAutoValues()
            Chart2.ResetAutoValues()
            Chart1.Series.Clear()
            Chart2.Series.Clear()
            Chart1.Series.Clear()
            Chart2.Series.Clear()
            Chart1.Series.Add("ES")
            Chart2.Series.Add("ES NON")
            Chart1.Series.Add("SS")
            Chart2.Series.Add("SS NON")
            Chart1.Series("ES").ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series("ES NON").ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series("SS").ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series("SS NON").ChartType = DataVisualization.Charting.SeriesChartType.Bar

            Chart1.Series("ES").IsValueShownAsLabel = True
            Chart2.Series("ES NON").IsValueShownAsLabel = True
            Chart1.Series("SS").IsValueShownAsLabel = True
            Chart2.Series("SS NON").IsValueShownAsLabel = True
            load_in3()
            load_in23()
            load_non3()
            load_non23()
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "Line" Then
            Chart1.Series("ES").ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart2.Series("ES NON").ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart1.Series("SS").ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart2.Series("SS NON").ChartType = DataVisualization.Charting.SeriesChartType.Line
        ElseIf ComboBox2.Text = "Bar" Then
            Chart1.Series("ES").ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series("ES NON").ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series("SS").ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series("SS NON").ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Else
            Chart1.Series("ES").ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart2.Series("ES NON").ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart1.Series("SS").ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart2.Series("SS NON").ChartType = DataVisualization.Charting.SeriesChartType.Column
        End If
    End Sub
End Class