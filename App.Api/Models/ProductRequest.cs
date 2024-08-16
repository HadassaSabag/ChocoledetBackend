namespace App.Api.Models
{
    public class ProductRequest
    {
        public string ProductName { get; set; } = null!;

        public int CategoryId { get; set; }

        public double Price { get; set; }

        public string? ImagePath { get; set; }
    }
}
