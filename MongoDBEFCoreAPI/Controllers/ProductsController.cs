using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MongoDBEFCoreAPI.Models;

namespace MongoDBEFCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        MongoDbContext _context;

        public ProductsController(MongoDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(Product product)
        {
            product.Id = 1;

            _context.Products.Add(product);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            return Ok(_context.Products);
        }
    }
}
