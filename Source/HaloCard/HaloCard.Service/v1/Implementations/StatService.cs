using HaloCard.Contracts.v1.Interfaces;
using HaloCard.Contracts.v1.Models;
using HaloCard.Contracts.v1;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace HaloCard.Service.v1.Implementations
{
	public class StatService : IStatService
	{
		private IRestService _restService;
		private string _baseUrl;
		private HttpClient _httpClient;
		private HttpClient httpClient
		{
			get
			{
				if(_httpClient == null)
				{
					_httpClient = _restService.GetHttpClientAsync(_baseUrl).Result;
					return _httpClient;
				}
				else
				{
					return _httpClient;
				}
			}
			set
			{
				_httpClient = value;
			}
		}

		public StatService(IRestService restService, string baseUrl = Constants.Urls.HaloApiBaseUrl)
		{
			_restService = restService;
			_baseUrl = baseUrl;
		}

		public async Task<HaloCardResponse> GetHaloCardForGamerTagAsync(string gamerTag)
		{
			try
			{
				HaloCardResponse haloCardResponse = new HaloCardResponse();

				HaloCardRequest haloCardRequest = new HaloCardRequest()
				{
					GamerTag = gamerTag
				};

				string jsonContent = JsonSerializer.Serialize(haloCardRequest);

				HttpResponseMessage response = await _restService.MakePostAsync(httpClient, "", jsonContent);

				string responseString = await response.Content.ReadAsStringAsync();
				haloCardResponse = JsonSerializer.Deserialize<HaloCardResponse>(responseString);

				return haloCardResponse;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}
			
		}
	}
}
