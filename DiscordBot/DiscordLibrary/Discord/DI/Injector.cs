using Discord.Commands;
using Discord.WebSocket;
using DiscordBot;
using DiscordLibrary.Logging;
using DiscordLibrary.Storage;
using System;
using System.Timers;
using Unity;
using Unity.Injection;

namespace DiscordLibrary
{ 
	 public static class Injector
	{
	    private static UnityContainer _container;

		public static UnityContainer Container
		{
			get
			{
				if (_container == null)
					RegisterTypes();
				return _container;
			}
		}


		public static void RegisterTypes()
		{
			_container = new UnityContainer();

			_container.RegisterSingleton<Connection>();
			_container.RegisterSingleton<DiscordSocketClient>
					(new InjectionConstructor(typeof(DiscordSocketConfig)));

			_container.RegisterSingleton<IDataStorage, JsonStorage>();
			_container.RegisterSingleton<ILogger, Logger>();
			_container.RegisterSingleton<CommandHandler>();
			_container.RegisterSingleton<DiscordEventHandler>();
			_container.RegisterSingleton<CommandService>();
			_container.RegisterSingleton<UserAccountDataStorage>();
			_container.RegisterSingleton<UserAccountManager>
				(new InjectionConstructor(typeof(UserAccountDataStorage)));
			_container.RegisterSingleton<TimedEventHandler>();

			_container.RegisterFactory<Timer>
				(i => TimerProvider.GetDefault());

			_container.RegisterFactory<IServiceProvider>
				(i => BotServiceProvider.GetServiceProvider());

			_container.RegisterFactory<DiscordSocketConfig>
				(i => SocketConfig.GetDefault());

			_container.RegisterFactory<BotConfiguration>
				(i => BotConfig.GetDefault());
		}

		public static T Resolve<T>()
		{
			return (T)Container.Resolve(typeof(T));
		}
	}
}