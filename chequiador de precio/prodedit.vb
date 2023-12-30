Imports MySql.Data.MySqlClient

Public Class prodedit
    Dim cnnx As New MySqlConnection(
                    "Server=" & Form1.kine(0) & ";database=bdadmin_ventas;User ID=" & Form1.kine(1) & ";Password=" & Form1.kine(2) & "")


    Private Sub prodedit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cnnx.Open()
        Dim consultax As New MySqlCommand("select * from productos where codigo = '" & Compras.tot & "'", cnnx)

        Dim lex As MySqlDataReader
        lex = consultax.ExecuteReader



        lex.Read()
        Try
            TextBox5.Text = lex("codigo")
            TextBox1.Text = lex("descripcion")
            NumericUpDown4.Value = lex("cuchara")
            NumericUpDown2.Value = lex("tina")
            NumericUpDown3.Value = lex("cono")
            NumericUpDown1.Value = lex("cant")
            TextBox2.Text = lex("precio")


        Catch ex As Exception

        End Try



        cnnx.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cnnx.Open()

        Dim consult3 As New MySqlCommand("Update productos SET descripcion='" & TextBox1.Text & "', cuchara='" & NumericUpDown4.Value & "', cono='" & NumericUpDown3.Value & "',tina='" & NumericUpDown2.Value & "',cant='" & NumericUpDown1.Value & "', precio='" & TextBox2.Text.Replace(",", ".") & "' WHERE codigo='" & Compras.tot & "'", cnnx)
        consult3.ExecuteNonQuery()


        cnnx.Close()

        Compras.cargartodo()

        Me.Close()
    End Sub
End Class