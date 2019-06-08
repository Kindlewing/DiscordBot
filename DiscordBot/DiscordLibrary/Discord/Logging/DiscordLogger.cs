using System;
using System.Threading.Tasks;
using Discord;

namespace DiscordLibrary
{
	public class DiscordLogger
	{
		public Task Log(LogMessage message)
		{
			Console.WriteLine(message.Message);
			return Task.CompletedTask;
		}
	}
}