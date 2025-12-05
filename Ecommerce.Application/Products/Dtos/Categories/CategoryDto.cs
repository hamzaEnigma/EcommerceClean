namespace Ecommerce.Application.Products.Dtos.Categories
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public byte[]? Picture { get; set; }

    }
}
