using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using SierraLauncher.Models;

namespace SierraLauncher.Services;

/// <summary>
/// Service for launching games via DOSBox, ScummVM, or custom executables.
/// </summary>
public class GameLauncherService
{
    private readonly ConfigurationService _configService;

    public GameLauncherService(ConfigurationService configService)
    {
        _configService = configService;
    }

    /// <summary>
    /// Launches a game based on its configuration.
    /// </summary>
    public bool LaunchGame(GameInfo game, GameDatabase database)
    {
        try
        {
            var (fileName, arguments, workingDir) = BuildLaunchCommand(game, database);

            if (string.IsNullOrEmpty(fileName))
            {
                Console.WriteLine("No executable specified for game launch");
                return false;
            }

            var startInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                WorkingDirectory = workingDir,
                UseShellExecute = true
            };

            Process.Start(startInfo);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error launching game: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// Opens a manual or document file.
    /// </summary>
    public bool OpenManual(string manualPath)
    {
        if (string.IsNullOrEmpty(manualPath) || !File.Exists(manualPath))
        {
            Console.WriteLine($"Manual not found: {manualPath}");
            return false;
        }

        try
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = manualPath,
                UseShellExecute = true
            };

            Process.Start(startInfo);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error opening manual: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// Opens a shortcut file (.lnk on Windows, alias on Mac).
    /// </summary>
    public bool OpenShortcut(string shortcutPath)
    {
        try
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = shortcutPath,
                UseShellExecute = true
            };

            Process.Start(startInfo);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error opening shortcut: {ex.Message}");
            return false;
        }
    }

    private (string fileName, string arguments, string workingDir) BuildLaunchCommand(GameInfo game, GameDatabase database)
    {
        var config = _configService.Configuration;
        var gamePath = game.Path;
        var gameExe = game.Executable;
        var gameCmd = game.CommandLine;

        // Handle shortcuts (.lnk files)
        if (gamePath.EndsWith(".lnk", StringComparison.OrdinalIgnoreCase))
        {
            return (gamePath, string.Empty, string.Empty);
        }

        // Normalize path (remove or add trailing separator)
        if (!string.IsNullOrEmpty(gamePath))
        {
            gamePath = gamePath.TrimEnd(Path.DirectorySeparatorChar, '\\', '/');
        }

        string fileName;
        string arguments;
        string workingDir = gamePath;

        switch (game.Program.ToLowerInvariant())
        {
            case "dosbox":
                (fileName, arguments) = BuildDosBoxCommand(config, gamePath, gameExe, gameCmd);
                break;

            case "scummvm":
                (fileName, arguments) = BuildScummVMCommand(config, gamePath, gameExe, gameCmd);
                break;

            case "":
                // Custom/direct executable
                fileName = Path.Combine(gamePath, gameExe);
                arguments = gameCmd;
                break;

            default:
                // Other program specified
                fileName = game.Program;
                arguments = $"{gamePath} {gameExe} {gameCmd}".Trim();
                break;
        }

        return (fileName, arguments, workingDir);
    }

    private (string fileName, string arguments) BuildDosBoxCommand(
        AppConfiguration config, string gamePath, string gameExe, string gameCmd)
    {
        var dosBoxPath = config.DosBoxPath.TrimEnd(Path.DirectorySeparatorChar, '\\', '/');
        string fileName;

        // Platform-specific DOSBox executable
        if (OperatingSystem.IsMacOS())
        {
            // Check if it's an app bundle
            if (dosBoxPath.EndsWith(".app", StringComparison.OrdinalIgnoreCase))
            {
                fileName = Path.Combine(dosBoxPath, "Contents", "MacOS", "DOSBox");
            }
            else
            {
                fileName = Path.Combine(dosBoxPath, "dosbox");
            }
        }
        else if (OperatingSystem.IsLinux())
        {
            fileName = Path.Combine(dosBoxPath, "dosbox");
        }
        else
        {
            fileName = Path.Combine(dosBoxPath, "dosbox.exe");
        }

        // Build DOSBox command line arguments
        var args = string.Empty;

        if (!string.IsNullOrEmpty(gamePath))
        {
            // Mount the game path as C:
            args = $"-c \"mount C '{gamePath}'\" -c \"C:\"";
        }

        if (!string.IsNullOrEmpty(gameExe))
        {
            args += $" -c \"{gameExe}\"";
        }

        if (!string.IsNullOrEmpty(gameCmd))
        {
            args += $" {gameCmd}";
        }

        return (fileName, args);
    }

    private (string fileName, string arguments) BuildScummVMCommand(
        AppConfiguration config, string gamePath, string gameExe, string gameCmd)
    {
        var scummVMPath = config.ScummVMPath.TrimEnd(Path.DirectorySeparatorChar, '\\', '/');
        string fileName;

        // Platform-specific ScummVM executable
        if (OperatingSystem.IsMacOS())
        {
            if (scummVMPath.EndsWith(".app", StringComparison.OrdinalIgnoreCase))
            {
                fileName = Path.Combine(scummVMPath, "Contents", "MacOS", "scummvm");
            }
            else
            {
                fileName = Path.Combine(scummVMPath, "scummvm");
            }
        }
        else if (OperatingSystem.IsLinux())
        {
            fileName = Path.Combine(scummVMPath, "scummvm");
        }
        else
        {
            fileName = Path.Combine(scummVMPath, "scummvm.exe");
        }

        // Build ScummVM command line arguments
        string args;

        // If command already contains -p (path flag), use it directly
        if (gameCmd.Contains("-p", StringComparison.OrdinalIgnoreCase))
        {
            args = gameCmd;
        }
        else
        {
            args = $"-p \"{gamePath}\" {gameExe} {gameCmd}".Trim();
        }

        return (fileName, args);
    }
}
