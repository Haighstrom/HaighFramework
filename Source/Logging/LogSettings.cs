namespace HaighFramework.Logging;

/// <summary>
/// Settings to be applied to static logger <see cref="Log"/>.
/// </summary>
[Serializable]
public class LogSettings
{
    public static LogSettings Default => new();

    /// <summary>
    /// The minimum level of log messages that the Console should display.
    /// </summary>
    public LogLevel ConsoleLogLevel { get; set; } = LogLevel.Information;

    /// <summary>
    /// Settings for any file writing that should be done (one <see cref="FileWriteSettings"/> should be added for each file to be written to).
    /// </summary>
    public List<FileWriteSettings> FileLogging { get; set; } = new();
}