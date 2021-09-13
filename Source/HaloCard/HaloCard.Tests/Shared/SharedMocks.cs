using HaloCard.Contracts.v1.Interfaces;
using HaloCard.Contracts.v1.Models;
using Moq;
using System.Net.Http;

namespace HaloCard.Tests.Shared
{
	public class SharedMocks
	{
		public static Mock<IRestService> GetMockRestService(bool returnValid)
		{
			Mock<IRestService> mockService = new Mock<IRestService>();

			mockService.Setup(x => x.GetHttpClientAsync(It.IsAny<string>()))
				.ReturnsAsync(It.IsAny<HttpClient>());

			mockService.Setup(x => x.GetAsync(It.IsAny<HttpClient>(), It.IsAny<string>()))
				.ReturnsAsync(GetHttpResponseMessage(returnValid));

			mockService.Setup(x => x.PostAsync(It.IsAny<HttpClient>(), It.IsAny<string>(), It.IsAny<string>()))
				.ReturnsAsync(GetHttpResponseMessage(returnValid));

			return mockService;
		}

		public static Mock<IStatService> GetMockStatService(bool returnValid)
		{
			Mock<IStatService> mockService = new Mock<IStatService>();

			mockService.Setup(x => x.GetHaloCardForGamerTagAsync(It.IsAny<string>()))
				.ReturnsAsync(GetHaloCardResponse(returnValid));

			return mockService;
		}

		public static Mock<IHaloCardGeneratorService> GetMockHaloCardGeneratorService(HaloCardResponse haloCardResponse, bool returnValid)
		{
			Mock<IHaloCardGeneratorService> mockService = new Mock<IHaloCardGeneratorService>();

			if (returnValid)
			{
				mockService.Setup(x => x.GetHaloCardFromStatsAsync(haloCardResponse))
					.ReturnsAsync(GetHaloCardModel(haloCardResponse, true));
			}

			return mockService;
		}

		public static HttpResponseMessage GetHttpResponseMessage(bool returnValid)
		{
			HttpResponseMessage httpResponseMessage = new HttpResponseMessage();

			if (returnValid)
			{
				httpResponseMessage = new HttpResponseMessage()
				{
					StatusCode = System.Net.HttpStatusCode.OK,
					Content = new StringContent(string.Empty)
				};
			}

			return httpResponseMessage;
		}

		public static HaloCardResponse GetHaloCardResponse(bool returnValid)
		{
			HaloCardResponse haloCardResponse = new HaloCardResponse();

			if (returnValid)
			{
				haloCardResponse = new HaloCardResponse()
				{
					GamerTag = "SageOfChaos",
					ClanTag = "CLAN",
					Emblem = "Sweet emblem",
					GamesPlayed = 100,
					Wins = 75,
					Losses = 25,
					WinRatio = 0.75f,
					Kills = 100,
					Deaths = 10,
					KillDeathRatio = 10.0f,
					KillsPerGame = 1.0f,
					DeathsPerGame = 0.1f,
					Last20 = new int[] { 1, -1, 1 },
					Streak = "1 win",
				};
			}

			return haloCardResponse;
		}

		public static HaloCardModel GetHaloCardModel(HaloCardResponse haloCardResponse, bool returnValid)
		{
			HaloCardModel haloCardModel = new HaloCardModel();

			if (returnValid)
			{
				haloCardModel = new HaloCardModel(haloCardResponse);
			}

			return haloCardModel;
		}
	}
}
