Imports System.Data
Imports LibClassCRM
Imports System.Windows.Forms

Public Class MttoEmpleados


    Dim olib As New clsEmpleados
    Dim sCadena As String = "Data Source=grove-ok93nb4v3;Initial Catalog=Empleados;Integrated Security=True"
    Dim dr As SqlClient.SqlDataReader
    Dim dt As New Data.DataTable
    Dim ds As New Data.DataSet




    Private Sub btnLeer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeer.Click
        Try
            olib.Cadena = sCadena
            ds = olib.consultaEmpleados("Empleados", "*", "")
            Me.grdView1.DataSource = ds.Tables("Empleados").DefaultView
            Me.grdView1.Refresh()


        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub bntAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntAdd.Click
        Dim FormTem As New NewEmployee
        FormTem.AddReg = True
        FormTem.Cadena = sCadena
        FormTem.ShowDialog()
        Me.btnLeer_Click(sender, e)
    End Sub

    Private Sub bntUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntUpdate.Click
        Dim formtem As New NewEmployee
        formtem.AddReg = False
        formtem.Cadena = sCadena
        formtem.txtPrimerNom.Text = Me.grdView1.Item("Nomb_Empl1", Me.grdView1.CurrentRow.Index).Value
        formtem.txtCod.Text = Me.grdView1.Item("Codigo", Me.grdView1.CurrentRow.Index).Value
        formtem.txtPrimApe.Text = Me.grdView1.Item("Apellido1", Me.grdView1.CurrentRow.Index).Value
        formtem.txtTel.Text = Me.grdView1.Item("Tele_Empl", Me.grdView1.CurrentRow.Index).Value
        formtem.txtCargo.Text = Me.grdView1.Item("Cargo_Empl", Me.grdView1.CurrentRow.Index).Value
        formtem.txtEstado.Text = Me.grdView1.Item("Esta_Empl", Me.grdView1.CurrentRow.Index).Value
        formtem.txtSecNom.Text = IIf(IsDBNull(Me.grdView1.Item("Nomb_Empl2", Me.grdView1.CurrentRow.Index).Value), "", Me.grdView1.Item("Nomb_Empl2", Me.grdView1.CurrentRow.Index).Value)
        formtem.txtSecApe.Text = IIf(IsDBNull(Me.grdView1.Item("Apellido2", Me.grdView1.CurrentRow.Index).Value), "", Me.grdView1.Item("Apellido2", Me.grdView1.CurrentRow.Index).Value)
        formtem.txtdir.Text = IIf(IsDBNull(Me.grdView1.Item("Dire_Empl", Me.grdView1.CurrentRow.Index).Value), "", Me.grdView1.Item("Dire_Empl", Me.grdView1.CurrentRow.Index).Value)
        formtem.txtCel.Text = IIf(IsDBNull(Me.grdView1.Item("Movil_Empl", Me.grdView1.CurrentRow.Index).Value), "", Me.grdView1.Item("Movil_Empl", Me.grdView1.CurrentRow.Index).Value)
        formtem.ShowDialog()
        Me.btnLeer_Click(sender, e)

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub grdView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdView1.CellDoubleClick
        Dim formtem As New NewEmployee
        formtem.AddReg = False
        formtem.Cadena = sCadena
        formtem.txtPrimerNom.Text = Me.grdView1.Item("Nomb_Empl1", Me.grdView1.CurrentRow.Index).Value
        formtem.txtCod.Text = Me.grdView1.Item("Codigo", Me.grdView1.CurrentRow.Index).Value
        formtem.txtPrimApe.Text = Me.grdView1.Item("Apellido1", Me.grdView1.CurrentRow.Index).Value
        formtem.txtTel.Text = Me.grdView1.Item("Tele_Empl", Me.grdView1.CurrentRow.Index).Value
        formtem.txtCargo.Text = Me.grdView1.Item("Cargo_Empl", Me.grdView1.CurrentRow.Index).Value
        formtem.txtEstado.Text = Me.grdView1.Item("Esta_Empl", Me.grdView1.CurrentRow.Index).Value
        formtem.txtSecNom.Text = IIf(IsDBNull(Me.grdView1.Item("Nomb_Empl2", Me.grdView1.CurrentRow.Index).Value), "", Me.grdView1.Item("Nomb_Empl2", Me.grdView1.CurrentRow.Index).Value)
        formtem.txtSecApe.Text = IIf(IsDBNull(Me.grdView1.Item("Apellido2", Me.grdView1.CurrentRow.Index).Value), "", Me.grdView1.Item("Apellido2", Me.grdView1.CurrentRow.Index).Value)
        formtem.txtdir.Text = IIf(IsDBNull(Me.grdView1.Item("Dire_Empl", Me.grdView1.CurrentRow.Index).Value), "", Me.grdView1.Item("Dire_Empl", Me.grdView1.CurrentRow.Index).Value)
        formtem.txtCel.Text = IIf(IsDBNull(Me.grdView1.Item("Movil_Empl", Me.grdView1.CurrentRow.Index).Value), "", Me.grdView1.Item("Movil_Empl", Me.grdView1.CurrentRow.Index).Value)
        formtem.ShowDialog()
        Me.btnLeer_Click(sender, e)
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim formtem As New VisorReport
        Try
            formtem.NumReport = 1
            formtem.oDS = ds
            formtem.ShowDialog()

        Catch ex As Exception
            messagebox.show(ex.Message)
        End Try
    End Sub
End Class