using DiscordLibrary.Storage;
using Newtonsoft.Json;
using System.IO;

namespace DiscordBot
{
	public class JsonStorage : IDataStorage
	{
		public T RetrieveObject<T>(string key)
		{
			var json = File.ReadAllText($"{key}.json");
			return JsonConvert.DeserializeObject<T>(json);
		}

		public void StoreObject(object obj, string key)
		{
			var file = $"{key}.json";
			Directory.CreateDirectory(Path.GetDirectoryName(file));
			var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
			File.WriteAllText(file, json);
		}
	}
}