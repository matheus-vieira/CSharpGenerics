using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generics.Models.Ecommerce
{
    public class Product
    {
        public long? ProductId { get; set; }
        public string Name { get; set; }
        [Range(1, 100000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public bool Deleted { get; set; }
        public long? CategoryId { get; set; }
        public Category Category { get; set; }
        public long? SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public virtual ICollection<SellItem> SellItems { get; set; }
    }
}