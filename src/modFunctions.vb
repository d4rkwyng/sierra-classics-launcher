Imports Microsoft.Win32
Imports System.Xml
Imports System.IO

Module modFunctions
    Public Sub LoadXMLData(ByVal strXMLFile As String)
        Try
            Dim Input As New XmlTextReader(strXMLFile)
            Input.WhitespaceHandling = WhitespaceHandling.None
            If File.Exists(strXMLFile) Then
                Do While Input.Read()
                    If Input.NodeType = XmlNodeType.Element Then
                        Select Case Input.Name
                            Case "Name"
                                strGame = Input.ReadString()
                            Case "NumButtons"
                                intGameCount = Input.ReadString()

                                ReDim GameInfo(intGameCount)

                                ' initialize variables (precaution)
                                Dim x As Integer
                                For x = 0 To intGameCount
                                    GameInfo(x).strGameExe = ""
                                    GameInfo(x).strGameProg = ""
                                    GameInfo(x).strGamePath = ""
                                    GameInfo(x).strGameExe = ""
                                    GameInfo(x).strGameCmd = ""
                                Next x
                            Case "DefaultPath"
                                strDefaultPath = Input.ReadString
                            Case "GameManual"
                                strManual = Input.ReadString()
                            Case "GameArt"
                                strGameArt = Input.ReadString()

                                '
                                ' Possible Loop to Shorten Code
                                '


                            Case "Game1Name"
                                GameInfo(0).strGameName = Input.ReadString()
                            Case "Game1Prog"
                                GameInfo(0).strGameProg = Input.ReadString()
                            Case "Game1Path"
                                GameInfo(0).strGamePath = Input.ReadString()
                            Case "Game1Exe"
                                GameInfo(0).strGameExe = Input.ReadString()
                            Case "Game1Cmd"
                                GameInfo(0).strGameCmd = Input.ReadString()
                            Case "Game1Art"
                                GameInfo(0).strGameArt = Input.ReadString()

                            Case "Game2Name"
                                GameInfo(1).strGameName = Input.ReadString()
                            Case "Game2Prog"
                                GameInfo(1).strGameProg = Input.ReadString()
                            Case "Game2Path"
                                GameInfo(1).strGamePath = Input.ReadString()
                            Case "Game2Exe"
                                GameInfo(1).strGameExe = Input.ReadString()
                            Case "Game2Cmd"
                                GameInfo(1).strGameCmd = Input.ReadString()
                            Case "Game2Art"
                                GameInfo(1).strGameArt = Input.ReadString()

                            Case "Game3Name"
                                GameInfo(2).strGameName = Input.ReadString()
                            Case "Game3Prog"
                                GameInfo(2).strGameProg = Input.ReadString()
                            Case "Game3Path"
                                GameInfo(2).strGamePath = Input.ReadString()
                            Case "Game3Exe"
                                GameInfo(2).strGameExe = Input.ReadString()
                            Case "Game3Cmd"
                                GameInfo(2).strGameCmd = Input.ReadString()
                            Case "Game3Art"
                                GameInfo(2).strGameArt = Input.ReadString()

                            Case "Game4Name"
                                GameInfo(3).strGameName = Input.ReadString()
                            Case "Game4Prog"
                                GameInfo(3).strGameProg = Input.ReadString()
                            Case "Game4Path"
                                GameInfo(3).strGamePath = Input.ReadString()
                            Case "Game4Exe"
                                GameInfo(3).strGameExe = Input.ReadString()
                            Case "Game4Cmd"
                                GameInfo(3).strGameCmd = Input.ReadString()
                            Case "Game4Art"
                                GameInfo(3).strGameArt = Input.ReadString()

                            Case "Game5Name"
                                GameInfo(4).strGameName = Input.ReadString()
                            Case "Game5Prog"
                                GameInfo(4).strGameProg = Input.ReadString()
                            Case "Game5Path"
                                GameInfo(4).strGamePath = Input.ReadString()
                            Case "Game5Exe"
                                GameInfo(4).strGameExe = Input.ReadString()
                            Case "Game5Cmd"
                                GameInfo(4).strGameCmd = Input.ReadString()
                            Case "Game5Art"
                                GameInfo(4).strGameArt = Input.ReadString()

                            Case "Game6Name"
                                GameInfo(5).strGameName = Input.ReadString()
                            Case "Game6Prog"
                                GameInfo(5).strGameProg = Input.ReadString()
                            Case "Game6Path"
                                GameInfo(5).strGamePath = Input.ReadString()
                            Case "Game6Exe"
                                GameInfo(5).strGameExe = Input.ReadString()
                            Case "Game6Cmd"
                                GameInfo(5).strGameCmd = Input.ReadString()
                            Case "Game6Art"
                                GameInfo(5).strGameArt = Input.ReadString()

                            Case "Game7Name"
                                GameInfo(6).strGameName = Input.ReadString()
                            Case "Game7Prog"
                                GameInfo(6).strGameProg = Input.ReadString()
                            Case "Game7Path"
                                GameInfo(6).strGamePath = Input.ReadString()
                            Case "Game7Exe"
                                GameInfo(6).strGameExe = Input.ReadString()
                            Case "Game7Cmd"
                                GameInfo(6).strGameCmd = Input.ReadString()
                            Case "Game7Art"
                                GameInfo(6).strGameArt = Input.ReadString()
                        End Select
                    End If
                Loop
            End If

            Input.Close()
            Input = Nothing

            If InStr(LCase(strManual), "%path") Then
                strManual = Replace(strManual, "%PATH", strDefaultPath)
            End If
            If InStr(LCase(strManual), "%curdir") Then
                strManual = Replace(strManual, "%CURDIR", Application.StartupPath)
            End If
            If InStr(LCase(strManual), "%gameart") Then
                strManual = Replace(strManual, "%GAMEART", strGameArtPath)
            End If

            If InStr(LCase(strGameArt), "%path") Then
                strGameArt = Replace(strGameArt, "%PATH", strDefaultPath)
            End If
            If InStr(LCase(strGameArt), "%curdir") Then
                strGameArt = Replace(strGameArt, "%CURDIR", Application.StartupPath)
            End If
            If InStr(LCase(strGameArt), "%gameart") Then
                strGameArt = Replace(strGameArt, "%GAMEART", strGameArtPath)
            End If

            Dim i As Integer
            For i = 0 To intGameCount
                With GameInfo(i)
                    If InStr(LCase(.strGamePath), "%path") Then
                        .strGamePath = Replace(.strGamePath, "%PATH", strDefaultPath)
                    End If
                    If InStr(LCase(.strGamePath), "%curdir") Then
                        .strGamePath = Replace(.strGamePath, "%CURDIR", Application.StartupPath)
                    End If
                    If InStr(LCase(.strGamePath), "%gameart") Then
                        .strGamePath = Replace(.strGamePath, "%GAMEART", strGameArtPath)
                    End If

                    If InStr(LCase(.strGameCmd), "%path") Then
                        .strGameCmd = Replace(.strGameCmd, "%PATH", strDefaultPath)
                    End If
                    If InStr(LCase(.strGameCmd), "%curdir") Then
                        .strGameCmd = Replace(.strGameCmd, "%CURDIR", Application.StartupPath)
                    End If
                    If InStr(LCase(.strGameCmd), "%gameart") Then
                        .strGameCmd = Replace(.strGameCmd, "%GAMEART", strGameArtPath)
                    End If

                    If InStr(LCase(.strGameArt), "%path") Then
                        .strGameArt = Replace(.strGameArt, "%PATH", strDefaultPath)
                    End If
                    If InStr(LCase(.strGameArt), "%curdir") Then
                        .strGameArt = Replace(.strGameArt, "%CURDIR", Application.StartupPath)
                    End If
                    If InStr(LCase(.strGameArt), "%gameart") Then
                        .strGameArt = Replace(.strGameArt, "%GAMEART", strGameArtPath)
                    End If
                End With
            Next i
            i = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub

    Public Sub LoadConfig()
        Try
            Dim strXMLFile As String = "config.xml"
            Dim Input As New XmlTextReader(strXMLFile)
            Input.WhitespaceHandling = WhitespaceHandling.None
            If Not File.Exists(strXMLFile) Then
                frmPreferences.SaveConfig()
            End If
            strXMLFile = Nothing

            Do While Input.Read()
                If Input.NodeType = XmlNodeType.Element Then
                    Select Case Input.Name
                        Case "StartupDatabase" : strStartupDatabase = Input.ReadString()
                        Case "DOSBoxPath"
                            strDOSBoxPath = Input.ReadString()
                            If InStr(LCase(strDOSBoxPath), "%curdir") Then
                                strDOSBoxPath = Replace(strDOSBoxPath, "%CURDIR", Application.StartupPath)
                            End If
                        Case "ScummVMPath"
                            strScummVMPath = Input.ReadString
                            If InStr(LCase(strScummVMPath), "%curdir") Then
                                strScummVMPath = Replace(strScummVMPath, "%CURDIR", Application.StartupPath)
                            End If
                        Case "TitleWindow" : strTitleWindow = Input.ReadString()
                        Case "XMLDBPath"
                            XMLDBPath = Input.ReadString()
                            If InStr(LCase(XMLDBPath), "%curdir") Then
                                XMLDBPath = Replace(XMLDBPath, "%CURDIR", Application.StartupPath)
                            End If
                        Case "GameArtPath"
                            strGameArtPath = Input.ReadString()
                            If InStr(LCase(strGameArtPath), "%curdir") Then
                                strGameArtPath = Replace(strGameArtPath, "%CURDIR", Application.StartupPath)
                            End If
                        Case "CloseOnSave" : blCloseOnSave = Input.ReadString()
                        Case "LastDBonExit" : blLastDBonExit = Input.ReadString()
                        Case "HideDB" : blHideDB = Input.ReadString()
                        Case "ShowGameArt" : blShowGameArt = Input.ReadString()
                    End Select
                End If
            Loop

            Input.Close()
            Input = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub

    Public Sub LaunchProcess(ByVal intIndex As Integer)
        Dim strLaunch As String = ""
        Try
            If intIndex = -1 Then 'Check to see if it's launching the Manual
                Diagnostics.Process.Start(strManual)
                Return
            End If

            If intIndex < 0 > 7 Then Return ' Make sure index is within range of buttons

            Dim strPath As String, strProg As String, strExe As String, strCmd As String
            strPath = GameInfo(intIndex).strGamePath
            strProg = GameInfo(intIndex).strGameProg
            strExe = GameInfo(intIndex).strGameExe
            strCmd = GameInfo(intIndex).strGameCmd

            If InStr(strPath, ".lnk") Then 'Check to see if it's a shortcut
                Diagnostics.Process.Start(strPath)
            Else

                If Not strPath = "" Then
                    If Mid(strPath, strPath.Length) = "\" Then ' checks to see if there is a trailing \ slash
                        strPath = Mid(strPath, 1, strPath.Length - 1)
                    Else
                        strPath &= "\"
                    End If
                End If


                Dim strFileName As String
                Dim strArguments As String

                Dim strQuote As String = Chr(34)

                strFileName = strProg
                strArguments = ""

                SCLProcess = New Process

                Select Case strProg ' Available programs
                    Case "dosbox"
                        strFileName = strDOSBoxPath
                        If Not Mid(strFileName, strFileName.Length) = "\" Then : strFileName &= "\" : End If
                        strFileName &= "dosbox.exe"
                        If Not strPath.Length < 1 Then : strPath = "-c " & strQuote & "mount C '" & strPath & "'" & strQuote & " -c " & strQuote & "C:" & strQuote : End If
                        If Not strExe.Length < 1 Then : strExe = " -c " & strQuote & strExe & strQuote : End If
                        strArguments = strPath & strExe & strCmd
                    Case "scummvm"
                        strFileName = strScummVMPath
                        If Not Mid(strFileName, strFileName.Length) = "\" Then : strFileName &= "\" : End If
                        strFileName &= "scummvm.exe"
                        If InStr(strCmd, "-p") Then
                            strPath = ""
                            strExe = ""
                            strArguments = strCmd
                        Else
                            strArguments = "-p " & strPath & " " & strExe & strCmd
                        End If
                    Case ""
                        strFileName = strPath & strExe
                        strArguments = strCmd
                    Case Else
                        strArguments = strPath & strExe & strCmd
                End Select

                With SCLProcess.StartInfo
                    .FileName = strFileName
                    .Arguments = strArguments
                    .WorkingDirectory = strPath
                    .UseShellExecute = True
                End With

                SCLProcess.Start()

                strPath = Nothing
                strProg = Nothing
                strExe = Nothing
                strCmd = Nothing
                strQuote = Nothing
                strLaunch = Nothing
            End If

            ' Check if closing after launch
            CheckToClose()
        Catch ex As Exception
            MessageBox.Show("File Not Found" & ControlChars.NewLine & strLaunch, "Launch Error")
            strLaunch = Nothing
        End Try
    End Sub

    Private Sub CheckToClose()
        If frmMain.chkCloseWindow.Checked = True Then
            frmMain.Close()
        End If
    End Sub

End Module
