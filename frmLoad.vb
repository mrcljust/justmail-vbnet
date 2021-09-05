Imports System.IO
Public Class frmLoad

    Private Sub frmLoad_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Registerfile(".jml", "justMail Datei", Application.StartupPath & "\justMail.exe", Application.StartupPath & "\justMail.ico")
        If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length > 1 Then
            MsgBox("justMail läuft bereits." + vbCrLf + "Beenden Sie justMail über den Taskmanager, falls Sie denken, dass dies ein Fehler ist.", MsgBoxStyle.Exclamation, "justMail läuft bereits - justMail")
            End
        End If
        If configSetup() = True Then
            If mySfirststart = True Then
                frmFirst.Show()
                frmFirst.Focus()
                Me.Close()
            Else
                frmMain.Show()
                frmMain.Focus()
                Me.Close()
            End If
        End If
    End Sub
End Class