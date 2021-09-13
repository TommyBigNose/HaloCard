namespace HaloCard.Contracts.v1.Models
{
	public class HaloCardModel
	{
		public HaloCardModel()
		{

		}

		/// <summary>
		/// Copies shared stats from the response model to the card model
		/// </summary>
		/// <param name="haloCardResponse"></param>
		public HaloCardModel(HaloCardResponse haloCardResponse)
		{
			this.GamerTag = haloCardResponse.GamerTag;
			this.ClanTag = haloCardResponse.ClanTag;
			this.Emblem = haloCardResponse.Emblem;
			this.GamesPlayed = haloCardResponse.GamesPlayed;
			this.Wins = haloCardResponse.Wins;
			this.Losses = haloCardResponse.Losses;
			this.WinRatio = haloCardResponse.WinRatio;
			this.Kills = haloCardResponse.Kills;
			this.Deaths = haloCardResponse.Deaths;
			this.KillDeathRatio = haloCardResponse.KillDeathRatio;
			this.KillsPerGame = haloCardResponse.KillsPerGame;
			this.DeathsPerGame = haloCardResponse.DeathsPerGame;
			this.Last20 = haloCardResponse.Last20;
			this.Streak = haloCardResponse.Streak;
		}

		// Status calculated
		public CardLevel CardLevel { get; set; }

		// Stats from HaloCardResponse
		public string GamerTag { get; set; }
		public string ClanTag { get; set; }
		public string Emblem { get; set; }
		public string Playtime { get; set; }
		public int GamesPlayed { get; set; }
		public int Wins { get; set; }
		public int Losses { get; set; }
		public float WinRatio { get; set; }
		public int Kills { get; set; }
		public int Deaths { get; set; }
		public float KillDeathRatio { get; set; }
		public float KillsPerGame { get; set; }
		public float DeathsPerGame { get; set; }
		public int[] Last20 { get; set; }
		public string Streak { get; set; }
	}

	public enum CardLevel
	{
		NotRated,
		Bronze,
		Silver,
		Gold
	}
}
