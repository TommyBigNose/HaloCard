using HaloCard.Contracts.v1.Interfaces;
using HaloCard.Contracts.v1.Models;
using HaloCard.Service.v1.Implementations;
using NUnit.Framework;
using System;

namespace HaloCard.Tests.v1.Implementations
{
	[TestFixture]
	public class HaloCardGeneratorServiceFunctionalTests
	{
		private IRestService _restService;
		private StatService _statService;
		private IHaloCardGeneratorService _sut;

		[SetUp]
		public void SetUp()
		{
			_restService = new RestService();
			_statService = new StatService(_restService);
			_sut = new HaloCardGeneratorService();
		}

		[TearDown]
		public void TearDown()
		{
			_restService = null;
			_statService.Dispose();
			_sut = null;
		}

		[TestCase("SageOfChaos")]
		public void GetHaloCardFromStats_GoldenFlow(string gamerTag)
		{
			// Arrange
			HaloCardResponse haloCardResponse = _statService.GetHaloCardForGamerTagAsync(gamerTag).ConfigureAwait(true).GetAwaiter().GetResult();

			// Act
			HaloCardModel result = _sut.GetHaloCardFromStats(haloCardResponse).ConfigureAwait(true).GetAwaiter().GetResult();

			// Assert
			Assert.IsTrue(result.CardLevel != CardLevel.NotRated);
			Assert.IsTrue(result.GamerTag.Equals(gamerTag, StringComparison.OrdinalIgnoreCase));
		}
	}
}
