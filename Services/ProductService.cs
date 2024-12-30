using DataAccess.Contacts;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace Services
{
    public class ProductService
    {
        public readonly IRepository<Product> _repository;
        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Product> GetAll()
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
        public IEnumerable<Product> GetByDepartmentId(int Id)
        {
            try
            {
                return _repository.GetById(Id).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public PagedResult<Product> GetPart(int departmentId,int currentPage, int postsPerPage)
        {
            try
            {
                var skipCount = (currentPage - 1) * postsPerPage;


                return _repository.GetPart(departmentId, skipCount, postsPerPage) ;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving products.", ex);
            }
        }
        public IEnumerable<Product> GetSearchResult(int departmentId, string search)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(search))
                {
                    return null;
                }
                return _repository.GetSearchResult(departmentId, search);

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving search result.", ex);
            }
        }
    }
}
