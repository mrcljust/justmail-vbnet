Public Class frmAddContact
    Public adbOpened As Boolean = False
    Private Sub frmAddContact_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If adbOpened = True Then
            frmAddressBook.Enabled = True
            frmAddressBook.Focus()
        Else
        End If
    End Sub

    Private Sub frmAddContact_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub tmrEnableOkButton_Tick(sender As System.Object, e As System.EventArgs) Handles tmrEnableOkButton.Tick
        If Not tbName.Text = "" And Not tbEmail.Text = "" Then
            btnOk.Enabled = True
        Else
            btnOk.Enabled = False
        End If
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        Dim reason As Integer = 0
        If Not tbEmail.Text.Contains("@") Then
            MsgBox("Bitte geben Sie eine existierende E-Mail-Adresse ein.", MsgBoxStyle.Exclamation, "Fehler beim Hinzufügen des Kontaktes '" + tbName.Text + "' - justMail")
        ElseIf tbName.Text.Contains("(") Then
            MsgBox("Die Zeichen '(' sowie ')' dürfen nicht im Namen/E-Mail-Adresse verwendet werden.", MsgBoxStyle.Exclamation, "Fehler beim Hinzufügen des Kontaktes '" + tbName.Text + "' - justMail")
        ElseIf tbName.Text.Contains(")") Then
            MsgBox("Die Zeichen '(' sowie ')' dürfen nicht im Namen/E-Mail-Adresse verwendet werden.", MsgBoxStyle.Exclamation, "Fehler beim Hinzufügen des Kontaktes '" + tbName.Text + "' - justMail")
        ElseIf tbEmail.Text.Contains("(") Then
            MsgBox("Die Zeichen '(' sowie ')' dürfen nicht im Namen/E-Mail-Adresse verwendet werden.", MsgBoxStyle.Exclamation, "Fehler beim Hinzufügen des Kontaktes '" + tbName.Text + "' - justMail")
        ElseIf tbEmail.Text.Contains(")") Then
            MsgBox("Die Zeichen '(' sowie ')' dürfen nicht im Namen/E-Mail-Adresse verwendet werden.", MsgBoxStyle.Exclamation, "Fehler beim Hinzufügen des Kontaktes '" + tbName.Text + "' - justMail")
        Else
            Dim exists As Boolean = False
            For Each d As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("contacts") + "\")
                If cdc(IO.File.ReadAllText(d + "\em")) = tbEmail.Text Then
                    exists = True
                    reason = 2
                End If
            Next
            For Each tvi As TreeNode In frmMain.tvAccounts.Nodes
                If tbEmail.Text = tvi.Text Then
                    reason = 1
                    exists = True
                End If
            Next
            If exists = False Then
                Dim pth As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("contacts") + "\" + CStr(myScc)
                myScc += 1 : saveConfigFile()
                IO.Directory.CreateDirectory(pth)
                IO.File.WriteAllText(pth + "\n", cc(tbName.Text))
                IO.File.WriteAllText(pth + "\em", cc(tbEmail.Text))
                IO.File.WriteAllText(pth + "\dt", cc(CStr(Format(DateTime.Now, "dd.MM.yyyy hh:mm:ss"))))
                IO.File.WriteAllText(pth + "\pl", cc(tbPlace.Text))
                IO.File.WriteAllText(pth + "\tl", cc(tbTelephone.Text))
                IO.File.WriteAllText(pth + "\fx", cc(tbFax.Text))
                If frmAddressBook.Visible = True Then
                    frmAddressBook.tvContacts.Nodes.Add(tbName.Text + " (" + tbEmail.Text + ")")
                End If
                Me.Close()
            Else
                If reason = 1 Then
                    MsgBox("Sie können sich nicht selbst hinzufügen, da ihre E-Mail-Adressen standartmäßig im Adressbuch gespeichert sind.", MsgBoxStyle.Exclamation, "Fehler beim Hinzufügen des Kontaktes '" + tbName.Text + "' - justMail")
                Else
                    MsgBox("Ein Kontakt mit der E-Mail-Adresse '" + tbEmail.Text + "' existiert bereits.", MsgBoxStyle.Exclamation, "Fehler beim Hinzufügen des Kontaktes '" + tbName.Text + "' - justMail")

                End If
            End If
        End If
    End Sub
End Class