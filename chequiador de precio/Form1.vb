


Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Form1
    Public kine(3)
    Public entrada
    Public active
    ' Public i As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Dim objReader As New StreamReader("info.txt")
            Dim sLine As String = ""
            Dim arrText As New ArrayList()

            Dim i = 0
            Do

                sLine = objReader.ReadLine()

                kine(i) = sLine

                If Not sLine Is Nothing Then
                    arrText.Add(sLine)
                End If
                i = i + 1
            Loop Until sLine Is Nothing
            objReader.Close()

            LoginForm1.ShowDialog()
            'Dim cnn As New SqlConnection(
            '          "Server=" & kine(0) & ";database=bdhuellas;User ID=" & kine(1) & ";Password=" & kine(2) & "")


            'cnn.Open()
            'usucont.ShowDialog()
            'Dim consul As New SqlCommand("select * from config ", cnn)
            'Dim le = consul.ExecuteReader

            'While (le.read)
            '    kk = le(0)
            '    Sql = le(4)

            'End While
            'le.close()




            'Dim objReader1 As New StreamReader("C:\Captahuellas\inf2.txt")
            'Dim sLine1 As String = ""
            'Dim arrText1 As New ArrayList()

            'Dim it = 0
            'Do

            '    sLine1 = objReader1.ReadLine()

            '    direc(it) = sLine1

            '    If Not sLine1 Is Nothing Then
            '        arrText1.Add(sLine1)
            '    End If
            '    it = it + 1
            'Loop Until sLine1 Is Nothing
            'objReader1.Close()



            'seri = direc(1)


            'Try
            '    If seri = EncryptText() Then


            '    Else
            '        active = 1
            '        MsgBox("Serial invalido o Vencido", MsgBoxStyle.Critical, "Importante")
            '    End If
            'Catch ex As Exception
            '    active = 1
            '    MsgBox("Serial invalido o Vencido")
            'End Try





            Dim cnnx As New MySqlConnection(
                    "Server=" & kine(0) & ";database=bdadmin_ventas;User ID=" & kine(1) & ";Password=" & kine(2) & "")
            cnnx.Open()
            Dim consultax As New MySqlCommand("select * from usuario where usu='" & entrada & "'", cnnx)

            Dim lex As MySqlDataReader
            lex = consultax.ExecuteReader
            Try


                lex.Read()
                If lex("conf") = "1" Then
                    Button7.Enabled = True
                End If
                If lex("fact") = "1" Then

                    Button10.Enabled = True
                End If
                If lex("vent") = "1" Then

                    Button13.Enabled = True
                End If
                If lex("inv") = "1" Then

                    Button11.Enabled = True
                End If
                If lex("comp") = "1" Then

                    Button12.Enabled = True
                End If
                If lex("clie") = "1" Then

                    Button9.Enabled = True
                End If
                If lex("rep") = "1" Then
                    Button8.Enabled = True

                End If
                cnnx.Close()
            Catch ex As Exception

            End Try

        Catch ex As Exception
            MsgBox("Debes configurar la conexion a la base de datos")
            Configuracion.ShowDialog()
        End Try



        'cronometro de verificacion de auto completacion
        'Dim cnnx1 As New SqlConnection(
        '                  "Server=" & kine(0) & ";database=bdhuellas;User ID=" & kine(1) & ";Password=" & kine(2) & "")
        'Try

        '    cnnx1.Open()
        '    Dim consultax1 As New SqlCommand("select * from autocomple where sino='True' ", cnnx1)

        '    Dim lex1 As SqlDataReader
        '    lex1 = consultax1.ExecuteReader
        '    i = 0
        '    While (lex1.Read())

        '        auto(i) = lex1(0)
        '        i = i + 1

        '    End While
        '    cnnx1.Close()

        'Catch ex As Exception
        '    cnnx1.Close()
        'End Try




    End Sub
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize

        ' Obtener el ancho actual del formulario
        Dim formWidth As Integer = Me.Width

        ' Obtener el ancho del botón
        Dim buttonWidth As Integer = CloseButton.Width

        ' Establecer la posición del botón para que esté siempre al margen derecho del formulario
        CloseButton.Left = formWidth - buttonWidth + 680 ' Puedes ajustar el margen a tu preferencia



    End Sub


    Private Sub Form1_DragOver(sender As Object, e As DragEventArgs) Handles Me.DragOver

    End Sub


    Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop


    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)





    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Configuracion.ShowDialog()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Facturacion.ShowDialog()
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        End
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Clientes.ShowDialog()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Compras.ShowDialog()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Inv.ShowDialog()
    End Sub
End Class