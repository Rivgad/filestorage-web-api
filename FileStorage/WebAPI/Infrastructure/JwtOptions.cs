using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAPI.Infrastructure;

public class JwtOptions
{
	public const string SectionName = "JwtSettings";

	[Required]
	public required string Issuer { get; set; }

	[Required]
	public required string Audience { get; set; }

	[Required]
	[MinLength(16)]
	public required string Key { get; set; }

	public SymmetricSecurityKey GetSymmetricSecurityKey() => new(Encoding.UTF8.GetBytes(Key));
}
