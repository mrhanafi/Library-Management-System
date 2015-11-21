Imports System.Data.OleDb
Public Class maklumat_buku
    Dim ds As DataSet
    Dim row As Integer
    Dim dt As New DataTable("buku")
    Dim q As Integer
    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dbconn As System.Data.OleDb.OleDbConnection
        dbconn = New System.Data.OleDb.OleDbConnection
        dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
        Dim cmd As New OleDb.OleDbCommand
        Try
            dbconn.Open()
            cmd.Connection = dbconn
            cmd.CommandText = "insert into maklumatbuku(NomborBuku,Tajuk,Kategori,NomborIsbn,JumlahBuku,Pengarang,Penerbit,NomborRak,BarisRak,TahunTerbit) values(@a,@b,@c,@d,@e,@f,@g,@h,@i,@j);"
            cmd.Parameters.AddWithValue("@a", TextBox1.Text)
            cmd.Parameters.AddWithValue("@b", TextBox2.Text)
            cmd.Parameters.AddWithValue("@c", TextBox3.Text)
            cmd.Parameters.AddWithValue("@d", TextBox4.Text)
            cmd.Parameters.AddWithValue("@e", TextBox5.Text)
            cmd.Parameters.AddWithValue("@f", TextBox6.Text)
            cmd.Parameters.AddWithValue("@g", TextBox7.Text)
            cmd.Parameters.AddWithValue("@h", TextBox8.Text)
            cmd.Parameters.AddWithValue("@i", TextBox9.Text)
            cmd.Parameters.AddWithValue("@j", TextBox10.Text)
            cmd.ExecuteNonQuery()

            dbconn.Close()
            MsgBox("Maklumat Buku Berjaya Disimpan.")
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""
            TextBox10.Text = ""
            datagrid()
        Catch ex As Exception
            MsgBox(ErrorToString)
        End Try
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim dbconn As System.Data.OleDb.OleDbConnection

        dbconn = New System.Data.OleDb.OleDbConnection
        dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
        Dim cmd As New OleDb.OleDbCommand
        Try
            dbconn.Open()
            cmd.Connection = dbconn
            cmd.CommandText = "delete from maklumatbuku where ID=@a;"
            cmd.Parameters.AddWithValue("@a", DataGridView1.Item(0, q).Value)
            cmd.ExecuteNonQuery()
            dbconn.Close()
            MsgBox("buang berjaya")
            datagrid()
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""
            TextBox10.Text = ""

        Catch ex As Exception
            MsgBox("gagal berjaya")
        End Try
    End Sub
    Public Sub datagrid()
        dt.Clear()
        Dim dbconn As System.Data.OleDb.OleDbConnection

        dbconn = New System.Data.OleDb.OleDbConnection
        dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
        Dim sqlsearch As String
        sqlsearch = "SELECT * FROM maklumatbuku"
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

    Private Sub maklumat_buku_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        datagrid()
    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        q = DataGridView1.CurrentRow.Index
        TextBox1.Text = DataGridView1.Item(1, q).Value
        TextBox2.Text = DataGridView1.Item(2, q).Value
        TextBox3.Text = DataGridView1.Item(3, q).Value
        TextBox4.Text = DataGridView1.Item(4, q).Value
        TextBox5.Text = DataGridView1.Item(5, q).Value
        TextBox6.Text = DataGridView1.Item(6, q).Value
        TextBox7.Text = DataGridView1.Item(7, q).Value
        TextBox8.Text = DataGridView1.Item(9, q).Value
        TextBox9.Text = DataGridView1.Item(10, q).Value
        TextBox10.Text = DataGridView1.Item(8, q).Value
    End Sub
End Class