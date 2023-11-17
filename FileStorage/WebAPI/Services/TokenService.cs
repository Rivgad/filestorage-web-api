using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using WebAPI.Infrastructure;
using System.Collections.Generic;

namespace WebAPI.Services;

public interface ITokenService
{
	string CreateToken(ICollection<Claim> claims);
}

public class TokenService : ITokenService
{
	private readonly JwtOptions _options;

	public TokenService(IOptions<JwtOptions> options)
	{
		_options = options.Value;
	}

	public string CreateToken(ICollection<Claim> claims)
	{
		var jwt = new JwtSecurityToken(
			issuer: _options.Issuer,
			audience: _options.Audience,
			claims: claims,
			expires: DateTime.UtcNow.Add(TimeSpan.FromDays(30)),
			signingCredentials: new SigningCredentials(
				_options.GetSymmetricSecurityKey(),
				SecurityAlgorithms.HmacSha256));

		return new JwtSecurityTokenHandler().WriteToken(jwt);
	}
}
