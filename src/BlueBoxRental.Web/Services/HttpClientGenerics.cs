using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BlueBoxRental.Web.Services
{
    public static class HttpClientGenerics
    {
        public static async Task<T> Get<T>(string apiUrl, string apiRoute, string argRoute, CancellationToken cancellationToken = default(CancellationToken)) where T : new()
        {
            using (HttpClient client = new HttpClient(new HttpClientHandler() { CookieContainer = new CookieContainer() }, false))
            {
                client.BaseAddress = new System.Uri(apiUrl + apiRoute);
                HttpResponseMessage response = await client.GetAsync(argRoute, cancellationToken);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>(cancellationToken);
                }
                string error = await response.Content.ReadAsStringAsync();
                throw new WebException(error);
            }
        }

        public static async Task<List<T>> GetList<T>(string apiUrl,string apiRoute, CancellationToken cancellationToken = default(CancellationToken)) where T : new()
        {
            using (HttpClient client = new HttpClient(new HttpClientHandler() {CookieContainer = new CookieContainer()}, false))
            {
                client.BaseAddress = new System.Uri(apiUrl);
                HttpResponseMessage response = await client.GetAsync(apiRoute, cancellationToken);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<T>>(cancellationToken);
                }

                string error = await response.Content.ReadAsStringAsync();
                throw new WebException(error);
            }
        }
    }
}
