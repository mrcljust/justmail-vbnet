<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShowEmailInWindow
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmShowEmailInWindow))
        Me.rtbEmailPreview = New System.Windows.Forms.RichTextBox()
        Me.wbPreviewEmail = New Gecko.GeckoWebBrowser()
        Me.SuspendLayout()
        '
        'rtbEmailPreview
        '
        Me.rtbEmailPreview.DetectUrls = False
        Me.rtbEmailPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbEmailPreview.Location = New System.Drawing.Point(0, 0)
        Me.rtbEmailPreview.Name = "rtbEmailPreview"
        Me.rtbEmailPreview.ReadOnly = True
        Me.rtbEmailPreview.ShortcutsEnabled = False
        Me.rtbEmailPreview.Size = New System.Drawing.Size(984, 612)
        Me.rtbEmailPreview.TabIndex = 1
        Me.rtbEmailPreview.Text = ""
        '
        'wbPreviewEmail
        '
        Me.wbPreviewEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbPreviewEmail.Location = New System.Drawing.Point(0, 0)
        Me.wbPreviewEmail.Name = "wbPreviewEmail"
        Me.wbPreviewEmail.NoDefaultContextMenu = True
        Me.wbPreviewEmail.Size = New System.Drawing.Size(984, 612)
        Me.wbPreviewEmail.TabIndex = 2
        Me.wbPreviewEmail.UseHttpActivityObserver = False
        Me.wbPreviewEmail.UseWaitCursor = True
        '
        'frmShowEmailInWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 612)
        Me.Controls.Add(Me.wbPreviewEmail)
        Me.Controls.Add(Me.rtbEmailPreview)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmShowEmailInWindow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "justMail"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rtbEmailPreview As System.Windows.Forms.RichTextBox
    Friend WithEvents wbPreviewEmail As Gecko.GeckoWebBrowser
End Class
