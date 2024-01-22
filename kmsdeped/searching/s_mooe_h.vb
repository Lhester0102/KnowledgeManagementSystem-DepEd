Imports MySql.Data.MySqlClient
Public Class s_mooe_h
    Dim squery As String = ""
    Sub load_sy()
        sy.Items.Clear()
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
                sy.Items.Add(READER.GetString(0).ToString)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub load_cm_region()
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
                regional.Items.Add(READER.GetString("region").ToString)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub s_mooe_h_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        regional.Visible = False
        division.Visible = False
        sname.Visible = False
        load_cm_region()
        load_sy()
        Chart1.Series.Clear()
        Chart1.Series.Add("SS MOOE")
        '  Chart1.Series.Add("SS Enrollees")
        Chart1.Series("SS MOOE").ChartType = DataVisualization.Charting.SeriesChartType.Bar
        ' Chart1.Series("SS Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Bar
    End Sub

    Private Sub regional_SelectedIndexChanged(sender As Object, e As EventArgs) Handles regional.SelectedIndexChanged
        division.Items.Clear()

        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT distinct division from mooe where offering='HIGHSCHOOL' and  region='" & regional.Text & "' order by division"
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                division.Items.Add(READER.GetString("division").ToString)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub division_SelectedIndexChanged(sender As Object, e As EventArgs) Handles division.SelectedIndexChanged
        sname.Items.Clear()

        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT distinct school_name from mooe where offering='HIGHSCHOOL' and  region='" & regional.Text & "' and division='" & division.Text & "' order by school_name"
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                sname.Items.Add(READER.GetString(0).ToString)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub visi()
        If soption.Text = "school_name" Then
            regional.Visible = True
            division.Visible = True
            sname.Visible = False
        ElseIf soption.Text = "specific_school" Then
            regional.Visible = True
            division.Visible = True
            sname.Visible = True
        ElseIf soption.Text = "division" Then
            regional.Visible = True
            division.Visible = False
            sname.Visible = False
        ElseIf soption.Text = "region" Then
            regional.Visible = False
            division.Visible = False
            sname.Visible = False
        End If
    End Sub
    Private Sub soption_SelectedIndexChanged(sender As Object, e As EventArgs) Handles soption.SelectedIndexChanged
        visi()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If soption.Text = "school_name" Then
            Chart1.ResetAutoValues()
            Chart1.Series.Clear()
            Chart1.Series.Add("SS MOOE")
            Chart1.Series("SS MOOE").ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart1.Series("SS MOOE").IsValueShownAsLabel = True
            loadschool_name_es()

        ElseIf soption.Text = "division" Then
            Chart1.ResetAutoValues()
            Chart1.Series.Clear()
            Chart1.Series.Add("SS MOOE")
            Chart1.Series("SS MOOE").ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart1.Series("SS MOOE").IsValueShownAsLabel = True
            loadschool_division_es()


        ElseIf soption.Text = "region" Then
            Chart1.ResetAutoValues()
            Chart1.Series.Clear()
            Chart1.Series.Add("SS MOOE")
            Chart1.Series("SS MOOE").ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart1.Series("SS MOOE").IsValueShownAsLabel = True
            loadschool_region_es()
        ElseIf soption.Text = "specific_school" Then
            Chart1.ResetAutoValues()
            Chart1.Series.Clear()
            Chart1.Series.Add("SS MOOE")
            Chart1.Series("SS MOOE").ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart1.Series("SS MOOE").IsValueShownAsLabel = True
            loadschool_sname_es()
        End If
    End Sub
    Sub loadschool_name_es()

        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader

        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            squery = "SELECT school_name,region,division,sum(ammount) as 'total',school_year FROM depedkms.mooe where offering='HIGHSCHOOL' and    division like'%" & division.Text & "%' and region like'%" & regional.Text & "%' group by school_name,school_year order by school_name,school_year "
            conn.Open()
            com = New MySqlCommand(squery, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart1.Series("SS MOOE").Points.AddXY(READER.GetString("school_name") & " " & READER.GetString("school_year"), READER.GetFloat("total"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub loadschool_sname_es()

        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader

        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            squery = "SELECT school_name,region,division,sum(ammount) as 'total',school_year FROM depedkms.mooe where offering='HIGHSCHOOL' and   school_name like'%" & sname.Text & "%' and division like'%" & division.Text & "%'  and   region like'%" & regional.Text & "%' group by school_name,school_year order by school_name,school_year"
            conn.Open()
            com = New MySqlCommand(squery, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart1.Series("SS MOOE").Points.AddXY(READER.GetString("school_name") & " " & READER.GetString("school_year"), READER.GetFloat("total"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub loadschool_division_es()

        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader

        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            squery = "SELECT school_name,region,division,sum(ammount) as 'total',school_year FROM depedkms.mooe where offering='HIGHSCHOOL' and    region like'%" & regional.Text & "%' group by division,school_year order by division,school_year"
            conn.Open()
            com = New MySqlCommand(squery, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart1.Series("SS MOOE").Points.AddXY(READER.GetString("division") & " " & READER.GetString("school_year"), READER.GetFloat("total"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub




    Sub loadschool_region_es()

        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader

        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            squery = "SELECT school_name,region,division,sum(ammount) as 'total',school_year FROM depedkms.mooe where offering='HIGHSCHOOL' group by region,school_year order by region,school_year "
            conn.Open()
            com = New MySqlCommand(squery, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart1.Series("SS MOOE").Points.AddXY(READER.GetString("region") & " " & READER.GetString("school_year"), READER.GetFloat("total"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub sname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles sname.SelectedIndexChanged

    End Sub
End Class