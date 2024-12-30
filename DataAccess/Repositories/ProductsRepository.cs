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
    public class ProductsRepository : IRepository<Product>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        public ProductsRepository(ILogger<ProductsRepository> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        public IEnumerable<Product> GetAll()
        {
            try
            {
                var obj = _context.Products.ToList();
                if (obj != null) return obj;
                else return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Product> GetById(int departmentId)
        {
            try
            {
                
                    var Obj = _context.Products.Where(p => p.DepartmentId == departmentId).ToList();
                    if (Obj != null) return Obj;
                    else return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Product GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public PagedResult<Product> GetPart(int departmentId,int skipCount, int postsPerPage)
        {
            try
            {
                var totalCount = _context.Products
                    .Where(p => p.DepartmentId == departmentId)
                    .Count();
                var products = _context.Products
                                       .Where(p => p.DepartmentId == departmentId)
                                       .Skip(skipCount)
                                       .Take(postsPerPage)
                                       .ToList();

                return new PagedResult<Product>
                {
                    Items = products,
                    TotalCount = totalCount
                }; ;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving products.", ex);
            }
        }
        

    }
}
