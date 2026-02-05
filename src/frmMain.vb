'Sierra Classics Launcher
'Author: d4rkwyng
'Created: 2 June 2007
'Edited: 18 June 2009
'Edited: 27 July 2009

Imports System.IO

Public Class frmMain
    Private Sub btnGame1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGame1.Click
        LaunchProcess(0)
    End Sub

    Private Sub btnGame2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGame2.Click
        LaunchProcess(1)
    End Sub

    Private Sub btnGame3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGame3.Click
        LaunchProcess(2)
    End Sub

    Private Sub btnGame4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGame4.Click
        LaunchProcess(3)
    End Sub

    Private Sub btnGame5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGame5.Click
        LaunchProcess(4)
    End Sub

    Private Sub btnGame6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGame6.Click
        LaunchProcess(5)
    End Sub

    Private Sub btnGame7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGame7.Click
        LaunchProcess(6)
    End Sub

    Private Sub btnViewManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewManual.Click
        LaunchProcess(-1)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim CommandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs
        Dim strXMLArg As String = ""
        If CommandLineArgs.Count > 1 Then
            For i As Integer = 0 To CommandLineArgs.Count - 1
                Select Case CommandLineArgs(i)
                    Case "-xml"
                        If InStr(CommandLineArgs(i + 1), ".xml") Then
                            strXMLArg = CommandLineArgs(i + 1)
                        End If
                End Select
            Next
        End If
        LoadConfig()
        If XMLDBPath = "" Then XMLDBPath = Application.StartupPath & "\XML\"
        LoadDatabase(strXMLArg)
    End Sub

    Private Sub frmAnyForm_Closing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.Closing
        'MessageBox.Show(cboDatabase.Text, "Test")
        If blLastDBonExit = True Then
            frmPreferences.txtAutoLoadCustom.Text = Me.cboDatabase.Text
            frmPreferences.ReadConfig()
            frmPreferences.SaveConfig()
        End If
    End Sub

    Public Sub LoadDatabase(ByVal XMLArg As String)
        Try
            Dim rand As New Random
            If Not XMLArg = "" Then
                blHideDB = True
                LoadXMLData(XMLDBPath & XMLArg)
                SetInformation()
                Exit Sub
            End If

            If LoadFiles(XMLDBPath) = True Then
                Select Case LCase(strStartupDatabase)
                    Case "first"
                        LoadXMLData(XMLDBPath & cboDatabase.Items.Item(0).ToString)
                        cboDatabase.SelectedIndex = 0
                    Case "last"
                        LoadXMLData(XMLDBPath & cboDatabase.Items.Item(cboDatabase.Items.Count - 1).ToString)
                        cboDatabase.SelectedIndex = cboDatabase.Items.Count - 1
                    Case "random"
                        Dim intIndex As Integer
                        intIndex = rand.Next(cboDatabase.Items.Count)
                        LoadXMLData(XMLDBPath & cboDatabase.Items.Item(intIndex).ToString)
                        cboDatabase.SelectedIndex = intIndex
                    Case Else
                        If InStr(strStartupDatabase, ".xml") Then
                            If File.Exists(XMLDBPath & strStartupDatabase) Then
                                LoadXMLData(XMLDBPath & strStartupDatabase)
                                cboDatabase.SelectedIndex = cboDatabase.FindString(strStartupDatabase)
                            Else
                                MessageBox.Show(strStartupDatabase & " was not found in " & XMLDBPath, "File Not Found")
                                LoadXMLData(XMLDBPath & cboDatabase.Items.Item(0).ToString)
                                cboDatabase.SelectedIndex = 0
                            End If
                        Else
                            LoadXMLData(XMLDBPath & cboDatabase.Items.Item(0).ToString)
                            cboDatabase.SelectedIndex = 0
                        End If
                End Select

                SetInformation()
            Else
                MessageBox.Show("No XML files were found. (" & XMLDBPath & ")", "No Data Information")

                Dim ApplicationTitle As String
                If My.Application.Info.Title <> "" Then
                    ApplicationTitle = My.Application.Info.Title
                Else
                    ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
                End If
                Me.Text = ApplicationTitle
                btnViewManual.Enabled = False
                lblFailLoad.Visible = True

                Me.picGame.ImageLocation = ""
                grpGame1.Visible = False
                grpGame2.Visible = False
                grpGame3.Visible = False
                grpGame4.Visible = False
                grpGame5.Visible = False
                grpGame6.Visible = False
                grpGame7.Visible = False
                cboDatabase.Items.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Loading Database")
        End Try
    End Sub

    Public Function LoadFiles(ByVal strPath As String) As Boolean
        Try
            Dim i As Integer
            Dim DirInfo As New IO.DirectoryInfo(strPath)
            Dim dirFiles As IO.FileInfo() = DirInfo.GetFiles()
            Dim File As IO.FileInfo
            cboDatabase.Items.Clear()

            For Each File In dirFiles
                'strFile(i) = File.ToString
                If InStr(File.ToString, ".xml") Then
                    cboDatabase.Items.Add(File)
                End If

                i += 1
            Next

            If i > 0 Then
                Return True
            Else
                Return False
            End If

            DirInfo = Nothing
            dirFiles = Nothing
            File = Nothing
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub SetInformation()
        Try
            grpGame1.Visible = False
            grpGame2.Visible = False
            grpGame3.Visible = False
            grpGame4.Visible = False
            grpGame5.Visible = False
            grpGame6.Visible = False
            grpGame7.Visible = False

            If intGameCount >= 0 Then
                grpGame1.Text = GameInfo(0).strGameName
                grpGame1.Visible = True
            End If
            If intGameCount > 1 Then
                grpGame2.Text = GameInfo(1).strGameName
                grpGame2.Visible = True
            End If
            If intGameCount > 2 Then
                grpGame3.Text = GameInfo(2).strGameName
                grpGame3.Visible = True
            End If
            If intGameCount > 3 Then
                grpGame4.Text = GameInfo(3).strGameName
                grpGame4.Visible = True
            End If
            If intGameCount > 4 Then
                grpGame5.Text = GameInfo(4).strGameName
                grpGame5.Visible = True
            End If
            If intGameCount > 5 Then
                grpGame6.Text = GameInfo(5).strGameName
                grpGame6.Visible = True
            End If
            If intGameCount > 6 Then
                grpGame7.Text = GameInfo(6).strGameName
                grpGame7.Visible = True
            End If

            If strManual = "" Then
                btnViewManual.Enabled = False
            Else
                btnViewManual.Enabled = True
            End If

            If lblFailLoad.Visible = True Then
                lblFailLoad.Visible = False
            End If

            Dim ApplicationTitle As String
            If My.Application.Info.Title <> "" Then
                ApplicationTitle = My.Application.Info.Title
            Else
                ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
            End If


            Dim titlewindow As String
            titlewindow = strTitleWindow
            If Not titlewindow = "" Then
                If InStr(LCase(titlewindow), "%app") Then
                    titlewindow = Replace(titlewindow, "%APP", ApplicationTitle)
                End If

                If InStr(LCase(titlewindow), "%ver") Then
                    titlewindow = Replace(titlewindow, "%VER", My.Application.Info.Version.ToString)
                End If

                If InStr(LCase(titlewindow), "%game") Then
                    titlewindow = Replace(titlewindow, "%GAME", strGame)
                End If
            Else
                titlewindow = String.Format("{0} - {1}", ApplicationTitle, strGame)
            End If

            Me.Text = titlewindow
            Me.picGame.ImageLocation = strGameArt
            titlewindow = Nothing

            If blHideDB = True Then
                cboDatabase.Visible = False
            Else
                cboDatabase.Visible = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message & "Error loading content data.  Check your XML files.", "Error")
        End Try
    End Sub

    Private Sub mnuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
        Me.Close()
    End Sub

    Private Sub mnuHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHelpAbout.Click
        frmAbout.Show()
    End Sub

    Private Sub cboDatabase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDatabase.SelectedIndexChanged
        LoadXMLData(XMLDBPath & cboDatabase.Text)
        SetInformation()
    End Sub

    Private Sub mnuToolsPreferences_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsPreferences.Click
        frmPreferences.Show()
    End Sub

    Private Sub mnuToolsReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolsReload.Click
        LoadConfig()
        LoadDatabase("")
    End Sub

    Private Sub btnGame1MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGame1.MouseHover
        ButtonMouseOver(0)
    End Sub

    Private Sub btnGame2MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGame2.MouseHover
        ButtonMouseOver(1)
    End Sub

    Private Sub btnGame3MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGame3.MouseHover
        ButtonMouseOver(2)
    End Sub

    Private Sub btnGame4MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGame4.MouseHover
        ButtonMouseOver(3)
    End Sub

    Private Sub btnGame5MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGame5.MouseHover
        ButtonMouseOver(4)
    End Sub

    Private Sub btnGame6MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGame6.MouseHover
        ButtonMouseOver(5)
    End Sub

    Private Sub btnGame7MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGame7.MouseHover
        ButtonMouseOver(6)
    End Sub

    Private Sub btnGame1MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGame1.MouseLeave
        ButtonMouseLeave()
    End Sub

    Private Sub btnGame2MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGame2.MouseLeave
        ButtonMouseLeave()
    End Sub

    Private Sub btnGame3MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGame3.MouseLeave
        ButtonMouseLeave()
    End Sub

    Private Sub btnGame4MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGame4.MouseLeave
        ButtonMouseLeave()
    End Sub

    Private Sub btnGame5MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGame5.MouseLeave
        ButtonMouseLeave()
    End Sub

    Private Sub btnGame6MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGame6.MouseLeave
        ButtonMouseLeave()
    End Sub

    Private Sub btnGame7MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGame7.MouseLeave
        ButtonMouseLeave()
    End Sub

    Private Sub ButtonMouseOver(ByVal GameID As Integer)
        If blShowGameArt And Not GameInfo(GameID).strGameArt = "" Then
            Me.picGame.ImageLocation = Nothing
            Me.picGame.ImageLocation = GameInfo(GameID).strGameArt
        End If
    End Sub

    Private Sub ButtonMouseLeave()
        If blShowGameArt And Not strGameArt = "" Then
            Me.picGame.ImageLocation = Nothing
            Me.picGame.ImageLocation = strGameArt
        End If
    End Sub

    Private Sub mnuOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpen.Click
        Dim OpenDatabase As New OpenFileDialog
        If OpenDatabase.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            LoadXMLData(OpenDatabase.FileName)
            SetInformation()
        End If
    End Sub
End Class
