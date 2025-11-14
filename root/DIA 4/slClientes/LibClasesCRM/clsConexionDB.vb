Imports System.Data.SqlClient
Public Class clsConexionDB
    Private oCnn As New SqlConnection
    Private sCadena As String

#Region "Propiedades"
    Public Property Cnn() As SqlConnection
        Get
            Return oCnn
        End Get
        Set(ByVal value As SqlConnection)
            oCnn = value
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

#End Region
#Region "Metodos"
    Public Sub GeneraConexion()
        Try
            If oCnn.State = ConnectionState.Closed Then
                oCnn = New SqlConnection(Me.Cadena)
                oCnn.Open()
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Public Sub DestruirConexion()
        Try
            If oCnn.State = ConnectionState.Open Then
                oCnn.Close()
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region

    Public Sub New()
        oCnn = New SqlConnection()
    End Sub

    Protected Overrides Sub Finalize()
        oCnn = Nothing
        MyBase.Finalize()
    End Sub
End Class
