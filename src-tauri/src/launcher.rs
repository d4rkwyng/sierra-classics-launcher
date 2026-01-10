use crate::config::AppConfig;
use crate::database::GameDatabase;
use std::process::Command;

pub fn launch_game(config: &AppConfig, database: &GameDatabase, game_index: usize) -> Result<(), String> {
    if game_index >= database.games.len() {
        return Err("Invalid game index".to_string());
    }

    let game = &database.games[game_index];

    // Handle shortcut files
    if game.path.ends_with(".lnk") {
        return open_file(&game.path);
    }

    let (program, args) = build_launch_command(config, game)?;

    Command::new(&program)
        .args(&args)
        .current_dir(if game.path.is_empty() { "." } else { &game.path })
        .spawn()
        .map_err(|e| format!("Failed to launch game: {}", e))?;

    Ok(())
}

pub fn open_file(path: &str) -> Result<(), String> {
    #[cfg(target_os = "macos")]
    {
        Command::new("open")
            .arg(path)
            .spawn()
            .map_err(|e| format!("Failed to open file: {}", e))?;
    }

    #[cfg(target_os = "linux")]
    {
        Command::new("xdg-open")
            .arg(path)
            .spawn()
            .map_err(|e| format!("Failed to open file: {}", e))?;
    }

    #[cfg(target_os = "windows")]
    {
        Command::new("cmd")
            .args(["/C", "start", "", path])
            .spawn()
            .map_err(|e| format!("Failed to open file: {}", e))?;
    }

    Ok(())
}

fn build_launch_command(
    config: &AppConfig,
    game: &crate::database::GameInfo,
) -> Result<(String, Vec<String>), String> {
    let program = game.program.to_lowercase();
    let game_path = game.path.trim_end_matches(['/', '\\']);

    match program.as_str() {
        "dosbox" => build_dosbox_command(config, game_path, &game.executable, &game.command_line),
        "scummvm" => build_scummvm_command(config, game_path, &game.executable, &game.command_line),
        "" => {
            // Custom/direct executable
            let exe_path = if game_path.is_empty() {
                game.executable.clone()
            } else {
                format!("{}/{}", game_path, game.executable)
            };
            Ok((exe_path, parse_args(&game.command_line)))
        }
        _ => {
            // Other program specified
            let mut args = vec![game_path.to_string(), game.executable.clone()];
            args.extend(parse_args(&game.command_line));
            Ok((game.program.clone(), args))
        }
    }
}

fn build_dosbox_command(
    config: &AppConfig,
    game_path: &str,
    game_exe: &str,
    game_cmd: &str,
) -> Result<(String, Vec<String>), String> {
    let dosbox_path = config.dosbox_path.trim_end_matches(['/', '\\']);

    let program = get_executable_path(dosbox_path, "dosbox");

    let mut args = Vec::new();

    // Mount the game path as C:
    if !game_path.is_empty() {
        args.push("-c".to_string());
        args.push(format!("mount C '{}'", game_path));
        args.push("-c".to_string());
        args.push("C:".to_string());
    }

    // Add game executable command
    if !game_exe.is_empty() {
        args.push("-c".to_string());
        args.push(game_exe.to_string());
    }

    // Add extra command line arguments
    if !game_cmd.is_empty() {
        args.extend(parse_args(game_cmd));
    }

    Ok((program, args))
}

fn build_scummvm_command(
    config: &AppConfig,
    game_path: &str,
    game_exe: &str,
    game_cmd: &str,
) -> Result<(String, Vec<String>), String> {
    let scummvm_path = config.scummvm_path.trim_end_matches(['/', '\\']);

    let program = get_executable_path(scummvm_path, "scummvm");

    let mut args = Vec::new();

    // If command already contains -p, use it directly
    if game_cmd.contains("-p") {
        args.extend(parse_args(game_cmd));
    } else {
        if !game_path.is_empty() {
            args.push("-p".to_string());
            args.push(game_path.to_string());
        }
        if !game_exe.is_empty() {
            args.push(game_exe.to_string());
        }
        if !game_cmd.is_empty() {
            args.extend(parse_args(game_cmd));
        }
    }

    Ok((program, args))
}

fn get_executable_path(base_path: &str, exe_name: &str) -> String {
    #[cfg(target_os = "macos")]
    {
        if base_path.ends_with(".app") {
            format!("{}/Contents/MacOS/{}", base_path, exe_name)
        } else {
            format!("{}/{}", base_path, exe_name)
        }
    }

    #[cfg(target_os = "linux")]
    {
        format!("{}/{}", base_path, exe_name)
    }

    #[cfg(target_os = "windows")]
    {
        format!("{}\\{}.exe", base_path, exe_name)
    }
}

fn parse_args(cmd: &str) -> Vec<String> {
    // Simple argument parser that handles quoted strings
    let mut args = Vec::new();
    let mut current = String::new();
    let mut in_quotes = false;
    let mut quote_char = ' ';

    for c in cmd.chars() {
        match c {
            '"' | '\'' if !in_quotes => {
                in_quotes = true;
                quote_char = c;
            }
            c if c == quote_char && in_quotes => {
                in_quotes = false;
            }
            ' ' if !in_quotes => {
                if !current.is_empty() {
                    args.push(current.clone());
                    current.clear();
                }
            }
            _ => {
                current.push(c);
            }
        }
    }

    if !current.is_empty() {
        args.push(current);
    }

    args
}
