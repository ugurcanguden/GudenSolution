using System;
using System.Collections.Generic;
using System.Linq;
using Guden.Business.Abstract;
using Guden.Business.ValidationRules.FluentValidation;
using Guden.Core.Aspects.Autofac.Validation;
using Guden.Core.Contants;
using Guden.Core.CrossCuttingConcerns.Validation;
using Guden.Core.Entities.Utilities;
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

        public IDataResult<PagerResult<Product>> GetList(PagerRequest pagerRequest)
        {
                var result=  Guden.Core.Utilities.ToolUtilities
                            .PagerResult<Product>
                            .GetPagerRequest(_productDal.GetList().ToList(),  pagerRequest);

            return new SuccessDataResult<PagerResult<Product>>(result);
        }

        public IDataResult<List<Product>> GetListByCategoryById(int categoryId)
        { 
            return new SuccessDataResult<List<Product>>(_productDal.GetList(p => p.CategoryId == categoryId).ToList());
        }
        [ValidationAspect(typeof(ProductValidator),Priority =1)]
        public Result Add(Product product)
        {
            ///Kontroler
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Add(product);
            return new SuccessDataResult<Product>( Messages.ProductAdded);
        }

        public Result Delete(Product product)
        {
            ///Kontroler
            _productDal.Delete(product);
            return new SuccessDataResult<Product>(Messages.ProductDeleted);
        }

        public Result Update(Product product)
        {
            ///Kontroler
            _productDal.Update(product);
            return new SuccessDataResult<Product>(Messages.ProductUpdated);
        }
    }
}
