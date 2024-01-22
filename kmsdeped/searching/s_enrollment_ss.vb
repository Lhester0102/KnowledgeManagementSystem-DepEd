﻿Imports MySql.Data.MySqlClient
Public Class s_enrollment_ss
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
            query = "SELECT distinct school_year from highschool order by school_year"
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
            query = "SELECT distinct region from highschool order by region"
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
    Private Sub s_enrollment_ss_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        regional.Visible = False
        province.Visible = False
        division.Visible = False

        municipality.Visible = False
        sname.Visible = False
        load_cm_region()
        load_sy()
        Chart1.Series.Clear()
        Chart1.Series.Add("SS Enrollees")
        Chart1.Series("SS Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Bar
    End Sub

    Private Sub soption_SelectedIndexChanged(sender As Object, e As EventArgs) Handles soption.SelectedIndexChanged
        visi()
    End Sub
    Sub visi()
        If soption.Text = "school_name" Then
            regional.Visible = True
            province.Visible = True
            division.Visible = True

            municipality.Visible = True
            sname.Visible = False
        ElseIf soption.Text = "specific_school" Then
            regional.Visible = True
            province.Visible = True
            division.Visible = True

            municipality.Visible = True
            sname.Visible = True
        ElseIf soption.Text = "municipality" Then
            regional.Visible = True
            province.Visible = True
            division.Visible = True

            municipality.Visible = False
            sname.Visible = False

        ElseIf soption.Text = "district" Then
            regional.Visible = True
            province.Visible = True
            division.Visible = True

            municipality.Visible = False
            sname.Visible = False
        ElseIf soption.Text = "division" Then
            regional.Visible = True
            province.Visible = True
            division.Visible = False

            municipality.Visible = False
            sname.Visible = False
        ElseIf soption.Text = "province" Then
            regional.Visible = True
            province.Visible = False
            division.Visible = False

            municipality.Visible = False
            sname.Visible = False
        ElseIf soption.Text = "region" Then
            regional.Visible = False
            province.Visible = False
            division.Visible = False

            municipality.Visible = False
            sname.Visible = False
        End If
    End Sub
    Private Sub regional_SelectedIndexChanged(sender As Object, e As EventArgs) Handles regional.SelectedIndexChanged
        province.Items.Clear()

        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT distinct province from highschool where region='" & regional.Text & "' order by province"
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                province.Items.Add(READER.GetString("province").ToString)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub province_SelectedIndexChanged(sender As Object, e As EventArgs) Handles province.SelectedIndexChanged
        division.Items.Clear()

        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT distinct division from highschool where region='" & regional.Text & "' and province='" & province.Text & "' order by division"
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                division.Items.Add(READER.GetString(0).ToString)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub division_SelectedIndexChanged(sender As Object, e As EventArgs) Handles division.SelectedIndexChanged
        municipality.Items.Clear()

        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT distinct municipality from highschool where region='" & regional.Text & "' and province='" & province.Text & "'  and division='" & division.Text & "' order by municipality"
            conn.Open()
            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            While READER.Read
                municipality.Items.Add(READER.GetString(0).ToString)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub municipality_SelectedIndexChanged(sender As Object, e As EventArgs) Handles municipality.SelectedIndexChanged
        sname.Items.Clear()

        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim query As String
        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            query = "SELECT distinct school_name from highschool where region='" & regional.Text & "' and province='" & province.Text & "'  and division='" & division.Text & "' and municipality='" & municipality.Text & "' order by school_name"
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If soption.Text = "school_name" Then
            Chart1.ResetAutoValues()
            Chart1.Series.Clear()
            Chart1.Series.Add("SS Enrollees")
            Chart1.Series("SS Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart1.Series("SS Enrollees").IsValueShownAsLabel = True
            loadschool_name_es()
        ElseIf soption.Text = "municipality" Then
            Chart1.ResetAutoValues()
            Chart1.Series.Clear()
            Chart1.Series.Add("SS Enrollees")
            Chart1.Series("SS Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart1.Series("SS Enrollees").IsValueShownAsLabel = True
            loadschool_municipality_es()
        ElseIf soption.Text = "division" Then
            Chart1.ResetAutoValues()
            Chart1.Series.Clear()
            Chart1.Series.Add("SS Enrollees")
            Chart1.Series("SS Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart1.Series("SS Enrollees").IsValueShownAsLabel = True
            loadschool_division_es()
     
        ElseIf soption.Text = "province" Then
            Chart1.ResetAutoValues()
            Chart1.Series.Clear()
            Chart1.Series.Add("SS Enrollees")
            Chart1.Series("SS Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart1.Series("SS Enrollees").IsValueShownAsLabel = True
            loadschool_province_es()
        ElseIf soption.Text = "region" Then
            Chart1.ResetAutoValues()
            Chart1.Series.Clear()
            Chart1.Series.Add("SS Enrollees")
            Chart1.Series("SS Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart1.Series("SS Enrollees").IsValueShownAsLabel = True
            loadschool_region_es()
        ElseIf soption.Text = "specific_school" Then
            Chart1.ResetAutoValues()
            Chart1.Series.Clear()
            Chart1.Series.Add("SS Enrollees")
            Chart1.Series("SS Enrollees").ChartType = DataVisualization.Charting.SeriesChartType.Column
            Chart1.Series("SS Enrollees").IsValueShownAsLabel = True
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
            squery = "SELECT school_name,region,province,division,municipality,sum(grandtotal) as 'total',school_year FROM depedkms.highschool where  municipality like'%" & municipality.Text & "%' and division like'%" & division.Text & "%' and  province like'%" & province.Text & "%' and   region like'%" & regional.Text & "%'  group by school_name,school_year order by school_name,school_year "
                conn.Open()
                com = New MySqlCommand(squery, conn)
                READER = com.ExecuteReader
                While READER.Read
                    Chart1.Series("SS Enrollees").Points.AddXY(READER.GetString("school_name") & READER.GetString("school_year"), READER.GetFloat("total"))
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
            squery = "SELECT school_name,region,province,division,municipality,sum(grandtotal) as 'total',school_year FROM depedkms.highschool where  school_name like'%" & sname.Text & "%' and  municipality like'%" & municipality.Text & "%'  and  division like'%" & division.Text & "%' and  province like'%" & province.Text & "%' and   region like'%" & regional.Text & "%'  group by school_name,school_year order by school_name,school_year"
                conn.Open()
                com = New MySqlCommand(squery, conn)
                READER = com.ExecuteReader
                While READER.Read
                    Chart1.Series("SS Enrollees").Points.AddXY(READER.GetString("school_name") & READER.GetString("school_year"), READER.GetFloat("total"))
                End While
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
    End Sub
    Sub loadschool_municipality_es()

        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader

        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            squery = "SELECT school_name,region,province,division,municipality,sum(grandtotal) as 'total',school_year FROM depedkms.highschool where    division like'%" & division.Text & "%' and  province like'%" & province.Text & "%' and   region like'%" & regional.Text & "%' group by municipality,school_year order by municipality,school_year"
            conn.Open()
            com = New MySqlCommand(squery, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart1.Series("SS Enrollees").Points.AddXY(READER.GetString("municipality") & READER.GetString("school_year"), READER.GetFloat("total"))
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
            squery = "SELECT school_name,region,province,division,municipality,sum(grandtotal) as 'total',school_year FROM depedkms.highschool where  province like'%" & province.Text & "%' and   region like'%" & regional.Text & "%' group by division,school_year order by division,school_year"
            conn.Open()
            com = New MySqlCommand(squery, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart1.Series("SS Enrollees").Points.AddXY(READER.GetString("division") & READER.GetString("school_year"), READER.GetFloat("total"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub loadschool_province_es()

        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader

        Dim strcon As String = " server=localhost;userid=root;password=user;database=depedkms"
        conn = New MySqlConnection
        conn.ConnectionString = strcon
        Try
            squery = "SELECT school_name,region,province,division,municipality,sum(grandtotal) as 'total',school_year FROM depedkms.highschool where   region like'%" & regional.Text & "'  group by province,school_year order by province,school_year"
            conn.Open()
            com = New MySqlCommand(squery, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart1.Series("SS Enrollees").Points.AddXY(READER.GetString("province") & " " & READER.GetString("school_year"), READER.GetFloat("total"))
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
            squery = "SELECT school_name,region,province,division,municipality,sum(grandtotal) as 'total',school_year FROM depedkms.highschool  group by region,school_year order by region,school_year "
            conn.Open()
            com = New MySqlCommand(squery, conn)
            READER = com.ExecuteReader
            While READER.Read
                Chart1.Series("SS Enrollees").Points.AddXY(READER.GetString("region") & " " & READER.GetString("school_year"), READER.GetFloat("total"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class