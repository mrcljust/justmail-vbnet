Public Class frmJunkFilter

    Private Sub frmJunkFilter_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        tvAccounts.Nodes.Clear()
        For Each s As String In IO.Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\")
            Dim tP As New TreeNode
            tP.Text = s.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\justMail\" + cc("accounts") + "\", "")
            tvAccounts.Nodes.Add(tP)
        Next
    End Sub

    Private Sub btnNewEmail_Click(sender As System.Object, e As System.EventArgs) Handles btnNewEmail.Click
        Dim frm As New frmAddJunkFilter
        frm.HeaderPanel1.Description = "für " + tvAccounts.SelectedNode.Text
        frm.ShowDialog(Me)
    End Sub
End Class