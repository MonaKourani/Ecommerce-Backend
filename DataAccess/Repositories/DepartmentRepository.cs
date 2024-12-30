using DataAccess.Contacts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Context;
using WebApi.Entities;

namespace DataAccess.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        public DepartmentRepository(ILogger<ProductsRepository> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IEnumerable<Department> GetAll()
        {
            try
            {
                var obj = _context.departments.ToList();
                if (obj != null) return obj;
                else return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Department> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Department GetByName(string name)
        {
            try
            {
                var department = _context.departments.Where(p => p.Name == name).ToList();
                if (department != null) return department.First();
                else return null;
            }
            catch (Exception)
            {
                throw;
            }
            
           
        }

        public IEnumerable<Department> GetSearchResult(int departmentId, string search)
        {
            throw new NotImplementedException();
        }

        PagedResult<Department> IRepository<Department>.GetPart(int departmentId, int currentPage, int postsPerPage)
        {
            throw new NotImplementedException();
        }
    }
}
