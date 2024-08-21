using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.Shop.Business.Interfaces;
using WebStore.Shop.Domain.Models;

namespace WebStore.Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.Get();
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var product = _productService.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _productService.Get(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _productService.Delete(id);
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            _productService.Create(product);
            return NoContent();
        }
    }
}
