using DataAccess.Contacts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services;
using WebApi.Context;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        // Get All Products
        [HttpGet]
        public JsonResult GetAll()
        {
            
            try
            {
                var result = _service.GetAll();
                return new JsonResult(Ok(result));
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        [HttpGet("{departmentId}")]
        public JsonResult GetByDepartmentId(int departmentId)
        {
            try
            {
                var result = _service.GetByDepartmentId(departmentId);
                return new JsonResult(Ok(result));
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("{departmentId}/{currentPage}/{postsPerPage}")]
        public JsonResult GetPart(int departmentId,int currentPage,int postsPerPage)
        {
            try
            {
                var result = _service.GetPart(departmentId,currentPage,postsPerPage);
                return new JsonResult(Ok(result));
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Create
        /*
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

        */
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



    }
}
