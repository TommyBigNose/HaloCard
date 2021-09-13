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
		private Mock<IStatService> _mockStatService;
		private IHaloCardGeneratorService _sut;

		[SetUp]
		public void SetUp()
		{
			_mockStatService = SharedMocks.GetMockStatService(true);
		}

		[TearDown]
		public void TearDown()
		{
			_mockStatService = null;
			_sut = null;
		}

		[TestCase("SageOfChaos")]
		public void GetHaloCardFromStatsWithGamerTag_GoldenFlow(string gamerTag)
		{
			// Arrange
			_mockStatService = SharedMocks.GetMockStatService(true);
			_sut = new HaloCardGeneratorService(_mockStatService.Object);

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
			_mockStatService = SharedMocks.GetMockStatService(false);
			_sut = new HaloCardGeneratorService(_mockStatService.Object);

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
			_sut = new HaloCardGeneratorService(_mockStatService.Object);
			HaloCardResponse haloCardResponse = SharedMocks.GetHaloCardResponse(true);

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
			_sut = new HaloCardGeneratorService(_mockStatService.Object);
			HaloCardResponse haloCardResponse = SharedMocks.GetHaloCardResponse(false);

			// Act
			HaloCardModel result = _sut.GetHaloCardFromStatsAsync(haloCardResponse).ConfigureAwait(true).GetAwaiter().GetResult();

			// Assert
			Assert.IsTrue(result.CardLevel == CardLevel.NotRated);
			Assert.IsTrue(string.IsNullOrWhiteSpace(result.GamerTag));
		}
	}
}
