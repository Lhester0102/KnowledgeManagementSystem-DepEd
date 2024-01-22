Imports MySql.Data.MySqlClient
Public Class enrollment_highschool

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
            Next
            Dim query As String
            Dim READER As MySqlDataReader
            Dim conn As MySqlConnection
            Dim com As MySqlCommand
            conn = New MySqlConnection
            conn.ConnectionString = "server=localhost;userid=root;password=user;database=depedkms"
            Try
                conn.Open()
                query = "INSERT INTO `depedkms`.`highschool` (`school_id`, `school_name`, `region`, `province`, `municipality`, `division`, `year1_m`, `year1_f`, `year1_total`, `year2_m`, `year2_f`, `year2_total`, `year3_m`, `year3_f`, `year3_total`, `year4_m`, `year4_f`, `year4_total`,g11_m,g11_f,g11_total,g12_m,g12_f,g12_total,sped_m,sped_f,sped_total, `male_total`, `female_total`, `grandtotal`,school_year) VALUES ('" & strData(0) & "', '" & strData(1) & "', '" & strData(2) & "', '" & strData(3) & "', '" & strData(4) & "', '" & strData(5) & "','" & strData(6) & "', '" & strData(7) & "', '" & strData(8) & "', '" & strData(9) & "', '" & strData(10) & "', '" & strData(11) & "', '" & strData(12) & "', '" & strData(13) & "', '" & strData(14) & "', '" & strData(15) & "', '" & strData(16) & "', '" & strData(17) & "', '" & strData(18) & "', '" & strData(19) & "', '" & strData(20) & "',  '" & strData(21) & "', '" & strData(22) & "', '" & strData(23) & "', '" & strData(24) & "', '" & strData(25) & "', '" & strData(26) & "', '" & strData(27) & "', '" & strData(28) & "', '" & strData(29) & "', '" & TextBox1.Text & "')"
                '    query = "INSERT INTO `depedkms`.`highschool` (`school_id`, `school_name`, `region`, `province`, `municipality`, `division`, `year1_m`, `year1_f`, `year1_total`, `year2_m`, `year2_f`, `year2_total`, `year3_m`, `year3_f`, `year3_total`, `year4_m`, `year4_f`, `year4_total`, `male_total`, `female_total`, `grandtotal`,school_year) VALUES ('" & strData(0) & "', '" & strData(1) & "', '" & strData(2) & "', '" & strData(3) & "', '" & strData(4) & "', '" & strData(5) & "', '" & strData(6) & "', '" & strData(7) & "', '" & strData(8) & "', '" & strData(9) & "', '" & strData(10) & "', '" & strData(11) & "', '" & strData(12) & "', '" & strData(13) & "', '" & strData(14) & "', '" & strData(15) & "', '" & strData(16) & "', '" & strData(17) & "', '" & strData(18) & "', '" & strData(19) & "', '" & strData(20) & "', '" & TextBox1.Text & "')"
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
                ComboBox2.Items.Add(a & " " & strData(0) & " " & ex.ToString)
            End Try
            'For q = 0 To DataGridView1.ColumnCount - 1
            '    strData(q) = ""
            'Next

        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class
