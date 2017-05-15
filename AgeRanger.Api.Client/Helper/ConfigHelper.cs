using System;
using System.Configuration;

namespace AgeRanger.Api.Client.Helper
{
    public class ConfigHelper
    {
        public static bool RequiresApiKey => Convert.ToBoolean(ConfigurationManager.AppSettings["RequiresApiKey"]);

        public static string ApiKey => ConfigurationManager.AppSettings["ApiKey"];

        public static string BasicAuth => ConfigurationManager.AppSettings["BasicAuth"];
    }
}
