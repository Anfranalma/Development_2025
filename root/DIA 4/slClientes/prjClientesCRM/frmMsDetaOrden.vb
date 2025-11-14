Imports System.Data.SqlClient
Imports LibClasesCRM
Public Class frmMsDetaOrden
    Dim oLib As New clsOrdenCompra
    Dim nNumOrden As Integer
    Dim sCadena As String
    Public Property NumOrden() As Integer
        Get
            Return nNumOrden
        End Get
        Set(ByVal value As Integer)
            nNumOrden = value
        End Set
    End Property
    Public Property Cadena() As String
        Get
            Return sCadena
        End Get
        Set(ByVal value As String)
            sCadena = value
        End Set
    End Property
    Private Sub LimpiaDatos()
        Try
            Me.txtDescArti.Text = ""
            Me.txtCant.Text = 0
            Me.txtPrec.Text = 1
            Me.txtDescArti.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            oLib.Cadena = Me.Cadena
            oLib.InsertaDetaOrdenComp(Integer.Parse(Me.txtNumOrden.Text), Me.txtDescArti.Text, Double.Parse(Me.txtCant.Text), Double.Parse(Me.txtPrec.Text))
            Me.LimpiaDatos()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmMsDetaOrden_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtNumOrden.Text = Me.NumOrden
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class