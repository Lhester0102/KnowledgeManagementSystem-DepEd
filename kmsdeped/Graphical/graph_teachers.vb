Imports MySql.Data.MySqlClient
Public Class graph_teachers
    Sub load_sy_teachers_high()
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
            query = "SELECT distinct region from teachers order by region"
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



    Sub loadteachers2()
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String = ""
            Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
                query = "SELECT region,sum(total_teacher) as 'total',school_year FROM depedkms.teachers where  school_type='HIGHSCHOOL' group by region,school_year order by region,school_year "
             
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                chart1.Series("SS Teachers").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("total"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub loadteachers()

        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String = ""
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT region,sum(total_teacher) as 'total',school_year FROM depedkms.teachers where  school_type='ELEMENTARY'  group by region,school_year order by region,school_year"
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart1.Series("ES Teachers").Points.AddXY(READER.GetString(0) & " " & READER.GetString("school_year").ToString, READER.GetFloat("total"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub loadteachers3()

        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String = ""
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT region,sum(total_teacher) as 'total',school_year FROM depedkms.teachers where region='" & ComboBox2.Text & "' and  school_type='ELEMENTARY'  group by region,school_year order by region,school_year"
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart1.Series("ES Teachers").Points.AddXY(READER.GetString(0) & " " & READER.GetString("school_year").ToString, READER.GetFloat("total"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub loadteachers4()

        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String = ""
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT region,sum(total_teacher) as 'total',school_year FROM depedkms.teachers where region='" & ComboBox2.Text & "' and  school_type='HIGHSCHOOL'  group by region,school_year order by region,school_year"
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart1.Series("SS Teachers").Points.AddXY(READER.GetString(0) & " " & READER.GetString("school_year").ToString, READER.GetFloat("total"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub graph_teachers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chart1.Series.Clear()
        Chart1.ResetAutoValues()
        Chart1.Series.Add("ES Teachers")
        chart1.Series.Add("SS Teachers")
        Chart1.Series("ES Teachers").ChartType = DataVisualization.Charting.SeriesChartType.Bar
        chart1.Series("SS Teachers").ChartType = DataVisualization.Charting.SeriesChartType.Bar
        load_sy_teachers_high()
        loadteachers()
        loadteachers2()

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "All Regions" Then
            Chart1.Series.Clear()
            Chart1.ResetAutoValues()
            Chart1.Series.Add("ES Teachers")
            Chart1.Series.Add("SS Teachers")
            Chart1.Series("ES Teachers").ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series("SS Teachers").ChartType = DataVisualization.Charting.SeriesChartType.Bar

            loadteachers()
            loadteachers2()
        Else
            Chart1.Series.Clear()
            Chart1.ResetAutoValues()
            Chart1.Series.Add("ES Teachers")
            Chart1.Series.Add("SS Teachers")
            Chart1.Series("ES Teachers").ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series("SS Teachers").ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series("ES Teachers").IsValueShownAsLabel = True
            Chart1.Series("SS Teachers").IsValueShownAsLabel = True
            loadteachers3()
            loadteachers4()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Line" Then
            Chart1.Series("ES Teachers").ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart1.Series("SS Teachers").ChartType = DataVisualization.Charting.SeriesChartType.Line
        ElseIf ComboBox1.Text = "Bar" Then
            Chart1.Series("ES Teachers").ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series("SS Teachers").ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Else
            Chart1.Series("ES Teachers").ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart1.Series("SS Teachers").ChartType = DataVisualization.Charting.SeriesChartType.Column
        End If
    End Sub
End Class