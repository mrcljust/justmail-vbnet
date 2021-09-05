<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJunkFilter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJunkFilter))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tvAccounts = New ComponentFactory.Krypton.Toolkit.KryptonTreeView()
        Me.btnNewEmail = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.clmWhat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmDoes = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmString = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clmAction = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Gainsboro
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tvAccounts)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnNewEmail)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ListView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(731, 287)
        Me.SplitContainer1.SplitterDistance = 187
        Me.SplitContainer1.TabIndex = 0
        '
        'tvAccounts
        '
        Me.tvAccounts.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ContextMenuHeading
        Me.tvAccounts.BorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.InputControlStandalone
        Me.tvAccounts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvAccounts.HideSelection = False
        Me.tvAccounts.ItemHeight = 21
        Me.tvAccounts.ItemStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.InputControl
        Me.tvAccounts.Location = New System.Drawing.Point(0, 0)
        Me.tvAccounts.Name = "tvAccounts"
        Me.tvAccounts.Size = New System.Drawing.Size(187, 287)
        Me.tvAccounts.TabIndex = 1
        '
        'btnNewEmail
        '
        Me.btnNewEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNewEmail.Location = New System.Drawing.Point(5, 253)
        Me.btnNewEmail.Name = "btnNewEmail"
        Me.btnNewEmail.Size = New System.Drawing.Size(120, 28)
        Me.btnNewEmail.TabIndex = 3
        Me.btnNewEmail.Values.Image = Global.justMail.My.Resources.Resources.new_email
        Me.btnNewEmail.Values.Text = "Neuen Filter"
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmWhat, Me.clmDoes, Me.clmString, Me.clmAction})
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(577, 250)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'clmWhat
        '
        Me.clmWhat.Text = ""
        Me.clmWhat.Width = 126
        '
        'clmDoes
        '
        Me.clmDoes.Text = ""
        Me.clmDoes.Width = 126
        '
        'clmString
        '
        Me.clmString.Text = ""
        Me.clmString.Width = 126
        '
        'clmAction
        '
        Me.clmAction.Text = ""
        Me.clmAction.Width = 126
        '
        'frmJunkFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 287)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(471, 288)
        Me.Name = "frmJunkFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Junk-Filter - justMail"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents tvAccounts As ComponentFactory.Krypton.Toolkit.KryptonTreeView
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents btnNewEmail As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents clmWhat As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmDoes As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmString As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmAction As System.Windows.Forms.ColumnHeader
End Class
