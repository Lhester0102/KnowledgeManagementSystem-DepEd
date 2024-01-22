Imports MySql.Data.MySqlClient
Public Class graph_water
    Sub load_sy()
        ComboBox2.Items.Clear()
        ComboBox2.Items.Add("All Regions")
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT distinct region from water order by region"
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                ComboBox2.Items.Add(READER.GetString("region").ToString)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub loadwater_elem()
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String = ""
            Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
            query = "SELECT region,sum(local_piped) as 'lp',sum(well_warter_deep_well) as 'dw' ,sum(rain_warer_cathment) as 'rwc' ,sum(natural_source) as 'ns',sum(without_available_water_supply) as 'waws', school_year FROM depedkms.water where school_type='ELEMENTARY' group by region,school_year order by region,school_year "
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                Chart1.Series("local pipe").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("lp"))
                Chart1.Series("deep well").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("dw"))
                Chart1.Series("rain water").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("rwc"))
                Chart1.Series("natural source").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("ns"))
                Chart1.Series("no available water supply").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("waws"))
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
    End Sub
    Sub loadwater_elem2()

        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String = ""
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT region,sum(local_piped) as 'lp',sum(well_warter_deep_well) as 'dw' ,sum(rain_warer_cathment) as 'rwc' ,sum(natural_source) as 'ns',sum(without_available_water_supply) as 'waws', school_year FROM depedkms.water where region='" & ComboBox2.Text & "' and school_type='ELEMENTARY' group by region,school_year order by region,school_year "

            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart1.Series("local pipe").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("lp"))
                Chart1.Series("deep well").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("dw"))
                Chart1.Series("rain water").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("rwc"))
                Chart1.Series("natural source").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("ns"))
                Chart1.Series("no available water supply").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("waws"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub loadwater2()
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String = ""
            Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
                query = "SELECT region,sum(local_piped) as 'lp',sum(well_warter_deep_well) as 'dw' ,sum(rain_warer_cathment) as 'rwc' ,sum(natural_source) as 'ns',sum(without_available_water_supply) as 'waws', school_year FROM depedkms.water where  school_type='HIGHSCHOOL' group by region,school_year order by region,school_year "
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                Chart2.Series("local pipe").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("lp"))
                Chart2.Series("deep well").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("dw"))
                Chart2.Series("rain water").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("rwc"))
                Chart2.Series("natural source").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("ns"))
                Chart2.Series("no available water supply").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("waws"))
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
    End Sub

    Sub loadwater4()
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String = ""
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT region,sum(local_piped) as 'lp',sum(well_warter_deep_well) as 'dw' ,sum(rain_warer_cathment) as 'rwc' ,sum(natural_source) as 'ns',sum(without_available_water_supply) as 'waws', school_year FROM depedkms.water where region='" & ComboBox2.Text & "' and school_type='HIGHSCHOOL' group by region,school_year order by region,school_year "

            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart2.Series("local pipe").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("lp"))
                Chart2.Series("deep well").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("dw"))
                Chart2.Series("rain water").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("rwc"))
                Chart2.Series("natural source").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("ns"))
                Chart2.Series("no available water supply").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("waws"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub graph_water_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chart1.Series.Clear()
        Chart2.Series.Clear()
        Chart1.Series.Add("local pipe")
        Chart1.Series.Add("deep well")
        Chart1.Series.Add("rain water")
        Chart1.Series.Add("natural source")
        Chart1.Series.Add("no available water supply")

        Chart2.Series.Add("local pipe")
        Chart2.Series.Add("deep well")
        Chart2.Series.Add("rain water")
        Chart2.Series.Add("natural source")
        Chart2.Series.Add("no available water supply")
        '    Chart2.Series.Add("HIGHSCHOOL")
        Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Chart1.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Chart1.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Chart1.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Chart1.Series(4).ChartType = DataVisualization.Charting.SeriesChartType.Bar

        Chart2.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Chart2.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Chart2.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Chart2.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Chart2.Series(4).ChartType = DataVisualization.Charting.SeriesChartType.Bar
        load_sy()
    
        loadwater_elem()
        loadwater2()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "All Regions" Then
            Chart1.ResetAutoValues()
            Chart2.ResetAutoValues()
            Chart1.Series.Clear()
            Chart2.Series.Clear()
            Chart1.Series.Add("local pipe")
            Chart1.Series.Add("deep well")
            Chart1.Series.Add("rain water")
            Chart1.Series.Add("natural source")
            Chart1.Series.Add("no available water supply")

            Chart2.Series.Add("local pipe")
            Chart2.Series.Add("deep well")
            Chart2.Series.Add("rain water")
            Chart2.Series.Add("natural source")
            Chart2.Series.Add("no available water supply")
            '    Chart2.Series.Add("HIGHSCHOOL")
            Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series(4).ChartType = DataVisualization.Charting.SeriesChartType.Bar

            Chart2.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series(4).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            loadwater_elem()
            loadwater2()
        Else
            Chart1.ResetAutoValues()
            Chart2.ResetAutoValues()
            Chart1.Series.Clear()
            Chart2.Series.Clear()
            Chart1.Series.Add("local pipe")
            Chart1.Series.Add("deep well")
            Chart1.Series.Add("rain water")
            Chart1.Series.Add("natural source")
            Chart1.Series.Add("no available water supply")

            Chart2.Series.Add("local pipe")
            Chart2.Series.Add("deep well")
            Chart2.Series.Add("rain water")
            Chart2.Series.Add("natural source")
            Chart2.Series.Add("no available water supply")
            '    Chart2.Series.Add("HIGHSCHOOL")
            Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series(4).ChartType = DataVisualization.Charting.SeriesChartType.Bar

            Chart2.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series(4).ChartType = DataVisualization.Charting.SeriesChartType.Bar

            Chart1.Series("local pipe").IsValueShownAsLabel = True
            Chart1.Series("deep well").IsValueShownAsLabel = True
            Chart1.Series("rain water").IsValueShownAsLabel = True
            Chart1.Series("natural source").IsValueShownAsLabel = True
            Chart1.Series("no available water supply").IsValueShownAsLabel = True

            Chart2.Series("local pipe").IsValueShownAsLabel = True
            Chart2.Series("deep well").IsValueShownAsLabel = True
            Chart2.Series("rain water").IsValueShownAsLabel = True
            Chart2.Series("natural source").IsValueShownAsLabel = True
            Chart2.Series("no available water supply").IsValueShownAsLabel = True

            loadwater_elem2()
            loadwater4()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Line" Then
            Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart1.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart1.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart1.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart1.Series(4).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Chart2.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart2.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart2.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart2.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart2.Series(4).ChartType = DataVisualization.Charting.SeriesChartType.Line
        ElseIf ComboBox1.Text = "Bar" Then
            Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series(4).ChartType = DataVisualization.Charting.SeriesChartType.Bar

            Chart2.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series(4).ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Else
            Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart1.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart1.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart1.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart1.Series(4).ChartType = DataVisualization.Charting.SeriesChartType.Column

            Chart2.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart2.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart2.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart2.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart2.Series(4).ChartType = DataVisualization.Charting.SeriesChartType.Column
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class