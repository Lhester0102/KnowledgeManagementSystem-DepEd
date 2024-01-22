Imports MySql.Data.MySqlClient

Public Class teacher_pie
    Dim all_teachers As Integer
    Dim teacher1 As Integer
    Dim teacher2 As Integer
    Dim teacher3 As Integer
    Dim mobile As Integer

    Dim h_all_teachers As Integer
    Dim h_teacher1 As Integer
    Dim h_teacher2 As Integer
    Dim h_teacher3 As Integer
    Dim h_mobile As Integer
    Sub load_sy_teachers_high()
        ComboBox2.Items.Clear()
        ComboBox2.Items.Add("All Years")
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT distinct school_year from teachers order by school_year"
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                ComboBox2.Items.Add(READER.GetString("school_year").ToString)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub load_region()
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
            query = "SELECT distinct region from teachers order by region"
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
    Sub all_t()
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT region,school_year,sum(teacher1) as 'all_t1',sum(teacher2) as 'all_t2',sum(teacher3) as 'all_t3',sum(total_teacher) as 'all_t' from teachers where school_type='ELEMENTARY'"
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read

                teacher1 = READER.GetString("all_t1").ToString
                teacher2 = READER.GetString("all_t2").ToString
                teacher3 = READER.GetString("all_t3").ToString
            End While
            all_teachers = teacher3 + teacher2 + teacher1
            teacher1 = (teacher1 / all_teachers) * 100
            teacher2 = (teacher2 / all_teachers) * 100
            teacher3 = (teacher3 / all_teachers) * 100
            mobile = 100 - (teacher3 + teacher2 + teacher1)
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub h_all_t()
        h_all_teachers = 0
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT region,school_year,sum(teacher1) as 'all_t1',sum(teacher2) as 'all_t2',sum(teacher3) as 'all_t3',sum(total_teacher) as 'all_t' from teachers where school_type='HIGHSCHOOL'"
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read

                h_teacher1 = READER.GetString("all_t1").ToString
                h_teacher2 = READER.GetString("all_t2").ToString
                h_teacher3 = READER.GetString("all_t3").ToString
            End While
            h_all_teachers = h_teacher1 + h_teacher2 + h_teacher3
            h_teacher1 = (h_teacher1 / h_all_teachers) * 100
            h_teacher2 = (h_teacher2 / h_all_teachers) * 100
            h_teacher3 = (h_teacher3 / h_all_teachers) * 100
            h_mobile = 100 - (h_teacher1 + h_teacher2 + h_teacher3)
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
   
    Private Sub teacher_pie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chart1.Series.Clear()
        Chart1.ResetAutoValues()
        Chart1.Series.Add("ES Teacher 1")
        Chart1.Series.Add("ES Teacher 2")
        Chart1.Series.Add("ES Teacher 3")
        Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Chart1.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Chart1.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        'Chart1.Series("ES Teacher 1").IsValueShownAsLabel = True
        'Chart1.Series("ES Teacher 2").IsValueShownAsLabel = True
        'Chart1.Series("ES Teacher 3").IsValueShownAsLabel = True
        load_sy_teachers_high()
        load_region()
        all_t()
        Chart1.Series("ES Teacher 1").XValueType = DataVisualization.Charting.ChartValueType.Int32
        Chart1.Series("ES Teacher 2").XValueType = DataVisualization.Charting.ChartValueType.Int32
        Chart1.Series("ES Teacher 3").XValueType = DataVisualization.Charting.ChartValueType.Int32
        Chart1.Series(0).Points.AddXY("ES Teacher 1-" & teacher1 & "%", teacher1)
        Chart1.Series(0).Points.AddXY("ES Teacher 2-" & teacher2 & "%", teacher2)
        Chart1.Series(0).Points.AddXY("ES Teacher 3-" & teacher3 & "%", teacher3)

        Chart2.Series.Clear()
        Chart2.ResetAutoValues()
        Chart2.Series.Add("SS Teacher 1")
        Chart2.Series.Add("SS Teacher 2")
        Chart2.Series.Add("SS Teacher 3")
        Chart2.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Chart2.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Chart2.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        'Chart2.Series("SS Teacher 1").IsValueShownAsLabel = True
        'Chart2.Series("SS Teacher 2").IsValueShownAsLabel = True
        'Chart2.Series("SS Teacher 3").IsValueShownAsLabel = True
        h_all_t()

        Chart2.Series("SS Teacher 1").XValueType = DataVisualization.Charting.ChartValueType.Int32
        Chart2.Series("SS Teacher 2").XValueType = DataVisualization.Charting.ChartValueType.Int32
        Chart2.Series("SS Teacher 3").XValueType = DataVisualization.Charting.ChartValueType.Int32
        Chart2.Series(0).Points.AddXY("SS Teacher 1-" & h_teacher1 & "%", h_teacher1)
        Chart2.Series(0).Points.AddXY("SS Teacher 2-" & h_teacher2 & "%", h_teacher2)
        Chart2.Series(0).Points.AddXY("SS Teacher 3-" & h_teacher3 & "%", h_teacher3)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        
    End Sub
    Sub r_all_t()
        all_teachers = 0
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT region,school_year,sum(teacher1) as 'all_t1',sum(teacher2) as 'all_t2',sum(teacher3) as 'all_t3' ,sum(total_teacher) as 'all_t' from teachers where region='" & ComboBox1.Text & "' and school_type='ELEMENTARY' group by region,school_year"
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read

                teacher1 = READER.GetString("all_t1").ToString
                teacher2 = READER.GetString("all_t2").ToString
                teacher3 = READER.GetString("all_t3").ToString

            End While
            all_teachers = teacher1 + teacher2 + teacher3
            teacher1 = (teacher1 / all_teachers) * 100
            teacher2 = (teacher2 / all_teachers) * 100
            teacher3 = (teacher3 / all_teachers) * 100
            mobile = 100 - (teacher1 + teacher2 + teacher3)
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub rh_all_t()
        h_all_teachers = 0
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT region,school_year ,sum(teacher1) as 'all_t1',sum(teacher2) as 'all_t2',sum(teacher3) as 'all_t3',sum(total_teacher) as 'all_t' from teachers where region='" & ComboBox1.Text & "' and school_type='HIGHSCHOOL' group by region,school_year"
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read

                h_teacher1 = READER.GetString("all_t1").ToString
                h_teacher2 = READER.GetString("all_t2").ToString
                h_teacher3 = READER.GetString("all_t3").ToString
            End While
            h_all_teachers = h_teacher1 + h_teacher2 + h_teacher3
            h_teacher1 = (h_teacher1 / h_all_teachers) * 100
            h_teacher2 = (h_teacher2 / h_all_teachers) * 100
            h_teacher3 = (h_teacher3 / h_all_teachers) * 100
            h_mobile = 100 - (h_teacher1 + h_teacher2 + h_teacher3)
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Chart1.Series.Clear()
        Chart1.ResetAutoValues()
        Chart1.Series.Add("ES Teacher 1")
        Chart1.Series.Add("ES Teacher 2")
        Chart1.Series.Add("ES Teacher 3")
        Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Chart1.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Chart1.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        'Chart1.Series("ES Teacher 1").IsValueShownAsLabel = True
        'Chart1.Series("ES Teacher 2").IsValueShownAsLabel = True
        'Chart1.Series("ES Teacher 3").IsValueShownAsLabel = True
        r_all_t()

        Chart1.Series("ES Teacher 1").XValueType = DataVisualization.Charting.ChartValueType.Int32
        Chart1.Series("ES Teacher 2").XValueType = DataVisualization.Charting.ChartValueType.Int32
        Chart1.Series("ES Teacher 3").XValueType = DataVisualization.Charting.ChartValueType.Int32
        Chart1.Series(0).Points.AddXY("ES Teacher 1-" & teacher1 & "%", teacher1)
        Chart1.Series(0).Points.AddXY("ES Teacher 2-" & teacher2 & "%", teacher2)
        Chart1.Series(0).Points.AddXY("ES Teacher 3-" & teacher3 & "%", teacher3)

        Chart2.Series.Clear()
        Chart2.ResetAutoValues()
        Chart2.Series.Add("SS Teacher 1")
        Chart2.Series.Add("SS Teacher 2")
        Chart2.Series.Add("SS Teacher 3")
        Chart2.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Chart2.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Chart2.Series(2).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        'Chart2.Series("SS Teacher 1").IsValueShownAsLabel = True
        'Chart2.Series("SS Teacher 2").IsValueShownAsLabel = True
        'Chart2.Series("SS Teacher 3").IsValueShownAsLabel = True
        rh_all_t()

        Chart2.Series("SS Teacher 1").XValueType = DataVisualization.Charting.ChartValueType.Int32
        Chart2.Series("SS Teacher 2").XValueType = DataVisualization.Charting.ChartValueType.Int32
        Chart2.Series("SS Teacher 3").XValueType = DataVisualization.Charting.ChartValueType.Int32
        Chart2.Series(0).Points.AddXY("SS Teacher 1-" & h_teacher1 & "%", h_teacher1)
        Chart2.Series(0).Points.AddXY("SS Teacher 2-" & h_teacher2 & "%", h_teacher2)
        Chart2.Series(0).Points.AddXY("SS Teacher 3-" & h_teacher3 & "%", h_teacher3)

    End Sub
End Class