using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
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
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
                return Ok(result.Data);
            
        }

        [HttpPost]
        public IActionResult Post(Product  product)
        {
            var result = _productService.Add(product);
            return Ok(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetByid(int productid)
        {
            var result = _productService.GetProductId(productid);
            return Ok(result.Data);

        }
    }
}
