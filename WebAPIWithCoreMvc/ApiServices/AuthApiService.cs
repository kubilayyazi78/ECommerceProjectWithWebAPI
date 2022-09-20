using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Core.Utilities.Responses;
using Core.Utilities.Security.Token;
using Entities.Dtos.AppUser;
using Entities.Dtos.Auth;
using Newtonsoft.Json;
using WebAPIWithCoreMvc.ApiServices.Interfaces;

namespace WebAPIWithCoreMvc.ApiServices
{
    public class AuthApiService : IAuthApiService
    {
        private readonly IHttpClientService _httpClientService;

        public AuthApiService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ApiDataResponse<AccessToken>> LoginAsync(LoginDto loginDto)
        {
            return await _httpClientService.LoginAsync(loginDto);
        }
    }
}
