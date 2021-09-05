<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettingsAccounts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettingsAccounts))
        Me.tvAccounts = New ComponentFactory.Krypton.Toolkit.KryptonTreeView()
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.KryptonTextBox1 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonTextBox2 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonTextBox3 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.btnRemoveAcc = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tvAccounts
        '
        Me.tvAccounts.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.InputControlStandalone
        Me.tvAccounts.BorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.InputControlStandalone
        Me.tvAccounts.HideSelection = False
        Me.tvAccounts.ItemHeight = 21
        Me.tvAccounts.ItemStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.ListItem
        Me.tvAccounts.Location = New System.Drawing.Point(12, 12)
        Me.tvAccounts.Name = "tvAccounts"
        Me.tvAccounts.Size = New System.Drawing.Size(177, 334)
        Me.tvAccounts.TabIndex = 1
        '
        'pbLogo
        '
        Me.pbLogo.Image = Global.justMail.My.Resources.Resources.icon
        Me.pbLogo.Location = New System.Drawing.Point(421, 271)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(76, 75)
        Me.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbLogo.TabIndex = 2
        Me.pbLogo.TabStop = False
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblEmail.Location = New System.Drawing.Point(198, 37)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(128, 17)
        Me.lblEmail.TabIndex = 4
        Me.lblEmail.Text = "beispiel@beispiel.de"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblTitle.Location = New System.Drawing.Point(195, 12)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(48, 25)
        Me.lblTitle.TabIndex = 3
        Me.lblTitle.Text = "Titel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(195, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "E-Mails im Posteingang"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(195, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 17)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "E-Mails im Postausgang"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label3.Location = New System.Drawing.Point(195, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "3"
        Me.Label3.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label4.Location = New System.Drawing.Point(228, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "beispiel@beispiel.de"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label5.Location = New System.Drawing.Point(243, 233)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 17)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "beispiel@beispiel.de"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.RadioButton1.Location = New System.Drawing.Point(195, 128)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(243, 21)
        Me.RadioButton1.TabIndex = 10
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "E-Mails auf dem Computer speichern"
        Me.RadioButton1.UseVisualStyleBackColor = True
        Me.RadioButton1.Visible = False
        '
        'KryptonTextBox1
        '
        Me.KryptonTextBox1.Location = New System.Drawing.Point(346, 74)
        Me.KryptonTextBox1.Name = "KryptonTextBox1"
        Me.KryptonTextBox1.Size = New System.Drawing.Size(151, 20)
        Me.KryptonTextBox1.TabIndex = 11
        Me.KryptonTextBox1.Text = "KryptonTextBox1"
        '
        'KryptonTextBox2
        '
        Me.KryptonTextBox2.Location = New System.Drawing.Point(346, 101)
        Me.KryptonTextBox2.Name = "KryptonTextBox2"
        Me.KryptonTextBox2.Size = New System.Drawing.Size(151, 20)
        Me.KryptonTextBox2.TabIndex = 12
        Me.KryptonTextBox2.Text = "KryptonTextBox2"
        '
        'KryptonTextBox3
        '
        Me.KryptonTextBox3.Location = New System.Drawing.Point(346, 127)
        Me.KryptonTextBox3.Name = "KryptonTextBox3"
        Me.KryptonTextBox3.Size = New System.Drawing.Size(151, 20)
        Me.KryptonTextBox3.TabIndex = 13
        Me.KryptonTextBox3.Text = "KryptonTextBox3"
        '
        'btnRemoveAcc
        '
        Me.btnRemoveAcc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnRemoveAcc.Location = New System.Drawing.Point(195, 73)
        Me.btnRemoveAcc.Name = "btnRemoveAcc"
        Me.btnRemoveAcc.Size = New System.Drawing.Size(148, 28)
        Me.btnRemoveAcc.TabIndex = 14
        Me.btnRemoveAcc.Values.Image = Global.justMail.My.Resources.Resources.new_email
        Me.btnRemoveAcc.Values.Text = "E-Mail-Konto löschen"
        '
        'frmSettingsAccounts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 358)
        Me.Controls.Add(Me.btnRemoveAcc)
        Me.Controls.Add(Me.KryptonTextBox3)
        Me.Controls.Add(Me.KryptonTextBox2)
        Me.Controls.Add(Me.KryptonTextBox1)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.tvAccounts)
        Me.Controls.Add(Me.pbLogo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSettingsAccounts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Verknüpfte Konten verwalten - justMail"
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tvAccounts As ComponentFactory.Krypton.Toolkit.KryptonTreeView
    Friend WithEvents pbLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents KryptonTextBox1 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonTextBox2 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonTextBox3 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents btnRemoveAcc As ComponentFactory.Krypton.Toolkit.KryptonButton
End Class
