Imports System.IO
Imports System.Text
Imports System.Net.Sockets
Imports OpenPop.Pop3
Imports System.Net.Mail
Imports System.Text.RegularExpressions
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

Public Class frmMain


    Dim useEmailBGW As String
    Dim usepop3 As Boolean
    Dim usessl As Boolean
    Dim password As String
    Dim pop3srv As String
    Dim pop3prt As Integer
    Dim imapsrv As String
    Dim imapprt As Integer
    Public mode As Integer = 0
    Dim lE As String
    Dim eml As String
    Dim newml As String
    Public mEx As Boolean = False
    Dim navA As Boolean = False
    Public emailAds As New List(Of String)
    Public checkUpdateCredits As Boolean = False
    Public windowFormINT As Integer = 0

    Public closeE As Boolean = False
    Const SORTIERSPALTE_INDEX = 0

    Private Const DISABLE_SOUNDS As Integer = 21
    Private Const SET_FEATURE_ON_PROCESS As Integer = 2

    <DllImport("urlmon.dll")> _
    Public Shared Function CoInternetSetFeatureEnabled( _
    ByVal FeatureEntry As Integer, <MarshalAs(UnmanagedType.U4)> ByVal dwFlags As Integer, ByVal fEnable As Boolean) As Integer
    End Function
    <DllImport("uxtheme", CharSet:=CharSet.Unicode)> _
    Public Shared Function SetWindowTheme(hWnd As IntPtr, textSubAppName As String, textSubIdList As String) As Int32
    End Function

    Private Sub frmMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If closeE = True Then
            e.Cancel = True
            closeE = False
            Me.Focus()
            tvAccounts.ExpandAll()
            btnRenew.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Standalone
            btnAddressBook.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Standalone
            btnNewEmail.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Standalone
        End If
        If frmAddressBook.Visible = True Then
            frmAddressBook.Close()
            frmAddContact.Close()
            frmEditContact.Close()
        End If
        mySlastLoc = CStr(Me.Location.X) + ";" + CStr(Me.Location.Y)
        mySlastSize = Me.Size.Width.ToString + ";" + Me.Size.Height.ToString
        mySwindowMode = Me.WindowState.ToString
        saveConfigFile()
    End Sub

    Sub SortListbox(ByVal box As ListBox)
        ' box prüfen: sortieren sinnvoll ?
        If box Is Nothing OrElse box.Items.Count < 2 Then Return
        ' 2 arrays anlegen
        Dim count As Integer = box.Items.Count
        Dim items(count - 1) As Object       ' enthält die ganzen strings
        Dim numbers(count - 1) As Integer    ' enthält nur die extrahierten Zahlen
        ' items kopieren
        box.Items.CopyTo(items, 0)
        ' Zahlenarray
        For i = 0 To count - 1
            'Dim m As Match = Regex.Match(CStr(items(i)), "(\d+)")  ' extrahiert die erste beliebige Zahl
            Dim m As Match = Regex.Match(CStr(items(i)), "^(\d+)")  ' extrahiert nur Zahlen die am Anfang stehen
            If m.Success Then numbers(i) = CInt(m.Groups(1).Value) Else numbers(i) = 0
        Next
        ' beide arrays sortieren: numbers führt
        Array.Sort(numbers, items)
        ' Liste neu befüllen
        box.Items.Clear()
        box.Items.AddRange(items)
    End Sub

    Public Sub refreshListViewGroups()
        lvEmails.Groups.Add(New ListViewGroup("Heute"))
        lvEmails.Groups.Add(New ListViewGroup("Gestern"))
        lvEmails.Groups.Add(New ListViewGroup("Dieser Monat"))
        lvEmails.Groups.Add(New ListViewGroup("Sonstiger Zeitraum"))
        lvOutEmails.Groups.Add(New ListViewGroup("Heute"))
        lvOutEmails.Groups.Add(New ListViewGroup("Gestern"))
        lvOutEmails.Groups.Add(New ListViewGroup("Dieser Monat"))
        lvOutEmails.Groups.Add(New ListViewGroup("Sonstiger Zeitraum"))
        Dim month As String = CStr(Date.Now.Month)
        If month = "12" Then
        ElseIf month = "11" Then
        ElseIf month = "10" Then
        Else
            month = "0" + month
        End If
        For Each i As ListViewItem In lvEmails.Items
            If i.SubItems(3).Text.Contains("Heute") Then
                For Each g As ListViewGroup In lvEmails.Groups
                    If g.Header = "Heute" Then
                        i.Group = g
                    End If
                Next
            Else
                If i.SubItems(3).Text.Contains("Gestern") Then
                    For Each g As ListViewGroup In lvEmails.Groups
                        If g.Header = "Gestern" Then
                            i.Group = g
                        End If
                    Next
                Else
                    If i.SubItems(3).Text.Contains("." + month + ".") Then
                        For Each g As ListViewGroup In lvEmails.Groups

                            If g.Header = "Dieser Monat" Then
                                i.Group = g
                            End If
                        Next
                    Else
                        For Each g As ListViewGroup In lvEmails.Groups

                            If g.Header = "Sonstiger Zeitraum" Then
                                i.Group = g
                            End If
                        Next
                    End If
                End If

            End If
        Next
        For Each i As ListViewItem In lvOutEmails.Items
            If i.SubItems(3).Text.Contains("Heute") Then
                For Each g As ListViewGroup In lvOutEmails.Groups
                    If g.Header = "Heute" Then
                        i.Group = g
                    End If
                Next
            Else
                If i.SubItems(3).Text.Contains("Gestern") Then
                    For Each g As ListViewGroup In lvOutEmails.Groups
                        If g.Header = "Gestern" Then
                            i.Group = g
                        End If
                    Next
                Else
                    If i.SubItems(3).Text.Contains("." + month + ".") Then
                        For Each g As ListViewGroup In lvOutEmails.Groups

                            If g.Header = "Dieser Monat" Then
                                i.Group = g
                            End If
                        Next
                    Else
                        For Each g As ListViewGroup In lvOutEmails.Groups

                            If g.Header = "Sonstiger Zeitraum" Then
                                i.Group = g
                            End If
                        Next
                    End If
                End If

            End If
        Next
    End Sub

    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        loadAccs()
        SetWindowTheme(lvEmails.Handle, "explorer", Nothing)
        SetWindowTheme(lvOutEmails.Handle, "explorer", Nothing)
        SetWindowTheme(rtbEmailPreview.Handle, "explorer", Nothing)
        SetWindowTheme(wbPreviewEmail.Handle, "explorer", Nothing)
    End Sub
    Public Sub checkForUpdate()
        updateCTRL.autoCloseHostApplication = True
        updateCTRL.releaseFilter.checkForBeta = True
        updateCTRL.showDialogsInTaskbar = True
        updateCTRL.showTaskBarProgress = True
        updateCTRL.updateInteractive()
    End Sub

    Private Sub showNewMessagesSingle(ByVal email As String, ByVal count As Integer)
        Dim text As String = ""
        If count = 1 Then
            text = CStr(count) + " neue Nachricht an '" + email + "'"
        Else
            text = CStr(count) + " neue Nachrichten an '" + email + "'"
        End If
        'frmNotificationR.lblText.Text = text
        'frmNotificationR.lblTitle.Text = "Neue Nachrichten"
        'frmNotificationR.Show()
        My.Computer.Audio.Play(My.Resources.newEmail, AudioPlayMode.Background)
    End Sub

    Private Sub showNewMessagesAll(ByVal count As Integer)
        Dim text As String = ""
        If count = 1 Then
            text = CStr(count) + " neue Nachricht an alle E-Mail-Adressen"
        Else
            text = CStr(count) + " neue Nachrichten an alle E-Mail-Adressen"
        End If
        'frmNotificationR.lblText.Text = text
        'frmNotificationR.lblTitle.Text = "Neue Nachrichten"
        'frmNotificationR.Show()
        My.Computer.Audio.Play(My.Resources.newEmail, AudioPlayMode.Background)
    End Sub

    Public Sub loadAccs()
        tvAccounts.Nodes.Clear()
        If IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "").Count = 0 Then
            frmAddEmail.Show()
            Me.Close()
        Else
            For Each z As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "")
                'Dim treeN As TreeNode = New TreeNode(z)
                IO.Directory.CreateDirectory(z + "\rM")
                IO.Directory.CreateDirectory(z + "\sM")
                IO.Directory.CreateDirectory(z + "\osM")
                IO.Directory.CreateDirectory(z + "\seM\")
                IO.Directory.CreateDirectory(z + "\jM\")
                IO.Directory.CreateDirectory(z + "\jF\")
                IO.Directory.CreateDirectory(z + "\jF\sj\")
                IO.Directory.CreateDirectory(z + "\jF\b\")
                IO.Directory.CreateDirectory(z + "\jF\t\")
                IO.Directory.CreateDirectory(z + "\jF\dt\")

                If Not menuRenew.Items.ContainsKey(z.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\", "")) Then
                    menuRenew.Items.Add(z.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\", ""))
                End If

                emailAds.Add(z.Replace("C:\Users\" + Environment.UserName + "\AppData\Roaming\justMail\" + cc("accounts") + "\", ""))
                Dim node As New TreeNode With {.Name = z.Replace("C:\Users\" + Environment.UserName + "\AppData\Roaming\justMail\" + cc("accounts") + "\", ""), .Text = z.Replace("C:\Users\" + Environment.UserName + "\AppData\Roaming\justMail\" + cc("accounts") + "\", "")}
                node.Nodes.Add("Posteingang")
                node.Nodes(0).Nodes.Add("Junk E-Mails")
                node.Nodes.Add("Papierkorb")
                node.Nodes.Add("Postausgang")
                node.Nodes(2).Nodes.Add("Entwürfe")
                tvAccounts.Nodes.Add(node)
                tvAccounts.SelectedNode = tvAccounts.Nodes(0).Nodes(0)
            Next
            tvAccounts.ExpandAll()
            For Each n As TreeNode In tvAccounts.Nodes
                n.Nodes(2).Collapse()
                n.Nodes(0).Collapse()
            Next
        End If
        If mySwindowMode = "Normal" Then
            Dim ls As New List(Of String)
            ls.AddRange(Split(mySlastSize, ";"))
            Me.Size = New Size(CInt(ls(0)), CInt(ls(1)))
            Dim ls2 As New List(Of String)
            ls2.AddRange(Split(mySlastLoc, ";"))
            If mySlastLoc = "10000;10000" Then

            Else
                Me.Location = New Point(CInt(ls2(0)), CInt(ls2(1)))
            End If

        ElseIf mySwindowMode = "Maximized" Then
            Me.Size = New Size(1024, 600)
            Dim ls2 As New List(Of String)
            ls2.AddRange(Split(mySlastLoc, ";"))
            If ls2(0) = "10000" Then

            Else
                Me.Location = New Point(CInt(ls2(0)), CInt(ls2(1)))
            End If
            Me.Location = New Point(CInt(ls2(0)), CInt(ls2(1)))
            Me.WindowState = FormWindowState.Maximized
        Else

            mySwindowMode = "Normal"
        End If
        lvEmails.Font = New Font("Segoe UI", 10)
        lvOutEmails.Font = New Font("Segoe UI", 10)
        CoInternetSetFeatureEnabled(DISABLE_SOUNDS, SET_FEATURE_ON_PROCESS, True)
    End Sub

    Public Sub addEmailAcc(ByVal newEmail As String)
        tvAccounts.Nodes.Clear()
        menuRenew.Items.Add(newEmail)
        For Each z As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "")
            'Dim treeN As TreeNode = New TreeNode(z)
            IO.Directory.CreateDirectory(z + "\rM")
            IO.Directory.CreateDirectory(z + "\sM")
            IO.Directory.CreateDirectory(z + "\osM")
            Dim node As New TreeNode With {.Name = z.Replace("C:\Users\" + Environment.UserName + "\AppData\Roaming\justMail\" + cc("accounts") + "\", ""), .Text = z.Replace("C:\Users\" + Environment.UserName + "\AppData\Roaming\justMail\" + cc("accounts") + "\", "")}
            node.Nodes.Add("Posteingang")
            node.Nodes(0).Nodes.Add("Junk E-Mails")
            node.Nodes.Add("Papierkorb")
            node.Nodes.Add("Postausgang")
            node.Nodes(2).Nodes.Add("Entwürfe")
            tvAccounts.Nodes.Add(node)
            tvAccounts.SelectedNode = tvAccounts.Nodes(0).Nodes(0)
        Next
        tvAccounts.ExpandAll()
        For Each n As TreeNode In tvAccounts.Nodes
            n.Nodes(0).Collapse()
            n.Nodes(2).Collapse()
        Next

        lvEmails.Font = New Font("Segoe UI", 10)
        lvOutEmails.Font = New Font("Segoe UI", 10)
        CoInternetSetFeatureEnabled(DISABLE_SOUNDS, SET_FEATURE_ON_PROCESS, True)
    End Sub

    Public Function getEmail(ByVal emailaddress As String) As Boolean
        Dim usepop3str As String = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + emailaddress + "\mtd"))
        If usepop3str = "pop3" Then
            usepop3 = True
        ElseIf usepop3str = "imap" Then
            usepop3 = False
        Else
            MsgBox("Fehler beim Auslesen der Methode. Das Profil von '" + emailaddress + "' scheint beschädigt zu sein.", MsgBoxStyle.Exclamation, "Fehler beim Auslesen - justMail")
            Stop
        End If
        usessl = CBool(cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + emailaddress + "\s-uon")))
        password = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + emailaddress + "\p"))
        If usepop3 = True Then
            pop3srv = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + emailaddress + "\p3s"))
            pop3prt = CInt(cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + emailaddress + "\p3p")))
        Else
            imapsrv = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + emailaddress + "\ims"))
            imapprt = CInt(cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + emailaddress + "\imp")))
        End If

        Return True
    End Function

    Private Sub btnNewEmail_Click(sender As System.Object, e As System.EventArgs) Handles btnNewEmail.Click
        showNewEmailWindow()
    End Sub

    Private Sub showNewEmailWindow()
        Dim mail As String

        If tvAccounts.SelectedNode.Text = "Entwürfe" Then
            mail = tvAccounts.SelectedNode.Parent.Parent.Text
        ElseIf tvAccounts.SelectedNode.Text = "Papierkorb" OrElse tvAccounts.SelectedNode.Text = "Posteingang" OrElse tvAccounts.SelectedNode.Text = "Postausgang" Then
            mail = tvAccounts.SelectedNode.Parent.Text
        Else
            mail = tvAccounts.SelectedNode.Text
        End If

        Dim name As String = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mail + "\nm"))

        Dim frm As New frmNewEmail
        frm.selectname = name + " (" + mail + ")"
        frm.inUseEmail = mail
        frm.ShowDialog(Me)
        frm.tbTo.Focus()
    End Sub

    Private Sub btnRenew_Click(sender As System.Object, e As System.EventArgs) Handles btnRenew.Click
        For Each tN As TreeNode In tvAccounts.Nodes
            getEmail(tN.Text)
        Next
    End Sub

    Private Sub tvAccounts_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvAccounts.AfterSelect

        '-------------------------------------------------------------------------------------------------------Posteingang

        If tvAccounts.SelectedNode.Text = "Posteingang" Then
            btnAnswer.Enabled = True
            btnSendAGN.Enabled = True
            rtbEmailPreview.Visible = False
            wbPreviewEmail.Visible = False
            lvEmails.Show()
            lvOutEmails.Hide()
            pnlSTRleft.Visible = False
            pnlSplitter.Visible = False
            pnlSTRleft2.Visible = False : pnlSplitter.Visible = False
            pnlSTRtop.Visible = False
            pnlMenuPreview.Visible = False
            pnlSTRbtm2.Visible = False
            Dim mail As String = tvAccounts.SelectedNode.Parent.Text
            lvEmails.Items.Clear()

            For Each s As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mail + "\sM\")
                Try
                    Dim DATEs As String = cdc(IO.File.ReadAllText(s + "\dt"))
                    Dim DATEs0 As String = DATEs.Substring(0, DATEs.Length - 9)
                    Dim curDate00 As String = Date.Now.ToString
                    Dim curDate000 As String = curDate00.Substring(0, curDate00.Length - 9)
                    Dim yesDate00 As Date = CDate(CStr(Date.Now).Substring(0, CStr(Date.Now).Length - 9))
                    yesDate00 = DateAdd(DateInterval.Day, -1, yesDate00)
                    Dim yesdate000 As String = yesDate00.ToString
                    Dim yesdate0000 As String = yesdate000.Substring(0, yesdate000.Length - 9)
                    If DATEs0 = curDate000 Then
                        Dim subject As String = cdc(IO.File.ReadAllText(s + "\s"))
                        Dim by0 As String = cdc(IO.File.ReadAllText(s + "\b"))
                        Dim bySplit As New List(Of String)
                        bySplit.AddRange(Split(by0, " <"))
                        Dim by As String = bySplit(0).Replace("""", "").Replace("""", "")
                        Dim dateSent As String = DATEs.Replace(curDate000, "Heute").Substring(0, DATEs.Length - 8)
                        Dim readStatus As String = cdc(IO.File.ReadAllText(s + "\rst"))
                        If readStatus = "False" Then
                            Dim newI As New ListViewItem(New String() {DATEs, subject, by, dateSent}, 0)
                            newI.UseItemStyleForSubItems = False
                            newI.SubItems(1).Font = New Font(lvEmails.Font, FontStyle.Bold)
                            lvEmails.Items.Add(newI)
                        Else
                            Dim newI As New ListViewItem(New String() {DATEs, subject, by, dateSent})
                            lvEmails.Items.Add(newI)
                        End If
                    ElseIf DATEs0 = yesdate0000 Then
                        Dim subject As String = cdc(IO.File.ReadAllText(s + "\s"))
                        Dim by0 As String = cdc(IO.File.ReadAllText(s + "\b"))
                        Dim bySplit As New List(Of String)
                        bySplit.AddRange(Split(by0, " <"))
                        Dim by As String = bySplit(0).Replace("""", "").Replace("""", "")
                        Dim dateSent As String = DATEs.Replace(yesdate0000, "Gestern").Substring(0, DATEs.Length - 6)
                        Dim readStatus As String = cdc(IO.File.ReadAllText(s + "\rst"))

                        If readStatus = "False" Then
                            Dim newI As New ListViewItem(New String() {DATEs, subject, by, dateSent}, 0)
                            newI.UseItemStyleForSubItems = False
                            newI.SubItems(1).Font = New Font(lvEmails.Font, FontStyle.Bold)
                            lvEmails.Items.Add(newI)
                        Else
                            Dim newI As New ListViewItem(New String() {DATEs, subject, by, dateSent})
                            lvEmails.Items.Add(newI)
                        End If
                    Else
                        Dim subject As String = cdc(IO.File.ReadAllText(s + "\s"))
                        Dim by0 As String = cdc(IO.File.ReadAllText(s + "\b"))
                        Dim bySplit As New List(Of String)
                        bySplit.AddRange(Split(by0, " <"))
                        Dim by As String = bySplit(0).Replace("""", "").Replace("""", "")
                        Dim dateSent As String = DATEs.Substring(0, DATEs.Length - 3)
                        Dim readStatus As String = cdc(IO.File.ReadAllText(s + "\rst"))

                        If readStatus = "False" Then
                            Dim newI As New ListViewItem(New String() {DATEs, subject, by, dateSent}, 0)
                            newI.UseItemStyleForSubItems = False
                            newI.SubItems(1).Font = New Font(lvEmails.Font, FontStyle.Bold)
                            lvEmails.Items.Add(newI)
                        Else
                            Dim newI As New ListViewItem(New String() {DATEs, subject, by, dateSent})
                            lvEmails.Items.Add(newI)
                        End If
                    End If
                Catch ex1 As FileNotFoundException
                    IO.Directory.Delete(s, True)
                End Try
            Next
            If lvEmails.Items.Count = 0 Then
                rtbEmailPreview.Visible = False
                pnlSTRleft.Visible = False
                pnlSTRleft2.Visible = False : pnlSplitter.Visible = False
                pnlSTRtop.Visible = False
                pnlMenuPreview.Visible = False
                pnlSTRbtm2.Visible = False
                wbPreviewEmail.Visible = False
                lblNoMails.Visible = True
            Else
                lblNoMails.Visible = False
            End If

            '-------------------------------------------------------------------------------------------------------Papierkorb

        ElseIf tvAccounts.SelectedNode.Text = "Papierkorb" Then
            btnAnswer.Enabled = True
            btnSendAGN.Enabled = True
            rtbEmailPreview.Visible = False
            wbPreviewEmail.Visible = False
            pnlSTRleft.Visible = False
            pnlSTRleft2.Visible = False : pnlSplitter.Visible = False
            pnlSTRtop.Visible = False
            pnlMenuPreview.Visible = False
            pnlSTRbtm2.Visible = False
            lvEmails.Show()
            lvOutEmails.Hide()
            Dim mail As String = tvAccounts.SelectedNode.Parent.Text
            lvEmails.Items.Clear()

            For Each s As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mail + "\rM\")
                Try
                    Dim DATEs As String = cdc(IO.File.ReadAllText(s + "\dt"))
                    Dim DATEs0 As String = DATEs.Substring(0, DATEs.Length - 9)
                    Dim curDate00 As String = Date.Now.ToString
                    Dim curDate000 As String = curDate00.Substring(0, curDate00.Length - 9)
                    Dim yesDate00 As Date = CDate(CStr(Date.Now).Substring(0, CStr(Date.Now).Length - 9))
                    yesDate00 = DateAdd(DateInterval.Day, -1, yesDate00)
                    Dim yesdate000 As String = yesDate00.ToString
                    Dim yesdate0000 As String = yesdate000.Substring(0, yesdate000.Length - 9)
                    If DATEs0 = curDate000 Then
                        Dim subject As String = cdc(IO.File.ReadAllText(s + "\s"))
                        Dim by0 As String = cdc(IO.File.ReadAllText(s + "\b"))
                        Dim bySplit As New List(Of String)
                        bySplit.AddRange(Split(by0, " <"))
                        Dim by As String = bySplit(0).Replace("""", "").Replace("""", "")
                        Dim dateSent As String = DATEs.Replace(curDate000, "Heute").Substring(0, DATEs.Length - 8)
                        Dim readStatus As String = cdc(IO.File.ReadAllText(s + "\rst"))

                        If readStatus = "False" Then
                            Dim newI As New ListViewItem(New String() {DATEs, subject, by, dateSent}, 0)
                            newI.UseItemStyleForSubItems = False
                            newI.SubItems(1).Font = New Font(lvEmails.Font, FontStyle.Bold)
                            lvEmails.Items.Add(newI)
                        Else
                            Dim newI As New ListViewItem(New String() {DATEs, subject, by, dateSent})
                            lvEmails.Items.Add(newI)
                        End If
                    ElseIf DATEs0 = yesdate0000 Then
                        Dim subject As String = cdc(IO.File.ReadAllText(s + "\s"))
                        Dim by0 As String = cdc(IO.File.ReadAllText(s + "\b"))
                        Dim bySplit As New List(Of String)
                        bySplit.AddRange(Split(by0, " <"))
                        Dim by As String = bySplit(0).Replace("""", "").Replace("""", "")
                        Dim dateSent As String = DATEs.Replace(yesdate0000, "Gestern").Substring(0, DATEs.Length - 6)
                        Dim readStatus As String = cdc(IO.File.ReadAllText(s + "\rst"))

                        If readStatus = "False" Then
                            Dim newI As New ListViewItem(New String() {DATEs, subject, by, dateSent}, 0)
                            newI.UseItemStyleForSubItems = False
                            newI.SubItems(1).Font = New Font(lvEmails.Font, FontStyle.Bold)
                            lvEmails.Items.Add(newI)
                        Else
                            Dim newI As New ListViewItem(New String() {DATEs, subject, by, dateSent})
                            lvEmails.Items.Add(newI)
                        End If
                    Else
                        Dim subject As String = cdc(IO.File.ReadAllText(s + "\s"))
                        Dim by0 As String = cdc(IO.File.ReadAllText(s + "\b"))
                        Dim bySplit As New List(Of String)
                        bySplit.AddRange(Split(by0, " <"))
                        Dim by As String = bySplit(0).Replace("""", "").Replace("""", "")
                        Dim dateSent As String = DATEs.Substring(0, DATEs.Length - 3)
                        Dim readStatus As String = cdc(IO.File.ReadAllText(s + "\rst"))

                        If readStatus = "False" Then
                            Dim newI As New ListViewItem(New String() {DATEs, subject, by, dateSent}, 0)
                            newI.UseItemStyleForSubItems = False
                            newI.SubItems(1).Font = New Font(lvEmails.Font, FontStyle.Bold)
                            lvEmails.Items.Add(newI)
                        Else
                            Dim newI As New ListViewItem(New String() {DATEs, subject, by, dateSent})
                            lvEmails.Items.Add(newI)
                        End If
                    End If
                Catch ex1 As FileNotFoundException
                    IO.Directory.Delete(s, True)
                End Try
            Next
            If lvEmails.Items.Count = 0 Then
                rtbEmailPreview.Visible = False
                pnlSTRleft.Visible = False
                pnlSTRleft2.Visible = False : pnlSplitter.Visible = False
                pnlSTRtop.Visible = False
                pnlMenuPreview.Visible = False
                pnlSTRbtm2.Visible = False
                wbPreviewEmail.Visible = True
                wbPreviewEmail.Visible = False
                lblNoMails.Visible = True
            Else
                lblNoMails.Visible = False
            End If

            '-------------------------------------------------------------------------------------------------------Junk E-Mails

        ElseIf tvAccounts.SelectedNode.Text = "Junk E-Mails" Then
            btnAnswer.Enabled = True
            btnSendAGN.Enabled = True
            rtbEmailPreview.Visible = False
            wbPreviewEmail.Visible = False
            pnlSTRleft.Visible = False
            pnlSTRleft2.Visible = False : pnlSplitter.Visible = False
            pnlSTRtop.Visible = False
            pnlMenuPreview.Visible = False
            pnlSTRbtm2.Visible = False
            lvEmails.Show()
            lvOutEmails.Hide()
            Dim mail As String = tvAccounts.SelectedNode.Parent.Text
            lvEmails.Items.Clear()

            If lvEmails.Items.Count = 0 Then
                rtbEmailPreview.Visible = False
                pnlSTRleft.Visible = False
                pnlSTRleft2.Visible = False : pnlSplitter.Visible = False
                pnlSTRtop.Visible = False
                pnlMenuPreview.Visible = False
                pnlSTRbtm2.Visible = False
                wbPreviewEmail.Visible = True
                wbPreviewEmail.Visible = False
                lblNoMails.Visible = True
            Else
                lblNoMails.Visible = False
            End If

            '-------------------------------------------------------------------------------------------------------Postausgang

        ElseIf tvAccounts.SelectedNode.Text = "Postausgang" Then
            btnAnswer.Enabled = False
            btnSendAGN.Enabled = False
            rtbEmailPreview.Visible = False
            wbPreviewEmail.Visible = False
            pnlSTRleft.Visible = False
            pnlSTRleft2.Visible = False : pnlSplitter.Visible = False
            pnlSTRtop.Visible = False
            pnlMenuPreview.Visible = False
            pnlSTRbtm2.Visible = False
            lvOutEmails.Show()
            lvEmails.Hide()
            Dim mail As String = tvAccounts.SelectedNode.Parent.Text
            lvOutEmails.Items.Clear()

            For Each s As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mail + "\osM\")
                Try
                    Dim DATEs As String = cdc(IO.File.ReadAllText(s + "\dt"))
                    Dim DATEs0 As String = DATEs.Substring(0, DATEs.Length - 9)
                    Dim curDate00 As String = Date.Now.ToString
                    Dim curDate000 As String = curDate00.Substring(0, curDate00.Length - 9)
                    Dim yesDate00 As Date = CDate(CStr(Date.Now).Substring(0, CStr(Date.Now).Length - 9))
                    yesDate00 = DateAdd(DateInterval.Day, -1, yesDate00)
                    Dim yesdate000 As String = yesDate00.ToString
                    Dim yesdate0000 As String = yesdate000.Substring(0, yesdate000.Length - 9)
                    If DATEs0 = curDate000 Then
                        Dim subject As String = cdc(IO.File.ReadAllText(s + "\s"))
                        Dim tos As String = cdc(IO.File.ReadAllText(s + "\t")).Replace("<", "").Replace(">", "")
                        tos = tos.Substring(0, tos.Length - 1)
                        Dim dateSent As String = DATEs.Replace(curDate000, "Heute").Substring(0, DATEs.Length - 8)
                        With lvOutEmails.Items.Insert(0, DATEs)
                            .SubItems.Add(subject)
                            .SubItems.Add(tos.Substring(0, tos.Length - 1))

                            .SubItems.Add(dateSent)
                        End With
                    ElseIf DATEs0 = yesdate0000 Then
                        Dim subject As String = cdc(IO.File.ReadAllText(s + "\s"))
                        Dim tos As String = cdc(IO.File.ReadAllText(s + "\t")).Replace("<", "").Replace(">", "")
                        tos = tos.Substring(0, tos.Length - 1)
                        Dim dateSent As String = DATEs.Replace(yesdate0000, "Gestern").Substring(0, DATEs.Length - 6)
                        With lvOutEmails.Items.Insert(0, DATEs)
                            .SubItems.Add(subject)
                            .SubItems.Add(tos)
                            .SubItems.Add(dateSent)
                        End With
                    Else
                        Dim subject As String = cdc(IO.File.ReadAllText(s + "\s"))
                        Dim tos As String = cdc(IO.File.ReadAllText(s + "\t")).Replace("<", "").Replace(">", "")
                        tos = tos.Substring(0, tos.Length - 1)
                        Dim dateSent As String = DATEs.Substring(0, DATEs.Length - 3)
                        With lvOutEmails.Items.Insert(0, DATEs)
                            .SubItems.Add(subject)
                            .SubItems.Add(tos)

                            .SubItems.Add(dateSent)
                        End With
                    End If
                Catch ex1 As FileNotFoundException
                    IO.Directory.Delete(s, True)
                End Try
            Next
            If lvOutEmails.Items.Count = 0 Then
                rtbEmailPreview.Visible = False
                pnlSTRleft.Visible = False
                pnlSTRleft2.Visible = False : pnlSplitter.Visible = False
                pnlSTRtop.Visible = False
                pnlMenuPreview.Visible = False
                pnlSTRbtm2.Visible = False
                wbPreviewEmail.Visible = False
                lblNoMails.Visible = True
            Else
                lblNoMails.Visible = False
            End If

            '-------------------------------------------------------------------------------------------------------Entwürfe

        ElseIf tvAccounts.SelectedNode.Text = "Entwürfe" Then
            btnAnswer.Enabled = False
            btnSendAGN.Enabled = False
            rtbEmailPreview.Visible = False
            wbPreviewEmail.Visible = False
            pnlSTRleft.Visible = False
            pnlSTRleft2.Visible = False : pnlSplitter.Visible = False
            pnlSTRtop.Visible = False
            pnlMenuPreview.Visible = False
            pnlSTRbtm2.Visible = False
            lvOutEmails.Show()
            lvEmails.Hide()
            Dim mail As String = tvAccounts.SelectedNode.Parent.Parent.Text
            lvOutEmails.Items.Clear()

            For Each s As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mail + "\seM\")
                Try
                    Dim DATEs As String = cdc(IO.File.ReadAllText(s + "\dt"))
                    Dim DATEs0 As String = DATEs.Substring(0, DATEs.Length - 9)
                    Dim curDate00 As String = Date.Now.ToString
                    Dim curDate000 As String = curDate00.Substring(0, curDate00.Length - 9)
                    Dim yesDate00 As Date = CDate(CStr(Date.Now).Substring(0, CStr(Date.Now).Length - 9))
                    yesDate00 = DateAdd(DateInterval.Day, -1, yesDate00)
                    Dim yesdate000 As String = yesDate00.ToString
                    Dim yesdate0000 As String = yesdate000.Substring(0, yesdate000.Length - 9)
                    If DATEs0 = curDate000 Then
                        Dim subject As String = cdc(IO.File.ReadAllText(s + "\s"))
                        Dim tos As String = cdc(IO.File.ReadAllText(s + "\t"))
                        Dim dateSent As String = DATEs.Replace(curDate000, "Heute").Substring(0, DATEs.Length - 8)
                        With lvOutEmails.Items.Insert(0, DATEs)
                            .SubItems.Add(subject)
                            .SubItems.Add(tos)

                            .SubItems.Add(dateSent)
                        End With
                    ElseIf DATEs0 = yesdate0000 Then
                        Dim subject As String = cdc(IO.File.ReadAllText(s + "\s"))
                        Dim tos As String = cdc(IO.File.ReadAllText(s + "\t"))
                        Dim dateSent As String = DATEs.Replace(yesdate0000, "Gestern").Substring(0, DATEs.Length - 6)
                        With lvOutEmails.Items.Insert(0, DATEs)
                            .SubItems.Add(subject)
                            .SubItems.Add(tos)
                            .SubItems.Add(dateSent)
                        End With
                    Else
                        Dim subject As String = cdc(IO.File.ReadAllText(s + "\s"))
                        Dim tos As String = cdc(IO.File.ReadAllText(s + "\t"))
                        Dim dateSent As String = DATEs.Substring(0, DATEs.Length - 3)
                        With lvOutEmails.Items.Insert(0, DATEs)
                            .SubItems.Add(subject)
                            .SubItems.Add(tos)

                            .SubItems.Add(dateSent)
                        End With
                    End If
                Catch ex1 As FileNotFoundException
                    IO.Directory.Delete(s, True)
                End Try
            Next
            If lvOutEmails.Items.Count = 0 Then
                rtbEmailPreview.Visible = False
                pnlSTRleft.Visible = False
                pnlSTRleft2.Visible = False : pnlSplitter.Visible = False
                pnlSTRtop.Visible = False
                pnlMenuPreview.Visible = False
                pnlSTRbtm2.Visible = False
                wbPreviewEmail.Visible = False
                lblNoMails.Visible = True
            Else
                lblNoMails.Visible = False
            End If

            '-------------------------------------------------------------------------------------------------------E-MAIL

        Else
            rtbEmailPreview.Visible = False
            wbPreviewEmail.Visible = False
            pnlSTRleft.Visible = False
            pnlSTRleft2.Visible = False : pnlSplitter.Visible = False
            pnlSTRtop.Visible = False
            pnlMenuPreview.Visible = False
            pnlSTRbtm2.Visible = False
            lvOutEmails.Hide()
            lvEmails.Hide()
        End If

        '----

        refreshListViewGroups()
    End Sub

    Private Sub tmrAuto_Tick(sender As System.Object, e As System.EventArgs) Handles tmrAuto.Tick
        If Me.Visible = True Then

            If getEmailsSingle.IsBusy OrElse getEmailsAll.IsBusy Then
                btnRenew.Enabled = False
            Else
                btnRenew.Enabled = True
            End If


            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            If tvAccounts.SelectedNode.Text = "Posteingang" Then
                Dim EMAIL As String = tvAccounts.SelectedNode.Parent.Text
                If Not IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\justMail\" + cc("accounts") + "\" + EMAIL + "\sM\").Count = lvEmails.Items.Count Then

                    For Each d As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\justMail\" + cc("accounts") + "\" + EMAIL + "\sM\")
                        Try
                            Dim dsj As String = cdc(IO.File.ReadAllText(d + "\s"))
                            Dim ddt As String = cdc(IO.File.ReadAllText(d + "\dt"))

                            Dim exists As Boolean = False

                            For Each l As ListViewItem In lvEmails.Items
                                If l.SubItems(1).Text = dsj Then
                                    If l.Text = ddt Then
                                        exists = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exists = False Then
                                Try
                                    Dim NIDATE As String
                                    Dim NIDATE0 As String
                                    Dim NISUBJ As String
                                    Dim NIBY As String
                                    NIDATE = cdc(IO.File.ReadAllText(d + "\dt"))
                                    NIDATE0 = cdc(IO.File.ReadAllText(d + "\dt"))
                                    NISUBJ = cdc(IO.File.ReadAllText(d + "\s"))
                                    Dim NIBY0 As String = cdc(IO.File.ReadAllText(d + "\b"))
                                    Dim SPLIT1 As New List(Of String) : SPLIT1.AddRange(Split(NIBY0, """"))
                                    NIBY = SPLIT1(1)

                                    '------------------------------------- DATUMFORMATIERUNG
                                    Dim yesDate00 As Date = CDate(CStr(Date.Now).Substring(0, CStr(Date.Now).Length - 9))
                                    yesDate00 = DateAdd(DateInterval.Day, -1, yesDate00)
                                    Dim yesdate000 As String = yesDate00.ToString
                                    Dim curDate00 As String = Date.Now.ToString
                                    'daten
                                    Dim yesdate As String = yesdate000.Substring(0, yesdate000.Length - 9)
                                    Dim curDate As String = curDate00.Substring(0, curDate00.Length - 9)
                                    Dim month As String = CStr(Date.Now.Month)

                                    NIDATE = NIDATE.Substring(0, NIDATE.Length - 3)



                                    If NIDATE.Contains(curDate) Then
                                        NIDATE = NIDATE.Replace(curDate, "Heute")
                                    End If
                                    If NIDATE.Contains(yesdate) Then
                                        NIDATE = NIDATE.Replace(yesdate, "Gestern")
                                    End If

                                    Dim newI As New ListViewItem(New String() {NIDATE0, NISUBJ, NIBY, NIDATE}, 0)
                                    newI.UseItemStyleForSubItems = False
                                    newI.SubItems(1).Font = New Font(lvEmails.Font, FontStyle.Bold)
                                    lvEmails.Items.Add(newI)
                                    If lblNoMails.Visible = True Then
                                        lblNoMails.Visible = False
                                    End If
                                    refreshListViewGroups()
                                Catch : End Try
                            End If
                        Catch ex1 As FileNotFoundException
                            Try
                                IO.Directory.Delete(d, True)
                            Catch : End Try
                        End Try
                    Next

                End If
            ElseIf tvAccounts.SelectedNode.Text = "Postausgang" Then
                Dim EMAIL As String = tvAccounts.SelectedNode.Parent.Text
                If Not IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\justMail\" + cc("accounts") + "\" + EMAIL + "\osM\").Count = lvOutEmails.Items.Count Then
                    For Each d As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\justMail\" + cc("accounts") + "\" + EMAIL + "\osM\")
                        Try
                            Dim dsj As String = cdc(IO.File.ReadAllText(d + "\s"))
                            Dim ddt As String = cdc(IO.File.ReadAllText(d + "\dt"))
                            Dim exists As Boolean = False

                            For Each l As ListViewItem In lvOutEmails.Items
                                If l.SubItems(1).Text = dsj Then
                                    If l.Text = ddt Then
                                        exists = True
                                        Exit For
                                    End If
                                End If
                            Next
                            If exists = False Then
                                Dim NIDATE As String
                                Dim NIDATE0 As String
                                Dim NISUBJ As String
                                Dim NIBY As String
                                NIDATE = cdc(IO.File.ReadAllText(d + "\dt"))
                                NIDATE0 = cdc(IO.File.ReadAllText(d + "\dt"))
                                NISUBJ = cdc(IO.File.ReadAllText(d + "\s"))
                                Dim NIBY0 As String = cdc(IO.File.ReadAllText(d + "\b"))
                                Dim SPLIT1 As New List(Of String) : SPLIT1.AddRange(Split(NIBY0, """"))
                                NIBY = SPLIT1(1)

                                '------------------------------------- DATUMFORMATIERUNG
                                Dim yesDate00 As Date = CDate(CStr(Date.Now).Substring(0, CStr(Date.Now).Length - 9))
                                yesDate00 = DateAdd(DateInterval.Day, -1, yesDate00)
                                Dim yesdate000 As String = yesDate00.ToString
                                Dim curDate00 As String = Date.Now.ToString
                                'daten
                                Dim yesdate As String = yesdate000.Substring(0, yesdate000.Length - 9)
                                Dim curDate As String = curDate00.Substring(0, curDate00.Length - 9)
                                Dim month As String = CStr(Date.Now.Month)

                                NIDATE = NIDATE.Substring(0, NIDATE.Length - 3)



                                If NIDATE.Contains(curDate) Then
                                    NIDATE = NIDATE.Replace(curDate, "Heute")
                                End If
                                If NIDATE.Contains(yesdate) Then
                                    NIDATE = NIDATE.Replace(yesdate, "Gestern")
                                End If

                                Dim newI As New ListViewItem(New String() {NIDATE0, NISUBJ, NIBY, NIDATE}, 0)
                                newI.UseItemStyleForSubItems = False
                                newI.SubItems(1).Font = New Font(lvOutEmails.Font, FontStyle.Bold)
                                lvOutEmails.Items.Add(newI)
                                If lblNoMails.Visible = True Then
                                    lblNoMails.Visible = False
                                End If
                                refreshListViewGroups()
                            End If
                        Catch ex2 As FileNotFoundException
                            IO.Directory.Delete(d, True)
                        End Try
                    Next
                End If
            End If


            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            Try
                If tvAccounts.SelectedNode.Text = "Posteingang" Then
                    Me.Text = "Posteingang - " + tvAccounts.SelectedNode.Parent.Text + " - justMail"
                ElseIf tvAccounts.SelectedNode.Text = "Papierkorb" Then
                    Me.Text = "Papierkorb - " + tvAccounts.SelectedNode.Parent.Text + " - justMail"
                ElseIf tvAccounts.SelectedNode.Text = "Postausgang" Then
                    Me.Text = "Postausgang - " + tvAccounts.SelectedNode.Parent.Text + " - justMail"
                ElseIf tvAccounts.SelectedNode.Text = "Entwürfe" Then
                    Me.Text = "Entwürfe - Postausgang - " + tvAccounts.SelectedNode.Parent.Parent.Text + " - justMail"
                Else
                    Me.Text = tvAccounts.SelectedNode.Text + " - justMail"
                End If
            Catch
                Me.Text = "justMail"
            End Try

            '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            'MenuItem14 undo
            'MenuItem17 cut
            'MenuItem18 copy
            'MenuItem19 paste
            'MenuItem20 del

            If tbSearch.Focused Then
                If tbSearch.CanUndo Then
                    MenuItem14.Enabled = True
                Else
                    MenuItem14.Enabled = False
                End If
                MenuItem19.Enabled = True
                If tbSearch.SelectedText.Length > 0 = True Then
                    MenuItem17.Enabled = True
                    MenuItem18.Enabled = True
                    MenuItem20.Enabled = True
                Else
                    MenuItem17.Enabled = False
                    MenuItem18.Enabled = False
                    MenuItem20.Enabled = False
                End If


            ElseIf rtbEmailPreview.Focused Then
                MenuItem14.Enabled = False
                MenuItem19.Enabled = False
                MenuItem20.Enabled = False
                MenuItem17.Enabled = False
                If rtbEmailPreview.SelectedText.Length > 0 Then
                    MenuItem18.Enabled = True
                Else
                    MenuItem18.Enabled = False
                End If


            ElseIf wbPreviewEmail.ContainsFocus Then
                MenuItem14.Enabled = False
                MenuItem17.Enabled = False
                MenuItem19.Enabled = False
                MenuItem20.Enabled = False
                If wbPreviewEmail.CanCopySelection Then
                    MenuItem18.Enabled = True
                Else
                    MenuItem18.Enabled = False
                End If
            Else
                MenuItem14.Enabled = False
                MenuItem17.Enabled = False
                MenuItem18.Enabled = False
                MenuItem19.Enabled = False
                MenuItem20.Enabled = False
            End If
        End If
    End Sub

    Private Sub menuRenew_ItemClicked(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles menuRenew.ItemClicked
        If e.ClickedItem.Text = "Alle Konten abrufen" Then
            getEmailsAll.RunWorkerAsync()
        Else
            lE = e.ClickedItem.Text
            getEmailsSingle.RunWorkerAsync()
        End If
    End Sub

    Private Sub getEmailsSingle_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles getEmailsSingle.DoWork
        tmrRefreshEmails.Stop()
        Dim totalcount As Integer = 0
        Dim downloadCount As Integer = 0
        Dim mailadr As String
        mailadr = lE
        Dim ptn As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\justMail\" + cc("accounts") + "\" + mailadr
        lblStatus.Text = "Status: Sammle Daten von '" + mailadr + "'..."
        Dim usePOP3 As Boolean
        Dim up3 As String = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\mtd"))
        If up3 = "pop3" Then
            usePOP3 = True
        ElseIf up3 = "imap" Then
            usePOP3 = False
        End If
        If usePOP3 = True Then
            'pop3
            Dim p3srv As String = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\p3s"))
            Dim p3prt As Integer = CInt(cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\p3p")))
            Dim uname As String = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\eml"))
            Dim pw As String = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\p"))
            Dim usessl As Boolean = CBool(cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\s-uon")))
            Dim latestCount As Integer = CInt(cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\lmsgc")))
            lblStatus.Text = "Status: Prüfe auf neue Nachrichten an '" + mailadr + "'..."
            Dim newC As Integer = getEmailCountPOP3(p3srv, p3prt, usessl, uname, pw)
            If newC = 457895487 Then
                lblStatus.Text = "Status: Fehler beim Abrufen neuer Nachrichten an '" + mailadr + "'!"
                System.Threading.Thread.Sleep(2000)
                lblStatus.Text = "Status:"
                Exit Sub
            ElseIf newC = Nothing Then
                lblStatus.Text = "Status: '" + mailadr + "' hat keine E-Mails im Posteingang."
                System.Threading.Thread.Sleep(2000)
                lblStatus.Text = "Status:"
                Exit Sub
            Else
                totalcount = newC
                ' totalcount += 1
            End If
            Dim newEmailCount As Integer = totalcount - latestCount
            Using pop3 As New Pop3Client
                pop3.Connect(p3srv, p3prt, usessl)
                pop3.Authenticate(uname, pw)
                If newEmailCount > 0 Then
                    lblStatus.Text = "Status: " + CStr(newEmailCount) + " neue Nachrichten an '" + mailadr + "'"
                    If pop3.Connected = True Then
                        If latestCount = 0 Then
                            latestCount = 1
                        End If
                        For currentMail As Integer = latestCount + 1 To totalcount
                            downloadCount += 1
                            lblStatus.Text = " Status: Empfange Nachricht " + CStr(downloadCount) + " von " + CStr(totalcount - (latestCount)) + " an '" + mailadr + "'..."
                            Dim MAIL As OpenPop.Mime.Message

                            MAIL = pop3.GetMessage(currentMail)
                            Dim pfN As String = ptn + "\sM"
                            Dim fPN As String = pfN + "\" + CStr(myScc + 1) : IO.Directory.CreateDirectory(fPN) : myScc += 1 : saveConfigFile()
                            IO.Directory.CreateDirectory(fPN + "\attachments")
                            Try
                                Dim subject As String = cc(MAIL.ToMailMessage.Subject)
                                Dim text As String = cc(MAIL.ToMailMessage.Body)
                                Dim by As String = cc(MAIL.ToMailMessage.From.ToString)
                                Dim dateSent0 As String = (CStr(MAIL.Headers.DateSent.AddHours(2)))
                                Dim dateSent As String = cc(dateSent0)
                                Dim sentTo As String = cc(MAIL.ToMailMessage.To.ToString)
                                Dim bcc As String = cc(MAIL.ToMailMessage.Bcc.ToString)
                                Dim ccO As String = cc(MAIL.ToMailMessage.CC.ToString)
                                Dim replTo As String = cc(MAIL.ToMailMessage.ReplyToList.ToString)
                                Dim priority As String = cc(MAIL.ToMailMessage.Priority.ToString)
                                Dim isHtml As String = cc(CStr(MAIL.ToMailMessage.IsBodyHtml))
                                Dim isHtm As String = cc(MAIL.ToMailMessage.IsBodyHtml.ToString)
                                Dim readStatus As String = cc("False")
                                Dim attachs As String = ""
                                Dim mID As String = cc(CStr(currentMail))
                                Dim atmCount As Integer = 0
                                For Each z As Attachment In MAIL.ToMailMessage.Attachments
                                    Dim fullPathAttachs As String = fPN + "\attachments\" + CStr(myScc)
                                    myScc += 1 : saveConfigFile()
                                    IO.Directory.CreateDirectory(fullPathAttachs)
                                    attachs += z.Name + ";;;;;"
                                    Dim allBytes As Byte() = New Byte(CInt(z.ContentStream.Length - 1)) {}
                                    Dim bytesRead As Integer = z.ContentStream.Read(allBytes, 0, CInt(z.ContentStream.Length))
                                    Dim destination As String = fullPathAttachs + "\" + z.Name
                                    Dim writer As New BinaryWriter(New FileStream(destination, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                                    writer.Write(allBytes)
                                    writer.Close()
                                    atmCount += 1
                                Next
                                attachs = cc(attachs)
                                IO.File.WriteAllText(fPN + "\" + "s", subject)
                                IO.File.WriteAllText(fPN + "\" + "tx", text)
                                IO.File.WriteAllText(fPN + "\" + "b", by)
                                IO.File.WriteAllText(fPN + "\" + "dt", dateSent)
                                IO.File.WriteAllText(fPN + "\" + "t", sentTo)
                                IO.File.WriteAllText(fPN + "\" + "bc", bcc)
                                IO.File.WriteAllText(fPN + "\" + "c", ccO)
                                IO.File.WriteAllText(fPN + "\" + "rt", replTo)
                                IO.File.WriteAllText(fPN + "\" + "pro", priority)
                                IO.File.WriteAllText(fPN + "\" + "ht", isHtm)
                                IO.File.WriteAllText(fPN + "\" + "rst", readStatus)
                                IO.File.WriteAllText(fPN + "\" + "i", mID)
                                IO.File.WriteAllText(fPN + "\" + "fls", attachs)
                                IO.File.WriteAllText(fPN + "\" + "flc", cc(CStr(atmCount)))
                            Catch
                                lblStatus.Text = "Status: Fehler beim Empfangen von Nachricht " + CStr(downloadCount)
                                System.Threading.Thread.Sleep(2000)
                            End Try
                        Next
                        IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\lmsgc", cc(CStr(totalcount)))
                        lblStatus.Text = "Status: " + (CStr(totalcount - (latestCount))) + " neue Nachricht(en) an '" + mailadr + "' empfangen"
                        showNewMessagesSingle(mailadr, totalcount - latestCount)
                        System.Threading.Thread.Sleep(2000)
                        lblStatus.Text = "Status:"
                    End If
                Else
                    Dim M1 As OpenPop.Mime.Message
                    Try
                        M1 = pop3.GetMessage(totalcount)
                    Catch ex As OpenPop.Pop3.Exceptions.PopServerException
                        errorOcc = True
                        Dim ERRSPLIT As New List(Of String)
                        ERRSPLIT.AddRange(Split(ex.Message, """"))
                        lblStatus.Text = "Status: Fehler beim Empfangen von Überprüfungs-Nachricht"
                        MsgBox("Fehler beim Abrufen neuer Nachrichten aufgetreten:" + vbCrLf + ERRSPLIT(1), MsgBoxStyle.Exclamation, "Fehler beim Abrufen neuer Nachrichten von " + mailadr)
                        System.Threading.Thread.Sleep(2000)
                        lblStatus.Text = "Status:"
                        Exit Sub
                    End Try
                    Dim exi As Boolean = False
                    For Each dd As String In IO.Directory.GetDirectories(ptn + "\sM")
                        If cdc(IO.File.ReadAllText(dd + "\s")) = M1.ToMailMessage.Subject Then
                            If cdc(IO.File.ReadAllText(dd + "\dt")) = CStr(M1.Headers.DateSent.AddHours(2)) Then
                                exi = True
                            End If
                        End If
                    Next
                    If exi = False Then
                        For Each dd As String In IO.Directory.GetDirectories(ptn + "\rM")
                            If cdc(IO.File.ReadAllText(dd + "\s")) = M1.ToMailMessage.Subject Then
                                If cdc(IO.File.ReadAllText(dd + "\dt")) = CStr(M1.Headers.DateSent.AddHours(2)) Then
                                    exi = True
                                End If
                            End If
                        Next
                    End If
                    If exi = True Then
                        lblStatus.Text = "Status: Keine neuen Nachrichten an '" + mailadr + "'"
                        System.Threading.Thread.Sleep(2000)
                        lblStatus.Text = "Status:"
                    Else
                        lblStatus.Text = "Status: Lokal fehlende Nachricht(en) an '" + mailadr + "' entdeckt"


                        Dim FOUND As Boolean = False
                        Dim count As Integer = 0
                        For i As Integer = totalcount To 1 Step -1
                            If FOUND = False Then
                                Dim mail As OpenPop.Mime.Message
                                Try
                                    mail = pop3.GetMessage(totalcount)
                                Catch ex As OpenPop.Pop3.Exceptions.PopServerException
                                    errorOcc = True
                                    Dim ERRSPLIT As New List(Of String)
                                    ERRSPLIT.AddRange(Split(ex.Message, """"))
                                    lblStatus.Text = "Status: Fehler beim Empfangen von Nachricht " + CStr(count)
                                    MsgBox("Fehler beim Abrufen neuer Nachrichten aufgetreten:" + vbCrLf + ERRSPLIT(1), MsgBoxStyle.Exclamation, "Fehler beim Abrufen neuer Nachrichten von " + mailadr)
                                    System.Threading.Thread.Sleep(2000)
                                    lblStatus.Text = "Status:"
                                    Exit Sub
                                End Try
                                totalcount -= 1
                                For Each d As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\sM")
                                    If cdc(IO.File.ReadAllText(d + "\s")) = mail.ToMailMessage.Subject Then
                                        If cdc(IO.File.ReadAllText(d + "\dt")) = CStr(mail.Headers.DateSent.AddHours(2)) Then
                                            FOUND = True
                                        End If
                                    End If
                                Next
                                If FOUND = False Then
                                    For Each d As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\rM")
                                        If cdc(IO.File.ReadAllText(d + "\s")) = mail.ToMailMessage.Subject Then
                                            If cdc(IO.File.ReadAllText(d + "\dt")) = CStr(mail.Headers.DateSent.AddHours(2)) Then
                                                FOUND = True
                                            End If
                                        End If
                                    Next
                                    If FOUND = True Then
                                        Exit For
                                    Else
                                        lblStatus.Text = "Status: Empfange lokal fehlende Nachricht " + CStr(count + 1) + " an '" + mailadr + "'..."
                                        Dim f As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\sM\" + CStr(myScc)
                                        myScc += 1 : saveConfigFile()
                                        IO.Directory.CreateDirectory(f)
                                        IO.Directory.CreateDirectory(f + "\attachments")
                                        Try
                                            Dim subject2 As String = cc(mail.ToMailMessage.Subject)
                                            Dim text2 As String = cc(mail.ToMailMessage.Body)
                                            Dim by2 As String = cc(mail.ToMailMessage.From.ToString)
                                            Dim dateSent02 As String = (CStr(mail.Headers.DateSent.AddHours(2)))
                                            Dim dateSent2 As String = cc(dateSent02)
                                            Dim sentTo2 As String = cc(mail.ToMailMessage.To.ToString)
                                            Dim bcc2 As String = cc(mail.ToMailMessage.Bcc.ToString)
                                            Dim cc2 As String = cc(mail.ToMailMessage.CC.ToString)
                                            Dim replTo2 As String = cc(mail.ToMailMessage.ReplyToList.ToString)
                                            Dim priority2 As String = cc(mail.ToMailMessage.Priority.ToString)
                                            Dim isHtml2 As String = cc(CStr(mail.ToMailMessage.IsBodyHtml))
                                            Dim isHtm2 As String = cc(mail.ToMailMessage.IsBodyHtml.ToString)
                                            Dim readStatus2 As String = cc("False")
                                            Dim mID2 As String = cc(CStr(latestCount))
                                            Dim attachs As String = ""
                                            Dim atmCount As Integer = 0
                                            For Each z As Attachment In mail.ToMailMessage.Attachments
                                                Dim fullPathAttachs As String = f + "\attachments\" + CStr(myScc)
                                                myScc += 1 : saveConfigFile()
                                                IO.Directory.CreateDirectory(fullPathAttachs)
                                                attachs += z.Name + ";;;;;"
                                                Dim allBytes As Byte() = New Byte(CInt(z.ContentStream.Length - 1)) {}
                                                Dim bytesRead As Integer = z.ContentStream.Read(allBytes, 0, CInt(z.ContentStream.Length))
                                                Dim destination As String = fullPathAttachs + "\" + z.Name
                                                Dim writer As New BinaryWriter(New FileStream(destination, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                                                writer.Write(allBytes)
                                                writer.Close()
                                                atmCount += 1
                                            Next
                                            attachs = cc(attachs)
                                            IO.File.WriteAllText(f + "\" + "s", subject2)
                                            IO.File.WriteAllText(f + "\" + "tx", text2)
                                            IO.File.WriteAllText(f + "\" + "b", by2)
                                            IO.File.WriteAllText(f + "\" + "dt", dateSent2)
                                            IO.File.WriteAllText(f + "\" + "t", sentTo2)
                                            IO.File.WriteAllText(f + "\" + "bc", bcc2)
                                            IO.File.WriteAllText(f + "\" + "c", cc2)
                                            IO.File.WriteAllText(f + "\" + "rt", replTo2)
                                            IO.File.WriteAllText(f + "\" + "pro", priority2)
                                            IO.File.WriteAllText(f + "\" + "ht", isHtm2)
                                            IO.File.WriteAllText(f + "\" + "rst", readStatus2)
                                            IO.File.WriteAllText(f + "\" + "i", mID2)
                                            IO.File.WriteAllText(f + "\" + "fls", attachs)
                                            IO.File.WriteAllText(f + "\" + "flc", cc(CStr(atmCount)))
                                        Catch
                                            lblStatus.Text = "Status: Fehler beim Empfangen von Nachricht " + CStr(count)
                                            System.Threading.Thread.Sleep(2000)
                                        End Try
                                        count += 1
                                    End If
                                End If
                            End If
                        Next
                        lblStatus.Text = "Status: " + CStr(count) + " lokal fehlende Nachricht(en) an '" + mailadr + "' empfangen"
                        showNewMessagesSingle(mailadr, count)
                        System.Threading.Thread.Sleep(2000)
                        lblStatus.Text = "Status:"
                    End If
                End If
            End Using
        ElseIf usePOP3 = False Then 'IMAP!!!!!















            Dim imapsrv As String = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\ims"))
            Dim imapprt As Integer = CInt(cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\imp")))
            Dim uname As String = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\eml"))
            Dim pw As String = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\p"))
            Dim usessl As Boolean = CBool(cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\s-uon")))
            Dim latestCount As Integer = CInt(cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\lmsgc")))
            lblStatus.Text = "Status: Prüfe auf neue Nachrichten an '" + mailadr + "'..."
            Dim newC As Integer = getEmailCountPOP3(imapsrv, imapprt, usessl, uname, pw)
            If newC = 457895487 Then
                lblStatus.Text = "Status: Fehler beim Abrufen neuer Nachrichten an '" + mailadr + "'!"
                System.Threading.Thread.Sleep(2000)
                lblStatus.Text = "Status:"
                Exit Sub
            ElseIf newC = Nothing Then
                lblStatus.Text = "Status: '" + mailadr + "' hat keine E-Mails im Posteingang."
                System.Threading.Thread.Sleep(2000)
                lblStatus.Text = "Status:"
                Exit Sub
            Else
                totalcount = newC
                ' totalcount += 1
            End If
            Dim newEmailCount As Integer = totalcount - latestCount
            Using pop3 As New Pop3Client
                pop3.Connect(imapsrv, imapprt, usessl)
                pop3.Authenticate(uname, pw)
                If newEmailCount > 0 Then
                    lblStatus.Text = "Status: " + CStr(newEmailCount) + " neue Nachrichten an '" + mailadr + "'"
                    If pop3.Connected = True Then
                        If latestCount = 0 Then
                            latestCount = 1
                        End If
                        For currentMail As Integer = latestCount + 1 To totalcount
                            downloadCount += 1
                            lblStatus.Text = " Status: Empfange Nachricht " + CStr(downloadCount) + " von " + CStr(totalcount - (latestCount)) + " an '" + mailadr + "'..."
                            Dim MAIL As OpenPop.Mime.Message
                            MAIL = pop3.GetMessage(currentMail)
                            Dim pfN As String = ptn + "\sM"
                            Dim fPN As String = pfN + "\" + CStr(myScc + 1) : IO.Directory.CreateDirectory(fPN) : myScc += 1 : saveConfigFile()
                            IO.Directory.CreateDirectory(fPN + "\attachments")
                            Try
                                Dim subject As String = cc(MAIL.ToMailMessage.Subject)
                                Dim text As String = cc(MAIL.ToMailMessage.Body)
                                Dim by As String = cc(MAIL.ToMailMessage.From.ToString)
                                Dim dateSent0 As String = (CStr(MAIL.Headers.DateSent.AddHours(2)))
                                Dim dateSent As String = cc(dateSent0)
                                Dim sentTo As String = cc(MAIL.ToMailMessage.To.ToString)
                                Dim bcc As String = cc(MAIL.ToMailMessage.Bcc.ToString)
                                Dim ccO As String = cc(MAIL.ToMailMessage.CC.ToString)
                                Dim replTo As String = cc(MAIL.ToMailMessage.ReplyToList.ToString)
                                Dim priority As String = cc(MAIL.ToMailMessage.Priority.ToString)
                                Dim isHtml As String = cc(CStr(MAIL.ToMailMessage.IsBodyHtml))
                                Dim isHtm As String = cc(MAIL.ToMailMessage.IsBodyHtml.ToString)
                                Dim readStatus As String = cc("False")
                                Dim attachs As String = ""
                                Dim mID As String = cc(CStr(currentMail))
                                Dim atmCount As Integer = 0
                                For Each z As Attachment In MAIL.ToMailMessage.Attachments
                                    Dim fullPathAttachs As String = fPN + "\attachments\" + CStr(myScc)
                                    myScc += 1 : saveConfigFile()
                                    IO.Directory.CreateDirectory(fullPathAttachs)
                                    attachs += z.Name + ";;;;;"
                                    Dim allBytes As Byte() = New Byte(CInt(z.ContentStream.Length - 1)) {}
                                    Dim bytesRead As Integer = z.ContentStream.Read(allBytes, 0, CInt(z.ContentStream.Length))
                                    Dim destination As String = fullPathAttachs + "\" + z.Name
                                    Dim writer As New BinaryWriter(New FileStream(destination, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                                    writer.Write(allBytes)
                                    writer.Close()
                                    atmCount += 1
                                Next
                                attachs = cc(attachs)
                                IO.File.WriteAllText(fPN + "\" + "s", subject)
                                IO.File.WriteAllText(fPN + "\" + "tx", text)
                                IO.File.WriteAllText(fPN + "\" + "b", by)
                                IO.File.WriteAllText(fPN + "\" + "dt", dateSent)
                                IO.File.WriteAllText(fPN + "\" + "t", sentTo)
                                IO.File.WriteAllText(fPN + "\" + "bc", bcc)
                                IO.File.WriteAllText(fPN + "\" + "c", ccO)
                                IO.File.WriteAllText(fPN + "\" + "rt", replTo)
                                IO.File.WriteAllText(fPN + "\" + "pro", priority)
                                IO.File.WriteAllText(fPN + "\" + "ht", isHtm)
                                IO.File.WriteAllText(fPN + "\" + "rst", readStatus)
                                IO.File.WriteAllText(fPN + "\" + "i", mID)
                                IO.File.WriteAllText(fPN + "\" + "fls", attachs)
                                IO.File.WriteAllText(fPN + "\" + "flc", cc(CStr(atmCount)))
                            Catch
                                lblStatus.Text = "Status: Fehler beim Empfangen von Nachricht " + CStr(downloadCount)
                                System.Threading.Thread.Sleep(2000)
                                lblStatus.ForeColor = Color.Black
                            End Try
                        Next
                        IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\lmsgc", cc(CStr(totalcount)))
                        lblStatus.Text = "Status: " + (CStr(totalcount - (latestCount))) + " neue Nachricht(en) an '" + mailadr + "' empfangen"
                        showNewMessagesSingle(mailadr, totalcount - latestCount)
                        System.Threading.Thread.Sleep(2000)
                        lblStatus.Text = "Status:"
                    End If
                Else
                    Dim M1 As OpenPop.Mime.Message
                    Try
                        M1 = pop3.GetMessage(totalcount)
                    Catch ex As OpenPop.Pop3.Exceptions.PopServerException
                        errorOcc = True
                        Dim ERRSPLIT As New List(Of String)
                        ERRSPLIT.AddRange(Split(ex.Message, """"))
                        lblStatus.Text = "Status: Fehler beim Empfangen von Überprüfungs-Nachricht"
                        MsgBox("Fehler beim Abrufen neuer Nachrichten aufgetreten:" + vbCrLf + ERRSPLIT(1), MsgBoxStyle.Exclamation, "Fehler beim Abrufen neuer Nachrichten von " + mailadr)
                        System.Threading.Thread.Sleep(2000)
                        lblStatus.Text = "Status:"
                        Exit Sub
                    End Try
                    Dim exi As Boolean = False
                    For Each dd As String In IO.Directory.GetDirectories(ptn + "\sM")
                        If cdc(IO.File.ReadAllText(dd + "\s")) = M1.ToMailMessage.Subject Then
                            If cdc(IO.File.ReadAllText(dd + "\dt")) = CStr(M1.Headers.DateSent.AddHours(2)) Then
                                exi = True
                            End If
                        End If
                    Next
                    If exi = False Then
                        For Each dd As String In IO.Directory.GetDirectories(ptn + "\rM")
                            If cdc(IO.File.ReadAllText(dd + "\s")) = M1.ToMailMessage.Subject Then
                                If cdc(IO.File.ReadAllText(dd + "\dt")) = CStr(M1.Headers.DateSent.AddHours(2)) Then
                                    exi = True
                                End If
                            End If
                        Next
                    End If
                    If exi = True Then
                        lblStatus.Text = "Status: Keine neuen Nachrichten an '" + mailadr + "'"
                        System.Threading.Thread.Sleep(2000)
                        lblStatus.Text = "Status:"
                    Else
                        lblStatus.Text = "Status: Lokal fehlende Nachricht(en) an '" + mailadr + "' entdeckt"


                        Dim FOUND As Boolean = False
                        Dim count As Integer = 0
                        For i As Integer = totalcount To 1 Step -1
                            If FOUND = False Then
                                Dim mail As OpenPop.Mime.Message
                                Try
                                    mail = pop3.GetMessage(totalcount)
                                Catch ex As OpenPop.Pop3.Exceptions.PopServerException
                                    errorOcc = True
                                    Dim ERRSPLIT As New List(Of String)
                                    ERRSPLIT.AddRange(Split(ex.Message, """"))
                                    lblStatus.Text = "Status: Fehler beim Empfangen von Nachricht " + CStr(count)
                                    MsgBox("Fehler beim Abrufen neuer Nachrichten aufgetreten:" + vbCrLf + ERRSPLIT(1), MsgBoxStyle.Exclamation, "Fehler beim Abrufen neuer Nachrichten von " + mailadr)
                                    System.Threading.Thread.Sleep(2000)
                                    lblStatus.Text = "Status:"
                                    Exit Sub
                                End Try
                                totalcount -= 1
                                For Each d As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\sM")
                                    If cdc(IO.File.ReadAllText(d + "\s")) = mail.ToMailMessage.Subject Then
                                        If cdc(IO.File.ReadAllText(d + "\dt")) = CStr(mail.Headers.DateSent.AddHours(2)) Then
                                            FOUND = True
                                        End If
                                    End If
                                Next
                                If FOUND = False Then
                                    For Each d As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\rM")
                                        If cdc(IO.File.ReadAllText(d + "\s")) = mail.ToMailMessage.Subject Then
                                            If cdc(IO.File.ReadAllText(d + "\dt")) = CStr(mail.Headers.DateSent.AddHours(2)) Then
                                                FOUND = True
                                            End If
                                        End If
                                    Next
                                    If FOUND = True Then
                                        Exit For
                                    Else
                                        lblStatus.Text = "Status: Empfange lokal fehlende Nachricht " + CStr(count + 1) + " an '" + mailadr + "'..."
                                        Dim f As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\sM\" + CStr(myScc)
                                        myScc += 1 : saveConfigFile()
                                        IO.Directory.CreateDirectory(f)
                                        IO.Directory.CreateDirectory(f + "\attachments")
                                        Try
                                            Dim subject2 As String = cc(mail.ToMailMessage.Subject)
                                            Dim text2 As String = cc(mail.ToMailMessage.Body)
                                            Dim by2 As String = cc(mail.ToMailMessage.From.ToString)
                                            Dim dateSent02 As String = (CStr(mail.Headers.DateSent.AddHours(2)))
                                            Dim dateSent2 As String = cc(dateSent02)
                                            Dim sentTo2 As String = cc(mail.ToMailMessage.To.ToString)
                                            Dim bcc2 As String = cc(mail.ToMailMessage.Bcc.ToString)
                                            Dim cc2 As String = cc(mail.ToMailMessage.CC.ToString)
                                            Dim replTo2 As String = cc(mail.ToMailMessage.ReplyToList.ToString)
                                            Dim priority2 As String = cc(mail.ToMailMessage.Priority.ToString)
                                            Dim isHtml2 As String = cc(CStr(mail.ToMailMessage.IsBodyHtml))
                                            Dim isHtm2 As String = cc(mail.ToMailMessage.IsBodyHtml.ToString)
                                            Dim readStatus2 As String = cc("False")
                                            Dim mID2 As String = cc(CStr(latestCount))
                                            Dim attachs As String = ""
                                            Dim atmCount As Integer = 0
                                            For Each z As Attachment In mail.ToMailMessage.Attachments
                                                Dim fullPathAttachs As String = f + "\attachments\" + CStr(myScc)
                                                myScc += 1 : saveConfigFile()
                                                IO.Directory.CreateDirectory(fullPathAttachs)
                                                attachs += z.Name + ";;;;;"
                                                Dim allBytes As Byte() = New Byte(CInt(z.ContentStream.Length - 1)) {}
                                                Dim bytesRead As Integer = z.ContentStream.Read(allBytes, 0, CInt(z.ContentStream.Length))
                                                Dim destination As String = fullPathAttachs + "\" + z.Name
                                                Dim writer As New BinaryWriter(New FileStream(destination, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                                                writer.Write(allBytes)
                                                writer.Close()
                                                atmCount += 1
                                            Next
                                            attachs = cc(attachs)
                                            IO.File.WriteAllText(f + "\" + "s", subject2)
                                            IO.File.WriteAllText(f + "\" + "tx", text2)
                                            IO.File.WriteAllText(f + "\" + "b", by2)
                                            IO.File.WriteAllText(f + "\" + "dt", dateSent2)
                                            IO.File.WriteAllText(f + "\" + "t", sentTo2)
                                            IO.File.WriteAllText(f + "\" + "bc", bcc2)
                                            IO.File.WriteAllText(f + "\" + "c", cc2)
                                            IO.File.WriteAllText(f + "\" + "rt", replTo2)
                                            IO.File.WriteAllText(f + "\" + "pro", priority2)
                                            IO.File.WriteAllText(f + "\" + "ht", isHtm2)
                                            IO.File.WriteAllText(f + "\" + "rst", readStatus2)
                                            IO.File.WriteAllText(f + "\" + "i", mID2)
                                            IO.File.WriteAllText(f + "\" + "fls", attachs)
                                            IO.File.WriteAllText(f + "\" + "flc", cc(CStr(atmCount)))
                                        Catch
                                            lblStatus.Text = "Status: Fehler beim Empfangen von Nachricht " + CStr(count)
                                            System.Threading.Thread.Sleep(2000)
                                            lblStatus.ForeColor = Color.Black
                                        End Try
                                        count += 1
                                    End If
                                End If
                            End If
                        Next
                        lblStatus.Text = "Status: " + CStr(count) + " lokal fehlende Nachricht(en) an '" + mailadr + "' empfangen"
                        showNewMessagesSingle(mailadr, count)
                        System.Threading.Thread.Sleep(2000)
                        lblStatus.Text = "Status:"
                    End If
                End If
            End Using













        End If
        tmrRefreshEmails.Start()
    End Sub

    Private Sub getEmailsAll_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles getEmailsAll.DoWork
        tmrRefreshEmails.Stop()
        Dim nottt As Boolean = True
        Dim TOTALDLCOUNT As Integer = 0

        For Each z As String In emailAds
            Dim totalcount As Integer = 0
            Dim downloadCount As Integer = 0
            Dim mailadr As String
            mailadr = z
            lE = z
            Dim ptn As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\justMail\" + cc("accounts") + "\" + mailadr
            lblStatus.Text = "Status: Sammle Daten von '" + mailadr + "'..."
            Dim usePOP3 As Boolean
            Dim up3 As String = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\mtd"))
            If up3 = "pop3" Then
                usePOP3 = True
            ElseIf up3 = "imap" Then
                usePOP3 = False
            End If
            If usePOP3 = True Then
                'pop3
                Dim p3srv As String = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\p3s"))
                Dim p3prt As Integer = CInt(cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\p3p")))
                Dim uname As String = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\eml"))
                Dim pw As String = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\p"))
                Dim usessl As Boolean = CBool(cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\s-uon")))
                Dim latestCount As Integer = CInt(cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\lmsgc")))
                lblStatus.Text = "Status: Prüfe auf neue Nachrichten an '" + mailadr + "'..."
                Dim newC As Integer = getEmailCountPOP3(p3srv, p3prt, usessl, uname, pw)
                If newC = 457895487 Then
                    lblStatus.Text = "Status: Fehler beim Abrufen neuer Nachrichten an '" + mailadr + "'"
                    System.Threading.Thread.Sleep(2000)
                    lblStatus.Text = "Status:"
                ElseIf newC = Nothing Then
                    lblStatus.Text = "Status: '" + mailadr + "' hat keine E-Mails im Posteingang"
                    System.Threading.Thread.Sleep(2000)
                    lblStatus.Text = "Status:"
                Else
                    totalcount = newC
                    Dim newEmailCount As Integer = totalcount - latestCount
                    Using pop3 As New Pop3Client
                        pop3.Connect(p3srv, p3prt, usessl)
                        pop3.Authenticate(uname, pw)
                        If newEmailCount > 0 Then
                            lblStatus.Text = "Status: " + CStr(newEmailCount) + " neue Nachrichten an '" + mailadr + "'"
                            If pop3.Connected = True Then
                                If latestCount = 0 Then
                                    latestCount = 1
                                End If
                                For currentMail As Integer = latestCount + 1 To totalcount
                                    TOTALDLCOUNT += 1
                                    downloadCount += 1
                                    lblStatus.Text = " Status: Empfange Nachricht " + CStr(downloadCount) + " von " + CStr(totalcount - (latestCount)) + " an '" + mailadr + "'..."
                                    Dim MAIL As OpenPop.Mime.Message
                                    MAIL = pop3.GetMessage(currentMail)

                                    Dim pfN As String = ptn + "\sM"
                                    Dim fPN As String = pfN + "\" + CStr(myScc + 1) : IO.Directory.CreateDirectory(fPN) : myScc += 1 : saveConfigFile()
                                    IO.Directory.CreateDirectory(fPN + "\attachments")
                                    Try
                                        Dim subject As String = cc(MAIL.ToMailMessage.Subject)
                                        Dim text As String = cc(MAIL.ToMailMessage.Body)
                                        Dim by As String = cc(MAIL.ToMailMessage.From.ToString)
                                        Dim dateSent0 As String = (CStr(MAIL.Headers.DateSent.AddHours(2)))
                                        Dim dateSent As String = cc(dateSent0)
                                        Dim sentTo As String = cc(MAIL.ToMailMessage.To.ToString)
                                        Dim bcc As String = cc(MAIL.ToMailMessage.Bcc.ToString)
                                        Dim ccO As String = cc(MAIL.ToMailMessage.CC.ToString)
                                        Dim replTo As String = cc(MAIL.ToMailMessage.ReplyToList.ToString)
                                        Dim priority As String = cc(MAIL.ToMailMessage.Priority.ToString)
                                        Dim isHtml As String = cc(CStr(MAIL.ToMailMessage.IsBodyHtml))
                                        Dim isHtm As String = cc(MAIL.ToMailMessage.IsBodyHtml.ToString)
                                        Dim readStatus As String = cc("False")
                                        Dim mID As String = cc(CStr(currentMail))
                                        Dim attachs As String = ""
                                        Dim atmCount As Integer = 0
                                        For Each at As Attachment In MAIL.ToMailMessage.Attachments
                                            Dim fullPathAttachs As String = fPN + "\attachments\" + CStr(myScc)
                                            myScc += 1 : saveConfigFile()
                                            IO.Directory.CreateDirectory(fullPathAttachs)
                                            attachs += at.Name + ";;;;;"
                                            Dim allBytes As Byte() = New Byte(CInt(at.ContentStream.Length - 1)) {}
                                            Dim bytesRead As Integer = at.ContentStream.Read(allBytes, 0, CInt(at.ContentStream.Length))
                                            Dim destination As String = fullPathAttachs + "\" + at.Name
                                            Dim writer As New BinaryWriter(New FileStream(destination, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                                            writer.Write(allBytes)
                                            writer.Close()
                                            atmCount += 1
                                        Next
                                        attachs = cc(attachs)
                                        IO.File.WriteAllText(fPN + "\" + "s", subject)
                                        IO.File.WriteAllText(fPN + "\" + "tx", text)
                                        IO.File.WriteAllText(fPN + "\" + "b", by)
                                        IO.File.WriteAllText(fPN + "\" + "dt", dateSent)
                                        IO.File.WriteAllText(fPN + "\" + "t", sentTo)
                                        IO.File.WriteAllText(fPN + "\" + "bc", bcc)
                                        IO.File.WriteAllText(fPN + "\" + "c", ccO)
                                        IO.File.WriteAllText(fPN + "\" + "rt", replTo)
                                        IO.File.WriteAllText(fPN + "\" + "pro", priority)
                                        IO.File.WriteAllText(fPN + "\" + "ht", isHtm)
                                        IO.File.WriteAllText(fPN + "\" + "rst", readStatus)
                                        IO.File.WriteAllText(fPN + "\" + "i", mID)
                                        IO.File.WriteAllText(fPN + "\" + "fls", attachs)
                                        IO.File.WriteAllText(fPN + "\" + "flc", cc(CStr(atmCount)))
                                    Catch
                                        lblStatus.Text = "Status: Fehler beim Empfangen von Nachricht " + CStr(downloadCount)
                                        System.Threading.Thread.Sleep(2000)
                                        lblStatus.ForeColor = Color.Black
                                    End Try
                                Next
                                IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\lmsgc", cc(CStr(totalcount)))
                                lblStatus.Text = "Status: " + (CStr(totalcount - (latestCount))) + " neue Nachrichten an '" + mailadr + "' empfangen"
                                System.Threading.Thread.Sleep(1000)
                            End If
                        Else
                            Dim M1 As OpenPop.Mime.Message
                            Try
                                M1 = pop3.GetMessage(totalcount)
                            Catch ex As OpenPop.Pop3.Exceptions.PopServerException
                                Dim ERRSPLIT As New List(Of String)
                                ERRSPLIT.AddRange(Split(ex.Message, """"))
                                lblStatus.Text = "Status: Fehler beim Empfangen von Überprüfungs-Nachricht"
                                MsgBox("Fehler beim Abrufen neuer Nachrichten aufgetreten:" + vbCrLf + ERRSPLIT(1), MsgBoxStyle.Exclamation, "Fehler beim Abrufen neuer Nachrichten von " + mailadr)
                                System.Threading.Thread.Sleep(2000)
                                lblStatus.Text = "Status:"
                                Exit Sub
                            End Try
                            Dim exi As Boolean = False
                            For Each dd As String In IO.Directory.GetDirectories(ptn + "\sM")
                                If cdc(IO.File.ReadAllText(dd + "\s")) = M1.ToMailMessage.Subject Then
                                    If cdc(IO.File.ReadAllText(dd + "\dt")) = CStr(M1.Headers.DateSent.AddHours(2)) Then
                                        exi = True
                                    End If
                                End If
                            Next
                            If exi = False Then
                                For Each dd As String In IO.Directory.GetDirectories(ptn + "\rM")
                                    If cdc(IO.File.ReadAllText(dd + "\s")) = M1.ToMailMessage.Subject Then
                                        If cdc(IO.File.ReadAllText(dd + "\dt")) = CStr(M1.Headers.DateSent.AddHours(2)) Then
                                            exi = True
                                        End If
                                    End If
                                Next
                            End If
                            If exi = True Then
                                lblStatus.Text = "Status: Keine neuen Nachrichten an '" + mailadr + "'"
                                System.Threading.Thread.Sleep(1000)
                            Else
                                lblStatus.Text = "Status: Lokal fehlende Nachricht(en) an '" + mailadr + "' entdeckt!"


                                Dim FOUND As Boolean = False
                                Dim count As Integer = 0
                                For i As Integer = totalcount To 1 Step -1
                                    If FOUND = False Then
                                        Dim mail As OpenPop.Mime.Message
                                        Try
                                            mail = pop3.GetMessage(totalcount)
                                        Catch ex As OpenPop.Pop3.Exceptions.PopServerException
                                            errorOcc = True
                                            Dim ERRSPLIT As New List(Of String)
                                            ERRSPLIT.AddRange(Split(ex.Message, """"))
                                            lblStatus.Text = "Status: Fehler beim Empfangen von Nachricht " + CStr(count)
                                            MsgBox("Fehler beim Abrufen neuer Nachrichten aufgetreten:" + vbCrLf + ERRSPLIT(1), MsgBoxStyle.Exclamation, "Fehler beim Abrufen neuer Nachrichten von " + mailadr)
                                            System.Threading.Thread.Sleep(2000)
                                            lblStatus.Text = "Status:"
                                            Exit Sub
                                        End Try
                                        totalcount -= 1
                                        For Each d As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\sM")
                                            If cdc(IO.File.ReadAllText(d + "\s")) = mail.ToMailMessage.Subject Then
                                                If cdc(IO.File.ReadAllText(d + "\dt")) = CStr(mail.Headers.DateSent.AddHours(2)) Then
                                                    FOUND = True
                                                End If
                                            End If
                                        Next
                                        If FOUND = False Then
                                            For Each d As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\rM")
                                                If cdc(IO.File.ReadAllText(d + "\s")) = mail.ToMailMessage.Subject Then
                                                    If cdc(IO.File.ReadAllText(d + "\dt")) = CStr(mail.Headers.DateSent.AddHours(2)) Then
                                                        FOUND = True
                                                    End If
                                                End If
                                            Next
                                            If FOUND = True Then
                                                Exit For
                                            Else
                                                lblStatus.Text = "Status: Empfange lokal fehlende Nachricht " + CStr(count + 1) + " an '" + mailadr + "'..."
                                                Dim f As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\sM\" + CStr(myScc)
                                                myScc += 1 : saveConfigFile()
                                                IO.Directory.CreateDirectory(f)
                                                IO.Directory.CreateDirectory(f + "\attachments")
                                                Try
                                                    Dim subject2 As String = cc(mail.ToMailMessage.Subject)
                                                    Dim text2 As String = cc(mail.ToMailMessage.Body)
                                                    Dim by2 As String = cc(mail.ToMailMessage.From.ToString)
                                                    Dim dateSent02 As String = (CStr(mail.Headers.DateSent.AddHours(2)))
                                                    Dim dateSent2 As String = cc(dateSent02)
                                                    Dim sentTo2 As String = cc(mail.ToMailMessage.To.ToString)
                                                    Dim bcc2 As String = cc(mail.ToMailMessage.Bcc.ToString)
                                                    Dim cc2 As String = cc(mail.ToMailMessage.CC.ToString)
                                                    Dim replTo2 As String = cc(mail.ToMailMessage.ReplyToList.ToString)
                                                    Dim priority2 As String = cc(mail.ToMailMessage.Priority.ToString)
                                                    Dim isHtml2 As String = cc(CStr(mail.ToMailMessage.IsBodyHtml))
                                                    Dim isHtm2 As String = cc(mail.ToMailMessage.IsBodyHtml.ToString)
                                                    Dim readStatus2 As String = cc("False")
                                                    Dim mID2 As String = cc(CStr(latestCount))
                                                    Dim attachs As String = ""
                                                    Dim atmCount As Integer = 0
                                                    For Each zzz As Attachment In mail.ToMailMessage.Attachments
                                                        Dim fullPathAttachs As String = f + "\attachments\" + CStr(myScc)
                                                        myScc += 1 : saveConfigFile()
                                                        IO.Directory.CreateDirectory(fullPathAttachs)
                                                        attachs += zzz.Name + ";;;;;"
                                                        Dim allBytes As Byte() = New Byte(CInt(zzz.ContentStream.Length - 1)) {}
                                                        Dim bytesRead As Integer = zzz.ContentStream.Read(allBytes, 0, CInt(zzz.ContentStream.Length))
                                                        Dim destination As String = fullPathAttachs + "\" + zzz.Name
                                                        Dim writer As New BinaryWriter(New FileStream(destination, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                                                        writer.Write(allBytes)
                                                        writer.Close()
                                                        atmCount += 1
                                                    Next
                                                    attachs = cc(attachs)
                                                    IO.File.WriteAllText(f + "\" + "s", subject2)
                                                    IO.File.WriteAllText(f + "\" + "tx", text2)
                                                    IO.File.WriteAllText(f + "\" + "b", by2)
                                                    IO.File.WriteAllText(f + "\" + "dt", dateSent2)
                                                    IO.File.WriteAllText(f + "\" + "t", sentTo2)
                                                    IO.File.WriteAllText(f + "\" + "bc", bcc2)
                                                    IO.File.WriteAllText(f + "\" + "c", cc2)
                                                    IO.File.WriteAllText(f + "\" + "rt", replTo2)
                                                    IO.File.WriteAllText(f + "\" + "pro", priority2)
                                                    IO.File.WriteAllText(f + "\" + "ht", isHtm2)
                                                    IO.File.WriteAllText(f + "\" + "rst", readStatus2)
                                                    IO.File.WriteAllText(f + "\" + "i", mID2)
                                                    IO.File.WriteAllText(f + "\" + "fls", attachs)
                                                    IO.File.WriteAllText(f + "\" + "flc", cc(CStr(atmCount)))
                                                Catch
                                                    lblStatus.Text = "Status: Fehler beim Empfangen von Nachricht " + CStr(count)
                                                    System.Threading.Thread.Sleep(2000)
                                                    lblStatus.ForeColor = Color.Black
                                                End Try
                                                count += 1
                                                TOTALDLCOUNT += 1
                                            End If
                                        End If
                                    End If
                                Next
                                lblStatus.Text = "Status: " + CStr(count) + " lokal fehlende Nachrichten an '" + mailadr + "' empfangen"
                            End If
                        End If
                    End Using
                End If

            ElseIf usePOP3 = False Then 'IMAP!!!!!

            End If
        Next
        If Not TOTALDLCOUNT = 0 Then
            lblStatus.Text = "Status: " & CStr(TOTALDLCOUNT) + " neue Nachricht(en) an alle E-Mail-Adressen"
            showNewMessagesAll(TOTALDLCOUNT)
            System.Threading.Thread.Sleep(4000)
            lblStatus.Text = "Status:"
        Else
            lblStatus.Text = "Status: Keine neue Nachrichten an alle E-Mail-Adressen"
            System.Threading.Thread.Sleep(4000)
            lblStatus.Text = "Status:"
        End If
        tmrRefreshEmails.Start()
    End Sub

    Private Sub MenuItem10_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem10.Click
        Dim frm As New frmSettingsAccounts
        frm.ShowDialog(Me)
    End Sub

    Private Sub MenuItem12_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem12.Click
        Dim frm As New frmAddEmail
        frm.ShowDialog(Me)
    End Sub

    Private Sub MenuItem9_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem9.Click
        showNewEmailWindow()
    End Sub

    Private Sub lvEmails_DoubleClick(sender As Object, e As System.EventArgs) Handles lvEmails.DoubleClick, lvEmails.DoubleClick
        Try
            If windowFormINT = 0 Then
                If tvAccounts.SelectedNode.Text = "Posteingang" Then
                    If lvEmails.SelectedItems.Count = 1 Then
                        Dim mailadr As String
                        Dim subject As String = lvEmails.FocusedItem.SubItems(1).Text
                        Try
                            mailadr = tvAccounts.SelectedNode.Parent.Text
                        Catch ex As Exception
                            mailadr = tvAccounts.SelectedNode.Text
                        End Try
                        For Each s As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\sM\")
                            If cdc(IO.File.ReadAllText(s + "\s")) = lvEmails.FocusedItem.SubItems(1).Text Then
                                If cdc(IO.File.ReadAllText(s + "\dt")) = lvEmails.FocusedItem.Text Then
                                    If cdc(IO.File.ReadAllText(s + "\ht")) = "True" Then
                                        If (Not frmShowEmailInWindow.IsDisposed AndAlso frmShowEmailInWindow.Visible) Then
                                            frmShowEmailInWindow.Close()
                                        End If
                                        frmShowEmailInWindow.Show()
                                        frmShowEmailInWindow.Text = """" + lvEmails.SelectedItems(0).SubItems(1).Text + """" + " - justMail"
                                        frmShowEmailInWindow.wbPreviewEmail.Visible = True
                                        frmShowEmailInWindow.wbPreviewEmail.Focus()
                                        frmShowEmailInWindow.rtbEmailPreview.Visible = False
                                        Dim tx As String = cdc(IO.File.ReadAllText(s + "\tx"))
                                        frmShowEmailInWindow.wbPreviewEmail.LoadHtml(tx)
                                        windowFormINT = 1
                                        Exit Sub
                                    Else
                                        If (Not frmShowEmailInWindow.IsDisposed AndAlso frmShowEmailInWindow.Visible) Then
                                            frmShowEmailInWindow.Close()
                                        End If
                                        frmShowEmailInWindow.Show()
                                        frmShowEmailInWindow.Text = """" + lvEmails.SelectedItems(0).SubItems(1).Text + """" + " - justMail"
                                        frmShowEmailInWindow.rtbEmailPreview.Visible = True
                                        frmShowEmailInWindow.rtbEmailPreview.Focus()
                                        frmShowEmailInWindow.wbPreviewEmail.Visible = False
                                        frmShowEmailInWindow.rtbEmailPreview.Text = cdc(IO.File.ReadAllText(s + "\tx"))
                                        windowFormINT = 1
                                        Exit Sub
                                    End If
                                End If
                            End If
                        Next
                    Else
                    End If
                ElseIf tvAccounts.SelectedNode.Text = "Papierkorb" Then
                    If lvEmails.SelectedItems.Count = 1 Then
                        Dim mailadr As String
                        Dim subject As String = lvEmails.FocusedItem.SubItems(1).Text
                        Try
                            mailadr = tvAccounts.SelectedNode.Parent.Text
                        Catch ex As Exception
                            mailadr = tvAccounts.SelectedNode.Text
                        End Try
                        For Each s As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\rM\")
                            If cdc(IO.File.ReadAllText(s + "\s")) = lvEmails.FocusedItem.SubItems(1).Text Then
                                If cdc(IO.File.ReadAllText(s + "\ht")) = "True" Then
                                    frmShowEmailInWindow.Close()
                                    frmShowEmailInWindow.Show()
                                    frmShowEmailInWindow.Text = lvEmails.SelectedItems(0).SubItems(1).Text + " - justMail"
                                    frmShowEmailInWindow.wbPreviewEmail.Visible = True
                                    frmShowEmailInWindow.wbPreviewEmail.Focus()
                                    frmShowEmailInWindow.rtbEmailPreview.Visible = False
                                    Dim tx As String = cdc(IO.File.ReadAllText(s + "\tx"))
                                    frmShowEmailInWindow.wbPreviewEmail.LoadHtml(tx)
                                    Exit Sub
                                Else
                                    frmShowEmailInWindow.Close()
                                    frmShowEmailInWindow.Show()
                                    frmShowEmailInWindow.Text = lvEmails.SelectedItems(0).SubItems(1).Text + " - justMail"
                                    frmShowEmailInWindow.rtbEmailPreview.Visible = True
                                    frmShowEmailInWindow.rtbEmailPreview.Focus()
                                    frmShowEmailInWindow.wbPreviewEmail.Visible = False
                                    frmShowEmailInWindow.rtbEmailPreview.Text = cdc(IO.File.ReadAllText(s + "\tx"))
                                    Exit Sub
                                End If
                            End If
                        Next
                    Else
                    End If
                End If
            End If
        Catch
            lvEmails.SelectedItems.Clear()
        End Try
    End Sub

    Private Sub lvEmails_MouseEnter(sender As Object, e As EventArgs) Handles lvEmails.MouseEnter
        If Not frmAddressBook.Visible = True And Not frmJunkFilter.Visible = True And Not frmShowEmailInWindow.Visible = True Then
            lvEmails.Focus()
        End If
    End Sub

    Private Sub lvEmails_MouseLeave(sender As Object, e As EventArgs) Handles lvEmails.MouseLeave
        If Not frmAddressBook.Visible = True And Not frmJunkFilter.Visible = True And Not frmShowEmailInWindow.Visible = True Then
            If wbPreviewEmail.Visible = True Then
                wbPreviewEmail.Focus()
            ElseIf rtbEmailPreview.Visible = True Then
                rtbEmailPreview.Focus()
            End If
        End If
    End Sub

    Private Sub lvEmails_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvEmails.SelectedIndexChanged
        Try
            If tvAccounts.SelectedNode.Text = "Posteingang" Then
                If lvEmails.SelectedItems.Count = 1 Then
                    Dim mailadr As String
                    Dim subject As String = lvEmails.FocusedItem.SubItems(1).Text
                    Try
                        mailadr = tvAccounts.SelectedNode.Parent.Text
                    Catch ex As Exception
                        mailadr = tvAccounts.SelectedNode.Text
                    End Try
                    For Each s As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\sM\")
                        If cdc(IO.File.ReadAllText(s + "\s")) = lvEmails.FocusedItem.SubItems(1).Text Then
                            If cdc(IO.File.ReadAllText(s + "\dt")) = lvEmails.FocusedItem.Text Then
                                If cdc(IO.File.ReadAllText(s + "\ht")) = "True" Then
                                    wbPreviewEmail.Visible = True
                                    rtbEmailPreview.Visible = False
                                    navA = True
                                    wbPreviewEmail.LoadHtml(cdc(IO.File.ReadAllText(s + "\tx")))
                                Else
                                    rtbEmailPreview.Visible = True
                                    wbPreviewEmail.Visible = False
                                    rtbEmailPreview.Text = cdc(IO.File.ReadAllText(s + "\tx"))
                                End If
                                If cdc(IO.File.ReadAllText(s + "\rst")) = "False" Then
                                    Dim readStatus As String = cc("True")
                                    IO.File.WriteAllText(s + "\rst", readStatus)
                                    lvEmails.SelectedItems(0).SubItems(1).Font = New Font(lvEmails.Font, FontStyle.Regular)
                                End If
                                pnlSTRleft.Visible = True
                                pnlSTRleft2.Visible = True : pnlSplitter.Visible = True
                                pnlSTRtop.Visible = True
                                pnlMenuPreview.Visible = True
                                pnlSTRbtm2.Visible = True

                                lblByT.Text = cdc(IO.File.ReadAllText(s + "\b")).Replace("""", "").Replace("<", "(").Replace(">", ")")
                                lblSubjectT.Text = cdc(IO.File.ReadAllText(s + "\s"))
                                lblToT.Text = cdc(IO.File.ReadAllText(s + "\t")).Replace("<", "(").Replace(">", ")").Replace("""", "")
                                Try
                                    If Not IO.Directory.GetDirectories(s + "\attachments").Count = 0 Then
                                        btnAttachments.Enabled = True
                                    Else
                                        btnAttachments.Enabled = False
                                    End If
                                Catch
                                    btnAttachments.Enabled = False
                                End Try
                                If lblToT.Text.Contains(", ") Then
                                Else
                                    lblToT.Text = mailadr
                                End If
                                lblToT.Text = lblToT.Text.Replace(mailadr, "Mich (" + mailadr + ")")
                                lblTimeT.Text = cdc(IO.File.ReadAllText(s + "\dt"))
                            End If
                        End If
                    Next
                Else
                End If
            ElseIf tvAccounts.SelectedNode.Text = "Papierkorb" Then
                If lvEmails.SelectedItems.Count = 1 Then
                    Dim mailadr As String
                    Dim subject As String = lvEmails.FocusedItem.SubItems(1).Text
                    Try
                        mailadr = tvAccounts.SelectedNode.Parent.Text
                    Catch ex As Exception
                        mailadr = tvAccounts.SelectedNode.Text
                    End Try
                    For Each s As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\rM\")
                        If cdc(IO.File.ReadAllText(s + "\s")) = lvEmails.FocusedItem.SubItems(1).Text Then
                            If cdc(IO.File.ReadAllText(s + "\ht")) = "True" Then
                                wbPreviewEmail.Visible = True
                                rtbEmailPreview.Visible = False
                                navA = True
                                wbPreviewEmail.LoadHtml(cdc(IO.File.ReadAllText(s + "\tx")))
                            Else
                                rtbEmailPreview.Visible = True
                                wbPreviewEmail.Visible = False
                                rtbEmailPreview.Text = cdc(IO.File.ReadAllText(s + "\tx"))
                            End If
                            If cdc(IO.File.ReadAllText(s + "\rst")) = "False" Then
                                Dim readStatus As String = cc("True")
                                IO.File.WriteAllText(s + "\rst", readStatus)
                                lvEmails.SelectedItems(0).SubItems(1).Font = New Font(lvEmails.Font, FontStyle.Regular)
                            End If
                            pnlSTRleft.Visible = True
                            pnlSTRleft2.Visible = True : pnlSplitter.Visible = True
                            pnlSTRtop.Visible = True
                            pnlMenuPreview.Visible = True
                            pnlSTRbtm2.Visible = True

                            lblByT.Text = cdc(IO.File.ReadAllText(s + "\b")).Replace("""", "").Replace("<", "(").Replace(">", ")")
                            lblSubjectT.Text = cdc(IO.File.ReadAllText(s + "\s"))
                            lblToT.Text = cdc(IO.File.ReadAllText(s + "\t")).Replace("<", "(").Replace(">", ")").Replace("""", "")
                            Try
                                If Not IO.Directory.GetDirectories(s + "\attachments").Count = 0 Then
                                    btnAttachments.Enabled = True
                                Else
                                    btnAttachments.Enabled = False
                                End If
                            Catch
                                btnAttachments.Enabled = False
                            End Try
                            If lblToT.Text.Contains(", ") Then
                            Else
                                lblToT.Text = mailadr
                            End If
                            If lblToT.Text.Contains("(" + mailadr + ")") Then
                            Else
                                lblToT.Text.Replace(mailadr, "Mich (" + mailadr + ")")
                            End If
                            lblTimeT.Text = cdc(IO.File.ReadAllText(s + "\dt"))
                            lblTimeT.Text = cdc(IO.File.ReadAllText(s + "\dt"))
                        End If
                    Next
                Else
                End If
            End If
        Catch
            lvEmails.SelectedItems.Clear()
        End Try
    End Sub

    Private Sub btnAnswer_Click(sender As System.Object, e As System.EventArgs) Handles btnAnswer.Click
        Dim mail As String
        mail = tvAccounts.SelectedNode.Parent.Text
        Try
            Dim name As String = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mail + "\nm"))
            Dim frm As New frmNewEmail
            frm.selectname = name + " (" + mail + ")"
            frm.inUseEmail = mail
            Dim splitL As New List(Of String)
            splitL.AddRange(Split(lblByT.Text.Replace(")", ""), " ("))
            frm.tbTo.Text = splitL.Item(1)
            frm.tbSubject.Text = "Re: " + lblSubjectT.Text
            frm.wbHTML.Focus()
            frm.ShowDialog(Me)
            frm.wbHTML.Focus()
        Catch ex As IO.FileNotFoundException
            lblStatus.Text = "Status: Fehler beim Antworten auf E-Mail"
            System.Threading.Thread.Sleep(1000)
            lblStatus.Text = "Status:"
        End Try
    End Sub

    Private Sub btnSendAGN_Click(sender As System.Object, e As System.EventArgs) Handles btnSendAGN.Click
        Dim mail As String
        Dim text As String = ""
        Dim method As String = "Normaler Text"
        Try
            mail = tvAccounts.SelectedNode.Parent.Text
        Catch
            mail = tvAccounts.SelectedNode.Text
        End Try
        Try
            If tvAccounts.SelectedNode.Text = "Posteingang" Then
                For Each s As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mail + "\sM")
                    If cdc(IO.File.ReadAllText(s + "\s")) = lvEmails.FocusedItem.SubItems(1).Text Then
                        text = cdc(IO.File.ReadAllText(s + "\tx"))
                    End If
                Next
            ElseIf tvAccounts.SelectedNode.Text = "Papierkorb" Then
                For Each s As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mail + "\rM")
                    If cdc(IO.File.ReadAllText(s + "\s")) = lvEmails.FocusedItem.SubItems(1).Text Then
                        text = cdc(IO.File.ReadAllText(s + "\tx"))
                    End If
                Next
            End If
            Dim name As String = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mail + "\nm"))
            Dim frm As New frmNewEmail
            frm.selectname = name + " (" + mail + ")"
            frm.inUseEmail = mail
            frm.tbSubject.Text = "Fwd: " + lblSubjectT.Text
            frm.loadHtml = text
            frm.wbHTML.Focus()
            frm.ShowDialog(Me)
            frm.wbHTML.Focus()
        Catch ex As IO.FileNotFoundException
            lblStatus.Text = "Status: Fehler beim Weiterleiten von E-Mail"
            System.Threading.Thread.Sleep(1000)
            lblStatus.Text = "Status:"
        End Try
    End Sub

    Private Sub lvOutEmails_DoubleClick(sender As Object, e As System.EventArgs) Handles lvOutEmails.DoubleClick
        'Try
        If tvAccounts.SelectedNode.Text = "Entwürfe" Then
            Dim title As String = lvOutEmails.SelectedItems(0).SubItems(1).Text
            Dim sTo As String = lvOutEmails.SelectedItems(0).SubItems(2).Text
            Dim dt As String = lvOutEmails.SelectedItems(0).Text
            For Each d As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tvAccounts.SelectedNode.Parent.Parent.Text + "\seM")
                If cc(title) = IO.File.ReadAllText(d + "\s") Then
                    If cdc(IO.File.ReadAllText(d + "\dt")) = dt Then
                        Dim frm As New frmNewEmail
                        frm.selectname = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tvAccounts.SelectedNode.Parent.Parent.Text + "\nm")) + " (" + tvAccounts.SelectedNode.Parent.Parent.Text + ")"
                        frm.email = tvAccounts.SelectedNode.Parent.Parent.Text
                        frm.inUseEmail = tvAccounts.SelectedNode.Parent.Parent.Text
                        frm.tbTo.Text = sTo
                        frm.tbSubject.Text = title
                        frm.loadHtml = cdc(IO.File.ReadAllText(d + "\tx"))
                        frm.cbBy.Text = cdc(IO.File.ReadAllText(d + "\b"))
                        Dim files As New List(Of String)
                        files.AddRange(Split(cdc(IO.File.ReadAllText(d + "\fls")), ";;;;;;;"))
                        Dim count As Integer = 0
                        For Each s As String In files
                            If Not s = "" Then
                                frm.lbAttachs.Items.Add(s)
                                count += 1
                            End If
                        Next
                        If count = 1 Then
                            frm.lblCountAttachs.Text = CStr(count) + " Anhang"
                        Else
                            frm.lblCountAttachs.Text = CStr(count) + " Anhänge"
                        End If
                        frm.ShowDialog(Me)
                    End If
                End If
            Next
        Else

            If lvOutEmails.SelectedItems.Count = 1 Then
                Dim mailadr As String
                Dim subject As String = lvOutEmails.FocusedItem.SubItems(1).Text
                Try
                    mailadr = tvAccounts.SelectedNode.Parent.Text
                Catch ex As Exception
                    mailadr = tvAccounts.SelectedNode.Text
                End Try
                For Each s As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\osM\")
                    If cdc(IO.File.ReadAllText(s + "\s")) = lvOutEmails.FocusedItem.SubItems(1).Text Then
                        If cdc(IO.File.ReadAllText(s + "\dt")) = lvOutEmails.FocusedItem.Text Then
                            If cdc(IO.File.ReadAllText(s + "\ht")) = "True" Then
                                frmShowEmailInWindow.Close()
                                frmShowEmailInWindow.Show()
                                frmShowEmailInWindow.Text = """" + lvOutEmails.SelectedItems(0).SubItems(1).Text + """" + " - justMail"
                                frmShowEmailInWindow.wbPreviewEmail.Visible = True
                                frmShowEmailInWindow.wbPreviewEmail.Focus()
                                frmShowEmailInWindow.rtbEmailPreview.Visible = False
                                Dim tx As String = cdc(IO.File.ReadAllText(s + "\tx"))
                                frmShowEmailInWindow.wbPreviewEmail.LoadHtml(tx)
                                Exit For
                            Else
                                frmShowEmailInWindow.Close()
                                frmShowEmailInWindow.Show()
                                frmShowEmailInWindow.Text = """" + lvOutEmails.SelectedItems(0).SubItems(1).Text + """" + " - justMail"
                                frmShowEmailInWindow.rtbEmailPreview.Visible = True
                                frmShowEmailInWindow.rtbEmailPreview.Focus()
                                frmShowEmailInWindow.wbPreviewEmail.Visible = False
                                frmShowEmailInWindow.rtbEmailPreview.Text = cdc(IO.File.ReadAllText(s + "\tx"))
                                Exit For
                            End If
                        End If
                    End If
                Next
            Else
            End If
        End If
        'Catch
        '    lvOutEmails.SelectedItems.Clear()
        ' End Try
    End Sub

    Private Sub lvOutEmails_MouseEnter(sender As Object, e As EventArgs) Handles lvOutEmails.MouseEnter
        lvOutEmails.Focus()
    End Sub

    Private Sub lvOutEmails_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lvOutEmails.SelectedIndexChanged
        Try
            If tvAccounts.SelectedNode.Text = "Entwürfe" Then

                If lvOutEmails.SelectedItems.Count = 1 Then
                    Dim mailadr As String
                    Dim subject As String = lvOutEmails.FocusedItem.SubItems(1).Text
                    mailadr = tvAccounts.SelectedNode.Parent.Parent.Text
                    For Each s As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\seM\")
                        If cdc(IO.File.ReadAllText(s + "\s")) = lvOutEmails.FocusedItem.SubItems(1).Text Then
                            If cdc(IO.File.ReadAllText(s + "\dt")) = lvOutEmails.FocusedItem.Text Then
                                wbPreviewEmail.Visible = True
                                rtbEmailPreview.Visible = False
                                navA = True
                                wbPreviewEmail.LoadHtml(cdc(IO.File.ReadAllText(s + "\tx")))
                                pnlSTRleft2.Visible = True : pnlSplitter.Visible = True
                                pnlSTRleft.Visible = True
                                pnlSTRtop.Visible = True
                                pnlMenuPreview.Visible = True
                                pnlSTRbtm2.Visible = True

                                lblByT.Text = mailadr
                                lblSubjectT.Text = cdc(IO.File.ReadAllText(s + "\s"))
                                lblToT.Text = cdc(IO.File.ReadAllText(s + "\t"))

                                If Not lblToT.Text = "" Then
                                    Dim ss1 As String = lblToT.Text.Substring(0, lblToT.Text.Length - 1)
                                    lblToT.Text = ss1
                                    lblToT.Text = lblToT.Text.Replace("<", "").Replace(">", "")
                                End If
                                lblTimeT.Text = cdc(IO.File.ReadAllText(s + "\dt"))
                                Try
                                    Dim fls As String = cdc(IO.File.ReadAllText(s + "\fls"))
                                    If Not fls = "" Then
                                        btnAttachments.Enabled = True
                                    Else
                                        btnAttachments.Enabled = False
                                    End If
                                Catch
                                    btnAttachments.Enabled = False
                                End Try
                            End If
                        End If
                    Next
                Else
                End If
            Else

                If lvOutEmails.SelectedItems.Count = 1 Then
                    Dim mailadr As String
                    Dim subject As String = lvOutEmails.FocusedItem.SubItems(1).Text
                    Try
                        mailadr = tvAccounts.SelectedNode.Parent.Text
                    Catch ex As Exception
                        mailadr = tvAccounts.SelectedNode.Text
                    End Try
                    For Each s As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + mailadr + "\osM\")
                        If cdc(IO.File.ReadAllText(s + "\s")) = lvOutEmails.FocusedItem.SubItems(1).Text Then
                            If cdc(IO.File.ReadAllText(s + "\ht")) = "True" Then
                                wbPreviewEmail.Visible = True
                                rtbEmailPreview.Visible = False
                                navA = True
                                wbPreviewEmail.LoadHtml(cdc(IO.File.ReadAllText(s + "\tx")))
                            Else
                                rtbEmailPreview.Visible = True
                                wbPreviewEmail.Visible = False
                                rtbEmailPreview.Text = cdc(IO.File.ReadAllText(s + "\tx"))
                            End If
                            pnlSTRleft2.Visible = True : pnlSplitter.Visible = True
                            pnlSTRleft.Visible = True
                            pnlSTRtop.Visible = True
                            pnlMenuPreview.Visible = True
                            pnlSTRbtm2.Visible = True

                            lblByT.Text = mailadr
                            lblSubjectT.Text = cdc(IO.File.ReadAllText(s + "\s"))
                            lblToT.Text = cdc(IO.File.ReadAllText(s + "\t"))
                            lblToT.Text = lblToT.Text.Substring(0, lblToT.Text.Length - 1).Replace("<", "").Replace(">", "")
                            lblTimeT.Text = cdc(IO.File.ReadAllText(s + "\dt"))

                            Try
                                Dim fls As String = cdc(IO.File.ReadAllText(s + "\fls"))
                                If Not fls = "" Then
                                    btnAttachments.Enabled = True
                                Else
                                    btnAttachments.Enabled = False
                                End If
                            Catch
                                btnAttachments.Enabled = False
                            End Try
                        End If
                    Next
                Else
                End If
            End If
        Catch
            lblStatus.Text = "Status: Fehler beim E-Mail anzeigen aufgetreten"
            System.Threading.Thread.Sleep(1000)
            lblStatus.Text = "Status:"
            lvOutEmails.SelectedItems.Clear()
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs)
        lvEmails.SelectedItems.Clear()
        lvEmails.Focus()
        For Each lvi As ListViewItem In lvEmails.Items
            If lvi.Text.ToLower.Contains(tbSearch.Text) Then
                lvi.Selected = True
            ElseIf lvi.SubItems(0).Text.ToLower.Contains(tbSearch.Text) Then
                lvi.Selected = True
            ElseIf lvi.SubItems(1).Text.ToLower.Contains(tbSearch.Text) Then
                lvi.Selected = True
            ElseIf lvi.SubItems(3).Text.ToLower.Contains(tbSearch.Text) Then
                lvi.Selected = True
            End If
        Next
    End Sub

    Private Sub tbSearch_GotFocus(sender As Object, e As System.EventArgs) Handles tbSearch.GotFocus
        If tbSearch.Text = "Suchen nach..." Then
            tbSearch.Text = ""
            tbSearch.Focus()
        End If
    End Sub

    Private Sub tbSearch_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub tbSearch_LostFocus(sender As Object, e As System.EventArgs) Handles tbSearch.LostFocus
        If tbSearch.Text = "" Then
            tbSearch.Text = "Suchen nach..."
        End If
    End Sub

    Private Sub tbSearch_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbSearch.TextChanged

        If lvOutEmails.Visible = False Then

            If tbSearch.Text = "" Then
                lvEmails.SelectedItems.Clear()
            ElseIf tbSearch.Text = "Suchen nach..." Then
                lvEmails.SelectedItems.Clear()
            Else
                lvEmails.SelectedItems.Clear()
                lvEmails.Focus()
                For Each lvi As ListViewItem In lvEmails.Items
                    If lvi.Text.ToLower.Contains(tbSearch.Text.ToLower) Then
                        lvi.Selected = True
                    ElseIf lvi.SubItems(0).Text.ToLower.Contains(tbSearch.Text.ToLower) Then
                        lvi.Selected = True
                    ElseIf lvi.SubItems(1).Text.ToLower.Contains(tbSearch.Text.ToLower) Then
                        lvi.Selected = True
                    ElseIf lvi.SubItems(3).Text.ToLower.Contains(tbSearch.Text.ToLower) Then
                        lvi.Selected = True
                    End If
                Next
                tbSearch.Focus()
            End If

        Else
            If tbSearch.Text = "" Then
                lvOutEmails.SelectedItems.Clear()
            ElseIf tbSearch.Text = "Suchen nach..." Then
                lvOutEmails.SelectedItems.Clear()
            Else
                lvOutEmails.SelectedItems.Clear()
                lvOutEmails.Focus()
                For Each lvi As ListViewItem In lvOutEmails.Items
                    If lvi.Text.ToLower.Contains(tbSearch.Text.ToLower) Then
                        lvi.Selected = True
                    ElseIf lvi.SubItems(0).Text.ToLower.Contains(tbSearch.Text.ToLower) Then
                        lvi.Selected = True
                    ElseIf lvi.SubItems(1).Text.ToLower.Contains(tbSearch.Text.ToLower) Then
                        lvi.Selected = True
                    ElseIf lvi.SubItems(3).Text.ToLower.Contains(tbSearch.Text.ToLower) Then
                        lvi.Selected = True
                    End If
                Next
                tbSearch.Focus()
            End If

        End If
    End Sub

    Private Sub wbPreviewEmail_MouseEnter(sender As Object, e As EventArgs) Handles wbPreviewEmail.MouseEnter
        MsgBox("kl")
        wbPreviewEmail.Focus()
    End Sub
    Private Sub wbPreviewEmail_Navigating(sender As Object, e As Gecko.Events.GeckoNavigatingEventArgs) Handles wbPreviewEmail.Navigating
        If navA = True Then
            navA = False
        Else
            Process.Start(e.Uri.ToString)
            e.Cancel = True
        End If
    End Sub

    Private Sub menuPosteingang_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles menuPosteingang.Opening

        If tvAccounts.SelectedNode.Text = "Posteingang" Then
            If lvEmails.SelectedItems.Count = 1 Then
                If lvEmails.SelectedItems(0).SubItems(1).Font.Style = FontStyle.Bold Then
                    UngelesenToolStripMenuItem.Enabled = False
                    GelesenToolStripMenuItem.Enabled = True
                Else
                    GelesenToolStripMenuItem.Enabled = False
                    UngelesenToolStripMenuItem.Enabled = True
                End If
                LöschenToolStripMenuItem.Enabled = True


            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub printText(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        ev.Graphics.DrawString(rtbEmailPreview.Text, New Font("Arial", 11, FontStyle.Regular), Brushes.Black, 12, 12)
        ev.HasMorePages = False
    End Sub

    Private Sub DruckvorschauToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DruckvorschauToolStripMenuItem.Click
        If tvAccounts.SelectedNode.Text = "Posteingang" OrElse tvAccounts.SelectedNode.Text = "Papierkorb" Then
            Dim sj As String = lvEmails.SelectedItems(0).SubItems(1).Text
            If tvAccounts.SelectedNode.Text = "Posteingang" Then
                For Each d As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tvAccounts.SelectedNode.Parent.Text + "\sM")
                    If cdc(IO.File.ReadAllText(d + "\s")) = sj Then
                        Dim isHTML As Boolean = CBool(cdc(IO.File.ReadAllText(d + "\ht")))
                        If isHTML = True Then
                            'wbPreviewEmail.ShowPrintPreviewDialog()
                        Else
                            Dim printPre As New PrintPreviewDialog
                            Dim printDoc As New PrintDocument
                            AddHandler printDoc.PrintPage, AddressOf printText
                            printDoc.DocumentName = lvEmails.SelectedItems(0).SubItems(1).Text
                            printPre.Document = printDoc
                            printPre.ShowIcon = False

                            printPre.ShowDialog()
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub DruckenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DruckenToolStripMenuItem.Click
        If tvAccounts.SelectedNode.Text = "Posteingang" OrElse tvAccounts.SelectedNode.Text = "Papierkorb" Then
            Dim sj As String = lvEmails.SelectedItems(0).SubItems(1).Text
            If tvAccounts.SelectedNode.Text = "Posteingang" Then
                For Each d As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tvAccounts.SelectedNode.Parent.Text + "\sM")
                    If cdc(IO.File.ReadAllText(d + "\s")) = sj Then
                        Dim isHTML As Boolean = CBool(cdc(IO.File.ReadAllText(d + "\ht")))
                        If isHTML = True Then
                            'wbPreviewEmail.ShowPrintDialog()
                        Else
                            Dim printDoc As New PrintDocument
                            AddHandler printDoc.PrintPage, AddressOf printText
                            printDoc.DocumentName = lvEmails.SelectedItems(0).SubItems(1).Text
                            printDoc.Print()
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub LöschenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LöschenToolStripMenuItem.Click
        If tvAccounts.SelectedNode.Text = "Posteingang" Then
            Dim dt As String = lvEmails.SelectedItems(0).Text
            Dim sj As String = lvEmails.SelectedItems(0).SubItems(1).Text
            Dim bys As String = lvEmails.SelectedItems(0).SubItems(2).Text
            If tvAccounts.SelectedNode.Text = "Posteingang" Then
                For Each d As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tvAccounts.SelectedNode.Parent.Text + "\sM")
                    Dim flN As String = d.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\justMail\" + cc("accounts") + "\" + tvAccounts.SelectedNode.Parent.Text + "\sM\", "")
                    If cdc(IO.File.ReadAllText(d + "\s")) = sj Then
                        If cdc(IO.File.ReadAllText(d + "\dt")) = dt Then
                            If MsgBox("Möchten Sie die Nachricht '" + sj + "' von '" + bys + "' wirklich in den Papierkorb verschieben?", MsgBoxStyle.YesNo, "Wirklich löschen?") = MsgBoxResult.Yes Then
                                IO.Directory.Move(d, (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\justMail\" + cc("accounts") + "\" + tvAccounts.SelectedNode.Parent.Text + "\rM\" + flN))
                                lvEmails.Items.Remove(lvEmails.SelectedItems(0))
                                Exit Sub
                            End If
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub rtbEmailPreview_LinkClicked(sender As Object, e As System.Windows.Forms.LinkClickedEventArgs) Handles rtbEmailPreview.LinkClicked
        Process.Start(e.LinkText)
    End Sub

    Private Sub btnAddressBook_Click(sender As System.Object, e As System.EventArgs) Handles btnAddressBook.Click
        frmAddressBook.Show()
    End Sub

    Private Sub tmrShowP_Tick(sender As System.Object, e As System.EventArgs) Handles tmrShowP.Tick
        tmrShowP.Stop()
        frmAddEmailPersonal.ShowDialog(Me)
    End Sub

    Private Sub tmrShowN_Tick(sender As System.Object, e As System.EventArgs) Handles tmrShowN.Tick
        tmrShowN.Stop()
        frmAddEmail.ShowDialog(Me)
    End Sub

    Private Sub MenuItem14_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem14.Click
        If tbSearch.Focused Then
            If tbSearch.CanUndo Then
                tbSearch.Undo()
            End If
        ElseIf rtbEmailPreview.Focused Then
            If rtbEmailPreview.CanUndo Then
                rtbEmailPreview.Undo()
            End If
        ElseIf wbPreviewEmail.ContainsFocus Then
            If wbPreviewEmail.CanUndo Then
                wbPreviewEmail.Undo()
            End If
        End If
    End Sub

    Private Sub MenuItem17_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem17.Click
        If tbSearch.Focused Then
            tbSearch.Cut()
        ElseIf rtbEmailPreview.Focused Then
            rtbEmailPreview.Cut()
        End If
    End Sub

    Private Sub MenuItem18_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem18.Click
        If tbSearch.Focused Then
            tbSearch.Copy()
        ElseIf rtbEmailPreview.Focused Then
            rtbEmailPreview.Copy()
        ElseIf wbPreviewEmail.ContainsFocus Then
            wbPreviewEmail.CopySelection()
        End If
    End Sub

    Private Sub MenuItem19_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem19.Click
        If tbSearch.Focused Then
            tbSearch.Paste()
        End If
    End Sub

    Private Sub MenuItem20_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem20.Click
        If tbSearch.Focused = True Then
            tbSearch.Cut()
            Clipboard.Clear()
        End If
    End Sub

    Private Sub tmrRefreshEmails_Tick(sender As System.Object, e As System.EventArgs) Handles tmrRefreshEmails.Tick
        getEmailsAll.RunWorkerAsync()
    End Sub

    Private Sub btnAttachments_Click(sender As System.Object, e As System.EventArgs) Handles btnAttachments.Click
        If tvAccounts.SelectedNode.Text = "Posteingang" Then
            For Each s As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" & cc("accounts") & "\" & tvAccounts.SelectedNode.Parent.Text + "\sM")
                If cdc(IO.File.ReadAllText(s + "\s")) = lvEmails.SelectedItems(0).SubItems(1).Text Then
                    If cdc(IO.File.ReadAllText(s + "\dt")) = lvEmails.SelectedItems(0).Text Then
                        frmAttachments.Close()
                        frmAttachments.openPathAttach = s + "\attachments"
                        frmAttachments.Text = """" + lvEmails.SelectedItems(0).SubItems(1).Text + """" + " - Anhänge - justMail"
                        frmAttachments.loadFiles()
                        frmAttachments.ShowDialog(Me)
                        Exit Sub
                    End If
                End If
            Next
        ElseIf tvAccounts.SelectedNode.Text = "Papierkorb" Then
            For Each s As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" & cc("accounts") & "\" & tvAccounts.SelectedNode.Parent.Text + "\rM")
                If cdc(IO.File.ReadAllText(s + "\s")) = lvEmails.SelectedItems(0).SubItems(1).Text Then
                    If cdc(IO.File.ReadAllText(s + "\dt")) = lvEmails.SelectedItems(0).Text Then
                        frmAttachments.Close()
                        frmAttachments.openPathAttach = s + "\attachments"
                        frmAttachments.Text = """" + lvEmails.SelectedItems(0).SubItems(1).Text + """" + " - Anhänge - justMail"
                        frmAttachments.loadFiles()
                        frmAttachments.ShowDialog(Me)
                        Exit Sub
                    End If
                End If
            Next
        ElseIf tvAccounts.SelectedNode.Text = "Postausgang" Then
            For Each s As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" & cc("accounts") & "\" & tvAccounts.SelectedNode.Parent.Text + "\osM")
                If cdc(IO.File.ReadAllText(s + "\s")) = lvOutEmails.SelectedItems(0).SubItems(1).Text Then
                    If cdc(IO.File.ReadAllText(s + "\dt")) = lvOutEmails.SelectedItems(0).Text Then
                        frmAttachments.Close()
                        frmAttachments.openPathAttach = "out-/-/-" + s
                        frmAttachments.Text = """" + lvOutEmails.SelectedItems(0).SubItems(1).Text + """" + " - Anhänge - justMail"
                        frmAttachments.loadFiles()
                        frmAttachments.ShowDialog(Me)
                        Exit Sub
                    End If
                End If
            Next
        ElseIf tvAccounts.SelectedNode.Text = "Entwürfe" Then
            For Each s As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" & cc("accounts") & "\" & tvAccounts.SelectedNode.Parent.Parent.Text + "\seM")
                If cdc(IO.File.ReadAllText(s + "\s")) = lvOutEmails.SelectedItems(0).SubItems(1).Text Then
                    If cdc(IO.File.ReadAllText(s + "\dt")) = lvOutEmails.SelectedItems(0).Text Then
                        frmAttachments.Close()
                        frmAttachments.openPathAttach = "out-/-/-" + s
                        frmAttachments.Text = """" + lvOutEmails.SelectedItems(0).SubItems(1).Text + """" + " - Anhänge - justMail"
                        frmAttachments.loadFiles()
                        frmAttachments.ShowDialog(Me)
                        Exit Sub
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub MenuItem15_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem15.Click
        checkForUpdate()
    End Sub

    Private Sub MenuItem21_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem21.Click
        frmAddressBook.Show()
    End Sub

    Private Sub MenuItem25_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem25.Click
        Try
            Dim frm As New frmCredits
            frmCredits.ShowDialog(Me)
        Catch ex As System.ComponentModel.Win32Exception
        End Try
    End Sub

    Private Function UnRegisterFile(ByVal endung As String, ByVal namedesdateityps As String) As Boolean
        Try
            Dim key1 As String = endung
            Dim key2 As String = namedesdateityps

            My.Computer.Registry.ClassesRoot.DeleteSubKeyTree(key1)
            My.Computer.Registry.ClassesRoot.DeleteSubKeyTree(key2)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub MenuItem23_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem23.Click
        frmJunkFilter.Show()
    End Sub

    Private Sub splMAILStoPREVIEW_Panel2_MouseEnter(sender As Object, e As EventArgs) Handles splMAILStoPREVIEW.Panel2.MouseEnter
        If wbPreviewEmail.Visible = True Then
            wbPreviewEmail.Focus()
        End If
    End Sub

    Private Sub pnlSTRleft2_MouseEnter(sender As Object, e As EventArgs) Handles pnlSTRleft2.MouseEnter
        If wbPreviewEmail.Visible = True Then
            wbPreviewEmail.Focus()
        End If
    End Sub

    Private Sub pnlSTRleft2_MouseHover(sender As Object, e As EventArgs) Handles pnlSTRleft2.MouseHover
        If wbPreviewEmail.Visible = True Then
            wbPreviewEmail.Focus()
        End If
    End Sub

    Private Sub splMAILStoPREVIEW_MouseHover(sender As Object, e As EventArgs) Handles splMAILStoPREVIEW.MouseHover
        If wbPreviewEmail.Visible = True Then
            wbPreviewEmail.Focus()
        End If
    End Sub

    Private Sub MacTextBox1_Text_Changed(e As String)

    End Sub

    Private Sub DrawBorder(g As Graphics)
        Throw New NotImplementedException
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        MsgBox(cdc("6uUwNJ1h7BXBTBVQzFWydg=="))
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Clipboard.SetText(cc("fzrejkdsds739"))
    End Sub
End Class