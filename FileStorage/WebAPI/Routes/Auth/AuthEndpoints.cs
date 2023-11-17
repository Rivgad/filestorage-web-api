using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Services;
namespace WebAPI.Routes.Auth;

public static class AuthEndpoints
{
	public static void AddAuthEndpointsServices(this IServiceCollection services)
	{
		services.AddSingleton<ITokenService, TokenService>();
	}

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
