using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Guden.Core.DataAccess.EntityFramework;
using Guden.DataAccess.Abstract;
using Guden.DataAccess.Concrete.EntityFramework.Context;
using Guden.Entities.Concrete;

namespace Guden.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal: EfEntityRepositoryBase<Category, GudenDatabaseContext>, ICategoryDal
    {
   
    }
}
