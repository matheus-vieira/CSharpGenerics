namespace Generics.Models.Ecommerce
{
    public class Category
    {
        public long? CategoryId { get; set; }
        public string Name { get; set; }
        public virtual System.Collections.Generic.ICollection<Product> Products { get; set; }
    }
}
