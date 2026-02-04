# Sierra Classics Launcher Help

## Requirements

- .NET Framework 2.0 or higher
- System requirements to match games loaded

## Introduction

Sierra Classics Launcher comes with four preset XML databases: Space Quest Collection, King's Quest Collection, Police Quest Collection, and Leisure Suit Larry Collection.

The program should work right away, but you may have to edit the paths in the database file. They are set to the default locations after Collector's patch has been installed.

On initial loading the program will load the first database found in the XML folder. You can specify which database to load on start in the preferences. The options are: First, Last, Random, and Custom. The custom variable allows you to specifically name the database you'd like to load. If it's not found it will load the first.

## Options

- **Tools -> Reload** - Reloads databases

## Troubleshooting

An example database would look like this:

```xml
<SpaceQuestCollection>
  <Name>Space Quest Collection</Name>
  <NumButtons>1</NumButtons>
  <DefaultPath>C:\Program Files\Sierra\Space Quest Collection(TM)</DefaultPath>
  <GameManual>%PATH\Manuals\SQManual.pdf</GameManual>
  <GameArt>%PATH\gameart.bmp</GameArt>

  <Game1Name>Space Quest 1 VGA</Game1Name>
  <Game1Prog>dosbox</Game1Prog>
  <Game1Path>%PATH\SQ1VGA</Game1Path>
  <Game1Exe>SCIDHUV.EXE</Game1Exe>
  <Game1Cmd>-conf "%PATH\SQ1VGA\dosbox.conf" -noconsole -exit</Game1Cmd>
  <Game1Art>"%GAMEART\SQ\SQ1.PNG"</Game1Art>
</SpaceQuestCollection>
```

### Database Elements

| Element | Description |
|---------|-------------|
| `Name` | Name of the game or series |
| `NumButtons` | Number of games to load (max 7) |
| `DefaultPath` | The default path to use (`%PATH` calls this) |
| `GameManual` | Path to game manual |
| `GameArt` | Path to image file (e.g. `gameart.bmp`) |
| `Game#Name` | Game name |
| `Game#Prog` | The program to use (e.g. `dosbox`, `scummvm`) |
| `Game#Path` | Path to file to run (also: shortcuts or direct file path) |
| `Game#Exe` | The file to run in the specified path |
| `Game#Cmd` | Additional commands to attach to program |
| `Game#Art` | Individual game art |

### Database Variables

| Variable | Description |
|----------|-------------|
| `%PATH` | Specified default path to game directory |
| `%CURDIR` | Application's startup path |
| `%GAMEART` | Specified game art path |

## Contact

For comments or suggestions, open an issue on GitHub or contact @d4rkwyng.
