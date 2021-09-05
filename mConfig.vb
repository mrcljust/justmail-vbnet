Module Mconfig

    Public myConfig As New cIni
    Public mySfirststart As Boolean = True
    Public myScc As Integer = 0
    Public mySlastLoc As String
    Public mySlastSize As String
    Public mySwindowMode As String
    Public ExceptionBase As New ExceptionBase.ExceptionBase("http://www.it-just.net/ExceptionBase/api/addException.php", 1, My.Application.Info.Version.ToString, My.Resources.icon)
    Public Function configSetup() As Boolean
        createDirectorys()
        If IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("config") + "\" + cc("config") + ".ini") Then
            readConfigFile()
            Return True
        Else
            createConfigFile()
            readConfigFile()
            Return True
        End If
    End Function

    Public Sub createDirectorys()
        IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\")
        IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("config") + "\")
        IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\")
        IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("contacts") + "\")
    End Sub

    Public Sub createConfigFile()
        myConfig.WriteValue(cc("justMail config"), "69181920192011820", "True")
        myConfig.WriteValue(cc("justMail config"), "315211420", "321")
        myConfig.WriteValue(cc("justMail config"), "121192012153", "10000;10000")
        myConfig.WriteValue(cc("justMail config"), "1211920199265", "1024;600")
        myConfig.WriteValue(cc("justMail config"), "2391441523131545", "Normal")
        myConfig.Save(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("config") + "\" + cc("config") + ".ini")
        Registerfile(".jml", "justMail Datei", Application.StartupPath & "\justMail.exe", Application.StartupPath & "\justMail.ico")

    End Sub

    Public Function Registerfile(ByVal endung As String, ByVal namedesdateityps As String, ByVal pfadzuprogramm As String, ByVal pfadzuicon As String) As Boolean
        Try
            Dim objSubKey As Microsoft.Win32.RegistryKey
            Dim objSubKey2 As Microsoft.Win32.RegistryKey
            Dim Wert As String = namedesdateityps
            Dim sKey As String = endung
            Dim sKey2 As String = endung & "\ShellNew"
            Dim sEntry As String = "Content Type"
            Dim sValue As String = "text/plain"
            Dim sEntry2 As String = "PerceivedType"
            Dim sValue2 As String = "text"
            Dim sEntry3 As String = "Nullfile"
            objSubKey = My.Computer.Registry.ClassesRoot.CreateSubKey(sKey)
            objSubKey.SetValue("", Wert)
            objSubKey.SetValue(sEntry, sValue)
            objSubKey.SetValue(sEntry2, sValue2)
            objSubKey2 = My.Computer.Registry.ClassesRoot.CreateSubKey(sKey2)
            objSubKey2.SetValue(sEntry3, "")

            Dim objSubKey3 As Microsoft.Win32.RegistryKey
            Dim sKey3 As String = namedesdateityps
            Dim sKey4 As String = namedesdateityps & "\shell\open\command"
            Dim skey5 As String = namedesdateityps & "\DefaultIcon"
            Dim sValue3 As String = namedesdateityps
            Dim objSubKey5 As Microsoft.Win32.RegistryKey
            Dim sValue5 As String = """" + pfadzuprogramm + """" + " %1"
            Dim sValue6 As String = """" + pfadzuicon + """"
            Dim objSubKey4 As Microsoft.Win32.RegistryKey

            objSubKey3 = My.Computer.Registry.ClassesRoot.CreateSubKey(sKey3)
            objSubKey3.SetValue("", sValue3)
            objSubKey4 = My.Computer.Registry.ClassesRoot.CreateSubKey(sKey4)
            objSubKey4.SetValue("", sValue5)
            objSubKey5 = My.Computer.Registry.ClassesRoot.CreateSubKey(skey5)
            objSubKey5.SetValue("", sValue6)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub saveConfigFile()
        myConfig.WriteValue(cc("justMail config"), "69181920192011820", CStr(mySfirststart))
        myConfig.WriteValue(cc("justMail config"), "315211420", CStr(myScc))
        myConfig.WriteValue(cc("justMail config"), "121192012153", mySlastLoc)
        myConfig.WriteValue(cc("justMail config"), "1211920199265", mySlastSize)
        myConfig.WriteValue(cc("justMail config"), "2391441523131545", mySwindowMode)
        myConfig.Save(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("config") + "\" + cc("config") + ".ini")
    End Sub

    Public Function readConfigFile() As Boolean
        myConfig.Load(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("config") + "\" + cc("config") + ".ini")
        mySfirststart = CBool(myConfig.TryGetValue(cc("justMail config"), "69181920192011820", "True"))
        myScc = CInt(myConfig.TryGetValue(cc("justMail config"), "315211420", "321"))
        mySlastLoc = myConfig.TryGetValue(cc("justMail config"), "121192012153", "10000;10000")
        mySlastSize = myConfig.TryGetValue(cc("justMail config"), "1211920199265", "1024;600")
        mySwindowMode = myConfig.TryGetValue(cc("justMail config"), "2391441523131545", "Normal")
        Return True
    End Function



End Module
