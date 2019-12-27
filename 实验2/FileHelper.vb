Imports System.IO

Public Class FileHelper(Of t)
    Shared m_instance As FileHelper(Of t) = Nothing
    Private Sub New()
    End Sub
    Public Shared ReadOnly Property Instance() As FileHelper(Of t)
        Get
            If m_instance Is Nothing Then
                m_instance = New FileHelper(Of t)()
            End If
            Return m_instance
        End Get
    End Property
    Sub FileCreat(ByVal Tlist As t(), ByVal filename As String)
        Dim sfFormatter As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim fStream As New FileStream(filename, FileMode.Create)
        sfFormatter.Serialize(fStream, Tlist)
        fStream.Close()
    End Sub
    Function FileRead(ByVal filename As String) As t()
        Dim fStream As New FileStream(filename, FileMode.Open)
        Dim sfFormatter As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Return sfFormatter.Deserialize(fStream)
        fStream.Close()
    End Function
End Class
