Imports System.Data.OleDb
Module Module1
    Public acsconn As New OleDbConnection
    Public acsdr As OleDbDataReader
    Public acsda As New OleDbDataAdapter
    Public acscmd As New OleDbCommand
    Public strsql As String
    Public acds As New DataSet
    Public acdt As New DataTable
    Public str As String
    Public license2 As Date = Date.Now.Date
    Public license As DateTime = "3-9-2014"

    Public Sub connect()
        Try
            acsconn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & System.Environment.CurrentDirectory & "\SPBCherana.accdb"
            acsconn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Module
