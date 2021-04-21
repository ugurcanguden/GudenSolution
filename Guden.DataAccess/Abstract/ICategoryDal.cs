using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guden.Core.DataAccess;
using Guden.Entities.Concrete;

namespace Guden.DataAccess.Abstract
{
    /// <summary>
    /// Varitabanı işlemleri yapılır.
    /// </summary>
   public interface ICategoryDal:IEntityRepository<Category>
    {
        
    }  
}
