using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlazorWYDDB23.Shared;
using Microsoft.IdentityModel.Tokens;

namespace BlazorWYDDB23.Server.Authentication
{
	public class JwtAuthenticationManager
	{
		public const string JWT_SECURITY_KEY = "JiQWRtaW4iLSb2xlIjoCJJc3N1ZXIisalesianosOiJeyJc3N1ZXIiLCJVc2VybmFtZSI6Ikphd";
		private const int JWT_TOKEN_VALIDITY_MINS = 20;

		public UserAccountService _userAccountService;

		public JwtAuthenticationManager(UserAccountService userAccountService)
		{
			_userAccountService = userAccountService;
		}

		public UserSession? GenerateJwtToken(string userName, string password)
		{
			if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
				return null;

			// Validating the USer Credentials
			var userAccount = _userAccountService.GetUserAccountbyUserName(userName);
            if (userAccount == null || userAccount.Password != password)
                return null;

			// Generating JWT Token
			var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
			var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
			var claimsIdentity = new ClaimsIdentity(new List<Claim>
				{
					new Claim(ClaimTypes.Name, userAccount.UserName),
					new Claim(ClaimTypes.Role, userAccount.Role)
                });
			var signingCredentials = new SigningCredentials(
				new SymmetricSecurityKey(tokenKey),
				SecurityAlgorithms.HmacSha256Signature);

			var securityTokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = claimsIdentity,
				Expires = tokenExpiryTimeStamp,
				SigningCredentials = signingCredentials
			};

			var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
			var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
			var token = jwtSecurityTokenHandler.WriteToken(securityToken);

			// Returning the User Session object
			var userSession = new UserSession
			{
				UserName = userAccount.UserName,
				Role = userAccount.Role,
				Token = token,
				ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds
			};

			return userSession;
        }
	}
}

