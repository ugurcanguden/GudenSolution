using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guden.Core.Entities.Utilities;
using Guden.Core.Utilities.Results;
using Guden.Entities.Concrete;

namespace Guden.Business.Abstract
{
    public interface IProductService
    {
        IDataResult<Product> GetById(int productId);
        IDataResult<PagerResult<Product>> GetList(PagerRequest pagerRequest);
        IDataResult<List<Product>> GetListByCategoryById(int categoryId);
        Result Add(Product product);
        Result Delete(Product product);
        Result Update(Product product);


    }
}
