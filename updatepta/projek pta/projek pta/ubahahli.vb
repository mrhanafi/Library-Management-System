Imports System.Data.OleDb

Public Class ubahahli
    Dim dt As New DataTable("ahli")
    Dim cari As Integer
    Dim id As String
    Private Sub ubahahli_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        datagrid()
    End Sub
    Public Sub datagrid()
        dt.Clear()
        Dim dbconn As System.Data.OleDb.OleDbConnection
        dbconn = New System.Data.OleDb.OleDbConnection
        dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
        Dim sqlsearch As String
        sqlsearch = "SELECT * FROM DaftarAhli"
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim dbconn As System.Data.OleDb.OleDbConnection
            dbconn = New System.Data.OleDb.OleDbConnection
            dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
            Dim sqlsearch As String
            sqlsearch = "SELECT * FROM DaftarAhli WHERE NomborAhli ='" & TextBox1.Text & "'"
            Dim adapter As New OleDbDataAdapter(sqlsearch, dbconn)
            dbconn.Open()
            adapter.Fill(dt)
            dbconn.Close()
            TextBox2.Text = dt.Rows(cari)("Nama")
            TextBox3.Text = dt.Rows(cari)("Alamat")
            TextBox4.Text = dt.Rows(cari)("NomborTelifon")
            TextBox5.Text = dt.Rows(cari)("Kelas")

            If dt.Rows(cari)("depan") = "03" Then
                ComboBox1.SelectedIndex = 0
            ElseIf dt.Rows(cari)("depan") = "04" Then
                ComboBox1.SelectedIndex = 1
            ElseIf dt.Rows(cari)("depan") = "05" Then
                ComboBox1.SelectedIndex = 2
            ElseIf dt.Rows(cari)("depan") = "06" Then
                ComboBox1.SelectedIndex = 3
            ElseIf dt.Rows(cari)("depan") = "07" Then
                ComboBox1.SelectedIndex = 4
            ElseIf dt.Rows(cari)("depan") = "08" Then
                ComboBox1.SelectedIndex = 5
            ElseIf dt.Rows(cari)("depan") = "09" Then
                ComboBox1.SelectedIndex = 6
            ElseIf dt.Rows(cari)("depan") = "010" Then
                ComboBox1.SelectedIndex = 7
            ElseIf dt.Rows(cari)("depan") = "011" Then
                ComboBox1.SelectedIndex = 8
            ElseIf dt.Rows(cari)("depan") = "012" Then
                ComboBox1.SelectedIndex = 9
            ElseIf dt.Rows(cari)("depan") = "013" Then
                ComboBox1.SelectedIndex = 10
            ElseIf dt.Rows(cari)("depan") = "014" Then
                ComboBox1.SelectedIndex = 11
            ElseIf dt.Rows(cari)("depan") = "015" Then
                ComboBox1.SelectedIndex = 12
            ElseIf dt.Rows(cari)("depan") = "016" Then
                ComboBox1.SelectedIndex = 13
            ElseIf dt.Rows(cari)("depan") = "017" Then
                ComboBox1.SelectedIndex = 14
            ElseIf dt.Rows(cari)("depan") = "018" Then
                ComboBox1.SelectedIndex = 15
            ElseIf dt.Rows(cari)("depan") = "019" Then
                ComboBox1.SelectedIndex = 16
            End If

            If dt.Rows(cari)("Status") = "BERKAHWIN" Then
                ComboBox2.SelectedIndex = 0
            ElseIf dt.Rows(cari)("Status") = "BUJANG" Then
                ComboBox2.SelectedIndex = 1
            ElseIf dt.Rows(cari)("Status") = "JANDA" Then
                ComboBox2.SelectedIndex = 2
            ElseIf dt.Rows(cari)("Status") = "DUDA" Then
                ComboBox2.SelectedIndex = 3
            End If

            If dt.Rows(cari)("Kategori") = "PELAJAR" Then
                ComboBox3.SelectedIndex = 0
            ElseIf dt.Rows(cari)("Kategori") = "PENGAJAR" Then
                ComboBox3.SelectedIndex = 1
            ElseIf dt.Rows(cari)("Kategori") = "ORANG AWAM" Then
                ComboBox3.SelectedIndex = 2
            ElseIf dt.Rows(cari)("Kategori") = "KAKITANGAN" Then
                ComboBox3.SelectedIndex = 3
            End If

            id = dt.Rows(cari)("ID")
            datagrid()
        Catch ex As Exception
            MsgBox("Data Tiada Dalam Senarai")
            TextBox1.Text = ""
        End Try
        
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim dbconn As System.Data.OleDb.OleDbConnection
        dbconn = New System.Data.OleDb.OleDbConnection
        dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
        Dim sqlsearch As String
        sqlsearch = "DELETE FROM DaftarAhli WHERE ID = " + id
        Dim adapter As New OleDbDataAdapter(sqlsearch, dbconn)
        Dim dt As New DataTable("delete")
        dbconn.Open()
        adapter.Fill(dt)
        dbconn.Close()
        MsgBox("berjaya dibuang")
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        datagrid()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Halaman_masuk.admin = True Then
            halaman_masuk_admin_user.Show()
            Me.Close()
        ElseIf Halaman_masuk.user = True Then
            Form2.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim dbconn As System.Data.OleDb.OleDbConnection
        dbconn = New System.Data.OleDb.OleDbConnection
        dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
        Dim cmd As New OleDb.OleDbCommand
        Try
            dbconn.Open()
            cmd.Connection = dbconn
            cmd.CommandText = "update DaftarAhli set NomborAhli=@a,Nama=@b,Alamat=@c,NomborTelifon=@d,Status=@e,Kategori=@f,Kelas=@g,depan=@h where ID=@i;"
            cmd.Parameters.AddWithValue("@a", TextBox1.Text)
            cmd.Parameters.AddWithValue("@b", TextBox2.Text)
            cmd.Parameters.AddWithValue("@c", TextBox3.Text)
            cmd.Parameters.AddWithValue("@d", TextBox4.Text)
            cmd.Parameters.AddWithValue("@e", ComboBox2.Text)
            cmd.Parameters.AddWithValue("@f", ComboBox3.Text)
            cmd.Parameters.AddWithValue("@g", TextBox5.Text)
            cmd.Parameters.AddWithValue("@h", ComboBox1.Text)
            cmd.Parameters.AddWithValue("@i", id)
            cmd.ExecuteNonQuery()
            dbconn.Close()
            MsgBox("Penetapan Selesai")
        Catch ex As Exception
            MsgBox("Gagal Menyimpan Data. Sila Cuba Lagi")
        End Try
    End Sub
End Class