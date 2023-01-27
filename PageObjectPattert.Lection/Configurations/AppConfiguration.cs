using PageObjectPattert.Lection.DriverConfiguration;
using PageObjectPattert.Lection.Utilities;

namespace PageObjectPattert.Lection.Configurations;

public static class AppConfiguration
{
    private const string BrowserKey = "browser";
    
    private const string UrlKey = "url";
    
    private const string DownloadDirKey = "download.default_directory";

    public static readonly string DownloadDir = Configurator.GetConfigurator().GetSection(DownloadDirKey).Value;
    
    public static readonly Browser Browser =
        Enum.Parse<Browser>(Configurator.GetConfigurator().GetSection(BrowserKey).Value, true);

    public static readonly string Url = Configurator.GetConfigurator().GetSection(UrlKey).Value;
}