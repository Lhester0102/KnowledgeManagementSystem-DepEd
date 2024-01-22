Imports MySql.Data.MySqlClient
Public Class graph_mooe
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
            query = "SELECT distinct region from mooe order by region"
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
    Sub loadmooe_elem()

        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String = ""
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT region,sum(ammount) as 'total',school_year FROM depedkms.mooe where offering='ELEMENTARY' group by region,school_year order by region,school_year "

            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart1.Series("ELEMENTARY").Points.AddXY(READER.GetString(0).ToString & " " & READER.GetString("school_year").ToString, READER.GetFloat("total"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub loadmooe2()
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String = ""
            Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
                query = "SELECT region,sum(ammount) as 'total',school_year FROM depedkms.mooe where  offering='HIGHSCHOOL'  group by region,school_year order by region,school_year"
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                    Chart1.Series("HIGHSCHOOL").Points.AddXY(READER.GetString(0) & " " & READER.GetString("school_year").ToString, READER.GetFloat("total"))
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
    End Sub
    Sub loadmooe3()

        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String = ""
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try

            query = "SELECT region,sum(ammount) as 'total',school_year FROM depedkms.mooe where region='" & ComboBox2.Text & "' and  offering='HIGHSCHOOL'  group by region,school_year order by school_year"

            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart1.Series("HIGHSCHOOL").Points.AddXY(READER.GetString(0) & " " & READER.GetString("school_year").ToString, READER.GetFloat("total"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub loadmooe4()

        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String = ""
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try

            query = "SELECT region,sum(ammount) as 'total',school_year FROM depedkms.mooe where region='" & ComboBox2.Text & "' and  offering='ELEMENTARY'  group by region,school_year order by school_year"

            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart1.Series("ELEMENTARY").Points.AddXY(READER.GetString(0) & " " & READER.GetString("school_year").ToString, READER.GetFloat("total"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    
    Private Sub graph_mooe_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        chart1.Series.Clear()
        Chart1.Series.Add("ELEMENTARY")
        Chart1.Series.Add("HIGHSCHOOL")
    
        Chart1.Series("ELEMENTARY").ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Chart1.Series("HIGHSCHOOL").ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Chart1.Series("ELEMENTARY").IsValueShownAsLabel = True
        Chart1.Series("HIGHSCHOOL").IsValueShownAsLabel = True
        load_sy()
        loadmooe_elem()
        loadmooe2()
 
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "All Regions" Then
            Chart1.ResetAutoValues()
            Chart1.Series.Clear()
            Chart1.Series.Add("ELEMENTARY")
            Chart1.Series.Add("HIGHSCHOOL")
            Chart1.Series("ELEMENTARY").ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series("HIGHSCHOOL").ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series("ELEMENTARY").IsValueShownAsLabel = True
            Chart1.Series("HIGHSCHOOL").IsValueShownAsLabel = True
            loadmooe_elem()
            loadmooe2()
        Else
            Chart1.ResetAutoValues()
            Chart1.Series.Clear()
            Chart1.Series.Clear()
            Chart1.Series.Add("ELEMENTARY")
            Chart1.Series.Add("HIGHSCHOOL")
            Chart1.Series("ELEMENTARY").ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series("HIGHSCHOOL").ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series("ELEMENTARY").IsValueShownAsLabel = True
            Chart1.Series("HIGHSCHOOL").IsValueShownAsLabel = True
            loadmooe3()
            loadmooe4()
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.Text = "Line" Then
            Chart1.Series("ELEMENTARY").ChartType = DataVisualization.Charting.SeriesChartType.Line
            Chart1.Series("HIGHSCHOOL").ChartType = DataVisualization.Charting.SeriesChartType.Line
          
        ElseIf ComboBox3.Text = "Bar" Then
            Chart1.Series("ELEMENTARY").ChartType = DataVisualization.Charting.SeriesChartType.Bar
            Chart1.Series("HIGHSCHOOL").ChartType = DataVisualization.Charting.SeriesChartType.Bar
        Else
            Chart1.Series("ELEMENTARY").ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart1.Series("HIGHSCHOOL").ChartType = DataVisualization.Charting.SeriesChartType.Column
        End If
    End Sub
End Class