using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Core.Utilities.Messages;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Exceptions;

namespace WebAPIWithCoreMvc.Handlers
{
    public class AuthTokenHandler : DelegatingHandler
    {
        private IHttpContextAccessor _httpContextAccessor;
        public AuthTokenHandler()
        {
        }
        public AuthTokenHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                string _language = _httpContextAccessor.HttpContext.User.FindFirst("language").Value;
                string _token = _httpContextAccessor.HttpContext.User.FindFirst("token").Value;
                if (!string.IsNullOrEmpty(_token))
                {
                    request.Headers.Add(Constants.AcceptLangauge, _language);
                    request.Headers.Add("Authorization", $"Bearer {_token}");
                }
            }

            var response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode==HttpStatusCode.Unauthorized)
            {
                throw new UnAuthorizedException();
            }

            return response;
        }
    }
}
