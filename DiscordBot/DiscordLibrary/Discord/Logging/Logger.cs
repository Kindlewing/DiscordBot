using DiscordLibrary.Logging;

namespace DiscordLibrary
{
	public class Logger : ILogger
	{
		public void Log(string message)
		{
			System.Console.WriteLine(message);
		}
	}
}