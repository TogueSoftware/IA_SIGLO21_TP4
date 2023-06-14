<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form1))
        ProgressBar1 = New ProgressBar()
        btnDetectarAnillo = New Button()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        btnCargarImagen = New Button()
        imgSalida = New PictureBox()
        imgIntermedia = New PictureBox()
        imgEntrada = New PictureBox()
        txtDiametro = New TextBox()
        Label4 = New Label()
        progresoTimer = New Timer(components)
        Button2 = New Button()
        Label6 = New Label()
        txtEspesor = New TextBox()
        CheckBox1 = New CheckBox()
        Label5 = New Label()
        btnDetectarLineas = New Button()
        CType(imgSalida, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgIntermedia, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgEntrada, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Location = New Point(626, 359)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(281, 10)
        ProgressBar1.TabIndex = 33
        ' 
        ' btnDetectarAnillo
        ' 
        btnDetectarAnillo.Location = New Point(652, 385)
        btnDetectarAnillo.Name = "btnDetectarAnillo"
        btnDetectarAnillo.Size = New Size(219, 23)
        btnDetectarAnillo.TabIndex = 28
        btnDetectarAnillo.Text = "Detectar anillo"
        btnDetectarAnillo.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(626, 45)
        Label3.Name = "Label3"
        Label3.Size = New Size(125, 15)
        Label3.TabIndex = 27
        Label3.Text = "Detección de patrones"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(326, 45)
        Label2.Name = "Label2"
        Label2.Size = New Size(103, 15)
        Label2.TabIndex = 26
        Label2.Text = "Preprocesamiento"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(24, 45)
        Label1.Name = "Label1"
        Label1.Size = New Size(106, 15)
        Label1.TabIndex = 25
        Label1.Text = "Imagen de Entrada"
        ' 
        ' btnCargarImagen
        ' 
        btnCargarImagen.Location = New Point(102, 364)
        btnCargarImagen.Name = "btnCargarImagen"
        btnCargarImagen.Size = New Size(125, 23)
        btnCargarImagen.TabIndex = 24
        btnCargarImagen.Text = "Cargar Imagen..."
        btnCargarImagen.UseVisualStyleBackColor = True
        ' 
        ' imgSalida
        ' 
        imgSalida.Image = CType(resources.GetObject("imgSalida.Image"), Image)
        imgSalida.Location = New Point(626, 63)
        imgSalida.Name = "imgSalida"
        imgSalida.Size = New Size(281, 295)
        imgSalida.SizeMode = PictureBoxSizeMode.Zoom
        imgSalida.TabIndex = 23
        imgSalida.TabStop = False
        ' 
        ' imgIntermedia
        ' 
        imgIntermedia.Image = CType(resources.GetObject("imgIntermedia.Image"), Image)
        imgIntermedia.Location = New Point(326, 63)
        imgIntermedia.Name = "imgIntermedia"
        imgIntermedia.Size = New Size(281, 295)
        imgIntermedia.SizeMode = PictureBoxSizeMode.Zoom
        imgIntermedia.TabIndex = 22
        imgIntermedia.TabStop = False
        ' 
        ' imgEntrada
        ' 
        imgEntrada.Image = CType(resources.GetObject("imgEntrada.Image"), Image)
        imgEntrada.Location = New Point(24, 63)
        imgEntrada.Name = "imgEntrada"
        imgEntrada.Size = New Size(281, 295)
        imgEntrada.SizeMode = PictureBoxSizeMode.Zoom
        imgEntrada.TabIndex = 35
        imgEntrada.TabStop = False
        ' 
        ' txtDiametro
        ' 
        txtDiametro.Location = New Point(448, 390)
        txtDiametro.Name = "txtDiametro"
        txtDiametro.Size = New Size(100, 23)
        txtDiametro.TabIndex = 36
        txtDiametro.Text = "0"
        txtDiametro.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(365, 393)
        Label4.Name = "Label4"
        Label4.Size = New Size(56, 15)
        Label4.TabIndex = 39
        Label4.Text = "Diametro"
        ' 
        ' progresoTimer
        ' 
        progresoTimer.Interval = 500
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(57, 415)
        Button2.Name = "Button2"
        Button2.Size = New Size(213, 23)
        Button2.TabIndex = 43
        Button2.Text = "Tomar parametros de esta imagen"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(365, 419)
        Label6.Name = "Label6"
        Label6.Size = New Size(102, 15)
        Label6.TabIndex = 45
        Label6.Text = "Espesor promedio"
        ' 
        ' txtEspesor
        ' 
        txtEspesor.Location = New Point(473, 416)
        txtEspesor.Name = "txtEspesor"
        txtEspesor.Size = New Size(75, 23)
        txtEspesor.TabIndex = 44
        txtEspesor.Text = "0"
        txtEspesor.TextAlign = HorizontalAlignment.Center
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Checked = True
        CheckBox1.CheckState = CheckState.Checked
        CheckBox1.Location = New Point(90, 390)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(157, 19)
        CheckBox1.TabIndex = 46
        CheckBox1.Text = "Limpiar Imagen al cargar"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label5.Location = New Point(391, 364)
        Label5.Name = "Label5"
        Label5.Size = New Size(123, 15)
        Label5.TabIndex = 47
        Label5.Text = "Parámetros del anillo"
        ' 
        ' btnDetectarLineas
        ' 
        btnDetectarLineas.Location = New Point(652, 419)
        btnDetectarLineas.Name = "btnDetectarLineas"
        btnDetectarLineas.Size = New Size(219, 23)
        btnDetectarLineas.TabIndex = 48
        btnDetectarLineas.Text = "Detectar 5  lineas"
        btnDetectarLineas.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(966, 476)
        Controls.Add(btnDetectarLineas)
        Controls.Add(Label5)
        Controls.Add(CheckBox1)
        Controls.Add(Label6)
        Controls.Add(txtEspesor)
        Controls.Add(Button2)
        Controls.Add(Label4)
        Controls.Add(txtDiametro)
        Controls.Add(imgEntrada)
        Controls.Add(ProgressBar1)
        Controls.Add(btnDetectarAnillo)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(btnCargarImagen)
        Controls.Add(imgSalida)
        Controls.Add(imgIntermedia)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Siglo 21 - Software de reconocimiento de patrones por IA con red de hough"
        CType(imgSalida, ComponentModel.ISupportInitialize).EndInit()
        CType(imgIntermedia, ComponentModel.ISupportInitialize).EndInit()
        CType(imgEntrada, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents btnDetectarAnillo As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCargarImagen As Button
    Friend WithEvents imgSalida As PictureBox
    Friend WithEvents imgIntermedia As PictureBox
    Friend WithEvents imgEntrada As PictureBox
    Friend WithEvents txtDiametro As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents progresoTimer As Timer
    Friend WithEvents Button2 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents txtEspesor As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnDetectarLineas As Button
End Class
