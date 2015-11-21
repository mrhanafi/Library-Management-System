Public Class daftar_user

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Sila Isi Pada Ruangan Yang Kosong.")

        ElseIf TextBox2.Text <> TextBox3.Text Then
            MsgBox("Kata Laluan Tidak Sah")
            TextBox2.Text = ""
            TextBox3.Text = ""
        Else
            If TextBox2.Text.Length < 6 Then
                MsgBox("kurang limit")
                TextBox2.Text = ""
                TextBox3.Text = ""
            ElseIf TextBox2.Text.Length > 10 Then
                MsgBox("lebih limit")
                TextBox2.Text = ""
                TextBox3.Text = ""
            Else
                Dim dbconn As System.Data.OleDb.OleDbConnection
                dbconn = New System.Data.OleDb.OleDbConnection
                dbconn.ConnectionString = My.Settings.sistem_pengurusan_perpustakaan1ConnectionString
                Dim cmd As New OleDb.OleDbCommand
                Try
                    dbconn.Open()
                    cmd.Connection = dbconn
                    cmd.CommandText = "insert into loginuser(akaun,katalaluan) values(@a,@b);"
                    cmd.Parameters.AddWithValue("@a", TextBox1.Text)
                    cmd.Parameters.AddWithValue("@b", TextBox2.Text)
                    cmd.ExecuteNonQuery()
                    dbconn.Close()
                    MsgBox("Pendaftaran Akaun Berjaya.")
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                Catch ex As Exception
                    MsgBox("Pendaftaran Akaun Tidak Berjaya.")
                End Try
            End If
            
        End If
       
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

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        'If TextBox2.Text.Length > 10 Then
        '    MsgBox("melebihi limit")
        '    TextBox2.Text = ""
        'End If
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        'If TextBox2.Text.Length > 10 Then
        '    MsgBox("melebihi limit")
        '    TextBox3.Text = ""
        'End If
    End Sub
End Class