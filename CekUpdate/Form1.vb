Imports System.Net
Imports System.IO
Imports System.Linq
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq


Public Class Form1
    Dim server_update As String = "http://localhost/website/cekUpdate/" '// GANTI SESUAI URL KALIAN
    Dim appVer = Application.ProductVersion


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim resJSON As String = New System.Net.WebClient().DownloadString(server_update) '// Download String JSON dari Website
            Dim jsonParse = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(resJSON) '// Parse JSON to Array

            Dim i_link = jsonParse.Item("update_link"),
                i_versi = jsonParse.Item("update_version"),
                i_deskripsi = jsonParse.Item("deskripsi")

            If (i_versi > appVer) Then
                MsgBox("Versi baru tersedia... Silahkan di Download segera!", vbInformation, "Update")
                lblVersion.Text = i_versi
                lblLink.Text = i_link

                TextBox1.Text = i_deskripsi
            Else
                MsgBox("Tidak ada update tersedia", vbInformation, "Update")
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan server...", vbCritical, "Update")
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Appilikasi ini Versi " + Application.ProductVersion
    End Sub
End Class
