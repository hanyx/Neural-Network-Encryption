Namespace Functions
    <Serializable>
    Public Class Sigmoid
        Implements IFunction
        Public Function Output(value As Double) As Double Implements IFunction.Output
            Return 1 / (1 + Math.Exp(-value))
        End Function
        Public Function F(value As Double) As Double Implements IFunction.F
            Return value * (1 - value)
        End Function
    End Class
End Namespace