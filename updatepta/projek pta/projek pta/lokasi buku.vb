Imports System.Data.OleDb
Public Class lokasi_buku
    Dim nmbr As Integer
    Dim box1 As Boolean = False
    Dim box2 As Boolean = False
    Dim box3 As Boolean = False
    Public Sub datagrid()
        Dim dbconn As System.Data.OleDb.OleDbConnection
        dbconn = New System.Data.OleDb.OleDbConnection
        dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
        Dim sqlsearch As String
        sqlsearch = "SELECT * FROM maklumatbuku"
        Dim adapter As New OleDbDataAdapter(sqlsearch, dbconn)
        Dim dt As New DataTable("buku")
        dbconn.Open()
        adapter.Fill(dt)
        dbconn.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If box1 = True Then
            Try

                Dim dbconn As System.Data.OleDb.OleDbConnection
                dbconn = New System.Data.OleDb.OleDbConnection
                dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
                Dim sqlsearch As String
                sqlsearch = "SELECT * FROM maklumatbuku WHERE Tajuk ='" & TextBox1.Text & "'"
                Dim adapter As New OleDbDataAdapter(sqlsearch, dbconn)
                Dim dt As New DataTable("buku")
                dbconn.Open()
                adapter.Fill(dt)
                dbconn.Close()
                Label6.Text = dt.Rows(nmbr)("NomborRak")
                Label7.Text = dt.Rows(nmbr)("BarisRak")
            Catch ex As Exception
                MsgBox("Tiada Dalam Senarai")
                TextBox1.Text = ""
            End Try
        ElseIf box2 = True Then
            Try

                Dim dbconn As System.Data.OleDb.OleDbConnection
                dbconn = New System.Data.OleDb.OleDbConnection
                dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
                Dim sqlsearch As String
                sqlsearch = "SELECT * FROM maklumatbuku WHERE NomborISBN ='" & TextBox2.Text & "'"
                Dim adapter As New OleDbDataAdapter(sqlsearch, dbconn)
                Dim dt As New DataTable("buku")
                dbconn.Open()
                adapter.Fill(dt)
                dbconn.Close()
                Label6.Text = dt.Rows(nmbr)("NomborRak")
                Label7.Text = dt.Rows(nmbr)("BarisRak")
            Catch ex As Exception
                MsgBox("Tiada Dalam Senarai")
                TextBox1.Text = ""
            End Try
            'ElseIf box3 = True Then
            '    Try

            '        Dim dbconn As System.Data.OleDb.OleDbConnection
            '        dbconn = New System.Data.OleDb.OleDbConnection
            '        dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
            '        Dim sqlsearch As String
            '        sqlsearch = "SELECT * FROM maklumatbuku WHERE Kategori ='" & ComboBox1.Text & "'"
            '        Dim adapter As New OleDbDataAdapter(sqlsearch, dbconn)
            '        Dim dt As New DataTable("buku")
            '        dbconn.Open()
            '        adapter.Fill(dt)
            '        dbconn.Close()
            '        Label6.Text = dt.Rows(nmbr)("NomborRak")
            '        Label7.Text = dt.Rows(nmbr)("BarisRak")
            '    Catch ex As Exception
            '        MsgBox("Tiada Dalam Senarai")
            '        TextBox1.Text = ""
            '    End Try
        End If
        
    End Sub

    Private Sub lokasi_buku_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        datagrid()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Halaman_masuk.admin = True Then
            halaman_masuk_admin_user.Show()
            Me.Close()
        ElseIf Halaman_masuk.user = True Then
            Form2.Show()
            Me.Close()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            TextBox2.Enabled = True
            ' ComboBox1.Enabled = True
            box1 = False
            Label6.Text = ""
            Label7.Text = ""
        Else
            TextBox2.Enabled = False
            '    ComboBox1.Enabled = False
            box1 = True
        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = "" Then
            TextBox1.Enabled = True
            ' ComboBox1.Enabled = True
            box2 = False
            Label6.Text = ""
            Label7.Text = ""
        Else
            TextBox1.Enabled = False
            'ComboBox1.Enabled = False
            box2 = True
        End If
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        'ComboBox1.Text = "-"
        Label6.Text = ""
        Label7.Text = ""
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class