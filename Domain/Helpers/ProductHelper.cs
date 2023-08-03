using Domain.APIModels;
using Microsoft.IdentityModel.Tokens;
using RESTfulAPI.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public class ProductHelper
    {
        public string ValidateProduct(Product product, List<Product>products)
        {
            product.Name = product.Name.Trim();
            var uniqueChecker = products.FirstOrDefault(x => x.Name.ToLower() == product.Name.ToLower());
            if (uniqueChecker != null)
            {
                return "Product name has to be unique.";
            }
            if (product.Name.IsNullOrEmpty())
            {
                return "Product name not nullable.";
            }
            if (product.Price <= 0)
            {
                return "Product price has to be greater than zero.";
            }
            return "";
        }
        public IEnumerable<Product> FilterProducts(IEnumerable<Product> products, FilterModel filterModel)
        {
            int result = 0;
            if (!filterModel.Contains.IsNullOrEmpty())
            {
                products = products.Where(x => x.Name.ToLower().Contains(filterModel.Contains.ToLower()));
            }
            if (Int32.TryParse(filterModel.GreaterThan, out result))
            {
                products = products.Where(x => x.Price > result);
            }
            if (Int32.TryParse(filterModel.LessThan, out result))
            {
                products = products.Where(x => x.Price < result);
            }
            if (Int32.TryParse(filterModel.EqualToo, out result))
            {
                products = products.Where(x => x.Price == result);
            }
            if (Int32.TryParse(filterModel.Limit, out result))
            {
                products = products.Take(result);
            }
            if ( Int32.TryParse(filterModel.OffSet, out result))
            {
                products = products.Skip(result);
            }
            return products;
        }
        public string ValidateFilter(FilterModel filterModel)
        {
            int result = 0;
            string validationMessage = "Cannot parse ";
            if (!Int32.TryParse(filterModel.GreaterThan, out result))
            {
                return validationMessage + "greater than";
            }
            if (!Int32.TryParse(filterModel.LessThan, out result))
            {
                return validationMessage + "less than";
            }
            if (!Int32.TryParse(filterModel.EqualToo, out result))
            {
                return validationMessage + "equal too";
            }
            if (!Int32.TryParse(filterModel.Limit, out result))
            {
                return validationMessage + "limit";
            }
            if (!Int32.TryParse(filterModel.OffSet, out result))
            {
                return validationMessage + "offset";
            }
            return "";
        }
    }
}
