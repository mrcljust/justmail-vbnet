Public Class frmNewEmail

    Public selectname As String
    Public email As String
    Public closeE As Boolean = False
    Public inUseEmail As String = ""
    Dim edited As Boolean = False
    Public loadHtml As String = ""
    Dim htmlText As String = ""

    Private Sub frmNewEmail_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If closeE = True Then
            frmMain.Focus()
            closeE = False
            frmMain.btnRenew.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Standalone
            frmMain.btnAddressBook.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Standalone
            frmMain.btnNewEmail.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Standalone
            frmMain.tvAccounts.ItemStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.ListItem
            frmMain.tvAccounts.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.InputControlStandalone
            frmMain.tvAccounts.BorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.InputControlStandalone
            frmMain.tvAccounts.ExpandAll()
            For Each n As TreeNode In frmMain.tvAccounts.Nodes
                n.Nodes(2).Collapse()
                n.Nodes(0).Collapse()
            Next
        Else
            If Not tbSubject.Text = "" Then
                If MsgBox("Möchten Sie die E-Mail mit dem Betreff '" + tbSubject.Text + "' als Entwurf speichern?" + vbCrLf + "Ansonsten wird diese gelöscht!", MsgBoxStyle.YesNo, "E-Mail als Entwurf speichern? - justMail") = MsgBoxResult.Yes Then
                    Dim pth As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + inUseEmail + "\seM\" + CStr(myScc) + "\"
                    IO.Directory.CreateDirectory(pth)
                    myScc += 1 : saveConfigFile()
                    IO.File.WriteAllText(pth + "\s", cc(tbSubject.Text))
                    IO.File.WriteAllText(pth + "\t", cc(tbTo.Text))
                    IO.File.WriteAllText(pth + "\b", cc(cbBy.Text))
                    IO.File.WriteAllText(pth + "\be", cc(inUseEmail))
                    IO.File.WriteAllText(pth + "\tx", cc(wbHTML.DocumentText))
                    IO.File.WriteAllText(pth + "\dt", cc(CStr(Date.Now)))
                    IO.File.WriteAllText(pth + "\ht", cc("HTML"))
                    Dim files As String = ""
                    For Each lvi As String In lbAttachs.Items
                        files &= lvi & ";;;;;;;"
                    Next
                    IO.File.WriteAllText(pth + "\fls", cc(files))
                End If
            Else
                If edited = False Then

                Else
                    If tbSubject.Text = "" Then
                        If MsgBox("Möchten Sie die E-Mail mit dem Betreff '(kein Betreff)' als Entwurf speichern?" + vbCrLf + "Ansonsten wird diese gelöscht!", MsgBoxStyle.YesNo, "E-Mail als Entwurf speichern? - justMail") = MsgBoxResult.Yes Then
                            Dim pth As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + inUseEmail + "\seM\" + CStr(myScc) + "\"
                            IO.Directory.CreateDirectory(pth)
                            myScc += 1 : saveConfigFile()
                            If tbSubject.Text = "" Then
                                IO.File.WriteAllText(pth + "\s", cc("(kein Betreff)"))
                            Else
                                IO.File.WriteAllText(pth + "\s", cc(tbSubject.Text))
                            End If
                            IO.File.WriteAllText(pth + "\t", cc(tbTo.Text))
                            IO.File.WriteAllText(pth + "\b", cc(cbBy.Text))
                            IO.File.WriteAllText(pth + "\be", cc(inUseEmail))
                            IO.File.WriteAllText(pth + "\tx", cc(wbHTML.DocumentText))
                            IO.File.WriteAllText(pth + "\dt", cc(CStr(Date.Now)))
                            IO.File.WriteAllText(pth + "\ht", cc("HTML"))
                            Dim files As String = ""
                            For Each lvi As String In lbAttachs.Items
                                files &= lvi & ";;;;;;;"
                            Next
                            IO.File.WriteAllText(pth + "\fls", cc(files))
                        End If
                    Else
                        If MsgBox("Möchten Sie die E-Mail mit dem Betreff '" + tbSubject.Text + "' als Entwurf speichern?" + vbCrLf + "Ansonsten wird diese gelöscht!", MsgBoxStyle.YesNo, "E-Mail als Entwurf speichern? - justMail") = MsgBoxResult.Yes Then
                            Dim pth As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + inUseEmail + "\seM\" + CStr(myScc) + "\"
                            IO.Directory.CreateDirectory(pth)
                            myScc += 1 : saveConfigFile()
                            If tbSubject.Text = "" Then
                                IO.File.WriteAllText(pth + "\s", cc("(kein Betreff)"))
                            Else
                                IO.File.WriteAllText(pth + "\s", cc(tbSubject.Text))
                            End If
                            IO.File.WriteAllText(pth + "\t", cc(tbTo.Text))
                            IO.File.WriteAllText(pth + "\b", cc(cbBy.Text))
                            IO.File.WriteAllText(pth + "\be", cc(inUseEmail))
                            IO.File.WriteAllText(pth + "\tx", cc(wbHTML.DocumentText))
                            IO.File.WriteAllText(pth + "\dt", cc(CStr(Date.Now)))
                            IO.File.WriteAllText(pth + "\ht", cc("HTML"))
                            Dim files As String = ""
                            For Each lvi As String In lbAttachs.Items
                                files &= lvi & ";;;;;;;"
                            Next
                            IO.File.WriteAllText(pth + "\fls", cc(files))
                        End If
                    End If
                End If

            End If
        End If
        frmMain.Focus()
    End Sub
    Private Sub frmNewEmail_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        For Each z As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts"))
            email = z.Replace("C:\Users\" + Environment.UserName + "\AppData\Roaming\justMail\" + cc("accounts") + "\", "")
            inUseEmail = email
            Dim yourName As String = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + inUseEmail + "\nm"))
            cbBy.Items.Add(yourName + " (" + inUseEmail + ")")

        Next
        If cbBy.Items.Contains(selectname) Then
            cbBy.Text = selectname
        End If
        If Not loadHtml = "" Then
            IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("defaultProfile") + "\" + cc("tempmail") + ".html", loadHtml)
            wbHTML.Navigate(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("defaultProfile") + "\" + cc("tempmail") + ".html")
            wbHTML.Document.ExecCommand("EditMode", False, Nothing)
        Else
            wbHTML.Navigate("about:blank")
            wbHTML.Document.ExecCommand("EditMode", False, Nothing)
        End If
    End Sub

    Private Sub btnChat_Click(sender As System.Object, e As System.EventArgs)
        Dim z As New OpenFileDialog
        z.Filter = "Alle Dateien (*.*)|*.*"
        If z.ShowDialog = Windows.Forms.DialogResult.OK Then
            lbAttachs.Items.Add(z.FileName)
            If lbAttachs.Items.Count = 1 Then
                lblCountAttachs.Text = CStr(lbAttachs.Items.Count) + " Anhang"
            ElseIf lbAttachs.Items.Count = 0 OrElse lbAttachs.Items.Count > 1 Then
                lblCountAttachs.Text = CStr(lbAttachs.Items.Count) + " Anhänge"
            End If
        End If
    End Sub

    Private Sub lbAttachs_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lbAttachs.KeyDown
        If e.KeyCode = Keys.Delete Then
            If lbAttachs.SelectedItems.Count > 0 Then
                e.SuppressKeyPress = True
                If MsgBox("Möchten Sie die Datei '" + lbAttachs.SelectedItem.ToString + "' wirklich aus den Anhängen entfernen?", MsgBoxStyle.YesNo, "Anhang entfernen? - justMail") = MsgBoxResult.Yes Then
                    lbAttachs.Items.RemoveAt(lbAttachs.SelectedIndex)
                    If lbAttachs.Items.Count = 1 Then
                        lblCountAttachs.Text = CStr(lbAttachs.Items.Count) + " Anhang"
                    ElseIf lbAttachs.Items.Count = 0 OrElse lbAttachs.Items.Count > 1 Then
                        lblCountAttachs.Text = CStr(lbAttachs.Items.Count) + " Anhänge"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnNewEmail_Click(sender As System.Object, e As System.EventArgs) Handles btnSend.Click
        htmlText = (wbHTML.DocumentText.Replace("ä", "&auml;").Replace("Ä", "&Auml;").Replace("Ü", "&Uuml;").Replace("ü", "&uuml;").Replace("Ö", "&Ouml;").Replace("ö", "&ouml;").Replace("ß", "&szlig;").Replace("€", "&euro;").Replace("©", "&copy;").Replace("<META name=GENERATOR content=" + """" + "MSHTML 10.00.9200.16721" + """" + "></HEAD>", "<META name=GENERATOR content=" + """" + "justMail " + My.Application.Info.Version.ToString + """" + "></HEAD>"))
        sendmail()
    End Sub

    Private Sub sendmail()
        If cbBy.Text = "" Then
            MsgBox("Bitte wählen Sie die E-Mail-Adresse aus, mit welcher Sie die Nachricht senden wollen.", MsgBoxStyle.Exclamation, "Fehlende Eingabe - justMail")
        Else
            If wbHTML.DocumentText = "" Then
                MsgBox("Bitte geben Sie eine Nachricht ein.", MsgBoxStyle.Exclamation, "Fehlende Eingabe - justMail")

            Else
                If tbTo.Text = "" And tbSubject.Text = "" Then
                    MsgBox("Bitte geben Sie mindestens einen Empfänger und einen Betreff ein.", MsgBoxStyle.Exclamation, "Fehlende Eingaben - justMail")
                ElseIf tbTo.Text = "" Then
                    MsgBox("Bitte geben Sie mindestens einen Empfänger ein.", MsgBoxStyle.Exclamation, "Fehlende Eingabe - justMail")
                ElseIf tbSubject.Text = "" Then
                    MsgBox("Bitte geben Sie einen Betreff ein.", MsgBoxStyle.Exclamation, "Fehlende Eingabe - justMail")
                Else
                    'VERSENDEN SMTP
                    If checkIfConnectedWithInternetM("Das Senden der E-Mail") = True Then
                        cbBy.Enabled = False
                        tbTo.Enabled = False
                        tbSubject.Enabled = False
                        Panel3.Enabled = False
                        'WebBrowser1.Enabled = False
                        lbAttachs.Enabled = False
                        btnSend.Enabled = False
                        For Each mI As MenuItem In barMenu.MenuItems
                            mI.Enabled = False
                        Next
                        If bgWorker1.IsBusy Then
                            MsgBox("Eine Nachricht wird derzeitig bereits versendet!", MsgBoxStyle.Exclamation, "Bereits unterwegs - justMail")

                        Else
                            bgWorker1.RunWorkerAsync()
                        End If
                    Else

                    End If
                End If
            End If
        End If
    End Sub

    Private Sub bgWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgWorker1.DoWork

        lblState.Text = "Status: Sammle Daten..."
        Dim smtpsrv As String = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + inUseEmail + "\ss"))
        Dim smtpprt As Integer = CInt(cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + inUseEmail + "\sp")))
        Dim usern As String = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + inUseEmail + "\eml"))
        Dim pasw As String = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + inUseEmail + "\p"))
        Dim dpName As String = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + inUseEmail + "\nm"))
        Dim usessl As Boolean = CBool(cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + inUseEmail + "\s-uon")))
        Dim attachments As New List(Of String)
        For Each s As String In lbAttachs.Items
            attachments.Add(s)
        Next
        Dim isMsgHTML As Boolean
        isMsgHTML = True
        tmrUpdateStatus.Enabled = True
        lblState.Text = "Status: Sende..."
        Dim erg As String = sendEmail(dpName, smtpsrv, smtpprt, usessl, usern, pasw, tbTo.Text, tbSubject.Text, htmlText, isMsgHTML, attachments)
        If erg = "0" Then
            Dim s As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + inUseEmail + "\osM\" + CStr(myScc + 1)
            IO.Directory.CreateDirectory(s)
            myScc += 1
            saveConfigFile()
            IO.File.WriteAllText(s + "\s", cc(tbSubject.Text))
            IO.File.WriteAllText(s + "\tx", cc(htmlText))
            Dim toList As New List(Of String)
            toList.AddRange(Split(tbTo.Text, ";"))
            Dim toNewStr As String = ""
            For Each str As String In toList
                toNewStr &= "<" + str + ">, "
            Next
            toNewStr = toNewStr.Substring(0, toNewStr.Length - 1)
            IO.File.WriteAllText(s + "\t", cc(toNewStr))
            Dim ccdate As String = CStr(Date.Now)
            IO.File.WriteAllText(s + "\dt", cc(ccdate))
            IO.File.WriteAllText(s + "\ht", cc(CStr(isMsgHTML)))
            Dim apnd As String = ""
            For Each z As String In lbAttachs.Items
                apnd += z + ";;;;;;;"
            Next
            IO.File.WriteAllText(s + "\fls", cc(apnd))
            'frmNotificationR.lblTitle.Text = "E-Mail gesendet"
            'frmNotificationR.lblText.Text = "Ihre E-Mail an '" + tbTo.Text + "' wurde gesendet"
            'frmNotificationR.Show()

            closeE = True
            Me.Close()
            bgWorker1.Dispose()
        Else
            Dim z As String = erg
            If z = "2" Then
                cbBy.Enabled = True
                tbTo.Enabled = True
                tbSubject.Enabled = True
                'WebBrowser1.Enabled = True
                Panel3.Enabled = True
                lbAttachs.Enabled = True
                btnSend.Enabled = True
                For Each mI As MenuItem In barMenu.MenuItems
                    mI.Enabled = True
                Next
                lblState.Text = "Status: Internetverbindung unterbrochen, E-Mail konnte nicht versendet werden."

            Else
                cbBy.Enabled = True
                tbTo.Enabled = True
                tbSubject.Enabled = True
                'WebBrowser1.Enabled = True
                Panel3.Enabled = True
                lbAttachs.Enabled = True
                btnSend.Enabled = True
                For Each mI As MenuItem In barMenu.MenuItems
                    mI.Enabled = True
                Next
                lblState.Text = "Status: Fehler beim Versenden: " + z
                MsgBox("Folgender Fehler wurde zurückgegeben:" + vbCrLf + z, MsgBoxStyle.Exclamation, "Fehler aufgetreten - justMail")

            End If
        End If
    End Sub

    Private Sub tmrUpdateStatus_Tick(sender As System.Object, e As System.EventArgs) Handles tmrUpdateStatus.Tick
        lblState.Text = "Status: " + curState
    End Sub

    Private Sub cbBy_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cbBy.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            tbTo.Focus()
        End If
    End Sub

    Private Sub cbBy_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbBy.SelectedIndexChanged
        Dim sp As New List(Of String)
        Dim sel As String = cbBy.Text.Replace("(", "").Replace(")", "")
        sp.AddRange(Split(sel, " "))
        inUseEmail = sp(1)
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        MsgBox(inUseEmail)
    End Sub

    Private Sub tmrUpdateProgramText_Tick(sender As System.Object, e As System.EventArgs) Handles tmrUpdateProgramText.Tick
        If tbSubject.Text = "" Then
            Me.Text = "Neue E-Mail: (kein Betreff) - justMail"
        Else
            Me.Text = "Neue E-Mail: " + tbSubject.Text + " - justMail"
        End If
    End Sub

    Private Sub tbTo_GotFocus(sender As Object, e As System.EventArgs) Handles tbTo.GotFocus
        ttMultiTo.Show("Sie können eine Nachricht an mehrere E-Mail-Adressen versenden, indem Sie mit """ + ";" + """ trennen:" + vbCrLf + "beispiel@beispiel.de;example@example.com", tbTo)
    End Sub

    Private Sub tbTo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            tbSubject.Focus()
        End If
    End Sub

    Private Sub tbSubject_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbSubject.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            wbHTML.Focus()
        End If
    End Sub

    Private Sub tbTo_MouseHover(sender As Object, e As System.EventArgs) Handles tbTo.MouseHover
        ttMultiTo.Show("Sie können eine Nachricht an mehrere E-Mail-Adressen versenden, indem Sie mit """ + ";" + """ trennen:" + vbCrLf + "beispiel@beispiel.de;example@example.com", tbTo)
    End Sub

    Private Sub MenuItem8_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem8.Click
        wbHTML.Document.ExecCommand("Undo", False, Nothing)
    End Sub

    Private Sub MenuItem9_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem9.Click
        wbHTML.Document.ExecCommand("Redo", False, Nothing)
    End Sub

    Private Sub MenuItem11_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem11.Click
        wbHTML.Document.ExecCommand("Cut", False, Nothing)
    End Sub

    Private Sub MenuItem12_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem12.Click
        wbHTML.Document.ExecCommand("Copy", False, Nothing)
    End Sub

    Private Sub MenuItem13_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem13.Click
        wbHTML.Document.ExecCommand("Paste", False, Nothing)
    End Sub

    Private Sub MenuItem14_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem14.Click
        wbHTML.Document.ExecCommand("Delete", False, Nothing)
    End Sub

    Private Sub MenuItem16_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem16.Click
        wbHTML.Document.ExecCommand("SelectAll", False, Nothing)
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        wbHTML.Document.ExecCommand("Bold", False, Nothing)
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        wbHTML.Document.ExecCommand("Italic", False, Nothing)
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        wbHTML.Document.ExecCommand("Underline", False, Nothing)
    End Sub

    Private Sub DateiToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DateiToolStripMenuItem.Click
        wbHTML.Document.ExecCommand("Image", False, Nothing)
    End Sub

    Private Sub LinkToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LinkToolStripMenuItem.Click
        wbHTML.Document.ExecCommand("Hyperlink", False, Nothing)
    End Sub

    Private Sub MenuItem17_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem17.Click
        'WebBrowser1.Document.ExecCommand(DHTMLEDLib.DHTMLEDITCMDID.DECMD_FINDTEXT, False, Nothing)
    End Sub

    Private Sub MenuItem19_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem19.Click
        wbHTML.Document.ExecCommand("InsertImage", False, Nothing)
    End Sub

    Private Sub ToolStripButton8_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton8.Click
        wbHTML.Document.ExecCommand("JustifyLeft", False, Nothing)
    End Sub

    Private Sub ToolStripButton7_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton7.Click
        wbHTML.Document.ExecCommand("JustifyCenter", False, Nothing)
    End Sub

    Private Sub ToolStripButton6_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton6.Click
        wbHTML.Document.ExecCommand("JustifyRight", False, Nothing)
    End Sub

    Private Sub MenuItem20_Click_2(sender As System.Object, e As System.EventArgs) Handles MenuItem20.Click
        wbHTML.Document.ExecCommand("FontName", False, Nothing)
    End Sub

    Private Sub MenuItem21_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem21.Click
        wbHTML.Document.ExecCommand("Createlink", False, Nothing)
    End Sub


    Private Sub ToolStripButton5_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton5.Click
        wbHTML.Document.ExecCommand("FontName", False, Nothing)
    End Sub

    Private Sub lbAttachsSelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbAttachs.SelectedIndexChanged
        If lbAttachs.SelectedItems.Count = 1 Then
            btnRemoveAttach.Enabled = True
        Else
            btnRemoveAttach.Enabled = False
        End If
    End Sub

    Private Sub MenuItem22_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem22.Click
        htmlText = (wbHTML.DocumentText.Replace("ä", "&auml;").Replace("Ä", "&Auml;").Replace("Ü", "&Uuml;").Replace("ü", "&uuml;").Replace("Ö", "&Ouml;").Replace("ö", "&ouml;").Replace("ß", "&szlig;").Replace("€", "&euro;").Replace("©", "&copy;").Replace("<META name=GENERATOR content=" + """" + "MSHTML 10.00.9200.16721" + """" + "></HEAD>", "<META name=GENERATOR content=" + """" + "justMail " + My.Application.Info.Version.ToString + """" + "></HEAD>"))
        sendmail()
    End Sub

    Private Sub ToolStripButton17_Click(sender As System.Object, e As System.EventArgs)
        Dim z As New OpenFileDialog
        z.Filter = "Alle Dateien (*.*)|*.*"
        If z.ShowDialog = Windows.Forms.DialogResult.OK Then
            lbAttachs.Items.Add(z.FileName)
            If lbAttachs.Items.Count = 1 Then
                lblCountAttachs.Text = CStr(lbAttachs.Items.Count) + " Anhang"
            ElseIf lbAttachs.Items.Count = 0 OrElse lbAttachs.Items.Count > 1 Then
                lblCountAttachs.Text = CStr(lbAttachs.Items.Count) + " Anhänge"
            End If
        End If
    End Sub

    Private Sub ToolStripButton18_Click(sender As System.Object, e As System.EventArgs)
        If lbAttachs.SelectedItems.Count > 0 Then
            If MsgBox("Möchten Sie die Datei '" + lbAttachs.SelectedItem.ToString + "' wirklich aus den Anhängen entfernen?", MsgBoxStyle.YesNo, "Anhang entfernen? - justMail") = MsgBoxResult.Yes Then
                lbAttachs.Items.RemoveAt(lbAttachs.SelectedIndex)
                If lbAttachs.Items.Count = 1 Then
                    lblCountAttachs.Text = CStr(lbAttachs.Items.Count) + " Anhang"
                ElseIf lbAttachs.Items.Count = 0 OrElse lbAttachs.Items.Count > 1 Then
                    lblCountAttachs.Text = CStr(lbAttachs.Items.Count) + " Anhänge"
                End If
            End If
        End If
    End Sub

    Private Sub ToolStripButton10_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton10.Click
        wbHTML.Document.ExecCommand("FontName", False, Nothing)
    End Sub

    Private Sub ToolStripButton11_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton11.Click
        wbHTML.Document.ExecCommand("Bold", False, Nothing)
    End Sub

    Private Sub ToolStripButton12_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton12.Click
        wbHTML.Document.ExecCommand("Italic", False, Nothing)
    End Sub

    Private Sub ToolStripButton13_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton13.Click
        wbHTML.Document.ExecCommand("Underline", False, Nothing)
    End Sub

    Private Sub ToolStripButton14_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton14.Click
        wbHTML.Document.ExecCommand("JustifyLeft", False, Nothing)
    End Sub

    Private Sub ToolStripButton15_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton15.Click
        wbHTML.Document.ExecCommand("JustifyCenter", False, Nothing)
    End Sub

    Private Sub ToolStripButton16_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton16.Click
        wbHTML.Document.ExecCommand("JustifyRight", False, Nothing)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click
        wbHTML.Document.ExecCommand("InsertImage", False, Nothing)
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem2.Click
        wbHTML.Document.ExecCommand("CreateLink", False, Nothing)
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs)
        htmlText = (wbHTML.DocumentText.Replace("ä", "&auml;").Replace("Ä", "&Auml;").Replace("Ü", "&Uuml;").Replace("ü", "&uuml;").Replace("Ö", "&Ouml;").Replace("ö", "&ouml;").Replace("ß", "&szlig;").Replace("€", "&euro;").Replace("©", "&copy;").Replace("<META name=GENERATOR content=" + """" + "MSHTML 10.00.9200.16721" + """" + "></HEAD>", "<META name=GENERATOR content=" + """" + "justMail " + My.Application.Info.Version.ToString + """" + "></HEAD>"))
        MsgBox(htmlText)
    End Sub

    Private Sub HorizontaleLinieToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HorizontaleLinieToolStripMenuItem.Click
        wbHTML.Document.ExecCommand("InsertHorizontalRule", False, Nothing)
    End Sub

    Private Sub MenuItem23_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem23.Click
        wbHTML.Document.ExecCommand("InsertHorizontalRule", False, Nothing)
    End Sub

    Private Sub ToolStripButton19_Click(sender As System.Object, e As System.EventArgs)
        wbHTML.Document.ExecCommand("FormatBlock", False, Nothing)
    End Sub

    Private Sub WebBrowser1_PreviewKeyDown(sender As Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles wbHTML.PreviewKeyDown
        edited = True
    End Sub

    Private Sub KryptonButton2_Click(sender As Object, e As EventArgs) Handles btnRemoveAttach.Click
        If lbAttachs.SelectedItems.Count > 0 Then
            If MsgBox("Möchten Sie die Datei '" + lbAttachs.SelectedItem.ToString + "' wirklich aus den Anhängen entfernen?", MsgBoxStyle.YesNo, "Anhang entfernen? - justMail") = MsgBoxResult.Yes Then
                lbAttachs.Items.RemoveAt(lbAttachs.SelectedIndex)
                If lbAttachs.Items.Count = 1 Then
                    lblCountAttachs.Text = CStr(lbAttachs.Items.Count) + " Anhang"
                ElseIf lbAttachs.Items.Count = 0 OrElse lbAttachs.Items.Count > 1 Then
                    lblCountAttachs.Text = CStr(lbAttachs.Items.Count) + " Anhänge"
                End If
            End If
        End If
    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles btnAddAttach.Click
        Dim z As New OpenFileDialog
        z.Filter = "Alle Dateien (*.*)|*.*"
        If z.ShowDialog = Windows.Forms.DialogResult.OK Then
            lbAttachs.Items.Add(z.FileName)
            If lbAttachs.Items.Count = 1 Then
                lblCountAttachs.Text = CStr(lbAttachs.Items.Count) + " Anhang"
            ElseIf lbAttachs.Items.Count = 0 OrElse lbAttachs.Items.Count > 1 Then
                lblCountAttachs.Text = CStr(lbAttachs.Items.Count) + " Anhänge"
            End If
        End If
    End Sub

    Private Function btnAttach() As Object
        Throw New NotImplementedException
    End Function

End Class