<Serializable()> Public Class ticktype
    Public name As String
    Public discount As Double
    Public maxnumber As Integer
    Sub New(name As String, discount As Double, maxnumber As Integer)
        Me.name = name
        Me.discount = discount
        Me.maxnumber = maxnumber
    End Sub
End Class
