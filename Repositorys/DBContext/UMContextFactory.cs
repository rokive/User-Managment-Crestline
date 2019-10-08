using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Repositorys.DBContext
{
    public class UMContextFactory : IDesignTimeDbContextFactory<UMDbContext>
    {
        public UMContextFactory()
        {
        }


        public UMDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../UserManagement"))
            .AddJsonFile("appsettings.json")
            .Build();
            var builder = new DbContextOptionsBuilder<UMDbContext>();
            builder.UseSqlServer(configuration.GetConnectionString("UserManagementDB"));
            return new UMDbContext(builder.Options);
        }
        
    }
}
