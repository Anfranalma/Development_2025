Imports System.Data



Public Class VisorReport

    Dim ds As New Data.DataSet
    Dim oReporte As New EmpleadosCR
    Dim nReporte As Integer

    Public Property oDS() As System.Data.DataSet
        Get
            Return ds
        End Get
        Set(ByVal value As System.Data.DataSet)
            ds = value
        End Set
    End Property

    Public Property NumReport() As Integer
        Get
            Return nReporte
        End Get
        Set(ByVal value As Integer)
            nReporte = value
        End Set
    End Property



    Private Sub VisorReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Me.NumReport = 1 Then
                oReporte.SetDataSource(ds)
                Me.CrystalReportViewer1.ReportSource = oReporte

            End If
            Me.CrystalReportViewer1.RefreshReport()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Class