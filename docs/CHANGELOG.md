# Sierra Classics Launcher Change Log

## 1.0.0.20 (17 July 2013)

- Updated Program Logo and About information

## 1.0.0.19 (5 August 2012)

- Changed ScummVM launch process
  - Uses Game Path for `-p` argument and Executable for Game Identifier
  - Includes old method of passing only arguments to application
- Added ability to put any application in Program field
- Added Open menu item under File for opening a database
- Small GUI changes

## 1.0.0.18 (26 July 2012)

- Added checkbox for remembering last opened database on application close
  - Note: Application saves config during close (not game database files)
- Added tooltip variable info to Preferences
- Small GUI changes
- Recoded launching of applications
- Added the ability to launch other applications
  - To use: leave program field blank and SCL will start process with Game Path & Game Exe with Game Cmd for arguments

## 1.0.0.17 (26 July 2009)

- Fixed configuration save loading incorrect database
- Added saving of game entry selection after save config
- Added internal mounting (issue with "King's" due to single quote)
  - Launches the dosbox application with `-c` variable for executing commands
  - `mount c '<gamepath>'`
- Added command line argument `-xml`
  - Usage: `SCLauncher.exe -xml SpaceQuestLauncher.xml`
  - Note: Looks in the set XML path for the database to launch

## 1.0.0.16 (19 June 2009)

- Removed registry configuration
- Added XML configuration for planned portable use (`config.xml`)
- Added default variables when `config.xml` not found
- Added `%CURDIR` for use with XMLDBPath and GameArtPath variables in Preferences (portable use)
- Improved memory management

## 1.0.0.15 (17 June 2007)

- Added error checking for missing data or databases
- Added option to hide the Database drop down box
- Added option to show GameArt for each Game
- Added Game Art Path textbox
- Added Game Art coding (mousehover, mouseleave, etc.)
- Added new variables:
  - `%CURDIR` - the application's startup directory
  - `%GAMEART` - the specified Game Art Path
- Added images to Database page for showing default art and game art

## 1.0.0.14 Beta (10 June 2007)

- Added option to close Preferences window when saving
  - Note: Turning this off is useful when editing multiple databases
- Edited launcher coding to better support additional programs (tested with ScummVM)
- Added ScummVM support (ScummVM now includes Sarien)
- Added textbox for ScummVM path
- Added XML Database Path textbox

## 1.0.0.13 Beta (9 June 2007)

- Added check for file extension on creating a new database
- Set `dosbox` to the defined default value for GameProgs
- Reset game to 1 when changing the number of buttons in Database tab
- Added delete button to database tab
- Added default name and buttons values when creating a new Database
- Set the images to stretch to fit within window

## 1.0.0.12 Beta (9 June 2007)

- Fixed bug: changing buttons value in preferences would result in data loss
  - Note: Will now save the data if the number is changed to add another game to the database

## 1.0.0.11 Beta (8 June 2007)

- Added DOSBox integration for running it directly (shortcuts are still supported)
- Added `Game#Exe` variables
- Added registry reading/writing code back into program for preferences and variables
- Added `Game#Prog` and `Game#Cmd` functions
- Removed Tools -> Databases menu options
- Added Listbox to bottom left of form (automatically loads on change)
- Updated default XML files for new syntax
- Added new value `DefaultPath`
- Added new custom variable for databases `%PATH`
- Added Preferences form (Main and Database tabs)
- Added option to choose which file loads on start (first, last, random, custom)
- Added option to customize the title window (variables: `%APP`, `%VER`, `%GAME`)
- Added option to specify dosbox location
- Added database reading/writing for XML files
- Added Reload option (CTRL+R)
- Fixed tab indexes
- Added error checking
- Many other fixes

## 1.0.0.10 Beta (3 June 2007)

- Removed the registry portion of the code (no longer uses registry)
- Removed internal images
- Removed Preferences form
- Added XML file reading
- Added launching of first XML file found in XML folder
- Cleaned coding (smaller footprint)

## 1.0.0.9 Beta (3 June 2007)

- Original release based off the Space Quest Launcher 1.0.0.8 code

---

## Space Quest Launcher

### 1.0.0.8 (2 June 2007)

- Fixed spelling errors in preferences and about page
- Renamed caption to "Space Quest Collection(TM)"
- Renamed Space Quest: Replicated to Space Quest 0: Replicated
- Moved Space Quest Replicated to position 2 on the Misc Launch Options
- Switch button for Misc Launch Options

### 1.0.0.7 (2 June 2007)

- Fixed tab indexes and focusing
- Cleaned code

### 1.0.0.6 (2 June 2007)

- Added ability to add SQ1EGA, SQ Lost Chapter, and SQ Replicated shortcut links

### 1.0.0.5 (2 June 2007)

- Added option to specify whether to use the default shortcut paths or specify individual locations

### 1.0.0.4 (1 June 2007)

- Added manual location for each shortcut to be launched

### 1.0.0.3 (1 June 2007)

- Added registry keys for variables instead of the file
- Removed config file (`config.cfg`)
- Removed all variables and code related to writing and loading a file

### 1.0.0.2 (1 June 2007)

- Edited launcher code to handle install shortcuts

### 1.0.0.1 (31 May 2007)

- Added launcher sub routine to handle executes and catches

### 1.0.0.0 (31 May 2007)

- Original release
