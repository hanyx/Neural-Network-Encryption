Imports NFunc.Functions

<Serializable>
Public NotInheritable Class Neuron
    Public Property Name As String
    Public Property Bias As Double
    Public Property Input As Double()
    Public Property Weight As Double()
    Public Property Correction As Double
    Public Property Type As NeuronType
    Public Property Parent As Network
    Sub New()
    End Sub
    Sub New(Parent As Network, Type As NeuronType, Name As String)
        Me.Parent = Parent
        Me.Name = Name
        Me.Type = Type
        Me.Input = New Double(1) {}
        Me.Weight = New Double(1) {}
    End Sub
    Public Sub Randomize()
        Me.Weight(0) = Me.Parent.Random.NextDouble
        Me.Weight(1) = Me.Parent.Random.NextDouble
        Me.Bias = Me.Parent.Random.NextDouble
    End Sub
    Public Sub Update()
        Me.Weight(0) += Me.Correction * Me.Input(0)
        Me.Weight(1) += Me.Correction * Me.Input(1)
        Me.Bias += Me.Correction
    End Sub
    Public ReadOnly Property Output() As Double
        Get
            Return Me.Parent.Sigmoid.Output(Me.Weight(0) * Me.Input(0) + Me.Weight(1) * Me.Input(1) + Me.Bias)
        End Get
    End Property
    Public Overrides Function ToString() As String
        Return String.Format("[{0}] {1} Output: {2} Bias: {3} Correction: {4}", Me.Name, Me.Type, Me.Output, Me.Bias, Me.Correction)
    End Function
End Class
