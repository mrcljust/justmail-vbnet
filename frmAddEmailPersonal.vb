Public Class frmAddEmailPersonal

    Public usepop3 As Boolean
    Public imapsrv As String
    Public imapprt As Integer
    Public p3srv As String
    Public p3prt As Integer
    Public smtpsrv As String
    Public smtpprt As Integer
    Public ssl As Boolean

    Dim closeIMP As Boolean = False

    Private Sub frmAddEmailPersonal_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        bgWorker1.CancelAsync()
        btnOk.Text = "Weiter"
        tbYourName.Enabled = True
        tbEmail.Enabled = True
        tbPassword.Enabled = True
        btnBack.Enabled = True
        lblYourName.ForeColor = Color.Black
        lblEmail.ForeColor = Color.Black
        lblPassword.ForeColor = Color.Black
        btnOk.Enabled = True
        PictureBox1.Visible = False
        tbEmail.Clear()
        tbYourName.Clear()
        lblStatus.Text = "Status: Warte..."
        tbPassword.Clear()
        If closeIMP = False Then
            frmAddEmail.Close()
        Else
            closeIMP = False
        End If

    End Sub

    Private Sub frmAddEmailPersonal_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            tbYourName.Text = Environment.UserName
        Catch
            tbYourName.Text = ""
        End Try
        tbYourName.SelectAll()
        If usepop3 = True Then
            lblTypeConn.Text = "(POP3)"
        Else
            lblTypeConn.Text = "(IMAP)"
        End If
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        If checkIfConnectedWithInternetM("Das Verknüpfen eines neuen E-Mail-Kontos") = True Then
            If btnOk.Text = "Weiter" Then
                If Not IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text) Then
                    If checkIfConnectedWithInternetM("Das Hinzufügen eines neuen Kontos") = True Then
                        PictureBox1.Visible = True
                        bgWorker1.RunWorkerAsync()
                        btnOk.Text = "..."
                        btnOk.Enabled = False
                    End If
                Else
                    MsgBox("Ein Konto mit der E-Mail-Adresse '" + tbEmail.Text + "' existiert bereits.", MsgBoxStyle.Exclamation, "Konto existiert bereits!")
                End If
            ElseIf btnOk.Text = "." Or btnOk.Text = ".." Or btnOk.Text = "..." Then
                Beep()
            ElseIf btnOk.Text = "Fertig" Then
                Dim method As String
                Dim crYourName As String = cc(tbYourName.Text)
                Dim crEmail As String = cc(tbEmail.Text)
                Dim crPassword As String = cc(tbPassword.Text)
                Dim crSMTPsrv As String = cc(smtpsrv)
                Dim crSMTPprt As String = cc(CStr(smtpprt))
                Dim crMethod As String
                Dim crPOP3srv As String
                Dim crPOP3prt As String
                Dim crIMAPsrv As String
                Dim crIMAPprt As String
                Dim crSSL As String = cc(CStr(ssl))
                Dim crLastMSGcount As String = cc("0")
                Dim crTimeAdded As String = cc(Now.ToString("HH:mm:ss"))
                Dim crDateAdded As String = cc(Now.ToString("dd.MM.yyyy"))
                Dim crOSN As String
                Dim crOSV As String
                Try
                    crOSN = cc(My.Computer.Info.OSFullName)
                    crOSV = cc(My.Computer.Info.OSVersion)
                Catch
                    crOSN = cc("unknown")
                    crOSV = cc("unknown")
                End Try

                IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\")
                IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\sM\")
                IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\rM\")
                IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\osM\")
                IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\seM\")
                IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\jF\")
                IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\jM\")
                IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\jF\sj\")
                IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\jF\b\")
                IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\jF\t\")
                IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\jF\dt\")

                IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\" + "nm", crYourName)
                IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\" + "eml", crEmail)
                IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\" + "p", crPassword)
                IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\" + "ss", crSMTPsrv)
                IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\" + "sp", crSMTPprt)
                IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\" + "s-uon", crSSL)
                IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\" + "tA", crTimeAdded)
                IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\" + "dA", crDateAdded)
                IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\" + "osN", crOSN)
                IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\" + "osV", crOSV)
                IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\" + "lmsgc", crLastMSGcount)
                If usepop3 = True Then
                    method = "pop3"
                    crMethod = cc("pop3")
                Else
                    method = "imap"
                    crMethod = cc("imap")
                End If
                IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\" + "mtd", crMethod)
                If usepop3 = True Then
                    crPOP3srv = cc(p3srv)
                    crPOP3prt = cc(CStr(p3prt))

                    IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\" + "p3s", crPOP3srv)
                    IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\" + "p3p", crPOP3prt)
                Else
                    crIMAPsrv = cc(imapsrv)
                    crIMAPprt = cc(CStr(imapprt))
                    IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\" + "ims", crIMAPsrv)
                    IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tbEmail.Text + "\" + "imp", crIMAPprt)
                End If
                mySfirststart = False
                saveConfigFile()
                If frmMain.Visible = True Then
                    frmMain.addEmailAcc(tbEmail.Text)
                    frmMain.emailAds.Add(tbEmail.Text)
                Else
                    frmMain.Show()
                End If

                Me.Close() '(und frmAddEmail wird auch geschlossen, siehe FormClose Sub)
            End If
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgWorker1.DoWork
        tbYourName.Enabled = False
        tbEmail.Enabled = False
        tbPassword.Enabled = False
        tbPassword.UseSystemPasswordChar = True
        btnBack.Enabled = False
        lblYourName.ForeColor = Color.Silver
        lblEmail.ForeColor = Color.Silver
        lblPassword.ForeColor = Color.Silver
        If usepop3 = True Then 'POP3
            lblStatus.Text = "Status: Sammle Daten..."
            Dim useSSL As Boolean = ssl
            Dim pop3server As String = p3srv
            Dim pop3port As Integer = p3prt
            Dim smtpserver As String = smtpsrv
            Dim smtpport As Integer = smtpprt
            Dim username As String = tbEmail.Text
            Dim password As String = tbPassword.Text
            lblStatus.Text = "Status: Versuche, POP3-Verbindung herzustellen..."
            If checkPOP3Connection(pop3server, pop3port, useSSL, username, password) = 2 Then
                lblStatus.Text = "Status: POP3-Verbindung hergestellt"
                lblStatus.Text = "Status: Versuche, SMTP-Verbindung herzustellen..."
                If sendWelcomeMailCHECKSMTP(tbYourName.Text, smtpserver, smtpport, useSSL, username, password, tbYourName.Text) = True Then
                    btnBack.Enabled = False
                    lblStatus.Text = "Status: SMTP-Verbindung hergestellt"
                    tmrCount.Stop()
                    btnOk.Text = "Fertig"
                    btnOk.Enabled = True
                    PictureBox1.Visible = False
                    bgWorker1.Dispose()
                Else
                    lblStatus.Text = "Status: SMTP-Verbindung konnte nicht hergestellt werden"
                    tmrCount.Stop()
                    btnOk.Text = "Weiter"
                    tbYourName.Enabled = True
                    tbEmail.Enabled = True
                    tbPassword.Enabled = True
                    btnBack.Enabled = True
                    lblYourName.ForeColor = Color.Black
                    lblEmail.ForeColor = Color.Black
                    lblPassword.ForeColor = Color.Black
                    btnOk.Enabled = True
                    PictureBox1.Visible = False
                    MsgBox("Mit den angegebenen Daten konnte keine Verbindung zum SMTP-Server hergestellt werden." + vbCrLf + vbCrLf + "Bitte prüfen Sie:" + vbCrLf + "● Richtige Daten eingegeben?" + vbCrLf + "● Internetverbindung" + vbCrLf + "● Möglicherweise Firewall", MsgBoxStyle.Exclamation, "Fehler beim Verbinden - justMail")
                End If
            ElseIf checkPOP3Connection(pop3server, pop3port, useSSL, username, password) = 1 Then
                lblStatus.Text = "Status: POP3-Verbindung konnte nicht hergestellt werden"
                tmrCount.Stop()
                btnOk.Text = "Weiter"
                tbYourName.Enabled = True
                tbEmail.Enabled = True
                tbPassword.Enabled = True
                btnBack.Enabled = True
                lblYourName.ForeColor = Color.Black
                lblEmail.ForeColor = Color.Black
                lblPassword.ForeColor = Color.Black
                btnOk.Enabled = True
                PictureBox1.Visible = False
                MsgBox("Mit den angegebenen Daten konnte keine Verbindung zum POP3-Server hergestellt werden." + vbCrLf + vbCrLf + "Bitte prüfen Sie:" + vbCrLf + "● Richtige Daten eingegeben?" + vbCrLf + "● Internetverbindung" + vbCrLf + "● Möglicherweise Firewall", MsgBoxStyle.Exclamation, "Fehler beim Verbinden - justMail")
            ElseIf checkPOP3Connection(pop3server, pop3port, useSSL, username, password) = 0 Then
                lblStatus.Text = "Status: POP3-Server konnte nicht gefunden werden"
                tmrCount.Stop()
                btnOk.Text = "Weiter"
                tbYourName.Enabled = True
                tbEmail.Enabled = True
                tbPassword.Enabled = True
                btnBack.Enabled = True
                lblYourName.ForeColor = Color.Black
                lblEmail.ForeColor = Color.Black
                lblPassword.ForeColor = Color.Black
                btnOk.Enabled = True
                PictureBox1.Visible = False
                MsgBox("Der POP3-Server konnte nicht gefunden werden, bitte prüfen Sie auf richtige Eingabe.", MsgBoxStyle.Exclamation, "POP3-Server nicht gefunden - justMail")
            ElseIf checkPOP3Connection(pop3server, pop3port, useSSL, username, password) = 3 Then
                lblStatus.Text = "Status: Internetverbindung unterbrochen, POP3-Verbindung konnte nicht hergestellt werden"
                tmrCount.Stop()
                btnOk.Text = "Weiter"
                tbYourName.Enabled = True
                tbEmail.Enabled = True
                tbPassword.Enabled = True
                btnBack.Enabled = True
                lblYourName.ForeColor = Color.Black
                lblEmail.ForeColor = Color.Black
                lblPassword.ForeColor = Color.Black
                btnOk.Enabled = True
                PictureBox1.Visible = False
            End If
            '---------------------
        Else 'IMAP
            lblStatus.Text = "Status: Sammle Daten..."
            Dim useSSL As Boolean = ssl
            Dim imapserver As String = imapsrv
            Dim imapport As Integer = imapprt
            Dim smtpserver As String = smtpsrv
            Dim smtpport As Integer = smtpprt
            Dim username As String = tbEmail.Text
            Dim password As String = tbPassword.Text

            lblStatus.Text = "Status: Versuche, IMAP-Verbindung herzustellen..."
            If checkIMAPconnection(imapserver, imapport, useSSL, username, password) = 2 Then
                lblStatus.Text = "Status: IMAP-Verbindung hergestellt"
                lblStatus.Text = "Status: Versuche, SMTP-Verbindung herzustellen..."
                If sendWelcomeMailCHECKSMTP(tbYourName.Text, smtpserver, smtpport, useSSL, username, password, tbYourName.Text) = True Then
                    btnBack.Enabled = False
                    lblStatus.Text = "Status: SMTP-Verbindung hergestellt"
                    tmrCount.Stop()
                    btnOk.Text = "Fertig"
                    btnOk.Enabled = True
                    PictureBox1.Visible = False
                    bgWorker1.Dispose()
                Else
                    lblStatus.Text = "Status: SMTP-Verbindung konnte nicht hergestellt werden"
                    tmrCount.Stop()
                    btnOk.Text = "Weiter"
                    tbYourName.Enabled = True
                    tbEmail.Enabled = True
                    tbPassword.Enabled = True
                    btnBack.Enabled = True
                    lblYourName.ForeColor = Color.Black
                    lblEmail.ForeColor = Color.Black
                    lblPassword.ForeColor = Color.Black
                    btnOk.Enabled = True
                    PictureBox1.Visible = False
                    MsgBox("Mit den angegebenen Daten konnte keine Verbindung zum SMTP-Server hergestellt werden." + vbCrLf + vbCrLf + "Bitte prüfen Sie:" + vbCrLf + "● Richtige Daten eingegeben?" + vbCrLf + "● Internetverbindung" + vbCrLf + "● Möglicherweise Firewall", MsgBoxStyle.Exclamation, "Fehler beim Verbinden - justMail")
                End If
            ElseIf checkIMAPconnection(imapserver, imapport, useSSL, username, password) = 1 Then
                lblStatus.Text = "Status: IMAP-Verbindung konnte nicht hergestellt werden"
                tmrCount.Stop()
                btnOk.Text = "Weiter"
                tbYourName.Enabled = True
                tbEmail.Enabled = True
                tbPassword.Enabled = True
                btnBack.Enabled = True
                lblYourName.ForeColor = Color.Black
                lblEmail.ForeColor = Color.Black
                lblPassword.ForeColor = Color.Black
                btnOk.Enabled = True
                PictureBox1.Visible = False
                MsgBox("Mit den angegebenen Daten konnte keine Verbindung zum IMAP-Server hergestellt werden." + vbCrLf + vbCrLf + "Bitte prüfen Sie:" + vbCrLf + "● Richtige Daten eingegeben?" + vbCrLf + "● Internetverbindung" + vbCrLf + "● Möglicherweise Firewall", MsgBoxStyle.Exclamation, "Fehler beim Verbinden - justMail")
            ElseIf checkIMAPconnection(imapserver, imapport, useSSL, username, password) = 0 Then
                lblStatus.Text = "Status: IMAP-Server konnte nicht gefunden werden"
                tmrCount.Stop()
                btnOk.Text = "Weiter"
                tbYourName.Enabled = True
                tbEmail.Enabled = True
                tbPassword.Enabled = True
                btnBack.Enabled = True
                lblYourName.ForeColor = Color.Black
                lblEmail.ForeColor = Color.Black
                lblPassword.ForeColor = Color.Black
                btnOk.Enabled = True
                PictureBox1.Visible = False
                MsgBox("Der IMAP-Server konnte nicht gefunden werden, bitte prüfen Sie auf richtige Eingabe.", MsgBoxStyle.Exclamation, "IMAP-Server nicht gefunden - justMail")
            ElseIf checkIMAPconnection(imapserver, imapport, useSSL, username, password) = 3 Then
                lblStatus.Text = "Status: Internetverbindung unterbrochen, IMAP-Verbindung zu konnte nicht hergestellt werden"
                tmrCount.Stop()
                btnOk.Text = "Weiter"
                tbYourName.Enabled = True
                tbEmail.Enabled = True
                tbPassword.Enabled = True
                btnBack.Enabled = True
                lblYourName.ForeColor = Color.Black
                lblEmail.ForeColor = Color.Black
                lblPassword.ForeColor = Color.Black
                btnOk.Enabled = True
                PictureBox1.Visible = False
            End If
        End If
    End Sub

    Private Sub tmrEnableOkButton_Tick(sender As System.Object, e As System.EventArgs) Handles tmrEnableOkButton.Tick
        If tbEmail.Text.Contains("@") And Not tbPassword.Text = "" Then
            btnOk.Enabled = True
        Else
            btnOk.Enabled = False
        End If
    End Sub

    Private Sub tmrCount_Tick(sender As System.Object, e As System.EventArgs) Handles tmrCount.Tick
        If btnOk.Text = "." Then
            btnOk.Text = ".."
        ElseIf btnOk.Text = ".." Then
            btnOk.Text = "..."
        ElseIf btnOk.Text = "..." Then
            btnOk.Text = "."
        End If
    End Sub

    Private Sub tbEmail_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbEmail.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            tbPassword.Focus()
        End If
    End Sub

    Private Sub tbPassword_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnOk.Focus()
            btnOk.PerformClick()
        End If
    End Sub

    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        Dim srv As String
        Dim srvP As String
        Dim smtp As String
        Dim smtpP As String
        If usepop3 = True Then
            srv = p3srv
            srvP = CStr(p3prt)
        Else
            srv = imapsrv
            srvP = CStr(imapprt)
        End If
        smtp = smtpsrv
        smtpP = CStr(smtpprt)
        frmAddEmail.tbPOP3server.Text = srv
        frmAddEmail.tbPOP3port.Text = srvP
        frmAddEmail.tbSMTPserver.Text = smtp
        frmAddEmail.tbSMTPport.Text = smtpP
        frmAddEmail.cbProvider.Text = cbProvider.Text
        frmAddEmail.cbSSL.Checked = ssl
        If usepop3 = True Then
            frmAddEmail.rbPOP3.Checked = True
        Else
            frmAddEmail.rbIMAP.Checked = True
        End If
        closeIMP = True
        If frmMain.Visible = True Then
        Else
            frmAddEmail.Show()
        End If
        Me.Close()
        If frmMain.Visible = True Then
            frmMain.tmrShowN.Enabled = True
        End If
    End Sub

    Private Sub tbYourName_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbYourName.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            tbEmail.Focus()
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        frmAddEmail.Visible = True
    End Sub
End Class