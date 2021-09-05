Imports System
Imports System.IO
Public Class frmMain

    Dim res As Integer = 0
    Dim isDL As Boolean = False

    WithEvents web As New Net.WebClient

    Private Sub btnNo_Click(sender As System.Object, e As System.EventArgs) Handles btnNo.Click
        If MsgBox("Möchten Sie die Aktualisierung von justMail wirklich abbrechen?" + vbNewLine + "Einige wichtige Funktionen könnten in diesem Update hinzugefügt worden sein!", MsgBoxStyle.YesNo, "Aktualisierung abbrechen? - justMail Updater") = MsgBoxResult.Yes Then
            Process.Start(Application.StartupPath & "\justMail.exe", "sNU")
            End
        End If
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If isDL = True Then
            e.Cancel = True
            MsgBox("Sie können die Aktualisierung nicht abbrechen", MsgBoxStyle.Exclamation, "Fehler - justMail Updater")
        End If
    End Sub

    Private Sub frmUpdater_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If Command() <> "" Then
        Else
            MsgBox("Der Updater kann nicht manuell gestartet werden.", MsgBoxStyle.Critical, "justMail Updater wird beendet")
            End
        End If
        Dim z As New List(Of String)
        Dim cmdline As String = Command()
        z.AddRange(Split(cmdline, ";"))
        lblNewestVersion.Text = z.Item(1)
        lblLocalVersion.Text = z.Item(0)
    End Sub

    Private Sub btnYes_Click(sender As System.Object, e As System.EventArgs) Handles btnYes.Click
        bgw1.RunWorkerAsync()
        btnYes.Enabled = False
        btnNo.Enabled = False
        tmrCheckBusy.Enabled = True
    End Sub

    Private Sub bgw1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw1.DoWork
        Try
            My.Computer.Network.Ping("www.google.de")
            res = 1
            bgw1.Dispose()
        Catch
            res = 0
            MsgBox("Sie sind nicht mit dem Internet verbunden." + vbCrLf + "Die Aktualisierung kann nicht fortgesetzt werden", MsgBoxStyle.Exclamation, "Nicht verbunden - justMail Updater")
            btnYes.Enabled = True
            btnNo.Enabled = True
            bgw1.Dispose()
        End Try
    End Sub

    Private Sub tmrCheckBusy_Tick(sender As System.Object, e As System.EventArgs) Handles tmrCheckBusy.Tick
        If bgw1.IsBusy = False Then
            tmrCheckBusy.Enabled = False
            If res = 1 Then
                Me.ControlBox = False
                updateN()
            End If
        End If
    End Sub

    Private Sub updateN()
        btnYes.Visible = False
        btnNo.Visible = False
        bgw2.RunWorkerAsync()
    End Sub

    Private Sub bgw2_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw2.DoWork
        isDL = True
        Dim folderpth As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\update"
        IO.Directory.CreateDirectory(folderpth)
        Dim dlpath As New Uri("http://www.it-just.net/justMail/versions/" + lblNewestVersion.Text + "/" + lblNewestVersion.Text + ".zip")
        lblStatus.Text = "Status: Lade Aktualisierung herunter..."

        ProgressBar1.Visible = True
        web.DownloadFileAsync(dlpath, folderpth + "\" + lblNewestVersion.Text + ".zip")
        
    End Sub

    Public Sub dlpgc(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs)

    End Sub

    Public Sub Unziped()
        Dim folderpth As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\update"
        bgw2.Dispose()
        lblStatus.Text = "Status: Fertig"
        IO.File.Delete(folderpth + "\" + lblNewestVersion.Text + ".zip")
        IO.Directory.Delete(folderpth)
        MsgBox("justMail wurde erfolgreich aktualisiert.", MsgBoxStyle.Information, "justMail wurde aktualisiert - justMail Updater")
        Process.Start(Application.StartupPath & "\justMail.exe", "updtD")
        End
    End Sub

    Private Sub tmrDot_Tick(sender As System.Object, e As System.EventArgs)
        If lblStatus.Text = "Status: Lade Aktualisierung herunter" Then
            lblStatus.Text = "Status: Lade Aktualisierung herunter."
        ElseIf lblStatus.Text = "Status: Lade Aktualisierung herunter." Then
            lblStatus.Text = "Status: Lade Aktualisierung herunter.."
        ElseIf lblStatus.Text = "Status: Lade Aktualisierung herunter.." Then
            lblStatus.Text = "Status: Lade Aktualisierung herunter..."
        Else
            lblStatus.Text = "Status: Lade Aktualisierung herunter"
        End If
    End Sub

    Private Sub web_DownloadFileCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles web.DownloadFileCompleted
        ProgressBar1.Visible = False
        Dim folderpth As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\update"
        lblStatus.Text = "Status: Ersetze alte Version mit neuer..."
        For Each s As String In IO.Directory.GetFiles(Application.StartupPath)
            If Not s = Application.StartupPath + "\justMail Updater.exe" Then
                If Not s = Application.StartupPath + "\AeroControls.dll" Then
                    IO.File.Delete(s)
                End If
            End If
        Next
        For Each d As String In IO.Directory.GetDirectories(Application.StartupPath)
            IO.Directory.Delete(d)
        Next

        Dim file As String = folderpth + "\" + lblNewestVersion.Text + ".zip"
        Dim cu As New ClassUnzip(file, Application.StartupPath)
        AddHandler cu.UnzipFinishd, AddressOf Unziped
        cu.UnzipNow()
    End Sub

    Private Sub web_DownloadProgressChanged(sender As Object, e As System.Net.DownloadProgressChangedEventArgs) Handles web.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub
End Class
