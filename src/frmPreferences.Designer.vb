<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPreferences
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreferences))
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.tabMain = New System.Windows.Forms.TabPage()
        Me.grpProgramSettings = New System.Windows.Forms.GroupBox()
        Me.chkGameArt = New System.Windows.Forms.CheckBox()
        Me.txtScummVM = New System.Windows.Forms.TextBox()
        Me.lblScummVM = New System.Windows.Forms.Label()
        Me.txtDOSBox = New System.Windows.Forms.TextBox()
        Me.lblDOSBox = New System.Windows.Forms.Label()
        Me.grpStartupSettings = New System.Windows.Forms.GroupBox()
        Me.chkLastDBonExit = New System.Windows.Forms.CheckBox()
        Me.txtGameArtPath = New System.Windows.Forms.TextBox()
        Me.lblGameArtPath = New System.Windows.Forms.Label()
        Me.chkHideDB = New System.Windows.Forms.CheckBox()
        Me.txtXMLDatabase = New System.Windows.Forms.TextBox()
        Me.lblXMLDatabase = New System.Windows.Forms.Label()
        Me.chkCloseOnSave = New System.Windows.Forms.CheckBox()
        Me.txtTitleWindow = New System.Windows.Forms.TextBox()
        Me.lblTitleWindow = New System.Windows.Forms.Label()
        Me.lblAutoLoadDB = New System.Windows.Forms.Label()
        Me.txtAutoLoadCustom = New System.Windows.Forms.TextBox()
        Me.cboAutoLoadDB = New System.Windows.Forms.ComboBox()
        Me.tabDB = New System.Windows.Forms.TabPage()
        Me.lblVariablesDB = New System.Windows.Forms.Label()
        Me.picGameArt2 = New System.Windows.Forms.PictureBox()
        Me.picGameArt = New System.Windows.Forms.PictureBox()
        Me.txtGameArt = New System.Windows.Forms.TextBox()
        Me.lblGameArt = New System.Windows.Forms.Label()
        Me.cboGameProg = New System.Windows.Forms.ComboBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.txtNumButtons = New System.Windows.Forms.TextBox()
        Me.lblNumButtons = New System.Windows.Forms.Label()
        Me.lblDatabase = New System.Windows.Forms.Label()
        Me.lblGameEntry = New System.Windows.Forms.Label()
        Me.btnGameBack = New System.Windows.Forms.Button()
        Me.btnGameNext = New System.Windows.Forms.Button()
        Me.txtGamePath = New System.Windows.Forms.TextBox()
        Me.lblGamePath = New System.Windows.Forms.Label()
        Me.txtGameCmd = New System.Windows.Forms.TextBox()
        Me.txtGameExe = New System.Windows.Forms.TextBox()
        Me.lblGameCmd = New System.Windows.Forms.Label()
        Me.lblGameExe = New System.Windows.Forms.Label()
        Me.txtGameName = New System.Windows.Forms.TextBox()
        Me.lblGameProg = New System.Windows.Forms.Label()
        Me.lblGameName = New System.Windows.Forms.Label()
        Me.txtArt = New System.Windows.Forms.TextBox()
        Me.txtManual = New System.Windows.Forms.TextBox()
        Me.lblArt = New System.Windows.Forms.Label()
        Me.lblManual = New System.Windows.Forms.Label()
        Me.txtDefaultPath = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblDefaultPath = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.cboDB = New System.Windows.Forms.ComboBox()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnSave = New System.Windows.Forms.Button()
        Me.tabControl.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.grpProgramSettings.SuspendLayout()
        Me.grpStartupSettings.SuspendLayout()
        Me.tabDB.SuspendLayout()
        CType(Me.picGameArt2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picGameArt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabControl
        '
        Me.tabControl.Controls.Add(Me.tabMain)
        Me.tabControl.Controls.Add(Me.tabDB)
        Me.tabControl.Location = New System.Drawing.Point(12, 12)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(684, 362)
        Me.tabControl.TabIndex = 0
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.grpProgramSettings)
        Me.tabMain.Controls.Add(Me.grpStartupSettings)
        Me.tabMain.Location = New System.Drawing.Point(4, 22)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMain.Size = New System.Drawing.Size(676, 336)
        Me.tabMain.TabIndex = 0
        Me.tabMain.Text = "Main"
        Me.tabMain.UseVisualStyleBackColor = True
        '
        'grpProgramSettings
        '
        Me.grpProgramSettings.Controls.Add(Me.chkGameArt)
        Me.grpProgramSettings.Controls.Add(Me.txtScummVM)
        Me.grpProgramSettings.Controls.Add(Me.lblScummVM)
        Me.grpProgramSettings.Controls.Add(Me.txtDOSBox)
        Me.grpProgramSettings.Controls.Add(Me.lblDOSBox)
        Me.grpProgramSettings.Location = New System.Drawing.Point(343, 7)
        Me.grpProgramSettings.Name = "grpProgramSettings"
        Me.grpProgramSettings.Size = New System.Drawing.Size(330, 323)
        Me.grpProgramSettings.TabIndex = 99
        Me.grpProgramSettings.TabStop = False
        Me.grpProgramSettings.Text = "Launcher Settings"
        '
        'chkGameArt
        '
        Me.chkGameArt.AutoSize = True
        Me.chkGameArt.Location = New System.Drawing.Point(9, 300)
        Me.chkGameArt.Name = "chkGameArt"
        Me.chkGameArt.Size = New System.Drawing.Size(151, 17)
        Me.chkGameArt.TabIndex = 9
        Me.chkGameArt.Text = "Show Game Art for Games"
        Me.ToolTip1.SetToolTip(Me.chkGameArt, "Show Game Art for each game on mouse over")
        Me.chkGameArt.UseVisualStyleBackColor = True
        '
        'txtScummVM
        '
        Me.txtScummVM.Location = New System.Drawing.Point(143, 44)
        Me.txtScummVM.MaxLength = 1000
        Me.txtScummVM.Name = "txtScummVM"
        Me.txtScummVM.Size = New System.Drawing.Size(175, 20)
        Me.txtScummVM.TabIndex = 8
        '
        'lblScummVM
        '
        Me.lblScummVM.AutoSize = True
        Me.lblScummVM.Location = New System.Drawing.Point(6, 47)
        Me.lblScummVM.Name = "lblScummVM"
        Me.lblScummVM.Size = New System.Drawing.Size(86, 13)
        Me.lblScummVM.TabIndex = 11
        Me.lblScummVM.Text = "ScummVM Path:"
        Me.ToolTip1.SetToolTip(Me.lblScummVM, "Path to ScummVM Directory" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Available Variables:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "%CURDIR - Replaces with the Star" & _
                "tup Directory for the Program")
        '
        'txtDOSBox
        '
        Me.txtDOSBox.Location = New System.Drawing.Point(143, 17)
        Me.txtDOSBox.MaxLength = 1000
        Me.txtDOSBox.Name = "txtDOSBox"
        Me.txtDOSBox.Size = New System.Drawing.Size(175, 20)
        Me.txtDOSBox.TabIndex = 7
        '
        'lblDOSBox
        '
        Me.lblDOSBox.AutoSize = True
        Me.lblDOSBox.Location = New System.Drawing.Point(6, 20)
        Me.lblDOSBox.Name = "lblDOSBox"
        Me.lblDOSBox.Size = New System.Drawing.Size(76, 13)
        Me.lblDOSBox.TabIndex = 0
        Me.lblDOSBox.Text = "DOSBox Path:"
        Me.ToolTip1.SetToolTip(Me.lblDOSBox, "Path to DOSBox Directory" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Available Variables:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "%CURDIR - Replaces with the Start" & _
                "up Directory for the Program")
        '
        'grpStartupSettings
        '
        Me.grpStartupSettings.Controls.Add(Me.chkLastDBonExit)
        Me.grpStartupSettings.Controls.Add(Me.txtGameArtPath)
        Me.grpStartupSettings.Controls.Add(Me.lblGameArtPath)
        Me.grpStartupSettings.Controls.Add(Me.chkHideDB)
        Me.grpStartupSettings.Controls.Add(Me.txtXMLDatabase)
        Me.grpStartupSettings.Controls.Add(Me.lblXMLDatabase)
        Me.grpStartupSettings.Controls.Add(Me.chkCloseOnSave)
        Me.grpStartupSettings.Controls.Add(Me.txtTitleWindow)
        Me.grpStartupSettings.Controls.Add(Me.lblTitleWindow)
        Me.grpStartupSettings.Controls.Add(Me.lblAutoLoadDB)
        Me.grpStartupSettings.Controls.Add(Me.txtAutoLoadCustom)
        Me.grpStartupSettings.Controls.Add(Me.cboAutoLoadDB)
        Me.grpStartupSettings.Location = New System.Drawing.Point(7, 7)
        Me.grpStartupSettings.Name = "grpStartupSettings"
        Me.grpStartupSettings.Size = New System.Drawing.Size(330, 323)
        Me.grpStartupSettings.TabIndex = 98
        Me.grpStartupSettings.TabStop = False
        Me.grpStartupSettings.Text = "Application Settings"
        '
        'chkLastDBonExit
        '
        Me.chkLastDBonExit.AutoSize = True
        Me.chkLastDBonExit.Location = New System.Drawing.Point(135, 70)
        Me.chkLastDBonExit.Name = "chkLastDBonExit"
        Me.chkLastDBonExit.Size = New System.Drawing.Size(189, 17)
        Me.chkLastDBonExit.TabIndex = 11
        Me.chkLastDBonExit.Text = "Remember last Database on Close"
        Me.ToolTip1.SetToolTip(Me.chkLastDBonExit, "Hide the Database drop down box")
        Me.chkLastDBonExit.UseVisualStyleBackColor = True
        '
        'txtGameArtPath
        '
        Me.txtGameArtPath.Location = New System.Drawing.Point(149, 161)
        Me.txtGameArtPath.Name = "txtGameArtPath"
        Me.txtGameArtPath.Size = New System.Drawing.Size(175, 20)
        Me.txtGameArtPath.TabIndex = 4
        '
        'lblGameArtPath
        '
        Me.lblGameArtPath.AutoSize = True
        Me.lblGameArtPath.Location = New System.Drawing.Point(6, 164)
        Me.lblGameArtPath.Name = "lblGameArtPath"
        Me.lblGameArtPath.Size = New System.Drawing.Size(79, 13)
        Me.lblGameArtPath.TabIndex = 10
        Me.lblGameArtPath.Text = "Game Art Path:"
        Me.ToolTip1.SetToolTip(Me.lblGameArtPath, "Specify the directory for Game Art" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Available Variables:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "%CURDIR - Replaces with" & _
                " the Startup Directory for the Program")
        '
        'chkHideDB
        '
        Me.chkHideDB.AutoSize = True
        Me.chkHideDB.Location = New System.Drawing.Point(9, 277)
        Me.chkHideDB.Name = "chkHideDB"
        Me.chkHideDB.Size = New System.Drawing.Size(134, 17)
        Me.chkHideDB.TabIndex = 5
        Me.chkHideDB.Text = "Hide the Database List"
        Me.ToolTip1.SetToolTip(Me.chkHideDB, "Hide the Database drop down box")
        Me.chkHideDB.UseVisualStyleBackColor = True
        '
        'txtXMLDatabase
        '
        Me.txtXMLDatabase.Location = New System.Drawing.Point(149, 135)
        Me.txtXMLDatabase.Name = "txtXMLDatabase"
        Me.txtXMLDatabase.Size = New System.Drawing.Size(175, 20)
        Me.txtXMLDatabase.TabIndex = 3
        '
        'lblXMLDatabase
        '
        Me.lblXMLDatabase.AutoSize = True
        Me.lblXMLDatabase.Location = New System.Drawing.Point(6, 138)
        Me.lblXMLDatabase.Name = "lblXMLDatabase"
        Me.lblXMLDatabase.Size = New System.Drawing.Size(106, 13)
        Me.lblXMLDatabase.TabIndex = 7
        Me.lblXMLDatabase.Text = "XML Database Path:"
        Me.ToolTip1.SetToolTip(Me.lblXMLDatabase, "Specify the directory for XML databases" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Available Variables:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "%CURDIR - Replaces" & _
                " with the Startup Directory for the Program")
        '
        'chkCloseOnSave
        '
        Me.chkCloseOnSave.AutoSize = True
        Me.chkCloseOnSave.Location = New System.Drawing.Point(9, 300)
        Me.chkCloseOnSave.Name = "chkCloseOnSave"
        Me.chkCloseOnSave.Size = New System.Drawing.Size(155, 17)
        Me.chkCloseOnSave.TabIndex = 6
        Me.chkCloseOnSave.Text = "Close Preferences on Save"
        Me.ToolTip1.SetToolTip(Me.chkCloseOnSave, "Close the Preferences window when clicking the Save button")
        Me.chkCloseOnSave.UseVisualStyleBackColor = True
        '
        'txtTitleWindow
        '
        Me.txtTitleWindow.Location = New System.Drawing.Point(149, 109)
        Me.txtTitleWindow.Name = "txtTitleWindow"
        Me.txtTitleWindow.Size = New System.Drawing.Size(175, 20)
        Me.txtTitleWindow.TabIndex = 2
        Me.txtTitleWindow.Text = "%APP - %GAME"
        '
        'lblTitleWindow
        '
        Me.lblTitleWindow.AutoSize = True
        Me.lblTitleWindow.Location = New System.Drawing.Point(6, 112)
        Me.lblTitleWindow.Name = "lblTitleWindow"
        Me.lblTitleWindow.Size = New System.Drawing.Size(72, 13)
        Me.lblTitleWindow.TabIndex = 3
        Me.lblTitleWindow.Text = "Title Window:"
        Me.ToolTip1.SetToolTip(Me.lblTitleWindow, "Customize the Application Title Window" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Available Variables:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "%APP - Application " & _
                "Title" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "%VER - Application Version" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "%GAME - Game Title")
        '
        'lblAutoLoadDB
        '
        Me.lblAutoLoadDB.AutoSize = True
        Me.lblAutoLoadDB.Location = New System.Drawing.Point(6, 20)
        Me.lblAutoLoadDB.Name = "lblAutoLoadDB"
        Me.lblAutoLoadDB.Size = New System.Drawing.Size(120, 13)
        Me.lblAutoLoadDB.TabIndex = 0
        Me.lblAutoLoadDB.Text = "Load Database on Start"
        Me.ToolTip1.SetToolTip(Me.lblAutoLoadDB, "Automatically launch a specific database on startup")
        '
        'txtAutoLoadCustom
        '
        Me.txtAutoLoadCustom.Location = New System.Drawing.Point(149, 44)
        Me.txtAutoLoadCustom.MaxLength = 255
        Me.txtAutoLoadCustom.Name = "txtAutoLoadCustom"
        Me.txtAutoLoadCustom.Size = New System.Drawing.Size(175, 20)
        Me.txtAutoLoadCustom.TabIndex = 1
        Me.txtAutoLoadCustom.Visible = False
        '
        'cboAutoLoadDB
        '
        Me.cboAutoLoadDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAutoLoadDB.FormattingEnabled = True
        Me.cboAutoLoadDB.Items.AddRange(New Object() {"First", "Last", "Random", "Custom"})
        Me.cboAutoLoadDB.Location = New System.Drawing.Point(211, 17)
        Me.cboAutoLoadDB.Name = "cboAutoLoadDB"
        Me.cboAutoLoadDB.Size = New System.Drawing.Size(113, 21)
        Me.cboAutoLoadDB.TabIndex = 0
        '
        'tabDB
        '
        Me.tabDB.Controls.Add(Me.lblVariablesDB)
        Me.tabDB.Controls.Add(Me.picGameArt2)
        Me.tabDB.Controls.Add(Me.picGameArt)
        Me.tabDB.Controls.Add(Me.txtGameArt)
        Me.tabDB.Controls.Add(Me.lblGameArt)
        Me.tabDB.Controls.Add(Me.cboGameProg)
        Me.tabDB.Controls.Add(Me.btnDelete)
        Me.tabDB.Controls.Add(Me.txtNumButtons)
        Me.tabDB.Controls.Add(Me.lblNumButtons)
        Me.tabDB.Controls.Add(Me.lblDatabase)
        Me.tabDB.Controls.Add(Me.lblGameEntry)
        Me.tabDB.Controls.Add(Me.btnGameBack)
        Me.tabDB.Controls.Add(Me.btnGameNext)
        Me.tabDB.Controls.Add(Me.txtGamePath)
        Me.tabDB.Controls.Add(Me.lblGamePath)
        Me.tabDB.Controls.Add(Me.txtGameCmd)
        Me.tabDB.Controls.Add(Me.txtGameExe)
        Me.tabDB.Controls.Add(Me.lblGameCmd)
        Me.tabDB.Controls.Add(Me.lblGameExe)
        Me.tabDB.Controls.Add(Me.txtGameName)
        Me.tabDB.Controls.Add(Me.lblGameProg)
        Me.tabDB.Controls.Add(Me.lblGameName)
        Me.tabDB.Controls.Add(Me.txtArt)
        Me.tabDB.Controls.Add(Me.txtManual)
        Me.tabDB.Controls.Add(Me.lblArt)
        Me.tabDB.Controls.Add(Me.lblManual)
        Me.tabDB.Controls.Add(Me.txtDefaultPath)
        Me.tabDB.Controls.Add(Me.txtName)
        Me.tabDB.Controls.Add(Me.lblDefaultPath)
        Me.tabDB.Controls.Add(Me.lblName)
        Me.tabDB.Controls.Add(Me.cboDB)
        Me.tabDB.Controls.Add(Me.btnOpen)
        Me.tabDB.Controls.Add(Me.btnNew)
        Me.tabDB.Location = New System.Drawing.Point(4, 22)
        Me.tabDB.Name = "tabDB"
        Me.tabDB.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDB.Size = New System.Drawing.Size(676, 336)
        Me.tabDB.TabIndex = 1
        Me.tabDB.Text = "Database"
        Me.tabDB.UseVisualStyleBackColor = True
        '
        'lblVariablesDB
        '
        Me.lblVariablesDB.AutoSize = True
        Me.lblVariablesDB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVariablesDB.Location = New System.Drawing.Point(563, 211)
        Me.lblVariablesDB.Name = "lblVariablesDB"
        Me.lblVariablesDB.Size = New System.Drawing.Size(98, 15)
        Me.lblVariablesDB.TabIndex = 34
        Me.lblVariablesDB.Text = "Available Variables"
        Me.ToolTip1.SetToolTip(Me.lblVariablesDB, "%PATH - Replaces with Default Path entry" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "%CURDIR - Replaces with the Startup Dir" & _
                "ectory for the Program" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "%GAMEART - Replaces with the Game Art Path entry")
        '
        'picGameArt2
        '
        Me.picGameArt2.Location = New System.Drawing.Point(566, 6)
        Me.picGameArt2.Name = "picGameArt2"
        Me.picGameArt2.Size = New System.Drawing.Size(100, 120)
        Me.picGameArt2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picGameArt2.TabIndex = 33
        Me.picGameArt2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picGameArt2, "Individual Game Art")
        '
        'picGameArt
        '
        Me.picGameArt.Location = New System.Drawing.Point(460, 6)
        Me.picGameArt.Name = "picGameArt"
        Me.picGameArt.Size = New System.Drawing.Size(100, 120)
        Me.picGameArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picGameArt.TabIndex = 32
        Me.picGameArt.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picGameArt, "Default Art")
        '
        'txtGameArt
        '
        Me.txtGameArt.Location = New System.Drawing.Point(416, 294)
        Me.txtGameArt.Name = "txtGameArt"
        Me.txtGameArt.Size = New System.Drawing.Size(250, 20)
        Me.txtGameArt.TabIndex = 16
        '
        'lblGameArt
        '
        Me.lblGameArt.AutoSize = True
        Me.lblGameArt.Location = New System.Drawing.Point(340, 297)
        Me.lblGameArt.Name = "lblGameArt"
        Me.lblGameArt.Size = New System.Drawing.Size(54, 13)
        Me.lblGameArt.TabIndex = 31
        Me.lblGameArt.Text = "Game Art:"
        Me.ToolTip1.SetToolTip(Me.lblGameArt, "Add game art for each game.")
        '
        'cboGameProg
        '
        Me.cboGameProg.FormattingEnabled = True
        Me.cboGameProg.Items.AddRange(New Object() {"dosbox", "scummvm"})
        Me.cboGameProg.Location = New System.Drawing.Point(75, 268)
        Me.cboGameProg.Name = "cboGameProg"
        Me.cboGameProg.Size = New System.Drawing.Size(250, 21)
        Me.cboGameProg.TabIndex = 12
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(188, 64)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "&Delete"
        Me.ToolTip1.SetToolTip(Me.btnDelete, "Delete the database")
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'txtNumButtons
        '
        Me.txtNumButtons.Location = New System.Drawing.Point(75, 145)
        Me.txtNumButtons.Name = "txtNumButtons"
        Me.txtNumButtons.Size = New System.Drawing.Size(250, 20)
        Me.txtNumButtons.TabIndex = 5
        '
        'lblNumButtons
        '
        Me.lblNumButtons.AutoSize = True
        Me.lblNumButtons.Location = New System.Drawing.Point(4, 148)
        Me.lblNumButtons.Name = "lblNumButtons"
        Me.lblNumButtons.Size = New System.Drawing.Size(46, 13)
        Me.lblNumButtons.TabIndex = 29
        Me.lblNumButtons.Text = "Buttons:"
        Me.ToolTip1.SetToolTip(Me.lblNumButtons, "Number of Game entries (Launch buttons)")
        '
        'lblDatabase
        '
        Me.lblDatabase.AutoSize = True
        Me.lblDatabase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDatabase.Location = New System.Drawing.Point(7, 98)
        Me.lblDatabase.Name = "lblDatabase"
        Me.lblDatabase.Size = New System.Drawing.Size(61, 15)
        Me.lblDatabase.TabIndex = 26
        Me.lblDatabase.Text = "Database: "
        '
        'lblGameEntry
        '
        Me.lblGameEntry.AutoSize = True
        Me.lblGameEntry.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblGameEntry.Location = New System.Drawing.Point(8, 209)
        Me.lblGameEntry.Name = "lblGameEntry"
        Me.lblGameEntry.Size = New System.Drawing.Size(47, 15)
        Me.lblGameEntry.TabIndex = 25
        Me.lblGameEntry.Text = "Game #"
        '
        'btnGameBack
        '
        Me.btnGameBack.Location = New System.Drawing.Point(75, 209)
        Me.btnGameBack.Name = "btnGameBack"
        Me.btnGameBack.Size = New System.Drawing.Size(22, 23)
        Me.btnGameBack.TabIndex = 9
        Me.btnGameBack.Text = "<"
        Me.ToolTip1.SetToolTip(Me.btnGameBack, "Previous Game")
        Me.btnGameBack.UseVisualStyleBackColor = True
        '
        'btnGameNext
        '
        Me.btnGameNext.Location = New System.Drawing.Point(104, 209)
        Me.btnGameNext.Name = "btnGameNext"
        Me.btnGameNext.Size = New System.Drawing.Size(22, 23)
        Me.btnGameNext.TabIndex = 10
        Me.btnGameNext.Text = ">"
        Me.ToolTip1.SetToolTip(Me.btnGameNext, "Next Game")
        Me.btnGameNext.UseVisualStyleBackColor = True
        '
        'txtGamePath
        '
        Me.txtGamePath.Location = New System.Drawing.Point(75, 294)
        Me.txtGamePath.Name = "txtGamePath"
        Me.txtGamePath.Size = New System.Drawing.Size(250, 20)
        Me.txtGamePath.TabIndex = 13
        '
        'lblGamePath
        '
        Me.lblGamePath.AutoSize = True
        Me.lblGamePath.Location = New System.Drawing.Point(4, 297)
        Me.lblGamePath.Name = "lblGamePath"
        Me.lblGamePath.Size = New System.Drawing.Size(63, 13)
        Me.lblGamePath.TabIndex = 19
        Me.lblGamePath.Text = "Game Path:"
        Me.ToolTip1.SetToolTip(Me.lblGamePath, "Path to game")
        '
        'txtGameCmd
        '
        Me.txtGameCmd.Location = New System.Drawing.Point(416, 268)
        Me.txtGameCmd.Name = "txtGameCmd"
        Me.txtGameCmd.Size = New System.Drawing.Size(250, 20)
        Me.txtGameCmd.TabIndex = 15
        '
        'txtGameExe
        '
        Me.txtGameExe.Location = New System.Drawing.Point(416, 242)
        Me.txtGameExe.Name = "txtGameExe"
        Me.txtGameExe.Size = New System.Drawing.Size(250, 20)
        Me.txtGameExe.TabIndex = 14
        '
        'lblGameCmd
        '
        Me.lblGameCmd.AutoSize = True
        Me.lblGameCmd.Location = New System.Drawing.Point(340, 271)
        Me.lblGameCmd.Name = "lblGameCmd"
        Me.lblGameCmd.Size = New System.Drawing.Size(60, 13)
        Me.lblGameCmd.TabIndex = 16
        Me.lblGameCmd.Text = "Arguments:"
        Me.ToolTip1.SetToolTip(Me.lblGameCmd, "Additional commands for the program." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Refer to the program's documentation.")
        '
        'lblGameExe
        '
        Me.lblGameExe.AutoSize = True
        Me.lblGameExe.Location = New System.Drawing.Point(340, 245)
        Me.lblGameExe.Name = "lblGameExe"
        Me.lblGameExe.Size = New System.Drawing.Size(63, 13)
        Me.lblGameExe.TabIndex = 15
        Me.lblGameExe.Text = "Executable:"
        Me.ToolTip1.SetToolTip(Me.lblGameExe, "Game executable")
        '
        'txtGameName
        '
        Me.txtGameName.Location = New System.Drawing.Point(75, 242)
        Me.txtGameName.Name = "txtGameName"
        Me.txtGameName.Size = New System.Drawing.Size(250, 20)
        Me.txtGameName.TabIndex = 11
        '
        'lblGameProg
        '
        Me.lblGameProg.AutoSize = True
        Me.lblGameProg.Location = New System.Drawing.Point(4, 271)
        Me.lblGameProg.Name = "lblGameProg"
        Me.lblGameProg.Size = New System.Drawing.Size(49, 13)
        Me.lblGameProg.TabIndex = 12
        Me.lblGameProg.Text = "Program:"
        Me.ToolTip1.SetToolTip(Me.lblGameProg, resources.GetString("lblGameProg.ToolTip"))
        '
        'lblGameName
        '
        Me.lblGameName.AutoSize = True
        Me.lblGameName.Location = New System.Drawing.Point(4, 245)
        Me.lblGameName.Name = "lblGameName"
        Me.lblGameName.Size = New System.Drawing.Size(38, 13)
        Me.lblGameName.TabIndex = 11
        Me.lblGameName.Text = "Name:"
        Me.ToolTip1.SetToolTip(Me.lblGameName, "Specified game name")
        '
        'txtArt
        '
        Me.txtArt.Location = New System.Drawing.Point(416, 171)
        Me.txtArt.Name = "txtArt"
        Me.txtArt.Size = New System.Drawing.Size(250, 20)
        Me.txtArt.TabIndex = 8
        '
        'txtManual
        '
        Me.txtManual.Location = New System.Drawing.Point(416, 145)
        Me.txtManual.Name = "txtManual"
        Me.txtManual.Size = New System.Drawing.Size(250, 20)
        Me.txtManual.TabIndex = 7
        '
        'lblArt
        '
        Me.lblArt.AutoSize = True
        Me.lblArt.Location = New System.Drawing.Point(340, 174)
        Me.lblArt.Name = "lblArt"
        Me.lblArt.Size = New System.Drawing.Size(23, 13)
        Me.lblArt.TabIndex = 8
        Me.lblArt.Text = "Art:"
        Me.ToolTip1.SetToolTip(Me.lblArt, "Path to Game artwork image" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(ex: C:\SCLauncher\GameArt\IMAGE.jpg)")
        '
        'lblManual
        '
        Me.lblManual.AutoSize = True
        Me.lblManual.Location = New System.Drawing.Point(340, 148)
        Me.lblManual.Name = "lblManual"
        Me.lblManual.Size = New System.Drawing.Size(45, 13)
        Me.lblManual.TabIndex = 7
        Me.lblManual.Text = "Manual:"
        Me.ToolTip1.SetToolTip(Me.lblManual, "Game manual")
        '
        'txtDefaultPath
        '
        Me.txtDefaultPath.Location = New System.Drawing.Point(75, 171)
        Me.txtDefaultPath.Name = "txtDefaultPath"
        Me.txtDefaultPath.Size = New System.Drawing.Size(250, 20)
        Me.txtDefaultPath.TabIndex = 6
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(75, 119)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(250, 20)
        Me.txtName.TabIndex = 4
        '
        'lblDefaultPath
        '
        Me.lblDefaultPath.AutoSize = True
        Me.lblDefaultPath.Location = New System.Drawing.Point(4, 174)
        Me.lblDefaultPath.Name = "lblDefaultPath"
        Me.lblDefaultPath.Size = New System.Drawing.Size(69, 13)
        Me.lblDefaultPath.TabIndex = 4
        Me.lblDefaultPath.Text = "Default Path:"
        Me.ToolTip1.SetToolTip(Me.lblDefaultPath, "Default path to game directory")
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(4, 122)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(38, 13)
        Me.lblName.TabIndex = 3
        Me.lblName.Text = "Name:"
        Me.ToolTip1.SetToolTip(Me.lblName, "Name of game series or collection" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        '
        'cboDB
        '
        Me.cboDB.FormattingEnabled = True
        Me.cboDB.Location = New System.Drawing.Point(7, 37)
        Me.cboDB.Name = "cboDB"
        Me.cboDB.Size = New System.Drawing.Size(175, 21)
        Me.cboDB.Sorted = True
        Me.cboDB.TabIndex = 1
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(188, 35)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 2
        Me.btnOpen.Text = "&Open"
        Me.ToolTip1.SetToolTip(Me.btnOpen, "Open the specified database")
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(7, 7)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "&New"
        Me.ToolTip1.SetToolTip(Me.btnNew, "Create a New Database")
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(540, 380)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 18
        Me.btnClose.Text = "&Cancel"
        Me.ToolTip1.SetToolTip(Me.btnClose, "Cancel and Close")
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(621, 380)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 17
        Me.btnSave.Text = "&Save"
        Me.ToolTip1.SetToolTip(Me.btnSave, "Save the settings")
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'frmPreferences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 408)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.tabControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmPreferences"
        Me.Text = "Preferences"
        Me.tabControl.ResumeLayout(False)
        Me.tabMain.ResumeLayout(False)
        Me.grpProgramSettings.ResumeLayout(False)
        Me.grpProgramSettings.PerformLayout()
        Me.grpStartupSettings.ResumeLayout(False)
        Me.grpStartupSettings.PerformLayout()
        Me.tabDB.ResumeLayout(False)
        Me.tabDB.PerformLayout()
        CType(Me.picGameArt2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picGameArt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabControl As System.Windows.Forms.TabControl
    Friend WithEvents tabMain As System.Windows.Forms.TabPage
    Friend WithEvents tabDB As System.Windows.Forms.TabPage
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnGameBack As System.Windows.Forms.Button
    Friend WithEvents btnGameNext As System.Windows.Forms.Button
    Friend WithEvents txtGamePath As System.Windows.Forms.TextBox
    Friend WithEvents lblGamePath As System.Windows.Forms.Label
    Friend WithEvents txtGameCmd As System.Windows.Forms.TextBox
    Friend WithEvents txtGameExe As System.Windows.Forms.TextBox
    Friend WithEvents lblGameCmd As System.Windows.Forms.Label
    Friend WithEvents lblGameExe As System.Windows.Forms.Label
    Friend WithEvents txtGameName As System.Windows.Forms.TextBox
    Friend WithEvents lblGameProg As System.Windows.Forms.Label
    Friend WithEvents lblGameName As System.Windows.Forms.Label
    Friend WithEvents txtArt As System.Windows.Forms.TextBox
    Friend WithEvents txtManual As System.Windows.Forms.TextBox
    Friend WithEvents lblArt As System.Windows.Forms.Label
    Friend WithEvents lblManual As System.Windows.Forms.Label
    Friend WithEvents txtDefaultPath As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblDefaultPath As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents cboDB As System.Windows.Forms.ComboBox
    Friend WithEvents lblDatabase As System.Windows.Forms.Label
    Friend WithEvents lblGameEntry As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtNumButtons As System.Windows.Forms.TextBox
    Friend WithEvents lblNumButtons As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cboAutoLoadDB As System.Windows.Forms.ComboBox
    Friend WithEvents txtAutoLoadCustom As System.Windows.Forms.TextBox
    Friend WithEvents lblAutoLoadDB As System.Windows.Forms.Label
    Friend WithEvents grpStartupSettings As System.Windows.Forms.GroupBox
    Friend WithEvents txtDOSBox As System.Windows.Forms.TextBox
    Friend WithEvents lblDOSBox As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtTitleWindow As System.Windows.Forms.TextBox
    Friend WithEvents lblTitleWindow As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents chkCloseOnSave As System.Windows.Forms.CheckBox
    Friend WithEvents txtXMLDatabase As System.Windows.Forms.TextBox
    Friend WithEvents lblXMLDatabase As System.Windows.Forms.Label
    Friend WithEvents txtScummVM As System.Windows.Forms.TextBox
    Friend WithEvents lblScummVM As System.Windows.Forms.Label
    Friend WithEvents cboGameProg As System.Windows.Forms.ComboBox
    Friend WithEvents grpProgramSettings As System.Windows.Forms.GroupBox
    Friend WithEvents chkHideDB As System.Windows.Forms.CheckBox
    Friend WithEvents txtGameArt As System.Windows.Forms.TextBox
    Friend WithEvents lblGameArt As System.Windows.Forms.Label
    Friend WithEvents chkGameArt As System.Windows.Forms.CheckBox
    Friend WithEvents picGameArt2 As System.Windows.Forms.PictureBox
    Friend WithEvents picGameArt As System.Windows.Forms.PictureBox
    Friend WithEvents txtGameArtPath As System.Windows.Forms.TextBox
    Friend WithEvents lblGameArtPath As System.Windows.Forms.Label
    Friend WithEvents lblVariablesDB As System.Windows.Forms.Label
    Friend WithEvents chkLastDBonExit As System.Windows.Forms.CheckBox
End Class
