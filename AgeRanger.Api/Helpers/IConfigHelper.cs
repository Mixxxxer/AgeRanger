namespace AgeRanger.Api.Helpers
{
    public interface IConfigHelper
    {
        string ApiKey { get; }

        bool RequiresApiKey { get; }
    }
}