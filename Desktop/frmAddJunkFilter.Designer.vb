<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddJunkFilter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddJunkFilter))
        Me.HeaderPanel1 = New AeroControls.HeaderPanel()
        Me.SeperatorLabel1 = New AeroControls.SeperatorLabel()
        Me.btnCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnOk = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.HeaderPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'HeaderPanel1
        '
        Me.HeaderPanel1.Caption = "Filter hinzufügen"
        Me.HeaderPanel1.Controls.Add(Me.SeperatorLabel1)
        Me.HeaderPanel1.Description = "E-Mail-Adresse"
        Me.HeaderPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.HeaderPanel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.HeaderPanel1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.HeaderPanel1.Location = New System.Drawing.Point(0, 0)
        Me.HeaderPanel1.Name = "HeaderPanel1"
        Me.HeaderPanel1.Size = New System.Drawing.Size(437, 55)
        Me.HeaderPanel1.TabIndex = 70
        '
        'SeperatorLabel1
        '
        Me.SeperatorLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SeperatorLabel1.Location = New System.Drawing.Point(-8, 48)
        Me.SeperatorLabel1.Name = "SeperatorLabel1"
        Me.SeperatorLabel1.SeperatorColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.SeperatorLabel1.Size = New System.Drawing.Size(469, 10)
        Me.SeperatorLabel1.TabIndex = 70
        Me.SeperatorLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(225, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(146, 28)
        Me.btnCancel.TabIndex = 73
        Me.btnCancel.Values.Image = CType(resources.GetObject("btnCancel.Values.Image"), System.Drawing.Image)
        Me.btnCancel.Values.Text = "Abbrechen"
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.Enabled = False
        Me.btnOk.Location = New System.Drawing.Point(73, 4)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(146, 28)
        Me.btnOk.TabIndex = 72
        Me.btnOk.Values.Image = CType(resources.GetObject("btnOk.Values.Image"), System.Drawing.Image)
        Me.btnOk.Values.Text = "Filter hinzufügen"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel3.Controls.Add(Me.btnOk)
        Me.Panel3.Controls.Add(Me.btnCancel)
        Me.Panel3.Location = New System.Drawing.Point(-5, 173)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(445, 91)
        Me.Panel3.TabIndex = 74
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel5.Location = New System.Drawing.Point(-5, 172)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(456, 174)
        Me.Panel5.TabIndex = 71
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Location = New System.Drawing.Point(-28, 66)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(489, 92)
        Me.Panel2.TabIndex = 75
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.ComboBox3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.ComboBox2)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Location = New System.Drawing.Point(-21, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(510, 90)
        Me.Panel1.TabIndex = 66
        '
        'ComboBox3
        '
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"In Junk E-Mails verschieben", "In Papierkorb verschieben"})
        Me.ComboBox3.Location = New System.Drawing.Point(112, 47)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(177, 21)
        Me.ComboBox3.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(61, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Aktion:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(295, 14)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(179, 20)
        Me.TextBox1.TabIndex = 2
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"enthält", "ist", "enthält nicht"})
        Me.ComboBox2.Location = New System.Drawing.Point(178, 14)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(111, 21)
        Me.ComboBox2.TabIndex = 1
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Betreff", "Von", "An", "Datum"})
        Me.ComboBox1.Location = New System.Drawing.Point(61, 14)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(111, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'frmAddJunkFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(437, 212)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.HeaderPanel1)
        Me.Controls.Add(Me.Panel5)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAddJunkFilter"
        Me.Text = "Filter hinzufügen - Junk-Filter - justMail"
        Me.HeaderPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents HeaderPanel1 As AeroControls.HeaderPanel
    Friend WithEvents SeperatorLabel1 As AeroControls.SeperatorLabel
    Friend WithEvents btnCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnOk As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
