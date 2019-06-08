using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace DiscordLibrary
{
	public class CommandHandler
	{
		private readonly CommandService _commandService;
		private readonly DiscordSocketClient _client;
		private readonly BotConfiguration _botConfig;
		private readonly IServiceProvider _botService;

		public CommandHandler(CommandService commandService,
			DiscordSocketClient client, BotConfiguration botConfig,
			IServiceProvider botService)
		{
			_commandService = commandService;
			_client = client;
			_botConfig = botConfig;
			_botService = botService;
		}

		public async Task InitializeAsync()
		{
			await _commandService.AddModulesAsync(Assembly.GetEntryAssembly(),
				services: _botService);
			_client.MessageReceived += HandleCommandAsync;
		}

		private async Task HandleCommandAsync(SocketMessage message)
		{
			var msg = message as SocketUserMessage;

			if (msg == null) { return; }

			var context = new SocketCommandContext(_client, msg);

			int argPos = 0;

			if (msg.HasStringPrefix(_botConfig.CommandPrefix, ref argPos))
			{
				var result = await _commandService.ExecuteAsync
					(context, argPos, services: null);

				if (!result.IsSuccess && result.Error
					!= CommandError.UnknownCommand)
				{
					System.Console.WriteLine(result.ErrorReason);
				}
			}
		}
	}
}