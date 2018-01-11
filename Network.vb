Imports NFunc.Functions
Imports System.IO

<Serializable>
Public NotInheritable Class Network
    Public Property Learning As Boolean
    Public Property Sigmoid As IFunction
    Public Property Neurons As List(Of Neuron)
    <NonSerialized> Public Event Status(Type As EventType, Args As EventArgs)
    <NonSerialized> Public Event Update(Index As Integer, Length As Integer, Output As Double, Correction As Double)
    Sub New()
        Me.Sigmoid = New Sigmoid()
    End Sub
    Public Sub Reinitialize()
        Me.Reset()
        Me.Randomize()
    End Sub
    Public Sub Abort()
        Me.Learning = False
    End Sub
    Public Sub Reset()
        Me.Neurons = New List(Of Neuron)
        Me.Neurons.Add(New Neuron(Me, NeuronType.Hidden, "N1"))
        Me.Neurons.Add(New Neuron(Me, NeuronType.Hidden, "N2"))
        Me.Neurons.Add(New Neuron(Me, NeuronType.Output, "N3"))
    End Sub
    Public Function Solve(input As Double(), key As Double()) As Double()
        Dim buffer As New List(Of Double)
        Dim NH1 As Neuron = Me.GetNeuron(NeuronType.Hidden, 0)
        Dim NH2 As Neuron = Me.GetNeuron(NeuronType.Hidden, 1)
        Dim NOUT As Neuron = Me.GetNeuron(NeuronType.Output)
        For index As Integer = 0 To input.Length - 1
            NH1.Input = New Double() {input(index), key(index)}
            NH2.Input = New Double() {input(index), key(index)}
            NOUT.Input = New Double() {NH1.Output, NH2.Output}
            buffer.Add(NOUT.Output)
        Next
        Return buffer.ToArray
    End Function
    Public Sub Learn(input As Double(), key As Double(), output As Double())
        Try
            Dim Epoch As Integer = 0
            Dim NH1 As Neuron = Me.GetNeuron(NeuronType.Hidden, 0)
            Dim NH2 As Neuron = Me.GetNeuron(NeuronType.Hidden, 1)
            Dim NOUT As Neuron = Me.GetNeuron(NeuronType.Output)
            Me.Learning = True
            RaiseEvent Status(EventType.Learning, New EventArgs())
            Do
                Epoch += 1
                For index As Integer = 0 To output.Length - 1
                    NH1.Input = New Double() {input(index), key(index)}
                    NH2.Input = New Double() {input(index), key(index)}
                    NOUT.Input = New Double() {NH1.Output, NH2.Output}
                    If (Epoch Mod 100 = 0 And Epoch <> 0) Then
                        RaiseEvent Update(index, output.Length, NOUT.Output, NOUT.Correction)
                    End If
                    NOUT.Correction = Me.Sigmoid.F(NOUT.Output) * (output(index) - NOUT.Output)
                    NOUT.Update()
                    NH1.Correction = Me.Sigmoid.F(NH1.Output) * NOUT.Correction * NOUT.Weight(0)
                    NH2.Correction = Me.Sigmoid.F(NH2.Output) * NOUT.Correction * NOUT.Weight(1)
                    NH1.Update()
                    NH2.Update()
                Next
            Loop While Me.Learning
        Catch ex As Exception
            RaiseEvent Status(EventType.Error, New EventArgs(ex.Message))
        Finally
            RaiseEvent Status(EventType.Idle, New EventArgs)
        End Try
    End Sub
    Public Sub Save(filename As String)
        Me.Serialize().Save(Path.GetFullPath(filename))
    End Sub
    Public Function Random() As Random
        Static rnd As New Random(Me.GetHashCode)
        Return rnd
    End Function
    Private Sub Randomize()
        If (Me.Neurons.Any) Then Me.Neurons.ForEach(Sub(n) n.Randomize())
    End Sub
    Private Function GetNeuron(Name As String) As Neuron
        Return (From n As Neuron In Me.Neurons Where n.Name.Equals(Name)).FirstOrDefault
    End Function
    Private Function GetNeuron(Type As NeuronType) As Neuron
        Return (From n As Neuron In Me.Neurons Where n.Type = Type).FirstOrDefault
    End Function
    Private Function GetNeuron(Type As NeuronType, Index As Integer) As Neuron
        Return (From n As Neuron In Me.Neurons Where n.Type = Type Select Me.Neurons.ElementAt(Index)).FirstOrDefault
    End Function
End Class
