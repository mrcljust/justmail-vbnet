<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddEmail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddEmail))
        Me.lblProvider = New System.Windows.Forms.Label()
        Me.cbProvider = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.lblPOP3server = New System.Windows.Forms.Label()
        Me.lblPOP3port = New System.Windows.Forms.Label()
        Me.lblSMTPport = New System.Windows.Forms.Label()
        Me.lblSMTPserver = New System.Windows.Forms.Label()
        Me.tbPOP3server = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.tbSMTPserver = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.pnlSeperator3 = New System.Windows.Forms.Panel()
        Me.pnlSeperator2 = New System.Windows.Forms.Panel()
        Me.btnOk = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.tmrEnableOkButton = New System.Windows.Forms.Timer(Me.components)
        Me.cbSSL = New System.Windows.Forms.CheckBox()
        Me.tbSMTPport = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.tbPOP3port = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.tmrEnableTextboxes = New System.Windows.Forms.Timer(Me.components)
        Me.rbPOP3 = New System.Windows.Forms.RadioButton()
        Me.rbIMAP = New System.Windows.Forms.RadioButton()
        Me.KryptonLinkLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLinkLabel()
        Me.HeaderPanel1 = New AeroControls.HeaderPanel()
        Me.SeperatorLabel1 = New AeroControls.SeperatorLabel()
        CType(Me.cbProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.HeaderPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblProvider
        '
        Me.lblProvider.AutoSize = True
        Me.lblProvider.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProvider.Location = New System.Drawing.Point(71, 88)
        Me.lblProvider.Name = "lblProvider"
        Me.lblProvider.Size = New System.Drawing.Size(60, 17)
        Me.lblProvider.TabIndex = 11
        Me.lblProvider.Text = "Anbieter:"
        '
        'cbProvider
        '
        Me.cbProvider.DropDownWidth = 191
        Me.cbProvider.Items.AddRange(New Object() {"Microsoft", "GMX", "AOL (.com)", "AOL (.de), aim.com", "WEB", "T-Online", "Gmail", "Andere..."})
        Me.cbProvider.Location = New System.Drawing.Point(139, 88)
        Me.cbProvider.Name = "cbProvider"
        Me.cbProvider.Size = New System.Drawing.Size(191, 21)
        Me.cbProvider.TabIndex = 3
        Me.cbProvider.Text = "Bitte auswählen..."
        '
        'lblPOP3server
        '
        Me.lblPOP3server.AutoSize = True
        Me.lblPOP3server.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPOP3server.ForeColor = System.Drawing.Color.Silver
        Me.lblPOP3server.Location = New System.Drawing.Point(47, 125)
        Me.lblPOP3server.Name = "lblPOP3server"
        Me.lblPOP3server.Size = New System.Drawing.Size(84, 17)
        Me.lblPOP3server.TabIndex = 13
        Me.lblPOP3server.Text = "POP3-Server:"
        '
        'lblPOP3port
        '
        Me.lblPOP3port.AutoSize = True
        Me.lblPOP3port.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPOP3port.ForeColor = System.Drawing.Color.Silver
        Me.lblPOP3port.Location = New System.Drawing.Point(96, 146)
        Me.lblPOP3port.Name = "lblPOP3port"
        Me.lblPOP3port.Size = New System.Drawing.Size(35, 17)
        Me.lblPOP3port.TabIndex = 14
        Me.lblPOP3port.Text = "Port:"
        '
        'lblSMTPport
        '
        Me.lblSMTPport.AutoSize = True
        Me.lblSMTPport.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSMTPport.ForeColor = System.Drawing.Color.Silver
        Me.lblSMTPport.Location = New System.Drawing.Point(98, 202)
        Me.lblSMTPport.Name = "lblSMTPport"
        Me.lblSMTPport.Size = New System.Drawing.Size(35, 17)
        Me.lblSMTPport.TabIndex = 16
        Me.lblSMTPport.Text = "Port:"
        '
        'lblSMTPserver
        '
        Me.lblSMTPserver.AutoSize = True
        Me.lblSMTPserver.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSMTPserver.ForeColor = System.Drawing.Color.Silver
        Me.lblSMTPserver.Location = New System.Drawing.Point(47, 181)
        Me.lblSMTPserver.Name = "lblSMTPserver"
        Me.lblSMTPserver.Size = New System.Drawing.Size(86, 17)
        Me.lblSMTPserver.TabIndex = 15
        Me.lblSMTPserver.Text = "SMTP-Server:"
        '
        'tbPOP3server
        '
        Me.tbPOP3server.Enabled = False
        Me.tbPOP3server.Location = New System.Drawing.Point(139, 125)
        Me.tbPOP3server.Name = "tbPOP3server"
        Me.tbPOP3server.Size = New System.Drawing.Size(191, 20)
        Me.tbPOP3server.TabIndex = 4
        '
        'tbSMTPserver
        '
        Me.tbSMTPserver.Enabled = False
        Me.tbSMTPserver.Location = New System.Drawing.Point(139, 181)
        Me.tbSMTPserver.Name = "tbSMTPserver"
        Me.tbSMTPserver.Size = New System.Drawing.Size(191, 20)
        Me.tbSMTPserver.TabIndex = 6
        '
        'pnlSeperator3
        '
        Me.pnlSeperator3.BackColor = System.Drawing.Color.Silver
        Me.pnlSeperator3.Location = New System.Drawing.Point(38, 262)
        Me.pnlSeperator3.Name = "pnlSeperator3"
        Me.pnlSeperator3.Size = New System.Drawing.Size(300, 1)
        Me.pnlSeperator3.TabIndex = 11
        '
        'pnlSeperator2
        '
        Me.pnlSeperator2.BackColor = System.Drawing.Color.Silver
        Me.pnlSeperator2.Location = New System.Drawing.Point(38, 118)
        Me.pnlSeperator2.Name = "pnlSeperator2"
        Me.pnlSeperator2.Size = New System.Drawing.Size(300, 1)
        Me.pnlSeperator2.TabIndex = 12
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(93, 274)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(191, 28)
        Me.btnOk.TabIndex = 9
        Me.btnOk.Values.Text = "Weiter"
        '
        'tmrEnableOkButton
        '
        Me.tmrEnableOkButton.Enabled = True
        Me.tmrEnableOkButton.Interval = 10
        '
        'cbSSL
        '
        Me.cbSSL.AutoSize = True
        Me.cbSSL.Enabled = False
        Me.cbSSL.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSSL.ForeColor = System.Drawing.Color.Silver
        Me.cbSSL.Location = New System.Drawing.Point(102, 235)
        Me.cbSSL.Name = "cbSSL"
        Me.cbSSL.Size = New System.Drawing.Size(173, 21)
        Me.cbSSL.TabIndex = 8
        Me.cbSSL.Text = "SSL (Sichere Verbindung)"
        Me.cbSSL.UseVisualStyleBackColor = True
        '
        'tbSMTPport
        '
        Me.tbSMTPport.Enabled = False
        Me.tbSMTPport.Location = New System.Drawing.Point(139, 202)
        Me.tbSMTPport.MaxLength = 5
        Me.tbSMTPport.Name = "tbSMTPport"
        Me.tbSMTPport.Size = New System.Drawing.Size(191, 20)
        Me.tbSMTPport.TabIndex = 7
        '
        'tbPOP3port
        '
        Me.tbPOP3port.Enabled = False
        Me.tbPOP3port.Location = New System.Drawing.Point(139, 146)
        Me.tbPOP3port.MaxLength = 5
        Me.tbPOP3port.Name = "tbPOP3port"
        Me.tbPOP3port.Size = New System.Drawing.Size(191, 20)
        Me.tbPOP3port.TabIndex = 5
        '
        'tmrEnableTextboxes
        '
        Me.tmrEnableTextboxes.Enabled = True
        Me.tmrEnableTextboxes.Interval = 10
        '
        'rbPOP3
        '
        Me.rbPOP3.AutoSize = True
        Me.rbPOP3.Checked = True
        Me.rbPOP3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPOP3.Location = New System.Drawing.Point(124, 61)
        Me.rbPOP3.Name = "rbPOP3"
        Me.rbPOP3.Size = New System.Drawing.Size(57, 21)
        Me.rbPOP3.TabIndex = 1
        Me.rbPOP3.TabStop = True
        Me.rbPOP3.Text = "POP3"
        Me.rbPOP3.UseVisualStyleBackColor = True
        '
        'rbIMAP
        '
        Me.rbIMAP.AutoSize = True
        Me.rbIMAP.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbIMAP.Location = New System.Drawing.Point(196, 61)
        Me.rbIMAP.Name = "rbIMAP"
        Me.rbIMAP.Size = New System.Drawing.Size(56, 21)
        Me.rbIMAP.TabIndex = 2
        Me.rbIMAP.Text = "IMAP"
        Me.rbIMAP.UseVisualStyleBackColor = True
        '
        'KryptonLinkLabel1
        '
        Me.KryptonLinkLabel1.Location = New System.Drawing.Point(271, 28)
        Me.KryptonLinkLabel1.Name = "KryptonLinkLabel1"
        Me.KryptonLinkLabel1.Size = New System.Drawing.Size(103, 20)
        Me.KryptonLinkLabel1.TabIndex = 10
        Me.KryptonLinkLabel1.Values.Text = "Weitere Anbieter"
        '
        'HeaderPanel1
        '
        Me.HeaderPanel1.Caption = "E-Mail Konto verknüpfen (1/2)"
        Me.HeaderPanel1.Controls.Add(Me.KryptonLinkLabel1)
        Me.HeaderPanel1.Controls.Add(Me.SeperatorLabel1)
        Me.HeaderPanel1.Description = "justMail unterstützt alle Anbieter."
        Me.HeaderPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderPanel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.HeaderPanel1.Location = New System.Drawing.Point(0, 0)
        Me.HeaderPanel1.Name = "HeaderPanel1"
        Me.HeaderPanel1.Size = New System.Drawing.Size(377, 51)
        Me.HeaderPanel1.TabIndex = 17
        '
        'SeperatorLabel1
        '
        Me.SeperatorLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SeperatorLabel1.Location = New System.Drawing.Point(-11, 45)
        Me.SeperatorLabel1.Name = "SeperatorLabel1"
        Me.SeperatorLabel1.SeperatorColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.SeperatorLabel1.Size = New System.Drawing.Size(396, 10)
        Me.SeperatorLabel1.TabIndex = 18
        Me.SeperatorLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmAddEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(377, 318)
        Me.Controls.Add(Me.HeaderPanel1)
        Me.Controls.Add(Me.rbIMAP)
        Me.Controls.Add(Me.rbPOP3)
        Me.Controls.Add(Me.cbSSL)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.pnlSeperator2)
        Me.Controls.Add(Me.pnlSeperator3)
        Me.Controls.Add(Me.tbSMTPserver)
        Me.Controls.Add(Me.tbSMTPport)
        Me.Controls.Add(Me.tbPOP3port)
        Me.Controls.Add(Me.tbPOP3server)
        Me.Controls.Add(Me.lblSMTPport)
        Me.Controls.Add(Me.lblSMTPserver)
        Me.Controls.Add(Me.lblPOP3port)
        Me.Controls.Add(Me.lblPOP3server)
        Me.Controls.Add(Me.cbProvider)
        Me.Controls.Add(Me.lblProvider)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmAddEmail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "E-Mail-Konto verknüpfen (Schritt 1) - justMail"
        CType(Me.cbProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.HeaderPanel1.ResumeLayout(False)
        Me.HeaderPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents lblProvider As System.Windows.Forms.Label
    Friend WithEvents cbProvider As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents lblPOP3server As System.Windows.Forms.Label
    Friend WithEvents lblPOP3port As System.Windows.Forms.Label
    Friend WithEvents lblSMTPport As System.Windows.Forms.Label
    Friend WithEvents lblSMTPserver As System.Windows.Forms.Label
    Friend WithEvents tbPOP3server As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents tbSMTPserver As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents pnlSeperator3 As System.Windows.Forms.Panel
    Friend WithEvents pnlSeperator2 As System.Windows.Forms.Panel
    Friend WithEvents btnOk As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents tmrEnableOkButton As System.Windows.Forms.Timer
    Friend WithEvents cbSSL As System.Windows.Forms.CheckBox
    Friend WithEvents tbSMTPport As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents tbPOP3port As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents tmrEnableTextboxes As System.Windows.Forms.Timer
    Friend WithEvents rbPOP3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbIMAP As System.Windows.Forms.RadioButton
    Friend WithEvents KryptonLinkLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLinkLabel
    Friend WithEvents HeaderPanel1 As AeroControls.HeaderPanel
    Friend WithEvents SeperatorLabel1 As AeroControls.SeperatorLabel
End Class
