Imports MySql.Data.MySqlClient

Public Class Nproducto
    Dim cnnx As New MySqlConnection(
                    "Server=" & Form1.kine(0) & ";database=bdadmin_ventas;User ID=" & Form1.kine(1) & ";Password=" & Form1.kine(2) & "")



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        cnnx.Open()

        Dim consult As New MySqlCommand("insert into productos ( codigo, descripcion, cuchara, tina, cono,precio ) values ('" & TextBox5.Text & "','" & TextBox1.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox6.Text & "','" & TextBox2.Text & "')", cnnx)
        Dim le As MySqlDataReader
        le = consult.ExecuteReader
        le.Close()


        Dim consultan = "select codigo, descripcion, cuchara, tina,cono,precio from productos"
        Dim da As MySqlDataAdapter = New MySqlDataAdapter(consultan, cnnx)
        Dim ds As DataSet = New DataSet()


        Compras.DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
        Compras.DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(CType(255, Byte), CType(244, Byte), CType(215, Byte))

        'Try
        'cargar tabla de nominas

        da.Fill(ds, "s")
        Compras.DataGridView1.DataSource = ds.Tables("s")
        Compras.DataGridView1.Columns.Item(0).HeaderText = "Codigo"
        Compras.DataGridView1.Columns.Item(1).HeaderText = "Descripcion"
        Compras.DataGridView1.Columns.Item(2).HeaderText = "Cuchara"
        Compras.DataGridView1.Columns.Item(3).HeaderText = "Vaso"
        Compras.DataGridView1.Columns.Item(4).HeaderText = "Barquilla"
        Compras.DataGridView1.Columns.Item(5).HeaderText = "Precio"


        Compras.DataGridView1.Columns.Item(0).Width = 75
        Compras.DataGridView1.Columns.Item(1).Width = 340
        Compras.DataGridView1.Columns.Item(2).Width = 75
        Compras.DataGridView1.Columns.Item(3).Width = 75
        Compras.DataGridView1.Columns.Item(4).Width = 75
        Compras.DataGridView1.Columns.Item(5).Width = 75

        Compras.DataGridView1.ReadOnly = True

        cnnx.Close()

        MsgBox("Producto creado exitosamente")

        Me.Close()





    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub


End Class