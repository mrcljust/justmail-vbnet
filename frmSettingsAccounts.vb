Public Class frmSettingsAccounts

    Private Sub frmSettingsAccounts_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmMain.Enabled = True
    End Sub

    Private Sub frmSettingsAccounts_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If frmMain.Visible = True Then
            frmMain.Enabled = True
            frmMain.Focus()
        End If
    End Sub

    Private Sub frmSettingsAccounts_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "").Count = 0 Then
            frmAddEmail.Show()
            Me.Close()
        Else
            For Each z As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "")
                'Dim treeN As TreeNode = New TreeNode(z)
                Dim usepop3 As Boolean
                Dim n As String = z.Replace("C:\Users\" + Environment.UserName + "\AppData\Roaming\justMail\" + cc("accounts") + "\", "")

                If cdc(IO.File.ReadAllText(z + "\mtd")) = "pop3" Then
                    usepop3 = True
                Else
                    usepop3 = False
                End If
                Dim node As New TreeNode With {.Name = n, .Text = z.Replace("C:\Users\" + Environment.UserName + "\AppData\Roaming\justMail\" + cc("accounts") + "\", "")}
                If usepop3 = True Then
                    node.Nodes.Add("POP3")
                    node.Nodes.Add("SMTP")
                    node.Nodes.Add("E-Mail-Einstellungen")
                    tvAccounts.Nodes.Add(node)
                Else
                    node.Nodes.Add("IMAP")
                    node.Nodes.Add("SMTP")
                    node.Nodes.Add("E-Mail-Einstellungen")
                    tvAccounts.Nodes.Add(node)
                End If
            Next
            tvAccounts.ExpandAll()
        End If
    End Sub

    Private Sub tvAccounts_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvAccounts.AfterSelect
        If tvAccounts.SelectedNode.Text = "POP3" Then
            lblTitle.Text = "POP3 Einstellungen"
            Label1.Text = "POP3 Server"
            Label2.Text = "POP3 Port"
            RadioButton1.Text = "POP3 E-Mails auf dem Computer speichern"


            btnRemoveAcc.Visible = False

            KryptonTextBox1.ReadOnly = False
            KryptonTextBox2.ReadOnly = False
            KryptonTextBox3.ReadOnly = False

            KryptonTextBox1.Enabled = True
            KryptonTextBox2.Enabled = True
            KryptonTextBox3.Enabled = True

            RadioButton1.Checked = True
            Label1.Visible = True
            Label2.Visible = True
            RadioButton1.Visible = True
            Label3.Visible = False
            KryptonTextBox3.Visible = False
            Label4.Visible = False
            Label5.Visible = False
            KryptonTextBox1.Text = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tvAccounts.SelectedNode.Parent.Text + "\p3s"))
            KryptonTextBox2.Text = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tvAccounts.SelectedNode.Parent.Text + "\p3p"))

            lblEmail.Text = tvAccounts.SelectedNode.Parent.Text
        ElseIf tvAccounts.SelectedNode.Text = "IMAP" Then
            lblTitle.Text = "IMAP Einstellungen"
            Label1.Text = "IMAP Server"
            Label2.Text = "IMAP Port"
            RadioButton1.Text = "IMAP E-Mails auf dem Computer speichern"

            btnRemoveAcc.Visible = False

            KryptonTextBox1.ReadOnly = False
            KryptonTextBox2.ReadOnly = False
            KryptonTextBox3.ReadOnly = False

            KryptonTextBox1.Enabled = True
            KryptonTextBox2.Enabled = True
            KryptonTextBox3.Enabled = True

            RadioButton1.Checked = True
            Label1.Visible = True
            Label2.Visible = True
            RadioButton1.Visible = True
            KryptonTextBox3.Visible = False
            Label3.Visible = False
            Label4.Visible = False
            Label5.Visible = False
            KryptonTextBox1.Text = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tvAccounts.SelectedNode.Parent.Text + "\ims"))
            KryptonTextBox2.Text = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tvAccounts.SelectedNode.Parent.Text + "\imp"))

            lblEmail.Text = tvAccounts.SelectedNode.Parent.Text
        ElseIf tvAccounts.SelectedNode.Text = "SMTP" Then
            lblTitle.Text = "SMTP Einstellungen"
            Label1.Text = "SMTP Server"
            Label2.Text = "SMTP Port"
            RadioButton1.Text = "SMTP E-Mails auf dem Computer speichern"

            btnRemoveAcc.Visible = False

            KryptonTextBox1.ReadOnly = False
            KryptonTextBox2.ReadOnly = False
            KryptonTextBox3.ReadOnly = False

            KryptonTextBox1.Enabled = True
            KryptonTextBox2.Enabled = True
            KryptonTextBox3.Enabled = True

            RadioButton1.Checked = True
            Label1.Visible = True
            Label2.Visible = True
            RadioButton1.Visible = True
            KryptonTextBox3.Visible = False
            Label3.Visible = False
            Label4.Visible = False
            Label5.Visible = False
            KryptonTextBox1.Text = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tvAccounts.SelectedNode.Parent.Text + "\ss"))
            KryptonTextBox2.Text = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tvAccounts.SelectedNode.Parent.Text + "\sp"))

            lblEmail.Text = tvAccounts.SelectedNode.Parent.Text
        ElseIf tvAccounts.SelectedNode.Text = "E-Mail-Einstellungen" Then
            lblTitle.Text = "E-Mail Einstellungen"
            lblEmail.Text = tvAccounts.SelectedNode.Parent.Text
            Label1.Visible = False
            Label2.Visible = False
            Label3.Visible = False
            Label4.Visible = False
            Label5.Visible = False
            KryptonTextBox1.Visible = False
            KryptonTextBox2.Visible = False
            KryptonTextBox3.Visible = False
            RadioButton1.Visible = False
            btnRemoveAcc.Visible = True
        Else
            lblTitle.Text = "Zusammenfassung"
            Label1.Text = "E-Mails im Posteingang"
            Label2.Text = "E-Mails im Postausgang"
            Label3.Text = "Hinzugefügt am"


            btnRemoveAcc.Visible = False

            KryptonTextBox1.ReadOnly = True
            KryptonTextBox2.ReadOnly = True
            KryptonTextBox3.ReadOnly = True

            KryptonTextBox1.Enabled = False
            KryptonTextBox2.Enabled = False
            KryptonTextBox3.Enabled = False

            Label1.Visible = True
            Label2.Visible = True
            RadioButton1.Visible = False
            Label3.Visible = False
            KryptonTextBox3.Visible = True
            Label3.Visible = True
            Label4.Visible = False
            Label5.Visible = False
            KryptonTextBox1.Text = CStr(IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tvAccounts.SelectedNode.Text + "\sM").Count)
            KryptonTextBox2.Text = CStr(IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tvAccounts.SelectedNode.Text + "\osM").Count)
            KryptonTextBox3.Text = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tvAccounts.SelectedNode.Text + "\dA")) + " - " + cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tvAccounts.SelectedNode.Text + "\tA"))

            lblEmail.Text = tvAccounts.SelectedNode.Text
        End If
    End Sub

    Private Sub btnRemoveAcc_Click(sender As System.Object, e As System.EventArgs) Handles btnRemoveAcc.Click
        If MsgBox("Möchten Sie das E-Mail-Konto '" + tvAccounts.SelectedNode.Parent.Text + "' wirklich löschen?" + vbCrLf + "Es wird für immer gelöscht sein!", MsgBoxStyle.YesNo, "E-Mail-Konto wirklich löschen? - justMail") = MsgBoxResult.Yes Then
            IO.Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + tvAccounts.SelectedNode.Parent.Text, True)
                    frmMain.tvAccounts.Nodes.RemoveByKey(tvAccounts.SelectedNode.Parent.Text)
                    tvAccounts.Nodes.Remove(tvAccounts.SelectedNode.Parent)
        End If
    End Sub
End Class