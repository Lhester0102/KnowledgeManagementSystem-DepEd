Imports MySql.Data.MySqlClient
Public Class line_graphs
    Sub load_region()
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT distinct region from enrollment "
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                ComboBox1.Items.Add(READER.GetString("region").ToString)
                ComboBox3.Items.Add(READER.GetString("region").ToString)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ComboBox3.Items.Add("All Regions")
    End Sub
    Sub load_sy_elem()
        For x = 0 To ComboBox1.Items.Count - 1
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String
            Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
                query = "SELECT region,sum(grand_total) as 'total',school_year FROM depedkms.enrollment where region='" & ComboBox1.Items.Item(x) & "' group by school_year "
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                    Chart1.Series("ES Enrollees").Points.AddXY(READER.GetString("school_year") & " " & ComboBox1.Items.Item(x), READER.GetFloat("total"))
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub
    Sub load_sy_elem2()

        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT region,sum(grand_total) as 'total',school_year FROM depedkms.enrollment where region='" & ComboBox3.Text & "' group by school_year "
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart1.Series("ES Enrollees").Points.AddXY(READER.GetString("school_year") & " " & ComboBox3.Text, READER.GetFloat("total"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub load_sy_highschool()
        For x = 0 To ComboBox1.Items.Count - 1
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String
            Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
                query = "SELECT region,sum(grandtotal) as 'total',school_year FROM depedkms.highschool where region='" & ComboBox1.Items.Item(x) & "' group by school_year "
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                    Chart1.Series("SS Enrollees").Points.AddXY(READER.GetString("school_year") & " " & ComboBox1.Items.Item(x), READER.GetFloat("total"))
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub
    Sub load_sy_highschool2()

        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT region,sum(grandtotal) as 'total',school_year FROM depedkms.highschool where region='" & ComboBox3.Text & "' group by school_year "
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart1.Series("SS Enrollees").Points.AddXY(READER.GetString("school_year") & " " & ComboBox3.Text, READER.GetFloat("total"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub line_graphs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chart1.Series.Clear()
        Chart1.Series.Add("ES Enrollees")
        Chart1.Series.Add("SS Enrollees")
        Chart1.Series("ES Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart1.Series("SS Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart1.Series("ES Enrollees").LabelAngle = -45
        Chart1.Series("SS Enrollees").LabelAngle = -45
        load_region()
        load_sy_highschool()
        load_sy_elem()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "Line" Then
            Chart1.Series("ES Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart1.Series("SS Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Line
        ElseIf ComboBox2.Text = "Bar" Then
            Chart1.Series("ES Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series("SS Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Else
            Chart1.Series("ES Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart1.Series("SS Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Column
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Chart1.ResetAutoValues()
        If ComboBox3.Text = "All Regions" Then
            Chart1.Series.Clear()
            Chart1.Series.Add("ES Enrollees")
            Chart1.Series.Add("SS Enrollees")
            Chart1.Series("ES Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart1.Series("SS Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart1.Series("ES Enrollees").LabelAngle = -45
            Chart1.Series("SS Enrollees").LabelAngle = -45

            load_sy_highschool()
            load_sy_elem()
        Else
            Chart1.Series.Clear()
            Chart1.Series.Add("ES Enrollees")
            Chart1.Series.Add("SS Enrollees")
            Chart1.Series("ES Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart1.Series("SS Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart1.Series("ES Enrollees").LabelAngle = -45
            Chart1.Series("SS Enrollees").LabelAngle = -45
            '       load_region()
            load_sy_highschool2()
            load_sy_elem2()
        End If
    End Sub
End Class