<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddressBook
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddressBook))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblDateAdded = New System.Windows.Forms.Label()
        Me.tbFax = New ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox()
        Me.tbName = New ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox()
        Me.tbTelephone = New ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblTelephone = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblFax = New System.Windows.Forms.Label()
        Me.tbEmail = New ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox()
        Me.tbPlace = New ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox()
        Me.lblPlace = New System.Windows.Forms.Label()
        Me.tvContacts = New ComponentFactory.Krypton.Toolkit.KryptonTreeView()
        Me.pnlSTRbtm = New System.Windows.Forms.Panel()
        Me.btnNew = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnRemove = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnNewEmail = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnEdit = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.tmrEnableButtons = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(305, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(287, 284)
        Me.Panel1.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.lblDateAdded)
        Me.Panel2.Controls.Add(Me.tbFax)
        Me.Panel2.Controls.Add(Me.tbName)
        Me.Panel2.Controls.Add(Me.tbTelephone)
        Me.Panel2.Controls.Add(Me.lblName)
        Me.Panel2.Controls.Add(Me.lblTelephone)
        Me.Panel2.Controls.Add(Me.lblEmail)
        Me.Panel2.Controls.Add(Me.lblFax)
        Me.Panel2.Controls.Add(Me.tbEmail)
        Me.Panel2.Controls.Add(Me.tbPlace)
        Me.Panel2.Controls.Add(Me.lblPlace)
        Me.Panel2.Location = New System.Drawing.Point(1, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(285, 282)
        Me.Panel2.TabIndex = 4
        '
        'lblDateAdded
        '
        Me.lblDateAdded.AutoSize = True
        Me.lblDateAdded.Location = New System.Drawing.Point(3, 266)
        Me.lblDateAdded.Name = "lblDateAdded"
        Me.lblDateAdded.Size = New System.Drawing.Size(81, 13)
        Me.lblDateAdded.TabIndex = 72
        Me.lblDateAdded.Text = "Hinzugefügt am"
        '
        'tbFax
        '
        Me.tbFax.Location = New System.Drawing.Point(41, 219)
        Me.tbFax.Name = "tbFax"
        Me.tbFax.ReadOnly = True
        Me.tbFax.Size = New System.Drawing.Size(204, 20)
        Me.tbFax.TabIndex = 69
        '
        'tbName
        '
        Me.tbName.Location = New System.Drawing.Point(41, 27)
        Me.tbName.Name = "tbName"
        Me.tbName.ReadOnly = True
        Me.tbName.Size = New System.Drawing.Size(204, 20)
        Me.tbName.TabIndex = 62
        '
        'tbTelephone
        '
        Me.tbTelephone.Location = New System.Drawing.Point(41, 171)
        Me.tbTelephone.Name = "tbTelephone"
        Me.tbTelephone.ReadOnly = True
        Me.tbTelephone.Size = New System.Drawing.Size(204, 20)
        Me.tbTelephone.TabIndex = 68
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.White
        Me.lblName.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblName.Location = New System.Drawing.Point(44, 7)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(43, 17)
        Me.lblName.TabIndex = 63
        Me.lblName.Text = "Name"
        '
        'lblTelephone
        '
        Me.lblTelephone.AutoSize = True
        Me.lblTelephone.BackColor = System.Drawing.Color.White
        Me.lblTelephone.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelephone.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTelephone.Location = New System.Drawing.Point(41, 151)
        Me.lblTelephone.Name = "lblTelephone"
        Me.lblTelephone.Size = New System.Drawing.Size(51, 17)
        Me.lblTelephone.TabIndex = 71
        Me.lblTelephone.Text = "Telefon"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.BackColor = System.Drawing.Color.White
        Me.lblEmail.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEmail.Location = New System.Drawing.Point(41, 55)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(97, 17)
        Me.lblEmail.TabIndex = 65
        Me.lblEmail.Text = "E-Mail-Adresse"
        '
        'lblFax
        '
        Me.lblFax.AutoSize = True
        Me.lblFax.BackColor = System.Drawing.Color.White
        Me.lblFax.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFax.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFax.Location = New System.Drawing.Point(41, 199)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(30, 17)
        Me.lblFax.TabIndex = 70
        Me.lblFax.Text = "Fax:"
        '
        'tbEmail
        '
        Me.tbEmail.Location = New System.Drawing.Point(41, 75)
        Me.tbEmail.Name = "tbEmail"
        Me.tbEmail.ReadOnly = True
        Me.tbEmail.Size = New System.Drawing.Size(204, 20)
        Me.tbEmail.TabIndex = 64
        '
        'tbPlace
        '
        Me.tbPlace.Location = New System.Drawing.Point(41, 123)
        Me.tbPlace.Name = "tbPlace"
        Me.tbPlace.ReadOnly = True
        Me.tbPlace.Size = New System.Drawing.Size(204, 20)
        Me.tbPlace.TabIndex = 66
        '
        'lblPlace
        '
        Me.lblPlace.AutoSize = True
        Me.lblPlace.BackColor = System.Drawing.Color.White
        Me.lblPlace.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlace.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPlace.Location = New System.Drawing.Point(40, 103)
        Me.lblPlace.Name = "lblPlace"
        Me.lblPlace.Size = New System.Drawing.Size(59, 17)
        Me.lblPlace.TabIndex = 67
        Me.lblPlace.Text = "Wohnort"
        '
        'tvContacts
        '
        Me.tvContacts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.tvContacts.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.InputControlStandalone
        Me.tvContacts.BorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.InputControlStandalone
        Me.tvContacts.HideSelection = False
        Me.tvContacts.ItemHeight = 21
        Me.tvContacts.ItemStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.ListItem
        Me.tvContacts.Location = New System.Drawing.Point(12, 12)
        Me.tvContacts.Name = "tvContacts"
        Me.tvContacts.Size = New System.Drawing.Size(287, 284)
        Me.tvContacts.TabIndex = 4
        '
        'pnlSTRbtm
        '
        Me.pnlSTRbtm.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlSTRbtm.BackColor = System.Drawing.SystemColors.ControlDark
        Me.pnlSTRbtm.Location = New System.Drawing.Point(12, 304)
        Me.pnlSTRbtm.Name = "pnlSTRbtm"
        Me.pnlSTRbtm.Size = New System.Drawing.Size(580, 1)
        Me.pnlSTRbtm.TabIndex = 6
        '
        'btnNew
        '
        Me.btnNew.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnNew.Location = New System.Drawing.Point(12, 311)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(287, 28)
        Me.btnNew.TabIndex = 7
        Me.btnNew.Values.Image = CType(resources.GetObject("btnNew.Values.Image"), System.Drawing.Image)
        Me.btnNew.Values.Text = "Kontakt hinzufügen"
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnRemove.Location = New System.Drawing.Point(158, 347)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(141, 28)
        Me.btnRemove.TabIndex = 11
        Me.btnRemove.Values.Image = CType(resources.GetObject("btnRemove.Values.Image"), System.Drawing.Image)
        Me.btnRemove.Values.Text = "Kontakt entfernen"
        '
        'btnNewEmail
        '
        Me.btnNewEmail.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnNewEmail.Location = New System.Drawing.Point(309, 311)
        Me.btnNewEmail.Name = "btnNewEmail"
        Me.btnNewEmail.Size = New System.Drawing.Size(141, 28)
        Me.btnNewEmail.TabIndex = 12
        Me.btnNewEmail.Values.Image = Global.justMail.My.resources.Resources.k2
        Me.btnNewEmail.Values.Text = "Neue E-Mail"
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnEdit.Location = New System.Drawing.Point(12, 347)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(141, 28)
        Me.btnEdit.TabIndex = 9
        Me.btnEdit.Values.Image = CType(resources.GetObject("btnEdit.Values.Image"), System.Drawing.Image)
        Me.btnEdit.Values.Text = "Bearbeiten"
        '
        'Panel3
        '
        Me.Panel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel3.Location = New System.Drawing.Point(302, 305)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1, 86)
        Me.Panel3.TabIndex = 7
        '
        'tmrEnableButtons
        '
        Me.tmrEnableButtons.Enabled = True
        Me.tmrEnableButtons.Interval = 1
        '
        'frmAddressBook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 388)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.btnNewEmail)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.pnlSTRbtm)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tvContacts)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(620, 1000000)
        Me.MinimumSize = New System.Drawing.Size(620, 426)
        Me.Name = "frmAddressBook"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Adressbuch - justMail"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents tvContacts As ComponentFactory.Krypton.Toolkit.KryptonTreeView
    Friend WithEvents pnlSTRbtm As System.Windows.Forms.Panel
    Friend WithEvents btnNew As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnRemove As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnNewEmail As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnEdit As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents tmrEnableButtons As System.Windows.Forms.Timer
    Friend WithEvents tbFax As ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox
    Friend WithEvents tbName As ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox
    Friend WithEvents tbTelephone As ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblTelephone As System.Windows.Forms.Label
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents lblFax As System.Windows.Forms.Label
    Friend WithEvents tbEmail As ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox
    Friend WithEvents tbPlace As ComponentFactory.Krypton.Toolkit.KryptonMaskedTextBox
    Friend WithEvents lblPlace As System.Windows.Forms.Label
    Friend WithEvents lblDateAdded As System.Windows.Forms.Label
End Class
