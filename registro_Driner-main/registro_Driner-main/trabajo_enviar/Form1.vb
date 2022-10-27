Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Reflection.Emit
Imports System.Web.UI.WebControls
Imports trabajo_enviar.AlumnosDataSetTableAdapters

Public Class Form1



    Private Sub Registro1BindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.Registro1BindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.AlumnosDataSet)



    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'conexion a la base de datos sqlserver
        Try
            Dim c As New SqlConnection("Data Source=DRINER;Initial Catalog=Alumnos;Integrated Security=True")
            c.Open()
        Catch ex As Exception
            MsgBox("mala conexion")
        End Try
        Me.Registro1TableAdapter.Fill(Me.AlumnosDataSet.registro1)
        'esto aremos para que al momento de iniciar el programa aparesca vasillo el programa ya que al momento de ingresar los datos se quedan guardados
        IdTextBox.Text = ""
        NombresTextBox.Text = ""
        ApellidoTextBox.Text = ""
        TelefonoTextBox.Text = ""
        EmailTextBox.Text = ""
        fecha.Text = ""
        DireccionTextBox.Text = ""
        observacion.Text = ""

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If IdTextBox.Text = "" Or NombresTextBox.Text = "" Or ApellidoTextBox.Text = "" Or TelefonoTextBox.Text = "" Or EmailTextBox.Text = "" Or fecha.Text = "" Or DireccionTextBox.Text = "" Then

            MsgBox("los campos no pueden estar vasillos")
        Else

            Try
                Me.Registro1TableAdapter.insertar(IdTextBox.Text, NombresTextBox.Text, ApellidoTextBox.Text, TelefonoTextBox.Text, DireccionTextBox.Text, EmailTextBox.Text, fecha.Text)

            Catch ex As Exception
                MsgBox("id repetido")


            End Try

            Me.Registro1TableAdapter.Fill(Me.AlumnosDataSet.registro1)
            IdTextBox.Text = ""
            NombresTextBox.Text = ""
            ApellidoTextBox.Text = ""
            TelefonoTextBox.Text = ""
            EmailTextBox.Text = ""
            fecha.Text = ""
            DireccionTextBox.Text = ""
            observacion.Text = ""

        End If



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If IdTextBox.Text = "" Or NombresTextBox.Text = "" Or ApellidoTextBox.Text = "" Or TelefonoTextBox.Text = "" Or EmailTextBox.Text = "" Or fecha.Text = "" Or DireccionTextBox.Text = "" Then


            MsgBox("seleciona campo a modificar")



        Else
            Me.Registro1TableAdapter.modificar(IdTextBox.Text, NombresTextBox.Text, ApellidoTextBox.Text, TelefonoTextBox.Text, DireccionTextBox.Text, EmailTextBox.Text, fecha.Text, IdTextBox.Text)
            Me.Registro1TableAdapter.Fill(Me.AlumnosDataSet.registro1)
            MsgBox("datos modificados")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If IdTextBox.Text = "" And NombresTextBox.Text = "" And ApellidoTextBox.Text = "" And TelefonoTextBox.Text = "" And EmailTextBox.Text = "" And DireccionTextBox.Text = "" And observacion.Text = "" Then
            MsgBox("Los campos ya estan vasillos")

        Else

            IdTextBox.Text = ""
            NombresTextBox.Text = ""
            ApellidoTextBox.Text = ""
            TelefonoTextBox.Text = ""
            EmailTextBox.Text = ""
            fecha.Text = ""
            DireccionTextBox.Text = ""
            observacion.Text = ""
        End If



    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'creamos un procedimiento la funcion DateAndTime.TimeOfDay para mostrar la ora actual segun el sistema
        Label1.Text = Format(DateAndTime.TimeOfDay, "hh") & ":" 'horas'
        Label2.Text = Format(DateAndTime.TimeOfDay, "mm") 'minutos'
        Label3.Text = Format(DateAndTime.TimeOfDay, "ss")  'segundos'
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        'esto nos ayuda a predecir si la hora es pm  o am 
        If Val(Label1.Text) > 12 Then
            Label3.Text = "AM"
        Else
            Label3.Text = "PM"
        End If

        'aqui creamos las variables para la fecha de nacimiento 
    End Sub
    Dim edad As Integer
    'con la funcion now.date.tostrig aremos que nos de la fecha actual
    Dim hoy As String = Now.Date.ToString("dd/MM/yyyy") 'dia,mes,año'
    Dim fechahoy As Integer
    Dim naci As Integer

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form2.Show()

    End Sub

    Private Sub IdLabel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub ApellidoLabel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub fecha_ValueChanged(sender As Object, e As EventArgs) Handles fecha.ValueChanged
        'la fecha para poder mostrAR la edad del cliente al momento dew que ingresa su fecha de nacimiento
        fechahoy = CDate(hoy).Date.Year
        naci = fecha.Value.Year
        edad = fechahoy - naci
        If naci > fechahoy Then
            MsgBox("LA FECHA NO PUEDE SER MAYOR A LA FECHA ACTUAL")
        ElseIf edad > 102 Then
            MsgBox("!ERES MUY MAYOR!,ME SORPRENDE QUE SIGAS VIVO!")
        ElseIf edad < 10 And edad > 1 Then
            MsgBox("ERES UN NIÑO AUN PARA USAR EL PROGAMA")
        Else
            Label12.Text = $"{edad } años "

        End If

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick

    End Sub

    Private Sub NombresLabel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DireccionLabel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        Configuracion.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Configuracion.Show()

    End Sub

    Private Sub IdTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles IdTextBox.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            MsgBox("escriba solo numeros")
        End If
    End Sub

    Private Sub IdTextBox_TextChanged(sender As Object, e As EventArgs) Handles IdTextBox.TextChanged

    End Sub

    Private Sub TelefonoTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TelefonoTextBox.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            MsgBox("escriba solo numeros")
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If IdTextBox.Text = "" Or NombresTextBox.Text = "" Or ApellidoTextBox.Text = "" Or TelefonoTextBox.Text = "" Or EmailTextBox.Text = "" Or fecha.Text = "" Or DireccionTextBox.Text = "" Then
            MsgBox("seleciona campo a Eleminar")
        Else
            Me.Registro1TableAdapter.eleminar(IdTextBox.Text)
            Me.Registro1TableAdapter.Fill(Me.AlumnosDataSet.registro1)
            MsgBox("Datos eleminados")
        End If

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub Registro1DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Registro1DataGridView.CellClick
        'esto nos ayudara a poder mandar los datos de DataGriedView al mometo de hacer clik en cualquiera de sus campos
        Dim i As Integer = Registro1DataGridView.CurrentRow.Index

        IdTextBox.Text = Registro1DataGridView(0, i).Value
        NombresTextBox.Text = Registro1DataGridView(1, i).Value
        ApellidoTextBox.Text = Registro1DataGridView(2, i).Value
        TelefonoTextBox.Text = Registro1DataGridView(3, i).Value
        DireccionTextBox.Text = Registro1DataGridView(4, i).Value
        EmailTextBox.Text = Registro1DataGridView(5, i).Value
        fecha.Text = Registro1DataGridView(6, i).Value

    End Sub

    Private Sub observacion_TextChanged(sender As Object, e As EventArgs) Handles observacion.TextChanged

    End Sub

    Private Sub Registro1DataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Registro1DataGridView.CellContentClick

    End Sub
End Class
