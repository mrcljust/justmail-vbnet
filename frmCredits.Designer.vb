<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCredits
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCredits))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.SeperatorLabel1 = New AeroControls.SeperatorLabel()
        Me.AeroLinkLabel1 = New AeroControls.AeroLinkLabel()
        Me.ExpanderPanel1 = New AeroControls.ExpanderPanel()
        Me.KryptonLabel13 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel12 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel11 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel8 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel10 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SeperatorLabel2 = New AeroControls.SeperatorLabel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.KryptonLabel9 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel7 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel6 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.KryptonLabel5 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel4 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel3 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel2 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.KryptonLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.ExpanderPanel1.SuspendLayout
        CType(Me.pbLogo,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = true
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 36!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblTitle.Location = New System.Drawing.Point(206, 12)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(194, 65)
        Me.lblTitle.TabIndex = 4
        Me.lblTitle.Text = "justMail"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = true
        Me.lblVersion.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblVersion.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblVersion.Location = New System.Drawing.Point(224, 74)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(56, 17)
        Me.lblVersion.TabIndex = 5
        Me.lblVersion.Text = "Version "
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = true
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblDescription.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblDescription.Location = New System.Drawing.Point(214, 99)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(269, 26)
        Me.lblDescription.TabIndex = 6
        Me.lblDescription.Text = "justMail ist ein Projekt von IT-Just."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"Die Entwicklung wurde im August 2013 begon"& _ 
    "nen."
        '
        'SeperatorLabel1
        '
        Me.SeperatorLabel1.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.SeperatorLabel1.ForeColor = System.Drawing.Color.Blue
        Me.SeperatorLabel1.Location = New System.Drawing.Point(201, 138)
        Me.SeperatorLabel1.Name = "SeperatorLabel1"
        Me.SeperatorLabel1.SeperatorColor = System.Drawing.Color.FromArgb(CType(CType(204,Byte),Integer), CType(CType(204,Byte),Integer), CType(CType(204,Byte),Integer))
        Me.SeperatorLabel1.Size = New System.Drawing.Size(510, 23)
        Me.SeperatorLabel1.TabIndex = 7
        Me.SeperatorLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AeroLinkLabel1
        '
        Me.AeroLinkLabel1.AutoSize = true
        Me.AeroLinkLabel1.Command = ""
        Me.AeroLinkLabel1.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.AeroLinkLabel1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.AeroLinkLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.AeroLinkLabel1.LinkForeColor = System.Drawing.SystemColors.HotTrack
        Me.AeroLinkLabel1.LinkHoverColor = System.Drawing.Color.FromArgb(CType(CType(51,Byte),Integer), CType(CType(153,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.AeroLinkLabel1.Location = New System.Drawing.Point(205, 158)
        Me.AeroLinkLabel1.Name = "AeroLinkLabel1"
        Me.AeroLinkLabel1.NavigateOnClick = false
        Me.AeroLinkLabel1.NonLinkForeColor = System.Drawing.Color.Black
        Me.AeroLinkLabel1.Size = New System.Drawing.Size(58, 15)
        Me.AeroLinkLabel1.TabIndex = 8
        Me.AeroLinkLabel1.Text = "it-just.net"
        '
        'ExpanderPanel1
        '
        Me.ExpanderPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240,Byte),Integer), CType(CType(240,Byte),Integer), CType(CType(240,Byte),Integer))
        Me.ExpanderPanel1.Controls.Add(Me.KryptonLabel13)
        Me.ExpanderPanel1.Controls.Add(Me.KryptonLabel12)
        Me.ExpanderPanel1.Controls.Add(Me.KryptonLabel11)
        Me.ExpanderPanel1.Controls.Add(Me.KryptonLabel8)
        Me.ExpanderPanel1.Controls.Add(Me.KryptonLabel10)
        Me.ExpanderPanel1.Controls.Add(Me.Panel2)
        Me.ExpanderPanel1.Controls.Add(Me.Panel1)
        Me.ExpanderPanel1.Controls.Add(Me.SeperatorLabel2)
        Me.ExpanderPanel1.Controls.Add(Me.Label5)
        Me.ExpanderPanel1.Controls.Add(Me.KryptonLabel9)
        Me.ExpanderPanel1.Controls.Add(Me.KryptonLabel7)
        Me.ExpanderPanel1.Controls.Add(Me.KryptonLabel6)
        Me.ExpanderPanel1.Controls.Add(Me.Label4)
        Me.ExpanderPanel1.Controls.Add(Me.KryptonLabel5)
        Me.ExpanderPanel1.Controls.Add(Me.KryptonLabel4)
        Me.ExpanderPanel1.Controls.Add(Me.KryptonLabel3)
        Me.ExpanderPanel1.Controls.Add(Me.KryptonLabel2)
        Me.ExpanderPanel1.Controls.Add(Me.KryptonLabel1)
        Me.ExpanderPanel1.Controls.Add(Me.Label3)
        Me.ExpanderPanel1.Expanded = false
        Me.ExpanderPanel1.ExpandedHeight = 240
        Me.ExpanderPanel1.Label = "Erwähnungen"
        Me.ExpanderPanel1.Location = New System.Drawing.Point(0, 199)
        Me.ExpanderPanel1.Name = "ExpanderPanel1"
        Me.ExpanderPanel1.Size = New System.Drawing.Size(647, 40)
        Me.ExpanderPanel1.TabIndex = 11
        '
        'KryptonLabel13
        '
        Me.KryptonLabel13.Location = New System.Drawing.Point(438, 183)
        Me.KryptonLabel13.Name = "KryptonLabel13"
        Me.KryptonLabel13.Size = New System.Drawing.Size(64, 20)
        Me.KryptonLabel13.TabIndex = 31
        Me.KryptonLabel13.Values.Text = "● Yusuf Y."
        '
        'KryptonLabel12
        '
        Me.KryptonLabel12.Location = New System.Drawing.Point(438, 157)
        Me.KryptonLabel12.Name = "KryptonLabel12"
        Me.KryptonLabel12.Size = New System.Drawing.Size(53, 20)
        Me.KryptonLabel12.TabIndex = 30
        Me.KryptonLabel12.Values.Text = "● Luis J."
        '
        'KryptonLabel11
        '
        Me.KryptonLabel11.Location = New System.Drawing.Point(438, 131)
        Me.KryptonLabel11.Name = "KryptonLabel11"
        Me.KryptonLabel11.Size = New System.Drawing.Size(54, 20)
        Me.KryptonLabel11.TabIndex = 29
        Me.KryptonLabel11.Values.Text = "● Jan H."
        '
        'KryptonLabel8
        '
        Me.KryptonLabel8.Location = New System.Drawing.Point(438, 105)
        Me.KryptonLabel8.Name = "KryptonLabel8"
        Me.KryptonLabel8.Size = New System.Drawing.Size(69, 20)
        Me.KryptonLabel8.TabIndex = 28
        Me.KryptonLabel8.Values.Text = "● Daniel K."
        '
        'KryptonLabel10
        '
        Me.KryptonLabel10.Location = New System.Drawing.Point(438, 79)
        Me.KryptonLabel10.Name = "KryptonLabel10"
        Me.KryptonLabel10.Size = New System.Drawing.Size(74, 20)
        Me.KryptonLabel10.TabIndex = 27
        Me.KryptonLabel10.Values.Text = "● Tobias M."
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer))
        Me.Panel2.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Panel2.Location = New System.Drawing.Point(431, 41)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 172)
        Me.Panel2.TabIndex = 14
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer), CType(CType(224,Byte),Integer))
        Me.Panel1.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Panel1.Location = New System.Drawing.Point(215, 41)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 172)
        Me.Panel1.TabIndex = 13
        '
        'SeperatorLabel2
        '
        Me.SeperatorLabel2.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.SeperatorLabel2.Location = New System.Drawing.Point(-11, 200)
        Me.SeperatorLabel2.Name = "SeperatorLabel2"
        Me.SeperatorLabel2.SeperatorColor = System.Drawing.Color.FromArgb(CType(CType(204,Byte),Integer), CType(CType(204,Byte),Integer), CType(CType(204,Byte),Integer))
        Me.SeperatorLabel2.Size = New System.Drawing.Size(672, 23)
        Me.SeperatorLabel2.TabIndex = 26
        Me.SeperatorLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label5.Location = New System.Drawing.Point(443, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 32)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Beta Tester"
        '
        'KryptonLabel9
        '
        Me.KryptonLabel9.Location = New System.Drawing.Point(226, 131)
        Me.KryptonLabel9.Name = "KryptonLabel9"
        Me.KryptonLabel9.Size = New System.Drawing.Size(147, 36)
        Me.KryptonLabel9.TabIndex = 22
        Me.KryptonLabel9.Values.Text = "● updateSystem.NET von"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"   Maximilian Krauß"
        '
        'KryptonLabel7
        '
        Me.KryptonLabel7.Location = New System.Drawing.Point(226, 105)
        Me.KryptonLabel7.Name = "KryptonLabel7"
        Me.KryptonLabel7.Size = New System.Drawing.Size(165, 20)
        Me.KryptonLabel7.TabIndex = 21
        Me.KryptonLabel7.Values.Text = "● ExceptionBase von leolabs"
        '
        'KryptonLabel6
        '
        Me.KryptonLabel6.Location = New System.Drawing.Point(227, 78)
        Me.KryptonLabel6.Name = "KryptonLabel6"
        Me.KryptonLabel6.Size = New System.Drawing.Size(204, 20)
        Me.KryptonLabel6.TabIndex = 20
        Me.KryptonLabel6.Values.Text = "● AeroControls von Alexander Wais"
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label4.Location = New System.Drawing.Point(227, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 32)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Imports"
        '
        'KryptonLabel5
        '
        Me.KryptonLabel5.Location = New System.Drawing.Point(12, 183)
        Me.KryptonLabel5.Name = "KryptonLabel5"
        Me.KryptonLabel5.Size = New System.Drawing.Size(108, 20)
        Me.KryptonLabel5.TabIndex = 18
        Me.KryptonLabel5.Values.Text = "● leandergraphics"
        '
        'KryptonLabel4
        '
        Me.KryptonLabel4.Location = New System.Drawing.Point(12, 157)
        Me.KryptonLabel4.Name = "KryptonLabel4"
        Me.KryptonLabel4.Size = New System.Drawing.Size(96, 20)
        Me.KryptonLabel4.TabIndex = 17
        Me.KryptonLabel4.Values.Text = "● Oxygen Team"
        '
        'KryptonLabel3
        '
        Me.KryptonLabel3.Location = New System.Drawing.Point(12, 131)
        Me.KryptonLabel3.Name = "KryptonLabel3"
        Me.KryptonLabel3.Size = New System.Drawing.Size(159, 20)
        Me.KryptonLabel3.TabIndex = 16
        Me.KryptonLabel3.Values.Text = "● VisualPharm (Ivan Boyko)"
        '
        'KryptonLabel2
        '
        Me.KryptonLabel2.Location = New System.Drawing.Point(12, 105)
        Me.KryptonLabel2.Name = "KryptonLabel2"
        Me.KryptonLabel2.Size = New System.Drawing.Size(64, 20)
        Me.KryptonLabel2.TabIndex = 15
        Me.KryptonLabel2.Values.Text = "● Jack Cai"
        '
        'KryptonLabel1
        '
        Me.KryptonLabel1.Location = New System.Drawing.Point(12, 79)
        Me.KryptonLabel1.Name = "KryptonLabel1"
        Me.KryptonLabel1.Size = New System.Drawing.Size(131, 20)
        Me.KryptonLabel1.TabIndex = 14
        Me.KryptonLabel1.Values.Text = "● Custom Icon Design"
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label3.Location = New System.Drawing.Point(12, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 32)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Grafiken von"
        '
        'pbLogo
        '
        Me.pbLogo.Image = Global.justMail.My.Resources.Resources.icon
        Me.pbLogo.Location = New System.Drawing.Point(12, 12)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(188, 188)
        Me.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbLogo.TabIndex = 3
        Me.pbLogo.TabStop = false
        '
        'frmCredits
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(647, 239)
        Me.Controls.Add(Me.ExpanderPanel1)
        Me.Controls.Add(Me.AeroLinkLabel1)
        Me.Controls.Add(Me.SeperatorLabel1)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.pbLogo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmCredits"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Über justMail"
        Me.ExpanderPanel1.ResumeLayout(false)
        Me.ExpanderPanel1.PerformLayout
        CType(Me.pbLogo,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents pbLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents SeperatorLabel1 As AeroControls.SeperatorLabel
    Friend WithEvents AeroLinkLabel1 As AeroControls.AeroLinkLabel
    Friend WithEvents ExpanderPanel1 As AeroControls.ExpanderPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents KryptonLabel5 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel4 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel3 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel2 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel9 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel7 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel6 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents KryptonLabel8 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel10 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents SeperatorLabel2 As AeroControls.SeperatorLabel
    Friend WithEvents KryptonLabel12 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel11 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    Friend WithEvents KryptonLabel13 As ComponentFactory.Krypton.Toolkit.KryptonLabel
    'Friend WithEvents updateCTRL As updateSystemDotNet.updateController
End Class
