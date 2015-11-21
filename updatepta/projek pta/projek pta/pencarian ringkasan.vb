Imports System.Data.OleDb
Public Class pencarian_ringkasan

    Private Sub pencarian_ringkasan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        datagrid()
    End Sub
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
        DataGridView1.DataSource = dt
        Dim dgvColumnHeaderStyle As New DataGridViewCellStyle()
        dgvColumnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        ' DataGridView1.ColumnHeadersDefaultCellStyle = dgvColumnHeaderStyle
        dbconn.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox2.Enabled = False
        Button2.Enabled = False
        Dim dbconn As System.Data.OleDb.OleDbConnection
        dbconn = New System.Data.OleDb.OleDbConnection
        dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
        Dim sqlsearch As String
        sqlsearch = "SELECT * FROM maklumatbuku WHERE Tajuk ='" & TextBox1.Text & "'"
        Dim adapter As New OleDbDataAdapter(sqlsearch, dbconn)
        Dim dt As New DataTable("pemulangan")
        dbconn.Open()
        adapter.Fill(dt)
        DataGridView1.DataSource = dt
        Dim dgvColumnHeaderStyle As New DataGridViewCellStyle()
        dgvColumnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.ColumnHeadersDefaultCellStyle = dgvColumnHeaderStyle
        dbconn.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Enabled = False
        Button1.Enabled = False
        Dim dbconn As System.Data.OleDb.OleDbConnection
        dbconn = New System.Data.OleDb.OleDbConnection
        dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
        Dim sqlsearch As String
        sqlsearch = "SELECT * FROM maklumatbuku WHERE NomborBuku ='" & TextBox2.Text & "'"
        Dim adapter As New OleDbDataAdapter(sqlsearch, dbconn)
        Dim dt As New DataTable("nombor")
        dbconn.Open()
        adapter.Fill(dt)
        DataGridView1.DataSource = dt
        Dim dgvColumnHeaderStyle As New DataGridViewCellStyle()
        dgvColumnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.ColumnHeadersDefaultCellStyle = dgvColumnHeaderStyle
        dbconn.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Halaman_masuk.admin = True Then
            halaman_masuk_admin_user.Show()
            Me.Close()
        ElseIf Halaman_masuk.user = True Then
            Form2.Show()
            Me.Close()
        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = "" Then
            TextBox1.Enabled = True
            Button1.Enabled = True
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            TextBox2.Enabled = True
            Button2.Enabled = True
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
End Class