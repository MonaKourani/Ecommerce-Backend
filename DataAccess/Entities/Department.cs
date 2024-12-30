using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
