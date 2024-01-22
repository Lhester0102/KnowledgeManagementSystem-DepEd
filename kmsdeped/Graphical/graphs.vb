Imports MySql.Data.MySqlClient
Public Class graphs
    Dim sy_elem As String
    Dim sy_high As String
    Dim sy_teach_elem As String
    Dim sy_teach_high As String
    'Sub load_sy_elem()
    '    Dim conn As MySqlConnection
    '    Dim com As MySqlCommand
    '    Dim READER As MySqlDataReader
    '    Dim query As String
    '    Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
    '    conn = New MySqlConnection
    '    conn.ConnectionString = strcon
    '    Try
    '        query = "SELECT distinct region from enrollment order by region"
    '        conn.Open()
    '        com = New MySqlCommand(query, conn)
    '        READER = com.ExecuteReader
    '        While READER.Read
    '            ComboBox1.Items.Add(READER.GetString("region").ToString)
    '            ComboBox3.Items.Add(READER.GetString("region").ToString)
    '        End While
    '        conn.Close()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub
    Sub load_sy_high()
        ComboBox3.Items.Clear()
        ComboBox3.Items.Add("All Regions")
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT distinct region from highschool order by region "
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                ComboBox3.Items.Add(READER.GetString("region").ToString)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
   

    Sub loadregions()
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String
            Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
            query = "SELECT region,sum(grand_total) as 'total',school_year FROM depedkms.enrollment group by region,school_year order by region,school_year "
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                Chart1.Series("ES Enrollees").Points.AddXY(READER.GetString("region") & " " & READER.GetString("school_year"), READER.GetFloat("total"))
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
    End Sub
    Sub loadregions4()

        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT region,sum(grand_total) as 'total',school_year FROM depedkms.enrollment where region like'%" & ComboBox3.Text & "' group by region,school_year order by region,school_year "
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart1.Series("ES Enrollees").Points.AddXY(READER.GetString("region") & " " & READER.GetString("school_year"), READER.GetFloat("total"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub loadregions2()
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String
            Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
            query = "SELECT region,sum(grandtotal) as 'total',school_year FROM depedkms.highschool  group by region,school_year order by region,school_year "
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                Chart1.Series("SS Enrollees").Points.AddXY(READER.GetString("region") & " " & READER.GetString("school_year"), READER.GetFloat("total"))
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
    End Sub
    Sub loadregions3()
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT region,sum(grandtotal) as 'total',school_year FROM depedkms.highschool where region like'%" & ComboBox3.Text & "'  group by region,school_year order by region,school_year "
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart1.Series("SS Enrollees").Points.AddXY(READER.GetString("region") & " " & READER.GetString("school_year"), READER.GetFloat("total"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub graphs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chart1.Series.Clear()
        chart1.Series.Clear()
        Chart1.Series.Add("ES Enrollees")
        chart1.Series.Add("SS Enrollees")
        Chart1.Series("ES Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Column
        Chart1.Series("SS Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Column
        Chart1.Series("ES Enrollees").IsValueShownAsLabel = True
        Chart1.Series("SS Enrollees").IsValueShownAsLabel = True
        ' load_sy_elem()
        load_sy_high()
        loadregions()
        loadregions2()
    End Sub

    Private Sub Chart3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Chart4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.Text = "All Regions" Then
            Chart1.Series.Clear()
            Chart1.Series.Clear()
            Chart1.Series.Add("ES Enrollees")
            Chart1.Series.Add("SS Enrollees")
            Chart1.Series("ES Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart1.Series("SS Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart1.Series("ES Enrollees").IsValueShownAsLabel = True
            Chart1.Series("SS Enrollees").IsValueShownAsLabel = True
            loadregions()
            loadregions2()
        Else
            Chart1.ResetAutoValues()
            Chart1.Series.Clear()
            Chart1.Series.Clear()
            Chart1.Series.Add("ES Enrollees")
            Chart1.Series.Add("SS Enrollees")
            Chart1.Series("ES Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series("SS Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series("ES Enrollees").IsValueShownAsLabel = True
            Chart1.Series("SS Enrollees").IsValueShownAsLabel = True
            loadregions3()
            loadregions4()
        End If
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub province_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class