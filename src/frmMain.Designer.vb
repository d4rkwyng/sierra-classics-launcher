<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.chkCloseWindow = New System.Windows.Forms.CheckBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnViewManual = New System.Windows.Forms.Button()
        Me.picGame = New System.Windows.Forms.PictureBox()
        Me.grpGame7 = New System.Windows.Forms.GroupBox()
        Me.btnGame7 = New System.Windows.Forms.Button()
        Me.grpGame6 = New System.Windows.Forms.GroupBox()
        Me.btnGame6 = New System.Windows.Forms.Button()
        Me.grpGame5 = New System.Windows.Forms.GroupBox()
        Me.btnGame5 = New System.Windows.Forms.Button()
        Me.grpGame4 = New System.Windows.Forms.GroupBox()
        Me.btnGame4 = New System.Windows.Forms.Button()
        Me.grpGame3 = New System.Windows.Forms.GroupBox()
        Me.btnGame3 = New System.Windows.Forms.Button()
        Me.grpGame2 = New System.Windows.Forms.GroupBox()
        Me.btnGame2 = New System.Windows.Forms.Button()
        Me.grpGame1 = New System.Windows.Forms.GroupBox()
        Me.btnGame1 = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuToolsReload = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuToolsPreferences = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboDatabase = New System.Windows.Forms.ComboBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblFailLoad = New System.Windows.Forms.Label()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        CType(Me.picGame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpGame7.SuspendLayout()
        Me.grpGame6.SuspendLayout()
        Me.grpGame5.SuspendLayout()
        Me.grpGame4.SuspendLayout()
        Me.grpGame3.SuspendLayout()
        Me.grpGame2.SuspendLayout()
        Me.grpGame1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkCloseWindow
        '
        Me.chkCloseWindow.AutoSize = True
        Me.chkCloseWindow.Location = New System.Drawing.Point(27, 456)
        Me.chkCloseWindow.Name = "chkCloseWindow"
        Me.chkCloseWindow.Size = New System.Drawing.Size(141, 17)
        Me.chkCloseWindow.TabIndex = 9
        Me.chkCloseWindow.Text = "Close window on launch"
        Me.ToolTip1.SetToolTip(Me.chkCloseWindow, "Close the program when launching the game")
        Me.chkCloseWindow.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(108, 427)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 23)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Close"
        Me.ToolTip1.SetToolTip(Me.btnClose, "Close the application")
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnViewManual
        '
        Me.btnViewManual.Location = New System.Drawing.Point(12, 427)
        Me.btnViewManual.Name = "btnViewManual"
        Me.btnViewManual.Size = New System.Drawing.Size(76, 23)
        Me.btnViewManual.TabIndex = 7
        Me.btnViewManual.Text = "View Manual"
        Me.ToolTip1.SetToolTip(Me.btnViewManual, "View game manual")
        Me.btnViewManual.UseVisualStyleBackColor = True
        '
        'picGame
        '
        Me.picGame.Location = New System.Drawing.Point(193, 27)
        Me.picGame.Name = "picGame"
        Me.picGame.Size = New System.Drawing.Size(404, 477)
        Me.picGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picGame.TabIndex = 20
        Me.picGame.TabStop = False
        '
        'grpGame7
        '
        Me.grpGame7.Controls.Add(Me.btnGame7)
        Me.grpGame7.Location = New System.Drawing.Point(12, 363)
        Me.grpGame7.Name = "grpGame7"
        Me.grpGame7.Size = New System.Drawing.Size(172, 49)
        Me.grpGame7.TabIndex = 6
        Me.grpGame7.TabStop = False
        Me.grpGame7.Text = "Game 7"
        Me.grpGame7.Visible = False
        '
        'btnGame7
        '
        Me.btnGame7.Location = New System.Drawing.Point(6, 21)
        Me.btnGame7.Name = "btnGame7"
        Me.btnGame7.Size = New System.Drawing.Size(160, 23)
        Me.btnGame7.TabIndex = 6
        Me.btnGame7.Text = "Launch"
        Me.btnGame7.UseVisualStyleBackColor = True
        '
        'grpGame6
        '
        Me.grpGame6.Controls.Add(Me.btnGame6)
        Me.grpGame6.Location = New System.Drawing.Point(12, 307)
        Me.grpGame6.Name = "grpGame6"
        Me.grpGame6.Size = New System.Drawing.Size(172, 50)
        Me.grpGame6.TabIndex = 5
        Me.grpGame6.TabStop = False
        Me.grpGame6.Text = "Game 6"
        Me.grpGame6.Visible = False
        '
        'btnGame6
        '
        Me.btnGame6.Location = New System.Drawing.Point(6, 21)
        Me.btnGame6.Name = "btnGame6"
        Me.btnGame6.Size = New System.Drawing.Size(160, 23)
        Me.btnGame6.TabIndex = 5
        Me.btnGame6.Text = "Launch"
        Me.btnGame6.UseVisualStyleBackColor = True
        '
        'grpGame5
        '
        Me.grpGame5.Controls.Add(Me.btnGame5)
        Me.grpGame5.Location = New System.Drawing.Point(12, 251)
        Me.grpGame5.Name = "grpGame5"
        Me.grpGame5.Size = New System.Drawing.Size(172, 50)
        Me.grpGame5.TabIndex = 4
        Me.grpGame5.TabStop = False
        Me.grpGame5.Text = "Game 5"
        Me.grpGame5.Visible = False
        '
        'btnGame5
        '
        Me.btnGame5.Location = New System.Drawing.Point(6, 21)
        Me.btnGame5.Name = "btnGame5"
        Me.btnGame5.Size = New System.Drawing.Size(160, 23)
        Me.btnGame5.TabIndex = 4
        Me.btnGame5.Text = "Launch"
        Me.btnGame5.UseVisualStyleBackColor = True
        '
        'grpGame4
        '
        Me.grpGame4.Controls.Add(Me.btnGame4)
        Me.grpGame4.Location = New System.Drawing.Point(12, 195)
        Me.grpGame4.Name = "grpGame4"
        Me.grpGame4.Size = New System.Drawing.Size(172, 50)
        Me.grpGame4.TabIndex = 3
        Me.grpGame4.TabStop = False
        Me.grpGame4.Text = "Game 4"
        Me.grpGame4.Visible = False
        '
        'btnGame4
        '
        Me.btnGame4.Location = New System.Drawing.Point(6, 21)
        Me.btnGame4.Name = "btnGame4"
        Me.btnGame4.Size = New System.Drawing.Size(160, 23)
        Me.btnGame4.TabIndex = 3
        Me.btnGame4.Text = "Launch"
        Me.btnGame4.UseVisualStyleBackColor = True
        '
        'grpGame3
        '
        Me.grpGame3.Controls.Add(Me.btnGame3)
        Me.grpGame3.Location = New System.Drawing.Point(12, 139)
        Me.grpGame3.Name = "grpGame3"
        Me.grpGame3.Size = New System.Drawing.Size(172, 50)
        Me.grpGame3.TabIndex = 2
        Me.grpGame3.TabStop = False
        Me.grpGame3.Text = "Game 3"
        Me.grpGame3.Visible = False
        '
        'btnGame3
        '
        Me.btnGame3.Location = New System.Drawing.Point(6, 21)
        Me.btnGame3.Name = "btnGame3"
        Me.btnGame3.Size = New System.Drawing.Size(160, 23)
        Me.btnGame3.TabIndex = 2
        Me.btnGame3.Text = "Launch"
        Me.btnGame3.UseVisualStyleBackColor = True
        '
        'grpGame2
        '
        Me.grpGame2.Controls.Add(Me.btnGame2)
        Me.grpGame2.Location = New System.Drawing.Point(12, 83)
        Me.grpGame2.Name = "grpGame2"
        Me.grpGame2.Size = New System.Drawing.Size(172, 50)
        Me.grpGame2.TabIndex = 1
        Me.grpGame2.TabStop = False
        Me.grpGame2.Text = "Game 2"
        Me.grpGame2.Visible = False
        '
        'btnGame2
        '
        Me.btnGame2.Location = New System.Drawing.Point(6, 21)
        Me.btnGame2.Name = "btnGame2"
        Me.btnGame2.Size = New System.Drawing.Size(160, 23)
        Me.btnGame2.TabIndex = 1
        Me.btnGame2.Text = "Launch"
        Me.btnGame2.UseVisualStyleBackColor = True
        '
        'grpGame1
        '
        Me.grpGame1.Controls.Add(Me.btnGame1)
        Me.grpGame1.Location = New System.Drawing.Point(12, 27)
        Me.grpGame1.Name = "grpGame1"
        Me.grpGame1.Size = New System.Drawing.Size(172, 50)
        Me.grpGame1.TabIndex = 0
        Me.grpGame1.TabStop = False
        Me.grpGame1.Text = "Game 1"
        Me.grpGame1.Visible = False
        '
        'btnGame1
        '
        Me.btnGame1.Location = New System.Drawing.Point(6, 21)
        Me.btnGame1.Name = "btnGame1"
        Me.btnGame1.Size = New System.Drawing.Size(160, 23)
        Me.btnGame1.TabIndex = 0
        Me.btnGame1.Text = "Launch"
        Me.btnGame1.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuTools, Me.mnuHelp})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(599, 24)
        Me.MenuStrip1.TabIndex = 21
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOpen, Me.ToolStripSeparator1, Me.mnuFileExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(37, 20)
        Me.mnuFile.Text = "File"
        '
        'mnuOpen
        '
        Me.mnuOpen.Name = "mnuOpen"
        Me.mnuOpen.Size = New System.Drawing.Size(152, 22)
        Me.mnuOpen.Text = "&Open"
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Name = "mnuFileExit"
        Me.mnuFileExit.Size = New System.Drawing.Size(152, 22)
        Me.mnuFileExit.Text = "E&xit"
        '
        'mnuTools
        '
        Me.mnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuToolsReload, Me.ToolStripMenuItem1, Me.mnuToolsPreferences})
        Me.mnuTools.Name = "mnuTools"
        Me.mnuTools.Size = New System.Drawing.Size(48, 20)
        Me.mnuTools.Text = "Tools"
        '
        'mnuToolsReload
        '
        Me.mnuToolsReload.Name = "mnuToolsReload"
        Me.mnuToolsReload.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.mnuToolsReload.Size = New System.Drawing.Size(190, 22)
        Me.mnuToolsReload.Text = "&Reload Config"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(187, 6)
        '
        'mnuToolsPreferences
        '
        Me.mnuToolsPreferences.Name = "mnuToolsPreferences"
        Me.mnuToolsPreferences.Size = New System.Drawing.Size(190, 22)
        Me.mnuToolsPreferences.Text = "&Preferences"
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelpAbout})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(44, 20)
        Me.mnuHelp.Text = "Help"
        '
        'mnuHelpAbout
        '
        Me.mnuHelpAbout.Name = "mnuHelpAbout"
        Me.mnuHelpAbout.Size = New System.Drawing.Size(107, 22)
        Me.mnuHelpAbout.Text = "&About"
        '
        'cboDatabase
        '
        Me.cboDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDatabase.FormattingEnabled = True
        Me.cboDatabase.Location = New System.Drawing.Point(12, 479)
        Me.cboDatabase.Name = "cboDatabase"
        Me.cboDatabase.Size = New System.Drawing.Size(172, 21)
        Me.cboDatabase.TabIndex = 23
        Me.ToolTip1.SetToolTip(Me.cboDatabase, "Switch to load a new database")
        '
        'lblFailLoad
        '
        Me.lblFailLoad.AutoSize = True
        Me.lblFailLoad.Location = New System.Drawing.Point(258, 171)
        Me.lblFailLoad.Name = "lblFailLoad"
        Me.lblFailLoad.Size = New System.Drawing.Size(219, 130)
        Me.lblFailLoad.TabIndex = 24
        Me.lblFailLoad.Text = resources.GetString("lblFailLoad.Text")
        Me.lblFailLoad.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 507)
        Me.Controls.Add(Me.cboDatabase)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.grpGame1)
        Me.Controls.Add(Me.lblFailLoad)
        Me.Controls.Add(Me.grpGame7)
        Me.Controls.Add(Me.grpGame6)
        Me.Controls.Add(Me.grpGame5)
        Me.Controls.Add(Me.grpGame4)
        Me.Controls.Add(Me.grpGame3)
        Me.Controls.Add(Me.grpGame2)
        Me.Controls.Add(Me.picGame)
        Me.Controls.Add(Me.chkCloseWindow)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnViewManual)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "frmMain"
        CType(Me.picGame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpGame7.ResumeLayout(False)
        Me.grpGame6.ResumeLayout(False)
        Me.grpGame5.ResumeLayout(False)
        Me.grpGame4.ResumeLayout(False)
        Me.grpGame3.ResumeLayout(False)
        Me.grpGame2.ResumeLayout(False)
        Me.grpGame1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkCloseWindow As System.Windows.Forms.CheckBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnViewManual As System.Windows.Forms.Button
    Friend WithEvents picGame As System.Windows.Forms.PictureBox
    Friend WithEvents grpGame7 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGame7 As System.Windows.Forms.Button
    Friend WithEvents grpGame6 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGame6 As System.Windows.Forms.Button
    Friend WithEvents grpGame5 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGame5 As System.Windows.Forms.Button
    Friend WithEvents grpGame4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGame4 As System.Windows.Forms.Button
    Friend WithEvents grpGame3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGame3 As System.Windows.Forms.Button
    Friend WithEvents grpGame2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGame2 As System.Windows.Forms.Button
    Friend WithEvents grpGame1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGame1 As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelpAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboDatabase As System.Windows.Forms.ComboBox
    Friend WithEvents mnuToolsPreferences As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblFailLoad As System.Windows.Forms.Label
    Friend WithEvents mnuToolsReload As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator

End Class
