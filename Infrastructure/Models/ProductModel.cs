using RESTfulAPI.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public static Expression<Func<Product, ProductModel>> Projection
        {
            get
            {
                return x => new ProductModel
                {
                    Name = x.Name,
                    Id = x.Id,
                    Price = x.Price,
                };
            }
        }
    }
}
