Imports System.Data.SqlClient
Public Class clsOrdenCompra
    Inherits clsConexionDB
    Private cmd As SqlCommand
    Private oParameter As New SqlParameter
    Private iParameter As New SqlParameter
    Private ds As New Data.DataSet
    Private dt As SqlDataAdapter
#Region "Metodos Privados"
    Private Function pInsertaEncaOrdenComp(ByVal dFecha As Date, ByVal nCodClie As Integer, ByVal nEstado As Integer) As Integer
        Dim nCorrMovi As Integer
        Try
            Me.GeneraConexion()
            cmd = Me.Cnn.CreateCommand
            cmd = New SqlCommand
            cmd.Connection = Me.Cnn
            cmd.CommandText = "SP_INSERT_ENCA_ORDEN_COMP"
            cmd.CommandType = CommandType.StoredProcedure
            oParameter = cmd.Parameters.Add("@CORR_MOVI", SqlDbType.Int, 0)
            oParameter.Direction = ParameterDirection.Output
            iParameter = cmd.Parameters.Add("@FECH_MOVI", SqlDbType.DateTime, 0)
            iParameter.Direction = ParameterDirection.Input
            iParameter.Value = dFecha
            iParameter = cmd.Parameters.Add("@CODI_CLIE", SqlDbType.Int, 0)
            iParameter.Direction = ParameterDirection.Input
            iParameter.Value = nCodClie
            iParameter = cmd.Parameters.Add("@ESTA_ORDE", SqlDbType.Int, 0)
            iParameter.Direction = ParameterDirection.Input
            iParameter.Value = nEstado
            cmd.ExecuteNonQuery()   
            nCorrMovi = oParameter.Value
            Me.DestruirConexion()

            Return nCorrMovi
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Private Function pInsertaDetaOrdenComp(ByVal nCorrMovi As Integer, ByVal sDescArti As String, ByVal nCant As Double, ByVal nPrecCosto As Double) As Boolean
        Dim x As Integer
        Try
            Me.GeneraConexion()
            cmd = Me.Cnn.CreateCommand
            cmd = New SqlCommand
            cmd.Connection = Me.Cnn
            cmd.CommandText = "SP_INSERT_DETA_ORDEN_COMP"
            cmd.CommandType = CommandType.StoredProcedure
            iParameter = cmd.Parameters.Add("@CORR_MOVI", SqlDbType.Int, 0)
            iParameter.Direction = ParameterDirection.Input
            iParameter.Value = nCorrMovi
            iParameter = cmd.Parameters.Add("@DESC_ARTI", SqlDbType.VarChar, 50)
            iParameter.Direction = ParameterDirection.Input
            iParameter.Value = sDescArti
            iParameter = cmd.Parameters.Add("@CANT_ARTI", SqlDbType.Decimal, 0)
            iParameter.Precision = 10
            iParameter.Scale = 4
            iParameter.Direction = ParameterDirection.Input
            iParameter.Value = nCant
            iParameter = cmd.Parameters.Add("@PREC_COSTO", SqlDbType.Decimal, 0)
            iParameter.Precision = 10
            iParameter.Scale = 4
            iParameter.Direction = ParameterDirection.Input
            iParameter.Value = nPrecCosto
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
    Private Function pConsultaEncaOrden(ByVal nCod As Integer) As System.Data.DataSet
        Try
            Me.GeneraConexion()
            cmd = Me.Cnn.CreateCommand
            cmd = New SqlCommand
            cmd.Connection = Me.Cnn
            cmd.CommandText = "SP_CONSULT_ENCA_ORDEN"
            cmd.CommandType = CommandType.StoredProcedure
            iParameter = cmd.Parameters.Add("@CORR_MOVI", SqlDbType.Int, 0)
            iParameter.Direction = ParameterDirection.Input
            iParameter.Value = nCod
            dt = New SqlDataAdapter
            dt.SelectCommand = cmd
            dt.Fill(ds, "ENCA_ORDEN_COMP")
            Return ds

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Private Function pConsultaRelacion() As System.Data.DataSet
        Dim sQuery As String
        Dim colP As Data.DataColumn
        Dim colH As Data.DataColumn
        Dim dr As Data.DataRelation

        Try
            Me.GeneraConexion()
            sQuery = "SELECT * FROM ENCA_ORDEN_COMP ORDER BY CORR_MOVI"
            dt = New SqlDataAdapter(sQuery, Me.Cnn)
            dt.Fill(ds, "ENCA_ORDEN")

            sQuery = "SELECT * FROM DETA_ORDE_COMP ORDER BY CORR_MOVI"
            dt = New SqlDataAdapter(sQuery, Me.Cnn)
            dt.Fill(ds, "DETA_ORDEN")

            ds.Tables("ENCA_ORDEN").PrimaryKey = New DataColumn() {ds.Tables("ENCA_ORDEN").Columns("CORR_MOVI")}
            ds.Tables("DETA_ORDEN").PrimaryKey = New DataColumn() {ds.Tables("DETA_ORDEN").Columns("CORR_MOVI"), ds.Tables("DETA_ORDEN").Columns("CORR_DETA")}

            colP = ds.Tables("ENCA_ORDEN").Columns("CORR_MOVI")
            colH = ds.Tables("DETA_ORDEN").Columns("CORR_MOVI")
            dr = New DataRelation("RELACION", colP, colH)
            ds.Relations.Add(dr)

            Return ds

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

#End Region
#Region "Metodos Publicos"
    Public Overridable Function InsertaEncaOrdenComp(ByVal dFecha As Date, ByVal nCodClie As Integer, ByVal nEstado As Integer) As Integer
        Dim nCorrMovi As Integer
        Try
            nCorrMovi = Me.pInsertaEncaOrdenComp(dFecha, nCodClie, nEstado)
            Return nCorrMovi
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Overridable Function InsertaDetaOrdenComp(ByVal nCorrMovi As Integer, ByVal sDescArti As String, ByVal nCant As Double, ByVal nPrecCosto As Double) As Boolean
        Dim bResp As Boolean
        Try
            bResp = Me.pInsertaDetaOrdenComp(nCorrMovi, sDescArti, nCant, nPrecCosto)
            Return bResp
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Overridable Function ConsultaEncaOrden(ByVal nCod As Integer) As System.Data.DataSet
        Try
            Return Me.pConsultaEncaOrden(nCod)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Overridable Function ConsultaRelacion() As System.Data.DataSet
        Try
            Return Me.pConsultaRelacion
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function
    Public Overridable Function ConsultaEncaOrden(ByVal sTabla As String, ByVal sCampos As String, ByVal sFiltro As String) As System.Data.DataSet
        Dim sQuery As String
        Try
            sQuery = "SELECT " & sCampos & " FROM " & sTabla & " " & sFiltro
            Me.GeneraConexion()
            dt = New SqlDataAdapter(sQuery, Me.Cnn)
            dt.Fill(ds, sTabla)
            Return ds
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function
    Public Overridable Function ConsultaDetalleOrden(ByVal nCod As Integer) As System.Data.DataSet
        Dim sQuery As String
        Try
            sQuery = "SELECT * FROM DETA_ORDE_COMP WHERE CORR_MOVI=" & nCod
            Me.GeneraConexion()
            dt = New SqlDataAdapter(sQuery, Me.Cnn)
            dt.Fill(ds, "DETA_ORDE_COMP")
            Return ds
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

#End Region
End Class
