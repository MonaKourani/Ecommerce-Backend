using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contacts
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
    }
    public interface IRepository<T>
    {
        //public Task<T> Create(T _object);
        //public void Delete(T _object);
        //public void Update(T _object);
        public IEnumerable<T> GetAll();
        public PagedResult<T> GetPart(int departmentId,int currentPage,int postsPerPage );
        public IEnumerable<T> GetById(int Id);
        public T GetByName(string name);
    }
}
