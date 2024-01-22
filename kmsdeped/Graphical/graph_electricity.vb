Imports MySql.Data.MySqlClient
Public Class graph_electricity
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
            query = "SELECT distinct region from electricity order by region"
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                ComboBox1.Items.Add(READER.GetString("region").ToString)
                ComboBox2.Items.Add(READER.GetString("region").ToString)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub loadelectricity_elem()
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String = ""
            Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
                query = "SELECT region,sum(grid_supply) as 'grid',sum(generator) as 'generator' ,sum(solar_power) as 'solar' ,sum(no_electricity) as 'no', school_year FROM depedkms.electricity where school_type='ELEMENTARY' group by region,school_year order by region,school_year "
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                    Chart1.Series("Grid Supply").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, Val(READER.GetString("grid")))
                    Chart1.Series("Generator").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, Val(READER.GetString("generator")))
                    Chart1.Series("Solar").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, Val(READER.GetString("solar")))
                    Chart1.Series("No Electricity").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, Val(READER.GetString("no")))
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
    End Sub
    Sub loadelectricity_elem2()

        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String = ""
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT region,sum(grid_supply) as 'grid',sum(generator) as 'generator' ,sum(solar_power) as 'solar' ,sum(no_electricity) as 'no', school_year FROM depedkms.electricity where region='" & ComboBox2.Text & "' and school_type='ELEMENTARY' group by region,school_year order by school_year "

            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart1.Series("Grid Supply").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("grid"))
                Chart1.Series("Generator").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("generator"))
                Chart1.Series("Solar").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("solar"))
                Chart1.Series("No Electricity").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("no"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub loadelectricity2()
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String = ""
            Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
            query = "SELECT region,sum(grid_supply) as 'grid',sum(generator) as 'generator' ,sum(solar_power) as 'solar' ,sum(no_electricity) as 'no', school_year FROM depedkms.electricity where  school_type='HIGHSCHOOL' group by region,school_year order by region,school_year "

                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                Chart2.Series("Grid Supply").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("grid"))
                Chart2.Series("Generator").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("generator"))
                Chart2.Series("Solar").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("solar"))
                Chart2.Series("No Electricity").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("no"))
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
    End Sub

    Sub loadelectricity4()

        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String = ""
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT region,sum(grid_supply) as 'grid',sum(generator) as 'generator' ,sum(solar_power) as 'solar' ,sum(no_electricity) as 'no', school_year FROM depedkms.electricity where region='" & ComboBox2.Text & "' and school_type='HIGHSCHOOL' group by school_year order by school_year  "

            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart2.Series("Grid Supply").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("grid"))
                Chart2.Series("Generator").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("generator"))
                Chart2.Series("Solar").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("solar"))
                Chart2.Series("No Electricity").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("no"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub graph_electricity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chart1.Series.Clear()
        Chart2.Series.Clear()
        Chart1.Series.Add("Grid Supply")
        Chart1.Series.Add("Generator")
        Chart1.Series.Add("Solar")
        Chart1.Series.Add("No Electricity")

        Chart2.Series.Add("Grid Supply")
        Chart2.Series.Add("Generator")
        Chart2.Series.Add("Solar")
        Chart2.Series.Add("No Electricity")
        Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Chart1.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Chart1.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Chart1.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Bar

        Chart2.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Chart2.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Chart2.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Chart2.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Bar

        load_sy()
        loadelectricity_elem()
        loadelectricity2()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "All Regions" Then
            Chart1.Series.Clear()
            Chart2.Series.Clear()
            Chart1.Series.Add("Grid Supply")
            Chart1.Series.Add("Generator")
            Chart1.Series.Add("Solar")
            Chart1.Series.Add("No Electricity")

            Chart2.Series.Add("Grid Supply")
            Chart2.Series.Add("Generator")
            Chart2.Series.Add("Solar")
            Chart2.Series.Add("No Electricity")
            Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Bar

            Chart2.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            loadelectricity_elem()
            loadelectricity2()
        Else
            Chart1.ResetAutoValues()
            Chart2.ResetAutoValues()
            Chart1.Series.Clear()
            Chart2.Series.Clear()
            Chart1.Series.Add("Grid Supply")
            Chart1.Series.Add("Generator")
            Chart1.Series.Add("Solar")

            Chart1.Series.Add("No Electricity")
            Chart2.Series.Add("Grid Supply")
            Chart2.Series.Add("Generator")
            Chart2.Series.Add("Solar")
            Chart2.Series.Add("No Electricity")
            '    Chart2.Series.Add("HIGHSCHOOL")
            Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Bar

            Chart2.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series("Grid Supply").IsValueShownAsLabel = True
            Chart1.Series("Generator").IsValueShownAsLabel = True
            Chart1.Series("Solar").IsValueShownAsLabel = True
            Chart1.Series("No Electricity").IsValueShownAsLabel = True

            Chart2.Series("Grid Supply").IsValueShownAsLabel = True
            Chart2.Series("Generator").IsValueShownAsLabel = True
            Chart2.Series("Solar").IsValueShownAsLabel = True
            Chart2.Series("No Electricity").IsValueShownAsLabel = True
            loadelectricity_elem2()
            loadelectricity4()
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.Text = "Line" Then
            Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart1.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart1.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart1.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Line

            Chart2.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart2.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart2.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart2.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Line

        ElseIf ComboBox3.Text = "Bar" Then
            Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Bar

            Chart2.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart2.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Else
            Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart1.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart1.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart1.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Column

            Chart2.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart2.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart2.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart2.Series(3).ChartType = DataVisualization.Charting.SeriesChartType.Column
        End If
    End Sub
End Class