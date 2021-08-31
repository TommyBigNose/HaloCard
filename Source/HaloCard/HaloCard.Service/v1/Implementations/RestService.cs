using HaloCard.Contracts.v1.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HaloCard.Service.v1.Implementations
{
	public class RestService : IRestService
	{
		public async Task<HttpClient> GetHttpClientAsync(string baseUrl)
		{
			HttpClient httpClient = new HttpClient()
			{
				BaseAddress = new Uri(baseUrl)
			};

			return await Task.FromResult(httpClient);
		}

		public async Task<HttpResponseMessage> MakeGetAsync(HttpClient httpClient, string endpoint)
		{
			HttpResponseMessage response = await httpClient.GetAsync(endpoint);

			return response;
		}

		public async Task<HttpResponseMessage> MakePostAsync(HttpClient httpClient, string endpoint, string jsonContent)
		{
			StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

			HttpResponseMessage response = await httpClient.PostAsync(endpoint, content);

			return response;
		}
	}
}
