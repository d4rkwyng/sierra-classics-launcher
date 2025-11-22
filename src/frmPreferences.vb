Imports System.Xml
Imports System.IO

Public Class frmPreferences
    Private GInfo() As GameInfoStructure

    Private intNum As Integer
    Private intGCount As Integer

    Private blCloseOnSave As Boolean
    Private blIntialized As Boolean = False

    Private Sub frmPreferences_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not frmMain.lblFailLoad.Visible Then Initialize()
        ReadConfig()
    End Sub

    Private Sub Initialize()
        Try
            Dim i As Integer
            If frmMain.cboDatabase.Items.Count = 0 Then
                cboDB.Items.Clear()
                cboDB.Text = ""
                lblDatabase.Text = "Database: "
                txtName.Clear()
                txtNumButtons.Clear()
                txtDefaultPath.Clear()
                txtManual.Clear()
                txtArt.Clear()

                intGCount = 1
                intNum = 0
                ReDim GInfo(intGCount)

                ' initialize variables (precaution)
                Dim x As Integer
                For x = 0 To intGCount - 1
                    With GInfo(x)
                        .strGameName = ""
                        .strGameProg = ""
                        .strGamePath = ""
                        .strGameExe = ""
                        .strGameCmd = ""
                        .strGameArt = ""
                    End With
                Next x
                x = Nothing

                LoadGameInfo()
                Return
            End If
            For i = 0 To frmMain.cboDatabase.Items.Count - 1
                cboDB.Items.Add(frmMain.cboDatabase.Items.Item(i).ToString)
            Next i
            i = Nothing

            cboDB.SelectedIndex = cboDB.FindString(frmMain.cboDatabase.Text)

            ReadXMLData(XMLDBPath & frmMain.cboDatabase.Text)

            lblDatabase.Text = "Database: " & frmMain.cboDatabase.Text
            intNum = 0

            SetGameArt(txtArt.Text, 0)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error (Intialize)")
        End Try
    End Sub

    Private Sub LoadGameInfo()
        Try
            lblGameEntry.Text = "Game " & (intNum + 1) & ": "
            With GInfo(intNum)
                txtGameName.Text = .strGameName
                cboGameProg.Text = .strGameProg
                txtGamePath.Text = .strGamePath
                txtGameExe.Text = .strGameExe
                txtGameCmd.Text = .strGameCmd
                txtGameArt.Text = .strGameArt
                SetGameArt(.strGameArt, 1)
            End With
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error (LoadGameInfo)")
        End Try
    End Sub

    Private Sub SaveGameInfo()
        Try
            If Not blIntialized Then Return
            With GInfo(intNum)
                .strGameName = txtGameName.Text
                .strGameProg = cboGameProg.Text
                .strGamePath = txtGamePath.Text
                .strGameExe = txtGameExe.Text
                .strGameCmd = txtGameCmd.Text
                .strGameArt = txtGameArt.Text
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error (SaveGameInfo)")
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnGameNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGameNext.Click
        If Not intNum >= (intGCount - 1) Then
            SaveGameInfo()
            intNum += 1
            LoadGameInfo()
        End If
    End Sub

    Private Sub btnGameBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGameBack.Click
        If Not intNum <= 0 Then
            SaveGameInfo()
            intNum -= 1
            LoadGameInfo()
        End If
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        If Not cboDB.Text = "" Then
            ReadXMLData(XMLDBPath & cboDB.Text)
            intNum = 0
            lblDatabase.Text = "Database: " & cboDB.Text
            SetGameArt(txtArt.Text, 0)
            LoadGameInfo()
        End If
    End Sub

    Private Sub ReadXMLData(ByVal strXMLFile As String)
        Try
            Dim Input As New XmlTextReader(strXMLFile)
            Input.WhitespaceHandling = WhitespaceHandling.None
            If File.Exists(strXMLFile) Then
                Do While Input.Read()
                    If Input.NodeType = XmlNodeType.Element Then
                        Select Case Input.Name
                            Case "Name"
                                txtName.Text = Input.ReadString()
                            Case "NumButtons"
                                intGCount = Input.ReadString()
                                txtNumButtons.Text = intGCount
                                ReDim GInfo(intGCount)

                                blIntialized = True

                                ' initialize variables (precaution)
                                Dim x As Integer
                                For x = 0 To intGCount - 1
                                    With GInfo(x)
                                        .strGameName = ""
                                        .strGameProg = ""
                                        .strGameProg = ""
                                        .strGameExe = ""
                                        .strGameCmd = ""
                                        .strGameArt = ""
                                    End With
                                Next x
                            Case "DefaultPath"
                                txtDefaultPath.Text = Input.ReadString
                            Case "GameManual"
                                txtManual.Text = Input.ReadString
                            Case "GameArt"
                                txtArt.Text = Input.ReadString

                                '
                                ' Possible Loop to Shorten Code
                                '

                            Case "Game1Name"
                                GInfo(0).strGameName = Input.ReadString()
                            Case "Game1Prog"
                                GInfo(0).strGameProg = Input.ReadString()
                            Case "Game1Path"
                                GInfo(0).strGamePath = Input.ReadString()
                            Case "Game1Exe"
                                GInfo(0).strGameExe = Input.ReadString()
                            Case "Game1Cmd"
                                GInfo(0).strGameCmd = Input.ReadString()
                            Case "Game1Art"
                                GInfo(0).strGameArt = Input.ReadString()

                            Case "Game2Name"
                                GInfo(1).strGameName = Input.ReadString()
                            Case "Game2Prog"
                                GInfo(1).strGameProg = Input.ReadString()
                            Case "Game2Path"
                                GInfo(1).strGamePath = Input.ReadString()
                            Case "Game2Exe"
                                GInfo(1).strGameExe = Input.ReadString()
                            Case "Game2Cmd"
                                GInfo(1).strGameCmd = Input.ReadString()
                            Case "Game2Art"
                                GInfo(1).strGameArt = Input.ReadString()

                            Case "Game3Name"
                                GInfo(2).strGameName = Input.ReadString()
                            Case "Game3Prog"
                                GInfo(2).strGameProg = Input.ReadString()
                            Case "Game3Path"
                                GInfo(2).strGamePath = Input.ReadString()
                            Case "Game3Exe"
                                GInfo(2).strGameExe = Input.ReadString()
                            Case "Game3Cmd"
                                GInfo(2).strGameCmd = Input.ReadString()
                            Case "Game3Art"
                                GInfo(2).strGameArt = Input.ReadString()

                            Case "Game4Name"
                                GInfo(3).strGameName = Input.ReadString()
                            Case "Game4Prog"
                                GInfo(3).strGameProg = Input.ReadString()
                            Case "Game4Path"
                                GInfo(3).strGamePath = Input.ReadString()
                            Case "Game4Exe"
                                GInfo(3).strGameExe = Input.ReadString()
                            Case "Game4Cmd"
                                GInfo(3).strGameCmd = Input.ReadString()
                            Case "Game4Art"
                                GInfo(3).strGameArt = Input.ReadString()

                            Case "Game5Name"
                                GInfo(4).strGameName = Input.ReadString()
                            Case "Game5Prog"
                                GInfo(4).strGameProg = Input.ReadString()
                            Case "Game5Path"
                                GInfo(4).strGamePath = Input.ReadString()
                            Case "Game5Exe"
                                GInfo(4).strGameExe = Input.ReadString()
                            Case "Game5Cmd"
                                GInfo(4).strGameCmd = Input.ReadString()
                            Case "Game5Art"
                                GInfo(4).strGameArt = Input.ReadString()

                            Case "Game6Name"
                                GInfo(5).strGameName = Input.ReadString()
                            Case "Game6Prog"
                                GInfo(5).strGameProg = Input.ReadString()
                            Case "Game6Path"
                                GInfo(5).strGamePath = Input.ReadString()
                            Case "Game6Exe"
                                GInfo(5).strGameExe = Input.ReadString()
                            Case "Game6Cmd"
                                GInfo(5).strGameCmd = Input.ReadString()
                            Case "Game6Art"
                                GInfo(5).strGameArt = Input.ReadString()

                            Case "Game7Name"
                                GInfo(6).strGameName = Input.ReadString()
                            Case "Game7Prog"
                                GInfo(6).strGameProg = Input.ReadString()
                            Case "Game7Path"
                                GInfo(6).strGamePath = Input.ReadString()
                            Case "Game7Exe"
                                GInfo(6).strGameExe = Input.ReadString()
                            Case "Game7Cmd"
                                GInfo(6).strGameCmd = Input.ReadString()
                            Case "Game7Art"
                                GInfo(6).strGameArt = Input.ReadString()
                        End Select
                    End If
                Loop
                Input.Close()
                Input = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Loading XML Database")
        End Try
    End Sub

    Public Sub SaveConfig()
        Try
            Dim strXMLFile As String
            strXMLFile = My.Computer.FileSystem.CurrentDirectory & "\config.xml"
            ' Write XML Data 
            Dim Doc As New XmlDocument
            Doc.PreserveWhitespace = True

            'Create a 'vanilla' XML Declaration (processing instruction)
            Dim myXmlDeclaration As XmlDeclaration
            myXmlDeclaration = _
                Doc.CreateXmlDeclaration("1.0", Nothing, Nothing)
            Doc.AppendChild(myXmlDeclaration)

            '
            ' Need to specify the use of whitespace in file creation
            '

            Dim Root As XmlElement
            Root = Doc.CreateElement("Configuration")

            ' Startup Database
            Dim Child As XmlElement
            Child = Doc.CreateElement("StartupDatabase")
            If (LCase(cboAutoLoadDB.Text) = "custom") Then
                Child.InnerText = txtAutoLoadCustom.Text
            Else
                Child.InnerText = cboAutoLoadDB.Text
            End If
            Root.AppendChild(Child)

            ' DOSBox Path
            ' C:\Program Files (x86)\DOSBox-0.73\
            '
            Child = Doc.CreateElement("DOSBoxPath")
            If txtDOSBox.Text = "" Then
                Child.InnerText = "C:\Program Files\DOSBox-0.73\"
            Else
                Child.InnerText = txtDOSBox.Text
            End If
            Root.AppendChild(Child)

            ' ScummVM Path
            ' C:\Program Files (x86)\ScummVM\
            '
            Child = Doc.CreateElement("ScummVMPath")
            If txtDOSBox.Text = "" Then
                Child.InnerText = "C:\Program Files\ScummVm\"
            Else
                Child.InnerText = txtScummVM.Text
            End If
            Root.AppendChild(Child)

            ' Title Window
            Child = Doc.CreateElement("TitleWindow")
            Child.InnerText = txtTitleWindow.Text
            Root.AppendChild(Child)

            ' XML Database Path for Game XML files
            Child = Doc.CreateElement("XMLDBPath")
            Dim tmpXMLDBPath As String
            tmpXMLDBPath = txtXMLDatabase.Text
            If tmpXMLDBPath = "" Then tmpXMLDBPath = Application.StartupPath & "\XML\"
            If Not Mid(tmpXMLDBPath, tmpXMLDBPath.Length) = "\" Then tmpXMLDBPath &= "\" ' checks to see if there is a trailing \ slash
            Child.InnerText = tmpXMLDBPath
            txtXMLDatabase.Text = tmpXMLDBPath
            Root.AppendChild(Child)

            ' Game Art Path
            Dim tmpGameArtPath As String
            tmpGameArtPath = txtGameArtPath.Text
            If tmpGameArtPath = "" Then tmpGameArtPath = Application.StartupPath & "\GameArt"
            If Not Mid(tmpGameArtPath, tmpGameArtPath.Length) = "\" Then tmpGameArtPath &= "\" ' removes trailing \ slash
            Child = Doc.CreateElement("GameArtPath")
            Child.InnerText = tmpGameArtPath
            Root.AppendChild(Child)

            ' Close On Saving Preferences
            Child = Doc.CreateElement("CloseOnSave")
            Child.InnerText = chkCloseOnSave.Checked
            Root.AppendChild(Child)

            ' Hide the Database list on Main form
            Child = Doc.CreateElement("HideDB")
            Child.InnerText = chkHideDB.Checked
            If chkHideDB.Checked = True Then
                blHideDB = True
                frmMain.cboDatabase.Visible = False
            Else
                blHideDB = False
                frmMain.cboDatabase.Visible = True
            End If
            Root.AppendChild(Child)

            ' Remember last database on Close
            Child = Doc.CreateElement("LastDBonExit")
            Child.InnerText = chkLastDBonExit.Checked
            Root.AppendChild(Child)

            ' Show Game Art on Mouse Rollover
            Child = Doc.CreateElement("ShowGameArt")
            Child.InnerText = chkGameArt.Checked
            Root.AppendChild(Child)
            If chkGameArt.Checked = True Then
                blShowGameArt = True
            Else
                blShowGameArt = False
            End If
            blCloseOnSave = chkCloseOnSave.Checked

            Doc.AppendChild(Root)

            'Write XML to a file
            Dim Output As New XmlTextWriter(strXMLFile, System.Text.Encoding.UTF8)
            Doc.WriteTo(Output)
            Output.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Configuration Save Error")
        End Try
    End Sub

    Public Sub ReadConfig()
        Try
            Dim strXMLFile As String = "config.xml"
            Dim Doc As New XmlDocument
            Dim Input As New XmlTextReader(strXMLFile)
            Input.WhitespaceHandling = WhitespaceHandling.None
            If File.Exists(strXMLFile) Then
                Do While Input.Read()
                    If Input.NodeType = XmlNodeType.Element Then
                        Select Case Input.Name

                            Case "StartupDatabase"
                                Dim tmpKey As String
                                tmpKey = Input.ReadString()
                                If InStr(tmpKey, ".xml") Then
                                    cboAutoLoadDB.Text = "Custom"
                                    txtAutoLoadCustom.Text = tmpKey
                                Else
                                    cboAutoLoadDB.Text = tmpKey
                                End If
                                tmpKey = Nothing
                            Case "DOSBoxPath" : txtDOSBox.Text = Input.ReadString()
                            Case "ScummVMPath" : txtScummVM.Text = Input.ReadString
                            Case "TitleWindow" : txtTitleWindow.Text = Input.ReadString
                            Case "XMLDBPath" : txtXMLDatabase.Text = Input.ReadString
                            Case "GameArtPath" : txtGameArtPath.Text = Input.ReadString
                            Case "CloseOnSave" : chkCloseOnSave.Checked = Input.ReadString
                            Case "HideDB" : chkHideDB.Checked = Input.ReadString
                            Case "LastDBonExit" : chkLastDBonExit.Checked = Input.ReadString
                            Case "ShowGameArt" : chkGameArt.Checked = Input.ReadString
                        End Select
                    End If
                Loop
                Input.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Loading XML Database")
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim strTempLoc As String, intTempNum As Integer

            intTempNum = intNum

            SaveConfig()
            SaveGameInfo()
            strTempLoc = cboDB.Text

            If Not cboDB.Text = "" Then
                SaveXMLData(XMLDBPath, strTempLoc)
            End If

            If frmMain.LoadFiles(XMLDBPath) = True Then
                cboDB.Items.Clear()
                frmMain.cboDatabase.SelectedIndex = frmMain.cboDatabase.FindString(strTempLoc)
                LoadXMLData(XMLDBPath & strTempLoc)
                Initialize()
            End If

            strTempLoc = Nothing

            SetGameArt(txtArt.Text, 0)
            If blCloseOnSave = True Then Me.Hide()

            intNum = intTempNum
            LoadGameInfo()

            LoadConfig()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub
    Private Sub cboAutoLoadDB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAutoLoadDB.SelectedIndexChanged
        If LCase(cboAutoLoadDB.Text) = "custom" Then
            txtAutoLoadCustom.Visible = True
        Else
            txtAutoLoadCustom.Visible = False
        End If
    End Sub

    Private Sub SaveXMLData(ByVal strXMLPath As String, ByVal strXMLFile As String)
        Try
            If Not File.Exists(strXMLPath) Then
                My.Computer.FileSystem.CreateDirectory(strXMLPath)
            End If

            strXMLFile = strXMLPath & strXMLFile
            ' Write XML Data 

            Dim Doc As New XmlDocument
            Doc.PreserveWhitespace = True

            'Create a 'vanilla' XML Declaration (processing instruction)
            Dim myXmlDeclaration As XmlDeclaration
            myXmlDeclaration = _
                Doc.CreateXmlDeclaration("1.0", Nothing, Nothing)
            Doc.AppendChild(myXmlDeclaration)

            '
            ' Need to specify the use of whitespace in file creation
            '
            Dim Root As XmlElement
            Root = Doc.CreateElement(Mid(cboDB.Text, 1, cboDB.Text.Length - 4))

            ' Collection Name
            Dim Child As XmlElement
            Child = Doc.CreateElement("Name")
            Child.InnerText = txtName.Text
            Root.AppendChild(Child)

            ' Num Buttons
            Child = Doc.CreateElement("NumButtons")
            Child.InnerText = txtNumButtons.Text
            Root.AppendChild(Child)

            ' Default Path
            Child = Doc.CreateElement("DefaultPath")
            Child.InnerText = txtDefaultPath.Text
            Root.AppendChild(Child)

            ' Game Manual
            Child = Doc.CreateElement("GameManual")
            Child.InnerText = txtManual.Text
            Root.AppendChild(Child)

            ' Game Art
            Child = Doc.CreateElement("GameArt")
            Child.InnerText = txtArt.Text
            Root.AppendChild(Child)

            ' Loop for writing game content
            Dim i As Integer
            Dim tmpNum As Integer
            tmpNum = intNum
            intNum = 0
            For i = 1 To intGCount
                LoadGameInfo()

                Child = Doc.CreateElement("Game" & i & "Name")
                Child.InnerText = txtGameName.Text
                Root.AppendChild(Child)

                Child = Doc.CreateElement("Game" & i & "Prog")
                Child.InnerText = cboGameProg.Text
                Root.AppendChild(Child)

                Child = Doc.CreateElement("Game" & i & "Path")
                Child.InnerText = txtGamePath.Text
                Root.AppendChild(Child)

                Child = Doc.CreateElement("Game" & i & "Exe")
                Child.InnerText = txtGameExe.Text
                Root.AppendChild(Child)

                Child = Doc.CreateElement("Game" & i & "Cmd")
                Child.InnerText = txtGameCmd.Text
                Root.AppendChild(Child)

                Child = Doc.CreateElement("Game" & i & "Art")
                Child.InnerText = txtGameArt.Text
                Root.AppendChild(Child)

                intNum += 1
            Next i

            intNum = tmpNum
            i = Nothing
            tmpNum = Nothing

            LoadGameInfo()

            Doc.AppendChild(Root)

            'Write XML to a file
            Dim Output As New XmlTextWriter(strXMLFile, System.Text.Encoding.UTF8)
            Doc.WriteTo(Output)
            Output.Close()
            Root = Nothing
            Child = Nothing
            Doc = Nothing
            myXmlDeclaration = Nothing
            Output = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Save XML Database Error")
        End Try
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Try
            Dim strNewName As String
            strNewName = InputBox("Enter new database name: ", "New")

            If Not strNewName = "" Then
                If strNewName.Length <= 4 Then
                    If MessageBox.Show("No XML file extension defined, Auto correct?", "Incorrect Database Name", MessageBoxButtons.YesNo, _
                        MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        strNewName &= ".xml"
                    End If
                ElseIf Not LCase(Mid(strNewName, strNewName.Length - 3)) = ".xml" Then
                    If MessageBox.Show("No XML file extension defined, Auto correct?", "Incorrect Database Name", MessageBoxButtons.YesNo, _
                        MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        strNewName &= ".xml"
                    Else
                        Return
                    End If
                End If

                If Not cboDB.FindString(strNewName) = -1 Then
                    MessageBox.Show("There is a file already with that name.", "Error")
                    Return
                End If

                lblDatabase.Text = "Database: " & strNewName
                cboDB.Items.Add(strNewName)
                cboDB.SelectedIndex = cboDB.FindString(strNewName)

                txtName.Clear()
                txtNumButtons.Clear()
                txtDefaultPath.Clear()
                txtManual.Clear()
                txtArt.Clear()

                intGCount = 1
                intNum = 0
                ReDim GInfo(intGCount)

                ' initialize variables (precaution)
                Dim x As Integer
                For x = 0 To intGCount - 1
                    With GInfo(x)
                        .strGameName = ""
                        .strGameProg = ""
                        .strGamePath = ""
                        .strGameExe = ""
                        .strGameCmd = ""
                        .strGameArt = ""
                    End With
                Next x
                x = Nothing

                SetGameArt(txtArt.Text, 0)
                txtName.Text = Mid(strNewName, 1, strNewName.Length - 4)
                txtNumButtons.Text = 1

                strNewName = Nothing

                LoadGameInfo()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "New Database Error")
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Are you sure you want to delete?", "Delete Database", MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                = Windows.Forms.DialogResult.Yes Then
                Dim strFiletoDEL As String
                Dim strTempLoc As String

                strTempLoc = frmMain.cboDatabase.Text

                If cboDB.SelectedIndex = -1 Then Return
                If cboDB.Items.Item(cboDB.SelectedIndex).ToString = "" Then Return
                strFiletoDEL = cboDB.Items.Item(cboDB.SelectedIndex).ToString

                If System.IO.File.Exists(XMLDBPath & strFiletoDEL) = True Then
                    System.IO.File.Delete(XMLDBPath & strFiletoDEL)
                    MessageBox.Show(XMLDBPath & strFiletoDEL & " has been deleted", "File Deleted")

                    If frmMain.LoadFiles(XMLDBPath) = True Then
                        frmMain.cboDatabase.SelectedIndex = frmMain.cboDatabase.FindString(strTempLoc)
                    End If
                End If

                cboDB.Items.Remove(strFiletoDEL)

                If strTempLoc = strFiletoDEL Then
                    frmMain.cboDatabase.SelectedIndex = 0
                    cboDB.SelectedIndex = frmMain.cboDatabase.SelectedIndex
                Else
                    cboDB.SelectedIndex = 0
                End If

                strFiletoDEL = Nothing
                strTempLoc = Nothing

                If Not cboDB.Text = "" Then
                    ReadXMLData(XMLDBPath & cboDB.Text)
                End If
                intNum = 0
                lblDatabase.Text = "Database: " & cboDB.Text
                SetGameArt(txtArt.Text, 0)
                LoadGameInfo()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Delete Error")
        End Try
    End Sub

    Private Sub txtNumButtons_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumButtons.TextChanged
        If (txtNumButtons.Text = "") Then
            Return
        End If

        If Not IsNumeric(txtNumButtons.Text) Then
            MessageBox.Show("Must be a numeric value.")
            txtNumButtons.Text = ""
            Return
        End If

        If (CInt(txtNumButtons.Text) <= 0) Then
            MessageBox.Show("Must be a number greater than 0.")
            txtNumButtons.Text = 1
            Return
        End If

        If (CInt(txtNumButtons.Text) > 7) Then
            MessageBox.Show("Must be a number less than or equal to 7.")
            txtNumButtons.Text = 7
            Return
        End If

        If txtNumButtons.Text = "" Then
            intGCount = 0
        Else
            If CInt(txtNumButtons.Text) <> intGCount Then
                Dim GInfoTemp(intGCount) As GameInfoStructure
                Dim intGCountTemp As Integer

                ' Save old data
                SaveGameInfo()
                GInfoTemp = GInfo

                intGCountTemp = intGCount

                ' process new data
                intGCount = CInt(txtNumButtons.Text)

                If intNum > intGCount Then
                    intNum = 0
                End If

                If intGCount > intGCountTemp Then
                    ReDim Preserve GInfo(intGCount)
                Else
                    GInfo = GInfoTemp
                End If

                intGCountTemp = Nothing
                GInfoTemp = Nothing


                LoadGameInfo()
            End If
        End If
    End Sub

    Private Sub cboDB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDB.SelectedIndexChanged
        If Not cboDB.Text = "" Then
            ReadXMLData(XMLDBPath & cboDB.Text)
        End If
        intNum = 0
        lblDatabase.Text = "Database: " & cboDB.Text
        SetGameArt(txtArt.Text, 0)
        LoadGameInfo()
    End Sub

    Private Sub SetGameArt(ByVal Source As String, ByVal Destination As String)
        If InStr(LCase(Source), "%path") Then
            Source = Replace(Source, "%PATH", txtDefaultPath.Text)
        End If

        If InStr(LCase(Source), "%curdir") Then
            Source = Replace(Source, "%CURDIR", Application.StartupPath)
        End If

        If InStr(LCase(Source), "%gameart") Then
            Source = Replace(Source, "%GAMEART", strGameArtPath)
        End If

        Select Case Destination
            Case 0
                picGameArt.ImageLocation = Nothing
                picGameArt.ImageLocation = Source
            Case 1
                picGameArt2.ImageLocation = Nothing
                picGameArt2.ImageLocation = Source
        End Select

        Source = Nothing
    End Sub

    Private Sub chkLastDBonExit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLastDBonExit.CheckedChanged
        If chkLastDBonExit.Checked = True Then
            strLastDBonExitTemp = Me.txtAutoLoadCustom.Text
            Me.cboAutoLoadDB.Enabled = False
            Me.txtAutoLoadCustom.Enabled = False
            Me.cboAutoLoadDB.Text = "Custom"
            Me.txtAutoLoadCustom.Text = frmMain.cboDatabase.Text
        Else
            Me.cboAutoLoadDB.Enabled = True
            Me.txtAutoLoadCustom.Enabled = True
            Me.cboAutoLoadDB.Text = "Custom"
            Me.txtAutoLoadCustom.Text = strLastDBonExitTemp
        End If
    End Sub
End Class