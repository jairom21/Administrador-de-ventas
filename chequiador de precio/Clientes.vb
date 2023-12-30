Imports MySql.Data.MySqlClient

Public Class Clientes
    Public tot
    Dim cnnx As New MySqlConnection(
                    "Server=" & Form1.kine(0) & ";database=bdadmin_ventas;User ID=" & Form1.kine(1) & ";Password=" & Form1.kine(2) & "")

    Private Sub cargartodo()



        Dim img31 As New DataGridViewImageColumn()
        Dim img32 As New DataGridViewImageColumn()

        Dim direc = System.AppDomain.CurrentDomain.BaseDirectory()
        Dim direc2 = System.AppDomain.CurrentDomain.BaseDirectory()
        direc2 = direc + "img\edit.png"
        direc = direc + "img\cancel.png"


        Dim inImg31 As Image = Image.FromFile(direc)
        img31.Image = inImg31
        img31.Width = 30

        img31.HeaderText = ""
        img31.Name = "img"

        Dim inImg32 As Image = Image.FromFile(direc2)
        img32.Image = inImg32
        img32.Width = 30

        img32.HeaderText = ""
        img32.Name = "img2"

        DataGridView1.Columns.Clear()

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
        DataGridView1.Columns.Add(img32)


        DataGridView1.Columns.Item(0).Width = 75
        DataGridView1.Columns.Item(1).Width = 100
        DataGridView1.Columns.Item(2).Width = 137
        DataGridView1.Columns.Item(3).Width = 137
        DataGridView1.Columns.Item(4).Width = 295

        DataGridView1.ReadOnly = True

    End Sub

    Private Sub Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargartodo()




    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Ncliente.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click



        Dim img31 As New DataGridViewImageColumn()
        Dim img32 As New DataGridViewImageColumn()

        Dim direc = System.AppDomain.CurrentDomain.BaseDirectory()
        Dim direc2 = System.AppDomain.CurrentDomain.BaseDirectory()
        direc2 = direc + "img\edit.png"
        direc = direc + "img\cancel.png"


        Dim inImg31 As Image = Image.FromFile(direc)
        img31.Image = inImg31
        img31.Width = 30

        img31.HeaderText = ""
        img31.Name = "img"

        Dim inImg32 As Image = Image.FromFile(direc2)
        img32.Image = inImg32
        img32.Width = 30

        img32.HeaderText = ""
        img32.Name = "img2"

        DataGridView1.Columns.Clear()

        Dim consultan = "select rut, nombre, apellido,telf , direccion from cliente where rut='" & TextBox1.Text & "'"
        Dim da As MySqlDataAdapter = New MySqlDataAdapter(consultan, cnnx)
        Dim ds As DataSet = New DataSet()
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(CType(255, Byte), CType(244, Byte), CType(215, Byte))

        'Try
        'cargar tabla de nominas


        'Try
        'cargar tabla de nominas

        da.Fill(ds, "s")
        DataGridView1.DataSource = ds.Tables("s")
        DataGridView1.Columns.Item(0).HeaderText = "RUT"
        DataGridView1.Columns.Item(1).HeaderText = "Nombre"
        DataGridView1.Columns.Item(2).HeaderText = "Apellido"
        DataGridView1.Columns.Item(3).HeaderText = "Telefono"
        DataGridView1.Columns.Item(4).HeaderText = "Direccion"
        DataGridView1.Columns.Add(img32)


        DataGridView1.Columns.Item(0).Width = 75
        DataGridView1.Columns.Item(1).Width = 100
        DataGridView1.Columns.Item(2).Width = 137
        DataGridView1.Columns.Item(3).Width = 137
        DataGridView1.Columns.Item(4).Width = 295

        DataGridView1.ReadOnly = True



    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        cargartodo()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim sel = Me.DataGridView1.CurrentCellAddress.Y

        tot = DataGridView1.Item(0, sel).Value

        ' Suponiendo que tienes una función para verificar si el producto ya está en el DataGridView
        ' Dim rowIndex As Integer = BuscarProductoEnDataGridView(Codigo)


        If e.ColumnIndex = 7 Then
            prodedit.ShowDialog()


        ElseIf e.ColumnIndex = 8 Then
            Dim resultado As DialogResult = MessageBox.Show("¿Estás seguro que desea eliminar este producto?", "Confirmación", MessageBoxButtons.YesNo)
            If resultado = DialogResult.Yes Then

                cnnx.Open()
                Dim consultax As New MySqlCommand("delete from productos where codigo = '" & tot & "'", cnnx)

                consultax.ExecuteNonQuery()

                cargartodo()




            Else

            End If


        End If
    End Sub
End Class