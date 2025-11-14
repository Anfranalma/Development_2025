Imports System.Data.DataSet
Imports LibClasesCRM

Public Class frmOCompra
    Dim oLib As New clsOrdenCompra
    Dim ds1 As New dsArchivo

    Private Sub frmOCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ds As New Data.DataSet
        Try

            oLib.Cadena = "Data Source=grove-ok93nb4v3;Initial Catalog=DBCLASENET;Integrated Security=True"
            ds = oLib.ConsultaRelacion
            Me.grdData.DataSource = ds.Tables("ENCA_ORDEN")
            Me.grdData.Refresh()
            Me.grdDataDeta.DataSource = ds.Tables("DETA_ORDEN").DefaultView
            Me.grdDataDeta.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class