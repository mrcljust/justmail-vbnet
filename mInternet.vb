Module mInternet
    Public newestV As String
    Dim newVf As String
    Friend WithEvents web As New Net.WebClient
    Public Function checkIfConnectedWithInternet() As Boolean
        Try
            My.Computer.Network.Ping("www.google.de")
            Return True
        Catch
            'Konnte keinen Ping senden, Google ist fast immer online = Firewall/Internet.
            Return False
        End Try
    End Function

    Public Function checkIfConnectedWithInternetM(ByVal currentOperation As String) As Boolean
        Try
            My.Computer.Network.Ping("www.google.de")
            Return True
        Catch
            'Konnte keinen Ping senden, Google ist fast immer online = Firewall/Internet.
            MsgBox("Sie sind nicht mit dem Internet verbunden. " + currentOperation + " konnte nicht abgeschlossen werden.", MsgBoxStyle.Exclamation, "Nicht verbunden - justMail")
            Return False
        End Try
    End Function

    Public Function isUpdateAvailable() As Boolean
        Dim localV As String = (My.Application.Info.Version.ToString)

        If checkIfConnectedWithInternet() = True Then
            newestV = web.DownloadString(New Uri("http://www.it-just.net/justMail/newestV"))
            newVf = newestV.Replace(".", "")
        Else
            showNotify(ToolTipIcon.Error, "Konnte nicht auf Aktualisierungen prüfen", "Da Sie nicht mit dem Internet verbunden sind, konnte justMail nicht prüfen, ob Aktualisierungen verfügbar sind.", 7000)
            Return Nothing
        End If
        If CInt(localV) < CInt(newVf) Then
            'update available
            showNotify(ToolTipIcon.Warning, "Aktualisierung verfügbar", "Eine Aktualisierung für justMail ist verfügbar." + vbNewLine + "Lokale Version: " + localV + vbNewLine + "Neuste Version: " + newestV, 7000)
            Return True


        Else
            showNotify(ToolTipIcon.Info, "Keine Aktualisierung verfügbar", "justMail läuft derzeitig auf der aktuellsten Version (" + localV + ").", 7000)
            Return False
            'no update
        End If
    End Function

    Private Sub web_DownloadStringCompleted(ByVal sender As Object, ByVal e As System.Net.DownloadStringCompletedEventArgs) Handles Web.DownloadStringCompleted
        newestV = e.Result
    End Sub


End Module
