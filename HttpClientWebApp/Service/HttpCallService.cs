using HttpClientWebApp.Interface;
using HttpClientWebApp.Models;
using Microsoft.Net.Http.Headers;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HttpClientWebApp.Service
{
    public class HttpCallService : IHttpCallService
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public HttpCallService(IHttpClientFactory httpClientFactory) =>
            _httpClientFactory = httpClientFactory;

        public async Task<T> GetData<T>()
        {
            T data = default(T);
            
            var httpRequestMessage = new HttpRequestMessage( HttpMethod.Get, "https://api.publicapis.org/entries")
            {
                Headers = { 
                    { HeaderNames.Accept, "application/json" },
                    { HeaderNames.UserAgent, "HttpRequestsSample" }
                }
            };

            var httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.SendAsync(httpRequestMessage);
            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadFromJsonAsync<T>().ConfigureAwait(false);
            }
            else
            {
                Debug.WriteLine("Failure");
            }
            return data;
        }
    }
}
