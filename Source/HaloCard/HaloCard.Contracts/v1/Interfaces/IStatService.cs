using HaloCard.Contracts.v1.Models;
using System.Threading.Tasks;

namespace HaloCard.Contracts.v1.Interfaces
{
	public interface IStatService
	{
		/// <summary>
		/// Returns the HaloCardResponse for a given GamerTag
		/// </summary>
		/// <param name="gamerTag"></param>
		/// <returns></returns>
		Task<HaloCardResponse> GetHaloCardForGamerTagAsync(string gamerTag);
	}
}
