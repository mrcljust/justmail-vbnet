<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.lblLocalVersionInfo = New System.Windows.Forms.Label()
        Me.lblLocalVersion = New System.Windows.Forms.Label()
        Me.lblNewestVersionInfo = New System.Windows.Forms.Label()
        Me.lblNewestVersion = New System.Windows.Forms.Label()
        Me.lblSeperator2 = New System.Windows.Forms.Panel()
        Me.lblQuestion = New System.Windows.Forms.Label()
        Me.btnYes = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnNo = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.bgw1 = New System.ComponentModel.BackgroundWorker()
        Me.tmrCheckBusy = New System.Windows.Forms.Timer(Me.components)
        Me.bgw2 = New System.ComponentModel.BackgroundWorker()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.HeaderPanel1 = New AeroControls.HeaderPanel()
        Me.SeperatorLabel1 = New AeroControls.SeperatorLabel()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbLogo
        '
        Me.pbLogo.Image = Global.justMail_Updater.My.Resources.Resources.blue
        Me.pbLogo.Location = New System.Drawing.Point(335, 6)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(35, 35)
        Me.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbLogo.TabIndex = 10
        Me.pbLogo.TabStop = False
        '
        'lblLocalVersionInfo
        '
        Me.lblLocalVersionInfo.AutoSize = True
        Me.lblLocalVersionInfo.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocalVersionInfo.Location = New System.Drawing.Point(81, 66)
        Me.lblLocalVersionInfo.Name = "lblLocalVersionInfo"
        Me.lblLocalVersionInfo.Size = New System.Drawing.Size(105, 20)
        Me.lblLocalVersionInfo.TabIndex = 11
        Me.lblLocalVersionInfo.Text = "Lokale Version"
        Me.lblLocalVersionInfo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLocalVersion
        '
        Me.lblLocalVersion.AutoSize = True
        Me.lblLocalVersion.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocalVersion.Location = New System.Drawing.Point(205, 65)
        Me.lblLocalVersion.Name = "lblLocalVersion"
        Me.lblLocalVersion.Size = New System.Drawing.Size(55, 21)
        Me.lblLocalVersion.TabIndex = 12
        Me.lblLocalVersion.Text = "0.0.0.0"
        '
        'lblNewestVersionInfo
        '
        Me.lblNewestVersionInfo.AutoSize = True
        Me.lblNewestVersionInfo.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewestVersionInfo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNewestVersionInfo.Location = New System.Drawing.Point(49, 95)
        Me.lblNewestVersionInfo.Name = "lblNewestVersionInfo"
        Me.lblNewestVersionInfo.Size = New System.Drawing.Size(137, 20)
        Me.lblNewestVersionInfo.TabIndex = 13
        Me.lblNewestVersionInfo.Text = "Aktuellste Version"
        Me.lblNewestVersionInfo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblNewestVersion
        '
        Me.lblNewestVersion.AutoSize = True
        Me.lblNewestVersion.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewestVersion.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNewestVersion.Location = New System.Drawing.Point(205, 94)
        Me.lblNewestVersion.Name = "lblNewestVersion"
        Me.lblNewestVersion.Size = New System.Drawing.Size(58, 21)
        Me.lblNewestVersion.TabIndex = 14
        Me.lblNewestVersion.Text = "0.0.0.0"
        '
        'lblSeperator2
        '
        Me.lblSeperator2.BackColor = System.Drawing.Color.Silver
        Me.lblSeperator2.Location = New System.Drawing.Point(48, 127)
        Me.lblSeperator2.Name = "lblSeperator2"
        Me.lblSeperator2.Size = New System.Drawing.Size(276, 1)
        Me.lblSeperator2.TabIndex = 10
        '
        'lblQuestion
        '
        Me.lblQuestion.AutoSize = True
        Me.lblQuestion.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuestion.ForeColor = System.Drawing.Color.DimGray
        Me.lblQuestion.Location = New System.Drawing.Point(67, 135)
        Me.lblQuestion.Name = "lblQuestion"
        Me.lblQuestion.Size = New System.Drawing.Size(239, 17)
        Me.lblQuestion.TabIndex = 15
        Me.lblQuestion.Text = "Möchten Sie justMail jetzt aktualisieren?"
        '
        'btnYes
        '
        Me.btnYes.Location = New System.Drawing.Point(21, 171)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(162, 28)
        Me.btnYes.TabIndex = 16
        Me.btnYes.Values.Text = "Ja"
        '
        'btnNo
        '
        Me.btnNo.Location = New System.Drawing.Point(189, 171)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(162, 28)
        Me.btnNo.TabIndex = 17
        Me.btnNo.Values.Text = "Nein"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 215)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(373, 22)
        Me.StatusStrip1.TabIndex = 19
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(42, 17)
        Me.lblStatus.Text = "Status:"
        '
        'bgw1
        '
        '
        'tmrCheckBusy
        '
        Me.tmrCheckBusy.Interval = 1
        '
        'bgw2
        '
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(21, 171)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(330, 28)
        Me.ProgressBar1.TabIndex = 20
        Me.ProgressBar1.Visible = False
        '
        'HeaderPanel1
        '
        Me.HeaderPanel1.Caption = "Aktualisierung verfügbar"
        Me.HeaderPanel1.Description = "Eine Aktualisierung für justMail ist verfügbar."
        Me.HeaderPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderPanel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.HeaderPanel1.Location = New System.Drawing.Point(0, 0)
        Me.HeaderPanel1.Name = "HeaderPanel1"
        Me.HeaderPanel1.Size = New System.Drawing.Size(373, 62)
        Me.HeaderPanel1.TabIndex = 21
        '
        'SeperatorLabel1
        '
        Me.SeperatorLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SeperatorLabel1.Location = New System.Drawing.Point(-25, 45)
        Me.SeperatorLabel1.Name = "SeperatorLabel1"
        Me.SeperatorLabel1.SeperatorColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.SeperatorLabel1.Size = New System.Drawing.Size(398, 23)
        Me.SeperatorLabel1.TabIndex = 22
        Me.SeperatorLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 237)
        Me.Controls.Add(Me.SeperatorLabel1)
        Me.Controls.Add(Me.pbLogo)
        Me.Controls.Add(Me.HeaderPanel1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnNo)
        Me.Controls.Add(Me.btnYes)
        Me.Controls.Add(Me.lblQuestion)
        Me.Controls.Add(Me.lblSeperator2)
        Me.Controls.Add(Me.lblNewestVersion)
        Me.Controls.Add(Me.lblNewestVersionInfo)
        Me.Controls.Add(Me.lblLocalVersion)
        Me.Controls.Add(Me.lblLocalVersionInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Update verfügbar - justMail"
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblLocalVersionInfo As System.Windows.Forms.Label
    Friend WithEvents lblLocalVersion As System.Windows.Forms.Label
    Friend WithEvents lblNewestVersionInfo As System.Windows.Forms.Label
    Friend WithEvents lblNewestVersion As System.Windows.Forms.Label
    Friend WithEvents lblSeperator2 As System.Windows.Forms.Panel
    Friend WithEvents lblQuestion As System.Windows.Forms.Label
    Friend WithEvents btnYes As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnNo As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents bgw1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents tmrCheckBusy As System.Windows.Forms.Timer
    Friend WithEvents bgw2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents HeaderPanel1 As AeroControls.HeaderPanel
    Friend WithEvents SeperatorLabel1 As AeroControls.SeperatorLabel

End Class
