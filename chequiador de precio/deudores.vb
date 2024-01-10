Imports MySql.Data.MySqlClient

Public Class deudores
    Public tot
    Dim xc = 1
    Dim cnnx As New MySqlConnection(
                "Server=" & Form1.kine(0) & ";database=bdadmin_ventas;User ID=" & Form1.kine(1) & ";Password=" & Form1.kine(2) & "")

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub deudores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargartodo()
    End Sub

    Public Sub cargartodo()

        DataGridView1.Columns.Clear()

        Dim img31 As New DataGridViewImageColumn()
        Dim img32 As New DataGridViewImageColumn()

        Dim direc = System.AppDomain.CurrentDomain.BaseDirectory()
        Dim direc2 = System.AppDomain.CurrentDomain.BaseDirectory()
        direc2 = direc + "img\ojo.png"
        direc = direc + "img\din.png"


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



        Dim consultan = "select rut_clien, nombre, apellido, fecha,facturas.id, fiao  from facturas inner join cliente on facturas.rut_clien=cliente.rut  where fiao>0"
        Dim da As MySqlDataAdapter = New MySqlDataAdapter(consultan, cnnx)
        Dim ds As DataSet = New DataSet()
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(CType(255, Byte), CType(244, Byte), CType(215, Byte))

        '  Try
        'cargar tabla de nominas

        da.Fill(ds, "s")
        DataGridView1.DataSource = ds.Tables("s")
        DataGridView1.Columns.Item(0).HeaderText = "RUT"
        DataGridView1.Columns.Item(1).HeaderText = "Nombre"
        DataGridView1.Columns.Item(2).HeaderText = "Apellido"
        DataGridView1.Columns.Item(3).HeaderText = "Fecha"
        DataGridView1.Columns.Item(4).HeaderText = "Factura"
        DataGridView1.Columns.Item(5).HeaderText = "Monto"




        DataGridView1.Columns.Item(0).Width = 75
        DataGridView1.Columns.Item(1).Width = 100
        DataGridView1.Columns.Item(2).Width = 137
        DataGridView1.Columns.Item(3).Width = 150
        DataGridView1.Columns.Item(4).Width = 150

        DataGridView1.ReadOnly = True

        ' DataGridView1.Columns.Add(img32)
        DataGridView1.Columns.Add(img31)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim sel = Me.DataGridView1.CurrentCellAddress.Y

        tot = DataGridView1.Item(4, sel).Value
        If IsNumeric(tot) Then
        Else
            tot = DataGridView1.Item(5, sel).Value
        End If
        ' Suponiendo que tienes una función para verificar si el producto ya está en el DataGridView
        ' Dim rowIndex As Integer = BuscarProductoEnDataGridView(Codigo)


        If DataGridView1.Columns(e.ColumnIndex).Name = "img" Then


            pdeuda.ShowDialog()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DataGridView1.Columns.Clear()

        Dim img31 As New DataGridViewImageColumn()
        Dim img32 As New DataGridViewImageColumn()

        Dim direc = System.AppDomain.CurrentDomain.BaseDirectory()
        Dim direc2 = System.AppDomain.CurrentDomain.BaseDirectory()
        direc2 = direc + "img\ojo.png"
        direc = direc + "img\din.png"


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



        Dim consultan = "select rut_clien, nombre, apellido, fecha,facturas.id, fiao  from facturas inner join cliente on facturas.rut_clien=cliente.rut  where fiao>0 and rut_clien='" & TextBox1.Text & "'"
        Dim da As MySqlDataAdapter = New MySqlDataAdapter(consultan, cnnx)
        Dim ds As DataSet = New DataSet()
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(CType(255, Byte), CType(244, Byte), CType(215, Byte))

        '  Try
        'cargar tabla de nominas

        da.Fill(ds, "s")
        DataGridView1.DataSource = ds.Tables("s")
        DataGridView1.Columns.Item(0).HeaderText = "RUT"
        DataGridView1.Columns.Item(1).HeaderText = "Nombre"
        DataGridView1.Columns.Item(2).HeaderText = "Apellido"
        DataGridView1.Columns.Item(3).HeaderText = "Fecha"
        DataGridView1.Columns.Item(4).HeaderText = "Factura"
        DataGridView1.Columns.Item(5).HeaderText = "Monto"




        DataGridView1.Columns.Item(0).Width = 75
        DataGridView1.Columns.Item(1).Width = 100
        DataGridView1.Columns.Item(2).Width = 137
        DataGridView1.Columns.Item(3).Width = 150
        DataGridView1.Columns.Item(4).Width = 150

        DataGridView1.ReadOnly = True

        ' DataGridView1.Columns.Add(img32)
        DataGridView1.Columns.Add(img31)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        cargartodo()
    End Sub
End Class