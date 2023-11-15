Imports MySql.Data.MySqlClient

Public Class Facturacion

    Dim cnnx As New MySqlConnection(
                "Server=" & Form1.kine(0) & ";database=bdadmin_ventas;User ID=" & Form1.kine(1) & ";Password=" & Form1.kine(2) & "")
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cnnx.Open()
        Dim consultax As New MySqlCommand("select * from cliente where rut='" & TextBox1.Text & "'", cnnx)

        Dim lex As MySqlDataReader
        lex = consultax.ExecuteReader



        lex.Read()
        Try
            Label9.Text = lex("nombre") & " " & lex("apellido")



        Catch ex As Exception
            Ncliente.ShowDialog()
        End Try



        cnnx.Close()


    End Sub
End Class