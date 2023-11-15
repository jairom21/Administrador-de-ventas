Imports System.IO
Imports MySql.Data.MySqlClient

Public Class LoginForm1
    Dim kine(5)

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

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

        Dim cnn As New MySqlConnection(
                             "Server=" & kine(0) & ";database=bdadmin_ventas;User ID=" & kine(1) & ";Password=" & kine(2) & "")
        cnn.Open()
        Dim consul As New MySqlCommand("select * from usuario where usu='" & TextBox2.Text & "' and clave='" & TextBox1.Text & "' ", cnn)
        Dim le As MySqlDataReader
        le = consul.ExecuteReader
        If le.Read Then
            Form1.Visible = True
            Form1.entrada = TextBox2.Text
            Me.Close()
        Else
            MsgBox("Clave Invalida!", MsgBoxStyle.Exclamation, "Alerta!")
        End If
    End Sub
End Class
