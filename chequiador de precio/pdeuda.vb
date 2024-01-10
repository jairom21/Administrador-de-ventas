Imports MySql.Data.MySqlClient

Public Class pdeuda

    Dim cnnx As New MySqlConnection(
                    "Server=" & Form1.kine(0) & ";database=bdadmin_ventas;User ID=" & Form1.kine(1) & ";Password=" & Form1.kine(2) & "")
    Dim a As Decimal
    Dim b As Decimal

    Dim fiao As String
    Private Sub ddeuda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargartodo()
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

        Try

            If ComboBox1.SelectedIndex = 2 Then
                a = TextBox4.Text
                b = TextBox7.Text
                ' Mostrar los números ingresados en TextBox1
                a = a - b
                If a >= 0 Then
                    TextBox6.Text = a.ToString
                    TextBox8.Text = 0
                Else
                    TextBox6.Text = 0
                    TextBox8.Text = a.ToString
                End If


                If TextBox7.Text = "" Then
                    Button3.Enabled = False
                Else
                    Button3.Enabled = True
                End If


            Else
                a = TextBox4.Text
                b = TextBox7.Text
                ' Mostrar los números ingresados en TextBox1
                a = a - b
                a = -a
                TextBox8.Text = a.ToString
                If a >= 0 Then
                    Button3.Enabled = True
                Else
                    Button3.Enabled = False
                End If



            End If



        Catch ex As Exception
            If TextBox7.Text = "" Then
                Button3.Enabled = False
            Else
                Button3.Enabled = True
            End If
        End Try

    End Sub







    Public Sub cargartodo()
        ComboBox1.SelectedIndex = 0
        cnnx.Open()
        Dim consultax As New MySqlCommand("select *,facturas.id as nf from facturas inner join cliente on cliente.rut=facturas.rut_clien  where facturas.id='" & deudores.tot & "'", cnnx)

        Dim lex As MySqlDataReader
        lex = consultax.ExecuteReader



        lex.Read()
        Try
            Label9.Text = lex("nombre") & " " & lex("apellido")

            Label10.Text = lex("direccion")

            Label12.Text = lex("rut")
            TextBox1.Text = lex("rut")
            Label8.Text = lex("nf")
            TextBox4.Text = lex("tprecio")
            TextBox3.Text = lex("iva")
            TextBox2.Text = lex("tprecio") - lex("iva")
            TextBox7.Text = lex("tprecio")

            lex.Close()

            ' datagridview

            Dim lct As MySqlDataReader

            Dim c2 As New MySqlCommand("SELECT *,productos.precio as precio2 FROM items inner join productos on productos.codigo=items.id_producto where id_factura=" & deudores.tot & "", cnnx)

            lct = c2.ExecuteReader
            Dim i = 0
            DataGridView1.Rows.Clear()

            While (lct.Read())
                i = i + 1
                DataGridView1.Rows.Add(i, lct("codigo"), lct("descripcion"), lct("cant"), lct("precio2"), lct("precio2") * lct("cant"))

            End While


            lct.Close()
        Catch ex As Exception

        End Try



        cnnx.Close()



    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        If ComboBox1.SelectedIndex = 0 Then
            TextBox7.ReadOnly = False
            TextBox8.Text = a.ToString
            TextBox6.Text = 0
            If a >= 0 Then
                Button3.Enabled = True
            Else
                Button3.Enabled = False
            End If
            fiao = 0
        ElseIf ComboBox1.SelectedIndex = 1 Then
            TextBox7.ReadOnly = True
            TextBox7.Text = 0
            TextBox8.Text = 0
            TextBox6.Text = TextBox4.Text
            Button3.Enabled = True
            fiao = 0
        ElseIf ComboBox1.SelectedIndex = 2 Then
            TextBox7.ReadOnly = False
            TextBox7.Text = 0
            fiao = 0
        ElseIf ComboBox1.SelectedIndex = 3 Then
            TextBox7.ReadOnly = True
            TextBox7.Text = 0
            TextBox8.Text = 0
            TextBox6.Text = 0
            Button3.Enabled = True
            fiao = TextBox4.Text
            fiao = fiao.Replace(",", ".")


        End If



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        cnnx.Open()

        Dim consult As New MySqlCommand("UPDATE facturas SET efectivo = '" & TextBox7.Text.Replace(",", ".") & "', tarjeta = '" & TextBox6.Text.Replace(",", ".") & "', fiao = 0 WHERE id='" & deudores.tot & "'", cnnx)
        consult.ExecuteNonQuery()

        cnnx.Close()
        deudores.cargartodo()
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub
End Class