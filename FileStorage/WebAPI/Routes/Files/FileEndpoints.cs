using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebAPI.Routes.Files;

public static class FileEndpoints
{
	public static void AddFileEndpointsServices(this IServiceCollection services)
	{

	}

	public static void MapFileEndpoints(this WebApplication app)
	{
		var group = app.MapGroup("/files").WithTags("Files");

		group.MapGet("/", () =>
		{

		})
		.WithSummary("Show uploaded files and group of files");

		group.MapGet("/{id:Guid}", (Guid id) =>
		{

		})
		.WithSummary("Download file or group of files");

		group.MapPost("/upload", (IFormFileCollection files) =>
		{

		})
		.WithSummary("Upload file or group of files");

		group.MapGet("/upload/{id:Guid}", (Guid id) =>
		{

		})
	   .WithSummary("Check upload status of file or group of files");

		group.WithOpenApi();
	}
}
