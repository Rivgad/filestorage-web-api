using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebAPI.Routes.Files;

public static class FileSharingEndpoints
{
	public static void AddFileSharingEndpointsServices(this IServiceCollection services)
	{

	}

	public static void MapFileSharingEndpoints(this WebApplication app)
	{
		var group = app.MapGroup("/files").WithTags("Files sharing");

		group.MapPost("/share/{id:Guid}", (Guid id) =>
		{

		})
		.WithSummary("Create link for share file or group of files");

		group.MapGet("/download", (Guid code) =>
		{

		})
		.WithSummary("Download file or group of files by shared link");
	}
}
