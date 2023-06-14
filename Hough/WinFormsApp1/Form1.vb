Imports System.Drawing.Drawing2D
Imports System.Net.Mime.MediaTypeNames
Imports System.Runtime.ConstrainedExecution
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.VisualBasic.Devices


Public Class Form1

    Private origen As Bitmap
    Private intermedia As Bitmap
    Private destino As Bitmap



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCargarImagen_Click(sender As Object, e As EventArgs) Handles btnCargarImagen.Click
        Label1.Text = "Imagen de entrada"
        intermedia = My.Resources.ResourceManager.GetObject("paso2")
        imgIntermedia.Image = intermedia
        destino = My.Resources.ResourceManager.GetObject("paso3")
        'imgSalida.Image = destino
        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Seleccionar imagen"
            .Filter = "Archivos de imagen (png, jpg|*.jpg;*.png|Todos los archivos(*.*)|*.*"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            If .ShowDialog = DialogResult.OK Then
                Try
                    origen = New Bitmap(.FileName)
                    imgEntrada.Image = origen
                    Label1.Text = "Imagen de entrada (" & origen.Width & "x" & origen.Height & " pixeles)"
                Catch ex As Exception
                    MsgBox("No se pudo cargar la imagen " & ex.ToString)
                End Try
                If CheckBox1.Checked Then
                    intermedia = limpiarImagen(origen)
                Else
                    intermedia = convertirBinario(origen)
                End If
            End If
        End With


        imgIntermedia.Image = intermedia
        ProgressBar1.Value = 0
    End Sub




    Private Sub btnDetectarPatron_click(sender As Object, e As EventArgs) Handles btnDetectarAnillo.Click
        Try

            If CInt(txtDiametro.Text) = 0 Then
                MsgBox("Debe cargar una imagen como patron, o poner los parametros correspondientes", vbCritical)
                Exit Sub
            End If

            If intermedia Is Nothing Then
                MsgBox("Debe cargar una imagen como patron, o poner los parametros correspondientes", vbCritical)
                Exit Sub
            End If


            destino = copiarImagen(intermedia)
            imgSalida.Image = destino
            Dim diametro As Integer = CInt(txtDiametro.Text)


            Dim procesa As Bitmap = copiarImagen(intermedia)
            Dim houghDetection As New Hough(procesa)
            ProgressBar1.Maximum = intermedia.Width - CInt(diametro / 2)
            ProgressBar1.Value = 0
            progresoTimer.Enabled = True
            Dim cir As Circulo = houghDetection.DetectarCirculos(diametro, CInt(txtEspesor.Text))


            If cir.radio > 0 Then
                Dim graphics As Graphics = Graphics.FromImage(destino)
                Dim centerX As Integer = cir.X + CInt(txtEspesor.Text / 2)
                Dim centerY As Integer = cir.Y + CInt(txtEspesor.Text / 2)
                Dim radius As Integer = cir.radio
                Dim pen As New Pen(Color.LightCoral, 8)
                Dim pen2 As New Pen(Color.LightCoral, 3)

                graphics.SmoothingMode = SmoothingMode.AntiAlias
                graphics.DrawEllipse(pen, centerX - radius, centerY - radius, 2 * radius, 2 * radius)
                graphics.DrawLine(pen2, 0, centerY, destino.Width, centerY)
                graphics.DrawLine(pen2, centerX, 0, centerX, destino.Height)
                imgSalida.Image = destino
                imgSalida.Invalidate()
                MsgBox("Se ha detectado el anillo")
            Else
                MsgBox("No se han detectado el anillo")
            End If

        Catch ex As Exception
            MsgBox("Error al procesar " & ex.ToString)
        End Try
        ProgressBar1.Value = ProgressBar1.Maximum
        progresoTimer.Enabled = False

    End Sub


    Private Sub progreso_Tick(sender As Object, e As EventArgs) Handles progresoTimer.Tick
        ProgressBar1.Value = progreso
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click



        If intermedia Is Nothing Then
            Exit Sub
        End If
        Dim analizar As Bitmap = copiarImagen(intermedia)



        Dim x1, x2, x3, x4 As Integer

        Dim y1, y2, y3, y4 As Integer

        Dim ancho, alto As Integer

        ancho = analizar.Width - 1
        alto = analizar.Height - 1

        'barrido horizontal
        Dim col As Color = Color.Black
        Dim antBlanco As Boolean = False

        For x = 0 To ancho
            col = analizar.GetPixel(x, alto / 2)
            If col.R = 255 AndAlso col.G = 255 AndAlso col.B = 255 Then
                'es un pixel blanco

                If x > 0 Then
                    If x < CInt(ancho * 0.25) Then

                        'segundo pixel blanco seguido
                        If antBlanco Then
                            If x1 = 0 Then
                                x1 = x
                            ElseIf x3 = 0 Then
                                x2 = x
                            End If
                        End If
                    ElseIf x > CInt(ancho * 0.75) Then

                        If antBlanco Then
                            If x3 = 0 Then
                                x3 = x
                            Else
                                x4 = x
                            End If
                        End If
                    End If
                End If
                antBlanco = True
            Else
                If x2 > 0 And (x < ancho / 2) Then
                    x = 0.75 * ancho
                ElseIf x4 > 0 Then
                    Exit For
                End If
                antBlanco = False
            End If

        Next

        If x4 = 0 Then
            Debug.Print("no se pudo encontrar eje horizontal")
        End If

        For y = 0 To alto
            col = analizar.GetPixel(ancho / 2, y)
            If col.R = 255 AndAlso col.G = 255 AndAlso col.B = 255 Then
                'es un pixel blanco
                If y > 0 Then
                    If y < CInt(alto * 0.25) Then
                        'segundo pixel blanco seguido
                        If antBlanco Then
                            If y1 = 0 Then
                                y1 = y
                            ElseIf y3 = 0 Then
                                y2 = y
                            End If
                        End If
                    ElseIf y > CInt(alto * 0.75) Then
                        If antBlanco Then
                            If y3 = 0 Then
                                y3 = y
                            Else
                                y4 = y
                            End If
                        End If
                    End If
                End If
                antBlanco = True
            Else
                If y2 > 0 And (y < alto / 2) Then
                    y = alto * 0.75
                ElseIf y4 > 0 Then
                    Exit For
                End If
                antBlanco = False
            End If
        Next

        If y4 = 0 Then
            Debug.Print("no se pudo encontrar eje vertical")
        End If

        Dim anchoPincelX = ((x2 - x1) + (x4 - x3)) / 2
        Dim anchoPincelY = ((y2 - y1) + y4 - y3) / 2
        Dim anchopincelpromedio As Integer = (anchoPincelX + anchoPincelY) / 2

        Dim diametrox As Integer = (x4 - x1) - anchoPincelX
        Dim diametroy As Integer = (y4 - y1) - anchoPincelY
        Dim diamPromedio As Integer = (diametrox + diametroy) / 2
        Dim centroX As Integer = x1 + (diametrox / 2) + CInt(anchoPincelX / 2)
        Dim centroy As Integer = y1 + (diametroy / 2) + CInt(anchoPincelY / 2)

        Debug.Print("ancho " & ancho)
        Debug.Print("alto " & alto)

        Debug.Print("x1 " & x1)
        Debug.Print("x2 " & x2)
        Debug.Print("x3 " & x3)
        Debug.Print("x4 " & x4)
        Debug.Print("y1 " & y1)
        Debug.Print("y2 " & y2)
        Debug.Print("y3 " & y3)
        Debug.Print("y4 " & y4)
        Debug.Print("espesor anillo " & anchopincelpromedio)
        Debug.Print("diametro horizontal  " & diametrox)
        Debug.Print("diametro vertical  " & diametroy)
        Debug.Print("diametro promedio  " & diamPromedio)
        Debug.Print("centroX  " & centroX)
        Debug.Print("centroY  " & centroy)

        txtDiametro.Text = diamPromedio
        txtEspesor.Text = anchopincelpromedio


        Dim graphics As Graphics = Graphics.FromImage(analizar)
        graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim pen As New Pen(Color.LightCoral, anchopincelpromedio)
        graphics.DrawEllipse(pen, centroX - CInt(diametrox / 2), centroy - CInt(diametroy / 2), diametrox, diametroy)
        Dim pen2 As New Pen(Color.LightCoral, anchopincelpromedio / 3)
        graphics.DrawLine(pen2, 0, centroy, ancho, centroy)
        graphics.DrawLine(pen2, centroX, 0, centroX, alto)

        imgIntermedia.Image = analizar
        imgIntermedia.Invalidate()
        MsgBox("Presione aceptar para dejar imagen anterior")

        imgIntermedia.Image = intermedia
        imgIntermedia.Invalidate()


    End Sub

    Private Sub btnDetectarLineas_Click(sender As Object, e As EventArgs) Handles btnDetectarLineas.Click
        Try


            destino = copiarImagen(intermedia)
            imgSalida.Image = destino
            Dim diametro As Integer = CInt(txtDiametro.Text)
            Dim procesa As Bitmap = copiarImagen(intermedia)
            Dim houghDetection As New Hough(procesa)
            ProgressBar1.Maximum = intermedia.Width
            ProgressBar1.Value = 0
            progresoTimer.Enabled = True
            Dim lineasDetectadas As List(Of Linea) = houghDetection.detectarLineas
            Dim detectada As Boolean = False

            For Each lin In lineasDetectadas

                If lin.distancia > -9999999 Then
                    detectada = True
                    Dim graphics As Graphics = Graphics.FromImage(destino)
                    Dim angulo As Double = lin.angulo
                    Dim distancia As Integer = lin.distancia
                    Dim x1, y1, x2, y2 As Integer
                    Debug.Print("Dibujando " & lin.angulo & " seno " & Math.Abs(Math.Sin(angulo)) & " distancia " & lin.distancia)
                    If Math.Abs(Math.Sin(angulo)) < 0.0001 Then ' Línea vertical
                        x1 = CInt(distancia)
                        y1 = 0
                        x2 = CInt(distancia)
                        y2 = destino.Height
                    Else
                        x1 = 0
                        y1 = CInt(distancia / Math.Sin(angulo))
                        x2 = destino.Width
                        y2 = CInt((distancia - x2 * Math.Cos(angulo)) / Math.Sin(angulo))
                    End If
                    Dim pen As New Pen(Color.LightCoral, 2)
                    graphics.DrawLine(pen, x1, y1, x2, y2)

                End If

            Next
            imgSalida.Image = destino
            imgSalida.Invalidate()

            If Not detectada Then
                MsgBox("No se han detectado lineas")
            End If

        Catch ex As Exception
            MsgBox("Error al procesar " & ex.ToString)
        End Try
        ProgressBar1.Value = ProgressBar1.Maximum
        progresoTimer.Enabled = False
    End Sub
End Class

