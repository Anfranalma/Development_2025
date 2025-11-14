Imports System.Configuration
Imports System.Data.SqlClient
Imports LibClasesCRM
Partial Class ConsultaDatos
    Inherits System.Web.UI.Page
    Dim oLib As New clsOrdenCompra
    Dim sCadena As String
    Dim ds As Data.DataSet
    Dim dr As Data.DataRow
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dr = Session.Item("DRC")
        Me.txtCodClie.Text = dr("CODIGO")
    End Sub

    Protected Sub grdData_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdData.PageIndexChanging
        Me.btnBuscar_Click(sender, e)
        Me.grdData.PageIndex = e.NewPageIndex
        Me.grdData.DataBind()
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        sCadena = ConfigurationManager.ConnectionStrings.Item("strCadena").ConnectionString
        oLib.Cadena = sCadena
        ds = oLib.ConsultaEncaOrden("ENCA_ORDEN_COMP", "CORR_MOVI,FECH_MOVI,CODI_CLIE,ESTA_ORDE", "WHERE CODI_CLIE=" & Integer.Parse(Me.txtCodClie.Text) & "")
        Me.grdData.DataSource = ds
        Me.grdData.DataBind()
    End Sub

  

    Protected Sub btnReg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReg.Click
        Response.Redirect("MttoClientes.aspx", False)
    End Sub
End Class
