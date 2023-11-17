using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
namespace WebAPI.Routes.Auth;

public static class AuthEndpoints
{
	public static void MapAuthEndpoints(this WebApplication app)
	{
		var group = app.MapGroup("/").WithTags("Authentication");

		group.MapPost("/login", () =>
		{
		});

		group.MapGet("/register", () =>
		{
		});
	}
}
