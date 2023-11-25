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

            Label10.Text = lex("direccion")

            Label12.Text = lex("rut")

        Catch ex As Exception
            Ncliente.ShowDialog()
        End Try



        cnnx.Close()


    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit



        Dim codigoNuevo As String
        If DataGridView1.Rows(e.RowIndex).Cells(1).Value IsNot Nothing Then
            codigoNuevo = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString()
        Else
            codigoNuevo = ""
        End If


        Try

            'Buscar si el código ya existe en el DataGridView
            For i As Integer = 0 To DataGridView1.Rows.Count - 2
                Dim codigoExistente As String
                If DataGridView1.Rows(e.RowIndex).Cells(1).Value IsNot Nothing Then
                    codigoExistente = DataGridView1.Rows(i).Cells(1).Value.ToString()

                Else
                    codigoNuevo = "1"
                End If


                If codigoExistente = codigoNuevo Then
                    'Actualizar la cantidad en lugar de agregar una nueva fila
                    Dim cantidadExistente As Integer = Convert.ToInt32(DataGridView1.Rows(i).Cells("cant").Value)
                    DataGridView1.Rows(i).Cells("cant").Value = cantidadExistente + 1
                    'Remover la nueva fila agregada, ya que el código ya existe
                    DataGridView1.Rows.RemoveAt(e.RowIndex + 1)
                    MsgBox(codigoExistente)
                    Exit For
                End If
            Next

        Catch ex As Exception

        End Try






        ' Verificar si la edición finalizó en una columna y fila específica






        If e.RowIndex >= 0 AndAlso e.ColumnIndex = 1 Then ' Suponiendo que la columna específica es la 1 (la segunda columna)




        End If
    End Sub

    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        ' Agregar el controlador de eventos KeyDown al cuadro de texto de edición de celda
        AddHandler e.Control.KeyDown, AddressOf DataGridViewTextBox_KeyDown
    End Sub

    Private Sub DataGridViewTextBox_KeyDown(sender As Object, e As KeyEventArgs)
        ' Verificar si se presionó la tecla Enter
        If e.KeyCode = Keys.Enter Then
            ' Finalizar la edición para desencadenar el evento CellEndEdit
            DataGridView1.EndEdit()
        End If
    End Sub

    Private Sub textBox5_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyDown
        If e.KeyCode = Keys.Enter Then

            Dim codigo As String = TextBox5.Text.Trim() ' Suponiendo que el código está ingresado en textBox1
            ' Aquí realizarías la búsqueda en tu base de datos u otras fuentes de datos para obtener la descripción del producto por su código
            Dim descripcion As String
            Dim precio As Decimal

            Try
                cnnx.Open()
                Dim consultax As New MySqlCommand("select * from productos where codigo='" & codigo & "'", cnnx)

                Dim lex As MySqlDataReader
                lex = consultax.ExecuteReader

                lex.Read()
                descripcion = lex("descripcion")
                precio = lex("precio")
                cnnx.Close()




            Catch ex As Exception
                descripcion = "noexiste"


                cnnx.Close()
            End Try

            ' Suponiendo que tienes una función para verificar si el producto ya está en el DataGridView
            Dim rowIndex As Integer = BuscarProductoEnDataGridView(codigo)
            Dim total As Decimal
            Dim total2 As Decimal
            If rowIndex <> -1 Then
                ' Si el producto ya existe, incrementa la cantidad
                Dim cantidad As Integer = Convert.ToInt32(DataGridView1.Rows(rowIndex).Cells("Cant").Value)
                DataGridView1.Rows(rowIndex).Cells("Cant").Value = cantidad + 1
                DataGridView1.Rows(rowIndex).Cells("total").Value = (cantidad + 1) * precio



                Dim i As Integer
                i = 0
                For Each row As DataGridViewRow In DataGridView1.Rows

                    total = Convert.ToInt32(DataGridView1.Rows(i).Cells("total").Value)
                    total2 = total2 + total
                    i = i + 1
                Next


                TextBox4.Text = total2



            Else

                If descripcion IsNot "noexiste" Then
                    ' Si el producto no existe, agrega una nueva fila al DataGridView
                    DataGridView1.Rows.Add(1, codigo, descripcion, 1, precio, precio)

                    Dim i As Integer
                    i = 0
                    For Each row As DataGridViewRow In DataGridView1.Rows

                        total = Convert.ToInt32(DataGridView1.Rows(i).Cells("total").Value)
                        total2 = total2 + total
                        i = i + 1
                    Next


                    TextBox4.Text = total2

                Else
                    MsgBox("El codigo de este producto no esta registrado en la base de datos")
                End If
            End If

            TextBox5.Clear() ' Limpiar el TextBox después de procesar el código
        End If
    End Sub
    Private Function BuscarProductoEnDataGridView(ByVal codigo As String) As Integer
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells("Codigo").Value IsNot Nothing AndAlso codigo = row.Cells("Codigo").Value.ToString() Then
                Return row.Index ' Devuelve el índice de la fila si se encuentra el producto
            End If
        Next
        Return -1 ' Devuelve -1 si el producto no se encontró en el DataGridView
    End Function


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Lproductos.ShowDialog()
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        cnnx.Open()
        Dim fechaYHoraActual As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        Dim consult As New MySqlCommand("insert into facturas (  tprecio, fecha, iva, id_usuario,rut_clien) values ('" & TextBox4.Text & "','" & fechaYHoraActual & "','" & TextBox3.Text & "','" & Form1.entrada & "','" & Label12.Text & "')", cnnx)
        Dim le As MySqlDataReader
        le = consult.ExecuteReader
        le.Close()

        Dim consul As New MySqlCommand("select MAX(id) from facturas where id_usuario='" & Form1.entrada & "'", cnnx)
        le = consul.ExecuteReader
        le.Read()
        Dim max_id = le(0)
        le.Close()

        Dim prec As String



        For Each row As DataGridViewRow In DataGridView1.Rows
            prec = row.Cells("precio").Value
            Dim consult2 As New MySqlCommand("insert into items (  id_producto, precio, iva, id_factura, cant) values ('" & row.Cells("Codigo").Value & "','" & prec.Replace(",", ".") & "','1','" & max_id & "','" & row.Cells("cant").Value & "')", cnnx)
            consult2.ExecuteNonQuery()

        Next
        cnnx.Close()

        Me.Close()
    End Sub


End Class