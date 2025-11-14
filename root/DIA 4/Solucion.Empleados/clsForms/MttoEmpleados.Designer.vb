<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MttoEmpleados
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.grdView1 = New System.Windows.Forms.DataGridView
        Me.btnLeer = New System.Windows.Forms.Button
        Me.bntAdd = New System.Windows.Forms.Button
        Me.bntUpdate = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnPrint = New System.Windows.Forms.Button
        CType(Me.grdView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(262, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Mantenimienot de Empleados"
        '
        'grdView1
        '
        Me.grdView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdView1.Location = New System.Drawing.Point(16, 49)
        Me.grdView1.Name = "grdView1"
        Me.grdView1.Size = New System.Drawing.Size(501, 319)
        Me.grdView1.TabIndex = 1
        '
        'btnLeer
        '
        Me.btnLeer.Location = New System.Drawing.Point(14, 13)
        Me.btnLeer.Name = "btnLeer"
        Me.btnLeer.Size = New System.Drawing.Size(75, 51)
        Me.btnLeer.TabIndex = 2
        Me.btnLeer.Text = "Mostrar Registro de Empleados"
        Me.btnLeer.UseVisualStyleBackColor = True
        '
        'bntAdd
        '
        Me.bntAdd.Location = New System.Drawing.Point(14, 70)
        Me.bntAdd.Name = "bntAdd"
        Me.bntAdd.Size = New System.Drawing.Size(75, 51)
        Me.bntAdd.TabIndex = 3
        Me.bntAdd.Text = "Agregar Nuevo Registro"
        Me.bntAdd.UseVisualStyleBackColor = True
        '
        'bntUpdate
        '
        Me.bntUpdate.Location = New System.Drawing.Point(14, 127)
        Me.bntUpdate.Name = "bntUpdate"
        Me.bntUpdate.Size = New System.Drawing.Size(75, 51)
        Me.bntUpdate.TabIndex = 4
        Me.bntUpdate.Text = "Actualizar Registro"
        Me.bntUpdate.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(547, 345)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnPrint)
        Me.Panel1.Controls.Add(Me.btnLeer)
        Me.Panel1.Controls.Add(Me.bntUpdate)
        Me.Panel1.Controls.Add(Me.bntAdd)
        Me.Panel1.Location = New System.Drawing.Point(533, 49)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(106, 260)
        Me.Panel1.TabIndex = 6
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(14, 184)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(76, 51)
        Me.btnPrint.TabIndex = 5
        Me.btnPrint.Text = "Impimir Reporte"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'MttoEmpleados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 390)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.grdView1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "MttoEmpleados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento Empleados"
        CType(Me.grdView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnLeer As System.Windows.Forms.Button
    Friend WithEvents bntAdd As System.Windows.Forms.Button
    Friend WithEvents bntUpdate As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnPrint As System.Windows.Forms.Button
End Class
