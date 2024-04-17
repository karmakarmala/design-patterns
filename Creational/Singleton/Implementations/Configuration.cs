namespace Singleton;

public sealed class Configuration
{
    private static readonly Lazy<Configuration> LazyConfig =
        new Lazy<Configuration>(() => new Configuration());
    
    public static Configuration Instance=> LazyConfig.Value;
    private readonly Dictionary<string, string?> _settings;

    private Configuration()
    {
        // Load configuration data from a file or a database here
        _settings = new Dictionary<string, string?>
        {
            // For example, let's assume we have a setting named "Setting1"
            ["Setting1"] = "Value1"
        };
    }
    public string? GetSetting(string key)
    {
        return _settings.GetValueOrDefault(key);
    }
}