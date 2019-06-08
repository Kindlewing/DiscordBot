using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DiscordLibrary
{
	public class UserAccountDataStorage
	{
		public void SaveAccounts(IEnumerable<UserAccount> accounts, string filePath)
		{
			string json = JsonConvert.SerializeObject(accounts, Formatting.Indented);
			File.WriteAllText(filePath, json);
		}

		public IEnumerable<UserAccount> LoadUserAccounts(string filePath)
		{
			if (!File.Exists(filePath)) return null;
			string json = File.ReadAllText(filePath);
			return JsonConvert.DeserializeObject<List<UserAccount>>(json);
		}

		public bool SaveExists(string filePath)
		{
			return File.Exists(filePath);
		}
	}
}


