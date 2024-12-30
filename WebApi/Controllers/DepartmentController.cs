using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using WebApi.Context;
using WebApi.Entities;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentServices _service;

        public DepartmentController(DepartmentServices service)
        {
            _service = service;
        }

        //Get All
        [HttpGet("GetAll")]
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
        [HttpGet("{departmentName}")]
        public JsonResult GetId(string departmentName)
        {
            try
            {
                var result = _service.GetByName(departmentName);
                return new JsonResult(Ok(result));
            }
            catch (Exception)
            {
                throw;
            }
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






    }
}
