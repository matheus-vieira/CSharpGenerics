namespace Generics.Models.Filter
{
    public class ProductFilter : GenericFilter<Models.Ecommerce.Product>
    {
        public string Category { get; set; }
        public string Supplier { get; set; }

        public override void AddViewData(Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary viewData)
        {
            base.AddViewData(viewData);

            viewData["FilterCategory"] = Category;
            viewData["FilterSupplier"] = Supplier;
        }
    }
}