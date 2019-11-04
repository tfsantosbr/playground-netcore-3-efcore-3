namespace Products.Domain.Products.Models
{
    public class ProductParameters
    {
        public string Query { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}