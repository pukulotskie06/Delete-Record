Public Class Delete
    ''Author pukulot github id = pukulotskie06
    Public db As New DatabaseClass
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MessageBox.Show("Are you sure You want to delete ID No " & dGrid.CurrentRow.Cells("ID").Value.ToString() & "?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = 6 Then
            db.DeleteQuery(Val(txtID.Text))
            Button2.PerformClick()
        End If
    End Sub

    Public FieldNames() As String = {"ID", "Product_Name", "Description", _
                                     "Brand", "Type", "Qty", "Size", _
                                    "Unit", "Price", "Total"}
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        For x = 0 To FieldNames.Length - 1
            If x <> 5 And x <> 9 Then
                dGrid.Columns.Add(FieldNames(x), FieldNames(x))
                comboFilter.Items.Add(FieldNames(x))
            End If
        Next
        'DataGridView1.Columns("Product_Name").Width = 200
        ''DataGridView1.Columns("Description").Width = 200
        '' DataGridView1.Columns("Price").Width = 160
        ''DataGridView1.Columns("Total").Width = 170
        Button2.PerformClick()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim con As New DatabaseClass

        con.DatabaseClass()


        dGrid.Rows.Clear()
        For x As Integer = 0 To con.dataSet.Tables("Inventory").Rows.Count - 1
            dGrid.Rows.Add()
            For y As Integer = 0 To con.dataSet.Tables("Inventory").Columns.Count - 1
                dGrid.Rows(x).Cells(y).Value = con.dataSet.Tables("Inventory").Rows(x).Item(y)
            Next
        Next

        If chkBoxfilter.Checked = True Then
            comboFilterNames.Text = Nothing
            comboFilter.Text = Nothing
        End If

    End Sub

    Private Sub chkBoxfilter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxfilter.CheckedChanged
        If chkBoxfilter.Checked = True Then
            comboFilterNames.Enabled = True
            comboFilter.Enabled = True
        Else
            comboFilterNames.Enabled = False
            comboFilter.Enabled = False
            comboFilter.Text = ""
            comboFilterNames.Text = ""
            Button2.PerformClick()

        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub comboFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboFilter.SelectedIndexChanged

        If comboFilter.Text <> Nothing Then
            comboFilterNames.Text = ""
            comboFilterNames.Items.Clear()

            Dim s() As String = db.Fill(comboFilter.Text).Split(";")


            For x As Integer = 0 To s.Length - 2
                comboFilterNames.Items.Add(s(x))
            Next
        End If
    End Sub

    Private Sub comboFilterNames_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboFilterNames.SelectedIndexChanged

        If comboFilter.Text = Nothing Or comboFilterNames.Text = Nothing Then

        Else

            db.FillDataWithType(comboFilter.Text, comboFilterNames.Text)

            dGrid.Rows.Clear()

            For x As Integer = 0 To db.dataSet.Tables("Inventory").Rows.Count - 1
                dGrid.Rows.Add()
                For y As Integer = 0 To db.dataSet.Tables("Inventory").Columns.Count - 1
                    dGrid.Rows(x).Cells(y).Value = db.dataSet.Tables("Inventory").Rows(x).Item(y)
                Next
            Next


        End If

    End Sub

    Private Sub diableButtons(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles comboFilterNames.KeyPress, comboFilter.KeyPress
        e.Handled = True
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellClick
        txtID.Text = dGrid.CurrentRow.Cells("ID").Value.ToString()
    End Sub



    Private Sub txtID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtID.KeyPress

    End Sub


    Private Sub txtID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtID.TextChanged

    End Sub


    Dim rowCtr As Integer
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

        If Asc(e.KeyChar) = 13 And TextBox1.Text <> Nothing And row.Count > 0 Then

            If rowCtr <= ctr Then
                dGrid.ClearSelection()
                dGrid.Rows(Val(row(rowCtr))).Selected = True
                dGrid.CurrentCell = dGrid.SelectedCells(0)
                rowCtr += 1
                If rowCtr = ctr Then
                    rowCtr = 0
                End If
            End If

        End If

    End Sub


    Dim ctr As Integer
    Dim row As New Collections.ArrayList
    Private Sub TextBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp

        If e.KeyCode <> 13 Then
            row.Clear()
            Dim temp As Integer = -1
            ctr = 0
            For x = 0 To dGrid.Rows.Count - 1
                For y = 0 To dGrid.Rows(x).Cells.Count - 1
                    If dGrid.Rows(x).Cells(y).Value.ToString.ToLower.Contains(TextBox1.Text.ToString.ToLower) Then
                        If temp <> x Then
                            ctr += 1
                            temp = x
                            row.Add(x)
                        End If
                    End If
                Next

            Next


            If TextBox1.Text <> Nothing Then
                lblDisplay.Text = ctr & " results found!"
            Else
                lblDisplay.Text = Nothing
            End If
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ''Main.Show()
        Me.Close()
    End Sub

End Class
