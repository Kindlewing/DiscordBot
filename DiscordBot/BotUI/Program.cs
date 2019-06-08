using DiscordLibrary;
using System.Threading.Tasks;

namespace BotUI
{
	public class Program
	{
		private static async Task Main()
		{
			Connection connection = Injector.Resolve<Connection>();

			await connection.ConnectAsync();
		}
	}
}
