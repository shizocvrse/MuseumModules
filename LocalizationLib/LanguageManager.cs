using System.Globalization;
using System.Resources;
using System.Threading;

namespace LocalizationLib
{
    public class LanguageManager
    {
        private readonly ResourceManager _resourceManager;

        public LanguageManager(ResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public void SetCulture(string cultureName)
        {
            var culture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        public string GetString(string key)
        {
            return _resourceManager.GetString(key) ?? $"[{key}]";
        }
    }
}