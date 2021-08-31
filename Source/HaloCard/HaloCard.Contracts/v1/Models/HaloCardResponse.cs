using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HaloCard.Contracts.v1.Models
{
	//Generated from https://autocode.com/lib/halo/mcc/
	public class HaloCardResponse
	{
		[JsonPropertyName("gamertag")]
		public string GamerTag { get; set; }

		[JsonPropertyName("clanTag")]
		public string ClanTag { get; set; }

		[JsonPropertyName("emblem")]
		public string Emblem { get; set; }

		[JsonPropertyName("playtime")]
		public string Playtime { get; set; }

		[JsonPropertyName("gamesPlayed")]
		public int GamesPlayed { get; set; }

		[JsonPropertyName("wins")]
		public int Wins { get; set; }

		[JsonPropertyName("losses")]
		public int Losses { get; set; }

		[JsonPropertyName("winRatio")]
		public float WinRatio { get; set; }

		[JsonPropertyName("kills")]
		public int Kills { get; set; }

		[JsonPropertyName("deaths")]
		public int Deaths { get; set; }

		[JsonPropertyName("killDeathRatio")]
		public float KillDeathRatio { get; set; }

		[JsonPropertyName("killsPerGame")]
		public float KillsPerGame { get; set; }

		[JsonPropertyName("deathsPerGame")]
		public float DeathsPerGame { get; set; }

		[JsonPropertyName("last20")]
		public int[] Last20 { get; set; }

		[JsonPropertyName("streak")]
		public string Streak { get; set; }
	}

}
