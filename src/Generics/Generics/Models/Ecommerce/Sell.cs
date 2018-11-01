using System.ComponentModel.DataAnnotations;

namespace Generics.Models.Ecommerce
{
    public class Sell
    {
        public long? SellId { get; set; }
        public long? SellNumber { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public System.DateTime Date { get; set; }
        public string BuyerName { get; set; }
        public string BuyerDoc { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal TotalPrice { get; set; }
        public bool Closed { get; set; }
        public virtual System.Collections.Generic.ICollection<SellItem> SellItems { get; set; }
    }
}