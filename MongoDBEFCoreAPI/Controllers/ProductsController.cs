using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        
        /*SQLDbContext _context;

        public ProductsController(SQLDbContext context)
        {
            _context = context;
        }*/

        //Add Product

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(Product product)
        {

            //var lastId = _context.Products.Count() > 0 ? _context.Products.Last().Id + 1 : 1;

            _context.Products.Add(product);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        //Get All Products

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            return Ok(_context.Products);
        }

        //Get Product based on Id
        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
           var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(product);
        }

        //Delete Product based on Id
        [HttpDelete("DeleteById")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id.ToString() == id.ToString());
            _context.Products.Remove(product!);
            _context.SaveChanges();

            return Ok(_context.Products);
        }


    }
}
