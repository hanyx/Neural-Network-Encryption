Public Class EventArgs
    Public Property Message As String
    Sub New()
        Me.Message = String.Empty
    End Sub
    Sub New(Message As String)
        Me.Message = Message
    End Sub
End Class
