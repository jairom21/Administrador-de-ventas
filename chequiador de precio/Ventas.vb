Imports MySql.Data.MySqlClient

Public Class Ventas
    Dim cnnx As New MySqlConnection(
                    "Server=" & Form1.kine(0) & ";database=bdadmin_ventas;User ID=" & Form1.kine(1) & ";Password=" & Form1.kine(2) & "")


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Ventas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargartodo()
        ComboBox1.SelectedIndex = 0


    End Sub
    Private Sub cargartodo()

        Dim consultan = "select id, fecha, iva, tprecio, id_usuario from facturas order by id DESC "
        Dim da As MySqlDataAdapter = New MySqlDataAdapter(consultan, cnnx)
        Dim ds As DataSet = New DataSet()
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(CType(255, Byte), CType(244, Byte), CType(215, Byte))

        'Try
        'cargar tabla de nominas

        da.Fill(ds, "s")
        DataGridView1.DataSource = ds.Tables("s")
        DataGridView1.Columns.Item(0).HeaderText = "N°"
        DataGridView1.Columns.Item(1).HeaderText = "Fecha"
        DataGridView1.Columns.Item(2).HeaderText = "Iva"
        DataGridView1.Columns.Item(3).HeaderText = "Precio"
        DataGridView1.Columns.Item(4).HeaderText = "Vendedor"


        DataGridView1.Columns.Item(0).Width = 100
        DataGridView1.Columns.Item(1).Width = 250
        DataGridView1.Columns.Item(2).Width = 100
        DataGridView1.Columns.Item(3).Width = 100
        DataGridView1.Columns.Item(4).Width = 160

        DataGridView1.ReadOnly = True
        Dim prec, prect As Decimal

        For Each row As DataGridViewRow In DataGridView1.Rows

            prec = row.Cells(3).Value
            prect = prec + prect
        Next

        Label3.Text = prect


        ' unidades

        Dim lct As MySqlDataReader
        cnnx.Open()
        Dim c2 As New MySqlCommand("SELECT usu FROM usuario", cnnx)

        ComboBox1.Items.Clear()
        lct = c2.ExecuteReader
        ComboBox1.Items.Add("Todos")
        While (lct.Read())

            ComboBox1.Items.Add(lct("usu"))
        End While

        cnnx.Close()



    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim fechaSeleccionada As String = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim fechaSeleccionada2 As String = DateTimePicker2.Value.ToString("yyyy-MM-dd")
        Dim consulta As String = "SELECT * FROM tu_tabla WHERE fecha = '" & fechaSeleccionada & "'"
        Dim consultan As String

        If ComboBox1.Text = "Todos" Then
            consultan = "select facturas.id as id2, fecha, iva, tprecio, id_usuario from facturas where  
fecha BETWEEN '" & fechaSeleccionada & "' AND '" & fechaSeleccionada2 & "' order by facturas.id DESC "

        Else
            consultan = "select facturas.id as id2, fecha, iva, tprecio, id_usuario from facturas where id_usuario='" & ComboBox1.Text & "' and 
fecha BETWEEN '" & fechaSeleccionada & "' AND '" & fechaSeleccionada2 & "' order by facturas.id DESC "

        End If




        Dim da As MySqlDataAdapter = New MySqlDataAdapter(consultan, cnnx)
        Dim ds As DataSet = New DataSet()
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(CType(255, Byte), CType(244, Byte), CType(215, Byte))

        'Try
        'cargar tabla de nominas

        da.Fill(ds, "s")
        DataGridView1.DataSource = ds.Tables("s")
        DataGridView1.Columns.Item(0).HeaderText = "N°"
        DataGridView1.Columns.Item(1).HeaderText = "Fecha"
        DataGridView1.Columns.Item(2).HeaderText = "Iva"
        DataGridView1.Columns.Item(3).HeaderText = "Precio"
        DataGridView1.Columns.Item(4).HeaderText = "Vendedor"


        DataGridView1.Columns.Item(0).Width = 100
        DataGridView1.Columns.Item(1).Width = 250
        DataGridView1.Columns.Item(2).Width = 100
        DataGridView1.Columns.Item(3).Width = 100
        DataGridView1.Columns.Item(4).Width = 160

        DataGridView1.ReadOnly = True
        Dim prec, prect As Decimal

        For Each row As DataGridViewRow In DataGridView1.Rows

            prec = row.Cells(3).Value
            prect = prec + prect
        Next

        Label3.Text = prect






    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        cargartodo()
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class