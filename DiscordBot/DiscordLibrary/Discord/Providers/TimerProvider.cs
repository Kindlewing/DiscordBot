using System.Timers;

namespace DiscordLibrary
{
	public static class TimerProvider
	{
		public static Timer GetDefault()
		{
			return new Timer()
			{
				Interval = ConvertToMinutes(0.5),
				AutoReset = true,
				Enabled = true
			};
		}

		private static double ConvertToMinutes(double number)
		{
			return number * 60000;
		}
	}
}
