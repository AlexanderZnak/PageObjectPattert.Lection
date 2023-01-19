using PageObjectPattert.Lection.DriverConfiguration;
using PageObjectPattert.Lection.Utilities;

namespace PageObjectPattert.Lection.Configurations;

public static class AppConfiguration
{
    private const string BrowserKey = "browser";
    
    private const string UrlKey = "url";
    
    public static readonly Browser Browser =
        Enum.Parse<Browser>(Configurator.GetConfigurator().GetSection(BrowserKey).Value, true);

    public static readonly string Url = Configurator.GetConfigurator().GetSection(UrlKey).Value;
}