Public Class Form1
    Dim nowticket As ticket
    Dim mticketmanage As ticketmanage = New ticketmanage()
    Dim nowtickets(,) As Integer
    Dim nowexh As exhtype
    Dim nowtic As ticktype
    Dim nowexh2 As exhtype
    Dim nowtic2 As ticktype
    Public filehelper1 As FileHelper(Of exhtype) = FileHelper(Of exhtype).Instance
    Public filehelper2 As FileHelper(Of ticktype) = FileHelper(Of ticktype).Instance
    Public filehelper3 As FileHelper(Of ticket) = FileHelper(Of ticket).Instance
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadsomething("无")
    End Sub
    Sub loadsomething(time As String)
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        ComboBox3.Items.Clear()
        ComboBox4.Items.Clear()
        ComboBox1.Items.AddRange(mticketmanage.Allexhname)
        ComboBox2.Items.AddRange(mticketmanage.Allticname)
        ComboBox3.Items.AddRange(mticketmanage.Allexhname)
        ComboBox4.Items.AddRange(mticketmanage.Allticname)
        DataGridView1.RowTemplate.Height = 30
        DataGridView1.Columns(0).HeaderText = ""
        DataGridView1.Columns(1).HeaderText = mticketmanage.Allexhname(0)
        DataGridView1.Columns(2).HeaderText = mticketmanage.Allexhname(1)
        DataGridView1.Columns(3).HeaderText = mticketmanage.Allexhname(2)
        DataGridView1.Rows.Clear()
        If time.Equals("无") Then
            DataGridView1.Rows.Add(mticketmanage.Allticname(0), "无", "无", "无")
            DataGridView1.Rows.Add(mticketmanage.Allticname(1), "无", "无", "无")
            DataGridView1.Rows.Add(mticketmanage.Allticname(2), "无", "无", "无")
        Else
            If time.Equals("day") Then
                nowtickets = mticketmanage.Getbyday(Convert.ToInt32(TextBox5.Text))
            ElseIf time.Equals("month") Then
                nowtickets = mticketmanage.Getbymonth(Convert.ToInt32(TextBox6.Text))
            ElseIf time.Equals("year") Then
                nowtickets = mticketmanage.Getbyyear(Convert.ToInt32(TextBox7.Text))
            End If
            DataGridView1.Rows.Add(mticketmanage.Allticname(0), nowtickets(0, 0), nowtickets(0, 1), nowtickets(0, 2))
            DataGridView1.Rows.Add(mticketmanage.Allticname(1), nowtickets(1, 0), nowtickets(1, 1), nowtickets(1, 2))
            DataGridView1.Rows.Add(mticketmanage.Allticname(2), nowtickets(2, 0), nowtickets(2, 1), nowtickets(2, 2))
        End If
        TextBox12.ReadOnly = True
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '’ nowexh = mticketmanage.Exhgetbyname(ComboBox1.Text)
        '’nowtic = mticketmanage.Ticgetbyname(ComboBox2.Text)
        If TextBox1.Text = "" Then
            MsgBox("请输入票的数量！")
        Else
            If Convert.ToInt32(TextBox1.Text) < mticketmanage.mTicktype(2).maxnumber And ComboBox2.Text = mticketmanage.Allticname(2) Then
                MsgBox("人数不足，无法购买团体票！请选择其他票种。")
            ElseIf TextBox1.Text.Equals("") Then
                MsgBox("请输入正确的票数！")
            Else
                TextBox2.Text = Convert.ToString(nowexh.price * (1 - nowtic.discount) * Convert.ToInt32(TextBox1.Text))
                MsgBox("计算成功！")
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox4.Text.Equals("") Or TextBox4.Text.Equals("当前付款不足") Then
            MsgBox("收款不足，无法售票！")
        Else
            mticketmanage.Sale(ComboBox1.Text, ComboBox2.Text, Convert.ToInt32(TextBox1.Text), DateTime.Now)
            MsgBox("售票成功！")
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox2.Text = "" Or TextBox3.Text = "" Then
            TextBox4.Text = ""
        ElseIf Convert.ToDouble(TextBox3.Text) - Convert.ToDouble(TextBox2.Text) >= 0 Then
            TextBox4.Text = Convert.ToString(Convert.ToDouble(TextBox3.Text) - Convert.ToDouble(TextBox2.Text))
        Else
            TextBox4.Text = "当前付款不足"
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        loadsomething("day")
        MsgBox("查找成功！")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        loadsomething("month")
        MsgBox("查找成功！")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        loadsomething("year")
        MsgBox("查找成功！")
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        nowexh2 = mticketmanage.Exhgetbyname(ComboBox3.Text)
        TextBox8.Text = nowexh2.name
        TextBox9.Text = Convert.ToString(nowexh2.price)

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        nowtic2 = mticketmanage.Ticgetbyname(ComboBox4.Text)
        If nowtic2.Equals(mticketmanage.mTicktype(2)) Then
            TextBox12.ReadOnly = False
            TextBox12.Text = Convert.ToString(nowtic2.maxnumber)
        End If
        TextBox10.Text = nowtic2.name
        TextBox11.Text = Convert.ToString(nowtic2.discount)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        nowexh2.name = TextBox8.Text
        nowexh2.price = Convert.ToDouble(TextBox9.Text)
        filehelper1.FileCreat(mticketmanage.mExhtype, "D:\c语言编译器\实验2\exhibition.txt")
        filehelper3.FileCreat(mticketmanage.mTicket, "D:\c语言编译器\实验2\ticket.txt")
        MsgBox("修改成功！")
        loadsomething("无")
        TextBox8.Text = ""
        TextBox9.Text = ""
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        nowtic2.name = TextBox10.Text
        nowtic2.discount = Convert.ToDouble(TextBox11.Text)
        nowtic2.maxnumber = Convert.ToInt32(TextBox12.Text)
        filehelper2.FileCreat(mticketmanage.mTicktype, "D:\c语言编译器\实验2\tickettype.txt")
        filehelper3.FileCreat(mticketmanage.mTicket, "D:\c语言编译器\实验2\ticket.txt")
        MsgBox("修改成功！")
        loadsomething("无")
        TextBox10.Text = ""
        TextBox11.Text = ""

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        nowexh = mticketmanage.Exhgetbyname(ComboBox1.Text)
        TextBox13.Text = Convert.ToString(nowexh.price)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        nowtic = mticketmanage.Ticgetbyname(ComboBox2.Text)
        TextBox14.Text = Convert.ToString(nowtic.discount)
    End Sub
End Class
