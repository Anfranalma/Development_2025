Partial Class dsArchivo
    Partial Class DETA_ORDE_COMPDataTable

        Private Sub DETA_ORDE_COMPDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.DESC_ARTIColumn.ColumnName) Then
                'Agregar código de usuario aquí
            End If

        End Sub

    End Class

End Class
