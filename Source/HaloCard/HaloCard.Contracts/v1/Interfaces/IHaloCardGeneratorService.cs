using HaloCard.Contracts.v1.Models;
using System.Threading.Tasks;

namespace HaloCard.Contracts.v1.Interfaces
{
	public interface IHaloCardGeneratorService
	{
		/// <summary>
		/// Takes in the HaloCardResponse from the API and morphs it into the meat and potatoes of the app
		/// </summary>
		/// <param name="haloCardResponse"></param>
		/// <returns></returns>
		Task<HaloCardModel> GetHaloCardFromStats(HaloCardResponse haloCardResponse);
	}
}
