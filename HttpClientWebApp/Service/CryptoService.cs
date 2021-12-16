using HttpClientWebApp.Interface;
using HttpClientWebApp.Models;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HttpClientWebApp.Service
{
    public class CryptoService : ICryptoService
    {
        public async Task<CryptoModel> GetData<T>()
        {
            CryptoModel crypto = new CryptoModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.publicapis.org/entries");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                if (response.IsSuccessStatusCode)
                {
                    crypto = await response.Content.ReadFromJsonAsync<CryptoModel>().ConfigureAwait(false);
                    Console.WriteLine(crypto);
                }
                else
                {
                    Debug.WriteLine("Failure");
                }
            }
            return crypto;
        }
    }
}
