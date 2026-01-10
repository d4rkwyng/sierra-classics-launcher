using System;
using System.IO;
using System.Xml.Linq;
using SierraLauncher.Models;

namespace SierraLauncher.Services;

/// <summary>
/// Service for loading and saving application configuration.
/// </summary>
public class ConfigurationService
{
    private const string ConfigFileName = "config.xml";
    private readonly string _appDirectory;

    public AppConfiguration Configuration { get; private set; } = new();

    public string AppDirectory => _appDirectory;

    public ConfigurationService()
    {
        _appDirectory = AppContext.BaseDirectory;
        LoadConfiguration();
    }

    public void LoadConfiguration()
    {
        var configPath = Path.Combine(_appDirectory, ConfigFileName);

        if (!File.Exists(configPath))
        {
            // Create default configuration
            Configuration = CreateDefaultConfiguration();
            SaveConfiguration();
            return;
        }

        try
        {
            var doc = XDocument.Load(configPath);
            var root = doc.Root;

            if (root == null) return;

            Configuration = new AppConfiguration
            {
                StartupDatabase = GetElementValue(root, "StartupDatabase"),
                DosBoxPath = ReplacePlaceholders(GetElementValue(root, "DOSBoxPath")),
                ScummVMPath = ReplacePlaceholders(GetElementValue(root, "ScummVMPath")),
                TitleWindowFormat = GetElementValue(root, "TitleWindow", "%APP - %GAME"),
                XmlDatabasePath = ReplacePlaceholders(GetElementValue(root, "XMLDBPath")),
                GameArtPath = ReplacePlaceholders(GetElementValue(root, "GameArtPath")),
                CloseOnSave = GetElementBool(root, "CloseOnSave"),
                HideDatabase = GetElementBool(root, "HideDB"),
                RememberLastDatabase = GetElementBool(root, "LastDBonExit", true),
                ShowGameArtOnHover = GetElementBool(root, "ShowGameArt", true)
            };

            // Apply defaults for empty paths
            if (string.IsNullOrEmpty(Configuration.XmlDatabasePath))
            {
                Configuration.XmlDatabasePath = Path.Combine(_appDirectory, "XML");
            }
            if (string.IsNullOrEmpty(Configuration.GameArtPath))
            {
                Configuration.GameArtPath = Path.Combine(_appDirectory, "GameArt");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading configuration: {ex.Message}");
            Configuration = CreateDefaultConfiguration();
        }
    }

    public void SaveConfiguration()
    {
        var configPath = Path.Combine(_appDirectory, ConfigFileName);

        try
        {
            var doc = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement("Configuration",
                    new XElement("StartupDatabase", Configuration.StartupDatabase),
                    new XElement("DOSBoxPath", Configuration.DosBoxPath),
                    new XElement("ScummVMPath", Configuration.ScummVMPath),
                    new XElement("TitleWindow", Configuration.TitleWindowFormat),
                    new XElement("XMLDBPath", Configuration.XmlDatabasePath),
                    new XElement("GameArtPath", Configuration.GameArtPath),
                    new XElement("CloseOnSave", Configuration.CloseOnSave),
                    new XElement("HideDB", Configuration.HideDatabase),
                    new XElement("LastDBonExit", Configuration.RememberLastDatabase),
                    new XElement("ShowGameArt", Configuration.ShowGameArtOnHover)
                )
            );

            doc.Save(configPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving configuration: {ex.Message}");
        }
    }

    public string ReplacePlaceholders(string input, string? defaultPath = null, string? gameArtPath = null)
    {
        if (string.IsNullOrEmpty(input)) return input;

        var result = input;

        // Replace %CURDIR with application directory
        result = result.Replace("%CURDIR", _appDirectory.TrimEnd(Path.DirectorySeparatorChar), StringComparison.OrdinalIgnoreCase);

        // Replace %PATH with default path (if provided)
        if (!string.IsNullOrEmpty(defaultPath))
        {
            result = result.Replace("%PATH", defaultPath, StringComparison.OrdinalIgnoreCase);
        }

        // Replace %GAMEART with game art path
        var artPath = gameArtPath ?? Configuration.GameArtPath;
        if (!string.IsNullOrEmpty(artPath))
        {
            result = result.Replace("%GAMEART", artPath.TrimEnd(Path.DirectorySeparatorChar), StringComparison.OrdinalIgnoreCase);
        }

        // Normalize path separators for current platform
        result = result.Replace('\\', Path.DirectorySeparatorChar);
        result = result.Replace('/', Path.DirectorySeparatorChar);

        return result;
    }

    private AppConfiguration CreateDefaultConfiguration()
    {
        return new AppConfiguration
        {
            StartupDatabase = "first",
            DosBoxPath = GetDefaultDosBoxPath(),
            ScummVMPath = GetDefaultScummVMPath(),
            TitleWindowFormat = "%APP - %GAME",
            XmlDatabasePath = Path.Combine(_appDirectory, "XML"),
            GameArtPath = Path.Combine(_appDirectory, "GameArt"),
            CloseOnSave = false,
            HideDatabase = false,
            RememberLastDatabase = true,
            ShowGameArtOnHover = true
        };
    }

    private static string GetDefaultDosBoxPath()
    {
        // Platform-specific default paths
        if (OperatingSystem.IsMacOS())
        {
            return "/Applications/DOSBox.app/Contents/MacOS";
        }
        if (OperatingSystem.IsLinux())
        {
            return "/usr/bin";
        }
        return @"C:\Program Files\DOSBox";
    }

    private static string GetDefaultScummVMPath()
    {
        // Platform-specific default paths
        if (OperatingSystem.IsMacOS())
        {
            return "/Applications/ScummVM.app/Contents/MacOS";
        }
        if (OperatingSystem.IsLinux())
        {
            return "/usr/bin";
        }
        return @"C:\Program Files\ScummVM";
    }

    private static string GetElementValue(XElement parent, string name, string defaultValue = "")
    {
        return parent.Element(name)?.Value ?? defaultValue;
    }

    private static bool GetElementBool(XElement parent, string name, bool defaultValue = false)
    {
        var value = parent.Element(name)?.Value;
        if (string.IsNullOrEmpty(value)) return defaultValue;
        return value.Equals("True", StringComparison.OrdinalIgnoreCase) || value == "1";
    }
}
