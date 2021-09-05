Imports System.Windows.Forms.VisualStyles

Public Class AdvancedListbox
    Inherits ListBox

    Const LVP_GROUPHEADER As Integer = 6
    Const LVGH_OPENSELECTEDNOTFOCUSEDHOT As Integer = 6
    Private renderer As New VisualStyleRenderer(VisualStyleElement.CreateElement("LISTVIEW", LVP_GROUPHEADER, LVGH_OPENSELECTEDNOTFOCUSEDHOT))

    Private Sub FirefoxListbox_DrawItem(sender As Object, e As System.Windows.Forms.DrawItemEventArgs) Handles Me.DrawItem
        e.Graphics.Clip = New Region(e.Bounds)
        e.Graphics.Clear(Color.White)
        renderer.DrawBackground(e.Graphics, e.Bounds)
    End Sub

    Public Sub New()
        Me.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ItemHeight = 72
        Me.IntegralHeight = False 'finde ich einfach besser
    End Sub
End Class