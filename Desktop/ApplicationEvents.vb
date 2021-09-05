Imports Gecko
Imports System.IO
Imports ExceptionBase
Namespace My

    ' Für MyApplication sind folgende Ereignisse verfügbar:
    ' 
    ' Startup: Wird beim Starten der Anwendung noch vor dem Erstellen des Startformulars ausgelöst.
    ' Shutdown: Wird nach dem Schließen aller Anwendungsformulare ausgelöst. Dieses Ereignis wird nicht ausgelöst, wenn die Anwendung nicht normal beendet wird.
    ' UnhandledException: Wird ausgelöst, wenn in der Anwendung eine unbehandelte Ausnahme auftritt.
    ' StartupNextInstance: Wird beim Starten einer Einzelinstanzanwendung ausgelöst, wenn diese bereits aktiv ist. 
    ' NetworkAvailabilityChanged: Wird beim Herstellen oder Trennen der Netzwerkverbindung ausgelöst.
    Partial Friend Class MyApplication
        Protected Overrides Function OnStartup(ByVal eventArgs As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) As Boolean

            '   set the path to the temp files
            Dim ProfileDirectory As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("defaultProfile")
            If Not Directory.Exists(ProfileDirectory) Then
                Directory.CreateDirectory(ProfileDirectory)
            End If

            'set the temp-directory for the gecko
            Xpcom.ProfileDirectory = ProfileDirectory

            '   set the path of the directory where the xulrunner files are located
            Dim xrPath As String = System.Reflection.Assembly.GetExecutingAssembly.Location
            xrPath = xrPath.Substring(0, xrPath.LastIndexOf("\") + 1) & "\xulrunner"

            '   initialize the path
            Xpcom.Initialize(xrPath)
            Return True
        End Function

        Private Sub MyApplication_UnhandledException(sender As Object, e As ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            ExceptionBase.Track(e.Exception)
        End Sub

        Private Sub MyApplication_Shutdown(sender As Object, e As System.EventArgs) Handles Me.Shutdown
            saveConfigFile()
        End Sub
    End Class

End Namespace

