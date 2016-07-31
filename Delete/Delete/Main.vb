Public Class Main

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim con As New DatabaseClass
        con.DatabaseClass()
        DataGridView1.Rows.Clear()
        For x As Integer = 0 To con.dataSet.Tables("Inventory").Rows.Count - 1
            DataGridView1.Rows.Add()
            For y As Integer = 0 To con.dataSet.Tables("Inventory").Columns.Count - 1
                DataGridView1.Rows(x).Cells(y).Value = con.dataSet.Tables("Inventory").Rows(x).Item(y)
            Next
        Next

    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DataGridView1.Columns.Add("ID", "ID")
        DataGridView1.Columns.Add("Product_Name", "Product_Name")
        DataGridView1.Columns.Add("Description", "Description")
        DataGridView1.Columns.Add("Brand", "Brand")
        DataGridView1.Columns.Add("Type", "Type")
        DataGridView1.Columns.Add("Qty", "Qty")
        DataGridView1.Columns.Add("Size", "Size")
        DataGridView1.Columns.Add("Unit", "Unit")
        DataGridView1.Columns.Add("Price", "Price")
        DataGridView1.Columns.Add("Total", "Total")

        'DataGridView1.Columns("Product_Name").Width = 200
        DataGridView1.Columns("Description").Width = 200
        '' DataGridView1.Columns("Price").Width = 160
        ''DataGridView1.Columns("Total").Width = 170
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If (Asc(e.KeyChar) = 13) Then

            For x As Integer = 0 To DataGridView1.Rows.Count - 1
                For y As Integer = 0 To DataGridView1.Columns.Count - 1

                    If (DataGridView1.Rows(x).Cells(y).Value.ToString.ToLower.Contains(LCase(TextBox1.Text.ToString))) Then
                        DataGridView1.ClearSelection()
                        DataGridView1.Rows(x).Cells(y).Selected = True
                        DataGridView1.CurrentCell = DataGridView1.SelectedCells(0)

                    End If


                Next
            Next

            ''MsgBox(DataGridView1.CurrentCell.Value.ToString)
            ''TextBox1.Clear()
        End If
    End Sub

   

  
   
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Panel6_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel6.Paint

    End Sub
End Class
