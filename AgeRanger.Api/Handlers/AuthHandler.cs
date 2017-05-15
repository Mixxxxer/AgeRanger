using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using AgeRanger.Api.Security;

namespace AgeRanger.Api.Handlers
{
    public class AuthHandler : DelegatingHandler
    {
        private string userName = "";

        private bool ValidateCredentials(AuthenticationHeaderValue authenticationHeaderVal)
        {
            try
            {
                if (authenticationHeaderVal != null
                    && string.IsNullOrEmpty(authenticationHeaderVal.Parameter) == false)
                {
                    var decodedCredentials = Encoding.ASCII
                        .GetString(Convert.FromBase64String(authenticationHeaderVal.Parameter))
                        .Split(new[] {':'});
            
                    if (decodedCredentials[0].Equals("username")
                        && decodedCredentials[1].Equals("password"))
                    {
                        userName = "bobjones";
                        return true;
                    }
                }

                return false;

            }
            catch
            {
                return false;
            }
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (ValidateCredentials(request.Headers.Authorization))
            {
                Thread.CurrentPrincipal = new ApiUserPrincipal(userName);
                HttpContext.Current.User = new ApiUserPrincipal(userName);
            }
            
            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized
                && !response.Headers.Contains("WwwAuthenticate"))
            {
                response.Headers.Add("WwwAuthenticate", "Basic");
            }

            return response;
        }
    }
}