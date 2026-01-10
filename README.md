# Sierra Classics Launcher

A customizable launcher for classic Sierra games (King's Quest, Space Quest, Leisure Suit Larry, Police Quest, Quest for Glory, and more).

## Download

**[Download Latest Release](../../releases/latest)**

| Platform | Download |
|----------|----------|
| macOS (Apple Silicon) | `.dmg` |
| macOS (Intel) | `.dmg` |
| Windows | `.msi` |
| Linux | `.deb` or `.AppImage` |

## Features

- Launch games via DOSBox, ScummVM, or custom programs
- Build game collection databases with up to 7 games each
- Display game artwork with hover preview
- Cross-platform: macOS, Windows, and Linux

## Screenshots

<!-- Add screenshots here -->

## Requirements

- [DOSBox](https://www.dosbox.com/) and/or [ScummVM](https://www.scummvm.org/) installed
- Your Sierra game files

## Configuration

The launcher uses XML files for configuration:

- `config.xml` - Application settings (paths to DOSBox/ScummVM, preferences)
- `XML/*.xml` - Game database files (one per collection)
- `GameArt/` - Artwork images for your games

### Path Placeholders

Use these in your XML files:
- `%CURDIR` - Application directory
- `%PATH` - Default game path (from database)
- `%GAMEART` - Game artwork directory

## Building from Source

The modern version is built with [Tauri](https://tauri.app/) (Rust + HTML/JS).

```bash
cd src-tauri
cargo install tauri-cli
cargo tauri build
```

See [src-tauri/README.md](src-tauri/README.md) for details.

---

## History

Originally created by Derek Wood in June 2007 as a replacement for the launcher included with Vivendi's 2006 Sierra collections.

### Version History

#### 2.0.0.0 (January 2026)
- Complete rewrite using Tauri for cross-platform support
- Native macOS, Windows, and Linux builds
- Modern UI with same functionality

#### 1.0.0.20 (July 2013)
- Updated Program Logo and About information

#### 1.0.0.19 (August 2012)
- Changed ScummVM launch process
- Added ability to use any application in Program field
- Added Open menu item for opening databases

#### 1.0.0.18 (July 2012)
- Added checkbox for remembering last opened database
- Recoded launching of applications

---

## Original Version

The original VB.NET Windows Forms source code is preserved in the [`src/`](src/) directory for historical reference.

## License

See [LICENSE](LICENSE) file.
