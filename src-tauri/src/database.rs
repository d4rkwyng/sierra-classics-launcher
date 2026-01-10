use crate::config::replace_placeholders;
use serde::{Deserialize, Serialize};
use std::fs;
use std::path::Path;

#[derive(Debug, Clone, Serialize, Deserialize)]
#[serde(rename_all = "camelCase")]
pub struct GameInfo {
    pub name: String,
    pub program: String,
    pub path: String,
    pub executable: String,
    pub command_line: String,
    pub artwork_path: String,
}

impl Default for GameInfo {
    fn default() -> Self {
        Self {
            name: String::new(),
            program: String::new(),
            path: String::new(),
            executable: String::new(),
            command_line: String::new(),
            artwork_path: String::new(),
        }
    }
}

#[derive(Debug, Clone, Serialize, Deserialize)]
#[serde(rename_all = "camelCase")]
pub struct GameDatabase {
    pub filename: String,
    pub name: String,
    pub default_path: String,
    pub manual_path: String,
    pub collection_artwork_path: String,
    pub games: Vec<GameInfo>,
}

pub fn get_available_databases(xml_path: &str) -> Result<Vec<String>, String> {
    let path = Path::new(xml_path);

    if !path.exists() {
        return Ok(Vec::new());
    }

    let entries = fs::read_dir(path)
        .map_err(|e| format!("Failed to read directory: {}", e))?;

    let mut databases: Vec<String> = entries
        .filter_map(|entry| entry.ok())
        .filter(|entry| {
            entry.path()
                .extension()
                .map(|ext| ext.to_string_lossy().to_lowercase() == "xml")
                .unwrap_or(false)
        })
        .filter_map(|entry| {
            entry.file_name().to_str().map(|s| s.to_string())
        })
        .collect();

    databases.sort();
    Ok(databases)
}

pub fn load_database(
    xml_path: &str,
    game_art_path: &str,
    app_dir: &str,
    filename: &str,
) -> Result<GameDatabase, String> {
    let file_path = Path::new(xml_path).join(filename);

    if !file_path.exists() {
        return Err(format!("Database file not found: {}", filename));
    }

    let content = fs::read_to_string(&file_path)
        .map_err(|e| format!("Failed to read database: {}", e))?;

    parse_database_xml(&content, filename, game_art_path, app_dir)
}

pub fn save_database(xml_path: &str, database: &GameDatabase) -> Result<(), String> {
    let file_path = Path::new(xml_path).join(&database.filename);

    // Ensure directory exists
    if let Some(parent) = file_path.parent() {
        fs::create_dir_all(parent)
            .map_err(|e| format!("Failed to create directory: {}", e))?;
    }

    // Build root element name from filename
    let root_name = database.filename
        .strip_suffix(".xml")
        .unwrap_or(&database.filename)
        .replace(" ", "");

    let mut xml = format!(
        r#"<?xml version="1.0"?>
<{root}>
    <Name>{}</Name>
    <NumButtons>{}</NumButtons>
    <DefaultPath>{}</DefaultPath>
    <GameManual>{}</GameManual>
    <GameArt>{}</GameArt>"#,
        database.name,
        database.games.len(),
        database.default_path,
        database.manual_path,
        database.collection_artwork_path,
        root = root_name
    );

    for (i, game) in database.games.iter().enumerate() {
        let idx = i + 1;
        xml.push_str(&format!(
            r#"
    <Game{}Name>{}</Game{}Name>
    <Game{}Prog>{}</Game{}Prog>
    <Game{}Path>{}</Game{}Path>
    <Game{}Exe>{}</Game{}Exe>
    <Game{}Cmd>{}</Game{}Cmd>
    <Game{}Art>{}</Game{}Art>"#,
            idx, game.name, idx,
            idx, game.program, idx,
            idx, game.path, idx,
            idx, game.executable, idx,
            idx, game.command_line, idx,
            idx, game.artwork_path, idx
        ));
    }

    xml.push_str(&format!("\n</{}>", root_name));

    fs::write(&file_path, xml)
        .map_err(|e| format!("Failed to save database: {}", e))
}

pub fn delete_database(xml_path: &str, filename: &str) -> Result<(), String> {
    let file_path = Path::new(xml_path).join(filename);

    if file_path.exists() {
        fs::remove_file(&file_path)
            .map_err(|e| format!("Failed to delete database: {}", e))?;
    }

    Ok(())
}

fn parse_database_xml(
    content: &str,
    filename: &str,
    game_art_path: &str,
    app_dir: &str,
) -> Result<GameDatabase, String> {
    let default_path = extract_element(content, "DefaultPath").unwrap_or_default();

    let mut database = GameDatabase {
        filename: filename.to_string(),
        name: extract_element(content, "Name").unwrap_or_default(),
        default_path: default_path.clone(),
        manual_path: replace_placeholders(
            &extract_element(content, "GameManual").unwrap_or_default(),
            app_dir,
            &default_path,
            game_art_path,
        ),
        collection_artwork_path: replace_placeholders(
            &extract_element(content, "GameArt").unwrap_or_default(),
            app_dir,
            &default_path,
            game_art_path,
        ),
        games: Vec::new(),
    };

    // Parse number of games
    let num_games: usize = extract_element(content, "NumButtons")
        .and_then(|s| s.parse().ok())
        .unwrap_or(0)
        .min(7);

    // Parse games
    for i in 1..=num_games {
        let game = GameInfo {
            name: extract_element(content, &format!("Game{}Name", i)).unwrap_or_default(),
            program: extract_element(content, &format!("Game{}Prog", i)).unwrap_or_default(),
            path: replace_placeholders(
                &extract_element(content, &format!("Game{}Path", i)).unwrap_or_default(),
                app_dir,
                &default_path,
                game_art_path,
            ),
            executable: extract_element(content, &format!("Game{}Exe", i)).unwrap_or_default(),
            command_line: replace_placeholders(
                &extract_element(content, &format!("Game{}Cmd", i)).unwrap_or_default(),
                app_dir,
                &default_path,
                game_art_path,
            ),
            artwork_path: replace_placeholders(
                &extract_element(content, &format!("Game{}Art", i)).unwrap_or_default(),
                app_dir,
                &default_path,
                game_art_path,
            ),
        };
        database.games.push(game);
    }

    Ok(database)
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
