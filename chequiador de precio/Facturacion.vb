Imports MySql.Data.MySqlClient
Imports System
Imports System.Drawing.Printing
Public Class Facturacion
    Dim x, i As Integer
    Dim cnnx As New MySqlConnection(
                "Server=" & Form1.kine(0) & ";database=bdadmin_ventas;User ID=" & Form1.kine(1) & ";Password=" & Form1.kine(2) & "")
    Dim fiao As String
    Dim max_id
    Dim a As Decimal
    Dim b As Decimal
    Dim cuchara1(20) As Integer
    Dim cono1(20) As Integer
    Dim tina1(20) As Integer
    Dim fechaYHoraActual As String
    Dim cnt As Integer

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
            Dim cuchara, cono, tina As Integer

            Try
                cnnx.Open()
                Dim consultax As New MySqlCommand("select * from productos where codigo='" & codigo & "'", cnnx)
                Dim lex As MySqlDataReader

                lex = consultax.ExecuteReader

                lex.Read()
                descripcion = lex("descripcion")
                precio = lex("precio")
                cuchara = lex("cuchara")
                cono = lex("cono")
                tina = lex("tina")



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




                i = 0
                For Each row As DataGridViewRow In DataGridView1.Rows

                    total = Convert.ToInt32(DataGridView1.Rows(i).Cells("total").Value)
                    total2 = total2 + total
                    i = i + 1
                Next


                TextBox2.Text = total2
                TextBox3.Text = total2 * 0.19
                TextBox4.Text = (total2 * 0.19) + total2
                TextBox7.Text = (total2 * 0.19) + total2

            Else

                If descripcion IsNot "noexiste" Then
                    ' Si el producto no existe, agrega una nueva fila al DataGridView
                    DataGridView1.Rows.Add(1, codigo, descripcion, 1, precio, precio)

                    ' DataGridView1.Rows(0).Cells("imagenColumna").Value = imagen
                    cuchara1(x) = cuchara
                    cono1(x) = cono
                    tina1(x) = tina

                    x = x + 1


                    i = 0
                    For Each row As DataGridViewRow In DataGridView1.Rows

                        total = Convert.ToInt32(DataGridView1.Rows(i).Cells("total").Value)
                        total2 = total2 + total
                        i = i + 1
                    Next


                    'TextBox4.Text = total2

                    TextBox2.Text = total2
                    TextBox3.Text = total2 * 0.19
                    TextBox4.Text = (total2 * 0.19) + total2
                    TextBox7.Text = (total2 * 0.19) + total2


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
        fechaYHoraActual = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        Dim consult As New MySqlCommand("insert into facturas (  tprecio, fecha, iva, id_usuario,rut_clien,efectivo,tarjeta,fiao) values ('" & TextBox4.Text.Replace(",", ".") & "','" & fechaYHoraActual & "','" & TextBox3.Text.Replace(",", ".") & "','" & Form1.entrada & "','" & Label12.Text & "','" & TextBox7.Text.Replace(",", ".") & "','" & TextBox6.Text.Replace(",", ".") & "','" & fiao & "')", cnnx)
        Dim le As MySqlDataReader
        le = consult.ExecuteReader
        le.Close()

        Dim consul As New MySqlCommand("select MAX(id) from facturas where id_usuario='" & Form1.entrada & "'", cnnx)
        le = consul.ExecuteReader
        le.Read()


        max_id = le(0)
        le.Close()

        Dim prec As String


        x = 0
        For Each row As DataGridViewRow In DataGridView1.Rows
            prec = row.Cells("precio").Value
            Dim consult2 As New MySqlCommand("insert into items (  id_producto, precio, iva, id_factura, cant) values ('" & row.Cells("Codigo").Value & "','" & prec.Replace(",", ".") & "','1','" & max_id & "','" & row.Cells("cant").Value & "')", cnnx)
            consult2.ExecuteNonQuery()


            Dim consult3 As New MySqlCommand("Update productos SET disp=disp-(cant*'" & row.Cells("cant").Value & "') WHERE codigo='" & row.Cells("Codigo").Value & "'", cnnx)
            consult3.ExecuteNonQuery()

            Dim consult4 As New MySqlCommand("Update productos SET disp=disp-(" & cuchara1(x) * row.Cells("cant").Value & ") WHERE descripcion='cuchara'", cnnx)
            consult4.ExecuteNonQuery()

            Dim consult5 As New MySqlCommand("Update productos SET disp=disp-(" & cono1(x) * row.Cells("cant").Value & ") WHERE descripcion='cono'", cnnx)
            consult5.ExecuteNonQuery()

            Dim consult6 As New MySqlCommand("Update productos SET disp=disp-(" & tina1(x) * row.Cells("cant").Value & ") WHERE descripcion='tina'", cnnx)
            consult6.ExecuteNonQuery()
            x = x + 1
        Next
        cnnx.Close()










        ' Crear un documento para impresión
        Dim pd As New Printing.PrintDocument
        ' Manejar el evento PrintPage para definir el contenido que se imprimirá
        AddHandler pd.PrintPage, AddressOf ImprimirContenido
        ' Asignar la impresora por defecto (tiquetera)


        Dim dlg As New PrintDialog
        dlg.Document = pd
        If dlg.ShowDialog = DialogResult.OK Then
            pd.Print()
        End If

        limpiar()
        Me.Close()
    End Sub
    Private Sub limpiar()
        TextBox1.Text = ""
        TextBox5.Text = ""
        Label9.Text = ""
        Label10.Text = ""
        TextBox2.Text = "0.00"
        TextBox3.Text = "0.00"
        TextBox4.Text = "0.00"
        TextBox6.Text = "0"
        TextBox7.Text = "0"
        TextBox8.Text = "0"

        Label12.Text = ""
        DataGridView1.Rows.Clear()
    End Sub


    Private Sub ImprimirContenido(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs)
        Dim contenidof As String
        Dim contenidoft As String

        For Each row As DataGridViewRow In DataGridView1.Rows
            contenidof = row.Cells("Descripcion").Value.ToString().PadRight(14) & " " & row.Cells("Precio").Value.ToString().PadRight(9) & " " & row.Cells("Cant").Value.ToString().PadRight(7) & " " & row.Cells("Precio").Value * row.Cells("Cant").Value & "" & vbCrLf
            contenidoft = contenidoft + contenidof

        Next




        ' Definir el contenido que se imprimirá en la factura
        Dim contenido As String = "=== ELADERIA FREDDY'S ===" & vbCrLf &
                                 "=== TELF: 88888888 ===" & vbCrLf &
                                 "=== NIF:   4444444 ===" & vbCrLf &
                                 "=== WEB:   www.eladeriasfreddys.com ===" & vbCrLf &
                                 "" & vbCrLf &
                                 "Factura N°:" & max_id & "   " & fechaYHoraActual & "" & vbCrLf &
                                 "Producto      Precio    Cant     Total" & vbCrLf &
                                 "-----------  --------  --------  --------" & vbCrLf &
                                 contenidoft


        ' Configurar la fuente y el formato de impresión
        Dim fuente As New Font("Courier New", 7)
        ' Definir el área de impresión
        Dim areaImpresion As New RectangleF(5, 5, e.MarginBounds.Width + 100, e.MarginBounds.Height + 200)

        ' Imprimir el contenido en el área definida
        e.Graphics.DrawString(contenido, fuente, Brushes.Black, areaImpresion)
    End Sub





    Private Sub ImprimirContenido2(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs)
        Dim font As New Font("Courier New", 12)
        Dim brush As New SolidBrush(Color.Black)
        Dim startX As Integer = 10
        Dim startY As Integer = 10
        Dim lineHeight As Integer = 20

        ' Print the header
        e.Graphics.DrawString("Factura prueba", font, brush, startX, startY)
        startY += lineHeight

        ' Print the items
        e.Graphics.DrawString("Helado con sabor a frutas tropicales:   $10", font, brush, startX, startY)
        startY += lineHeight
        e.Graphics.DrawString("Helado con sabor a frutas tropicales con siro de fresa ...: $20", font, brush, startX, startY)
        startY += lineHeight

        ' Print the total
        e.Graphics.DrawString("Total: $30", font, brush, startX, startY)
    End Sub

    Private Sub Facturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(CType(255, Byte), CType(244, Byte), CType(215, Byte))

        ComboBox1.SelectedIndex = 0
        cnnx.Open()
        fechaYHoraActual = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        Dim le As MySqlDataReader

        Dim consul As New MySqlCommand("select MAX(id) from facturas ", cnnx)
        le = consul.ExecuteReader
        le.Read()


        max_id = le(0)
        le.Close()
        Label8.Text = max_id + 1
        cnnx.Close()

        Dim direc1 = System.AppDomain.CurrentDomain.BaseDirectory()
        Dim img2 As New DataGridViewImageColumn()
        direc1 = direc1 + "x.png"

        Dim inImg2 As Image = Image.FromFile(direc1)
        img2.Image = inImg2
        img2.Width = 25

        img2.HeaderText = ""
        img2.Name = "img"
        If cnt Then

        Else
            DataGridView1.Columns.Add(img2)
            cnt = 1

        End If

    End Sub

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        ' Verificar si la tecla presionada es un número o la tecla de retroceso
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True ' Si no es un número, se ignora la tecla
        End If
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



    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim sel = Me.DataGridView1.CurrentCellAddress.Y

        Dim tot = DataGridView1.Item(3, sel).Value

        ' Suponiendo que tienes una función para verificar si el producto ya está en el DataGridView
        ' Dim rowIndex As Integer = BuscarProductoEnDataGridView(Codigo)
        Dim total As Decimal
        Dim total2 As Decimal

        If e.ColumnIndex = 6 Then
            DataGridView1.Rows.RemoveAt(e.RowIndex)



            i = 0
            For Each row As DataGridViewRow In DataGridView1.Rows

                total = Convert.ToInt32(DataGridView1.Rows(i).Cells("total").Value)
                total2 = total2 + total
                i = i + 1
            Next


            'TextBox4.Text = total2

            TextBox2.Text = total2
            TextBox3.Text = total2 * 0.19
            TextBox4.Text = (total2 * 0.19) + total2
            TextBox7.Text = (total2 * 0.19) + total2


        End If


    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

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


End Class