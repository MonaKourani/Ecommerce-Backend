using Microsoft.AspNetCore.Http;

namespace WebApi.Entities
{
    public class ProductRequest
    {
        public string ProductName { get; set; } = null!;
        public string Price { get; set; } = null!;
        public string Rating { get; set; } = null!;
        public int DepartmentId { get; set; }
        public IFormFile ImageFile { get; set; } = null!; // Handle the uploaded file
    }

}
