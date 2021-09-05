Public Class frmAddressBook

    Private Sub btnNewEmail_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Dim z As New frmAddContact
        z.ShowDialog(Me)
    End Sub

    Private Sub frmAddressBook_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("contacts") + "\").Count = 0 Then
            For Each n As TreeNode In frmMain.tvAccounts.Nodes
                Dim z As New TreeNode
                z.NodeFont = New Font(tvContacts.Font, FontStyle.Bold)
                z.Text = "Ich (" + n.Text + ")"
                tvContacts.Nodes.Add(z)
            Next
        Else
            For Each n As TreeNode In frmMain.tvAccounts.Nodes
                Dim z As New TreeNode
                z.NodeFont = New Font(tvContacts.Font, FontStyle.Bold)
                z.Text = "Ich (" + n.Text + ")"
                tvContacts.Nodes.Add(z)
            Next
            For Each d As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("contacts") + "\")
                tvContacts.Nodes.Add(cdc(IO.File.ReadAllText(d + "\n")) + " (" + cdc(IO.File.ReadAllText(d + "\em")) + ")")
            Next
        End If
    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        Dim EMAIL1 As New List(Of String)
        EMAIL1.AddRange(Split(tvContacts.SelectedNode.Text, "("))
        Dim EMAIL2 As New List(Of String)
        EMAIL2.AddRange(Split(EMAIL1(1), ")"))
        Dim EMAIL As String = EMAIL2(0)
        Dim exists As Boolean = False
        For Each z As TreeNode In frmMain.tvAccounts.Nodes
            If z.Text = EMAIL Then
                exists = True
            End If
        Next
        If exists = False Then
            If MsgBox("Kontakt '" + tvContacts.SelectedNode.Text + "' wirklich aus dem Adressbuch entfernen?", MsgBoxStyle.YesNo, "Kontakt entfernen? - Adressbuch - justMail") = MsgBoxResult.Yes Then
                For Each d As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("contacts") + "\")
                    If tvContacts.SelectedNode.Text = cdc(IO.File.ReadAllText(d + "\n")) + " (" + cdc(IO.File.ReadAllText(d + "\em")) + ")" Then
                        IO.Directory.Delete(d, True)
                        tvContacts.SelectedNode.Remove()
                        Exit For
                    End If
                Next
            End If
        Else
            MsgBox("Sie können ihre eigene E-Mail-Adresse nicht entfernen.", MsgBoxStyle.Exclamation, "Fehler beim Entfernen - Adressbuch - justMail")
        End If
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        Dim EMAIL1 As New List(Of String)
        EMAIL1.AddRange(Split(tvContacts.SelectedNode.Text, "("))
        Dim EMAIL2 As New List(Of String)
        EMAIL2.AddRange(Split(EMAIL1(1), ")"))
        Dim EMAIL As String = EMAIL2(0)
        Dim exists As Boolean = False
        For Each z As TreeNode In frmMain.tvAccounts.Nodes
            If z.Text = EMAIL Then
                exists = True
            End If
        Next
        If exists = False Then
            Dim NAMESPLIT1 As New List(Of String)
            NAMESPLIT1.AddRange(Split(tvContacts.SelectedNode.Text, "("))
            Dim part1 As String = NAMESPLIT1(1)
            Dim NAMESPLIT2 As New List(Of String)
            NAMESPLIT2.AddRange(Split(part1, ")"))
            Dim email00 As String = NAMESPLIT2(0)
            Dim name As String = ""
            Dim tel As String = ""
            Dim fax As String = ""
            Dim place As String = ""
            For Each d As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("contacts") + "\")
                If cdc(IO.File.ReadAllText(d + "\em")) = email00 Then
                    name = cdc(IO.File.ReadAllText(d + "\n"))
                    tel = cdc(IO.File.ReadAllText(d + "\tl"))
                    fax = cdc(IO.File.ReadAllText(d + "\fx"))
                    place = cdc(IO.File.ReadAllText(d + "\pl"))
                    Exit For
                End If
            Next
            Dim z As New frmEditContact
            z.beforeEmail = email00
            z.tbEmail.Text = email00
            z.tbName.Text = name
            z.tbPlace.Text = place
            z.tbFax.Text = fax
            z.tbTelephone.Text = tel
            z.ShowDialog()
        Else
            MsgBox("Sie können ihre eigene E-Mail-Adresse nicht bearbeiten.", MsgBoxStyle.Exclamation, "Fehler beim Bearbeiten - Adressbuch - justMail")
        End If
    End Sub

    Private Sub tvContacts_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvContacts.AfterSelect
        Dim EMAIL1 As New List(Of String)
        EMAIL1.AddRange(Split(tvContacts.SelectedNode.Text, "("))
        Dim EMAIL2 As New List(Of String)
        EMAIL2.AddRange(Split(EMAIL1(1), ")"))
        Dim EMAIL As String = EMAIL2(0)

        Dim exists As Boolean = False
        For Each z As TreeNode In frmMain.tvAccounts.Nodes
            If z.Text = EMAIL Then
                exists = True
            End If
        Next
        If exists = False Then
            For Each d As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("contacts") + "\")
                If cdc(IO.File.ReadAllText(d + "\em")) = EMAIL Then
                    tbEmail.Text = cdc(IO.File.ReadAllText(d + "\em"))
                    tbName.Text = cdc(IO.File.ReadAllText(d + "\n"))
                    tbPlace.Text = cdc(IO.File.ReadAllText(d + "\pl"))
                    tbTelephone.Text = cdc(IO.File.ReadAllText(d + "\tl"))
                    tbFax.Text = cdc(IO.File.ReadAllText(d + "\fx"))
                    lblDateAdded.Text = "Hinzugefügt am " + cdc(IO.File.ReadAllText(d + "\dt"))
                End If
            Next
        Else
            tbEmail.Text = EMAIL
            tbName.Text = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + EMAIL + "\nm"))
            lblDateAdded.Text = "Hinzugefügt am " + cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + EMAIL + "\dA")) + " " + cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + EMAIL + "\tA"))
            tbPlace.Text = ""
            tbTelephone.Text = ""
            tbFax.Text = ""
        End If
    End Sub

    Private Sub btnNewEmail_Click_1(sender As System.Object, e As System.EventArgs) Handles btnNewEmail.Click
        Dim EMAIL1 As New List(Of String)
        EMAIL1.AddRange(Split(tvContacts.SelectedNode.Text, "("))
        Dim EMAIL2 As New List(Of String)
        EMAIL2.AddRange(Split(EMAIL1(1), ")"))
        Dim EMAIL As String = EMAIL2(0)

        Dim EMAIL10 As New List(Of String)
        EMAIL10.AddRange(Split(tvContacts.Nodes(0).Text, "("))
        Dim EMAIL20 As New List(Of String)
        EMAIL20.AddRange(Split(EMAIL10(1), ")"))
        Dim EMAIL0 As String = EMAIL20(0)
        Dim z As New frmNewEmail
        z.inUseEmail = EMAIL0
        z.selectname = cdc(IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\" + EMAIL0 + "\nm")) + " (" + EMAIL0 + ")"
        z.tbTo.Text = EMAIL
        z.tbSubject.Focus()
        z.ShowDialog()
    End Sub
End Class