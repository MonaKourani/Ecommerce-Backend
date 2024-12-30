using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; } = null!;
        [Required]
        public string Price { get; set; } = null!;
        [Required]
        public string Rating { get; set; } = null!;
        [Required]
        public int DepartmentId { get; set; } 
        [Required]
        public byte[]? Images { get; set; } = null!;

        public Department Department { get; set; }
    }
}
