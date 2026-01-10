# Sierra Classics Launcher - Avalonia Port

A cross-platform launcher for classic Sierra games, built with .NET 8.0 and Avalonia UI.

## Features

- **Cross-platform**: Runs on Windows, macOS, and Linux
- **DOSBox Integration**: Launch games through DOSBox with custom configurations
- **ScummVM Integration**: Launch games through ScummVM
- **Game Database**: XML-based game collections with artwork support
- **Customizable**: Configure paths, startup behavior, and display options

## Requirements

- .NET 8.0 SDK or later
- DOSBox and/or ScummVM installed (for launching games)

## Building

```bash
cd src-avalonia
dotnet restore
dotnet build
```

## Running

```bash
dotnet run
```

## Publishing

### For macOS:
```bash
dotnet publish -c Release -r osx-x64 --self-contained
```

### For Windows:
```bash
dotnet publish -c Release -r win-x64 --self-contained
```

### For Linux:
```bash
dotnet publish -c Release -r linux-x64 --self-contained
```

## Configuration

The launcher uses XML files for configuration:

- `config.xml` - Application settings (paths, preferences)
- `XML/*.xml` - Game database files

### Path Placeholders

- `%CURDIR` - Application directory
- `%PATH` - Default game path (from database)
- `%GAMEART` - Game artwork directory

## Migration from VB.NET Version

This is a complete rewrite of the original VB.NET Windows Forms application.
Your existing XML configuration and game database files are fully compatible.

## License

See LICENSE file in the project root.
