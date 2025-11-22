Module modDeclares
    Public strFile() As String
    Public strGame As String
    Public strGameArt As String
    Public strManual As String
    Public intGameCount As Integer

    Public strDefaultPath As String
    Public XMLDBPath As String
    Public strScummVMPath As String
    Public strDOSBoxPath As String
    Public strStartupDatabase As String
    Public strGameArtPath As String
    Public strTitleWindow As String

    Public strLastDBonExitTemp As String
    Public blLastDBonExit As Boolean
    Public blHideDB As Boolean
    Public blShowGameArt As Boolean
    Public blCloseOnSave As Boolean

    Public WithEvents SCLProcess As Process

    Public Structure GameInfoStructure
        Public strGameName As String
        Public strGameProg As String
        Public strGamePath As String
        Public strGameExe As String
        Public strGameCmd As String
        Public strGameArt As String
    End Structure

    Public GameInfo() As GameInfoStructure
End Module
