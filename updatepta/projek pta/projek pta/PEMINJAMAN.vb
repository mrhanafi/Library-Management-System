
Imports System.Data.OleDb
Public Class PEMINJAMAN
    Dim datepinjam As DateTime
    Dim datepulang As DateTime
    Dim diff As System.TimeSpan
    Dim pinjam As String
    Dim pulang As String
    Dim ds As New DataSet
    Public dbconn As New OleDbConnection
    Public acsdr As OleDbDataReader
    Public acsda As New OleDbDataAdapter
    Public acscmd As New OleDbCommand
    Public strsql As String
    Public acds As New DataSet
    Public acdt As New DataTable
    Public str As String
    Dim dt As New DataTable("peminjam")
    Dim q As Integer
    Private Sub PEMINJAMAN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'showdata()
        datagrid()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        datepinjam = Convert.ToDateTime(DateTimePicker1.Text)
        datepulang = Convert.ToDateTime(DateTimePicker2.Text)
        pinjam = Format(datepinjam, "dd/MM/yyyy")
        pulang = Format(datepulang, "dd/MM/yyyy")

        Dim dbconn As System.Data.OleDb.OleDbConnection

        dbconn = New System.Data.OleDb.OleDbConnection
        dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
        Dim cmd As New OleDb.OleDbCommand
        Try
            dbconn.Open()
            cmd.Connection = dbconn
            cmd.CommandText = "insert into peminjaman(IdPeminjam,IdBuku,Kelas,Tajuk,TarikhPinjam,TarikhPulang) values(@a,@b,@c,@d,@e,@f);"
            cmd.Parameters.AddWithValue("@a", TextBox1.Text)
            cmd.Parameters.AddWithValue("@b", TextBox2.Text)
            cmd.Parameters.AddWithValue("@c", TextBox3.Text)
            cmd.Parameters.AddWithValue("@d", TextBox4.Text)
            cmd.Parameters.AddWithValue("@e", pinjam)
            cmd.Parameters.AddWithValue("@f", pulang)

            cmd.ExecuteNonQuery()

            dbconn.Close()
            MsgBox("Pendaftaran Item Berjaya. Data Telah Disimpan.")
            'showdata()
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            datagrid()
        Catch ex As Exception
            MsgBox(ErrorToString)
        End Try
    End Sub

    'Public Sub showdata()
    '    Dim oleConn As System.Data.OleDb.OleDbConnection
    '    Dim da As OleDb.OleDbDataAdapter
    '    ds = New DataSet
    '    oleConn = New System.Data.OleDb.OleDbConnection
    '    oleConn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
    '    oleConn.Open()
    '    da = New OleDb.OleDbDataAdapter("SELECT * FROM Peminjam", oleConn)
    '    da.Fill(ds, "peminjam")
    '    oleConn.Close()
    '    ListView1.Clear()
    '    With ListView1
    '        .Items.Clear()
    '        .View = View.Details
    '        .GridLines = True
    '        .FullRowSelect = True
    '        .Columns.Add("ID", 0, HorizontalAlignment.Left)
    '        .Columns.Add("ID PEMINJAM", 100, HorizontalAlignment.Left)
    '        .Columns.Add("ID BUKU", 100, HorizontalAlignment.Left)
    '        .Columns.Add("KELAS / BAHAGIAN", 150, HorizontalAlignment.Left)
    '        .Columns.Add("TAJUK", 150, HorizontalAlignment.Left)
    '        .Columns.Add("TARIKH PINJAM", 150, HorizontalAlignment.Left)
    '        .Columns.Add("TARIKH PULANG", 150, HorizontalAlignment.Left)
    '    End With
    '    For Each row As DataRow In ds.Tables("peminjam").Rows
    '        Dim lst As ListViewItem
    '        lst = ListView1.Items.Add(row(0))
    '        For i As Integer = 1 To ds.Tables("peminjam").Columns.Count - 1
    '            lst.SubItems.Add(row(i))
    '        Next
    '    Next
    'End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If Halaman_masuk.admin = True Then
            halaman_masuk_admin_user.Show()
            Me.Close()
        ElseIf Halaman_masuk.user = True Then
            Form2.Show()
            Me.Close()
        End If
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Public Sub datagrid()
        dt.Clear()
        Dim dbconn As System.Data.OleDb.OleDbConnection

        dbconn = New System.Data.OleDb.OleDbConnection
        dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
        Dim sqlsearch As String
        sqlsearch = "SELECT * FROM Peminjaman"
        Dim adapter As New OleDbDataAdapter(sqlsearch, dbconn)
        ' Dim dt As New DataTable("peminjam")
        dbconn.Open()
        adapter.Fill(dt)
        DataGridView1.DataSource = dt
        Dim dgvColumnHeaderStyle As New DataGridViewCellStyle()
        dgvColumnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.ColumnHeadersDefaultCellStyle = dgvColumnHeaderStyle
        dbconn.Close()
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim dbconn As System.Data.OleDb.OleDbConnection

        dbconn = New System.Data.OleDb.OleDbConnection
        dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
        Dim cmd As New OleDb.OleDbCommand
        Try
            dbconn.Open()
            cmd.Connection = dbconn
            cmd.CommandText = "delete from peminjaman where ID=@a;"
            cmd.Parameters.AddWithValue("@a", DataGridView1.Item(0, q).Value)


            cmd.ExecuteNonQuery()

            dbconn.Close()
            MsgBox("buang berjaya")
            datagrid()
        Catch ex As Exception
            MsgBox("gagal berjaya")
        End Try
    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        q = DataGridView1.CurrentRow.Index
        TextBox1.Text = DataGridView1.Item(1, q).Value
        TextBox2.Text = DataGridView1.Item(2, q).Value
        TextBox3.Text = DataGridView1.Item(3, q).Value
        TextBox4.Text = DataGridView1.Item(4, q).Value
        datepinjam = Convert.ToDateTime(DataGridView1.Item(5, q).Value)
        datepulang = Convert.ToDateTime(DataGridView1.Item(6, q).Value)

        DateTimePicker1.Text = datepinjam
        DateTimePicker2.Text = datepulang
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

    End Sub
End Class