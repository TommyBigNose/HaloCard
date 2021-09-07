using HaloCard.Contracts.v1.Interfaces;
using HaloCard.Contracts.v1.Models;
using HaloCard.Service.v1.Implementations;
using NUnit.Framework;
using System;

namespace HaloCard.Tests.v1.Implementations
{
	[TestFixture]
	public class StatServiceFunctionalTests
	{
		private IRestService _restService;
		private IStatService _sut;

		[SetUp]
		public void SetUp()
		{
			_restService = new RestService();
			_sut = new StatService(_restService);
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
