Imports MySql.Data.MySqlClient

Public Class clientedit

    Dim cnnx As New MySqlConnection(
                    "Server=" & Form1.kine(0) & ";database=bdadmin_ventas;User ID=" & Form1.kine(1) & ";Password=" & Form1.kine(2) & "")



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub clientedit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cnnx.Open()
        Dim consultax As New MySqlCommand("select * from cliente where rut = '" & Clientes.tot & "'", cnnx)

        Dim lex As MySqlDataReader
        lex = consultax.ExecuteReader



        lex.Read()
        Try
            TextBox5.Text = lex("rut")
            TextBox1.Text = lex("nombre")
            TextBox2.Text = lex("apellido")
            TextBox3.Text = lex("telf")
            TextBox4.Text = lex("direccion")


        Catch ex As Exception

        End Try



        cnnx.Close()





    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cnnx.Open()

        Dim consult3 As New MySqlCommand("Update cliente SET nombre='" & TextBox1.Text & "', apellido='" & TextBox2.Text & "', telf='" & TextBox3.Text & "',direccion='" & TextBox4.Text & "' WHERE rut='" & Clientes.tot & "'", cnnx)
        consult3.ExecuteNonQuery()


        cnnx.Close()

        Clientes.cargartodo()

        Me.Close()
    End Sub
End Class