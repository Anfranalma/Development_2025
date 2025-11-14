Imports LibClasesCRM
Public Class frmMsClientes
    Dim bFlag As Boolean
    Dim oLib As New clsClientes
    Dim sCadena As String
    Private Sub LimpiaDatos()
        Me.txtNomClie.Text = ""
        Me.txtDir.Text = ""
        Me.txtTel.Text = ""
        Me.txtFax.Text = ""
        Me.txtRegF.Text = ""
        Me.txtNit.Text = ""
    End Sub
    Public Property AddReg() As Boolean
        Get
            Return bFlag
        End Get
        Set(ByVal value As Boolean)
            bFlag = value
        End Set
    End Property

    Public Property Cadena() As String
        Get
            Return sCadena
        End Get
        Set(ByVal value As String)
            sCadena = value
        End Set
    End Property

    Private Sub frmMsClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.AddReg = True Then
            Me.Text = "Inserta Clientes"
        Else
            Me.Text = "Modifica Clientes"
        End If
        Me.txtNomClie.Focus()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        oLib.Cadena = Me.Cadena

        If Me.AddReg = True Then
            If oLib.InsertaClientes(Me.txtNomClie.Text, Me.txtDir.Text, Me.txtTel.Text, Me.txtFax.Text, Me.txtNit.Text, Me.txtRegF.Text) = True Then
                MessageBox.Show("")
            Else

            End If
            Me.LimpiaDatos()
            Me.txtNomClie.Focus()
        Else
            oLib.ModificaClientes(Integer.Parse(Me.txtCod.Text), Me.txtNomClie.Text, Me.txtDir.Text, Me.txtTel.Text, Me.txtFax.Text, Me.txtNit.Text, Me.txtRegF.Text)
            Me.Button2_Click(sender, e)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class