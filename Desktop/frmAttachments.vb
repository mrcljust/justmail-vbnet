Public Class frmAttachments

    Public openPathAttach As String

    Private Sub frmAttachments_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        frmMain.SetWindowTheme(ListView1.Handle, "explorer", Nothing)
    End Sub

    Public Sub loadFiles()
        ListView1.Items.Clear()
        If openPathAttach.StartsWith("out-/-/-") Then
            Dim opnPA As String = ""
            opnPA = openPathAttach.Replace("out-/-/-", "")
            Dim ANHNG As New List(Of String)
            Dim anhngS As String = cdc(IO.File.ReadAllText(opnPA + "\fls"))
            Dim anhngC As String = anhngS.Substring(0, anhngS.Length - 7)
            ANHNG.AddRange(Split(anhngC, ";;;;;;;"))
            For Each s As String In ANHNG
                Dim sEnd As String = s.Substring(s.Length - 5)
                Dim sEnding As New List(Of String) : sEnding.AddRange(Split(sEnd, "."))
                Dim format As String = sEnding(1)
                Dim filename As String = s.Replace("." + sEnding(1), "")
                With ListView1.Items.Add(filename)
                    .SubItems.Add(format.ToUpper)
                End With
            Next
        Else
            For Each f As String In IO.Directory.GetDirectories(openPathAttach)
                For Each ss As String In IO.Directory.GetFiles(f)
                    Dim s As String = ss.Replace(f + "\", "")
                    Dim sEnd As String = s.Substring(s.Length - 5)
                    Dim sEnding As New List(Of String) : sEnding.AddRange(Split(sEnd, "."))
                    Dim format As String = sEnding(1)
                    Dim filename As String = s.Replace("." + sEnding(1), "")
                    With ListView1.Items.Add(filename)
                        .SubItems.Add(format.ToUpper)
                    End With
                Next
            Next
        End If
        Me.Text = Me.Text.Replace("Anhänge", "Anhänge (" + CStr(ListView1.Items.Count) + ")")
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As System.EventArgs) Handles ListView1.DoubleClick
        If openPathAttach.StartsWith("out-/-/-") Then
            Process.Start(ListView1.SelectedItems(0).Text + "." + ListView1.SelectedItems(0).SubItems(1).Text.ToLower)
        Else
            For Each f As String In IO.Directory.GetDirectories(openPathAttach)
                For Each ss As String In IO.Directory.GetFiles(f)
                    If ss = f + "\" + ListView1.SelectedItems(0).Text + "." + ListView1.SelectedItems(0).SubItems(1).Text.ToLower Then
                        Process.Start(ss)
                        Exit For
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count = 1 Then
            KryptonButton1.Enabled = True
        Else
            KryptonButton1.Enabled = False
        End If
    End Sub

    Private Sub KryptonButton1_Click(sender As System.Object, e As System.EventArgs) Handles KryptonButton1.Click
        If openPathAttach.StartsWith("out-/-/-") Then
            Process.Start(ListView1.SelectedItems(0).Text + "." + ListView1.SelectedItems(0).SubItems(1).Text.ToLower)
            Else
                For Each f As String In IO.Directory.GetDirectories(openPathAttach)
                    For Each ss As String In IO.Directory.GetFiles(f)
                        If ss = f + "\" + ListView1.SelectedItems(0).Text + "." + ListView1.SelectedItems(0).SubItems(1).Text.ToLower Then
                            Process.Start(ss)
                            Exit For
                        End If
                    Next
                Next
            End If
    End Sub
End Class