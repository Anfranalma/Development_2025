Imports LibClassCRM
Imports System.Windows.Forms

Public Class NewEmployee

    Dim bflag As Boolean
    Dim olib As New clsEmpleados
    Dim scadena As String

    Private Sub DATAClean()
        Me.txtCargo.Text = ""
        Me.txtCel.Text = ""
        Me.txtCod.Text = ""
        Me.txtEstado.Text = ""
        Me.txtDir.Text = ""
        Me.txtPrimApe.Text = ""
        Me.txtPrimerNom.Text = ""
        Me.txtSecApe.Text = ""
        Me.txtSecNom.Text = ""
        Me.txtTel.Text = ""
    End Sub

    Public Property AddReg() As Boolean
        Get
            Return bflag
        End Get
        Set(ByVal value As Boolean)
            bflag = value
        End Set
    End Property

    Public Property Cadena() As String
        Get
            Return scadena
        End Get
        Set(ByVal value As String)
            scadena = value
        End Set
    End Property

    Private Sub frmNewEmployee_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.AddReg = True Then
            Me.Text = "Insercion de Registros"
            Me.Label1.Text = "Insercion de Registros"
        Else
            Me.Text = "Actualizacion de Registros"
            Me.Label1.Text = "Actualizacion de Registros"
        End If
        Me.txtPrimerNom.Focus()

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        olib.Cadena = Me.Cadena
        If Me.AddReg = True Then
            If olib.InsertaEmpleados(Me.txtPrimerNom.Text, Me.txtSecNom.Text, Me.txtPrimApe.Text, Me.txtSecApe.Text, Me.txtDir.Text, Me.txtTel.Text, Me.txtCel.Text, Me.txtCargo.Text, Me.txtEstado.Text) = True Then
                Messagebox.show("")
            Else

            End If
            Me.DATAClean()
            Me.txtPrimerNom.Focus()
        Else
            olib.ModificaEmpleados(Integer.Parse(Me.txtCod.Text), Me.txtPrimerNom.Text, Me.txtSecNom.Text, _
                    Me.txtPrimApe.Text, Me.txtSecApe.Text, Me.txtDir.Text, Me.txtTel.Text, Me.txtCel.Text, _
                    Me.txtCargo.Text, Me.txtEstado.Text)
            Me.bntCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub bntCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntCancelar.Click
        Me.Close()
    End Sub




End Class