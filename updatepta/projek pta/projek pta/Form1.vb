Imports System.Data.OleDb

Public Class Form1
    Dim dt As New DataTable("penetapan")
    Dim nmbr As Integer
    Dim status As Boolean = False
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Halaman_masuk.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Halaman_masuk.Show()
        Me.Hide()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        datagrid()

        If status = True Then
            Form3.Hide()

        Else
            Form3.Show()
        End If
    End Sub
    Public Sub datagrid()
        Dim dbconn As System.Data.OleDb.OleDbConnection
        dbconn = New System.Data.OleDb.OleDbConnection
        dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
        Dim sqlsearch As String
        sqlsearch = "select * from penetapan"
        Dim adapter As New OleDbDataAdapter(sqlsearch, dbconn)

        dbconn.Open()
        adapter.Fill(dt)
        dbconn.Close()

        If dt.Rows(nmbr)("status") = "no" Then
            status = False
        ElseIf dt.Rows(nmbr)("status") = "yes" Then
            status = True


        End If
    End Sub
End Class
