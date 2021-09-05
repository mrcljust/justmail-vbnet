Imports System.Runtime.InteropServices
Public Class frmShowEmailInWindow

    Dim i As Integer = 0

    Const SORTIERSPALTE_INDEX = 0

    Private Const DISABLE_SOUNDS As Integer = 21
    Private Const SET_FEATURE_ON_PROCESS As Integer = 2

    <DllImport("urlmon.dll")> _
    Public Shared Function CoInternetSetFeatureEnabled( _
    ByVal FeatureEntry As Integer, <MarshalAs(UnmanagedType.U4)> ByVal dwFlags As Integer, ByVal fEnable As Boolean) As Integer

    End Function

    Private Sub rtbEmailPreview_LinkClicked(sender As Object, e As System.Windows.Forms.LinkClickedEventArgs) Handles rtbEmailPreview.LinkClicked
        Process.Start(e.LinkText)
    End Sub

    Private Sub wbPreviewEmail_Navigated(sender As Object, e As Gecko.GeckoNavigatedEventArgs) Handles wbPreviewEmail.Navigated
        i += 1
    End Sub

    Private Sub wbPreviewEmail_Navigating(sender As Object, e As Gecko.Events.GeckoNavigatingEventArgs) Handles wbPreviewEmail.Navigating
        If i = 2 Then
            Process.Start(e.Uri.ToString)
            e.Cancel = True
        End If
    End Sub

    Private Sub frmShowEmailInWindow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        frmMain.windowFormINT = 0
    End Sub

    Private Sub frmShowEmailInWindow_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CoInternetSetFeatureEnabled(DISABLE_SOUNDS, SET_FEATURE_ON_PROCESS, True)
    End Sub

    Private Sub wbPreviewEmail_Click(sender As System.Object, e As System.EventArgs) Handles wbPreviewEmail.Click

    End Sub
End Class