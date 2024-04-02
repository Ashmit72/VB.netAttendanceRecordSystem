Imports System.Data.SqlClient

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim query As String = "SELECT * FROM newtab"
            Using con As SqlConnection = New SqlConnection("Data Source=DESKTOP-VPETHI2\SQLEXPRESS;Initial Catalog=studentdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True")
                con.Open()
                Using cnn As SqlCommand = New SqlCommand(query, con)
                    cnn.CommandType = CommandType.Text
                    Using da As New SqlDataAdapter(cnn)
                        Dim table As New DataTable()
                        da.Fill(table)
                        DataGridView1.DataSource = table
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim StudentId As Integer = Convert.ToInt32(TextBox1.Text)
            Dim StudentName As String = TextBox2.Text
            Dim RollNo As String = TextBox3.Text
            Dim Status As String = TextBox4.Text

            Dim Query As String = "INSERT INTO newtab VALUES (@StudentId, @StudentName, @RollNo, @Status)"

            Using con As SqlConnection = New SqlConnection("Data Source=DESKTOP-VPETHI2\SQLEXPRESS;Initial Catalog=studentdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True")
                con.Open()
                Using cnn As SqlCommand = New SqlCommand(Query, con)
                    cnn.Parameters.AddWithValue("@StudentId", StudentId)
                    cnn.Parameters.AddWithValue("@StudentName", StudentName)
                    cnn.Parameters.AddWithValue("@RollNo", RollNo)
                    cnn.Parameters.AddWithValue("@Status", Status)

                    cnn.ExecuteNonQuery()
                    MessageBox.Show("Record Saved Successfully!")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error inserting record: " & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim query As String = "SELECT * FROM newtab"
            Using con As SqlConnection = New SqlConnection("Data Source=DESKTOP-VPETHI2\SQLEXPRESS;Initial Catalog=studentdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True")
                con.Open()
                Using cnn As SqlCommand = New SqlCommand(query, con)
                    cnn.CommandType = CommandType.Text
                    Using da As New SqlDataAdapter(cnn)
                        Dim table As New DataTable()
                        da.Fill(table)
                        DataGridView1.DataSource = table
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error refreshing data: " & ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim StudentId As Integer = Convert.ToInt32(TextBox1.Text)
            Dim StudentName As String = TextBox2.Text
            Dim RollNo As String = TextBox3.Text
            Dim Status As String = TextBox4.Text

            Dim Query As String = "UPDATE newtab SET studentname = @StudentName, rollno = @RollNo, status = @Status WHERE studentid = @StudentId"

            Using con As SqlConnection = New SqlConnection("Data Source=DESKTOP-VPETHI2\SQLEXPRESS;Initial Catalog=studentdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True")
                con.Open()
                Using cnn As SqlCommand = New SqlCommand(Query, con)
                    cnn.Parameters.AddWithValue("@StudentId", StudentId)
                    cnn.Parameters.AddWithValue("@StudentName", StudentName)
                    cnn.Parameters.AddWithValue("@RollNo", RollNo)
                    cnn.Parameters.AddWithValue("@Status", Status)

                    cnn.ExecuteNonQuery()
                    MessageBox.Show("Record Updated Successfully!")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating record: " & ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim StudentId As Integer = Convert.ToInt32(TextBox1.Text)
            Dim Query As String = "DELETE FROM newtab WHERE studentid = @StudentId"

            Using con As SqlConnection = New SqlConnection("Data Source=DESKTOP-VPETHI2\SQLEXPRESS;Initial Catalog=studentdb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True")
                con.Open()
                Using cnn As SqlCommand = New SqlCommand(Query, con)
                    cnn.Parameters.AddWithValue("@StudentId", StudentId)

                    cnn.ExecuteNonQuery()
                    If Not cnn.ExecuteNonQuery() Then
                        MessageBox.Show("Error Deleting Record!")
                        Return
                    End If
                    MessageBox.Show("Record Deleted Successfully!")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error deleting record: " & ex.Message)
        End Try
    End Sub
End Class
