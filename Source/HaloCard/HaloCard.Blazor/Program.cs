using HaloCard.Contracts.v1.Interfaces;
using HaloCard.Service.v1.Implementations;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HaloCard.Blazor
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
			builder.Services.AddSingleton<IRestService, RestService>();
			builder.Services.AddSingleton<IStatService, StatService>();
			builder.Services.AddSingleton<IHaloCardGeneratorService, HaloCardGeneratorService>();

			await builder.Build().RunAsync();
		}
	}
}
