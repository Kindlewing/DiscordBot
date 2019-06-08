using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordLibrary.Storage
{
	public interface IDataStorage
	{
		void StoreObject(object obj, string path);
		T RetrieveObject<T>(string key);
	}
}
