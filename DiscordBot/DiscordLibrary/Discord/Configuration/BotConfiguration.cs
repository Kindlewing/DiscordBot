using Discord.WebSocket;

namespace DiscordLibrary
{
	public class BotConfiguration
	{
		public string Token { get; set; }
		public string CommandPrefix { get; set; }
		public string GuildID { get; set; }
		public DiscordSocketConfig SocketConfig { get; set; }

	}
}