using DataAccess.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace Services
{
    public class DepartmentServices
    {
        public readonly IRepository<Department> _repository;
        public DepartmentServices(IRepository<Department> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Department> GetAll()
        {
            try
            {
                return _repository.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Department GetByName(string name)
        {
            try
            {
                return _repository.GetByName(name);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
