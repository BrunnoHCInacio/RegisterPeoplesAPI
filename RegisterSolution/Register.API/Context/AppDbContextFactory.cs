using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Register.API.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
	{
		public AppDbContext CreateDbContext(string[] args)
		{
			string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
			IConfiguration config = new ConfigurationBuilder()
				.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Register.API"))
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{environment}.json", optional: true)
				.AddEnvironmentVariables()
				.Build();

			// Get connection string
			var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
			var connectionString = config.GetConnectionString("DefaultConnection");
			optionsBuilder.UseMySql(connectionString);
			return new AppDbContext(optionsBuilder.Options);
		}
    }
}
