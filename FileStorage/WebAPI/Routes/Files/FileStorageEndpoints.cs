using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebAPI.Routes.Files;

public static class FileStorageEndpoints
{
	public static void AddFileStorageEndpointsServices(this IServiceCollection services)
	{

	}

	public static void MapFileStorageEndpoints(this WebApplication app)
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

		group.MapGet("/status/{id:Guid}", (Guid id) =>
		{

		})
	   .WithSummary("Check upload status of file or group of files");

		group.MapPost("/share/{id:Guid}", (Guid id) =>
		{

		})
		.WithSummary("Create link for share file or group of files");

		group.MapGet("/download", (Guid code) =>
		{

		})
		.WithSummary("Download file or group of files by shared link");

		group.WithOpenApi();
	}
}
