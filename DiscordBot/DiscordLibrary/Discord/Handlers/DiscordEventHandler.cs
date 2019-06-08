using Discord.WebSocket;
using System;

namespace DiscordLibrary
{
	public class DiscordEventHandler
	{
		private readonly DiscordSocketClient _client;
		private readonly UserAccountManager _accountManager;
		private readonly BotConfiguration _botConfig;

		public DiscordEventHandler(DiscordSocketClient client,
			UserAccountManager accountManager, BotConfiguration botConfig)
		{
			_client = client;
			_accountManager = accountManager;
			_botConfig = botConfig;

		}

		public void InitializeEvents()
		{

		}
	}
}