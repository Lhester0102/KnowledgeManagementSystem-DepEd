Imports MySql.Data.MySqlClient
Public Class all_graphs

    Sub loadsy()
        ComboBox2.Items.Clear()
        ComboBox4.Items.Clear()
        ComboBox4.Items.Add("All Years")
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim squery As String
        conn = New MySqlConnection
        conn.ConnectionString = "server=localhost;userid=root;password=;database=depedkms"
        Try
            squery = "select distinct school_year from enrollment order by school_year"
            conn.Open()
            com = New MySqlCommand(squery, conn)
            READER = com.ExecuteReader
            While READER.Read
                ComboBox2.Items.Add(READER.GetString(0).ToString)
                ComboBox4.Items.Add(READER.GetString(0).ToString)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub loadregions()
        For x = 0 To ComboBox2.Items.Count - 1
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String
            Dim strcon As String = " server=localhost;userid=root;password=;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
                query = "SELECT sum(grand_total) as 'total',school_year FROM depedkms.enrollment where school_year='" & ComboBox2.Items.Item(x) & "' group by school_year"
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                    Chart1.Series("ES Enrollees").Points.AddXY(READER.GetString("school_year"), READER.GetFloat("total"))
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub
    Sub loadregions2()
        For x = 0 To ComboBox2.Items.Count - 1
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String
            Dim strcon As String = " server=localhost;userid=root;password=;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
                query = "SELECT sum(grandtotal) as 'total',school_year FROM depedkms.highschool where school_year='" & ComboBox2.Items.Item(x) & "' group by school_year "
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                    Chart1.Series("SS Enrollees").Points.AddXY(READER.GetString("school_year"), READER.GetFloat("total"))
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub
    Sub loadmooe_elem()
        For x = 0 To ComboBox2.Items.Count - 1
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String = ""
            Dim strcon As String = " server=localhost;userid=root;password=;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
                query = "SELECT sum(ammount) as 'total',school_year FROM depedkms.mooe where school_year='" & ComboBox2.Items.Item(x) & "' and offering='ELEMENTARY' group by School_year "

                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                    Chart2.Series("ES MOOE").Points.AddXY(READER.GetString("school_year").ToString, READER.GetFloat("total"))
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub
    Sub loadmooe_hs()
        For x = 0 To ComboBox2.Items.Count - 1
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String = ""
            Dim strcon As String = " server=localhost;userid=root;password=;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
                query = "SELECT sum(ammount) as 'total',school_year FROM depedkms.mooe where school_year='" & ComboBox2.Items.Item(x) & "' and offering='HIGHSCHOOL' group by school_year "

                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                    Chart2.Series("SS MOOE").Points.AddXY(READER.GetString("school_year").ToString, READER.GetFloat("total"))
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub
    Sub load_in()
        For x = 0 To ComboBox2.Items.Count - 1
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String = ""
            Dim strcon As String = " server=localhost;userid=root;password=;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
                query = "SELECT sum(total_instructional_room) as 'total',school_year,school_type FROM depedkms.rooms_i where school_year='" & ComboBox2.Items.Item(x) & "' and school_type='ELEMENTARY' group by school_year "
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read

                    Chart3.Series("ES ROOM INS").Points.AddXY(READER.GetString("school_year").ToString, READER.GetFloat("total"))

                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub
    Sub load_in2()
        For x = 0 To ComboBox2.Items.Count - 1
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String = ""
            Dim strcon As String = " server=localhost;userid=root;password=;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
                query = "SELECT sum(total_instructional_room) as 'total',school_year,school_type FROM depedkms.rooms_i where school_year='" & ComboBox2.Items.Item(x) & "' and school_type='HIGHSCHOOL' group by school_year "
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read

                    Chart3.Series("SS ROOM INS").Points.AddXY(READER.GetString("school_year").ToString, READER.GetFloat("total"))

                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub
    Sub load_non()
        For x = 0 To ComboBox2.Items.Count - 1
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String = ""
            Dim strcon As String = " server=localhost;userid=root;password=;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try

                query = "SELECT sum(total_non_instructional_room) as 'total',school_year,school_type FROM depedkms.rooms_ni where school_year='" & ComboBox2.Items.Item(x) & "' and school_type='ELEMENTARY' group by school_year "
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read

                    Chart4.Series("ES ROOM NON INS").Points.AddXY(READER.GetString("School_year").ToString, READER.GetFloat("total"))

                End While
                  conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next

    End Sub
    Sub load_non2()
        For x = 0 To ComboBox2.Items.Count - 1
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String = ""
            Dim strcon As String = " server=localhost;userid=root;password=;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try

                query = "SELECT sum(total_non_instructional_room) as 'total',school_year,school_type FROM depedkms.rooms_ni where school_year='" & ComboBox2.Items.Item(x) & "' and school_type='HIGHSCHOOL' group by school_year "
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read

                    Chart4.Series("SS ROOM NON INS").Points.AddXY(READER.GetString("school_year").ToString, READER.GetFloat("total"))

                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next

    End Sub
    Sub loadteachers()
        For x = 0 To ComboBox2.Items.Count - 1
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String = ""
            Dim strcon As String = " server=localhost;userid=root;password=;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try

                query = "SELECT sum(total_teacher) as 'total',school_year FROM depedkms.teachers where school_year='" & ComboBox2.Items.Item(x) & "' and  school_type='ELEMENTARY'  group by school_year"

                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                    Chart5.Series("ES Teachers").Points.AddXY(READER.GetString("school_year"), READER.GetFloat("total"))
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub
    Sub loadteachers2()
        For x = 0 To ComboBox2.Items.Count - 1
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String = ""
            Dim strcon As String = " server=localhost;userid=root;password=;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try

                query = "SELECT sum(total_teacher) as 'total',school_year FROM depedkms.teachers where school_year='" & ComboBox2.Items.Item(x) & "' and  school_type='HIGHSCHOOL'  group by school_year"

                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                    Chart5.Series("SS Teachers").Points.AddXY(READER.GetString("school_year"), READER.GetFloat("total"))
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub
    Sub loadelectricity_elem()
        For x = 0 To ComboBox2.Items.Count - 1
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String = ""
            Dim strcon As String = " server=localhost;userid=root;password=;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
                query = "SELECT region,sum(grid_supply) as 'grid',sum(generator) as 'generator' ,sum(solar_power) as 'solar' ,sum(no_electricity) as 'no', school_year FROM depedkms.electricity where school_year='" & ComboBox2.Items.Item(x) & "' and school_type='ELEMENTARY' group by school_year "
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                    Chart6.Series("ES Grid Supply").Points.AddXY(READER.GetString("school_year"), Val(READER.GetString("grid")))
                    Chart6.Series("ES Generator").Points.AddXY(READER.GetString("school_year"), Val(READER.GetString("generator")))
                    Chart6.Series("ES Solar").Points.AddXY(READER.GetString("school_year"), Val(READER.GetString("solar")))
                    Chart6.Series("ES No Electricity").Points.AddXY(READER.GetString("school_year"), Val(READER.GetString("no")))
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub
    Sub loadelectricity_hs()
        For x = 0 To ComboBox2.Items.Count - 1
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String = ""
            Dim strcon As String = " server=localhost;userid=root;password=;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
                query = "SELECT region,sum(grid_supply) as 'grid',sum(generator) as 'generator' ,sum(solar_power) as 'solar' ,sum(no_electricity) as 'no', school_year FROM depedkms.electricity where school_year='" & ComboBox2.Items.Item(x) & "' and school_type='HIGHSCHOOL' group by school_year "
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                    Chart6.Series("SS Grid Supply").Points.AddXY(READER.GetString("school_year"), Val(READER.GetString("grid")))
                    Chart6.Series("SS Generator").Points.AddXY(READER.GetString("school_year"), Val(READER.GetString("generator")))
                    Chart6.Series("SS Solar").Points.AddXY(READER.GetString("school_year"), Val(READER.GetString("solar")))
                    Chart6.Series("SS No Electricity").Points.AddXY(READER.GetString("school_year"), Val(READER.GetString("no")))
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub
    Sub loadwater_elem()
        For x = 0 To ComboBox2.Items.Count - 1
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String = ""
            Dim strcon As String = " server=localhost;userid=root;password=;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
                query = "SELECT sum(local_piped) as 'lp',sum(well_warter_deep_well) as 'dw' ,sum(rain_warer_cathment) as 'rwc' ,sum(natural_source) as 'ns',sum(without_available_water_supply) as 'waws', school_year FROM depedkms.water where school_year='" & ComboBox2.Items.Item(x) & "' and school_type='ELEMENTARY' group by school_year "
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                    Chart7.Series("ES local pipe").Points.AddXY(READER.GetString("school_year"), READER.GetFloat("lp"))
                    Chart7.Series("ES deep well").Points.AddXY(READER.GetString("school_year"), READER.GetFloat("dw"))
                    Chart7.Series("ES rain water").Points.AddXY(READER.GetString("school_year"), READER.GetFloat("rwc"))
                    Chart7.Series("ES natural source").Points.AddXY(READER.GetString("school_year"), READER.GetFloat("ns"))
                    Chart7.Series("ES no supply").Points.AddXY(READER.GetString("school_year"), READER.GetFloat("waws"))
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub
    Sub loadwater_hs()
        For x = 0 To ComboBox2.Items.Count - 1
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String = ""
            Dim strcon As String = " server=localhost;userid=root;password=;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
                query = "SELECT sum(local_piped) as 'lp',sum(well_warter_deep_well) as 'dw' ,sum(rain_warer_cathment) as 'rwc' ,sum(natural_source) as 'ns',sum(without_available_water_supply) as 'waws', school_year FROM depedkms.water where school_year='" & ComboBox2.Items.Item(x) & "' and school_type='HIGHSCHOOL' group by school_year "
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                    Chart7.Series("SS local pipe").Points.AddXY(READER.GetString("school_year"), READER.GetFloat("lp"))
                    Chart7.Series("SS deep well").Points.AddXY(READER.GetString("school_year"), READER.GetFloat("dw"))
                    Chart7.Series("SS rain water").Points.AddXY(READER.GetString("school_year"), READER.GetFloat("rwc"))
                    Chart7.Series("SS natural source").Points.AddXY(READER.GetString("school_year"), READER.GetFloat("ns"))
                    Chart7.Series("SS no supply").Points.AddXY(READER.GetString("school_year"), READER.GetFloat("waws"))
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub
    Sub isval()
        Chart1.Series("ES Enrollees").IsValueShownAsLabel = True
        Chart1.Series("SS Enrollees").IsValueShownAsLabel = True
        Chart2.Series("ES MOOE").IsValueShownAsLabel = True
        Chart2.Series("SS MOOE").IsValueShownAsLabel = True
        Chart3.Series("ES ROOM INS").IsValueShownAsLabel = True
        Chart3.Series("SS ROOM INS").IsValueShownAsLabel = True
        Chart4.Series("ES ROOM NON INS").IsValueShownAsLabel = True
        Chart4.Series("SS ROOM NON INS").IsValueShownAsLabel = True
        Chart5.Series("ES Teachers").IsValueShownAsLabel = True
        Chart5.Series("SS Teachers").IsValueShownAsLabel = True

        Chart6.Series("ES Grid Supply").IsValueShownAsLabel = True
        Chart6.Series("ES Generator").IsValueShownAsLabel = True
        Chart6.Series("ES Solar").IsValueShownAsLabel = True
        Chart6.Series("ES No Electricity").IsValueShownAsLabel = True
        Chart6.Series("SS Grid Supply").IsValueShownAsLabel = True
        Chart6.Series("SS Generator").IsValueShownAsLabel = True
        Chart6.Series("SS Solar").IsValueShownAsLabel = True
        Chart6.Series("SS No Electricity").IsValueShownAsLabel = True

        Chart7.Series("ES local pipe").IsValueShownAsLabel = True
        Chart7.Series("ES deep well").IsValueShownAsLabel = True
        Chart7.Series("ES rain water").IsValueShownAsLabel = True
        Chart7.Series("ES natural source").IsValueShownAsLabel = True
        Chart7.Series("ES no supply").IsValueShownAsLabel = True

    End Sub
    Private Sub all_graphs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadsy()
        Chart1.Series.Clear()
        Chart2.Series.Clear()
        Chart3.Series.Clear()
        Chart4.Series.Clear()
        Chart5.Series.Clear()
        Chart6.Series.Clear()
        Chart7.Series.Clear()
        Chart1.Series.Add("ES Enrollees")
        Chart1.Series.Add("SS Enrollees")
        Chart2.Series.Add("ES MOOE")
        Chart2.Series.Add("SS MOOE")
        Chart3.Series.Add("ES ROOM INS")
        Chart3.Series.Add("SS ROOM INS")
        Chart4.Series.Add("ES ROOM NON INS")
        Chart4.Series.Add("SS ROOM NON INS")
        Chart5.Series.Add("ES Teachers")
        Chart5.Series.Add("SS Teachers")

        Chart6.Series.Add("ES Grid Supply")
        Chart6.Series.Add("ES Generator")
        Chart6.Series.Add("ES Solar")
        Chart6.Series.Add("ES No Electricity")
        Chart6.Series.Add("SS Grid Supply")
        Chart6.Series.Add("SS Generator")
        Chart6.Series.Add("SS Solar")
        Chart6.Series.Add("SS No Electricity")

        Chart7.Series.Add("ES local pipe")
        Chart7.Series.Add("ES deep well")
        Chart7.Series.Add("ES rain water")
        Chart7.Series.Add("ES natural source")
        Chart7.Series.Add("ES no supply")

        Chart7.Series.Add("SS local pipe")
        Chart7.Series.Add("SS deep well")
        Chart7.Series.Add("SS rain water")
        Chart7.Series.Add("SS natural source")
        Chart7.Series.Add("SS no supply")
        isval()
        mainfrm.Text = "Loading Enrollees"

        loadregions()
        loadregions2()
        mainfrm.Text = "Loading MOOE"
        loadmooe_elem()
        loadmooe_hs()
        mainfrm.Text = "Loading Rooms"
        load_in()
        load_in2()
        load_non()
        load_non2()
        mainfrm.Text = "Loading Teachers"
        loadteachers()
        loadteachers2()
        mainfrm.Text = "Loading Electricity Supply"
        loadelectricity_elem()
        loadelectricity_hs()
        mainfrm.Text = "Loading Water Supply"
        loadwater_elem()
        loadwater_hs()
        mainfrm.Text = "MAIN FORM"
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.Text = "Line" Then
            For x = 0 To Chart1.Series.Count - 1
                Chart1.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Line
                Chart1.Series(x).BorderWidth = 3
            Next
            For x = 0 To Chart2.Series.Count - 1
                Chart2.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Line
                Chart2.Series(x).BorderWidth = 3
            Next
            For x = 0 To Chart3.Series.Count - 1
                Chart3.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Line
                Chart3.Series(x).BorderWidth = 3
            Next
            For x = 0 To Chart4.Series.Count - 1
                Chart4.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Line
                Chart4.Series(x).BorderWidth = 3
            Next
            For x = 0 To Chart5.Series.Count - 1
                Chart5.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Line
                Chart5.Series(x).BorderWidth = 3
            Next
            For x = 0 To Chart6.Series.Count - 1
                Chart6.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Line
                Chart6.Series(x).BorderWidth = 3
            Next
            For x = 0 To Chart7.Series.Count - 1
                Chart7.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Line
                Chart7.Series(x).BorderWidth = 3
            Next
        ElseIf ComboBox3.Text = "Bar" Then
            For x = 0 To Chart1.Series.Count - 1
                Chart1.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Bar
                Chart1.Series(x).BorderWidth = 3
            Next
            For x = 0 To Chart2.Series.Count - 1
                Chart2.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Bar
                Chart2.Series(x).BorderWidth = 3
            Next
            For x = 0 To Chart3.Series.Count - 1
                Chart3.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Bar
                Chart3.Series(x).BorderWidth = 3
            Next
            For x = 0 To Chart4.Series.Count - 1
                Chart4.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Bar
                Chart4.Series(x).BorderWidth = 3
            Next
            For x = 0 To Chart5.Series.Count - 1
                Chart5.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Bar
                Chart5.Series(x).BorderWidth = 3
            Next
            For x = 0 To Chart6.Series.Count - 1
                Chart6.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Bar
                Chart6.Series(x).BorderWidth = 3
            Next
            For x = 0 To Chart7.Series.Count - 1
                Chart7.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Bar
                Chart7.Series(x).BorderWidth = 3
            Next
        ElseIf ComboBox3.Text = "Area" Then
            For x = 0 To Chart1.Series.Count - 1
                Chart1.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Area
                Chart1.Series(x).BorderWidth = 3
            Next
            For x = 0 To Chart2.Series.Count - 1
                Chart2.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Area
                Chart2.Series(x).BorderWidth = 3
            Next
            For x = 0 To Chart3.Series.Count - 1
                Chart3.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Area
                Chart3.Series(x).BorderWidth = 3
            Next
            For x = 0 To Chart4.Series.Count - 1
                Chart4.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Area
                Chart4.Series(x).BorderWidth = 3
            Next
            For x = 0 To Chart5.Series.Count - 1
                Chart5.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Area
                Chart5.Series(x).BorderWidth = 3
            Next
            For x = 0 To Chart6.Series.Count - 1
                Chart6.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Area
                Chart6.Series(x).BorderWidth = 3
            Next
            For x = 0 To Chart7.Series.Count - 1
                Chart7.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Area
                Chart7.Series(x).BorderWidth = 3
            Next
        Else
            For x = 0 To Chart1.Series.Count - 1
                Chart1.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Column
                Chart1.Series(x).BorderWidth = 3
            Next
            For x = 0 To Chart2.Series.Count - 1
                Chart2.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Column
                Chart2.Series(x).BorderWidth = 3
            Next
            For x = 0 To Chart3.Series.Count - 1
                Chart3.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Column
                Chart3.Series(x).BorderWidth = 3
            Next
            For x = 0 To Chart4.Series.Count - 1
                Chart4.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Column
                Chart4.Series(x).BorderWidth = 3
            Next
            For x = 0 To Chart5.Series.Count - 1
                Chart5.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Column
                Chart5.Series(x).BorderWidth = 3
            Next
            For x = 0 To Chart6.Series.Count - 1
                Chart6.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Column
                Chart6.Series(x).BorderWidth = 3
            Next
            For x = 0 To Chart7.Series.Count - 1
                Chart7.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Column
                Chart7.Series(x).BorderWidth = 3
            Next

        End If
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        Chart1.ResetAutoValues()
        Chart2.ResetAutoValues()
        Chart3.ResetAutoValues()
        Chart4.ResetAutoValues()
        Chart5.ResetAutoValues()
        Chart6.ResetAutoValues()
        Chart7.ResetAutoValues()
        If ComboBox4.Text = "All Years" Then
            loadsy()
            Chart1.Series.Clear()
            Chart2.Series.Clear()
            Chart3.Series.Clear()
            Chart4.Series.Clear()
            Chart5.Series.Clear()
            Chart6.Series.Clear()
            Chart7.Series.Clear()
            Chart1.Series.Add("ES Enrollees")
            Chart1.Series.Add("SS Enrollees")
            Chart2.Series.Add("ES MOOE")
            Chart2.Series.Add("SS MOOE")
            Chart3.Series.Add("ES ROOM INS")
            Chart3.Series.Add("SS ROOM INS")
            Chart4.Series.Add("ES ROOM NON INS")
            Chart4.Series.Add("SS ROOM NON INS")
            Chart5.Series.Add("ES Teachers")
            Chart5.Series.Add("SS Teachers")

            Chart6.Series.Add("ES Grid Supply")
            Chart6.Series.Add("ES Generator")
            Chart6.Series.Add("ES Solar")
            Chart6.Series.Add("ES No Electricity")
            Chart6.Series.Add("SS Grid Supply")
            Chart6.Series.Add("SS Generator")
            Chart6.Series.Add("SS Solar")
            Chart6.Series.Add("SS No Electricity")

            Chart7.Series.Add("ES local pipe")
            Chart7.Series.Add("ES deep well")
            Chart7.Series.Add("ES rain water")
            Chart7.Series.Add("ES natural source")
            Chart7.Series.Add("ES no supply")

            Chart7.Series.Add("SS local pipe")
            Chart7.Series.Add("SS deep well")
            Chart7.Series.Add("SS rain water")
            Chart7.Series.Add("SS natural source")
            Chart7.Series.Add("SS no supply")
            isval()
            mainfrm.Text = "Loading Enrollees"
            loadregions()
            loadregions2()
            mainfrm.Text = "Loading MOOE"
            loadmooe_elem()
            loadmooe_hs()
            mainfrm.Text = "Loading Rooms"
            load_in()
            load_in2()
            load_non()
            load_non2()
            mainfrm.Text = "Loading Teachers"
            loadteachers()
            loadteachers2()
            mainfrm.Text = "Loading Electricity Supply"
            loadelectricity_elem()
            loadelectricity_hs()
            mainfrm.Text = "Loading Water Supply"
            loadwater_elem()
            loadwater_hs()
            mainfrm.Text = "MAIN FORM"
        Else
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add(ComboBox4.Text)
            Chart1.Series.Clear()
            Chart2.Series.Clear()
            Chart3.Series.Clear()
            Chart4.Series.Clear()
            Chart5.Series.Clear()
            Chart6.Series.Clear()
            Chart7.Series.Clear()
            Chart1.Series.Add("ES Enrollees")
            Chart1.Series.Add("SS Enrollees")
            Chart2.Series.Add("ES MOOE")
            Chart2.Series.Add("SS MOOE")
            Chart3.Series.Add("ES ROOM INS")
            Chart3.Series.Add("SS ROOM INS")
            Chart4.Series.Add("ES ROOM NON INS")
            Chart4.Series.Add("SS ROOM NON INS")
            Chart5.Series.Add("ES Teachers")
            Chart5.Series.Add("SS Teachers")

            Chart6.Series.Add("ES Grid Supply")
            Chart6.Series.Add("ES Generator")
            Chart6.Series.Add("ES Solar")
            Chart6.Series.Add("ES No Electricity")
            Chart6.Series.Add("SS Grid Supply")
            Chart6.Series.Add("SS Generator")
            Chart6.Series.Add("SS Solar")
            Chart6.Series.Add("SS No Electricity")

            Chart7.Series.Add("ES local pipe")
            Chart7.Series.Add("ES deep well")
            Chart7.Series.Add("ES rain water")
            Chart7.Series.Add("ES natural source")
            Chart7.Series.Add("ES no supply")

            Chart7.Series.Add("SS local pipe")
            Chart7.Series.Add("SS deep well")
            Chart7.Series.Add("SS rain water")
            Chart7.Series.Add("SS natural source")
            Chart7.Series.Add("SS no supply")
            isval()
            mainfrm.Text = "Loading Enrollees"
            loadregions()
            loadregions2()
            mainfrm.Text = "Loading MOOE"
            loadmooe_elem()
            loadmooe_hs()
            mainfrm.Text = "Loading Rooms"
            load_in()
            load_in2()
            load_non()
            load_non2()
            mainfrm.Text = "Loading Teachers"
            loadteachers()
            loadteachers2()
            mainfrm.Text = "Loading Electricity Supply"
            loadelectricity_elem()
            loadelectricity_hs()
            mainfrm.Text = "Loading Water Supply"
            loadwater_elem()
            loadwater_hs()
            mainfrm.Text = "MAIN FORM"
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class