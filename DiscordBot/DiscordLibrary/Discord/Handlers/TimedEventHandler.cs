using Discord.WebSocket;
using System;
using System.Timers;

namespace DiscordLibrary
{
	public class TimedEventHandler
	{
		private readonly Timer _timer;
		private readonly DiscordSocketClient _client;
		private readonly BotConfiguration _botConfig;
		private readonly UserAccountManager _accountManager;

		public TimedEventHandler(Timer timer, DiscordSocketClient client,
			BotConfiguration botConfig, UserAccountManager accountManager)
		{
			_timer = timer;
			_client = client;
			_botConfig = botConfig;
			_accountManager = accountManager;
		}

		public void InitializeEvents()
		{
			
		}

		
	}
}