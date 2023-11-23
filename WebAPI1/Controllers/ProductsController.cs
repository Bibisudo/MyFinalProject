using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.Entity_Framework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI1.Controllers
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
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallbycategoryid")]
        public IActionResult Get(int id) 
        {
            var result = _productService.GetAllByCategoryId(id);
            if(result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);  
        }

        [HttpPost("add")] //Silme ve güncelleme için de bu kullanıyor sektörde.
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
