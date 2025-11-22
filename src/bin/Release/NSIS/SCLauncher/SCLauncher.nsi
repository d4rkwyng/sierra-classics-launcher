; The name of the installer
Name "Sierra Classics Launcher"

; The file to write
OutFile "SCLauncher.exe"

; The default installation directory
InstallDir "$PROGRAMFILES\Vaguesoft\Sierra Classics Launcher"

; Registry key to check for directory (so if you install again, it will 
; overwrite the old one automatically)
InstallDirRegKey HKLM "Software\Vaguesoft\Sierra Classics Launcher" "Install_Dir"

;--------------------------------

; Pages

Page components
Page directory
Page instfiles

UninstPage uninstConfirm
UninstPage instfiles

;--------------------------------

; The stuff to install
Section "Sierra Classics Launcher (required)"

  SectionIn RO
  
  ; Set output path to the installation directory.
  SetOutPath $INSTDIR
  
  ; Put file there
  File "Sierra Classics Launcher.exe"
  File "HELP.txt"
  File "VERSION.txt"
  File /r "*.xml"
  File /r "*.png"
  
  
  ; Write the installation path into the registry
  WriteRegStr HKLM "SOFTWARE\Vaguesoft\Sierra Classics Launcher" "Install_Dir" "$INSTDIR"
  
  ; Write the uninstall keys for Windows
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Sierra Classics Launcher" "DisplayName" "Sierra Classics Launcher"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Sierra Classics Launcher" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Sierra Classics Launcher" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Sierra Classics Launcher" "NoRepair" 1
  WriteUninstaller "uninstall.exe"
  
SectionEnd

; Optional section (can be disabled by the user)
Section "Start Menu Shortcuts"

  CreateDirectory "$SMPROGRAMS\Sierra Classics Launcher"
  CreateShortCut "$SMPROGRAMS\Sierra Classics Launcher\Uninstall.lnk" "$INSTDIR\uninstall.exe" "" "$INSTDIR\uninstall.exe" 0
  CreateShortCut "$SMPROGRAMS\Sierra Classics Launcher\Sierra Classics Launcher.lnk" "$INSTDIR\Sierra Classics Launcher.Exe" "" "$INSTDIR\Sierra Classics Launcher.exe" 0
  
SectionEnd

;--------------------------------

; Uninstaller

Section "Uninstall"
  
  ; Remove registry keys
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Sierra Classics Launcher"
  DeleteRegKey HKLM "SOFTWARE\Vaguesoft\Sierra Classics Launcher"

  ; Remove files
  Delete "$INSTDIR\*.*"
  Delete "$INSTDIR\XML\*.*"
  Delete "$INSTDIR\GameArt\*.*"

  ; Remove shortcuts, if any
  Delete "$SMPROGRAMS\Sierra Classics Launcher\*.*"

  ; Remove directories used
  RMDir "$SMPROGRAMS\Sierra Classics Launcher"
  RMDir "$INSTDIR\XML"
  RMDir "$INSTDIR\GameArt"
  RMDir "$INSTDIR"

SectionEnd
