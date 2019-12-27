<Serializable()> Public Class exhtype
    Public name As String
    Public price As Integer
    Sub New(name As String, price As Integer)
        Me.name = name
        Me.price = price
    End Sub
End Class
