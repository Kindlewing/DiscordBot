using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DiscordLibrary
{
	public static class BotServiceProvider
	{
		public static IServiceProvider GetServiceProvider()
		{
			IServiceCollection services = new ServiceCollection()
				.AddSingleton(Injector.Resolve<DiscordSocketClient>())
				.AddSingleton(Injector.Resolve<UserAccountManager>())
				.AddSingleton(Injector.Resolve<BotConfiguration>());



			return services.BuildServiceProvider();



		}

	}
}
