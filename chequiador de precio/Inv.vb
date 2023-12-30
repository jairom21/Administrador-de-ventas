Imports MySql.Data.MySqlClient

Public Class Inv
    Dim cnnx As New MySqlConnection(
                "Server=" & Form1.kine(0) & ";database=bdadmin_ventas;User ID=" & Form1.kine(1) & ";Password=" & Form1.kine(2) & "")

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Inv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim consultan = "select codigo, descripcion,disp from productos"
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

        DataGridView1.Columns.Item(2).HeaderText = "Disponible"


        DataGridView1.Columns.Item(0).Width = 120
        DataGridView1.Columns.Item(1).Width = 480
        DataGridView1.Columns.Item(2).Width = 120


        DataGridView1.ReadOnly = True
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(CType(255, Byte), CType(244, Byte), CType(215, Byte))

        cnnx.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cinv.ShowDialog()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim consultan = "select codigo, descripcion,disp from productos where descripcion like '%" & TextBox1.Text & "%'"
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

        DataGridView1.Columns.Item(2).HeaderText = "Disponible"


        DataGridView1.Columns.Item(0).Width = 120
        DataGridView1.Columns.Item(1).Width = 480
        DataGridView1.Columns.Item(2).Width = 120


        DataGridView1.ReadOnly = True
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(CType(255, Byte), CType(244, Byte), CType(215, Byte))

        cnnx.Close()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim consultan = "select codigo, descripcion,disp from productos"
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

        DataGridView1.Columns.Item(2).HeaderText = "Disponible"


        DataGridView1.Columns.Item(0).Width = 120
        DataGridView1.Columns.Item(1).Width = 480
        DataGridView1.Columns.Item(2).Width = 120


        DataGridView1.ReadOnly = True
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
        DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(CType(255, Byte), CType(244, Byte), CType(215, Byte))

        cnnx.Close()

    End Sub
End Class