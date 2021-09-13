using HaloCard.Contracts.v1;
using HaloCard.Contracts.v1.Interfaces;
using HaloCard.Contracts.v1.Models;
using HaloCard.Service.v1.Implementations;
using HaloCard.Tests.Shared;
using Moq;
using NUnit.Framework;
using System;

namespace HaloCard.Tests.Unit.v1.Implementations
{
	[TestFixture]
	[Category(Constants.Tests.Unit)]
	public class HaloCardGeneratorServiceUnitTests
	{
		private Mock<IRestService> _mockRestService;
		private Mock<IStatService> _mockStatService;
		private IHaloCardGeneratorService _sut;

		[SetUp]
		public void SetUp()
		{
			_mockRestService = SharedMocks.GetMockRestService(true);
			_mockStatService = SharedMocks.GetMockStatService(true);
			_sut = new HaloCardGeneratorService();
		}

		[TearDown]
		public void TearDown()
		{
			_mockRestService = null;
			_mockStatService = null;
			_sut = null;
		}

		[TestCase("SageOfChaos")]
		public void GetHaloCardFromStats_GoldenFlow(string gamerTag)
		{
			// Arrange
			HaloCardResponse haloCardResponse = _mockStatService.Object.GetHaloCardForGamerTagAsync(gamerTag).ConfigureAwait(true).GetAwaiter().GetResult();

			// Act
			HaloCardModel result = _sut.GetHaloCardFromStatsAsync(haloCardResponse).ConfigureAwait(true).GetAwaiter().GetResult();

			// Assert
			Assert.IsTrue(result.CardLevel != CardLevel.NotRated);
			Assert.IsTrue(result.GamerTag.Equals(gamerTag, StringComparison.OrdinalIgnoreCase));
		}

		[TestCase("-_FakeStuff_-")]
		public void GetHaloCardFromStats_InvalidArgument(string gamerTag)
		{
			// Arrange
			HaloCardResponse haloCardResponse = _mockStatService.Object.GetHaloCardForGamerTagAsync(gamerTag).ConfigureAwait(true).GetAwaiter().GetResult();

			// Act
			HaloCardModel result = _sut.GetHaloCardFromStatsAsync(haloCardResponse).ConfigureAwait(true).GetAwaiter().GetResult();

			// Assert
			Assert.IsTrue(result.CardLevel == CardLevel.NotRated);
			Assert.IsTrue(string.IsNullOrWhiteSpace(result.GamerTag));
		}
	}
}
