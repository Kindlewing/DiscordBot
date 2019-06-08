using Discord;
using System.Collections.Generic;
using System.Linq;

namespace DiscordLibrary
{
	public class UserAccountManager
	{
		private readonly UserAccountDataStorage _storage;
		private readonly List<UserAccount> _accounts;
		private readonly string _accountsFilePath = "Resources/UserAccounts.json";
		public UserAccountManager(UserAccountDataStorage storage)
		{
			_storage = storage;

			if (storage.SaveExists(_accountsFilePath))
			{
				_accounts = _storage.LoadUserAccounts(_accountsFilePath).ToList();
			}
			else
			{
				_accounts = new List<UserAccount>();
				SaveAccounts();
			}
		}


		public void SaveAccounts()
		{
			_storage.SaveAccounts(_accounts, _accountsFilePath);
		}

		public UserAccount GetAccount(IGuildUser user)
		{
			return GetOrCreateAccount(user);
		}

		private UserAccount GetOrCreateAccount(IGuildUser user)
		{
			var result = from a in _accounts
						 where a.ID == user.Id
						 select a;
			var account = result.FirstOrDefault();
			if (account == null) { account = CreateUserAccount(user); }
			return account;

		}

		private UserAccount CreateUserAccount(IGuildUser user)
		{
			UserAccount account = new UserAccount()
			{
				Username = user.Username,
				ID = user.Id,
				DateAccountCreated = user.CreatedAt,
				Status = UserAccount.BanStatus.Unbanned
			};

			_accounts.Add(account);
			SaveAccounts();
			return account;
		}
	}
}
