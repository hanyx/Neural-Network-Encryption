Imports System.IO

<Serializable>
Public Class Profile
    Const Offset As Integer = 20
    Public Property Chars As List(Of Char)
    Public Property Key As List(Of Double)
    Public Property Offsets As List(Of Double)
    Public Property Multiplier As Integer = 100
    Public Property Characters As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ !?,.1234567890"
    Public Sub Randomize(Network As Network)
        Me.Key = New List(Of Double)
        Me.Offsets = New List(Of Double)
        Me.Chars = New List(Of Char)
        For i As Integer = 0 To Me.Characters.Length - 1
            Dim index As Integer = 0
            Me.Chars.Add(Me.Characters(i))
            Do
                index = Network.Random.Next(Profile.Offset, Me.Characters.Length + Profile.Offset + 1)
            Loop While Me.Offsets.Contains(index / Me.Multiplier)
            Me.Offsets.Add(index / Multiplier)
            Do
                index = Network.Random.Next(Profile.Offset, Me.Characters.Length + Profile.Offset + 1)
            Loop While Me.Key.Contains(index / Multiplier)
            Me.Key.Add(index / Multiplier)
        Next
    End Sub
    Public Function Encrypt(Message As String) As String
        Dim output As New List(Of Integer)
        For Each ch As Char In Message.ToUpper.ToCharArray
            Dim index As Integer = Me.Chars.IndexOf(ch)
            If (index <> -1) Then
                output.AddRange({CInt(Me.Offsets(index) * Me.Multiplier), CInt(Me.Key(index) * Me.Multiplier)})
            End If
        Next
        Return String.Concat(output)
    End Function
    Public Function Decrypt(Network As Network, Sequence As String) As String
        If (Sequence.Length Mod 2 = 0) Then
            Dim decrypted As New List(Of Char)
            For i As Integer = 0 To Sequence.Length - 1 Step 4
                Dim input As Double = Double.Parse(String.Concat(Sequence(i), Sequence(i + 1))) / Me.Multiplier
                Dim key As Double = Double.Parse(String.Concat(Sequence(i + 2), Sequence(i + 3))) / Me.Multiplier
                Dim output As Double = Network.Solve({input}, {key}).First
                Dim index As Integer = Me.Offsets.IndexOf(Math.Round(output, 2))
                If (index <> -1) Then
                    decrypted.Add(Me.Chars(index))
                End If
            Next
            Return String.Concat(decrypted)
        End If
        Return String.Empty
    End Function
    Public Sub Save(filename As String)
        Me.Serialize().Save(Path.GetFullPath(filename))
    End Sub
End Class
