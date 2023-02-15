using System;
namespace BlazorWYDDB23.Server.Authentication
{
	public class UserAccountService
	{
		private List<UserAccount> _userAccountList;

		public UserAccountService()
		{
			_userAccountList = new List<UserAccount>
			{
				new UserAccount{ UserName = "admin", Password = "admin", Role = "Administrator"}
            };
		}

		public UserAccount? GetUserAccountbyUserName(string userName)
		{
			return _userAccountList.FirstOrDefault(a => a.UserName == userName);
		}
	}
}

