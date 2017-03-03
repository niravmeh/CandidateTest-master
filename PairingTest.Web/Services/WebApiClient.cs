﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;

namespace PairingTest.Web.Services
{
    public class WebApiClient : IGetApiClient, IPostApiClient
    {
        private readonly Uri _serverBaseUri;

        public WebApiClient(IServiceUriProvider serverUriProvider)
        {
            _serverBaseUri = new Uri(serverUriProvider.BaseUri);
        }

        public async Task<T> Get<T>(string requestUri)
        {
            return JsonConvert.DeserializeObject<T>(await GetAsync(requestUri));
        }

        public async Task<object> Get(string requestUri)
        {
            return JsonConvert.DeserializeObject(await GetAsync(requestUri));
        }

        public async Task<T> Post<T>(string requestUri, object data)
        {
            return JsonConvert.DeserializeObject<T>(await PostAsync(requestUri, data));
        }

        public async Task<object> Post(string requestUri, object data)
        {
            return JsonConvert.DeserializeObject(await PostAsync(requestUri, data));
        }

        private async Task<string> GetAsync(string requestUri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _serverBaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(requestUri);
                response.EnsureSuccessStatusCode(); // throw if not a success code

                return await response.Content.ReadAsStringAsync();
            }
        }

        private async Task<string> PostAsync(string requestUri, object data)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _serverBaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsJsonAsync(requestUri, data);
                response.EnsureSuccessStatusCode(); // throw if not a success code

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}