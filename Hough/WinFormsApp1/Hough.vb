Imports System.Drawing

Public Class Hough

    Private imagenProcesar As Bitmap

    Public Sub New(ByVal imagen As Bitmap)
        ' Cargar la imagen desde el archivo
        imagenProcesar = imagen
    End Sub

    Public Function DetectarCirculos(diametro As Integer, tolerancia As Integer) As Circulo
        Dim ancho As Integer = imagenProcesar.Width
        Dim alto As Integer = imagenProcesar.Height



        ' Calcular el radio y la tolerancia correspondientes al diámetro y la tolerancia proporcionados
        Dim radio As Integer = diametro \ 2
        Dim toleranciaRadio As Integer = tolerancia \ 2

        ' Crear un acumulador para almacenar los votos de los círculos detectados
        Dim acumulador As New Dictionary(Of String, Integer)()

        ' Bucle para recorrer todos los píxeles de la imagen
        For x As Integer = radio To ancho - 1 - radio
            progreso = x
            Application.DoEvents()

            Try
                System.Threading.Thread.Sleep(1)
            Catch
            End Try

            For y As Integer = radio To alto - 1 - radio
                Dim color As Color = imagenProcesar.GetPixel(x, y)

                ' Comprobar si el píxel es blanco (parte del círculo)
                If color.R = 255 AndAlso color.G = 255 AndAlso color.B = 255 Then

                    ' Bucle para generar todos los posibles círculos dentro de la tolerancia especificada
                    For theta As Double = 0 To 2 * Math.PI Step 0.01
                        ' Calcular el centro del posible círculo
                        ' Calcular el centro del posible círculo
                        Dim centerX As Integer = CInt(x - radio * Math.Cos(theta))
                        Dim centerY As Integer = CInt(y - radio * Math.Sin(theta))


                        ' Comprobar si el centro está dentro de la imagen
                        If centerX >= radio AndAlso centerX < (ancho - radio) AndAlso centerY >= radio AndAlso centerY < (alto - radio) Then
                            ' Calcular el radio del posible círculo
                            Dim radioPosible As Integer = CInt(Math.Sqrt((centerX - x) ^ 2 + (centerY - y) ^ 2))

                            ' Comprobar si el radio del posible círculo está dentro de la tolerancia
                            'toleranciaRadio
                            If Math.Abs(radioPosible - radio) = 0 Then
                                ' Crear un círculo con el centro y el radio calculados
                                '  Dim circle As New Circulo(centerX, centerY, radioPosible)
                                Dim str As String = centerX & " " & centerY
                                ' Incrementar el contador del círculo detectado en el acumulador
                                If acumulador.ContainsKey(str) Then
                                    acumulador(str) += 1

                                Else
                                    acumulador(str) = 1
                                End If
                                '  Debug.Print("circulo encontrado en " & centerX & " , " & centerY & " acumulador " & accumulator(circle) & " posible encontrado " & possibleRadius)
                            End If
                        End If

                    Next


                End If
            Next
        Next

        ' Filtrar los círculos detectados según el umbral dado

        Dim circulosDetectados As New Circulo

        Dim max As Integer = 1
        Dim mejorClave As String = ""
        For Each clave In acumulador.Keys
            If acumulador(clave) > max Then
                max = acumulador(clave)
                mejorClave = clave
            End If
        Next

        If Not mejorClave.Equals("") And max > 400 Then
            Dim split As String() = mejorClave.ToString.Split(" "c)
            Dim x As Integer = CInt(split(0))
            Dim y As Integer = CInt(split(1))

            circulosDetectados = New Circulo(x, y, radio)
        End If




        Return circulosDetectados
    End Function
End Class

Public Class Circulo
    Public Property X As Integer
    Public Property Y As Integer
    Public Property radio As Integer

    Public Sub New()
        radio = 0
    End Sub
    Public Sub New(centroX As Integer, centroY As Integer, rad As Integer)
        Me.X = centroX
        Me.Y = centroY
        Me.radio = rad
    End Sub
End Class
