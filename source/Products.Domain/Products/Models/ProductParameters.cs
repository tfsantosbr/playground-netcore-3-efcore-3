namespace Products.Domain.Products.Models
{
    public class ProductParameters
    {
        public string Query { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 25;
    }
}