using Core;
using Entity;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys.DBContext
{
    public class UMDbContext : DbContext
    {
        public UMDbContext(DbContextOptions<UMDbContext> options) :
            base(options)
        {

        }

        public UMDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../UserManagement"))
           .AddJsonFile("appsettings.json")
           .Build();
            var builder = new DbContextOptionsBuilder<UMDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("UserManagementDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserInformation>()
            .HasIndex(u => u.UserName)
            .IsUnique();
        }

        public DbSet<UserInformation> UserInformations { get; set; }
    }
}
