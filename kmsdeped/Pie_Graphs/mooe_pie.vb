Imports MySql.Data.MySqlClient
Public Class mooe_pie
    Dim all_ammount As Double
    Dim all_ammount2 As Double
    Dim h_ammount As Double
    Dim e_ammount As Double

    Sub load_sy_mooe()
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
            query = "SELECT distinct school_year from mooe order by school_year"
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
        '  ComboBox1.Items.Add("All Regions")
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
                Chart1.Series.Add(READER.GetString("region").ToString())
                Chart2.Series.Add(READER.GetString("region").ToString())
                ComboBox1.Items.Add(READER.GetString("region").ToString())
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub all_mooe()
        all_ammount = 0
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT sum(ammount) as 'total' from mooe where offering='ELEMENTARY'"
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                all_ammount = READER.GetDouble("total")
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' MsgBox(all_ammount)
    End Sub
    Sub all_mooe_region()
        For x = 0 To ComboBox1.Items.Count - 1
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String
            Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
                query = "SELECT region,school_year,sum(ammount) as 'total' from mooe where offering='ELEMENTARY' and region='" & ComboBox1.Items.Item(x) & "'"
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                    e_ammount = 0
                    TextBox1.Text = (READER.GetFloat("total") / all_ammount) * 100
                    Dim strr As String = ""
                    For w = 0 To 2
                        strr = strr + TextBox1.Text.ElementAt(w)
                    Next
                    e_ammount = Val(strr)
                    Chart1.Series(0).Points.AddXY(READER.GetString("region").ToString(), e_ammount)
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub

    Sub all_mooe2()
        all_ammount = 0
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT sum(ammount) as 'total' from mooe where offering='HIGHSCHOOL'"
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                all_ammount2 = READER.GetFloat("total")
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' MsgBox(all_ammount)
    End Sub
    Sub all_mooe_region2()
        For x = 0 To ComboBox1.Items.Count - 1
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String
            Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
                query = "SELECT region,school_year,sum(ammount) as 'total' from mooe where offering='HIGHSCHOOL' and region='" & ComboBox1.Items.Item(x) & "'"
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                    h_ammount = 0
                    TextBox2.Text = (READER.GetFloat("total") / all_ammount2) * 100
                    Dim strr As String = ""
                    For w = 0 To 2
                        strr = strr + TextBox2.Text.ElementAt(w)
                    Next
                    h_ammount = Val(strr)
                    Chart2.Series(0).Points.AddXY(READER.GetString("region").ToString(), h_ammount)
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub


    Private Sub mooe_pie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chart1.Series.Clear()
        Chart1.ResetAutoValues()
        Chart2.Series.Clear()
        Chart2.ResetAutoValues()
        load_sy_mooe()
        load_region()
        all_mooe()
        For x = 0 To ComboBox1.Items.Count - 1
            Chart2.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Chart1.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Pie
        Next
        Chart1.Series(0).IsValueShownAsLabel = True
        Chart2.Series(0).IsValueShownAsLabel = True
        all_mooe_region()
        all_mooe2()
        all_mooe_region2()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
  
    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
    Sub all_mooe3()
        all_ammount = 0
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT sum(ammount) as 'total' from mooe where offering='ELEMENTARY' and school_year='" & ComboBox2.Text & "'"
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                all_ammount = READER.GetDouble("total")
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' MsgBox(all_ammount)
    End Sub
    Sub all_mooe_region3()
        For x = 0 To ComboBox1.Items.Count - 1
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String
            Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
                query = "SELECT region,school_year,sum(ammount) as 'total' from mooe where offering='ELEMENTARY' and region='" & ComboBox1.Items.Item(x) & "'  and school_year='" & ComboBox2.Text & "'"
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                    e_ammount = 0
                    TextBox1.Text = (READER.GetFloat("total") / all_ammount) * 100
                    Dim strr As String = ""
                    For w = 0 To 2
                        strr = strr + TextBox1.Text.ElementAt(w)
                    Next
                    e_ammount = Val(strr)
                    Chart1.Series(0).Points.AddXY(READER.GetString("region").ToString(), e_ammount)
                End While
                conn.Close()
            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try
        Next
    End Sub

    Sub all_mooe23()
        all_ammount = 0
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT sum(ammount) as 'total' from mooe where offering='HIGHSCHOOL' and school_year='" & ComboBox2.Text & "'"
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                all_ammount2 = READER.GetFloat("total")
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' MsgBox(all_ammount)
    End Sub
    Sub all_mooe_region23()
        For x = 0 To ComboBox1.Items.Count - 1
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            Dim READER As MySqlDataReader
            Dim query As String
            Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
            conn = New MySqlConnection
            conn.ConnectionString = strcon
            Try
                query = "SELECT region,school_year,sum(ammount) as 'total' from mooe where offering='HIGHSCHOOL' and region='" & ComboBox1.Items.Item(x) & "' and school_year='" & ComboBox2.Text & "'"
                conn.Open()
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                While READER.Read
                    h_ammount = 0
                    TextBox2.Text = (READER.GetFloat("total") / all_ammount2) * 100
                    Dim strr As String = ""
                    For w = 0 To 2
                        strr = strr + TextBox2.Text.ElementAt(w)
                    Next
                    h_ammount = Val(strr)
                    Chart2.Series(0).Points.AddXY(READER.GetString("region").ToString(), h_ammount)
                End While
                conn.Close()
            Catch ex As Exception
                '  MsgBox(ex.Message)
            End Try
        Next
    End Sub
    'Chart1.Series.Clear()
    '    Chart1.ResetAutoValues()
    '    Chart2.Series.Clear()
    '    Chart2.ResetAutoValues()
    '    all_mooe()
    '    For x = 0 To ComboBox1.Items.Count - 1
    '        Chart2.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Pie
    '        Chart1.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Pie
    '    Next
    '    Chart1.Series(0).IsValueShownAsLabel = True
    '    Chart2.Series(0).IsValueShownAsLabel = True
    '    all_mooe_region()
    '    all_mooe2()
    '    all_mooe_region2()
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "All Years" Then
            Chart1.Series.Clear()
            Chart1.ResetAutoValues()
            Chart2.Series.Clear()
            Chart2.ResetAutoValues()
            load_region()
            all_mooe()
            For x = 0 To ComboBox1.Items.Count - 1
                Chart2.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Pie
                Chart1.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Next
            Chart1.Series(0).IsValueShownAsLabel = True
            Chart2.Series(0).IsValueShownAsLabel = True
            all_mooe_region()
            all_mooe2()
            all_mooe_region2()
        Else
            Chart1.Series.Clear()
            Chart1.ResetAutoValues()
            Chart2.Series.Clear()
            Chart2.ResetAutoValues()
            load_region()
            all_mooe3()

            For x = 0 To ComboBox1.Items.Count - 1
                Chart2.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Pie
                Chart1.Series(x).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Next
            Chart1.Series(0).IsValueShownAsLabel = True
            Chart2.Series(0).IsValueShownAsLabel = True
            all_mooe_region3()
            all_mooe23()
            all_mooe_region23()

        End If
    End Sub
End Class