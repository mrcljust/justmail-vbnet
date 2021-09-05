Public Class frmFirst

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        frmAddEmail.Show()
        Me.Close()
    End Sub

    Private Sub frmFirst_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        configSetup()
    End Sub
End Class
