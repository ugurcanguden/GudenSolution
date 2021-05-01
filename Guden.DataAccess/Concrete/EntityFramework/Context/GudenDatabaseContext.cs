using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guden.Core.Entities.Concrete;
using Guden.Core.Entities.Concrete.Core;
using Guden.Entities.Concrete;
using Guden.Entities.Concrete.Core;
using Microsoft.EntityFrameworkCore;

namespace Guden.DataAccess.Concrete.EntityFramework.Context
{
    public class GudenDatabaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=guden.database.windows.net;Initial Catalog=guden;User ID=ugurcan;Password=Kafaca48.;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public DbSet<Core_User> Core_Users { get; set; }
        public DbSet<Core_OperationClaim> Core_OperationClaims { get; set; }
        public DbSet<Core_UserOperationClaim> Core_UserOperationClaims { get; set; }
        public DbSet<Core_Menus> Core_Menus { get; set; }       
        public DbSet<Core_MenuOperationClaimRel> Core_MenuOperationClaimRel { get; set; }
        public  DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
