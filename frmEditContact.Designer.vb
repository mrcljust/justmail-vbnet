<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditContact
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditContact))
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnOk = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.tbFax = New ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox()
        Me.tbTelephone = New ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox()
        Me.lblTelephone = New System.Windows.Forms.Label()
        Me.lblFax = New System.Windows.Forms.Label()
        Me.tmrEnableOkButton = New System.Windows.Forms.Timer(Me.components)
        Me.tbPlace = New ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox()
        Me.lblPlace = New System.Windows.Forms.Label()
        Me.tbEmail = New ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.tbName = New ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.HeaderPanel1 = New AeroControls.HeaderPanel()
        Me.SeperatorLabel1 = New AeroControls.SeperatorLabel()
        Me.Panel2.SuspendLayout()
        Me.HeaderPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(191, 273)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(140, 28)
        Me.btnCancel.TabIndex = 90
        Me.btnCancel.Values.Image = CType(resources.GetObject("btnCancel.Values.Image"), System.Drawing.Image)
        Me.btnCancel.Values.Text = "Abbrechen"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(12, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 21)
        Me.Label6.TabIndex = 86
        Me.Label6.Text = "*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(12, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 21)
        Me.Label5.TabIndex = 85
        Me.Label5.Text = "*"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(-19, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(430, 174)
        Me.Panel1.TabIndex = 66
        '
        'btnOk
        '
        Me.btnOk.Enabled = False
        Me.btnOk.Location = New System.Drawing.Point(45, 273)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(140, 28)
        Me.btnOk.TabIndex = 88
        Me.btnOk.Values.Image = CType(resources.GetObject("btnOk.Values.Image"), System.Drawing.Image)
        Me.btnOk.Values.Text = "Speichern"
        '
        'tbFax
        '
        Me.tbFax.Location = New System.Drawing.Point(137, 189)
        Me.tbFax.Name = "tbFax"
        Me.tbFax.Size = New System.Drawing.Size(221, 20)
        Me.tbFax.TabIndex = 82
        '
        'tbTelephone
        '
        Me.tbTelephone.Location = New System.Drawing.Point(137, 167)
        Me.tbTelephone.Name = "tbTelephone"
        Me.tbTelephone.Size = New System.Drawing.Size(221, 20)
        Me.tbTelephone.TabIndex = 81
        '
        'lblTelephone
        '
        Me.lblTelephone.AutoSize = True
        Me.lblTelephone.BackColor = System.Drawing.Color.White
        Me.lblTelephone.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelephone.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTelephone.Location = New System.Drawing.Point(76, 167)
        Me.lblTelephone.Name = "lblTelephone"
        Me.lblTelephone.Size = New System.Drawing.Size(54, 17)
        Me.lblTelephone.TabIndex = 84
        Me.lblTelephone.Text = "Telefon:"
        '
        'lblFax
        '
        Me.lblFax.AutoSize = True
        Me.lblFax.BackColor = System.Drawing.Color.White
        Me.lblFax.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFax.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFax.Location = New System.Drawing.Point(100, 189)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(30, 17)
        Me.lblFax.TabIndex = 83
        Me.lblFax.Text = "Fax:"
        '
        'tmrEnableOkButton
        '
        Me.tmrEnableOkButton.Enabled = True
        Me.tmrEnableOkButton.Interval = 10
        '
        'tbPlace
        '
        Me.tbPlace.Location = New System.Drawing.Point(137, 141)
        Me.tbPlace.Name = "tbPlace"
        Me.tbPlace.Size = New System.Drawing.Size(221, 20)
        Me.tbPlace.TabIndex = 79
        '
        'lblPlace
        '
        Me.lblPlace.AutoSize = True
        Me.lblPlace.BackColor = System.Drawing.Color.White
        Me.lblPlace.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlace.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPlace.Location = New System.Drawing.Point(67, 141)
        Me.lblPlace.Name = "lblPlace"
        Me.lblPlace.Size = New System.Drawing.Size(62, 17)
        Me.lblPlace.TabIndex = 80
        Me.lblPlace.Text = "Wohnort:"
        '
        'tbEmail
        '
        Me.tbEmail.Location = New System.Drawing.Point(137, 93)
        Me.tbEmail.Name = "tbEmail"
        Me.tbEmail.Size = New System.Drawing.Size(221, 20)
        Me.tbEmail.TabIndex = 77
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.BackColor = System.Drawing.Color.White
        Me.lblEmail.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEmail.Location = New System.Drawing.Point(30, 93)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(100, 17)
        Me.lblEmail.TabIndex = 78
        Me.lblEmail.Text = "E-Mail-Adresse:"
        '
        'tbName
        '
        Me.tbName.Location = New System.Drawing.Point(137, 67)
        Me.tbName.Name = "tbName"
        Me.tbName.Size = New System.Drawing.Size(221, 20)
        Me.tbName.TabIndex = 75
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.White
        Me.lblName.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblName.Location = New System.Drawing.Point(84, 67)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(46, 17)
        Me.lblName.TabIndex = 76
        Me.lblName.Text = "Name:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Location = New System.Drawing.Point(-23, 61)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(432, 176)
        Me.Panel2.TabIndex = 87
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel3.Location = New System.Drawing.Point(-5, 269)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(401, 91)
        Me.Panel3.TabIndex = 91
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel5.Location = New System.Drawing.Point(-5, 268)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(430, 174)
        Me.Panel5.TabIndex = 89
        '
        'HeaderPanel1
        '
        Me.HeaderPanel1.Caption = "Kontakt hinzufügen"
        Me.HeaderPanel1.Controls.Add(Me.SeperatorLabel1)
        Me.HeaderPanel1.Description = "Ändern Sie nun die Infos, die Sie ändern möchten."
        Me.HeaderPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderPanel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.HeaderPanel1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HeaderPanel1.Location = New System.Drawing.Point(0, 0)
        Me.HeaderPanel1.Name = "HeaderPanel1"
        Me.HeaderPanel1.Size = New System.Drawing.Size(370, 55)
        Me.HeaderPanel1.TabIndex = 92
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
        'frmEditContact
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(370, 303)
        Me.Controls.Add(Me.HeaderPanel1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.tbFax)
        Me.Controls.Add(Me.tbTelephone)
        Me.Controls.Add(Me.lblTelephone)
        Me.Controls.Add(Me.lblFax)
        Me.Controls.Add(Me.tbPlace)
        Me.Controls.Add(Me.lblPlace)
        Me.Controls.Add(Me.tbEmail)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.tbName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEditContact"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Kontakt bearbeiten - Adressbuch - justMail"
        Me.Panel2.ResumeLayout(False)
        Me.HeaderPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnOk As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents tbFax As ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox
    Friend WithEvents tbTelephone As ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox
    Friend WithEvents lblTelephone As System.Windows.Forms.Label
    Friend WithEvents lblFax As System.Windows.Forms.Label
    Friend WithEvents tmrEnableOkButton As System.Windows.Forms.Timer
    Friend WithEvents tbPlace As ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox
    Friend WithEvents lblPlace As System.Windows.Forms.Label
    Friend WithEvents tbEmail As ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents tbName As ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents HeaderPanel1 As AeroControls.HeaderPanel
    Friend WithEvents SeperatorLabel1 As AeroControls.SeperatorLabel
End Class
