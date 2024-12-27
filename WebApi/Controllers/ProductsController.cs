using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Context;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create
        [HttpPost]
        public IActionResult CreateProduct([FromForm] ProductRequest request)
        {
            if (request.ImageFile == null || request.ImageFile.Length == 0)
            {
                return BadRequest("Image file is required.");
            }

            using var memoryStream = new MemoryStream();
            request.ImageFile.CopyTo(memoryStream);
            var imageBytes = memoryStream.ToArray();

            var product = new Product
            {
                ProductName = request.ProductName,
                Price = request.Price,
                Rating = request.Rating,
                DepartmentId = request.DepartmentId,
                Images = imageBytes
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return Ok(product);
        }


        // Get Product by ID
        /*
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var result = _context.Products.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }
        */
        // Delete Product
        /*
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var result = _context.Products.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Products.Remove(result);
            _context.SaveChanges();
            return new JsonResult(Ok(result));
        }
        */
        // Get All Products
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Products.ToList();
            return new JsonResult(Ok(result));
        }
        
        [HttpGet("{departmentId}")]
        public JsonResult GetByDepartmentId(int departmentId)
        {
            var products = _context.Products.Where(p => p.DepartmentId == departmentId).ToList();
            if (!products.Any())
            {
                return new JsonResult(NotFound($"No products found for Department ID: {departmentId}"));
            }
            return new JsonResult(Ok(products));
        }


    }
}
