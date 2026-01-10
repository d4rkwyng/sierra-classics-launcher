#![cfg_attr(
    all(not(debug_assertions), target_os = "windows"),
    windows_subsystem = "windows"
)]

mod config;
mod database;
mod launcher;

use config::{AppConfig, load_config, save_config};
use database::{GameDatabase, get_available_databases, load_database, save_database, delete_database};
use launcher::launch_game;
use std::sync::Mutex;
use tauri::State;

struct AppState {
    config: Mutex<AppConfig>,
    app_dir: String,
}

#[tauri::command]
fn get_config(state: State<AppState>) -> Result<AppConfig, String> {
    let config = state.config.lock().map_err(|e| e.to_string())?;
    Ok(config.clone())
}

#[tauri::command]
fn update_config(state: State<AppState>, new_config: AppConfig) -> Result<(), String> {
    let mut config = state.config.lock().map_err(|e| e.to_string())?;
    *config = new_config.clone();
    save_config(&state.app_dir, &new_config)
}

#[tauri::command]
fn get_databases(state: State<AppState>) -> Result<Vec<String>, String> {
    let config = state.config.lock().map_err(|e| e.to_string())?;
    get_available_databases(&config.xml_database_path)
}

#[tauri::command]
fn load_game_database(state: State<AppState>, filename: String) -> Result<GameDatabase, String> {
    let config = state.config.lock().map_err(|e| e.to_string())?;
    load_database(&config.xml_database_path, &config.game_art_path, &state.app_dir, &filename)
}

#[tauri::command]
fn save_game_database(state: State<AppState>, database: GameDatabase) -> Result<(), String> {
    let config = state.config.lock().map_err(|e| e.to_string())?;
    save_database(&config.xml_database_path, &database)
}

#[tauri::command]
fn delete_game_database(state: State<AppState>, filename: String) -> Result<(), String> {
    let config = state.config.lock().map_err(|e| e.to_string())?;
    delete_database(&config.xml_database_path, &filename)
}

#[tauri::command]
fn launch(state: State<AppState>, game_index: usize, database: GameDatabase) -> Result<(), String> {
    let config = state.config.lock().map_err(|e| e.to_string())?;
    launch_game(&config, &database, game_index)
}

#[tauri::command]
fn open_manual(path: String) -> Result<(), String> {
    launcher::open_file(&path)
}

fn main() {
    // Determine app directory
    let app_dir = std::env::current_exe()
        .ok()
        .and_then(|p| p.parent().map(|p| p.to_path_buf()))
        .map(|p| p.to_string_lossy().to_string())
        .unwrap_or_else(|| ".".to_string());

    // Load configuration
    let config = load_config(&app_dir).unwrap_or_else(|_| AppConfig::default(&app_dir));

    tauri::Builder::default()
        .manage(AppState {
            config: Mutex::new(config),
            app_dir,
        })
        .invoke_handler(tauri::generate_handler![
            get_config,
            update_config,
            get_databases,
            load_game_database,
            save_game_database,
            delete_game_database,
            launch,
            open_manual,
        ])
        .run(tauri::generate_context!())
        .expect("error while running tauri application");
}
