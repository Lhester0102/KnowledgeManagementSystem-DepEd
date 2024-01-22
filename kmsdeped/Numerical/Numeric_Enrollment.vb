Imports MySql.Data.MySqlClient
Public Class Numeric_Enrollment
    Dim query As String = ""
    Sub loadsy()
        ComboBox2.Items.Clear()
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim READER As MySqlDataReader
        Dim squery As String
        conn = New MySqlConnection
        conn.ConnectionString = "server=localhost;userid=root;password=user;database=depedkms"
        Try
            squery = "select distinct school_year from enrollment"
            conn.Open()
            com = New MySqlCommand(squery, conn)
            READER = com.ExecuteReader
            While READER.Read
                ComboBox2.Items.Add(READER.GetString(0).ToString)
            End While
            conn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub loadusers()
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim sd = New MySqlDataAdapter
        Dim dsource = New BindingSource
        Dim dset As DataTable
        dset = New DataTable

        conn = New MySqlConnection
        conn.ConnectionString = "server=localhost;userid=root;password=user;database=depedkms"
        Try
            conn.Open()
            com = New MySqlCommand(query, conn)
            sd.SelectCommand = com
            sd.Fill(dset)
            dsource.DataSource = dset
            DataGridView1.DataSource = dsource
            sd.Update(dset)
            conn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub loadusers2()
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim sd = New MySqlDataAdapter
        Dim dsource = New BindingSource
        Dim dset As DataTable
        dset = New DataTable

        conn = New MySqlConnection
        conn.ConnectionString = "server=localhost;userid=root;password=user;database=depedkms"
        Try
            conn.Open()
            com = New MySqlCommand(query, conn)
            sd.SelectCommand = com
            sd.Fill(dset)
            dsource.DataSource = dset
            DataGridView2.DataSource = dsource
            sd.Update(dset)
            conn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Numeric_Enrollment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadsy()

        query = "Select region,school_year, sum(grand_total) from enrollment group by region,school_year  order by region,school_year"
        loadusers()
        query = "Select region,school_year, sum(grandtotal) from highschool group by region,school_year  order by region,school_year"
        loadusers2()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "region" Then
            query = "Select region,school_year, sum(grand_total) from enrollment group by region,school_year  order by region,school_year"
            loadusers()
            query = "Select region,school_year, sum(grandtotal) from highschool group by region,school_year  order by region,school_year"
            loadusers2()
        ElseIf ComboBox1.Text = "division" Then
            query = "Select division,school_year, sum(grand_total) from enrollment group by division,school_year  order by division,school_year"
            loadusers()
            query = "Select division,school_year, sum(grandtotal) from highschool group by division,school_year  order by division,school_year"
            loadusers2()
        ElseIf ComboBox1.Text = "municipality" Then
            query = "Select municipality,school_year, sum(grand_total) from enrollment group by municipality,school_year  order by municipality,school_year"
            loadusers()
            query = "Select municipality,school_year, sum(grandtotal) from highschool group by municipality,school_year  order by municipality,school_year"
            loadusers2()
        ElseIf ComboBox1.Text = "province" Then
            query = "Select province,school_year, sum(grand_total) from enrollment group by province,school_year  order by province,school_year"
            loadusers()
            query = "Select province,school_year, sum(grandtotal) from highschool group by province,school_year  order by province,school_year"
            loadusers2()
        ElseIf ComboBox1.Text = "school_name" Then
            query = "Select school_name,school_year, sum(grand_total) from enrollment group by school_name,school_year  order by school_name,school_year"
            loadusers()
            query = "Select school_name,school_year, sum(grandtotal) from highschool group by school_name,school_year  order by school_name,school_year"
            loadusers2()
        End If

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub
End Class