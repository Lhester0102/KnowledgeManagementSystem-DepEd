﻿Imports MySql.Data.MySqlClient
Public Class water

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.ShowDialog()

        Try
            Dim myconnection As System.Data.OleDb.OleDbConnection
            Dim dataset As System.Data.DataSet
            Dim command As System.Data.OleDb.OleDbDataAdapter
            Dim path As String = OpenFileDialog1.FileName
            Me.Text = path
            '"F:\KM Deped\Data\SY 2012 2013 Public Schools Enrolment.xls"
            myconnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.jet.oledb.4.0;data source=" + path + ";Extended Properties= Excel 8.0;")
            command = New System.Data.OleDb.OleDbDataAdapter("select * from [" & TextBox2.Text & "$]", myconnection)
            dataset = New System.Data.DataSet
            command.Fill(dataset)
            DataGridView1.DataSource = dataset.Tables(0)
            myconnection.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("ready")
        MsgBox(DataGridView1.ColumnCount & " " & DataGridView1.Rows.Count)
        Dim strData(100) As String
        For a = Val(TextBox3.Text) To DataGridView1.Rows.Count - 2
            For b = 0 To DataGridView1.ColumnCount - 1
                strData(b) = DataGridView1.Rows(a).Cells(b).Value.ToString
                If strData(0) = "" Then
                    Label3.Text = 0
                    Exit Sub
                End If
            Next


            Dim query As String
            Dim READER As MySqlDataReader
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            conn = New MySqlConnection
            conn.ConnectionString = "server=localhost;userid=root;password=user;database=depedkms"
            Try
                conn.Open()
                query = "INSERT INTO `depedkms`.`water` (`school_id`, `school_name`, `region`, `province`, `municipality`, `division`, `district`, `local_piped`, `well_warter_deep_well`, `rain_warer_cathment`, `natural_source`, `without_available_water_supply`, `school_year`, `school_type`) VALUES ('" & strData(0) & "', '" & strData(1) & "', '" & strData(2) & "', '" & strData(3) & "', '" & strData(4) & "', '" & strData(5) & "', '" & strData(6) & "', '" & strData(7) & "', '" & strData(8) & "', '" & strData(9) & "', '" & strData(10) & "', '" & strData(11) & "', '" & TextBox1.Text & "', '" & ComboBox3.Text & "')"
                com = New MySqlCommand(query, conn)
                READER = com.ExecuteReader
                Me.Text = DataGridView1.Rows(a).Cells(0).Value.ToString
                Label3.Text = "remaining record:" & (DataGridView1.Rows.Count - 2) - a
                conn.Close()
                Threading.Thread.Sleep(1)
                Application.DoEvents()
                '  MsgBox("NEW USER ACOUNT IS CREATED...", vbInformation)
            Catch ex As Exception
                MsgBox(ex.ToString())
                ComboBox2.Items.Add(a & " " & strData(2) & " " & ex.ToString)
            End Try
        Next
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class
