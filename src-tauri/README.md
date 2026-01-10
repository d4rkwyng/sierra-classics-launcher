# Sierra Classics Launcher - Tauri Port

A lightweight, cross-platform launcher for classic Sierra games, built with Tauri (Rust + HTML/CSS/JS).

## Features

- **Cross-platform**: Windows, macOS, and Linux
- **Lightweight**: ~5-10MB app size (vs 150MB+ for Electron)
- **Native Performance**: Rust backend with native system integration
- **DOSBox Integration**: Launch games through DOSBox
- **ScummVM Integration**: Launch games through ScummVM
- **Game Database**: XML-based game collections with artwork support
- **Customizable**: Configure paths, startup behavior, and display options

## Requirements

### For Development
- [Rust](https://rustup.rs/) (1.70 or later)
- [Node.js](https://nodejs.org/) (optional, only if you want to use a bundler)

### For Running Games
- DOSBox and/or ScummVM installed

## Building

```bash
cd src-tauri

# Development mode
cargo tauri dev

# Production build
cargo tauri build
```

## Build Output

After building, you'll find the app in:
- **macOS**: `target/release/bundle/macos/Sierra Classics Launcher.app`
- **Windows**: `target/release/bundle/msi/` or `target/release/bundle/nsis/`
- **Linux**: `target/release/bundle/deb/` or `target/release/bundle/appimage/`

## Project Structure

```
src-tauri/
├── Cargo.toml          # Rust dependencies
├── tauri.conf.json     # Tauri configuration
├── src/
│   ├── main.rs         # App entry point & Tauri commands
│   ├── config.rs       # Configuration loading/saving
│   ├── database.rs     # Game database management
│   └── launcher.rs     # Game launching logic
└── ui/
    ├── index.html      # Main window UI
    ├── styles.css      # Styling
    └── app.js          # Frontend logic
```

## Configuration

The launcher uses XML files for configuration:

- `config.xml` - Application settings (paths, preferences)
- `XML/*.xml` - Game database files

### Path Placeholders

- `%CURDIR` - Application directory
- `%PATH` - Default game path (from database)
- `%GAMEART` - Game artwork directory

## Compatibility

Your existing XML configuration and game database files from the original
VB.NET version are fully compatible with this Tauri port.

## License

See LICENSE file in the project root.
