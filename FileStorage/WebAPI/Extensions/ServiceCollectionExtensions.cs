using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Infrastructure;

namespace WebAPI.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddSwagger(this IServiceCollection services)
	{
		services.AddSwaggerGen();

		services.ConfigureSwaggerGen(options =>
		{
			options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme,
				new OpenApiSecurityScheme
				{
					Scheme = JwtBearerDefaults.AuthenticationScheme,
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Name = "Authorization",
					Description = "Bearer Authentication with JWT Token",
					Type = SecuritySchemeType.Http
				});
			options.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Id = JwtBearerDefaults.AuthenticationScheme,
								Type = ReferenceType.SecurityScheme
							}
						},
						new List<string>()
					}
				});
		});

		return services;
	}

	public static AuthenticationBuilder AddJwtAuthentication(
		this IServiceCollection services,
		IConfiguration configuration)
	{
		services.AddOptions<JwtOptions>()
			.Bind(configuration.GetSection(JwtOptions.SectionName))
			.ValidateDataAnnotations()
			.ValidateOnStart();

		return services
			.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{

					ValidateAudience = false,
					ValidAudience = configuration["JwtSettings:Audience"],

					ValidateIssuer = true,
					ValidIssuer = configuration["JwtSettings:Issuer"],

					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(
						Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]!)),
					
					ValidateLifetime = true,
					ClockSkew = TimeSpan.FromSeconds(5),
				};
			});
	}
}
