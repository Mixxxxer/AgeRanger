using System.Configuration;

namespace AgeRanger.Api.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        public string ApiKey => "A61D4BE4-F84C-4A24-9676-26B35DC479F7";

        public bool RequiresApiKey
        {
            get
            {
                bool requiresKey;
                var setting = ConfigurationManager.AppSettings["RequiresApiKey"];

                var result = bool.TryParse(setting, out requiresKey);
                if (result)
                {
                    return requiresKey;
                }
                return true;
            }
        }
    }
}