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
	public class StatServiceUnitTests
	{
		private Mock<IRestService> _mockRestService;
		private IStatService _sut;

		[SetUp]
		public void SetUp()
		{
			_mockRestService = SharedMocks.GetMockRestService(true);
			_sut = new StatService(_mockRestService.Object);
		}

		[TearDown]
		public void TearDown()
		{
			_sut = null;
		}

		[TestCase("SageOfChaos")]
		public void GetHaloCardForGamerTagAsync_GoldenFlow(string gamerTag)
		{
			// Arrange
			// Act
			HaloCardResponse result = _sut.GetHaloCardForGamerTagAsync(gamerTag).ConfigureAwait(true).GetAwaiter().GetResult();

			// Assert
			Assert.IsTrue(result.GamerTag.Equals(gamerTag, StringComparison.OrdinalIgnoreCase));
		}

		[TestCase("-_FakeStuff_-")]
		public void GetHaloCardForGamerTagAsync_InvalidGamerTag(string gamerTag)
		{
			// Arrange
			// Act
			HaloCardResponse result = _sut.GetHaloCardForGamerTagAsync(gamerTag).ConfigureAwait(true).GetAwaiter().GetResult();

			// Assert
			Assert.IsTrue(string.IsNullOrWhiteSpace(result.GamerTag));
		}
	}
}
