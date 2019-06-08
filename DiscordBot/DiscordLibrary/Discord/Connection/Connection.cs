using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordLibrary
{
	public class Connection
	{
		private readonly BotConfiguration _botConfig;
		private readonly DiscordSocketClient _client;
		private readonly CommandHandler _commandHandler;
		private readonly DiscordEventHandler _eventHandler;
		private readonly DiscordLogger _logger;
		private readonly TimedEventHandler _timedEventHandler;

		public Connection(DiscordSocketClient client,
			BotConfiguration botConfig, CommandHandler commandHandler,
			DiscordEventHandler eventHandler, TimedEventHandler timedEventHandler,
			DiscordLogger logger)
		{
			_client = client;
			_botConfig = botConfig;
			_commandHandler = commandHandler;
			_eventHandler = eventHandler;
			_logger = logger;
			_timedEventHandler = timedEventHandler;
		}

		public async Task ConnectAsync()
		{
			if (_botConfig.Token == "" ||
				_botConfig.Token == null) { return; }

			_client.Log += _logger.Log;
			_client.Ready += ClientReady;
			await _client.LoginAsync(TokenType.Bot, _botConfig.Token);
			await _client.StartAsync();
			await _commandHandler.InitializeAsync();


			await Task.Delay(-1);
		}

		private Task ClientReady()
		{
			_eventHandler.InitializeEvents();
			_timedEventHandler.InitializeEvents();
			Console.WriteLine("Events initialized.");
			return Task.CompletedTask;
		}
	}
}

