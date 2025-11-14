Imports system.Data.SqlClient

Public Class clsEmpleados

    Inherits clsConexionDataBase
    Dim squery As String
    Dim cmd As SqlCommand

#Region "Metodos Privados"

    Private Function pconsultaEmpleados(ByVal stabla As String, ByVal scampos As String, ByVal sfiltro As String) As System.Data.DataSet
        Dim dt As SqlDataAdapter
        Dim ds As New Data.DataSet

        Try
            squery = "SELECT " & scampos & " FROM " & stabla & "" & sfiltro
            Me.makeConexion()
            dt = New SqlDataAdapter(squery, Me.Cnn)
            dt.Fill(ds, "Empleados")
            Me.burnConexion()
            Return ds
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Function pInsertaEmpleados(ByVal sPrimNom As String, _
    ByVal sSecNom As String, _
    ByVal sPrimApe As String, _
    ByVal sSecApe As String, _
    ByVal sDir As String, _
    ByVal sTelefono As String, _
    ByVal sCel As String, _
    ByVal sCargo As String, _
    ByVal sState As String) As Boolean

        Dim x As Integer
        Try
            squery = "INSERT INTO Empleados" _
                    & "(Nomb_Empl1, " _
                    & "Nomb_Empl2, " _
                    & "Apellido1, " _
                    & "Apellido2, " _
                    & "Dire_Empl, " _
                    & "Tele_Empl, " _
                    & "Movil_Empl, " _
                    & "Cargo_Empl, " _
                    & "Esta_Empl)  " _
                    & "VALUES(" _
                    & "'" & sPrimNom & "', " _
                    & "'" & sSecNom & "', " _
                    & "'" & sPrimApe & "', " _
                    & "'" & sSecApe & "', " _
                    & "'" & sDir & "', " _
                    & "'" & sTelefono & "', " _
                    & "'" & sCel & "', " _
                    & "'" & sCargo & "', " _
                    & "'" & sState & "') "
            Me.makeConexion()
            cmd = Me.Cnn.CreateCommand
            cmd = New SqlCommand(squery, Me.Cnn)
            x = cmd.ExecuteNonQuery()
            Me.burnConexion()
            If x > 0 Then
                Return True
            Else
                Return False

            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Function pModificaEmpleados(ByVal sCod As Integer, _
    ByVal sPrimNom As String, _
    ByVal sSecNom As String, _
    ByVal sPrimApe As String, _
    ByVal sSecApe As String, _
    ByVal sDir As String, _
    ByVal sTelefono As String, _
    ByVal sCel As String, _
    ByVal sCargo As String, _
    ByVal sState As String) As Boolean

        Dim x As Integer

        Try
            squery = "UPDATE Empleados " _
                    & "SET Nomb_Empl1='" & sPrimNom & "', " _
                    & "Nomb_Empl2='" & sSecNom & "', " _
                    & "Apellido1='" & sPrimApe & "', " _
                    & "Apellido2='" & sSecApe & "', " _
                    & "Dire_Empl='" & sDir & "', " _
                    & "Tele_Empl='" & sTelefono & "', " _
                    & "Movil_Empl='" & sCel & "', " _
                    & "Cargo_Empl='" & sCargo & "', " _
                    & "Esta_empl='" & sState & "' " _
                    & "WHERE Codigo=" & sCod & ""

            Me.makeConexion()
            cmd = Me.Cnn.CreateCommand
            cmd = New SqlCommand(squery, Me.Cnn)
            x = cmd.ExecuteNonQuery
            If x > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

#End Region



#Region "Metodos Publicos"

    Public Overridable Function consultaEmpleados(ByVal stabla As String, ByVal scampos As String, ByVal sfiltro As String) As System.Data.DataSet
        Dim ds As New Data.DataSet
        Try
            ds = Me.pconsultaEmpleados(stabla, scampos, sfiltro)
            Return ds
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Overridable Function InsertaEmpleados( _
    ByVal sPrimNom As String, _
    ByVal sSecNom As String, _
    ByVal sPrimApe As String, _
    ByVal sSecApe As String, _
    ByVal sDir As String, _
    ByVal sTelefono As String, _
    ByVal sCel As String, _
    ByVal sCargo As String, _
    ByVal sState As String) As Boolean
        Dim Respuesta As Boolean
        Try
            Respuesta = Me.pInsertaEmpleados(sPrimNom, sSecNom, sPrimApe, sSecApe, sDir, sTelefono, sCel, sCargo, sState)
            Return Respuesta

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Overridable Function ModificaEmpleados(ByVal scod As Integer, _
    ByVal sPrimNom As String, _
    ByVal sSecNom As String, _
    ByVal sPrimApe As String, _
    ByVal sSecApe As String, _
    ByVal sDir As String, _
    ByVal sTelefono As String, _
    ByVal sCel As String, _
    ByVal sCargo As String, _
    ByVal sState As String) As Boolean
        Dim Respuesta As Boolean
        Try
            Respuesta = Me.pModificaEmpleados(scod, sPrimNom, sSecNom, sPrimApe, sSecApe, sDir, sTelefono, sCel, sCargo, sState)
            Return Respuesta
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

#End Region

    Protected Overrides Sub finalize()
        cmd = Nothing
        MyBase.finalize()

    End Sub


End Class

