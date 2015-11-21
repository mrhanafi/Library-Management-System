Imports System.Data.OleDb
Public Class Halaman_masuk
    Dim nmbr As Integer
    Public Shared admin As Boolean = False
    Public Shared user As Boolean = False
    Private Sub Halaman_masuk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Sila Masukkan Nama Akaun Dan Kata Laluan Yang Betul")
        ElseIf TextBox1.Text = "admin" Or TextBox2.Text = "admin" Then

            admin = True
            Form1.Hide()
            halaman_masuk_admin_user.Show()
            Me.Close()
        Else
            Dim dbconn As System.Data.OleDb.OleDbConnection
            dbconn = New System.Data.OleDb.OleDbConnection
            dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
            Dim sqlsearch As String
            sqlsearch = "SELECT * FROM loginuser WHERE katalaluan like'" & TextBox2.Text & "'"
            Dim adapter As New OleDbDataAdapter(sqlsearch, dbconn)
            Dim dt As New DataTable("login")
            dbconn.Open()
            adapter.Fill(dt)
            dbconn.Close()
            If TextBox1.Text = dt.Rows(nmbr)("akaun") And TextBox2.Text = dt.Rows(nmbr)("katalaluan") Then
                user = True
                Me.Hide()
                Form1.Hide()
                Form2.Show()
            Else
                MsgBox("Akaun atau kata laluan salah.Sila cuba lagi.")
                TextBox1.Text = ""
                TextBox2.Text = ""
            End If
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        Form1.Show()

    End Sub


End Class