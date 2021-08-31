using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HaloCard.Contracts.v1.Models
{
	public class HaloCardRequest
	{
		[JsonPropertyName("gamertag")]
		public string GamerTag { get; set; }
	}
}
