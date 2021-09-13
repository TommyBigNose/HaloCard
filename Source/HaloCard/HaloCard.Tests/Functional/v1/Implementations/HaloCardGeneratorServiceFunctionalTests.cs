using HaloCard.Contracts.v1;
using HaloCard.Contracts.v1.Interfaces;
using HaloCard.Contracts.v1.Models;
using HaloCard.Service.v1.Implementations;
using NUnit.Framework;
using System;

namespace HaloCard.Tests.Functional.v1.Implementations
{
	[TestFixture]
	[Category(Constants.Tests.Functional)]
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
			_sut = new HaloCardGeneratorService(_statService);
		}

		[TearDown]
		public void TearDown()
		{
			_restService = null;
			_statService.Dispose();
			_sut = null;
		}

		[TestCase("SageOfChaos")]
		public void GetHaloCardFromStatsWithGamerTag_GoldenFlow(string gamerTag)
		{
			// Arrange
			// Act
			HaloCardModel result = _sut.GetHaloCardFromStatsAsync(gamerTag).ConfigureAwait(true).GetAwaiter().GetResult();

			// Assert
			Assert.IsTrue(result.CardLevel != CardLevel.NotRated);
			Assert.IsTrue(result.GamerTag.Equals(gamerTag, StringComparison.OrdinalIgnoreCase));
		}

		[TestCase("-_FakeStuff_-")]
		public void GetHaloCardFromStatsWithGamerTag_InvalidArgument(string gamerTag)
		{
			// Arrange
			// Act
			HaloCardModel result = _sut.GetHaloCardFromStatsAsync(gamerTag).ConfigureAwait(true).GetAwaiter().GetResult();

			// Assert
			Assert.IsTrue(result.CardLevel == CardLevel.NotRated);
			Assert.IsTrue(string.IsNullOrWhiteSpace(result.GamerTag));
		}

		[TestCase("SageOfChaos")]
		public void GetHaloCardFromStatsWithHaloCardResponse_GoldenFlow(string gamerTag)
		{
			// Arrange
			HaloCardResponse haloCardResponse = _statService.GetHaloCardForGamerTagAsync(gamerTag).ConfigureAwait(true).GetAwaiter().GetResult();

			// Act
			HaloCardModel result = _sut.GetHaloCardFromStatsAsync(haloCardResponse).ConfigureAwait(true).GetAwaiter().GetResult();

			// Assert
			Assert.IsTrue(result.CardLevel != CardLevel.NotRated);
			Assert.IsTrue(result.GamerTag.Equals(haloCardResponse.GamerTag, StringComparison.OrdinalIgnoreCase));
		}

		[TestCase("-_FakeStuff_-")]
		public void GetHaloCardFromStatsWithHaloCardResponse_InvalidArgument(string gamerTag)
		{
			// Arrange
			HaloCardResponse haloCardResponse = _statService.GetHaloCardForGamerTagAsync(gamerTag).ConfigureAwait(true).GetAwaiter().GetResult();

			// Act
			HaloCardModel result = _sut.GetHaloCardFromStatsAsync(haloCardResponse).ConfigureAwait(true).GetAwaiter().GetResult();

			// Assert
			Assert.IsTrue(result.CardLevel == CardLevel.NotRated);
			Assert.IsTrue(string.IsNullOrWhiteSpace(result.GamerTag));
		}
	}
}
