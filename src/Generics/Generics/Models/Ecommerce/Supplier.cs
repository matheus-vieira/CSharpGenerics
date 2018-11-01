namespace Generics.Models.Ecommerce
{
    public class Supplier
    {
        public long? SupplierId { get; set; }
        public string Name { get; set; }

        public virtual System.Collections.Generic.ICollection<Product> Products { get; set; }
    }
}