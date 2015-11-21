Imports System.Data.OleDb
Public Class senaraipeminjam
    Dim Brush As New SolidBrush(Color.DarkBlue)
    Dim dFormat As New StringFormat
    Dim Pen As New Pen(Color.Black, 3)
    Dim dFont As New Font("Arial", 20)
    Dim mRow As Integer = 0
    Dim newpage As Boolean = True
    Private pages As Dictionary(Of Integer, pageDetails)

    Dim maxPagesWide As Integer
    Dim maxPagesTall As Integer
    Private Structure pageDetails
        Dim columns As Integer
        Dim rows As Integer
        Dim startCol As Integer
        Dim startRow As Integer
    End Structure
    Private Sub senaraipeminjam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        datagrid()
    End Sub
    Public Sub datagrid()
        Dim dbconn As System.Data.OleDb.OleDbConnection
        dbconn = New System.Data.OleDb.OleDbConnection
        dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
        Dim sqlsearch As String
        sqlsearch = "SELECT IdPeminjam,IdBuku,Kelas,Tajuk,TarikhPinjam,TarikhPulang FROM peminjaman"
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PrintPreviewDialog1.Document = PrintDocument1 'PrintPreviewDialog associate with PrintDocument.


        DirectCast(DirectCast(PrintPreviewDialog1.Controls(1), ToolStrip).Items(0), ToolStripButton).Enabled = False
        PrintPreviewDialog1.ShowDialog()

        PrintDialog1.Document = PrintDocument1 'PrintDialog associate with PrintDocument.

        If PrintDialog1.ShowDialog() = DialogResult.OK Then

            PrintDocument1.Print()

        End If
    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawString("SENARAI PEMINJAM", dFont, Brush, 330.0F, 100.0F, dFormat)

        Dim tmpSize As New SizeF()
        Dim tmpFont As Font
        For i As Integer = 0 To DataGridView1.Columns.Count()
            tmpFont = DataGridView1.ColumnHeadersDefaultCellStyle.Font
            If tmpFont Is Nothing Then
                tmpFont = DataGridView1.DefaultCellStyle.Font
            End If
            For j As Integer = 0 To DataGridView1.Rows.Count - 1
                tmpFont = DataGridView1.Rows(j).DefaultCellStyle.Font
                If tmpFont Is Nothing Then
                    tmpFont = DataGridView1.DefaultCellStyle.Font
                End If
            Next
        Next
        Dim cellsPerRow As New List(Of Integer)
        Dim rowHeight As Integer = DataGridView1.ColumnHeadersHeight + DataGridView1.Rows(0).Height
        Dim cellWidths(DataGridView1.Columns.Count - 1) As Integer
        Dim rowWidths As New List(Of Integer)
        Dim cellCounter As Integer = 0
        With DataGridView1
            Dim fmt As StringFormat = New StringFormat(StringFormatFlags.LineLimit)
            fmt.LineAlignment = StringAlignment.Center
            fmt.Trimming = StringTrimming.EllipsisCharacter
            Dim y As Single = e.MarginBounds.Top + 60
            Do While mRow < .RowCount
                Dim row As DataGridViewRow = .Rows(mRow)
                Dim x As Single = e.MarginBounds.Left
                Dim h As Single = 0
                For Each cell As DataGridViewCell In row.Cells
                    Dim rc As RectangleF = New RectangleF(x, y, cell.Size.Width, cell.Size.Height)
                    e.Graphics.DrawRectangle(Pens.Black, rc.Left, rc.Top, rc.Width, rc.Height)
                    If (newpage) Then
                        e.Graphics.DrawString(DataGridView1.Columns(cell.ColumnIndex).HeaderText, .Font,
                        Brushes.Black, rc, fmt)
                    Else
                        e.Graphics.DrawString(DataGridView1.Rows(cell.RowIndex - 1).Cells(cell.ColumnIndex).FormattedValue.ToString(), .Font, Brushes.Black, rc, fmt)
                    End If
                    x += rc.Width
                    h =
                    Math.Max(h, rc.Height)
                Next
                newpage = False
                y += h
                mRow += 1
                If y + h > e.MarginBounds.Bottom Then
                    e.HasMorePages = True
                    mRow -= 1
                    newpage = True
                    Exit Sub
                End If
            Loop
            mRow = 0
        End With
    End Sub
End Class