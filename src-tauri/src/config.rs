use serde::{Deserialize, Serialize};
use std::fs;
use std::path::Path;

#[derive(Debug, Clone, Serialize, Deserialize)]
#[serde(rename_all = "camelCase")]
pub struct AppConfig {
    pub startup_database: String,
    pub dosbox_path: String,
    pub scummvm_path: String,
    pub title_window_format: String,
    pub xml_database_path: String,
    pub game_art_path: String,
    pub close_on_save: bool,
    pub hide_database: bool,
    pub remember_last_database: bool,
    pub show_game_art_on_hover: bool,
}

impl AppConfig {
    pub fn default(app_dir: &str) -> Self {
        Self {
            startup_database: "first".to_string(),
            dosbox_path: get_default_dosbox_path(),
            scummvm_path: get_default_scummvm_path(),
            title_window_format: "%APP - %GAME".to_string(),
            xml_database_path: format!("{}/XML", app_dir),
            game_art_path: format!("{}/GameArt", app_dir),
            close_on_save: false,
            hide_database: false,
            remember_last_database: true,
            show_game_art_on_hover: true,
        }
    }
}

pub fn load_config(app_dir: &str) -> Result<AppConfig, String> {
    let config_path = Path::new(app_dir).join("config.xml");

    if !config_path.exists() {
        return Err("Config file not found".to_string());
    }

    let content = fs::read_to_string(&config_path)
        .map_err(|e| format!("Failed to read config: {}", e))?;

    parse_config_xml(&content, app_dir)
}

pub fn save_config(app_dir: &str, config: &AppConfig) -> Result<(), String> {
    let config_path = Path::new(app_dir).join("config.xml");

    let xml = format!(
        r#"<?xml version="1.0" encoding="utf-8"?>
<Configuration>
    <StartupDatabase>{}</StartupDatabase>
    <DOSBoxPath>{}</DOSBoxPath>
    <ScummVMPath>{}</ScummVMPath>
    <TitleWindow>{}</TitleWindow>
    <XMLDBPath>{}</XMLDBPath>
    <GameArtPath>{}</GameArtPath>
    <CloseOnSave>{}</CloseOnSave>
    <HideDB>{}</HideDB>
    <LastDBonExit>{}</LastDBonExit>
    <ShowGameArt>{}</ShowGameArt>
</Configuration>"#,
        config.startup_database,
        config.dosbox_path,
        config.scummvm_path,
        config.title_window_format,
        config.xml_database_path,
        config.game_art_path,
        config.close_on_save,
        config.hide_database,
        config.remember_last_database,
        config.show_game_art_on_hover
    );

    fs::write(&config_path, xml)
        .map_err(|e| format!("Failed to save config: {}", e))
}

fn parse_config_xml(content: &str, app_dir: &str) -> Result<AppConfig, String> {
    let mut config = AppConfig::default(app_dir);

    // Simple XML parsing for the flat config structure
    config.startup_database = extract_element(content, "StartupDatabase")
        .unwrap_or_else(|| "first".to_string());

    config.dosbox_path = replace_placeholders(
        &extract_element(content, "DOSBoxPath").unwrap_or_default(),
        app_dir,
        "",
        ""
    );

    config.scummvm_path = replace_placeholders(
        &extract_element(content, "ScummVMPath").unwrap_or_default(),
        app_dir,
        "",
        ""
    );

    config.title_window_format = extract_element(content, "TitleWindow")
        .unwrap_or_else(|| "%APP - %GAME".to_string());

    config.xml_database_path = replace_placeholders(
        &extract_element(content, "XMLDBPath").unwrap_or_default(),
        app_dir,
        "",
        ""
    );

    config.game_art_path = replace_placeholders(
        &extract_element(content, "GameArtPath").unwrap_or_default(),
        app_dir,
        "",
        ""
    );

    config.close_on_save = extract_element(content, "CloseOnSave")
        .map(|s| s.to_lowercase() == "true")
        .unwrap_or(false);

    config.hide_database = extract_element(content, "HideDB")
        .map(|s| s.to_lowercase() == "true")
        .unwrap_or(false);

    config.remember_last_database = extract_element(content, "LastDBonExit")
        .map(|s| s.to_lowercase() == "true")
        .unwrap_or(true);

    config.show_game_art_on_hover = extract_element(content, "ShowGameArt")
        .map(|s| s.to_lowercase() == "true")
        .unwrap_or(true);

    // Apply defaults for empty paths
    if config.xml_database_path.is_empty() {
        config.xml_database_path = format!("{}/XML", app_dir);
    }
    if config.game_art_path.is_empty() {
        config.game_art_path = format!("{}/GameArt", app_dir);
    }
    if config.dosbox_path.is_empty() {
        config.dosbox_path = get_default_dosbox_path();
    }
    if config.scummvm_path.is_empty() {
        config.scummvm_path = get_default_scummvm_path();
    }

    Ok(config)
}

fn extract_element(content: &str, tag: &str) -> Option<String> {
    let start_tag = format!("<{}>", tag);
    let end_tag = format!("</{}>", tag);

    let start = content.find(&start_tag)?;
    let end = content.find(&end_tag)?;

    let value_start = start + start_tag.len();
    if value_start < end {
        Some(content[value_start..end].trim().to_string())
    } else {
        None
    }
}

pub fn replace_placeholders(input: &str, app_dir: &str, default_path: &str, game_art_path: &str) -> String {
    let mut result = input.to_string();

    // Replace %CURDIR with app directory
    result = result.replace("%CURDIR", app_dir);

    // Replace %PATH with default path
    if !default_path.is_empty() {
        result = result.replace("%PATH", default_path);
    }

    // Replace %GAMEART with game art path
    if !game_art_path.is_empty() {
        result = result.replace("%GAMEART", game_art_path);
    }

    // Normalize path separators
    #[cfg(target_os = "windows")]
    {
        result = result.replace("/", "\\");
    }
    #[cfg(not(target_os = "windows"))]
    {
        result = result.replace("\\", "/");
    }

    result
}

fn get_default_dosbox_path() -> String {
    #[cfg(target_os = "macos")]
    {
        "/Applications/DOSBox.app/Contents/MacOS".to_string()
    }
    #[cfg(target_os = "linux")]
    {
        "/usr/bin".to_string()
    }
    #[cfg(target_os = "windows")]
    {
        "C:\\Program Files\\DOSBox".to_string()
    }
}

fn get_default_scummvm_path() -> String {
    #[cfg(target_os = "macos")]
    {
        "/Applications/ScummVM.app/Contents/MacOS".to_string()
    }
    #[cfg(target_os = "linux")]
    {
        "/usr/bin".to_string()
    }
    #[cfg(target_os = "windows")]
    {
        "C:\\Program Files\\ScummVM".to_string()
    }
}
