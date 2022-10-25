﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Core.Utilities.Responses;
using Entities.Dtos.AppUser;
using WebAPIWithCoreMvc.ApiServices.Interfaces;

namespace WebAPIWithCoreMvc.ApiServices
{
    public class AppUserApiService : IAppUserApiService
    {
        private readonly IHttpClientService _httpClientService;

        public AppUserApiService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<ApiDataResponse<AppUserDto>> AddAsync(AppUserAddDto  appUserAddDto)
        {
            return await _httpClientService.PostAsync("AppUsers/Add", appUserAddDto, new AppUserDto());
        }

        public async Task<ApiDataResponse<List<AppUserDto>>> GetListAsync()
        {
            return await _httpClientService.GetListAsync<AppUserDto>("AppUsers/GetList");
        }

        public async Task<ApiDataResponse<List<AppUserDto>>> GetListDetailAsync()
        {
            return await _httpClientService.GetListAsync<AppUserDto>("AppUsers/GetListDetail");
        }
    }
}
