Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Configuracion


    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click


        ' La conexión a usar, indicando la base master
        Dim cnn As New MySqlConnection("Server=" & TextBox3.Text & ";User ID=" & TextBox1.Text & ";Password=" & TextBox2.Text & "")

        Try
            cnn.Open()

            'System.IO.Directory.CreateDirectory("C:\Captahuellas\fotos")
            Dim oSW As New StreamWriter("info.txt")

            Dim Linea As String = TextBox3.Text & "" & vbNewLine & "" & TextBox1.Text & "" & vbNewLine & "" & TextBox2.Text
            oSW.WriteLine(Linea)
            oSW.Flush()

            MsgBox("La conexión ha sido exitosa, debe Crear la base de datos y reiniciar el sistema", , "PRUEBA DE CONEXIÓN")
            Button4.Enabled = True
        Catch ex As Exception
            MsgBox("Error en datos de conexión", MsgBoxStyle.Critical, "PRUEBA DE CONEXIÓN")
        End Try


        cnn.Close()
    End Sub

    Private Sub Configuracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click


        Dim nombrebd
        nombrebd = "bdadmin_ventas"

        ' La conexión a usar, indicando la base master
        Dim cnn As New MySqlConnection("Server=" & TextBox3.Text & ";User ID=" & TextBox1.Text & ";Password=" & TextBox2.Text & "")
        ' La orden T-SQL para crear la tabla

        Dim s As String = "CREATE DATABASE " & nombrebd
        Dim cmd As New MySqlCommand(s, cnn)
        '

        Try
            cnn.Open()
            cmd.ExecuteNonQuery()
            '
            cnn.Close()

            Dim objConn As New MySqlConnection("Server=" & TextBox3.Text & ";uid=" & TextBox1.Text & ";pwd=" & TextBox2.Text & ";database=" & nombrebd & "")

            objConn.Open()

            'crea tablas
            'tabla config

            Dim objCmd11 As New MySqlCommand("Create Table usuario( usu Varchar(100),  clave Varchar(100), nomb Varchar(100), conf Varchar(100), fact Varchar(100), vent Varchar(100), inv  Varchar(100), comp Varchar(100), clie Varchar(100), rep  Varchar(100))", objConn)

            objCmd11.CommandType = CommandType.Text

            objCmd11.ExecuteNonQuery()


            Dim objCmd12 As New MySqlCommand("CREATE TABLE IF Not EXISTS `cliente` ( `id` int(11) Not NULL AUTO_INCREMENT, `nombre` varchar(150) Not NULL DEFAULT '0',  `apellido` varchar(150) Not NULL DEFAULT '0',  `telf` varchar(50) Not NULL DEFAULT '0',  `direccion` varchar(500) Not NULL DEFAULT '0',  `rut` varchar(500) Not NULL DEFAULT '0',  PRIMARY KEY(`id`)) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;", objConn)

            objCmd12.CommandType = CommandType.Text

            objCmd12.ExecuteNonQuery()



            Dim objCmd13 As New MySqlCommand("INSERT INTO `usuario` (`usu`, `clave`, `nomb`, `conf`, `fact`, `vent`, `inv`, `comp`, `clie`, `rep`) VALUES ('master', '12345', '1', '1', '1', '1', '1', '1', '1', '1')", objConn)

            objCmd13.ExecuteReader()
            objConn.Close()

        Catch ex As Exception
            MsgBox("Error al crear la base de datos")
        End Try





    End Sub
End Class