using System;

namespace DiscordLibrary
{ 
	public class UserAccount
	{
		public string Username { get; set; }
		public ulong ID { get; set; }
		public DateTimeOffset DateAccountCreated { get; set; }

		public enum BanStatus { Banned, Unbanned };
		public BanStatus Status { get; set; }
		public bool IsBanned()
		{
			if (Status == BanStatus.Banned) { return true; }
			return false;
		}
	}
}
