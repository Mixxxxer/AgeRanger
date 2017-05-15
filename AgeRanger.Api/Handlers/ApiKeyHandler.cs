using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AgeRanger.Api.Handlers
{
    public class ApiKeyHandler : DelegatingHandler
    {
        private readonly Guid apiKey;

        public ApiKeyHandler()
        {
            apiKey = Guid.Parse("A61D4BE4-F84C-4A24-9676-26B35DC479F7");
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var isValidApiKey = false;
            IEnumerable<string> lsHeaders;

            var checkApiKeyExists = request.Headers.TryGetValues("API_KEY", out lsHeaders);

            if (checkApiKeyExists)
            {
                var header = lsHeaders.FirstOrDefault();
                if (header != null && string.Equals(header, apiKey.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    isValidApiKey = true;
                }
            }

            if (!isValidApiKey)
                return request.CreateResponse(HttpStatusCode.Forbidden, "Bad API Key");

            var response = await base.SendAsync(request, cancellationToken);

            return response;
        }
    }
}