Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Reflection.Emit
Imports Microsoft.Reporting.WinForms

Public Class Form1



    Private Sub Registro1BindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.Registro1BindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.AlumnosDataSet)



    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim c As New SqlConnection("Data Source=DRINER;Initial Catalog=Alumnos;Integrated Security=True")
            c.Open()
            MsgBox("conexion exitosa")
        Catch ex As Exception
            MsgBox("mala conexion")
        End Try
        Me.Registro1TableAdapter.Fill(Me.AlumnosDataSet.registro1)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Registro1TableAdapter.insertar(IdTextBox.Text, NombresTextBox.Text, ApellidoTextBox.Text, TelefonoTextBox.Text, DireccionTextBox.Text, EmailTextBox.Text, fecha.Text)
        Me.Registro1TableAdapter.Fill(Me.AlumnosDataSet.registro1)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Registro1TableAdapter.modificar(IdTextBox.Text, NombresTextBox.Text, ApellidoTextBox.Text, TelefonoTextBox.Text, DireccionTextBox.Text, EmailTextBox.Text, fecha.Text, IdTextBox.Text)
        Me.Registro1TableAdapter.Fill(Me.AlumnosDataSet.registro1)
        MsgBox("datos modificados")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Registro1TableAdapter.eleminar(IdTextBox.Text)
        Me.Registro1TableAdapter.Fill(Me.AlumnosDataSet.registro1)
        MsgBox("datos eleminados")
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
End Class
