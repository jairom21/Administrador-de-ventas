Imports MySql.Data.MySqlClient

Public Class Lproductos
    Dim cnnx As New MySqlConnection(
                    "Server=" & Form1.kine(0) & ";database=bdadmin_ventas;User ID=" & Form1.kine(1) & ";Password=" & Form1.kine(2) & "")


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Lproductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim consultan = "select codigo, descripcion,precio from productos"
        Dim da As MySqlDataAdapter = New MySqlDataAdapter(consultan, cnnx)
        Dim ds As DataSet = New DataSet()


        Clientes.DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
        Clientes.DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(CType(255, Byte), CType(244, Byte), CType(215, Byte))

        'Try
        'cargar tabla de nominas

        da.Fill(ds, "s")
        DataGridView1.DataSource = ds.Tables("s")
        DataGridView1.Columns.Item(0).HeaderText = "Codigo"
        DataGridView1.Columns.Item(1).HeaderText = "Descripcion"

        DataGridView1.Columns.Item(2).HeaderText = "Precio"


        DataGridView1.Columns.Item(0).Width = 75
        DataGridView1.Columns.Item(1).Width = 340
        DataGridView1.Columns.Item(2).Width = 75


        DataGridView1.ReadOnly = True

        cnnx.Close()


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Facturacion.TextBox5.Text = 0
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim consultan = "select codigo, descripcion,precio from productos"
        Dim da As MySqlDataAdapter = New MySqlDataAdapter(consultan, cnnx)
        Dim ds As DataSet = New DataSet()


        Clientes.DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
        Clientes.DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(CType(255, Byte), CType(244, Byte), CType(215, Byte))

        'Try
        'cargar tabla de nominas

        da.Fill(ds, "s")
        DataGridView1.DataSource = ds.Tables("s")
        DataGridView1.Columns.Item(0).HeaderText = "Codigo"
        DataGridView1.Columns.Item(1).HeaderText = "Descripcion"

        DataGridView1.Columns.Item(2).HeaderText = "Precio"


        DataGridView1.Columns.Item(0).Width = 75
        DataGridView1.Columns.Item(1).Width = 340
        DataGridView1.Columns.Item(2).Width = 75


        DataGridView1.ReadOnly = True

        cnnx.Close()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim consultan = "select codigo, descripcion,precio from productos where descripcion like '%" & TextBox1.Text & "%'"
        Dim da As MySqlDataAdapter = New MySqlDataAdapter(consultan, cnnx)
        Dim ds As DataSet = New DataSet()


        Clientes.DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
        Clientes.DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(CType(255, Byte), CType(244, Byte), CType(215, Byte))

        'Try
        'cargar tabla de nominas

        da.Fill(ds, "s")
        DataGridView1.DataSource = ds.Tables("s")
        DataGridView1.Columns.Item(0).HeaderText = "Codigo"
        DataGridView1.Columns.Item(1).HeaderText = "Descripcion"

        DataGridView1.Columns.Item(2).HeaderText = "Precio"


        DataGridView1.Columns.Item(0).Width = 75
        DataGridView1.Columns.Item(1).Width = 340
        DataGridView1.Columns.Item(2).Width = 75


        DataGridView1.ReadOnly = True

        cnnx.Close()

    End Sub
End Class