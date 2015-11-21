Imports System.Data.OleDb
Public Class ubahpenetapan
    Dim dt As New DataTable("penetapan")
    Dim nmbr As Integer
    Private Sub ubahpenetapan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        datagrid()
    End Sub
    Public Sub datagrid()
        Dim dbconn As System.Data.OleDb.OleDbConnection
        dbconn = New System.Data.OleDb.OleDbConnection
        dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
        Dim sqlsearch As String
        sqlsearch = "SELECT * FROM penetapan"
        Dim adapter As New OleDbDataAdapter(sqlsearch, dbconn)

        dbconn.Open()
        adapter.Fill(dt)
        dbconn.Close()
        TextBox5.Text = dt.Rows(nmbr)("kod")
        TextBox1.Text = dt.Rows(nmbr)("nama")
        TextBox2.Text = dt.Rows(nmbr)("alamat")
        TextBox4.Text = dt.Rows(nmbr)("email")
        TextBox3.Text = dt.Rows(nmbr)("telefon")

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        tetap()
    End Sub
    Public Sub tetap()
        Dim status As String = "yes"
        Dim dbconn As System.Data.OleDb.OleDbConnection

        dbconn = New System.Data.OleDb.OleDbConnection
        dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
        Dim cmd As New OleDb.OleDbCommand
        Try
            dbconn.Open()
            cmd.Connection = dbconn
            cmd.CommandText = "update penetapan set nama=@a,status=@b,alamat=@c,kod=@d,telefon=@e,email=@f where ID = 1;"
            cmd.Parameters.AddWithValue("@a", TextBox1.Text)
            cmd.Parameters.AddWithValue("@b", status)
            cmd.Parameters.AddWithValue("@c", TextBox2.Text)
            cmd.Parameters.AddWithValue("@d", TextBox5.Text)
            cmd.Parameters.AddWithValue("@e", TextBox3.Text)
            cmd.Parameters.AddWithValue("@f", TextBox4.Text)

            cmd.ExecuteNonQuery()

            dbconn.Close()
            MsgBox("Penetapan Selesai")
            Me.Close()
        Catch ex As Exception
            MsgBox("Gagal Menyimpan Data. Sila Cuba Lagi")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class