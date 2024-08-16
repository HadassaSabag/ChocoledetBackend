

namespace App.DTO.Models
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public virtual ICollection<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}
