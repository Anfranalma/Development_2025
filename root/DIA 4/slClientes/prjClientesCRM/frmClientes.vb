Imports System.Data
Imports LibClasesCRM
Public Class frmClientes
    Dim oLib As New clsClientes
    Dim sCadena As String = "Data Source=grove-ok93nb4v3;Initial Catalog=DBCLASENET;Integrated Security=True"
    Dim dr As SqlClient.SqlDataReader
    Dim dt As New Data.DataTable
    Dim ds As New Data.DataSet

    Private Sub btnConsul_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsul.Click
        Try
            oLib.Cadena = sCadena
            dr = oLib.ConsultaClientesDR("CLIENTES", "*", "")
            dt.Load(dr, LoadOption.OverwriteChanges)
            Me.grdData.DataSource = dt
            Me.grdData.Refresh()
            oLib.DestruirConexion()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            oLib.Cadena = sCadena
            ds = oLib.ConsultaClientesDS("CLIENTES", "*", "")
            Me.grdData.DataSource = ds.Tables("Clientes").DefaultView
            Me.grdData.Refresh()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim frmTemp As New frmMsClientes
        frmTemp.AddReg = True
        frmTemp.Cadena = sCadena
        frmTemp.ShowDialog()
        Me.Button1_Click(sender, e)
    End Sub

    Private Sub grdData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdData.CellContentClick

    End Sub

    Private Sub grdData_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdData.CellDoubleClick
        Dim frmTemp As New frmMsClientes
        frmTemp.AddReg = False
        frmTemp.Cadena = sCadena
        frmTemp.txtNomClie.Text = Me.grdData.Item("NOMB_CLIE", e.RowIndex).Value
        frmTemp.txtCod.Text = Me.grdData.Item("CODIGO", e.RowIndex).Value
        frmTemp.txtDir.Text = IIf(IsDBNull(Me.grdData.Item("DIRE_CLIE", e.RowIndex).Value), "", Me.grdData.Item("DIRE_CLIE", e.RowIndex).Value)
        frmTemp.txtTel.Text = IIf(IsDBNull(Me.grdData.Item("TELE_CLIE", e.RowIndex).Value), "", Me.grdData.Item("TELE_CLIE", e.RowIndex).Value)
        frmTemp.txtFax.Text = IIf(IsDBNull(Me.grdData.Item("FAX_CLIE", e.RowIndex).Value), "", Me.grdData.Item("FAX_CLIE", e.RowIndex).Value)
        frmTemp.txtNit.Text = IIf(IsDBNull(Me.grdData.Item("NIT_CLIE", e.RowIndex).Value), "", Me.grdData.Item("NIT_CLIE", e.RowIndex).Value)
        frmTemp.txtRegF.Text = IIf(IsDBNull(Me.grdData.Item("REGI_FISC_CLIE", e.RowIndex).Value), "", Me.grdData.Item("REGI_FISC_CLIE", e.RowIndex).Value)
        frmTemp.ShowDialog()
        Me.Button1_Click(sender, e)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim frmTemp As New frmMsClientes
        frmTemp.AddReg = False
        frmTemp.Cadena = sCadena
        frmTemp.txtNomClie.Text = Me.grdData.Item("NOMB_CLIE", Me.grdData.CurrentRow.Index).Value
        frmTemp.txtCod.Text = Me.grdData.Item("CODIGO", Me.grdData.CurrentRow.Index).Value
        frmTemp.txtDir.Text = IIf(IsDBNull(Me.grdData.Item("DIRE_CLIE", Me.grdData.CurrentRow.Index).Value), "", Me.grdData.Item("DIRE_CLIE", Me.grdData.CurrentRow.Index).Value)
        frmTemp.txtTel.Text = IIf(IsDBNull(Me.grdData.Item("TELE_CLIE", Me.grdData.CurrentRow.Index).Value), "", Me.grdData.Item("TELE_CLIE", Me.grdData.CurrentRow.Index).Value)
        frmTemp.txtFax.Text = IIf(IsDBNull(Me.grdData.Item("FAX_CLIE", Me.grdData.CurrentRow.Index).Value), "", Me.grdData.Item("FAX_CLIE", Me.grdData.CurrentRow.Index).Value)
        frmTemp.txtNit.Text = IIf(IsDBNull(Me.grdData.Item("NIT_CLIE", Me.grdData.CurrentRow.Index).Value), "", Me.grdData.Item("NIT_CLIE", Me.grdData.CurrentRow.Index).Value)
        frmTemp.txtRegF.Text = IIf(IsDBNull(Me.grdData.Item("REGI_FISC_CLIE", Me.grdData.CurrentRow.Index).Value), "", Me.grdData.Item("REGI_FISC_CLIE", Me.grdData.CurrentRow.Index).Value)
        frmTemp.ShowDialog()
        Me.Button1_Click(sender, e)
    End Sub

    Private Sub frmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
