Public Class ticketmanage
    Public mExhtype() As exhtype
    Public mTicktype() As ticktype
    Public mTicket() As ticket
    Public filehelper1 As FileHelper(Of exhtype) = FileHelper(Of exhtype).Instance
    Public filehelper2 As FileHelper(Of ticktype) = FileHelper(Of ticktype).Instance
    Public filehelper3 As FileHelper(Of ticket) = FileHelper(Of ticket).Instance

    Function Allexhname() As String()
        Dim n(mExhtype.Length - 1) As String
        Dim i As Integer = 0
        For Each Commodity In mExhtype
            n(i) = Commodity.name
            i += 1
        Next
        Return n
    End Function
    Function Allticname() As String()
        Dim n(mTicktype.Length - 1) As String
        Dim i As Integer = 0
        For Each Commodity In mTicktype
            n(i) = Commodity.name
            i += 1
        Next
        Return n
    End Function
    Function Exhgetbyname(name As String) As exhtype
        For Each ttt In mExhtype
            If ttt.name.Equals(name) Then
                Return ttt
            End If
        Next
        Return Nothing
    End Function
    Function Ticgetbyname(name As String) As ticktype
        For Each ttt In mTicktype
            If ttt.name.Equals(name) Then
                Return ttt
            End If
        Next
        Return Nothing
    End Function
    Sub New() '这里写从文件的读写
        Dim fi As New System.IO.FileInfo("D:\c语言编译器\实验2\ticket.txt")
        If (fi.Length = 0) Then
            Dim a1 = New exhtype("鬼斧神工", 100)
            Dim a2 = New exhtype("市井风情", 120)
            Dim a3 = New exhtype("国之重器", 150)
            Dim b1 = New ticktype("成人票"， 0, 10)
            Dim b2 = New ticktype("学生票"， 0.2, 10)
            Dim b3 = New ticktype("团体票"， 0.3, 10)
            mExhtype = {a1, a2, a3}
            mTicktype = {b1， b2， b3}
            filehelper1.FileCreat(mExhtype, "D:\c语言编译器\实验2\exhibition.txt")
            filehelper2.FileCreat(mTicktype, "D:\c语言编译器\实验2\tickettype.txt")
        Else
            mExhtype = filehelper1.FileRead("D:\c语言编译器\实验2\exhibition.txt")
            mTicktype = filehelper2.FileRead("D:\c语言编译器\实验2\tickettype.txt")
            mTicket = filehelper3.FileRead("D:\c语言编译器\实验2\ticket.txt")
        End If
    End Sub
    Sub Sale(exhtype As String, tictype As String, number As Integer, time As DateTime)
        If mTicket Is Nothing Then
            ReDim mTicket(0)
        Else
            ReDim Preserve mTicket(mTicket.Length)
        End If
        Dim newticket As ticket = New ticket(Ticgetbyname(tictype), Exhgetbyname(exhtype))
        newticket.Addnumber(number)
        newticket.mDatetime = time
        mTicket(mTicket.Length - 1) = newticket
        filehelper3.FileCreat(mTicket, "D: \c语言编译器\实验2\ticket.txt")
    End Sub
    Function Getbyday(day As Integer) As Integer(,)
        Dim alltickets As Integer(,) = {{0, 0, 0}, {0, 0, 0}, {0, 0, 0}}
        For Each ticket In mTicket
            If ticket.mDatetime.Day = day Then
                For i = 0 To 2
                    For j = 0 To 2
                        If ticket.mExhtype.name.Equals((mExhtype(i).name)) And ticket.mTicktype.name.Equals((mTicktype(j).name)) Then
                            alltickets(j, i) += ticket.mNumber
                        End If
                    Next
                Next
            End If
        Next
        Return alltickets
    End Function
    Function Getbymonth(month As Integer) As Integer(,)
        Dim alltickets As Integer(,) = {{0, 0, 0}, {0, 0, 0}, {0, 0, 0}}
        For Each ticket In mTicket
            If ticket.mDatetime.Month = month Then
                For i = 0 To 2
                    For j = 0 To 2
                        If ticket.mExhtype.Equals(mExhtype(i)) And ticket.mTicktype.Equals(mTicktype(j)) Then
                            alltickets(j, i) += ticket.mNumber
                        End If
                    Next
                Next
            End If
        Next
        Return alltickets
    End Function
    Function Getbyyear(year As Integer) As Integer(,)
        Dim alltickets As Integer(,) = {{0, 0, 0}, {0, 0, 0}, {0, 0, 0}}
        For Each ticket In mTicket
            If ticket.mDatetime.Year = year Then
                For i = 0 To 2
                    For j = 0 To 2
                        If ticket.mExhtype.Equals(mExhtype(i)) And ticket.mTicktype.Equals(mTicktype(j)) Then
                            alltickets(j, i) += ticket.mNumber
                        End If
                    Next
                Next
            End If
        Next
        Return alltickets
    End Function
End Class
