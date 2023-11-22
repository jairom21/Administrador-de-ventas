Imports MySql.Data.MySqlClient

Public Class Ncliente
    Dim cnnx As New MySqlConnection(
                    "Server=" & Form1.kine(0) & ";database=bdadmin_ventas;User ID=" & Form1.kine(1) & ";Password=" & Form1.kine(2) & "")



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        cnnx.Open()

        Dim consult As New MySqlCommand("insert into cliente (  nombre, apellido, telf, direccion,rut ) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "')", cnnx)
        Dim le As MySqlDataReader
        le = consult.ExecuteReader
        le.Close()

        Dim consultan = "select rut, nombre, apellido,telf , direccion from cliente"
        Dim da As MySqlDataAdapter = New MySqlDataAdapter(consultan, cnnx)
        Dim ds As DataSet = New DataSet()


        Clientes.DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
        Clientes.DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(CType(255, Byte), CType(244, Byte), CType(215, Byte))

        'Try
        'cargar tabla de nominas

        da.Fill(ds, "s")
        Clientes.DataGridView1.DataSource = ds.Tables("s")
        Clientes.DataGridView1.Columns.Item(0).HeaderText = "RUT"
        Clientes.DataGridView1.Columns.Item(1).HeaderText = "Nombre"
        Clientes.DataGridView1.Columns.Item(2).HeaderText = "Apellido"
        Clientes.DataGridView1.Columns.Item(3).HeaderText = "Telefono"
        Clientes.DataGridView1.Columns.Item(4).HeaderText = "Direccion"


        Clientes.DataGridView1.Columns.Item(0).Width = 75
        Clientes.DataGridView1.Columns.Item(1).Width = 100
        Clientes.DataGridView1.Columns.Item(2).Width = 137
        Clientes.DataGridView1.Columns.Item(3).Width = 137
        Clientes.DataGridView1.Columns.Item(4).Width = 275

        Clientes.DataGridView1.ReadOnly = True

        cnnx.Close()
        MsgBox("Cliente creado exitosamente")

        Me.Close()


    End Sub

    Private Sub Ncliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox5.Text = Facturacion.TextBox1.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class