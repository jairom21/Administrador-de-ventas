


Public Class Form1

    ' Public i As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoginForm1.ShowDialog()


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
End Class