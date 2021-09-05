Public Class frmAddEmail

    Dim showP As Boolean = False
    Private Sub cbProvider_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cbProvider.KeyDown
        If e.KeyCode = Keys.Enter Then
            If cbProvider.Text = "Andere..." Then
                e.SuppressKeyPress = True
                tbPOP3server.Focus()
            Else
                e.SuppressKeyPress = True
                btnOk.Focus()
                btnOk.PerformClick()
            End If
        End If
    End Sub

    Private Sub cbProvider_LostFocus(sender As Object, e As System.EventArgs) Handles cbProvider.LostFocus
        If cbProvider.Text = "" Then
            cbProvider.Text = "Bitte auswählen..."
        End If
    End Sub

    Private Sub frmAddEmail_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If showP = True Then
            frmMain.tmrShowP.Enabled = True
        End If
    End Sub

    Private Sub cbProvider_TextChanged(sender As Object, e As System.EventArgs) Handles cbProvider.TextChanged
        If Not cbProvider.Items.Contains(cbProvider.Text) And Not cbProvider.Text = "Bitte auswählen..." Then
            cbProvider.Text = ""
            tbPOP3server.Text = ""
            tbPOP3port.Text = ""
            tbSMTPserver.Text = ""
            tbSMTPport.Text = ""
            Beep()
            cbSSL.Checked = False
        Else
            If rbPOP3.Checked = True Then
                If cbProvider.Text = "Microsoft" Then
                    tbPOP3server.Text = "pop3.live.com"
                    tbPOP3port.Text = "995"
                    tbSMTPserver.Text = "smtp.live.com"
                    tbSMTPport.Text = "25"
                    cbSSL.Checked = True
                ElseIf cbProvider.Text = "GMX" Then
                    tbPOP3server.Text = "pop.gmx.net"
                    tbPOP3port.Text = "995"
                    tbSMTPserver.Text = "mail.gmx.net"
                    tbSMTPport.Text = "25"
                    cbSSL.Checked = True
                ElseIf cbProvider.Text = "AOL (.com)" Then
                    tbPOP3server.Text = "pop.aol.com"
                    tbPOP3port.Text = "995"
                    tbSMTPserver.Text = "smtp.de.aol.com"
                    tbSMTPport.Text = "587"
                    cbSSL.Checked = True
                ElseIf cbProvider.Text = "AOL (.de), aim.com" Then
                    tbPOP3server.Text = "pop.aim.com"
                    tbPOP3port.Text = "995"
                    tbSMTPserver.Text = "smtp.aim.com"
                    tbSMTPport.Text = "587"
                    cbSSL.Checked = True
                ElseIf cbProvider.Text = "WEB" Then
                    tbPOP3server.Text = "pop3.web.de"
                    tbPOP3port.Text = "995"
                    tbSMTPserver.Text = "smtp.web.de"
                    tbSMTPport.Text = "587"
                    cbSSL.Checked = True
                ElseIf cbProvider.Text = "T-Online" Then
                    tbPOP3server.Text = "securepop.t-online.de"
                    tbPOP3port.Text = "995"
                    tbSMTPserver.Text = "securesmtp.t-online.de"
                    tbSMTPport.Text = "25"
                    cbSSL.Checked = True
                ElseIf cbProvider.Text = "Gmail" Then
                    tbPOP3server.Text = "pop.gmail.com"
                    tbPOP3port.Text = "995"
                    tbSMTPserver.Text = "smtp.gmail.com"
                    tbSMTPport.Text = "465"
                    cbSSL.Checked = True
                ElseIf cbProvider.Text = "Andere..." Then
                    cbProvider.Text = ""
                    tbPOP3server.Text = ""
                    tbPOP3port.Text = "995"
                    tbSMTPserver.Text = ""
                    tbSMTPport.Text = "25"
                    cbSSL.Checked = True
                End If

            ElseIf rbIMAP.Checked = True Then
                If cbProvider.Text = "GMX" Then
                    tbPOP3server.Text = "imap.gmx.net"
                    tbPOP3port.Text = "993"
                    tbSMTPserver.Text = "mail.gmx.net"
                    tbSMTPport.Text = "25"
                    cbSSL.Checked = True
                ElseIf cbProvider.Text = "AOL (.com)" Then
                    tbPOP3server.Text = "imap.aol.com"
                    tbPOP3port.Text = "993"
                    tbSMTPserver.Text = "smtp.de.aol.com"
                    tbSMTPport.Text = "587"
                    cbSSL.Checked = False
                ElseIf cbProvider.Text = "AOL (.de), aim.com" Then
                    tbPOP3server.Text = "imap.aim.com"
                    tbPOP3port.Text = "993"
                    tbSMTPserver.Text = "smtp.aim.com"
                    tbSMTPport.Text = "587"
                    cbSSL.Checked = False
                ElseIf cbProvider.Text = "WEB" Then
                    tbPOP3server.Text = "imap.web.de"
                    tbPOP3port.Text = "993"
                    tbSMTPserver.Text = "smtp.web.de"
                    tbSMTPport.Text = "587"
                    cbSSL.Checked = True
                ElseIf cbProvider.Text = "T-Online" Then
                    tbPOP3server.Text = "secureimap.t-online.de"
                    tbPOP3port.Text = "993"
                    tbSMTPserver.Text = "securesmtp.t-online.de"
                    tbSMTPport.Text = "25"
                    cbSSL.Checked = True
                ElseIf cbProvider.Text = "Gmail" Then
                    tbPOP3server.Text = "imap.gmail.com"
                    tbPOP3port.Text = "993"
                    tbSMTPserver.Text = "smtp.gmail.com"
                    tbSMTPport.Text = "465"
                    cbSSL.Checked = True
                ElseIf cbProvider.Text = "Andere..." Then
                    cbProvider.Text = ""
                    tbPOP3server.Text = ""
                    tbPOP3port.Text = "993"
                    tbSMTPserver.Text = ""
                    tbSMTPport.Text = "25"
                    cbSSL.Checked = True
                End If
            End If
        End If
    End Sub

    Private Sub tmrEnableOkButton_Tick(sender As System.Object, e As System.EventArgs) Handles tmrEnableOkButton.Tick
        If Not tbPOP3server.Text = "" And Not tbPOP3port.Text = "" And Not tbSMTPserver.Text = "" And Not tbSMTPport.Text = "" Then
            btnOk.Enabled = True
        Else
            btnOk.Enabled = False
        End If
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        If IsNumeric(tbPOP3port.Text) And IsNumeric(tbSMTPport.Text) Then
            If rbPOP3.Checked = True Then
                frmAddEmailPersonal.usepop3 = True
                frmAddEmailPersonal.p3srv = tbPOP3server.Text
                frmAddEmailPersonal.p3prt = CInt(tbPOP3port.Text)
            ElseIf rbIMAP.Checked = True Then
                frmAddEmailPersonal.usepop3 = False
                frmAddEmailPersonal.imapsrv = tbPOP3server.Text
                frmAddEmailPersonal.imapprt = CInt(tbPOP3port.Text)
            End If
            frmAddEmailPersonal.cbProvider.Text = cbProvider.Text
            frmAddEmailPersonal.smtpsrv = tbSMTPserver.Text
            frmAddEmailPersonal.smtpprt = CInt(tbSMTPport.Text)
            frmAddEmailPersonal.ssl = CBool(cbSSL.CheckState)
            If frmMain.Visible = True Then
                showP = True
                Me.Close()
            Else
                frmAddEmailPersonal.Show()
                Me.Close()
            End If
        Else
            If rbPOP3.Checked = True Then
                MsgBox("Der POP3- oder SMTP-Port enthält ungültige Zeichen. Nur Zahlen (0-9) sind erlaubt.", MsgBoxStyle.Exclamation, "Ungültige Zeichen - justMail")
            ElseIf rbIMAP.Checked = True Then
                MsgBox("Der IMAP- oder SMTP-Port enthält ungültige Zeichen. Nur Zahlen (0-9) sind erlaubt.", MsgBoxStyle.Exclamation, "Ungültige Zeichen - justMail")
            End If
        End If
    End Sub

    Private Sub lLblSuggestProvider_LinkClicked(sender As System.Object, e As System.EventArgs)
        If MsgBox("Sie werden auf unsere Seite geleitet, um einen Anbieter vorzuschlagen." & vbNewLine & "Fortfahren?", MsgBoxStyle.YesNo, "Fortfahren? - justMail") = MsgBoxResult.Yes Then
            Process.Start("http://www.it-just.net")
        End If
    End Sub

    Private Sub tmrEnableTextboxes_Tick(sender As System.Object, e As System.EventArgs) Handles tmrEnableTextboxes.Tick
        If cbProvider.Text = "Andere..." Then
            tbPOP3server.Enabled = True
            tbPOP3port.Enabled = True
            tbSMTPserver.Enabled = True
            tbSMTPport.Enabled = True
            cbSSL.Enabled = True
            lblPOP3server.ForeColor = Color.Black
            lblPOP3port.ForeColor = Color.Black
            lblSMTPserver.ForeColor = Color.Black
            lblSMTPport.ForeColor = Color.Black
            cbSSL.ForeColor = Color.Black
        Else
            tbPOP3server.Enabled = False
            tbPOP3port.Enabled = False
            tbSMTPserver.Enabled = False
            tbSMTPport.Enabled = False
            cbSSL.Enabled = False
            lblPOP3server.ForeColor = Color.Silver
            lblPOP3port.ForeColor = Color.Silver
            lblSMTPserver.ForeColor = Color.Silver
            lblSMTPport.ForeColor = Color.Silver
            cbSSL.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub rbPOP3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbPOP3.CheckedChanged
        If rbPOP3.Checked = True Then
            tbPOP3server.Clear()
            tbPOP3port.Clear()
            tbSMTPserver.Clear()
            tbSMTPport.Clear()
            cbProvider.Items.Clear()
            cbSSL.Checked = False
            cbProvider.Text = "Bitte auswählen..."
            cbProvider.Items.Add("Microsoft")
            cbProvider.Items.Add("GMX")
            cbProvider.Items.Add("AOL (.com)")
            cbProvider.Items.Add("AOL (.de), aim.com")
            cbProvider.Items.Add("WEB")
            cbProvider.Items.Add("T-Online")
            cbProvider.Items.Add("Gmail")
            cbProvider.Items.Add("Andere...")
            lblPOP3server.Text = "POP3-Server:"
            lblPOP3port.Location = New Point(lblPOP3port.Location.X - 1, lblPOP3port.Location.Y)
        End If
    End Sub

    Private Sub rbIMAP_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbIMAP.CheckedChanged
        If rbIMAP.Checked = True Then
            tbPOP3server.Clear()
            tbPOP3port.Clear()
            tbSMTPserver.Clear()
            tbSMTPport.Clear()
            cbProvider.Items.Clear()
            cbSSL.Checked = False
            cbProvider.Text = "Bitte auswählen..."
            cbProvider.Items.Add("GMX")
            cbProvider.Items.Add("AOL (.com)")
            cbProvider.Items.Add("AOL (.de), aim.com")
            cbProvider.Items.Add("WEB")
            cbProvider.Items.Add("T-Online")
            cbProvider.Items.Add("Gmail")
            cbProvider.Items.Add("Andere...")
            lblPOP3server.Text = "IMAP-Server:"
            lblPOP3port.Location = New Point(lblPOP3port.Location.X + 1, lblPOP3port.Location.Y)
        End If
    End Sub

    Private Sub KryptonLinkLabel1_LinkClicked(sender As System.Object, e As System.EventArgs) Handles KryptonLinkLabel1.LinkClicked
        Process.Start("http://it-just.net/email-anbieter/")

    End Sub

    Private Sub tbPOP3server_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbPOP3server.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            tbPOP3port.Focus()
        End If
    End Sub

    Private Sub tbPOP3port_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbPOP3port.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            tbSMTPserver.Focus()
        End If
    End Sub

    Private Sub tbSMTPserver_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbSMTPserver.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            tbSMTPport.Focus()
        End If
    End Sub

    Private Sub tbSMTPport_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbSMTPport.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            cbSSL.Focus()
        End If
    End Sub

    Private Sub cbSSL_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cbSSL.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnOk.Focus()
            btnOk.PerformClick()
        End If
    End Sub

    Private Sub rbPOP3_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles rbPOP3.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbProvider.Focus()
        End If
    End Sub

    Private Sub rbIMAP_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles rbIMAP.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbProvider.Focus()
        End If
    End Sub

    Private Sub frmAddEmail_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cbProvider_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbProvider.SelectedIndexChanged

    End Sub
End Class