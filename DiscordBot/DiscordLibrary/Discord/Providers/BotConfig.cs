using DiscordLibrary.Storage;
using System;


namespace DiscordLibrary
{
	public static class BotConfig
	{

		public static BotConfiguration GetDefault()
		{
			var storage = Injector.Resolve<IDataStorage>();

			return new BotConfiguration
			{
				Token = storage.RetrieveObject<string>("BotConfiguration/Token"),
				CommandPrefix = storage.RetrieveObject<string>
				("BotConfiguration/CommandPrefix"),
				GuildID = storage.RetrieveObject<string>("BotConfiguration/CurrentGuildID"),
				SocketConfig = SocketConfig.GetDefault()
			};
		}
	}
}
