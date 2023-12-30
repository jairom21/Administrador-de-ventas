Imports MySql.Data.MySqlClient

Public Class Nproducto
    Dim cnnx As New MySqlConnection(
                    "Server=" & Form1.kine(0) & ";database=bdadmin_ventas;User ID=" & Form1.kine(1) & ";Password=" & Form1.kine(2) & "")



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        cnnx.Open()

        Dim consult As New MySqlCommand("insert into productos ( codigo, descripcion, cuchara, tina, cono,precio,cant ) values ('" & TextBox5.Text & "','" & TextBox1.Text & "','" & NumericUpDown4.Value & "','" & NumericUpDown2.Value & "','" & NumericUpDown3.Value & "','" & TextBox2.Text & "','" & NumericUpDown1.Value & "')", cnnx)

        consult.ExecuteNonQuery()



        cnnx.Close()


        Compras.cargartodo()


        MsgBox("Producto creado exitosamente")

        Me.Close()





    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Nproducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class