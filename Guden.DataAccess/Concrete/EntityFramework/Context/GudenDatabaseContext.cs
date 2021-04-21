using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guden.Core.Entities.Concrete;
using Guden.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Guden.DataAccess.Concrete.EntityFramework.Context
{
    public class GudenDatabaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=guden.database.windows.net;Initial Catalog=guden;User ID=ugurcan;Password=Kafaca48.;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public  DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OperationClaim> Core_OperationClaims { get; set; }
        public DbSet<User> Core_Users { get; set; }
        public DbSet<UserOperationClaim> Core_UserOperationClaims { get; set; }



    }
}
