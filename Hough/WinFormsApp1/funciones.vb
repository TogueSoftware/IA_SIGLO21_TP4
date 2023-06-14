Imports System.Drawing.Drawing2D

Module funciones


    Public progreso As Integer = 0

    Public Function convertirBinario(image As Bitmap) As Bitmap
        Try
            Dim binaryImage As New Bitmap(image.Width, image.Height)
            Dim pixel As Color
            Dim grayscale As Integer
            Dim binaryColor As Color
            For y As Integer = 0 To image.Height - 1
                For x As Integer = 0 To image.Width - 1
                    pixel = image.GetPixel(x, y)
                    grayscale = (CInt(pixel.R) + CInt(pixel.G) + CInt(pixel.B)) / 3
                    binaryColor = If(grayscale < 128, Color.Black, Color.White)
                    binaryImage.SetPixel(x, y, binaryColor)
                Next
            Next
            Return binaryImage
        Catch
        End Try

    End Function


    Public Function limpiarImagen(image As Bitmap) As Bitmap
        Try
            Dim imagenLimpia As New Bitmap(image.Width, image.Height)
            Dim umbralRojo As Integer = 128
            For i = 1 To 2

                For y As Integer = 1 To image.Height - 2
                    For x As Integer = 1 To image.Width - 2
                        Dim pixel As Color = image.GetPixel(x, y)

                        Dim p1 As Color = image.GetPixel(x - 1, y - 1)
                        Dim p2 As Color = image.GetPixel(x + 1, y + 1)
                        Dim c1 As Boolean = p1.R > umbralRojo
                        Dim c2 As Boolean = p2.R > umbralRojo
                        Dim claro As Boolean = pixel.R > umbralRojo

                        If c1 = c2 Then
                            claro = c1
                        End If

                        Dim cleanedColor As Color = If(claro, Color.White, Color.Black)
                        imagenLimpia.SetPixel(x, y, cleanedColor)

                        p1 = image.GetPixel(x - 1, y)
                        p2 = image.GetPixel(x + 1, y)
                        c1 = p1.R > umbralRojo
                        c2 = p2.R > umbralRojo
                        If c1 = c2 Then
                            claro = c1
                        End If
                        cleanedColor = If(claro, Color.White, Color.Black)
                        imagenLimpia.SetPixel(x, y, cleanedColor)


                        p1 = image.GetPixel(x, y - 1)
                        p2 = image.GetPixel(x, y + 1)
                        c1 = p1.R > umbralRojo
                        c2 = p2.R > umbralRojo
                        If c1 = c2 Then
                            claro = c1
                        End If
                        cleanedColor = If(claro, Color.White, Color.Black)
                        imagenLimpia.SetPixel(x, y, cleanedColor)

                    Next
                Next
            Next

            Return imagenLimpia
        Catch
        End Try

    End Function

    Public Function copiarImagen(image As Bitmap) As Bitmap
        Try
            Dim imagenLimpia As New Bitmap(image.Width, image.Height)
            For y As Integer = 0 To image.Height - 1
                For x As Integer = 0 To image.Width - 1
                    Dim pixel As Color = image.GetPixel(x, y)
                    imagenLimpia.SetPixel(x, y, pixel)
                Next
            Next
            Return imagenLimpia
        Catch
        End Try

    End Function



End Module
