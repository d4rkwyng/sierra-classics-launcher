using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using SierraLauncher.Models;

namespace SierraLauncher.Services;

/// <summary>
/// Service for loading and saving game database XML files.
/// </summary>
public class GameDatabaseService
{
    private readonly ConfigurationService _configService;

    public GameDatabaseService(ConfigurationService configService)
    {
        _configService = configService;
    }

    /// <summary>
    /// Gets all available database files from the XML database path.
    /// </summary>
    public List<string> GetAvailableDatabases()
    {
        var dbPath = _configService.Configuration.XmlDatabasePath;

        if (!Directory.Exists(dbPath))
        {
            return new List<string>();
        }

        return Directory.GetFiles(dbPath, "*.xml")
            .Select(Path.GetFileName)
            .Where(f => f != null)
            .Cast<string>()
            .OrderBy(f => f)
            .ToList();
    }

    /// <summary>
    /// Loads a game database from an XML file.
    /// </summary>
    public GameDatabase? LoadDatabase(string fileName)
    {
        var dbPath = _configService.Configuration.XmlDatabasePath;
        var filePath = Path.Combine(dbPath, fileName);

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Database file not found: {filePath}");
            return null;
        }

        try
        {
            var doc = XDocument.Load(filePath);
            var root = doc.Root;

            if (root == null) return null;

            var database = new GameDatabase
            {
                FileName = fileName,
                Name = GetElementValue(root, "Name"),
                DefaultPath = GetElementValue(root, "DefaultPath"),
                ManualPath = GetElementValue(root, "GameManual"),
                CollectionArtworkPath = GetElementValue(root, "GameArt")
            };

            // Parse number of games
            var numButtonsStr = GetElementValue(root, "NumButtons", "0");
            if (!int.TryParse(numButtonsStr, out var numGames))
            {
                numGames = 0;
            }

            // Load games (Game1 through Game7)
            var games = new List<GameInfo>();
            for (int i = 1; i <= Math.Min(numGames, 7); i++)
            {
                var game = new GameInfo
                {
                    Name = GetElementValue(root, $"Game{i}Name"),
                    Program = GetElementValue(root, $"Game{i}Prog"),
                    Path = GetElementValue(root, $"Game{i}Path"),
                    Executable = GetElementValue(root, $"Game{i}Exe"),
                    CommandLine = GetElementValue(root, $"Game{i}Cmd"),
                    ArtworkPath = GetElementValue(root, $"Game{i}Art")
                };

                // Apply placeholder replacements
                ApplyPlaceholders(game, database.DefaultPath);
                games.Add(game);
            }

            database.Games = games;

            // Apply placeholders to database-level paths
            database.ManualPath = _configService.ReplacePlaceholders(
                database.ManualPath, database.DefaultPath);
            database.CollectionArtworkPath = _configService.ReplacePlaceholders(
                database.CollectionArtworkPath, database.DefaultPath);

            return database;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading database {fileName}: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Saves a game database to an XML file.
    /// </summary>
    public void SaveDatabase(GameDatabase database)
    {
        var dbPath = _configService.Configuration.XmlDatabasePath;
        var filePath = Path.Combine(dbPath, database.FileName);

        try
        {
            // Ensure directory exists
            Directory.CreateDirectory(dbPath);

            // Build root element name from filename (without .xml extension)
            var rootName = Path.GetFileNameWithoutExtension(database.FileName);

            var root = new XElement(rootName,
                new XElement("Name", database.Name),
                new XElement("NumButtons", database.Games.Count),
                new XElement("DefaultPath", database.DefaultPath),
                new XElement("GameManual", database.ManualPath),
                new XElement("GameArt", database.CollectionArtworkPath)
            );

            // Add game elements
            for (int i = 0; i < database.Games.Count && i < 7; i++)
            {
                var game = database.Games[i];
                var idx = i + 1;

                root.Add(new XElement($"Game{idx}Name", game.Name));
                root.Add(new XElement($"Game{idx}Prog", game.Program));
                root.Add(new XElement($"Game{idx}Path", game.Path));
                root.Add(new XElement($"Game{idx}Exe", game.Executable));
                root.Add(new XElement($"Game{idx}Cmd", game.CommandLine));
                root.Add(new XElement($"Game{idx}Art", game.ArtworkPath));
            }

            var doc = new XDocument(new XDeclaration("1.0", "utf-8", null), root);
            doc.Save(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving database {database.FileName}: {ex.Message}");
        }
    }

    /// <summary>
    /// Deletes a game database file.
    /// </summary>
    public bool DeleteDatabase(string fileName)
    {
        var dbPath = _configService.Configuration.XmlDatabasePath;
        var filePath = Path.Combine(dbPath, fileName);

        try
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting database {fileName}: {ex.Message}");
            return false;
        }
    }

    private void ApplyPlaceholders(GameInfo game, string defaultPath)
    {
        game.Path = _configService.ReplacePlaceholders(game.Path, defaultPath);
        game.CommandLine = _configService.ReplacePlaceholders(game.CommandLine, defaultPath);
        game.ArtworkPath = _configService.ReplacePlaceholders(game.ArtworkPath, defaultPath);
    }

    private static string GetElementValue(XElement parent, string name, string defaultValue = "")
    {
        return parent.Element(name)?.Value ?? defaultValue;
    }
}
