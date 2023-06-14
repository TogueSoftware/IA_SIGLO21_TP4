Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Math
Imports Microsoft.VisualBasic.Devices

Public Class Hough

    Private imagenProcesar As Bitmap

    Public Sub New(ByVal imagen As Bitmap)
        ' Cargar la imagen desde el archivo
        imagenProcesar = imagen
    End Sub


    Public Function detectarLineas() As List(Of Linea)
        Dim ancho As Integer = imagenProcesar.Width
        Dim alto As Integer = imagenProcesar.Height

        ' Crear un acumulador para almacenar los votos de las líneas detectadas
        Dim acumulador As New Dictionary(Of String, Integer)()
        Dim distanciaMAX As Integer = CInt(ancho * Cos(0.25 * PI) + alto * Sin(0.25 * PI))

        Dim distanciasGrupos As Integer()


        Dim cantidadGruposDistancia As Integer = 300

        Debug.Print("salto cada " & CInt((distanciaMAX * 2) / cantidadGruposDistancia))
        ReDim distanciasGrupos(cantidadGruposDistancia)

        Dim a As Integer = 0
        For ii = -distanciaMAX To distanciaMAX Step CInt((distanciaMAX * 2) / cantidadGruposDistancia)
            Try
                distanciasGrupos(a) = ii
                a += 1
            Catch
            End Try
        Next


        Dim minDistancia = 9999
        Dim maxDistancia = -9999
        Dim str As String

        ' Bucle para recorrer todos los píxeles de la imagen
        For x As Integer = 0 To ancho - 1
            progreso = x
            Application.DoEvents()
            Try
                System.Threading.Thread.Sleep(1)
            Catch
            End Try
            For y As Integer = 0 To alto - 1
                Dim color As Color = imagenProcesar.GetPixel(x, y)
                ' Comprobar si el píxel es blanco (parte de la línea)
                If color.R = 255 AndAlso color.G = 255 AndAlso color.B = 255 Then
                    ' Bucle para generar todas las posibles líneas
                    Dim ang As Double = 0
                    For angulo As Double = 0 To PI Step PI / 180 ' 1 grado de precisión

                        ang = CInt(angulo * 10) / 10
                        Dim distancia As Integer = CInt(x * Math.Cos(ang) + y * Math.Sin(ang))


                        For ii = 1 To distanciasGrupos.Length - 1
                            '     'agrupador de distancias
                            If distancia >= distanciasGrupos(ii - 1) And distancia <= distanciasGrupos(ii) Then
                                distancia = distanciasGrupos(ii)
                                Exit For
                            End If
                        Next

                        If distancia < minDistancia Then
                                minDistancia = distancia
                            End If
                            If distancia > maxDistancia Then
                                maxDistancia = distancia
                            End If

                            str = ang & " " & distancia
                            ' Incrementar el contador del círculo detectado en el acumulador
                            If acumulador.ContainsKey(str) Then
                                acumulador(str) += 1
                            Else
                                acumulador(str) = 1
                            End If
                            ' Crear una línea con el ángulo y rho calculados
                            'Dim line As New Linea(angulo, distancia)
                            ' Incrementar el contador de la línea detectada en el acumulador
                        Next
                End If
            Next
        Next

        ' Filtrar las líneas detectadas según los 5 más votados

        'agrupacion por angulos y distancias




        '  ReDim distanciasGrupos(cantidadGruposDistancia)
        '  ReDim angulosGrupos(cantidadGruposAngulos)
        '  Dim a As Integer = 0
        '  For ii = minDistancia To maxDistancia Step CInt((maxDistancia - minDistancia) / cantidadGruposDistancia)
        '  Try
        '  distanciasGrupos(a) = ii
        '
        '        a += 1
        '        Catch
        '        End Try
        '        Next

        '        a = 0
        '        For angulo As Double = 0 To PI Step (PI / cantidadGruposAngulos)
        '        Try
        '        angulosGrupos(a) = angulo
        '        '  Debug.Print("B " & a & " angulo " & angulo)
        '        a += 1
        '        Catch
        '        End Try
        '        Next

        Debug.Print("obteniendo maximos")

        Dim dist As Integer

        'reagrupacion por distancia
        Dim acumulador2 As New Dictionary(Of String, Integer)()

        For Each clave In acumulador.Keys
            If acumulador(clave) > 1 Then
                Dim split As String() = clave.Split(" "c)
                Dim angulo As Double = CDbl(split(0))
                dist = CInt(split(1))

                '     For ii = 1 To distanciasGrupos.Length - 1
                '     'agrupador de distancias
                '     If dist >= distanciasGrupos(ii - 1) And dist <= distanciasGrupos(ii) Then
                '     dist = distanciasGrupos(ii)
                '     Exit For
                ' End If
                ' Next

                '          For ii = 1 To angulosGrupos.Length - 1
                '          'agrupador de angulos
                '          If angulo >= angulosGrupos(ii - 1) And angulo <= angulosGrupos(ii) Then
                '          angulo = angulosGrupos(ii)
                '          Exit For
                '      End If
                '  Next

                str = angulo & " " & dist

                        If acumulador2.ContainsKey(str) Then
                            acumulador2(str) += 1

                        Else
                            acumulador2(str) = 1
                        End If
                    End If

                Next

        Debug.Print("Acumulador 1 tiene " & acumulador.Count)
        Debug.Print("Acumulador 2 tiene " & acumulador2.Count)


        Dim votos() As Integer = {0, 0, 0, 0, 0}
        Dim claves() As String = {"", "", "", "", ""}

        'obtención de los 5 más votados
        For Each clave In acumulador.Keys

            '   Debug.Print(" acumulador " & acumulador2(clave) & " clave " & clave)
            If acumulador(clave) > votos(0) Then
                votos(4) = votos(3)
                votos(3) = votos(2)
                votos(2) = votos(1)
                votos(1) = votos(0)
                votos(0) = acumulador(clave)

                claves(4) = claves(3)
                claves(3) = claves(2)
                claves(2) = claves(1)
                claves(1) = claves(0)
                claves(0) = clave
            End If

        Next
        Debug.Print("obteniendo maximo 0 " & votos(0) & " clave " & claves(0))
        Debug.Print("obteniendo maximo 1 " & votos(1) & " clave " & claves(1))
        Debug.Print("obteniendo maximo 2 " & votos(2) & " clave " & claves(2))
        Debug.Print("obteniendo maximo 3 " & votos(3) & " clave " & claves(3))
        Debug.Print("obteniendo maximo 4 " & votos(4) & " clave " & claves(4))


        'armado de resultado
        Dim lineasDetectadas As New List(Of Linea)()

        For ii = 0 To claves.Length - 1
            If Not claves(ii).Equals("") Then
                Dim split As String() = claves(ii).Split(" "c)
                Dim angulo As Double = CDbl(split(0))
                Dim distancia As Integer = CInt(split(1))
                Dim linea As Linea = New Linea(angulo, distancia)
                lineasDetectadas.Add(linea)
            End If
        Next


        Debug.Print("saliendo")
        Return lineasDetectadas
    End Function


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
                            If radioPosible = radio Then
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

Public Class Linea
    Public Property angulo As Double
    Public Property distancia As Integer

    Public Sub New()
        distancia = -9999999
    End Sub

    Public Sub New(angulo As Double, distancia As Integer)
        Me.angulo = angulo
        Me.distancia = distancia
    End Sub
End Class
