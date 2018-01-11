Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Module Extensions
    <System.Runtime.CompilerServices.Extension>
    Public Function Normalize(source As List(Of Double)) As List(Of Double)
        For i As Integer = 0 To source.Count - 1
            source(i) = Math.Round(source(i), 4)
        Next
        Return source
    End Function
    <System.Runtime.CompilerServices.Extension>
    Public Function Shuffle(Of T)(src As List(Of T), randomizer As Random) As List(Of T)
        Dim n As Integer = src.Count
        While n > 1
            n -= 1
            Dim k As Integer = randomizer.Next(n + 1)
            Dim value As T = src(k)
            src(k) = src(n)
            src(n) = value
        End While
        Return src
    End Function
    <System.Runtime.CompilerServices.Extension>
    Public Function Serialize(instance As Network) As Byte()
        If (instance.GetType.IsSerializable) Then
            Using ms As New MemoryStream
                Call New BinaryFormatter().Serialize(ms, instance)
                ms.Position = 0
                Return ms.ToArray
            End Using
        End If
        Throw New Exception("instance cannot be serialized")
    End Function
    <System.Runtime.CompilerServices.Extension>
    Public Function Serialize(instance As Profile) As Byte()
        If (instance.GetType.IsSerializable) Then
            Using ms As New MemoryStream
                Call New BinaryFormatter().Serialize(ms, instance)
                ms.Position = 0
                Return ms.ToArray
            End Using
        End If
        Throw New Exception("instance cannot be serialized")
    End Function
    <System.Runtime.CompilerServices.Extension>
    Public Function Deserialize(Of T)(buffer() As Byte) As T
        If (buffer.Length > 0) Then
            Return CType(New BinaryFormatter().Deserialize(New MemoryStream(buffer)), T)
        End If
        Throw New IOException("no stream")
    End Function
    <System.Runtime.CompilerServices.Extension>
    Public Sub Save(src As Byte(), filename As String, Optional Overwrite As Boolean = False)
        If (src IsNot Nothing) Then
            If (File.Exists(filename) AndAlso Overwrite) Then File.Delete(filename)
            Using bw As New BinaryWriter(File.Open(filename, FileMode.OpenOrCreate))
                bw.Write(src)
            End Using
        End If
    End Sub
End Module
