Imports System.Data.SqlClient
Public Class clsClientes
    Inherits clsConexionDB
    Dim sQuery As String
    Dim cmd As SqlCommand
#Region "Metodos Privados"
    Private Function pConsultaClientesDR(ByVal sTabla As String, ByVal sCampos As String, ByVal sFiltro As String) As System.Data.SqlClient.SqlDataReader
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Try
            sQuery = "SELECT " & sCampos & " FROM " & sTabla & " " & sFiltro
            Me.GeneraConexion()
            cmd = Me.Cnn.CreateCommand
            cmd = New SqlCommand(sQuery, Me.Cnn)
            dr = cmd.ExecuteReader
            Return dr
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Private Function pConsultaClientesDS(ByVal sTabla As String, ByVal sCampos As String, ByVal sFiltro As String) As System.Data.DataSet
        Dim dt As SqlDataAdapter
        Dim ds As New Data.DataSet

        Try
            sQuery = "SELECT " & sCampos & " FROM " & sTabla & " " & sFiltro
            Me.GeneraConexion()
            dt = New SqlDataAdapter(sQuery, Me.Cnn)
            dt.Fill(ds, sTabla)
            Me.DestruirConexion()
            Return ds

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Private Function pInsertaClientes(ByVal sNombre As String, ByVal sDir As String, ByVal sTel As String, ByVal sFax As String, ByVal sNit As String, ByVal sRegFisc As String) As Boolean
        Dim x As Integer
        Try
            sQuery = "INSERT INTO CLIENTES " _
                    & "(NOMB_CLIE," _
                    & "DIRE_CLIE," _
                    & "TELE_CLIE, " _
                    & "FAX_CLIE, " _
                    & "NIT_CLIE," _
                    & "REGI_FISC_CLIE) " _
                    & "VALUES(" _
                    & "'" & sNombre & "', " _
                    & "'" & sDir & "', " _
                    & "'" & sTel & "', " _
                    & "'" & sFax & "', " _
                    & "'" & sNit & "', " _
                    & "'" & sRegFisc & "') "
            Me.GeneraConexion()
            cmd = Me.Cnn.CreateCommand
            cmd = New SqlCommand(sQuery, Me.Cnn)
            x = cmd.ExecuteNonQuery
            Me.DestruirConexion()
            If x > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Private Function pModificaClientes(ByVal nCod As Integer, ByVal sNombre As String, ByVal sDir As String, ByVal sTel As String, ByVal sFax As String, ByVal sNit As String, ByVal sRegFisc As String) As Boolean
        Dim x As Integer
        Try
            sQuery = "UPDATE CLIENTES " _
                    & "SET NOMB_CLIE='" & sNombre & "', " _
                    & "DIRE_CLIE='" & sDir & "', " _
                    & "TELE_CLIE='" & sTel & "', " _
                    & "FAX_CLIE='" & sFax & "', " _
                    & "NIT_CLIE='" & sNit & "', " _
                    & "REGI_FISC_CLIE='" & sRegFisc & "' " _
                    & " WHERE CODIGO=" & nCod & ""

            Me.GeneraConexion()
            cmd = Me.Cnn.CreateCommand
            cmd = New SqlCommand(sQuery, Me.Cnn)
            x = cmd.ExecuteNonQuery()
            If x > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function




#End Region
#Region "Metodos Publicos"
    Public Overridable Function ConsultaClientesDR(ByVal sTabla As String, ByVal sCampos As String, ByVal sFiltro As String) As System.Data.SqlClient.SqlDataReader
        Dim dr As SqlDataReader
        Try
            dr = Me.pConsultaClientesDR(sTabla, sCampos, sFiltro)
            Return dr
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Overridable Function ConsultaClientesDS(ByVal sTabla As String, ByVal sCampos As String, ByVal sFiltro As String) As System.Data.DataSet
        Dim ds As New Data.DataSet
        Try
            ds = Me.pConsultaClientesDS(sTabla, sCampos, sFiltro)
            Return ds
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Overridable Function InsertaClientes(ByVal sNombre As String, ByVal sDir As String, ByVal sTel As String, ByVal sFax As String, ByVal sNit As String, ByVal sRegFisc As String) As Boolean
        Dim bResp As Boolean
        Try
            bResp = Me.pInsertaClientes(sNombre, sDir, sTel, sFax, sNit, sRegFisc)
            Return bResp
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Overridable Function ModificaClientes(ByVal nCod As Integer, ByVal sNombre As String, ByVal sDir As String, ByVal sTel As String, ByVal sFax As String, ByVal sNit As String, ByVal sRegFisc As String) As Boolean
        Dim bResp As Boolean
        Try
            bResp = Me.pModificaClientes(nCod, sNombre, sDir, sTel, sFax, sNit, sRegFisc)
            Return bResp
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function GetNomClie(ByVal nCod As Integer) As String
        Dim sNombre As String
        Try
            sQuery = "SELECT NOMB_CLIE FROM CLIENTES WHERE CODIGO=" & nCod & ""
            Me.GeneraConexion()
            cmd = Me.Cnn.CreateCommand
            cmd = New SqlCommand(sQuery, Me.Cnn)
            sNombre = cmd.ExecuteScalar
            Me.DestruirConexion()
            Return sNombre
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
#End Region

    Protected Overrides Sub Finalize()
        cmd = Nothing
        MyBase.Finalize()
    End Sub
End Class
