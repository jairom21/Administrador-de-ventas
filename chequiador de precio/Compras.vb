Imports MySql.Data.MySqlClient

Public Class Compras

    Dim cnnx As New MySqlConnection(
                    "Server=" & Form1.kine(0) & ";database=bdadmin_ventas;User ID=" & Form1.kine(1) & ";Password=" & Form1.kine(2) & "")


    Private Sub Compras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim consultan = "select codigo, descripcion, cuchara, tina,cono,cant,precio from productos"
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
        DataGridView1.Columns.Item(2).HeaderText = "Cuchara"
        DataGridView1.Columns.Item(3).HeaderText = "Vaso"
        DataGridView1.Columns.Item(5).HeaderText = "Cant."
        DataGridView1.Columns.Item(4).HeaderText = "Barquilla"
        DataGridView1.Columns.Item(6).HeaderText = "Precio"


        DataGridView1.Columns.Item(0).Width = 75
        DataGridView1.Columns.Item(1).Width = 265
        DataGridView1.Columns.Item(2).Width = 75
        DataGridView1.Columns.Item(3).Width = 75
        DataGridView1.Columns.Item(4).Width = 75
        DataGridView1.Columns.Item(5).Width = 75
        DataGridView1.Columns.Item(6).Width = 75

        DataGridView1.ReadOnly = True

        cnnx.Close()




    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Nproducto.ShowDialog()




    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class