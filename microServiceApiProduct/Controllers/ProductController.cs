using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace microServiceApiProduct.Controllers
{    
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }
               

        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            var products = InMemoryContext.GetProducts();
            return products is null ? NotFound($"not_found")
                : (IActionResult)Ok(products);

        }

        [HttpGet("GetProductByCode")]
        public IActionResult GetProductByCode(string code)
        {
            var product = InMemoryContext.GetProductByCode(code);
            return product is null ? NotFound($"not_found_{code}")
                : (IActionResult)Ok(product);

        }

        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct(Product product)
        {
            var result = InMemoryContext.AddProduct(product);
            return !result ? BadRequest("bad request") : Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteProduct(Product product)
        {
            var result = InMemoryContext.DeleteProduct(product);
            return !result ? BadRequest("bad request") : Ok();
        }

    }
}
