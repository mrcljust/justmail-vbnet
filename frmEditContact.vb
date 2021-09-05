Public Class frmEditContact

    Public adbOpened As Boolean = False
    Public beforeEmail As String = ""

    Private Sub frmEditContact_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If adbOpened = True Then
            frmAddressBook.Enabled = True
            frmAddressBook.Focus()
        Else
        End If
    End Sub

    Private Sub frmEditContact_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
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
            If Not tbEmail.Text = beforeEmail Then
                For Each d As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("contacts") + "\")
                    If cdc(IO.File.ReadAllText(d + "\em")) = tbEmail.Text Then
                        exists = True
                    End If
                Next
            End If
            If exists = False Then
                If tbEmail.Text = beforeEmail Then
                    For Each d As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("contacts") + "\")
                        If cdc(IO.File.ReadAllText(d + "\em")) = beforeEmail Then
                            IO.File.WriteAllText(d + "\n", cc(tbName.Text))
                            IO.File.WriteAllText(d + "\em", cc(tbEmail.Text))
                            IO.File.WriteAllText(d + "\dt", cc(CStr(Format(DateTime.Now, "dd.MM.yyyy hh:mm:ss"))))
                            IO.File.WriteAllText(d + "\pl", cc(tbPlace.Text))
                            IO.File.WriteAllText(d + "\tl", cc(tbTelephone.Text))
                            IO.File.WriteAllText(d + "\fx", cc(tbFax.Text))
                        End If
                    Next
                Else
                    Dim pth As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("contacts") + "\" + CStr(myScc)
                    myScc += 1 : saveConfigFile()
                    IO.Directory.CreateDirectory(pth)
                    IO.File.WriteAllText(pth + "\n", cc(tbName.Text))
                    IO.File.WriteAllText(pth + "\em", cc(tbEmail.Text))
                    IO.File.WriteAllText(pth + "\dt", cc(CStr(Format(DateTime.Now.AddHours(12), "dd.MM.yyyy hh:mm:ss"))))
                    IO.File.WriteAllText(pth + "\pl", cc(tbPlace.Text))
                    IO.File.WriteAllText(pth + "\tl", cc(tbTelephone.Text))
                    IO.File.WriteAllText(pth + "\fx", cc(tbFax.Text))
                    For Each d As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("contacts") + "\")
                        If cdc(IO.File.ReadAllText(d + "\em")) = beforeEmail Then
                            IO.Directory.Delete(d, True)
                            Exit For
                        End If
                    Next
                End If
                If frmAddressBook.Visible = True Then
                    frmAddressBook.tvContacts.SelectedNode.Remove()
                    frmAddressBook.tvContacts.Nodes.Add(tbName.Text + " (" + tbEmail.Text + ")")
                End If
                Me.Close()
            Else
                MsgBox("Ein Kontakt mit der E-Mail-Adresse '" + tbEmail.Text + "' existiert bereits.", MsgBoxStyle.Exclamation, "Fehler beim Hinzufügen des Kontaktes '" + tbName.Text + "' - justMail")
            End If
            End If
    End Sub

    Private Sub tmrEnableOkButton_Tick(sender As System.Object, e As System.EventArgs) Handles tmrEnableOkButton.Tick
        If Not tbName.Text = "" And Not tbEmail.Text = "" Then
            btnOk.Enabled = True
        Else
            btnOk.Enabled = False
        End If
    End Sub
End Class