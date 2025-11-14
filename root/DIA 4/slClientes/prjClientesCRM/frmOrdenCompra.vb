Imports System.Data.SqlClient
Imports LibClasesCRM
Public Class frmOrdenCompra
    Dim oLibO As New clsOrdenCompra
    Dim olibC As New clsClientes
    Private Sub frmOrdenCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Panel1.Enabled = False
    End Sub

    Private Sub txtCodClie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodClie.KeyPress
        If Asc(e.KeyChar) = 13 Then
            olibC.Cadena = "Data Source=grove-ok93nb4v3;Initial Catalog=DBCLASENET;Integrated Security=True"
            Me.txtNomClie.Text = olibC.GetNomClie(Integer.Parse(Me.txtCodClie.Text))
            SendKeys.Send(vbTab)
        End If
    End Sub

    
    Private Sub btnAddE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddE.Click
        Try
            oLibO.Cadena = "Data Source=HOME;Initial Catalog=DBCLASENET;Persist Security Info=True;User ID=intranet;password=intranet"
            Me.txtNumeOrde.Text = oLibO.InsertaEncaOrdenComp(Me.dtFecha.Value, Integer.Parse(Me.txtCodClie.Text), 0)
            Me.Panel1.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim ds As New Data.DataSet
        Dim dr As Data.DataRow
        Try
            oLibO.Cadena = "Data Source=grove-ok93nb4v3;Initial Catalog=DBCLASENET;Integrated Security=True"
            olibC.Cadena = "Data Source=grove-ok93nb4v3;Initial Catalog=DBCLASENET;Integrated Security=True"
            ds = oLibO.ConsultaEncaOrden(Me.txtNumeOrde.Text)
            dr = ds.Tables(0).Rows(0)
            Me.txtCodClie.Text = dr("CODI_CLIE")
            Me.dtFecha.Value = dr("FECH_MOVI")
            Me.txtNomClie.Text = olibC.GetNomClie(Integer.Parse(Me.txtCodClie.Text))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ds As New Data.DataSet
        Try
            oLibO.Cadena = "Data Source=grove-ok93nb4v3;Initial Catalog=DBCLASENET;Integrated Security=True"
            ds = oLibO.ConsultaDetalleOrden(Integer.Parse(Me.txtNumeOrde.Text))
            Me.grdData.DataSource = ds.Tables("DETA_ORDE_COMP").DefaultView
            Me.grdData.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim frmTemp As New frmMsDetaOrden
        Try
            frmTemp.Cadena = "Data Source=grove-ok93nb4v3;Initial Catalog=DBCLASENET;Integrated Security=True"
            frmTemp.NumOrden = Integer.Parse(Me.txtNumeOrde.Text)
            frmTemp.ShowDialog()
            Me.Button1_Click(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class