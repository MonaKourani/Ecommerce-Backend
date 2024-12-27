using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Context;
using WebApi.Entities;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // create/Edit
        /*[HttpPost]
        public JsonResult CreateEdit (Department department)
        {
            if (department.Id == 0)
            {
                _context.departments.Add(department);
            }
            else
            {
                var departmentDb = _context.departments.Find(department.Id);
                if (departmentDb == null) { return new JsonResult(NotFound()); }
                department.Id = department.Id;
                departmentDb.Name = department.Name;
            }
            _context.SaveChanges();
            return new JsonResult(Ok(department));
        }
        */


        //Get
        /*
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.departments.Find(id);
            if (result == null) { 
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }
        */


        //Delete
        /*
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.departments.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            _context.departments.Remove(result);
            _context.SaveChanges();
            return new JsonResult(Ok(result));
        }
        */

        //Get All
        [HttpGet("GetAll")]
        public JsonResult GetAll()
        {
            var result = _context.departments.ToList();
            return new JsonResult(Ok(result));
        }
        [HttpGet("{departmentName}")]
        public JsonResult GetId(string departmentName)
        {
            var department = _context.departments.Where(p => p.Name == departmentName).ToList();
            if (!department.Any())
            {
                return new JsonResult(NotFound($"No products found for Department ID: {departmentName}"));
            }
            int id = department.First().Id;
            return new JsonResult(Ok(id));
        }




    }
}
