Imports System.Configuration
Imports System.Data.SqlClient
Imports LibClasesCRM
Partial Class Controles_InsertaDatos
    Inherits System.Web.UI.UserControl
    Dim ds As New Data.DataSet
    Dim sCadena As String
    Dim oLib As New clsClientes
    Private Sub LimpiaDatos()
        Me.txtCodigo.Text = ""
        Me.txtNomClie.Text = ""
        Me.txtDirClie.Text = ""
        Me.txtFaxClie.Text = ""
        Me.txtNit.Text = ""
        Me.txtTelClie.Text = ""
        Me.txtRegFisc.Text = ""
    End Sub
    Protected Sub Page_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DataBinding
        oLib.Cadena = sCadena
        ds = oLib.ConsultaClientesDS("CLIENTES", "*", "")
        Me.grdData.DataSource = ds
        Me.grdData.DataBind()
        Session.Add("DS", ds)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sCadena = ConfigurationManager.ConnectionStrings.Item("strCadena").ConnectionString
        If (Not IsPostBack) Then
            Me.DataBind()
        End If
    End Sub

 

    Protected Sub grdData_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdData.PageIndexChanging
        Me.grdData.PageIndex = e.NewPageIndex
        Me.grdData.DataBind()
        Me.DataBind()
    End Sub

    Protected Sub grdData_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdData.SelectedIndexChanged
        Dim nKey As Integer
        Dim dr As Data.DataRow
        Try
            nKey = Me.grdData.SelectedDataKey.Item("CODIGO")
            ds = Session.Item("DS")
            dr = ds.Tables("CLIENTES").Rows(nKey)
            Me.txtCodigo.Text = IIf(IsDBNull(dr("CODIGO")), "", dr("CODIGO"))
            Me.txtNomClie.Text = IIf(IsDBNull(dr("NOMB_CLIE")), "", dr("NOMB_CLIE"))
            Me.txtDirClie.Text = IIf(IsDBNull(dr("DIRE_CLIE")), "", dr("DIRE_CLIE"))
            Me.txtTelClie.Text = IIf(IsDBNull(dr("TELE_CLIE")), "", dr("TELE_CLIE"))
            Me.txtFaxClie.Text = IIf(IsDBNull(dr("FAX_CLIE")), "", dr("FAX_CLIE"))
            Me.txtNit.Text = IIf(IsDBNull(dr("NIT_CLIE")), "", dr("NIT_CLIE"))
            Me.txtRegFisc.Text = IIf(IsDBNull(dr("REGI_FISC_CLIE")), "", dr("REGI_FISC_CLIE"))
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            oLib.Cadena = sCadena
            oLib.InsertaClientes(Me.txtNomClie.Text, Me.txtDirClie.Text, Me.txtTelClie.Text, Me.txtFaxClie.Text, Me.txtNit.Text, Me.txtRegFisc.Text)
            Me.LimpiaDatos()
            Me.DataBind()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Class
