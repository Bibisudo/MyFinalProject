using Business.Abstract;
using Core.Entities.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTO_s;
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

        public IResult Add(Product product)
        {
            if (product.ProductName.Length<2)
            {
                return new ErrorResult("Ürün ismi min 2 karakter olmalı.");
            }
            _productDal.Add(product);
            return new SuccessResult("Ürün eklendi.");
        }

        public List<Product> GetAll()
        {
            //İş Kodları(ör: yetkisi var mı?) buradan geçerse aşağıya devam ediyor, getall metodu çalışıyor.
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p=>p.CategoryId==id);
        }

        public Product GetById(int productId)
        {
            return _productDal.GetById(p=>p.ProductId==productId);  
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice == min && p.UnitPrice == max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
