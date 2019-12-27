<Serializable()> Public Class ticket
    Public mTicktype As ticktype
    Public mExhtype As exhtype
    Public mNumber As Integer = 0
    Public mDatetime As DateTime
    Public Sub New(ByVal ticktype As ticktype, ByVal exhtype As exhtype)
        Me.mTicktype = ticktype
        Me.mExhtype = exhtype
    End Sub
    Sub Addnumber(number As Integer)
        Me.mNumber += number
    End Sub
End Class
