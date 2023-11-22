Imports MySql.Data.MySqlClient

Public Class Clientes

    Dim cnnx As New MySqlConnection(
                    "Server=" & Form1.kine(0) & ";database=bdadmin_ventas;User ID=" & Form1.kine(1) & ";Password=" & Form1.kine(2) & "")



    Private Sub Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Dim consultan = "select rut, nombre, apellido,telf , direccion from cliente"
        Dim da As MySqlDataAdapter = New MySqlDataAdapter(consultan, cnnx)
        Dim ds As DataSet = New DataSet()
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(CType(255, Byte), CType(244, Byte), CType(215, Byte))

        'Try
        'cargar tabla de nominas

        da.Fill(ds, "s")
        DataGridView1.DataSource = ds.Tables("s")
        DataGridView1.Columns.Item(0).HeaderText = "RUT"
        DataGridView1.Columns.Item(1).HeaderText = "Nombre"
        DataGridView1.Columns.Item(2).HeaderText = "Apellido"
        DataGridView1.Columns.Item(3).HeaderText = "Telefono"
        DataGridView1.Columns.Item(4).HeaderText = "Direccion"


        DataGridView1.Columns.Item(0).Width = 75
        DataGridView1.Columns.Item(1).Width = 100
        DataGridView1.Columns.Item(2).Width = 137
        DataGridView1.Columns.Item(3).Width = 137
        DataGridView1.Columns.Item(4).Width = 275

        DataGridView1.ReadOnly = True













    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Ncliente.ShowDialog()
    End Sub
End Class