using Discord.WebSocket;

namespace DiscordLibrary
{
	public static class SocketConfig
	{
		public static DiscordSocketConfig GetDefault()
		{
			return new DiscordSocketConfig();
		}
	}
}
