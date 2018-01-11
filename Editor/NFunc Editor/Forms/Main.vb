Imports NFunc.Extensions
Imports System.IO
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Main
    Private Property Network As Network
    Private Property Profile As Profile
    Private Property Compare As List(Of Double)
    Private Property WaitHandle As Threading.ManualResetEvent
    Private Sub Main_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        Me.Compare = New List(Of Double)
        Me.WaitHandle = New Threading.ManualResetEvent(False)
        If (File.Exists(".\Network.bin") AndAlso File.Exists(".\Profile.bin")) Then
            Me.Network = File.ReadAllBytes(".\Network.bin").Deserialize(Of Network)()
            Me.Profile = File.ReadAllBytes(".\Profile.bin").Deserialize(Of Profile)()
            AddHandler Me.Network.Status, AddressOf Me.EventNetworkStatus
            AddHandler Me.Network.Update, AddressOf Me.EventNetworkUpdate
            Me.tbUserInput.Text = Me.Profile.Characters
            Me.UpdateCharts()
            Me.UpdateInput()
        Else
            Me.Profile = New Profile
            Me.Network = New Network
            AddHandler Me.Network.Status, AddressOf Me.EventNetworkStatus
            AddHandler Me.Network.Update, AddressOf Me.EventNetworkUpdate
            Me.tbUserInput.Text = Me.Profile.Characters
            Me.ResetNetwork()
            Me.UpdateCharts()
        End If

    End Sub
    Private Sub btnNew_Click(sender As Object, e As System.EventArgs) Handles btnNew.Click
        Me.tbNetKey.Clear()
        Me.tbNetOutputEncrypted.Clear()
        Me.tbNetOutputDecrypted.Clear()
        Me.ResetNetwork()
        Me.UpdateCharts()
    End Sub
    Private Sub btnLearn_Click(sender As Object, e As System.EventArgs) Handles btnLearn.Click
        Call New Threading.Thread(AddressOf Me.Learn) With {.IsBackground = True}.Start()
    End Sub
    Private Sub btnStop_Click(sender As Object, e As System.EventArgs) Handles btnStop.Click
        Me.WaitHandle.Set()
    End Sub
    Private Sub tbUserInput_KeyUp(sender As Object, e As KeyEventArgs) Handles tbUserInput.KeyUp
        If (Me.tbUserInput.Text.Length > 0) Then
            Me.UpdateInput()
        Else
            Me.tbNetOutputEncrypted.Clear()
            Me.tbNetOutputDecrypted.Clear()
        End If
    End Sub
    Private Sub EventNetworkStatus(Type As EventType, Args As EventArgs)
        If (Type = EventType.Error) Then
            Debugger.Break()
        End If
    End Sub
    Private Sub EventNetworkUpdate(Index As Integer, Length As Integer, Output As Double, Correction As Double)
        Me.Compare.Add(Output)
        If (Index = Me.Profile.Offsets.Count - 1) Then
            Me.UpdateChart("Output", Compare.Normalize)
            Me.UpdateStatus(String.Format("Learning...[{0}/{1}]", Math.Round(Output, 8), Math.Round(Correction, 8)))
            Me.Compare.Clear()
            Me.UpdateInput()
        End If
    End Sub
    Private Sub ResetNetwork()
        Me.Profile.Randomize(Me.Network)
        Me.Network.Reinitialize()
    End Sub
    Private Sub Learn()
        Me.UpdateGUI(False)
        Me.WaitHandle.Reset()
        Call New Threading.Thread(Sub() Me.Network.Learn(Me.Profile.Offsets.ToArray, Me.Profile.Key.ToArray, Me.Profile.Offsets.ToArray)) With {.IsBackground = True}.Start()
        Me.WaitHandle.WaitOne()
        Me.Network.Abort()
        Me.UpdateGUI()
        Me.UpdateStatus("Idle...")
        Me.Network.Save(".\Network.bin")
        Me.Profile.Save(".\Profile.bin")
        Me.UpdateGUI(True)
    End Sub
    Private Sub UpdateCharts()
        Me.Chart.Series.Clear()
        Me.Chart.Series.Add("Key")
        Me.Chart.Series("Key").Color = Color.DarkGray
        Me.Chart.Series("Key").XValueType = ChartValueType.Double
        Me.Chart.Series("Key").ChartType = SeriesChartType.Column
        Me.Chart.Series.Add("Offsets")
        Me.Chart.Series("Offsets").Color = Color.Red
        Me.Chart.Series("Offsets").XValueType = ChartValueType.Double
        Me.Chart.Series("Offsets").ChartType = SeriesChartType.FastLine
        Me.Chart.Series.Add("Output")
        Me.Chart.Series("Output").Color = Color.Blue
        Me.Chart.Series("Output").XValueType = ChartValueType.Double
        Me.Chart.Series("Output").ChartType = SeriesChartType.FastLine

        Me.tbNetKey.Clear()
        Me.UpdateGUI()
        Me.UpdateChart("Offsets", Me.Profile.Offsets)
        Me.UpdateChart("Key", Me.Profile.Key)
    End Sub
    Private Sub UpdateInput()
        If (Me.InvokeRequired) Then
            Me.Invoke(Sub() Me.UpdateInput())
        Else
            If (Me.tbUserInput.Text.Length > 0) Then
                Me.tbNetOutputEncrypted.Clear()
                Me.tbNetOutputDecrypted.Clear()
                Dim encrypted As String = Me.Profile.Encrypt(Me.tbUserInput.Text)
                Dim decrypted As String = Me.Profile.Decrypt(Me.Network, encrypted)
                Me.tbNetOutputEncrypted.Text = encrypted
                Me.tbNetOutputDecrypted.Text = decrypted
            End If
        End If
    End Sub
    Private Sub UpdateGUI()
        If (Me.InvokeRequired) Then
            Me.Invoke(Sub() Me.UpdateGUI())
        Else
            Me.tbOffset.Text = String.Join(",", Me.Profile.Offsets.Select(Function(x) CInt(x * Me.Profile.Multiplier).ToString("X")))
            Me.tbNetKey.Text = String.Join(",", Me.Profile.Key.Select(Function(x) CInt(x * Me.Profile.Multiplier).ToString("X")))
            Me.ToolStripStatus.Text = String.Format("Characters: {0}", Me.Profile.Characters.Length)
        End If
    End Sub
    Private Sub UpdateChart(Name As String, data As List(Of Double))
        If (Me.InvokeRequired) Then
            Me.Invoke(Sub() Me.UpdateChart(Name, data))
        Else
            Me.Chart.Series(Name).Points.Clear()
            For i As Integer = 0 To data.Count - 1
                Me.Chart.Series(Name).Points.AddXY(i, data(i) * Me.Profile.Multiplier)
            Next
            Me.Chart.Refresh()
        End If

    End Sub
    Private Sub UpdateStatus(Message As String)
        If (Me.InvokeRequired) Then
            Me.Invoke(Sub() Me.UpdateStatus(Message))
        Else
            Me.ToolStripErrorRare.Text = Message
        End If
    End Sub
    Private Sub UpdateGUI(state As Boolean)
        If (Me.InvokeRequired) Then
            Me.Invoke(Sub() Me.UpdateGUI(state))
        Else
            Me.btnLearn.Enabled = state
            Me.btnNew.Enabled = state
        End If
    End Sub
End Class
