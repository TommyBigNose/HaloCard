using HaloCard.Contracts.v1.Models;
using System.Threading.Tasks;

namespace HaloCard.Contracts.v1.Interfaces
{
	public interface IHaloCardGeneratorService
	{
		/// <summary>
		/// Takes in a gamerTag and generates a HaloCard by hitting the API
		/// </summary>
		/// <param name="gamerTag"></param>
		/// <returns></returns>
		Task<HaloCardModel> GetHaloCardFromStatsAsync(string gamerTag);

		/// <summary>
		/// Takes in the HaloCardResponse from the API and morphs it into the meat and potatoes of the app
		/// </summary>
		/// <param name="haloCardResponse"></param>
		/// <returns></returns>
		Task<HaloCardModel> GetHaloCardFromStatsAsync(HaloCardResponse haloCardResponse);
	}
}
