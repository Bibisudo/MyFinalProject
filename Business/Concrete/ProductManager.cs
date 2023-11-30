using Business.Abstract;
using Business.Abstract.CSS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTO_s;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal; //injection
       
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
            
        }

       //[ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //business codes
            if(CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success) 
            {
                _productDal.Add(product);
                return new SuccessResult(Messages.ProductAdded);
            }
            return new ErrorResult();
        }

        public IDataResult<List<Product>> GetAll()
        {
           //İş Kodları(ör: yetkisi var mı?) buradan geçerse aşağıya devam ediyor, getall metodu çalışıyor.
            
            //if (DateTime.Now.Hour==22)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);    
            //}
            
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(p=>p.CategoryId==id));
        }


        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice == min && p.UnitPrice == max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)  //bir kategoride en fazla 10 ürün olabilir. (bu bir iş kodu mesela)
                                                                              //İş kuralı parçacığı sadece bu class içinde kullanacağım için private. Sonra bunu alıp kullacağım metodun içerisine yazabilirim. Check Add();.
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists ( string productName) 
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result) //result true demek bu. Yani böyle bir data varsa. ----  !result yazsaydık result false demekti.
            { 
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
