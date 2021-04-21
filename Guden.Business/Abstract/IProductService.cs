using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guden.Core.Utilities.Results;
using Guden.Entities.Concrete;

namespace Guden.Business.Abstract
{
    public interface IProductService
    {
        IDataResult<Product> GetById(int productId);
        IDataResult<List<Product>>GetList();
        IDataResult<List<Product>> GetListByCategoryById(int categoryId);
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);


    }
}
