using Core;
using Entity;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            optionsBuilder.UseSqlServer(Constants.connection_string_name);
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
