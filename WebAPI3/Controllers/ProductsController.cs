using Business.Abstract;
using Business.Concrete;
using Core.Entities.Utilities.Results;
using DataAccess.Concrete.Entity_Framework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
             _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            
            
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
            

        }
        [HttpPost("add")]
        public IActionResult Post(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    
    }

}

//[HttpGet]
//public List<Product> Get()
//{
//    return new List<Product>
//    {
//        new Product {ProductId = 1, ProductName = "Elma" },
//        new Product {ProductId = 2, ProductName = "Armut"}

//    };
//}


//[HttpGet]
//public List<Product> Get()
//{


//    IProductService productService = new ProductManager(new EfProductDal());
//    var result = productService.GetAll();
//    return result.Data;


//}