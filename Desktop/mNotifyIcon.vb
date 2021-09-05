Module mNotifyIcon
    Public notifyIconM As New NotifyIcon

    Public Sub showNotify(ByVal icon As ToolTipIcon, ByVal title As String, ByVal text As String, ByVal time As Integer)
        z.Interval = 10
        z.Enabled = True
        notifyIconM.Icon = frmMain.Icon
        notifyIconM.BalloonTipTitle = title
        notifyIconM.BalloonTipIcon = icon
        notifyIconM.BalloonTipText = text
        notifyIconM.Text = frmMain.Text
        notifyIconM.Visible = True
        notifyIconM.ShowBalloonTip(time)
    End Sub

    WithEvents z As New Timer


    Private Sub z_Tick(sender As Object, e As System.EventArgs) Handles z.Tick
        If frmMain.Enabled = True Then
            notifyIconM.Text = frmMain.Text
        ElseIf frmAddEmail.Visible = True Then
            notifyIconM.Text = frmAddEmail.Text
        ElseIf frmAddEmailPersonal.Visible = True Then
            notifyIconM.Text = frmAddEmailPersonal.Text
        ElseIf frmFirst.Visible = True Then
            notifyIconM.Text = frmFirst.Text
        ElseIf frmNewEmail.Visible = True Then
            notifyIconM.Text = "Neue E-MailjustMail"
        ElseIf frmSettingsAccounts.Visible = True Then
            notifyIconM.Text = frmSettingsAccounts.Text
        End If
    End Sub
End Module