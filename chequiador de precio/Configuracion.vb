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

            Dim objCmd12 As New MySqlCommand("CREATE TABLE IF NOT EXISTS `cliente` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(150) NOT NULL DEFAULT '0',
  `apellido` varchar(150) NOT NULL DEFAULT '0',
  `telf` varchar(50) NOT NULL DEFAULT '0',
  `direccion` varchar(500) NOT NULL DEFAULT '0',
  `rut` varchar(500) NOT NULL DEFAULT '0',
  `id_usuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;", objConn)

            objCmd12.CommandType = CommandType.Text

            objCmd12.ExecuteNonQuery()

            Dim objCmd14 As New MySqlCommand("CREATE TABLE IF NOT EXISTS `facturas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tprecio` decimal(15,2) NOT NULL DEFAULT '0.00',
  `iva` decimal(15,2) NOT NULL DEFAULT '0.00',
  `fecha` datetime NOT NULL,
  `id_usuario` varchar(50) NOT NULL DEFAULT '0',
  `rut_clien` varchar(50) NOT NULL DEFAULT '0',
  `efectivo` decimal(15,2) DEFAULT NULL,
  `tarjeta` decimal(15,2) DEFAULT NULL,
  `fiao` decimal(15,2) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=latin1;", objConn)

            objCmd14.CommandType = CommandType.Text

            objCmd14.ExecuteNonQuery()

            Dim objCmd15 As New MySqlCommand("CREATE TABLE IF NOT EXISTS `inv` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(500) NOT NULL DEFAULT '0',
  `cant` int(11) NOT NULL DEFAULT '0',
  `fecha` datetime NOT NULL,
  `id_usuario` int(11) DEFAULT NULL,
  `costo` decimal(15,2) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;", objConn)

            objCmd15.CommandType = CommandType.Text

            objCmd15.ExecuteNonQuery()

            Dim objCmd16 As New MySqlCommand("CREATE TABLE IF NOT EXISTS `items` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_producto` int(11) NOT NULL DEFAULT '0',
  `precio` decimal(15,2) NOT NULL DEFAULT '0.00',
  `iva` decimal(15,2) NOT NULL DEFAULT '0.00',
  `id_factura` int(11) DEFAULT '0',
  `cant` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;", objConn)

            objCmd16.CommandType = CommandType.Text

            objCmd16.ExecuteNonQuery()

            Dim objCmd17 As New MySqlCommand("CREATE TABLE IF NOT EXISTS `productos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(500) NOT NULL DEFAULT '0',
  `precio` decimal(15,2) NOT NULL DEFAULT '0.00',
  `codigo` varchar(50) NOT NULL DEFAULT '0',
  `id_usuario` int(11) NOT NULL DEFAULT '0',
  `cuchara` int(11) NOT NULL DEFAULT '0',
  `cono` int(11) NOT NULL DEFAULT '0',
  `tina` int(11) NOT NULL DEFAULT '0',
   `cant` int(11) NOT NULL DEFAULT '0',
`disp` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;", objConn)

            objCmd17.CommandType = CommandType.Text

            objCmd17.ExecuteNonQuery()


            Dim objCmd18 As New MySqlCommand("CREATE TABLE IF NOT EXISTS `usuario` (
`id` int(11) NOT NULL AUTO_INCREMENT,
  `usu` varchar(100) DEFAULT NULL,
  `clave` varchar(100) DEFAULT NULL,
  `nomb` varchar(100) DEFAULT NULL,
  `conf` varchar(100) DEFAULT NULL,
  `fact` varchar(100) DEFAULT NULL,
  `vent` varchar(100) DEFAULT NULL,
  `inv` varchar(100) DEFAULT NULL,
  `comp` varchar(100) DEFAULT NULL,
  `clie` varchar(100) DEFAULT NULL,
  `rep` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;", objConn)

            objCmd18.CommandType = CommandType.Text

            objCmd18.ExecuteNonQuery()



            Dim objCmd13 As New MySqlCommand("INSERT INTO `usuario` (`usu`, `clave`, `nomb`, `conf`, `fact`, `vent`, `inv`, `comp`, `clie`, `rep`) VALUES
	('master', '12345', '1', '1', '1', '1', '1', '1', '1', '1');", objConn)

            objCmd13.ExecuteNonQuery()

            Dim objCmd20 As New MySqlCommand("INSERT INTO `facturas` (`id`, `tprecio`, `iva`, `fecha`, `id_usuario`, `rut_clien`, `efectivo`, `tarjeta`, `fiao`) VALUES
	(0, 0.00, 0.00, '2023-12-22 14:52:21', '0', '0', NULL, NULL, NULL);", objConn)

            objCmd20.ExecuteNonQuery()


            objConn.Close()




        Catch ex As Exception
            MsgBox("Error al crear la base de datos")
        End Try





    End Sub
End Class