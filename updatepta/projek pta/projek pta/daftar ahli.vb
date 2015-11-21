Imports System.Data.OleDb
Public Class daftar_ahli
    Dim cari As Integer
    Dim updatedb As Boolean = False
    Dim id As String
    Dim counter As Integer = 0
    Dim dt As New DataTable("nombor")
    'Dim inc = counter.ToString("0000")
    Private Sub daftar_ahli_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        datagrid()
        TextBox1.Text = Format(FindMaxDataTableValue(dt) + 1, "0000")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim dbconn As System.Data.OleDb.OleDbConnection
            dbconn = New System.Data.OleDb.OleDbConnection
            dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
            Dim cmd As New OleDb.OleDbCommand
            Try
                dbconn.Open()
                cmd.Connection = dbconn
                cmd.CommandText = "insert into DaftarAhli(NomborAhli, Nama, Alamat, NomborTelifon, Status, Kategori, Kelas, depan) values(@a,@b,@c,@d,@e,@f,@g,@h);"
                cmd.Parameters.AddWithValue("@a", TextBox1.Text)
                cmd.Parameters.AddWithValue("@b", TextBox2.Text)
                cmd.Parameters.AddWithValue("@c", TextBox3.Text)
                cmd.Parameters.AddWithValue("@d", TextBox4.Text)
                cmd.Parameters.AddWithValue("@e", ComboBox2.Text)
                cmd.Parameters.AddWithValue("@f", ComboBox3.Text)
                cmd.Parameters.AddWithValue("@g", TextBox5.Text)
                cmd.Parameters.AddWithValue("@h", ComboBox1.Text)
                cmd.ExecuteNonQuery()
                dbconn.Close()
                MsgBox("Pendaftaran Item Berjaya. Data Telah Disimpan.")
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                ComboBox1.SelectedIndex = -1
                ComboBox2.SelectedIndex = -1
                ComboBox3.SelectedIndex = -1
                counter = Format(counter + 1, "0000")
            Catch ex As Exception
                MsgBox("Gagal Menyimpan Data. Sila Cuba Lagi")
            End Try
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
    Public Sub datagrid()
        Dim dbconn As System.Data.OleDb.OleDbConnection
        dbconn = New System.Data.OleDb.OleDbConnection
        dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
        Dim sqlsearch As String
        sqlsearch = "SELECT NomborAhli FROM DaftarAhli"
        Dim adapter As New OleDbDataAdapter(sqlsearch, dbconn)
        dbconn.Open()
        adapter.Fill(dt)
        dbconn.Close()
    End Sub
    Private Function FindMaxDataTableValue(ByRef dt As DataTable) As Integer
        Dim currentValue As Integer, maxValue As Integer
        Dim rowIndex As Integer, colIndex As Integer
        Dim dv As DataView = dt.DefaultView
        For c As Integer = 0 To dt.Columns.Count - 1
            dv.Sort = dt.Columns(c).ColumnName + " DESC"
            currentValue = CInt(dv(0).Item(c).ToString)
            If currentValue > maxValue Then
                rowIndex = dt.Rows.IndexOf(dv(0).Row)
                colIndex = c
                maxValue = currentValue.ToString()
            End If
        Next
        Return maxValue
    End Function
End Class