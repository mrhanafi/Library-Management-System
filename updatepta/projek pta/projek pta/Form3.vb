Imports System.Data.OleDb
Public Class Form3
    Dim dt As New DataTable("penetapan")
    Dim nmbr As Integer

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
            Me.Hide()
            Form1.Show()
        Catch ex As Exception
            MsgBox("Gagal Menyimpan Data. Sila Cuba Lagi")
        End Try
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    'Public Sub datagrid()
    '    Dim dbconn As System.Data.OleDb.OleDbConnection
    '    dbconn = New System.Data.OleDb.OleDbConnection
    '    dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
    '    Dim sqlsearch As String
    '    sqlsearch = "SELECT * FROM penetapan"
    '    Dim adapter As New OleDbDataAdapter(sqlsearch, dbconn)

    '    dbconn.Open()
    '    adapter.Fill(dt)
    '    dbconn.Close()


    'End Sub
End Class