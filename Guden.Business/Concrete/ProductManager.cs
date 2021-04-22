using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guden.Business.Abstract;
using Guden.Business.ValidationRules.FluentValidation;
using Guden.Core.Aspects.Autofac.Validation;
using Guden.Core.Contants;
using Guden.Core.CrossCuttingConcerns.Validation;
using Guden.Core.Utilities.Results;
using Guden.DataAccess.Abstract;
using Guden.Entities.Concrete;

namespace Guden.Business.Concrete
{
    public class ProductManager:IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        
        public IDataResult< Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult< List<Product>> GetList()
        {
            return new SuccessDataResult <List<Product>>(_productDal.GetList().ToList()) ;
        }

        public IDataResult<List<Product>> GetListByCategoryById(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(p=>p.CategoryId==categoryId).ToList());
        }
        [ValidationAspect(typeof(ProductValidator),Priority =1)]
        public IResult Add(Product product)
        {
            ///Kontroler
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Add(product);
            return new SuccessDataResult<Product>( Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            ///Kontroler
            _productDal.Delete(product);
            return new SuccessDataResult<Product>(Messages.ProductDeleted);
        }

        public IResult Update(Product product)
        {
            ///Kontroler
            _productDal.Update(product);
            return new SuccessDataResult<Product>(Messages.ProductUpdated);
        }
    }
}
