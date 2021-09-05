<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFirst
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFirst))
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.btnOk = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.HeaderPanel1 = New AeroControls.HeaderPanel()
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.SeperatorLabel1 = New AeroControls.SeperatorLabel()
        Me.HeaderPanel1.SuspendLayout()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.Gray
        Me.lblInfo.Location = New System.Drawing.Point(8, 58)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(356, 105)
        Me.lblInfo.TabIndex = 5
        Me.lblInfo.Text = "Da Sie noch kein Konto eingerichtet haben, sollten" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sie zu Anfang Ihr erstes Kont" & _
    "o einrichten." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Der Setup Assistent wird Sie nun durch die" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Kontoeinrichtung fü" & _
    "hren."
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(91, 179)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(191, 28)
        Me.btnOk.TabIndex = 6
        Me.btnOk.Values.Text = "Weiter"
        '
        'HeaderPanel1
        '
        Me.HeaderPanel1.Caption = "Herzlich Willkommen..."
        Me.HeaderPanel1.Controls.Add(Me.pbLogo)
        Me.HeaderPanel1.Controls.Add(Me.SeperatorLabel1)
        Me.HeaderPanel1.Description = "...bei justMail"
        Me.HeaderPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderPanel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.HeaderPanel1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HeaderPanel1.Location = New System.Drawing.Point(0, 0)
        Me.HeaderPanel1.Name = "HeaderPanel1"
        Me.HeaderPanel1.Size = New System.Drawing.Size(373, 55)
        Me.HeaderPanel1.TabIndex = 70
        '
        'pbLogo
        '
        Me.pbLogo.Image = Global.justMail.My.Resources.Resources.icon
        Me.pbLogo.Location = New System.Drawing.Point(328, 6)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(42, 42)
        Me.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbLogo.TabIndex = 71
        Me.pbLogo.TabStop = False
        '
        'SeperatorLabel1
        '
        Me.SeperatorLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SeperatorLabel1.Location = New System.Drawing.Point(-8, 48)
        Me.SeperatorLabel1.Name = "SeperatorLabel1"
        Me.SeperatorLabel1.SeperatorColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.SeperatorLabel1.Size = New System.Drawing.Size(396, 10)
        Me.SeperatorLabel1.TabIndex = 70
        Me.SeperatorLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmFirst
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 219)
        Me.Controls.Add(Me.HeaderPanel1)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.lblInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmFirst"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Herzlich Willkommen - justMail"
        Me.HeaderPanel1.ResumeLayout(False)
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents btnOk As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents HeaderPanel1 As AeroControls.HeaderPanel
    Friend WithEvents SeperatorLabel1 As AeroControls.SeperatorLabel
    Friend WithEvents pbLogo As System.Windows.Forms.PictureBox

End Class
