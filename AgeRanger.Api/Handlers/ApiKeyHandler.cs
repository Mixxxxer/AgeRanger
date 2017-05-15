using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AgeRanger.Api.Helpers;

namespace AgeRanger.Api.Handlers
{
    public class ApiKeyHandler : DelegatingHandler
    {
        private readonly IConfigHelper configHelper;

        public ApiKeyHandler()
        {
            if (configHelper == null)
                configHelper = new ConfigHelper();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (configHelper.RequiresApiKey == false)
            {
                return await base.SendAsync(request, cancellationToken);
            }

            var isValidApiKey = false;
            IEnumerable<string> lsHeaders;

            var checkApiKeyExists = request.Headers.TryGetValues("API_KEY", out lsHeaders);

            if (checkApiKeyExists)
            {
                var header = lsHeaders.FirstOrDefault();
                if (header != null && string.Equals(header, configHelper.ApiKey, StringComparison.CurrentCultureIgnoreCase))
                {
                    isValidApiKey = true;
                }
            }

            if (!isValidApiKey)
            {
                return request.CreateResponse(HttpStatusCode.Forbidden, "Invalid API Key");
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}