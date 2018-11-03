namespace Generics.Models.Filter
{
    public class GenericFilter<TFilter> : IFilter
        where TFilter : class
    {
        public string Name { get; set; }

        public virtual void AddViewData(Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary viewData)
        {
            viewData["FilterName"] = Name;
        }
    }
}
