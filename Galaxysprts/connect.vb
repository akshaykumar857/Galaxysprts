Imports System.Data
Imports System.Data.SqlClient
Module connect
    Public cmd As New SqlCommand
    Public cnn As New SqlConnection
    Public reportstr As String
    Public sel As String
    Public unamee, dat
    Public Sub all_connect()
        cnn.ConnectionString = "Data Source=mgm-server;Initial Catalog=GSW;Integrated Security=true"
        cnn.Open()
        cmd.Connection = cnn
    End Sub
End Module
