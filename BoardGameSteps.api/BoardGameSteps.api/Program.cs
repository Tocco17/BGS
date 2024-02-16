using Asp.Versioning;

using BoardGameSteps.entities.Contexts;

using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using System;
using System.Diagnostics;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var okDoms = new List<string> { "localhost", "vmdocker1" };
builder.Services.AddCors(opt =>
{
	opt.AddDefaultPolicy(policy =>
		policy.SetIsOriginAllowed(origin => okDoms.Contains(new Uri(origin).Host))
			.AllowAnyHeader()
			.AllowAnyMethod());
});

builder.Services.AddControllers()
	.AddJsonOptions(opt =>
	{
		opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
		opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
	});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BgsDbContext>(options => 
	options.UseSqlite(
		builder.Configuration.GetConnectionString("DefaultConnection"),
		x => x.MigrationsAssembly("BoardGameSteps.migrations")
	)
);


builder.Services.AddApiVersioning(opt =>
{
	opt.DefaultApiVersion = new ApiVersion(1, 0);
	opt.AssumeDefaultVersionWhenUnspecified = true;
	opt.ReportApiVersions = true;
	opt.ApiVersionReader = ApiVersionReader.Combine(
		new UrlSegmentApiVersionReader(),
		new HeaderApiVersionReader("x-api-version"),
		new MediaTypeApiVersionReader("x-api-version")
	);
});

builder.Services.AddHttpLogging(logging =>
{
	logging.LoggingFields =
		//HttpLoggingFields.RequestHeaders | 
		HttpLoggingFields.RequestMethod |
		HttpLoggingFields.RequestPath |
		HttpLoggingFields.RequestBody |
		HttpLoggingFields.ResponseBody |
		HttpLoggingFields.ResponseStatusCode;
	logging.RequestBodyLogLimit = 512;
	logging.ResponseBodyLogLimit = 512;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
