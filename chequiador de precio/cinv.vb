Imports MySql.Data.MySqlClient

Public Class cinv
    Dim cnnx As New MySqlConnection(
                "Server=" & Form1.kine(0) & ";database=bdadmin_ventas;User ID=" & Form1.kine(1) & ";Password=" & Form1.kine(2) & "")
    Dim codigo As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        cnnx.Open()
        Dim consultax As New MySqlCommand("select codigo, descripcion,disp from productos where codigo = '" & TextBox1.Text & "'", cnnx)

        Dim lex As MySqlDataReader
        lex = consultax.ExecuteReader



        lex.Read()
        Try
            TextBox2.Text = lex("descripcion")
            codigo = TextBox1.Text


        Catch ex As Exception

        End Try



        cnnx.Close()



    End Sub

    Private Sub cinv_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cnnx.Open()
        Dim consult3 As New MySqlCommand("Update productos SET disp=disp+" & NumericUpDown1.Value & " WHERE codigo='" & codigo & "'", cnnx)
        consult3.ExecuteNonQuery()
        cnnx.Close()


        Dim consultan = "select codigo, descripcion,disp from productos"
        Dim da As MySqlDataAdapter = New MySqlDataAdapter(consultan, cnnx)
        Dim ds As DataSet = New DataSet()


        Inv.DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
        Inv.DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(CType(255, Byte), CType(244, Byte), CType(215, Byte))

        'Try
        'cargar tabla de nominas

        da.Fill(ds, "s")
        Inv.DataGridView1.DataSource = ds.Tables("s")
        Inv.DataGridView1.Columns.Item(0).HeaderText = "Codigo"
        Inv.DataGridView1.Columns.Item(1).HeaderText = "Descripcion"

        Inv.DataGridView1.Columns.Item(2).HeaderText = "Disponible"


        Inv.DataGridView1.Columns.Item(0).Width = 120
        Inv.DataGridView1.Columns.Item(1).Width = 480
        Inv.DataGridView1.Columns.Item(2).Width = 120


        Inv.DataGridView1.ReadOnly = True
        Inv.DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
        Inv.DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(CType(255, Byte), CType(244, Byte), CType(215, Byte))

        cnnx.Close()

        TextBox1.Text = ""
        TextBox2.Text = ""
        NumericUpDown1.Value = 0


        Me.Close()
    End Sub
End Class