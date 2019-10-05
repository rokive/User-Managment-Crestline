using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
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
            var builder = new DbContextOptionsBuilder<UMDbContext>();
            builder.UseSqlServer(Constants.connection_string_name,b=>b.MigrationsAssembly("UserManagement"));
            return new UMDbContext(builder.Options);
        }
        
    }
}
