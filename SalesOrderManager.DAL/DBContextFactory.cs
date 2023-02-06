using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderManager.DAL
{
    internal class DBContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {

        public AppDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<AppDbContext> dbContextOptionsBuilder =
                new();
            //dbContextOptionsBuilder.UseSqlServer(@"Server=.;Database=SalesOrderManagerNew;Trusted_Connection=True;MultipleActiveResultSets=true;");
            return new AppDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
