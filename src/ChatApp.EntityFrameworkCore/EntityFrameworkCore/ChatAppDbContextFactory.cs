using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ChatApp.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class ChatAppDbContextFactory : IDesignTimeDbContextFactory<ChatAppDbContext>
{
    public ChatAppDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        ChatAppEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<ChatAppDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new ChatAppDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ChatApp.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
