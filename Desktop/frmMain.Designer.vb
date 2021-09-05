
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
        Me.splAccountsToListPRE = New System.Windows.Forms.SplitContainer()
        Me.tvAccounts = New ComponentFactory.Krypton.Toolkit.KryptonTreeView()
        Me.splMAILStoPREVIEW = New System.Windows.Forms.SplitContainer()
        Me.lvEmails = New System.Windows.Forms.ListView()
        Me.clmDateFull = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.clmSubject = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.clmBy = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.clmDateIn = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.menuPosteingang = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AnzeigenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AntwortenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WeiterleitenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MarkierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GelesenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UngelesenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SpeichernUnterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DruckvorschauToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DruckenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lvOutEmails = New System.Windows.Forms.ListView()
        Me.date2 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.clmSubjectOut = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.clmTo = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.clmDateOut = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.lblSelectNode = New System.Windows.Forms.Label()
        Me.wbPreviewEmail = New Gecko.GeckoWebBrowser()
        Me.pnlSTRleft2 = New System.Windows.Forms.Panel()
        Me.pnlMenuPreview = New System.Windows.Forms.Panel()
        Me.btnAttachments = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.pnlSplitter = New System.Windows.Forms.Panel()
        Me.lblTimeT = New System.Windows.Forms.Label()
        Me.btnSendAGN = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnAnswer = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.lblToT = New System.Windows.Forms.Label()
        Me.lblSubjectT = New System.Windows.Forms.Label()
        Me.lblByT = New System.Windows.Forms.Label()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.lblSubject = New System.Windows.Forms.Label()
        Me.lblBy = New System.Windows.Forms.Label()
        Me.pnlSTRbtm2 = New System.Windows.Forms.Panel()
        Me.pnlSTRtop = New System.Windows.Forms.Panel()
        Me.pnlSTRleft = New System.Windows.Forms.Panel()
        Me.rtbEmailPreview = New System.Windows.Forms.RichTextBox()
        Me.lblNoMails = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.menuRenew = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AlleKontenAbrufenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.reNewSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.barStatus = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatuzhjghjkgfgjk = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tmrAuto = New System.Windows.Forms.Timer(Me.components)
        Me.getEmailsSingle = New System.ComponentModel.BackgroundWorker()
        Me.getEmailsAll = New System.ComponentModel.BackgroundWorker()
        Me.KryptonContextMenuItems1 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem8 = New System.Windows.Forms.MenuItem()
        Me.MenuItem9 = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem14 = New System.Windows.Forms.MenuItem()
        Me.MenuItem16 = New System.Windows.Forms.MenuItem()
        Me.MenuItem17 = New System.Windows.Forms.MenuItem()
        Me.MenuItem18 = New System.Windows.Forms.MenuItem()
        Me.MenuItem19 = New System.Windows.Forms.MenuItem()
        Me.MenuItem20 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.MenuItem21 = New System.Windows.Forms.MenuItem()
        Me.MenuItem23 = New System.Windows.Forms.MenuItem()
        Me.MenuItem22 = New System.Windows.Forms.MenuItem()
        Me.MenuItem10 = New System.Windows.Forms.MenuItem()
        Me.MenuItem12 = New System.Windows.Forms.MenuItem()
        Me.MenuItem13 = New System.Windows.Forms.MenuItem()
        Me.MenuItem11 = New System.Windows.Forms.MenuItem()
        Me.MenuItem7 = New System.Windows.Forms.MenuItem()
        Me.MenuItem15 = New System.Windows.Forms.MenuItem()
        Me.MenuItem24 = New System.Windows.Forms.MenuItem()
        Me.MenuItem25 = New System.Windows.Forms.MenuItem()
        Me.tmrShowP = New System.Windows.Forms.Timer(Me.components)
        Me.tmrShowN = New System.Windows.Forms.Timer(Me.components)
        Me.tmrRefreshEmails = New System.Windows.Forms.Timer(Me.components)
        Me.pnlSTRbtm = New System.Windows.Forms.Panel()
        Me.updateCTRL = New updateSystemDotNet.updateController()
        Me.pnlMainMenu2 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tbSearch = New System.Windows.Forms.TextBox()
        Me.btnAddressBook = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnNewEmail = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btnRenew = New ComponentFactory.Krypton.Toolkit.KryptonDropButton()
        CType(Me.splAccountsToListPRE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splAccountsToListPRE.Panel1.SuspendLayout()
        Me.splAccountsToListPRE.Panel2.SuspendLayout()
        Me.splAccountsToListPRE.SuspendLayout()
        CType(Me.splMAILStoPREVIEW, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splMAILStoPREVIEW.Panel1.SuspendLayout()
        Me.splMAILStoPREVIEW.Panel2.SuspendLayout()
        Me.splMAILStoPREVIEW.SuspendLayout()
        Me.menuPosteingang.SuspendLayout()
        Me.pnlMenuPreview.SuspendLayout()
        Me.menuRenew.SuspendLayout()
        Me.barStatus.SuspendLayout()
        Me.pnlMainMenu2.SuspendLayout()
        Me.SuspendLayout()
        '
        'splAccountsToListPRE
        '
        Me.splAccountsToListPRE.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.splAccountsToListPRE.BackColor = System.Drawing.Color.Gainsboro
        Me.splAccountsToListPRE.Location = New System.Drawing.Point(0, 37)
        Me.splAccountsToListPRE.Name = "splAccountsToListPRE"
        '
        'splAccountsToListPRE.Panel1
        '
        Me.splAccountsToListPRE.Panel1.Controls.Add(Me.tvAccounts)
        Me.splAccountsToListPRE.Panel1MinSize = 0
        '
        'splAccountsToListPRE.Panel2
        '
        Me.splAccountsToListPRE.Panel2.Controls.Add(Me.splMAILStoPREVIEW)
        Me.splAccountsToListPRE.Panel2MinSize = 220
        Me.splAccountsToListPRE.Size = New System.Drawing.Size(1008, 373)
        Me.splAccountsToListPRE.SplitterDistance = 184
        Me.splAccountsToListPRE.TabIndex = 0
        '
        'tvAccounts
        '
        Me.tvAccounts.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ContextMenuHeading
        Me.tvAccounts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvAccounts.HideSelection = False
        Me.tvAccounts.ItemStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.InputControl
        Me.tvAccounts.Location = New System.Drawing.Point(0, 0)
        Me.tvAccounts.Name = "tvAccounts"
        Me.tvAccounts.Size = New System.Drawing.Size(184, 373)
        Me.tvAccounts.TabIndex = 0
        '
        'splMAILStoPREVIEW
        '
        Me.splMAILStoPREVIEW.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.splMAILStoPREVIEW.Location = New System.Drawing.Point(0, 0)
        Me.splMAILStoPREVIEW.Name = "splMAILStoPREVIEW"
        Me.splMAILStoPREVIEW.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splMAILStoPREVIEW.Panel1
        '
        Me.splMAILStoPREVIEW.Panel1.Controls.Add(Me.lvEmails)
        Me.splMAILStoPREVIEW.Panel1.Controls.Add(Me.lvOutEmails)
        Me.splMAILStoPREVIEW.Panel1.Controls.Add(Me.lblSelectNode)
        '
        'splMAILStoPREVIEW.Panel2
        '
        Me.splMAILStoPREVIEW.Panel2.Controls.Add(Me.wbPreviewEmail)
        Me.splMAILStoPREVIEW.Panel2.Controls.Add(Me.pnlSTRleft2)
        Me.splMAILStoPREVIEW.Panel2.Controls.Add(Me.pnlMenuPreview)
        Me.splMAILStoPREVIEW.Panel2.Controls.Add(Me.rtbEmailPreview)
        Me.splMAILStoPREVIEW.Panel2.Controls.Add(Me.lblNoMails)
        Me.splMAILStoPREVIEW.Size = New System.Drawing.Size(820, 373)
        Me.splMAILStoPREVIEW.SplitterDistance = 173
        Me.splMAILStoPREVIEW.TabIndex = 0
        '
        'lvEmails
        '
        Me.lvEmails.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmDateFull, Me.clmSubject, Me.clmBy, Me.clmDateIn})
        Me.lvEmails.ContextMenuStrip = Me.menuPosteingang
        Me.lvEmails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvEmails.FullRowSelect = True
        Me.lvEmails.HideSelection = False
        Me.lvEmails.Location = New System.Drawing.Point(0, 0)
        Me.lvEmails.Name = "lvEmails"
        Me.lvEmails.Size = New System.Drawing.Size(820, 173)
        Me.lvEmails.Sorting = System.Windows.Forms.SortOrder.Descending
        Me.lvEmails.TabIndex = 3
        Me.lvEmails.UseCompatibleStateImageBehavior = False
        Me.lvEmails.View = System.Windows.Forms.View.Details
        '
        'clmDateFull
        '
        Me.clmDateFull.Text = ""
        Me.clmDateFull.Width = 0
        '
        'clmSubject
        '
        Me.clmSubject.Text = "Betreff"
        Me.clmSubject.Width = 383
        '
        'clmBy
        '
        Me.clmBy.Text = "Von"
        Me.clmBy.Width = 249
        '
        'clmDateIn
        '
        Me.clmDateIn.Text = "Datum"
        Me.clmDateIn.Width = 159
        '
        'menuPosteingang
        '
        Me.menuPosteingang.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.menuPosteingang.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnzeigenToolStripMenuItem, Me.ToolStripSeparator1, Me.AntwortenToolStripMenuItem, Me.WeiterleitenToolStripMenuItem, Me.ToolStripSeparator2, Me.MarkierenToolStripMenuItem, Me.ToolStripSeparator3, Me.SpeichernUnterToolStripMenuItem, Me.DruckvorschauToolStripMenuItem, Me.DruckenToolStripMenuItem, Me.LöschenToolStripMenuItem})
        Me.menuPosteingang.Name = "menuPosteingang"
        Me.menuPosteingang.Size = New System.Drawing.Size(167, 198)
        '
        'AnzeigenToolStripMenuItem
        '
        Me.AnzeigenToolStripMenuItem.Name = "AnzeigenToolStripMenuItem"
        Me.AnzeigenToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.AnzeigenToolStripMenuItem.Text = "Anzeigen"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(163, 6)
        '
        'AntwortenToolStripMenuItem
        '
        Me.AntwortenToolStripMenuItem.Name = "AntwortenToolStripMenuItem"
        Me.AntwortenToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.AntwortenToolStripMenuItem.Text = "Antworten"
        '
        'WeiterleitenToolStripMenuItem
        '
        Me.WeiterleitenToolStripMenuItem.Name = "WeiterleitenToolStripMenuItem"
        Me.WeiterleitenToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.WeiterleitenToolStripMenuItem.Text = "Weiterleiten"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(163, 6)
        '
        'MarkierenToolStripMenuItem
        '
        Me.MarkierenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GelesenToolStripMenuItem, Me.UngelesenToolStripMenuItem})
        Me.MarkierenToolStripMenuItem.Name = "MarkierenToolStripMenuItem"
        Me.MarkierenToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.MarkierenToolStripMenuItem.Text = "Markieren"
        '
        'GelesenToolStripMenuItem
        '
        Me.GelesenToolStripMenuItem.Name = "GelesenToolStripMenuItem"
        Me.GelesenToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.GelesenToolStripMenuItem.Text = "Gelesen"
        '
        'UngelesenToolStripMenuItem
        '
        Me.UngelesenToolStripMenuItem.Name = "UngelesenToolStripMenuItem"
        Me.UngelesenToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.UngelesenToolStripMenuItem.Text = "Ungelesen"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(163, 6)
        '
        'SpeichernUnterToolStripMenuItem
        '
        Me.SpeichernUnterToolStripMenuItem.Name = "SpeichernUnterToolStripMenuItem"
        Me.SpeichernUnterToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.SpeichernUnterToolStripMenuItem.Text = "Speichern unter..."
        '
        'DruckvorschauToolStripMenuItem
        '
        Me.DruckvorschauToolStripMenuItem.Name = "DruckvorschauToolStripMenuItem"
        Me.DruckvorschauToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.DruckvorschauToolStripMenuItem.Text = "Druckvorschau"
        '
        'DruckenToolStripMenuItem
        '
        Me.DruckenToolStripMenuItem.Name = "DruckenToolStripMenuItem"
        Me.DruckenToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.DruckenToolStripMenuItem.Text = "Drucken..."
        '
        'LöschenToolStripMenuItem
        '
        Me.LöschenToolStripMenuItem.Name = "LöschenToolStripMenuItem"
        Me.LöschenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.LöschenToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.LöschenToolStripMenuItem.Text = "Löschen"
        '
        'lvOutEmails
        '
        Me.lvOutEmails.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.date2, Me.clmSubjectOut, Me.clmTo, Me.clmDateOut})
        Me.lvOutEmails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvOutEmails.FullRowSelect = True
        Me.lvOutEmails.HideSelection = False
        Me.lvOutEmails.Location = New System.Drawing.Point(0, 0)
        Me.lvOutEmails.Name = "lvOutEmails"
        Me.lvOutEmails.Size = New System.Drawing.Size(820, 173)
        Me.lvOutEmails.Sorting = System.Windows.Forms.SortOrder.Descending
        Me.lvOutEmails.TabIndex = 1
        Me.lvOutEmails.UseCompatibleStateImageBehavior = False
        Me.lvOutEmails.View = System.Windows.Forms.View.Details
        '
        'date2
        '
        Me.date2.Text = ""
        Me.date2.Width = 0
        '
        'clmSubjectOut
        '
        Me.clmSubjectOut.Text = "Betreff"
        Me.clmSubjectOut.Width = 383
        '
        'clmTo
        '
        Me.clmTo.Text = "Empfänger"
        Me.clmTo.Width = 249
        '
        'clmDateOut
        '
        Me.clmDateOut.Text = "Datum"
        Me.clmDateOut.Width = 159
        '
        'lblSelectNode
        '
        Me.lblSelectNode.AutoSize = True
        Me.lblSelectNode.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblSelectNode.ForeColor = System.Drawing.Color.Gray
        Me.lblSelectNode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSelectNode.Location = New System.Drawing.Point(3, 21)
        Me.lblSelectNode.Name = "lblSelectNode"
        Me.lblSelectNode.Size = New System.Drawing.Size(516, 25)
        Me.lblSelectNode.TabIndex = 2
        Me.lblSelectNode.Text = "Bitte wählen Sie einen Unterordner aus Ihrem Konto aus."
        '
        'wbPreviewEmail
        '
        Me.wbPreviewEmail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wbPreviewEmail.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.wbPreviewEmail.Location = New System.Drawing.Point(1, 85)
        Me.wbPreviewEmail.Name = "wbPreviewEmail"
        Me.wbPreviewEmail.NoDefaultContextMenu = True
        Me.wbPreviewEmail.Size = New System.Drawing.Size(818, 111)
        Me.wbPreviewEmail.TabIndex = 13
        Me.wbPreviewEmail.UseHttpActivityObserver = False
        '
        'pnlSTRleft2
        '
        Me.pnlSTRleft2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlSTRleft2.BackColor = System.Drawing.Color.Gray
        Me.pnlSTRleft2.Location = New System.Drawing.Point(0, 73)
        Me.pnlSTRleft2.Name = "pnlSTRleft2"
        Me.pnlSTRleft2.Size = New System.Drawing.Size(1, 123)
        Me.pnlSTRleft2.TabIndex = 11
        '
        'pnlMenuPreview
        '
        Me.pnlMenuPreview.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlMenuPreview.Controls.Add(Me.btnAttachments)
        Me.pnlMenuPreview.Controls.Add(Me.pnlSplitter)
        Me.pnlMenuPreview.Controls.Add(Me.lblTimeT)
        Me.pnlMenuPreview.Controls.Add(Me.btnSendAGN)
        Me.pnlMenuPreview.Controls.Add(Me.btnAnswer)
        Me.pnlMenuPreview.Controls.Add(Me.lblToT)
        Me.pnlMenuPreview.Controls.Add(Me.lblSubjectT)
        Me.pnlMenuPreview.Controls.Add(Me.lblByT)
        Me.pnlMenuPreview.Controls.Add(Me.lblTo)
        Me.pnlMenuPreview.Controls.Add(Me.lblSubject)
        Me.pnlMenuPreview.Controls.Add(Me.lblBy)
        Me.pnlMenuPreview.Controls.Add(Me.pnlSTRbtm2)
        Me.pnlMenuPreview.Controls.Add(Me.pnlSTRtop)
        Me.pnlMenuPreview.Controls.Add(Me.pnlSTRleft)
        Me.pnlMenuPreview.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMenuPreview.Location = New System.Drawing.Point(0, 0)
        Me.pnlMenuPreview.Name = "pnlMenuPreview"
        Me.pnlMenuPreview.Size = New System.Drawing.Size(820, 84)
        Me.pnlMenuPreview.TabIndex = 2
        Me.pnlMenuPreview.Visible = False
        '
        'btnAttachments
        '
        Me.btnAttachments.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAttachments.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAttachments.Location = New System.Drawing.Point(627, 35)
        Me.btnAttachments.Name = "btnAttachments"
        Me.btnAttachments.Size = New System.Drawing.Size(186, 25)
        Me.btnAttachments.TabIndex = 22
        Me.btnAttachments.Values.Text = "Anhänge"
        '
        'pnlSplitter
        '
        Me.pnlSplitter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSplitter.BackColor = System.Drawing.Color.Gray
        Me.pnlSplitter.Location = New System.Drawing.Point(0, 83)
        Me.pnlSplitter.Name = "pnlSplitter"
        Me.pnlSplitter.Size = New System.Drawing.Size(825, 1)
        Me.pnlSplitter.TabIndex = 12
        '
        'lblTimeT
        '
        Me.lblTimeT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTimeT.AutoSize = True
        Me.lblTimeT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTimeT.Location = New System.Drawing.Point(710, 65)
        Me.lblTimeT.Name = "lblTimeT"
        Me.lblTimeT.Size = New System.Drawing.Size(40, 13)
        Me.lblTimeT.TabIndex = 21
        Me.lblTimeT.Text = "Uhrzeit"
        Me.lblTimeT.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblTimeT.Visible = False
        '
        'btnSendAGN
        '
        Me.btnSendAGN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSendAGN.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSendAGN.Location = New System.Drawing.Point(723, 7)
        Me.btnSendAGN.Name = "btnSendAGN"
        Me.btnSendAGN.TabIndex = 20
        Me.btnSendAGN.Values.Text = "Weiterleiten"
        '
        'btnAnswer
        '
        Me.btnAnswer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnswer.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAnswer.Location = New System.Drawing.Point(627, 7)
        Me.btnAnswer.Name = "btnAnswer"
        Me.btnAnswer.TabIndex = 19
        Me.btnAnswer.Values.Text = "Antworten"
        '
        'lblToT
        '
        Me.lblToT.AutoSize = True
        Me.lblToT.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblToT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblToT.Location = New System.Drawing.Point(47, 55)
        Me.lblToT.Name = "lblToT"
        Me.lblToT.Size = New System.Drawing.Size(21, 13)
        Me.lblToT.TabIndex = 18
        Me.lblToT.Text = "An"
        '
        'lblSubjectT
        '
        Me.lblSubjectT.AutoSize = True
        Me.lblSubjectT.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSubjectT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSubjectT.Location = New System.Drawing.Point(47, 33)
        Me.lblSubjectT.Name = "lblSubjectT"
        Me.lblSubjectT.Size = New System.Drawing.Size(42, 13)
        Me.lblSubjectT.TabIndex = 17
        Me.lblSubjectT.Text = "Betreff"
        '
        'lblByT
        '
        Me.lblByT.AutoSize = True
        Me.lblByT.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblByT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblByT.Location = New System.Drawing.Point(47, 11)
        Me.lblByT.Name = "lblByT"
        Me.lblByT.Size = New System.Drawing.Size(27, 13)
        Me.lblByT.TabIndex = 16
        Me.lblByT.Text = "Von"
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblTo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTo.Location = New System.Drawing.Point(3, 55)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(21, 13)
        Me.lblTo.TabIndex = 15
        Me.lblTo.Text = "An"
        '
        'lblSubject
        '
        Me.lblSubject.AutoSize = True
        Me.lblSubject.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblSubject.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSubject.Location = New System.Drawing.Point(3, 33)
        Me.lblSubject.Name = "lblSubject"
        Me.lblSubject.Size = New System.Drawing.Size(42, 13)
        Me.lblSubject.TabIndex = 14
        Me.lblSubject.Text = "Betreff"
        '
        'lblBy
        '
        Me.lblBy.AutoSize = True
        Me.lblBy.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblBy.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBy.Location = New System.Drawing.Point(3, 11)
        Me.lblBy.Name = "lblBy"
        Me.lblBy.Size = New System.Drawing.Size(27, 13)
        Me.lblBy.TabIndex = 13
        Me.lblBy.Text = "Von"
        '
        'pnlSTRbtm2
        '
        Me.pnlSTRbtm2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSTRbtm2.BackColor = System.Drawing.Color.Gray
        Me.pnlSTRbtm2.Location = New System.Drawing.Point(0, 84)
        Me.pnlSTRbtm2.Name = "pnlSTRbtm2"
        Me.pnlSTRbtm2.Size = New System.Drawing.Size(820, 1)
        Me.pnlSTRbtm2.TabIndex = 12
        Me.pnlSTRbtm2.Visible = False
        '
        'pnlSTRtop
        '
        Me.pnlSTRtop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSTRtop.BackColor = System.Drawing.Color.Gray
        Me.pnlSTRtop.Location = New System.Drawing.Point(1, 0)
        Me.pnlSTRtop.Name = "pnlSTRtop"
        Me.pnlSTRtop.Size = New System.Drawing.Size(820, 1)
        Me.pnlSTRtop.TabIndex = 11
        Me.pnlSTRtop.Visible = False
        '
        'pnlSTRleft
        '
        Me.pnlSTRleft.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlSTRleft.BackColor = System.Drawing.Color.Gray
        Me.pnlSTRleft.Location = New System.Drawing.Point(0, 0)
        Me.pnlSTRleft.Name = "pnlSTRleft"
        Me.pnlSTRleft.Size = New System.Drawing.Size(1, 84)
        Me.pnlSTRleft.TabIndex = 10
        Me.pnlSTRleft.Visible = False
        '
        'rtbEmailPreview
        '
        Me.rtbEmailPreview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbEmailPreview.AutoWordSelection = True
        Me.rtbEmailPreview.BackColor = System.Drawing.Color.White
        Me.rtbEmailPreview.Cursor = System.Windows.Forms.Cursors.Default
        Me.rtbEmailPreview.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.rtbEmailPreview.Location = New System.Drawing.Point(0, 83)
        Me.rtbEmailPreview.Name = "rtbEmailPreview"
        Me.rtbEmailPreview.ReadOnly = True
        Me.rtbEmailPreview.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.rtbEmailPreview.Size = New System.Drawing.Size(820, 113)
        Me.rtbEmailPreview.TabIndex = 1
        Me.rtbEmailPreview.Text = ""
        Me.rtbEmailPreview.Visible = False
        '
        'lblNoMails
        '
        Me.lblNoMails.AutoSize = True
        Me.lblNoMails.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblNoMails.ForeColor = System.Drawing.Color.Gray
        Me.lblNoMails.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNoMails.Location = New System.Drawing.Point(3, 8)
        Me.lblNoMails.Name = "lblNoMails"
        Me.lblNoMails.Size = New System.Drawing.Size(422, 25)
        Me.lblNoMails.TabIndex = 3
        Me.lblNoMails.Text = "Dieser Unterordner enthält keine Nachrichten."
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "attachment.png")
        '
        'menuRenew
        '
        Me.menuRenew.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.menuRenew.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AlleKontenAbrufenToolStripMenuItem, Me.reNewSep1})
        Me.menuRenew.Name = "menuRenew"
        Me.menuRenew.Size = New System.Drawing.Size(180, 32)
        '
        'AlleKontenAbrufenToolStripMenuItem
        '
        Me.AlleKontenAbrufenToolStripMenuItem.Name = "AlleKontenAbrufenToolStripMenuItem"
        Me.AlleKontenAbrufenToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.AlleKontenAbrufenToolStripMenuItem.Text = "Alle Konten abrufen"
        '
        'reNewSep1
        '
        Me.reNewSep1.Name = "reNewSep1"
        Me.reNewSep1.Size = New System.Drawing.Size(176, 6)
        '
        'barStatus
        '
        Me.barStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.barStatus.Location = New System.Drawing.Point(0, 408)
        Me.barStatus.Name = "barStatus"
        Me.barStatus.Size = New System.Drawing.Size(1008, 22)
        Me.barStatus.TabIndex = 3
        Me.barStatus.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(42, 17)
        Me.lblStatus.Text = "Status:"
        '
        'lblStatuzhjghjkgfgjk
        '
        Me.lblStatuzhjghjkgfgjk.BackColor = System.Drawing.Color.Transparent
        Me.lblStatuzhjghjkgfgjk.Name = "lblStatuzhjghjkgfgjk"
        Me.lblStatuzhjghjkgfgjk.Size = New System.Drawing.Size(42, 17)
        Me.lblStatuzhjghjkgfgjk.Text = "Status:"
        '
        'tmrAuto
        '
        Me.tmrAuto.Enabled = True
        Me.tmrAuto.Interval = 10
        '
        'getEmailsSingle
        '
        '
        'getEmailsAll
        '
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2, Me.MenuItem3, Me.MenuItem4, Me.MenuItem5, Me.MenuItem6, Me.MenuItem7})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem8})
        Me.MenuItem1.Text = "Datei"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 0
        Me.MenuItem8.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem9})
        Me.MenuItem8.Text = "Neu"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 0
        Me.MenuItem9.Text = "Neue E-Mail"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem14, Me.MenuItem16, Me.MenuItem17, Me.MenuItem18, Me.MenuItem19, Me.MenuItem20})
        Me.MenuItem2.Text = "Bearbeiten"
        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 0
        Me.MenuItem14.Text = "Rückgängig"
        '
        'MenuItem16
        '
        Me.MenuItem16.Index = 1
        Me.MenuItem16.Text = "-"
        '
        'MenuItem17
        '
        Me.MenuItem17.Index = 2
        Me.MenuItem17.Text = "Ausschneiden"
        '
        'MenuItem18
        '
        Me.MenuItem18.Index = 3
        Me.MenuItem18.Text = "Kopieren"
        '
        'MenuItem19
        '
        Me.MenuItem19.Index = 4
        Me.MenuItem19.Text = "Einfügen"
        '
        'MenuItem20
        '
        Me.MenuItem20.Index = 5
        Me.MenuItem20.Text = "Löschen"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 2
        Me.MenuItem3.Text = "Ansicht"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 3
        Me.MenuItem4.Text = "Navigieren"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 4
        Me.MenuItem5.Text = "Aktionen"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 5
        Me.MenuItem6.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem21, Me.MenuItem23, Me.MenuItem22, Me.MenuItem10, Me.MenuItem12, Me.MenuItem13, Me.MenuItem11})
        Me.MenuItem6.Text = "Extras"
        '
        'MenuItem21
        '
        Me.MenuItem21.Index = 0
        Me.MenuItem21.Text = "Adressbuch"
        '
        'MenuItem23
        '
        Me.MenuItem23.Index = 1
        Me.MenuItem23.Text = "Junk-Filter"
        '
        'MenuItem22
        '
        Me.MenuItem22.Index = 2
        Me.MenuItem22.Text = "-"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 3
        Me.MenuItem10.Text = "Existierende Konten bearbeiten"
        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 4
        Me.MenuItem12.Text = "Neues Konto anlegen"
        '
        'MenuItem13
        '
        Me.MenuItem13.Index = 5
        Me.MenuItem13.Text = "-"
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 6
        Me.MenuItem11.Text = "Einstellungen"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 6
        Me.MenuItem7.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem15, Me.MenuItem24, Me.MenuItem25})
        Me.MenuItem7.Text = "Hilfe"
        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 0
        Me.MenuItem15.Text = "Auf Aktualisierung prüfen..."
        '
        'MenuItem24
        '
        Me.MenuItem24.Index = 1
        Me.MenuItem24.Text = "-"
        '
        'MenuItem25
        '
        Me.MenuItem25.Index = 2
        Me.MenuItem25.Text = "Über justMail"
        '
        'tmrShowP
        '
        Me.tmrShowP.Interval = 10
        '
        'tmrShowN
        '
        Me.tmrShowN.Interval = 10
        '
        'tmrRefreshEmails
        '
        Me.tmrRefreshEmails.Enabled = True
        Me.tmrRefreshEmails.Interval = 900000
        '
        'pnlSTRbtm
        '
        Me.pnlSTRbtm.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSTRbtm.BackColor = System.Drawing.Color.Gray
        Me.pnlSTRbtm.Location = New System.Drawing.Point(0, 37)
        Me.pnlSTRbtm.Name = "pnlSTRbtm"
        Me.pnlSTRbtm.Size = New System.Drawing.Size(1008, 1)
        Me.pnlSTRbtm.TabIndex = 2
        '
        'updateCTRL
        '
        Me.updateCTRL.applicationLocation = ""
        Me.updateCTRL.projectId = "8542b445-8c39-4535-820f-b8b7cfa2f29b"
        Me.updateCTRL.proxyPassword = Nothing
        Me.updateCTRL.proxyUrl = Nothing
        Me.updateCTRL.proxyUsername = Nothing
        Me.updateCTRL.publicKey = resources.GetString("updateCTRL.publicKey")
        Me.updateCTRL.releaseFilter.checkForAlpha = False
        Me.updateCTRL.releaseFilter.checkForBeta = False
        Me.updateCTRL.releaseFilter.checkForFinal = True
        Me.updateCTRL.releaseInfo.Version = ""
        Me.updateCTRL.requestElevation = True
        Me.updateCTRL.updateUrl = "http://it-just.net/justMail/versions/"
        '
        'pnlMainMenu2
        '
        Me.pnlMainMenu2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMainMenu2.BackColor = System.Drawing.Color.Gainsboro
        Me.pnlMainMenu2.BackgroundImage = CType(resources.GetObject("pnlMainMenu2.BackgroundImage"), System.Drawing.Image)
        Me.pnlMainMenu2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlMainMenu2.Controls.Add(Me.Button1)
        Me.pnlMainMenu2.Controls.Add(Me.tbSearch)
        Me.pnlMainMenu2.Controls.Add(Me.btnAddressBook)
        Me.pnlMainMenu2.Controls.Add(Me.btnNewEmail)
        Me.pnlMainMenu2.Controls.Add(Me.btnRenew)
        Me.pnlMainMenu2.Location = New System.Drawing.Point(0, -1)
        Me.pnlMainMenu2.Name = "pnlMainMenu2"
        Me.pnlMainMenu2.Size = New System.Drawing.Size(1008, 38)
        Me.pnlMainMenu2.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(430, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tbSearch
        '
        Me.tbSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSearch.BackColor = System.Drawing.SystemColors.Window
        Me.tbSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tbSearch.Location = New System.Drawing.Point(770, 6)
        Me.tbSearch.Name = "tbSearch"
        Me.tbSearch.Size = New System.Drawing.Size(226, 23)
        Me.tbSearch.TabIndex = 4
        Me.tbSearch.Text = "Suchen nach..."
        '
        'btnAddressBook
        '
        Me.btnAddressBook.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAddressBook.Location = New System.Drawing.Point(278, 4)
        Me.btnAddressBook.Name = "btnAddressBook"
        Me.btnAddressBook.Size = New System.Drawing.Size(120, 28)
        Me.btnAddressBook.TabIndex = 4
        Me.btnAddressBook.Values.Image = Global.justMail.My.Resources.Resources.addressbook_icon
        Me.btnAddressBook.Values.Text = "Adressbuch"
        '
        'btnNewEmail
        '
        Me.btnNewEmail.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnNewEmail.Location = New System.Drawing.Point(152, 4)
        Me.btnNewEmail.Name = "btnNewEmail"
        Me.btnNewEmail.Size = New System.Drawing.Size(120, 28)
        Me.btnNewEmail.TabIndex = 2
        Me.btnNewEmail.Values.Image = Global.justMail.My.Resources.Resources.new_email
        Me.btnNewEmail.Values.Text = "Neue E-Mail"
        '
        'btnRenew
        '
        Me.btnRenew.ContextMenuStrip = Me.menuRenew
        Me.btnRenew.Images.Common = Global.justMail.My.Resources.Resources.refresh_emails_icon
        Me.btnRenew.Images.Normal = Global.justMail.My.Resources.Resources.refresh_emails_icon
        Me.btnRenew.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnRenew.Location = New System.Drawing.Point(12, 4)
        Me.btnRenew.Name = "btnRenew"
        Me.btnRenew.Size = New System.Drawing.Size(130, 29)
        Me.btnRenew.TabIndex = 0
        Me.btnRenew.Values.Image = Global.justMail.My.Resources.Resources.refresh_emails_icon
        Me.btnRenew.Values.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.btnRenew.Values.Text = "Empfangen"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1008, 430)
        Me.Controls.Add(Me.barStatus)
        Me.Controls.Add(Me.pnlSTRbtm)
        Me.Controls.Add(Me.pnlMainMenu2)
        Me.Controls.Add(Me.splAccountsToListPRE)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.MainMenu1
        Me.MinimumSize = New System.Drawing.Size(405, 255)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "justMail"
        Me.splAccountsToListPRE.Panel1.ResumeLayout(False)
        Me.splAccountsToListPRE.Panel2.ResumeLayout(False)
        CType(Me.splAccountsToListPRE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splAccountsToListPRE.ResumeLayout(False)
        Me.splMAILStoPREVIEW.Panel1.ResumeLayout(False)
        Me.splMAILStoPREVIEW.Panel1.PerformLayout()
        Me.splMAILStoPREVIEW.Panel2.ResumeLayout(False)
        Me.splMAILStoPREVIEW.Panel2.PerformLayout()
        CType(Me.splMAILStoPREVIEW, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splMAILStoPREVIEW.ResumeLayout(False)
        Me.menuPosteingang.ResumeLayout(False)
        Me.pnlMenuPreview.ResumeLayout(False)
        Me.pnlMenuPreview.PerformLayout()
        Me.menuRenew.ResumeLayout(False)
        Me.barStatus.ResumeLayout(False)
        Me.barStatus.PerformLayout()
        Me.pnlMainMenu2.ResumeLayout(False)
        Me.pnlMainMenu2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents splAccountsToListPRE As System.Windows.Forms.SplitContainer
    Friend WithEvents splMAILStoPREVIEW As System.Windows.Forms.SplitContainer
    Friend WithEvents pnlMainMenu2 As System.Windows.Forms.Panel
    Friend WithEvents tvAccounts As ComponentFactory.Krypton.Toolkit.KryptonTreeView
    Friend WithEvents menuRenew As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AlleKontenAbrufenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents reNewSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnRenew As ComponentFactory.Krypton.Toolkit.KryptonDropButton
    Friend WithEvents btnNewEmail As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnAddressBook As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents barStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents lvOutEmails As System.Windows.Forms.ListView
    Friend WithEvents clmSubjectOut As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmTo As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmDateOut As System.Windows.Forms.ColumnHeader
    Friend WithEvents tmrAuto As System.Windows.Forms.Timer
    Friend WithEvents getEmailsSingle As System.ComponentModel.BackgroundWorker
    Friend WithEvents getEmailsAll As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblStatuzhjghjkgfgjk As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents rtbEmailPreview As System.Windows.Forms.RichTextBox
    Friend WithEvents pnlMenuPreview As System.Windows.Forms.Panel
    Friend WithEvents pnlSTRleft As System.Windows.Forms.Panel
    Friend WithEvents pnlSTRtop As System.Windows.Forms.Panel
    Friend WithEvents pnlSTRbtm2 As System.Windows.Forms.Panel
    Friend WithEvents lblSelectNode As System.Windows.Forms.Label
    Friend WithEvents lblToT As System.Windows.Forms.Label
    Friend WithEvents lblSubjectT As System.Windows.Forms.Label
    Friend WithEvents lblByT As System.Windows.Forms.Label
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents lblSubject As System.Windows.Forms.Label
    Friend WithEvents lblBy As System.Windows.Forms.Label
    Friend WithEvents btnSendAGN As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btnAnswer As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents lblTimeT As System.Windows.Forms.Label
    Friend WithEvents menuPosteingang As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AnzeigenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AntwortenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WeiterleitenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MarkierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GelesenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UngelesenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SpeichernUnterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DruckvorschauToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DruckenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LöschenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KryptonContextMenuItems1 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents lblNoMails As System.Windows.Forms.Label
    Friend WithEvents pnlSTRleft2 As System.Windows.Forms.Panel
    Friend WithEvents pnlSplitter As System.Windows.Forms.Panel
    Friend WithEvents date2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tmrShowP As System.Windows.Forms.Timer
    Friend WithEvents tmrShowN As System.Windows.Forms.Timer
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem16 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem17 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem18 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem19 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem20 As System.Windows.Forms.MenuItem
    Friend WithEvents tmrRefreshEmails As System.Windows.Forms.Timer
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnAttachments As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents wbPreviewEmail As Gecko.GeckoWebBrowser
    Friend WithEvents MenuItem21 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem22 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem23 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem24 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem25 As System.Windows.Forms.MenuItem
    Friend WithEvents pnlSTRbtm As System.Windows.Forms.Panel
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lvEmails As System.Windows.Forms.ListView
    Friend WithEvents clmDateFull As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmSubject As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmBy As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmDateIn As System.Windows.Forms.ColumnHeader
    Friend WithEvents updateCTRL As updateSystemDotNet.updateController
    Friend WithEvents tbSearch As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    'Friend WithEvents updateCTRL As updateSystemDotNet.updateController
End Class
