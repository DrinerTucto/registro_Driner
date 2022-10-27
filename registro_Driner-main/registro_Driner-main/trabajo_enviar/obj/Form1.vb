Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Reflection.Emit
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
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Registro1DataGridView.Text = Visible
        If IdTextBox.Text = "" Or NombresTextBox.Text = "" Or ApellidoTextBox.Text = "" Or TelefonoTextBox.Text = "" Or EmailTextBox.Text = "" Or fecha.Text = "" Or DireccionTextBox.Text = "" Then

            MsgBox("los campos no pueden estar vasillos")
        ElseIf IdTextBox.Text = Registro1DataGridView.Text Then
            MsgBox("hay campos repetidos")

        Else
            Try
                Me.Registro1TableAdapter.insertar(IdTextBox.Text, NombresTextBox.Text, ApellidoTextBox.Text, TelefonoTextBox.Text, DireccionTextBox.Text, EmailTextBox.Text, fecha.Text)

            Catch ex As Exception
                MsgBox("id repetido")
            End Try
            Me.Registro1TableAdapter.Fill(Me.AlumnosDataSet.registro1)
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

        If IdTextBox.Text = "" Or NombresTextBox.Text = "" Or ApellidoTextBox.Text = "" Or TelefonoTextBox.Text = "" Or EmailTextBox.Text = "" Or fecha.Text = "" Or DireccionTextBox.Text = "" Then
            MsgBox("seleciona campo a Eleminar")
        Else
            Me.Registro1TableAdapter.eleminar(IdTextBox.Text)
            Me.Registro1TableAdapter.Fill(Me.AlumnosDataSet.registro1)
            MsgBox("Datos eleminados")
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

    Private Sub Registro1DataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Registro1DataGridView.CellContentClick

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
    End Sub
End Class
