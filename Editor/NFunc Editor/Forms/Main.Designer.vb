<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripErrorRare = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnLearn = New System.Windows.Forms.Button()
        Me.tbUserInput = New System.Windows.Forms.TextBox()
        Me.tbNetKey = New System.Windows.Forms.TextBox()
        Me.tbNetOutputEncrypted = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.Chart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbOffset = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbNetOutputDecrypted = New System.Windows.Forms.TextBox()
        Me.StatusStrip.SuspendLayout()
        CType(Me.Chart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatus, Me.ToolStripErrorRare})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 521)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1205, 22)
        Me.StatusStrip.TabIndex = 1
        '
        'ToolStripStatus
        '
        Me.ToolStripStatus.Name = "ToolStripStatus"
        Me.ToolStripStatus.Size = New System.Drawing.Size(87, 17)
        Me.ToolStripStatus.Text = "Array Length: 0"
        '
        'ToolStripErrorRare
        '
        Me.ToolStripErrorRare.Name = "ToolStripErrorRare"
        Me.ToolStripErrorRare.Size = New System.Drawing.Size(35, 17)
        Me.ToolStripErrorRare.Text = "Idle..."
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(914, 12)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(89, 31)
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnLearn
        '
        Me.btnLearn.Location = New System.Drawing.Point(1009, 12)
        Me.btnLearn.Name = "btnLearn"
        Me.btnLearn.Size = New System.Drawing.Size(89, 31)
        Me.btnLearn.TabIndex = 4
        Me.btnLearn.Text = "Learn"
        Me.btnLearn.UseVisualStyleBackColor = True
        '
        'tbUserInput
        '
        Me.tbUserInput.Location = New System.Drawing.Point(12, 59)
        Me.tbUserInput.Name = "tbUserInput"
        Me.tbUserInput.Size = New System.Drawing.Size(1181, 20)
        Me.tbUserInput.TabIndex = 5
        '
        'tbNetKey
        '
        Me.tbNetKey.Location = New System.Drawing.Point(12, 137)
        Me.tbNetKey.Name = "tbNetKey"
        Me.tbNetKey.ReadOnly = True
        Me.tbNetKey.Size = New System.Drawing.Size(1181, 20)
        Me.tbNetKey.TabIndex = 6
        Me.tbNetKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbNetOutputEncrypted
        '
        Me.tbNetOutputEncrypted.Location = New System.Drawing.Point(12, 176)
        Me.tbNetOutputEncrypted.Name = "tbNetOutputEncrypted"
        Me.tbNetOutputEncrypted.ReadOnly = True
        Me.tbNetOutputEncrypted.Size = New System.Drawing.Size(1181, 20)
        Me.tbNetOutputEncrypted.TabIndex = 7
        Me.tbNetOutputEncrypted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 121)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Key"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Encrypted"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Message"
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(1104, 12)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(89, 31)
        Me.btnStop.TabIndex = 12
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'Chart
        '
        Me.Chart.BorderlineColor = System.Drawing.Color.Black
        Me.Chart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea2.Name = "ChartArea1"
        Me.Chart.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Chart.Legends.Add(Legend2)
        Me.Chart.Location = New System.Drawing.Point(12, 241)
        Me.Chart.Name = "Chart"
        Me.Chart.Size = New System.Drawing.Size(1181, 277)
        Me.Chart.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Offset"
        '
        'tbOffset
        '
        Me.tbOffset.Location = New System.Drawing.Point(12, 98)
        Me.tbOffset.Name = "tbOffset"
        Me.tbOffset.ReadOnly = True
        Me.tbOffset.Size = New System.Drawing.Size(1181, 20)
        Me.tbOffset.TabIndex = 15
        Me.tbOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 199)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Decrypted"
        '
        'tbNetOutputDecrypted
        '
        Me.tbNetOutputDecrypted.Location = New System.Drawing.Point(12, 215)
        Me.tbNetOutputDecrypted.Name = "tbNetOutputDecrypted"
        Me.tbNetOutputDecrypted.ReadOnly = True
        Me.tbNetOutputDecrypted.Size = New System.Drawing.Size(1181, 20)
        Me.tbNetOutputDecrypted.TabIndex = 17
        Me.tbNetOutputDecrypted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1205, 543)
        Me.Controls.Add(Me.tbNetOutputDecrypted)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbOffset)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Chart)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbNetOutputEncrypted)
        Me.Controls.Add(Me.tbNetKey)
        Me.Controls.Add(Me.tbUserInput)
        Me.Controls.Add(Me.btnLearn)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.StatusStrip)
        Me.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NFunc"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.Chart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnLearn As System.Windows.Forms.Button
    Friend WithEvents ToolStripErrorRare As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tbUserInput As System.Windows.Forms.TextBox
    Friend WithEvents tbNetKey As System.Windows.Forms.TextBox
    Friend WithEvents tbNetOutputEncrypted As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents Chart As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbOffset As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbNetOutputDecrypted As System.Windows.Forms.TextBox

End Class
