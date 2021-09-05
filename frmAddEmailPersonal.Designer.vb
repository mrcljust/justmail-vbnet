<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddEmailPersonal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddEmailPersonal))
        Me.pnlSeperator2 = New System.Windows.Forms.Panel()
        Me.pnlSeperator3 = New System.Windows.Forms.Panel()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblProvider = New System.Windows.Forms.Label()
        Me.cbProvider = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.bgWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.tmrEnableOkButton = New System.Windows.Forms.Timer(Me.components)
        Me.barStatus = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tmrCount = New System.Windows.Forms.Timer(Me.components)
        Me.btnOk = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.lblYourName = New System.Windows.Forms.Label()
        Me.btnBack = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.lblTypeConn = New System.Windows.Forms.Label()
        Me.tbYourName = New ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.tbEmail = New ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox()
        Me.tbPassword = New System.Windows.Forms.TextBox()
        Me.HeaderPanel1 = New AeroControls.HeaderPanel()
        Me.rtbHtmlWelcome = New System.Windows.Forms.RichTextBox()
        Me.SeperatorLabel1 = New AeroControls.SeperatorLabel()
        CType(Me.cbProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.barStatus.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.HeaderPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSeperator2
        '
        Me.pnlSeperator2.BackColor = System.Drawing.Color.Silver
        Me.pnlSeperator2.Location = New System.Drawing.Point(38, 89)
        Me.pnlSeperator2.Name = "pnlSeperator2"
        Me.pnlSeperator2.Size = New System.Drawing.Size(300, 1)
        Me.pnlSeperator2.TabIndex = 32
        '
        'pnlSeperator3
        '
        Me.pnlSeperator3.BackColor = System.Drawing.Color.Silver
        Me.pnlSeperator3.Location = New System.Drawing.Point(38, 166)
        Me.pnlSeperator3.Name = "pnlSeperator3"
        Me.pnlSeperator3.Size = New System.Drawing.Size(300, 1)
        Me.pnlSeperator3.TabIndex = 30
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPassword.Location = New System.Drawing.Point(49, 139)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(66, 17)
        Me.lblPassword.TabIndex = 34
        Me.lblPassword.Text = "Kennwort:"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEmail.Location = New System.Drawing.Point(15, 118)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(100, 17)
        Me.lblEmail.TabIndex = 33
        Me.lblEmail.Text = "E-Mail-Adresse:"
        '
        'lblProvider
        '
        Me.lblProvider.AutoSize = True
        Me.lblProvider.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProvider.ForeColor = System.Drawing.Color.Silver
        Me.lblProvider.Location = New System.Drawing.Point(55, 63)
        Me.lblProvider.Name = "lblProvider"
        Me.lblProvider.Size = New System.Drawing.Size(60, 17)
        Me.lblProvider.TabIndex = 29
        Me.lblProvider.Text = "Anbieter:"
        '
        'cbProvider
        '
        Me.cbProvider.DropDownWidth = 191
        Me.cbProvider.Enabled = False
        Me.cbProvider.Location = New System.Drawing.Point(121, 62)
        Me.cbProvider.Name = "cbProvider"
        Me.cbProvider.Size = New System.Drawing.Size(191, 21)
        Me.cbProvider.TabIndex = 1
        '
        'bgWorker1
        '
        Me.bgWorker1.WorkerSupportsCancellation = True
        '
        'tmrEnableOkButton
        '
        Me.tmrEnableOkButton.Enabled = True
        Me.tmrEnableOkButton.Interval = 10
        '
        'barStatus
        '
        Me.barStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.barStatus.Location = New System.Drawing.Point(0, 212)
        Me.barStatus.Name = "barStatus"
        Me.barStatus.Size = New System.Drawing.Size(377, 22)
        Me.barStatus.TabIndex = 43
        Me.barStatus.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(85, 17)
        Me.lblStatus.Text = "Status: Warte..."
        '
        'tmrCount
        '
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(191, 173)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(137, 28)
        Me.btnOk.TabIndex = 10
        Me.btnOk.Values.Text = "Weiter"
        '
        'lblYourName
        '
        Me.lblYourName.AutoSize = True
        Me.lblYourName.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYourName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblYourName.Location = New System.Drawing.Point(50, 96)
        Me.lblYourName.Name = "lblYourName"
        Me.lblYourName.Size = New System.Drawing.Size(65, 17)
        Me.lblYourName.TabIndex = 45
        Me.lblYourName.Text = "Ihr Name:"
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(48, 173)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(137, 28)
        Me.btnBack.TabIndex = 11
        Me.btnBack.Values.Text = "Zurück"
        '
        'lblTypeConn
        '
        Me.lblTypeConn.AutoSize = True
        Me.lblTypeConn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTypeConn.ForeColor = System.Drawing.Color.DarkGray
        Me.lblTypeConn.Location = New System.Drawing.Point(312, 63)
        Me.lblTypeConn.Name = "lblTypeConn"
        Me.lblTypeConn.Size = New System.Drawing.Size(49, 17)
        Me.lblTypeConn.TabIndex = 49
        Me.lblTypeConn.Text = "(POP3)"
        '
        'tbYourName
        '
        Me.tbYourName.Location = New System.Drawing.Point(121, 96)
        Me.tbYourName.Name = "tbYourName"
        Me.tbYourName.Size = New System.Drawing.Size(191, 20)
        Me.tbYourName.TabIndex = 7
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(334, 166)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 50
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'tbEmail
        '
        Me.tbEmail.Location = New System.Drawing.Point(121, 118)
        Me.tbEmail.Name = "tbEmail"
        Me.tbEmail.Size = New System.Drawing.Size(191, 20)
        Me.tbEmail.TabIndex = 8
        '
        'tbPassword
        '
        Me.tbPassword.Location = New System.Drawing.Point(121, 139)
        Me.tbPassword.Name = "tbPassword"
        Me.tbPassword.Size = New System.Drawing.Size(191, 20)
        Me.tbPassword.TabIndex = 9
        Me.tbPassword.UseSystemPasswordChar = True
        '
        'HeaderPanel1
        '
        Me.HeaderPanel1.Caption = "E-Mail Konto verknüpfen (2/2)"
        Me.HeaderPanel1.Controls.Add(Me.rtbHtmlWelcome)
        Me.HeaderPanel1.Description = "Geben Sie nun Ihre Daten ein."
        Me.HeaderPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderPanel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.HeaderPanel1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.HeaderPanel1.Location = New System.Drawing.Point(0, 0)
        Me.HeaderPanel1.Name = "HeaderPanel1"
        Me.HeaderPanel1.Size = New System.Drawing.Size(377, 51)
        Me.HeaderPanel1.TabIndex = 51
        '
        'rtbHtmlWelcome
        '
        Me.rtbHtmlWelcome.Location = New System.Drawing.Point(275, 12)
        Me.rtbHtmlWelcome.Name = "rtbHtmlWelcome"
        Me.rtbHtmlWelcome.Size = New System.Drawing.Size(90, 32)
        Me.rtbHtmlWelcome.TabIndex = 0
        Me.rtbHtmlWelcome.Text = resources.GetString("rtbHtmlWelcome.Text")
        Me.rtbHtmlWelcome.Visible = False
        '
        'SeperatorLabel1
        '
        Me.SeperatorLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SeperatorLabel1.Location = New System.Drawing.Point(-7, 47)
        Me.SeperatorLabel1.Name = "SeperatorLabel1"
        Me.SeperatorLabel1.SeperatorColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.SeperatorLabel1.Size = New System.Drawing.Size(396, 10)
        Me.SeperatorLabel1.TabIndex = 52
        Me.SeperatorLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmAddEmailPersonal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 234)
        Me.Controls.Add(Me.SeperatorLabel1)
        Me.Controls.Add(Me.HeaderPanel1)
        Me.Controls.Add(Me.tbPassword)
        Me.Controls.Add(Me.tbEmail)
        Me.Controls.Add(Me.tbYourName)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblTypeConn)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.lblYourName)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.barStatus)
        Me.Controls.Add(Me.cbProvider)
        Me.Controls.Add(Me.pnlSeperator2)
        Me.Controls.Add(Me.pnlSeperator3)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.lblProvider)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmAddEmailPersonal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "E-Mail-Konto verknüpfen (Schritt 2) - justMail"
        CType(Me.cbProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.barStatus.ResumeLayout(False)
        Me.barStatus.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.HeaderPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlSeperator2 As System.Windows.Forms.Panel
    Friend WithEvents pnlSeperator3 As System.Windows.Forms.Panel
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents lblProvider As System.Windows.Forms.Label
    Friend WithEvents cbProvider As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents bgWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents tmrEnableOkButton As System.Windows.Forms.Timer
    Friend WithEvents barStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tmrCount As System.Windows.Forms.Timer
    Friend WithEvents btnOk As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents lblYourName As System.Windows.Forms.Label
    Friend WithEvents btnBack As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents lblTypeConn As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents tbYourName As ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox
    Friend WithEvents tbEmail As ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox
    Friend WithEvents tbPassword As System.Windows.Forms.TextBox
    Friend WithEvents HeaderPanel1 As AeroControls.HeaderPanel
    Friend WithEvents SeperatorLabel1 As AeroControls.SeperatorLabel
    Friend WithEvents rtbHtmlWelcome As System.Windows.Forms.RichTextBox
End Class
