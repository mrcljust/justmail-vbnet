Public Class frmCredits

    Private Sub frmCredits_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblVersion.Text = "Version " + My.Application.Info.Version.ToString
    End Sub

    Private Sub AeroLinkLabel1_Click(sender As System.Object, e As System.EventArgs) Handles AeroLinkLabel1.Click
        Process.Start("http://it-just.net")
    End Sub

    Private Sub AeroLinkLabel2_Click(sender As System.Object, e As System.EventArgs)
        Process.Start("http://it-just.net/facebook")
    End Sub

    Private Sub AeroLinkLabel3_Click(sender As System.Object, e As System.EventArgs)
        Process.Start("http://it-just.net/twitter")
    End Sub
End Class