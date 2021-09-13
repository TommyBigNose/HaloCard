using System.Net.Http;
using System.Threading.Tasks;

namespace HaloCard.Contracts.v1.Interfaces
{
	/// <summary>
	/// This interface is used to simply wrap the HttpClient object.
	/// </summary>
	public interface IRestService
	{
		/// <summary>
		/// Gets a HttpClient object with a BaseUrl setup, no auth
		/// </summary>
		/// <param name="baseUrl"></param>
		/// <returns></returns>
		Task<HttpClient> GetHttpClientAsync(string baseUrl);

		/// <summary>
		/// Makes a simple GET call and returns the response
		/// </summary>
		/// <param name="httpClient"></param>
		/// <param name="endpoint"></param>
		/// <returns></returns>
		Task<HttpResponseMessage> GetAsync(HttpClient httpClient, string endpoint);

		/// <summary>
		/// Make a simple POST call and return the response
		/// </summary>
		/// <param name="httpClient"></param>
		/// <param name="endpoint"></param>
		/// <param name="jsonContent"></param>
		/// <returns></returns>
		Task<HttpResponseMessage> PostAsync(HttpClient httpClient, string endpoint, string jsonContent);
	}
}
