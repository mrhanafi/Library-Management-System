Imports System.Data.OleDb
Public Class pemulangan
    Dim nmbr As Integer
    Dim tarikhskarang As DateTime = DateTime.Now
    Dim datepinjam As DateTime
    Dim datepulang As DateTime
    Dim skarang As String
    Dim pulang As String
    Dim tolak As System.TimeSpan
    Dim denda As Decimal
    Dim denda1 As Decimal
    Dim pinjam As String
    Dim q As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            datagrid()
            Label8.Text = ""
            Label9.Text = ""
            Label10.Text = ""
            Label11.Text = ""
            Label12.Text = ""
        Else
            Dim dbconn As System.Data.OleDb.OleDbConnection
            dbconn = New System.Data.OleDb.OleDbConnection
            dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
            Dim sqlsearch As String
            sqlsearch = "SELECT * FROM Peminjaman WHERE IdPeminjam ='" & TextBox1.Text & "'"
            Dim adapter As New OleDbDataAdapter(sqlsearch, dbconn)
            Dim dt As New DataTable("peminjam")
            dbconn.Open()
            adapter.Fill(dt)
            DataGridView1.DataSource = dt
            Dim dgvColumnHeaderStyle As New DataGridViewCellStyle()
            dgvColumnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.ColumnHeadersDefaultCellStyle = dgvColumnHeaderStyle
            dbconn.Close()
            q = dt.Rows(nmbr)("ID")
            Label8.Text = dt.Rows(nmbr)("IdBuku")
            Label10.Text = dt.Rows(nmbr)("Kelas")
            Label9.Text = dt.Rows(nmbr)("Tajuk")
            Label11.Text = dt.Rows(nmbr)("TarikhPinjam")
            Label12.Text = dt.Rows(nmbr)("TarikhPulang")

            datepulang = Convert.ToDateTime(dt.Rows(nmbr)("TarikhPulang"))
            tolak = datepulang.Subtract(tarikhskarang)

            If tolak.Days < 0 Then
                denda = tolak.Days * 0.5
                denda1 = (denda * (-2)) + denda
                MsgBox("Pemulangan Buku Adalah Lewat Dari Tarikh Pulang. Denda RM" + denda1.ToString("N2") + " Akan Dikenakan.")
                Label14.Text = "Denda RM" + denda1.ToString("N2")
            Else
                If tolak.Days = "0" Then
                    MsgBox("Tarikh Pemulangan Buku Adalah Pada Hari Ini.")
                    Label14.Text = "Pemulangan Buku Hari Ini"
                Else
                    MsgBox("masih ada " + tolak.Days.ToString + " hari lagi")
                    Label14.Text = "Pemulangan " + tolak.Days.ToString + " hari lagi"
                End If
            End If
        End If
    End Sub


    Public Sub datagrid()
        Dim dbconn As System.Data.OleDb.OleDbConnection
        dbconn = New System.Data.OleDb.OleDbConnection
        dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
        Dim sqlsearch As String
        sqlsearch = "SELECT IdPeminjam,IdBuku,Kelas,Tajuk,TarikhPinjam,TarikhPulang FROM peminjaman"
        Dim adapter As New OleDbDataAdapter(sqlsearch, dbconn)
        Dim dt As New DataTable("peminjam")
        dbconn.Open()
        adapter.Fill(dt)
        DataGridView1.DataSource = dt
        Dim dgvColumnHeaderStyle As New DataGridViewCellStyle()
        dgvColumnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dbconn.Close()
    End Sub

    Private Sub pemulangan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        datagrid()
    End Sub
    Public Sub tambah()
        Dim dbconn As System.Data.OleDb.OleDbConnection

        dbconn = New System.Data.OleDb.OleDbConnection
        dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
        Dim cmd As New OleDb.OleDbCommand
        Try
            dbconn.Open()
            cmd.Connection = dbconn
            cmd.CommandText = "insert into Pemulangan(IdPeminjam,IdBuku,Kelas,Tajuk,TarikhPinjam,TarikhPulang) values(@a,@b,@c,@d,@e,@f);"
            cmd.Parameters.AddWithValue("@a", TextBox1.Text)
            cmd.Parameters.AddWithValue("@b", Label8.Text)
            cmd.Parameters.AddWithValue("@c", Label10.Text)
            cmd.Parameters.AddWithValue("@d", Label9.Text)
            cmd.Parameters.AddWithValue("@e", Label11.Text)
            cmd.Parameters.AddWithValue("@f", Label12.Text)
            cmd.ExecuteNonQuery()
            dbconn.Close()
            MsgBox("Pemulangan Selesai")
            TextBox1.Text = ""
            Label8.Text = ""
            Label9.Text = ""
            Label10.Text = ""
            Label11.Text = ""
            Label12.Text = ""

        Catch ex As Exception
            MsgBox("Gagal Menyimpan Data. Sila Cuba Lagi")
        End Try
    End Sub
    Public Sub delete()
        Dim dbconn As System.Data.OleDb.OleDbConnection
        dbconn = New System.Data.OleDb.OleDbConnection
        dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
        Dim cmd As New OleDb.OleDbCommand
        Try
            dbconn.Open()
            cmd.Connection = dbconn
            cmd.CommandText = "delete * from peminjaman where [IdPeminjam]=@a"
            cmd.Parameters.AddWithValue("@a", TextBox1.Text)
            cmd.ExecuteNonQuery()
            dbconn.Close()

        Catch ex As Exception
            'MsgBox("Gagal Menyimpan Data. Sila Cuba Lagi")
        End Try
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        delete()
        tambah()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        delete()
        tambah()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            datagrid()
            Label8.Text = ""
            Label9.Text = ""
            Label10.Text = ""
            Label11.Text = ""
            Label12.Text = ""
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        delete()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If Halaman_masuk.admin = True Then
            halaman_masuk_admin_user.Show()
            Me.Close()
        ElseIf Halaman_masuk.user = True Then
            Form2.Show()
            Me.Close()
        End If
    End Sub
End Class