using HaloCard.Contracts.v1.Interfaces;
using HaloCard.Contracts.v1.Models;
using System.Threading.Tasks;

namespace HaloCard.Service.v1.Implementations
{
	public class HaloCardGeneratorService : IHaloCardGeneratorService
	{
		private IStatService _statService;

		public HaloCardGeneratorService(IStatService statService)
		{
			_statService = statService;
		}

		public async Task<HaloCardModel> GetHaloCardFromStatsAsync(string gamerTag)
		{
			HaloCardResponse haloCardResponse = await _statService.GetHaloCardForGamerTagAsync(gamerTag);

			HaloCardModel haloCardModel = await GetHaloCardFromStatsAsync(haloCardResponse);

			return haloCardModel;
		}

		public async Task<HaloCardModel> GetHaloCardFromStatsAsync(HaloCardResponse haloCardResponse)
		{
			HaloCardModel haloCardModel = new HaloCardModel(haloCardResponse);

			haloCardModel.CardLevel = GetCardLevelCalculated(haloCardModel);

			await Task.Yield();

			return haloCardModel;
		}

		private CardLevel GetCardLevelCalculated(HaloCardModel haloCardModel)
		{
			CardLevel cardLevel = CardLevel.NotRated;

			if (haloCardModel.WinRatio >= 0.70f)
			{
				cardLevel = CardLevel.Gold;
			}
			else if (haloCardModel.WinRatio >= 0.40f)
			{
				cardLevel = CardLevel.Silver;
			}
			else if (haloCardModel.WinRatio > 0.00f)
			{
				cardLevel = CardLevel.Bronze;
			}

			return cardLevel;
		}
	}
}
