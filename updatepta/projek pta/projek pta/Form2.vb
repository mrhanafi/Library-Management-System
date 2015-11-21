Imports System.Data.OleDb
Public Class Form2
    Dim dt As New DataTable("penetapan")
    Dim nmbr As Integer
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        laporan.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        maklumat_buku.Show()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        daftar_ahli.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        PEMINJAMAN.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        pemulangan.Show()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        pencarian_ringkasan.Show()
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        datagrid()
        If dt.Rows(nmbr)("nama").ToString = "" Then
            Label2.Text = ""
            Label3.Text = ""
            Label4.Text = ""
            Label5.Text = ""
            Label6.Text = ""
        Else
            Label2.Text = dt.Rows(nmbr)("nama").ToString
            Label3.Text = dt.Rows(nmbr)("alamat").ToString
            Label4.Text = dt.Rows(nmbr)("kod").ToString
            Label5.Text = dt.Rows(nmbr)("telefon").ToString
            Label6.Text = dt.Rows(nmbr)("email").ToString
        End If
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
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        lokasi_buku.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Halaman_masuk.admin = False
        Halaman_masuk.user = False
        Me.Close()
        Form1.Show()
    End Sub
End Class