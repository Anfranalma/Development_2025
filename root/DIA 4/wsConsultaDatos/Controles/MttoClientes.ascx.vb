Imports System.Configuration
Imports System.Data.SqlClient
Imports LibClasesCRM
Partial Class Controles_MttoClientes
    Inherits System.Web.UI.UserControl
    Dim oLib As New clsClientes
    Dim ds As New Data.DataSet
    Dim sCadena As String
    Private Sub LimpiaDatos()
        Me.txtCodClie.Text = ""
        Me.txtNomClie.Text = ""
        Me.txtDir.Text = ""
        Me.txtTel.Text = ""
        Me.txtFax.Text = ""
        Me.txtNit.Text = ""
        Me.txtRegFisc.Text = ""
    End Sub
    Public Property Cadena() As String
        Get
            Return sCadena
        End Get
        Set(ByVal value As String)
            sCadena = value
        End Set
    End Property

    Protected Sub Page_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataBinding
        oLib.Cadena = sCadena
        ds = oLib.ConsultaClientesDS("CLIENTES", "CODIGO,NOMB_CLIE,TELE_CLIE", "")
        Me.grdData.DataSource = ds
        Me.grdData.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sCadena = ConfigurationManager.ConnectionStrings.Item("strCadena").ConnectionString
        Me.DataBind()
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            oLib.Cadena = sCadena
            oLib.InsertaClientes(Me.txtNomClie.Text, Me.txtDir.Text, Me.txtTel.Text, Me.txtFax.Text, Me.txtNit.Text, Me.txtRegFisc.Text)
            Me.LimpiaDatos()
            Me.DataBind()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Protected Sub grdData_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdData.PageIndexChanging
        Me.grdData.PageIndex = e.NewPageIndex
        Me.grdData.DataBind()
    End Sub

 
    Protected Sub grdData_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdData.SelectedIndexChanged
        Dim nKey As Integer
        Dim dsF As New Data.DataSet
        Dim dr As Data.DataRow

        nKey = Me.grdData.SelectedDataKey.Item("CODIGO")
        oLib.Cadena = sCadena
        dsF = oLib.ConsultaClientesDS("CLIENTES", "*", " WHERE CODIGO=" & nKey & "")
        dr = dsF.Tables("CLIENTES").Rows(0)
        Session.Add("DRC", dr)
        Me.txtCodClie.Text = IIf(IsDBNull(dr("CODIGO")), "", dr("CODIGO"))
        Me.txtNomClie.Text = IIf(IsDBNull(dr("NOMB_CLIE")), "", dr("NOMB_CLIE"))
        Me.txtTel.Text = IIf(IsDBNull(dr("TELE_CLIE")), "", dr("TELE_CLIE"))
        Me.txtDir.Text = IIf(IsDBNull(dr("DIRE_CLIE")), "", dr("DIRE_CLIE"))
        Me.txtFax.Text = IIf(IsDBNull(dr("FAX_CLIE")), "", dr("FAX_CLIE"))
        Me.txtNit.Text = IIf(IsDBNull(dr("NIT_CLIE")), "", dr("NIT_CLIE"))
        Me.txtRegFisc.Text = IIf(IsDBNull(dr("REGI_FISC_CLIE")), "", dr("REGI_FISC_CLIE"))
    End Sub

    Protected Sub btnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        Try
            oLib.Cadena = sCadena
            oLib.ModificaClientes(Integer.Parse(Me.txtCodClie.Text), Me.txtNomClie.Text, Me.txtDir.Text, Me.txtTel.Text, Me.txtFax.Text, Me.txtNit.Text, Me.txtRegFisc.Text)
            Me.LimpiaDatos()
            Me.DataBind()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Protected Sub btnConsulta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsulta.Click
        Response.Redirect("ConsultaDatos.aspx", False)
    End Sub
End Class
